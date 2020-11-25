using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cephei.Cell.Generic
{
    /// <summary>
    /// Cell is a generic holder (<i>like lazy</i>), but the value is dependant on the
    /// functional relationship to the values that it is derived from. Irrespective of
    /// the current value of the referenced cells, this cell's value will always
    /// reflect the value of its underling values.
    /// For <i>x = f (y)</i> the formula <i>f </i>is treated as a relationship of the
    /// set of values of <i>x</i> that are related to the set of values of <i>y</i> by
    /// the relationship <i>f</i>
    /// 
    /// The paradigm  is that of a spreadsheet that automatically recalculates, but
    /// with the addition that the calculation is performed asynchronously in parallel
    /// for large models.
    /// 
    /// cells are best used when the function captures compute intensive calculations
    /// (like an PV function for a derivative contract.
    /// 
    /// If the model contains a thousand different possible values for an interest rate,
    /// the model can define 1000 NPV functions and a cell that with the average
    /// exposure and the 95% confidence value of potential exposure.  When valued most
    /// calculations will be performed in parallel.
    /// </summary>
    public class Cell<T> : ICell<T>
    {
        /// <summary>
        /// reference to the function to evaluate
        /// </summary>
        private FSharpFunc<Unit, T> _func;
        /// <summary>
        /// A spin lock is used to control access to the state pointer.  The protocol is
        /// that the spin lock is only held while reading or writing state - calculations
        /// release the spin lock before eval, and re-acquire when changing value.  With
        /// this protocol spinlock is efficient even in highly contentious scenarios
        /// </summary>
        private SpinLock _spinLock = new SpinLock(true);
        /// <summary>
        /// Event is fired from every transition for Blocking State
        /// </summary>
        private volatile ManualResetEvent _event = new ManualResetEvent(false);

        /// <summary>
        /// reference to the state.  It is held as an integer to allow cache bypass read
        /// and write
        /// </summary>
        private volatile int _state = (int)CellState.Dirty;
        /// <summary>
        /// Holder of the lock while calculating
        /// </summary>
        private Thread _lockHolder = null;
        /// <summary>
		/// cached value of the last calculation
		/// </summary>
        private T _value;
        /// <summary>
        /// Because calculation is performed in parallel, any exceptions are saved for
        /// throw when the value is used
        /// </summary>
        private Exception _lastException = null;
        /// <summary>
        /// The timestamp of the last calculation  Used to prevent Cells spot being updated 
        /// by earlier events that have been scheduled later than more recent evens
        /// </summary>
        private DateTime _epoch;

        /// <summary>
		/// if it has not been linked then need to gather dependencies.  True when
		/// calculation cells are first created, and reset if on of the boolean values it
		/// is dependant on changes
		/// </summary>
        private bool _link = true;
        /// <summary>
		/// if true then trigger re-link to capture other dependencies.  It is presumed
		/// that boolean cells are used to allow for re-profiling when a value changes
		/// </summary>
        private bool _isBool = typeof(T) == typeof(bool) || typeof(T) == typeof(Boolean);
        // only re-link if this value has not been provided before
        private bool _flip = true;

        /// <summary>
		/// number of pending calculations for sessions, to allow parallel overlapped
		/// calculation
		/// </summary>
        volatile int _pending;

        /// <summary>
        /// Has this cell been disposed, buy wating for references to be cleared
        /// </summary>
        private bool _disposd = false;

        public string Mnemonic { get; set; }
        public ICell Parent { get; set; }

        /// <summary>
        /// Create the cell with the F# function.  If used from C#, the Func<> formula can
        /// be converted to an F# function for usage
        /// use FuncConvert.FromFunc for C# functions
        /// </summary>
        /// <param name="func"></param>
        public Cell(FSharpFunc<Unit, T> func)
        {
            _func = func;
            if (Cell.Parellel && !Cell.Lazy)
                Task.Run(() => 
                    {
                        try 
                        { 
                            Calculate(DateTime.Now, 0); 
                        } catch { } 
                    });
            else if (!Cell.Lazy)
                Calculate(DateTime.Now, 0);
        }
        /// <summary>
        /// Create a cell with a mnemonic reference
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mnemonic"></param>
        public Cell(FSharpFunc<Unit, T> func, string mnemonic) : this(func)
        {
            Mnemonic = mnemonic;
        }
        /// <summary>
        /// Cretate a cell with a a mutable value
        /// </summary>
        /// <param name="value"></param>
        public Cell(T value)
        {
            _value = value;
            _state = (int)CellState.Clean;
        }
        /// <summary>
        /// Create a Cell with a value and a memonic reference
        /// </summary>
        /// <param name="value"></param>
        /// <param name="mnemonic"></param>
        public Cell(T value, string mnemonic) : this(value)
        {
            Mnemonic = mnemonic;
        }
        /// <summary>
        /// Link return allows for dependent cells visited during a calculation to be
        /// referenced for change notification.
        /// The protocol is that Cells that are being profiled are pushed onto the stack,
        /// so any cell visited during evaluation <u>must</u> be a dependency.
        /// 
        /// Normally there will be no values on the stack because profiling only occurs
        /// when a cell is first evaluated, or notified of a change of logic
        /// </summary>
        /// <param name="t"></param>
#if !DEBUG
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private T LinkReturn(T t)
        {
            var s = Cell.Current.Value;
            var c = s.Peek();
            if (c != null)
            {
                if (this == c) return t;
                    bool already = false;
                    foreach (var v in c.Dependants)
                    {
                        if (v == this)
                        {
                            already = true;
                            break;
                        }
                    }
                    if (!already) this.Change += c.OnChange;
            }
            return t;
        }
        /// <summary>
        /// Internal calculation function, that is triggered either by:
        /// <ol>
        /// 	<li>Creation of a cell with a formula (executed asynchronously</li>
        /// 	<li>the Request of a value when the state is dirty</li>
        /// 	<li>when triggered by the change of a cell that it si dependant on</li>
        /// </ol>
        /// </summary>
        /// <param name="epoch"></param>
        /// <param name="recurse"></param>
        /// <param name="session"></param>
#if !DEBUG
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private T Calculate(DateTime epoch, int recurse, ISession session = null)
        {
            if (recurse > 60) throw new LockRecursionException();
            bool taken = false;
            bool pushed = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (taken)
                {
                    if (_state == (int)CellState.Clean && session == null || (_epoch > epoch && session == null))
                        return _value;      // don't recalculate for read
                    SetState(CellState.Calculating);
                    _spinLock.Exit(true);
                    taken = false;
                    if (_link)
                    {
                        Cell.Current.Value.Push(this);
                        pushed = true;
                    }

                    var t = (_func != null ? _func.Invoke(null) : _value);
                    if (session != null)
                        session.SetValue<T>(this, t);

                    while (taken == false)
                    {
                        // sleep through massive contention
                        _spinLock.Enter(ref taken);
                        if (!taken)
                        {
                            Thread.Sleep(recurse++ * 100);
                            return Calculate(epoch, recurse, session);
                        }
                    }
                    if (epoch >= _epoch)
                    {
                        _epoch = epoch;
                        _value = t;
                    }
                    SetState(CellState.Clean);
                    if (_pending > 0)
                    {
                        if (session != null)
                            _pending--;
                    }
                    if (pushed)
                    {
                        Cell.Current.Value.Pop();
                        _link = false;
                        pushed = false;
                    }
                    if (_isBool && _flip && (Convert.ToBoolean(t) != Convert.ToBoolean(_value)))
                    {
                        _flip = false;
                        RaiseChange(CellEvent.Link, this, this, _epoch, session);

                    }
                    return LinkReturn(t);
                }
                else
                {
                    Thread.Sleep(recurse * 100);
                    return Calculate(epoch, recurse + 1, session);     // edge case retry lock
                }
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, "Calculation failed for {0} with error {1}", Mnemonic, e.Message);
                _lastException = new CalculationException(e);
                SetState(CellState.Error);
                RaiseChange(CellEvent.Error, this, this, epoch, null);

                throw;
            }
            finally
            {
                if (pushed)
                {
                    Cell.Current.Value.Pop();
                    _link = false;
                }
                if (taken) _spinLock.Exit(true);
            }
        }
        /// <summary>
        /// Internal function used by Value property to get the current value of a Cell.
        /// This is a function to allow for lock contention and to retry if the state has
        /// changed whilst waiting.
        /// If the cell is dirty when a value is required, the caculate function is called
        /// </summary>
        /// <param name="recurse"></param>
        public T GetValue(int recurse)
        {
            if (recurse > 60) throw new LockRecursionException();
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (!taken)
                {
                    Thread.Sleep(recurse * 100);
                    return GetValue(recurse + 1);                   // edge case lock failed
                }
                if (_pending > 0)
                    if (Interlocked.Exchange(ref _state, (int)CellState.Dirty) == (int)CellState.Blocking)
                        if (Interlocked.Exchange(ref _state, (int)CellState.Blocking) == (int)CellState.Clean)
                            SetState(CellState.Dirty);

                switch (_state)
                {
                    case (int)CellState.Clean:
                        var v = _value;
                        _spinLock.Exit(true);
                        taken = false;
                        if (v == null && _lastException == null)
                        {
                            SetState(CellState.Dirty);
                            return GetValue(recurse + 1);
                        }    
                        var ses = Session.Current;
                        if (ses != null && ses.HasJoined(this))
                        {
                            if (ses.GetValue<T>(this, ref v))
                                return LinkReturn(v);
                            else
                                return Calculate(DateTime.Now, recurse + 1);     // edge case for read before write
                        }
                        return LinkReturn(v);

                    case (int)CellState.Calculating:
                    case (int)CellState.Blocking:
                        Interlocked.Exchange(ref _state, (int)CellState.Blocking);
                        _spinLock.Exit(true);
                        taken = false;
                        for (int c = 0; c < 60000; c += 100)
                        {
                            if (_event.WaitOne(c) || _state != (int)CellState.Blocking || _lockHolder == null || !_lockHolder.IsAlive || _lockHolder == Thread.CurrentThread)
                                break;
                        }
                        if (_state != (int)CellState.Clean)
                            return Calculate(DateTime.Now, recurse + 1);
                        else
                            return GetValue(recurse + 1);           // re-read through lock

                    case (int)CellState.Dirty:
                        SetState(CellState.Calculating);
                        _spinLock.Exit(true);
                        taken = false;
                        return Calculate(DateTime.Now, recurse + 1);

                    case (int)CellState.Error:
                        throw _lastException;

                    default:
                        return GetValue(recurse + 1);           // edge case
                }
            }
            finally
            {
                if (taken) _spinLock.Exit(true);
            }
        }
        public T Value
        {
            get
            {
                return GetValue(0);
            }
            set
            {
                bool taken = false;
                try
                {
                    _spinLock.Enter(ref taken);
                    if (taken)
                    {
                        SetState(CellState.Clean);
                        var ses = Session.Current;
                        if (_isBool && _flip && (Convert.ToBoolean(value) != Convert.ToBoolean(_value)))
                        {
                            _flip = false;
                            RaiseChange(CellEvent.Link, this, this, _epoch, ses);

                        }
                        _value = value;
                        _epoch = DateTime.Now;
                        _state = (int)CellState.Clean;
                        _spinLock.Exit(true);
                        taken = false;
                        if (ses != null)
                        {
                            ses.SetValue<T>(this, value);
                            RaiseChange(CellEvent.JoinSession, this, this, DateTime.Now, ses);

                        }
                        else
                            RaiseChange(CellEvent.Calculate, this, this, _epoch, ses);

                    }
                }
                finally
                {
                    if (taken) _spinLock.Exit(true);
                }
            }
        }

        public IEnumerable<ICellEvent> Dependants
        {
            get
            {
                if (Change != null)
                {
                    bool taken = false;
                    ICellEvent[] r = null;
                    while (taken == false)
                    {
                        _spinLock.Enter(ref taken);
                        if (taken)
                        {
                            var l = Change.GetInvocationList();
                            r = new ICellEvent[l.Length];
                            for (int c = 0; c < l.Length; ++c)
                            {
                                r[c] = l[c].Target as ICellEvent;
                            }
                        }
                        else
                            Thread.Sleep(100);

                    }
                    if (taken) _spinLock.Exit();
                    return r;
                }
                else
                    return new ICellEvent[0];
            }
        }

        public event CellChange Change;

        public void Dispose()
        {
            _disposd = true;
            RaiseChange(CellEvent.Delete, this, this, DateTime.Now, null);

            Change = delegate { };
        }

        private void PoolCalculate(DateTime epoch, ISession session)
        {
            var lastsession = Session.Current;
            Session.Current = session;
            Calculate(epoch, 0, session);
            RaiseChange(CellEvent.Calculate, this, this, epoch, session);

            Session.Current = lastsession;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (Change != null)
                Change(eventType, root, this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root,  this, epoch, session);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Cephei.Cell.CellState SetState(CellState value)
        {
            if (value == CellState.Calculating)
            {
                _lockHolder = Thread.CurrentThread;
            }
            else if (value == CellState.Clean)
            {
                _lockHolder = null;
            }
            var s = (CellState)Interlocked.Exchange(ref _state, (int)value);
            if (s == CellState.Blocking)
            {
                _event.Set();
                _event.Reset();
            }
            return s;
        }
        public FSharpFunc<Unit, T> Function
        { 
            get
            {
                return _func;
            }
            set
            {
                _func = value;
            }
        }

        public void Merge(ICell source, Model model)
        {
            if (source != this)
            {
                var c = (ICell<T>)source;
                var f = _func;
                _func = c.Function;
                c.Function = f;
                Parent = c.Parent;
                _state = (int)CellState.Dirty;
            }

            // handle update of current while this cell is being constructed
            if (Parent is Model m)
            {
                var cur = m[this.Mnemonic];
                if (cur != this && cur != null && cur.GetType() == this.GetType())
                    cur.Merge(this, model);
            }
            RaiseChange(CellEvent.CyclicCheck, this, this, DateTime.Now, null);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        public virtual void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {
            if (_disposd && root != this && eventType != CellEvent.Delete) sender.OnChange(CellEvent.Delete, this, this, epoch, session);
            switch (eventType)
            {
                case CellEvent.Calculate:
                    if (session != null && session.State == SessionState.Open)
                        _pending++;
                    else if (epoch > _epoch)
                    {
                        _epoch = epoch;
                        OnChange(CellEvent.Invalidate, root, this, epoch, session);
                        if (Cell.Parellel)
                            Task.Run(() =>
                            {
                                try
                                {
                                    PoolCalculate(epoch, session);
                                }
                                catch (Exception e)
                                {
                                    Serilog.Log.Error(e, e.Message);
                                }
                            });
                        else
                            PoolCalculate(epoch, session);
                    }
                    break;
                case CellEvent.Delete:
                    _link = true;
                    Change -= root.OnChange;
                    break;
                case CellEvent.Invalidate:
                    var lastState = (CellState)Interlocked.Exchange(ref _state, (int)CellState.Dirty);
                    if (lastState == CellState.Calculating || lastState == CellState.Blocking)
                        lastState = (CellState)Interlocked.Exchange(ref _state, (int)lastState);
                    else
                        RaiseChange(eventType, root, this, epoch, session);
                    break;
                case CellEvent.Link:
                    _link = true;
                    _flip = true;
                    if (_func != null)
                        SetState(CellState.Dirty);
                    RaiseChange(eventType, root, this, epoch, session);
                    break;

                case CellEvent.JoinSession:
                    session.Join(this);
                    RaiseChange(eventType, root, this, epoch, session);
                    break;

                case CellEvent.Error:
                    bool taken = false;
                    _spinLock.Enter(ref taken);
                    while (!taken)
                    {
                        Thread.Yield();
                        _spinLock.Enter(ref taken);
                    }
                    SetState(CellState.Error);
                    _spinLock.Exit();
                    break;
                case CellEvent.CyclicCheck:
                    if (root == this)
                        throw new CyclicDependencyException();
                    else
                        RaiseChange(eventType, root, this, epoch, session);
                    break;
            }
        }

        /// <see cref="ICell.HasFunction"/>
        public bool HasFunction => _func != null;
        /// <see cref="ICell.HasValue"/>
        public bool HasValue => (_func != null && !_link) || _func == null;

        /// <see cref="ICell.Box"/>
        public object Box 
        { 
            get
            {
                return Value;
            }
            set
            {
                Value = (T)value;
            }
        }

        public bool ValueIs<Base>()
        {
            return typeof(Base).IsAssignableFrom(typeof(T)) ||
                   typeof(T).IsSubclassOf(typeof(Base));
        }

        #region observable
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return new CellObserver<T>(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, T>>> observer)
        {
            return new SessionObserver<T>(this, observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>> observer)
        {
            return new TraceObserver<T>(this, observer);
        }
        #endregion
        #region observer
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            _lastException = error;
            SetState(CellState.Error);
        }

        public void OnNext(T value)
        {
            Value = value;
        }

        public void Notify(ICell listener)
        {
            if (listener == this) return;
            foreach (var v in Dependants)
                if (v == listener)
                    return;
            Change += listener.OnChange;
        }

        public void UnNotify(ICell listener)
        {
            Change -= listener.OnChange;
        }
        public object GetFunction()
        {
            return _func;
        }

        #endregion
    }
}
