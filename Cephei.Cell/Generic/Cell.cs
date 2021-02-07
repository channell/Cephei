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
        private Lazy<ManualResetEvent> _event = new Lazy<ManualResetEvent>(() => new ManualResetEvent(false));

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

        /// <summary>
        /// object that need to be locked during evaluation of func
        /// </summary>
        public ICell Mutex { get; set; }

        /// <summary>
        /// Identifier for the Cell
        /// </summary>
        public string Mnemonic { get; set; }
        private ICell _parent;

        /// <summary>
        /// Parent of the Cell, when arranged in a hierarchy (including Model, which is a dictionary and a Cell
        /// </summary>
        public ICell Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent == null || _parent.Parent != value)
                    _parent = value;
            }
        }

        /// <summary>
        /// Create the cell with the F# function.  If used from C#, the Func<> formula can
        /// be converted to an F# function for usage
        /// use FuncConvert.FromFunc for C# functions
        /// </summary>
        /// <param name="func"></param>
        public Cell(FSharpFunc<Unit, T> func)
        {
            _func = func;
            if (!Cell.Lazy)
                Cell.Dispatch(() => 
                    {
                        try 
                        { 
                            Calculate(DateTime.Now, 0); 
                        } 
                        catch (Exception e)
                        {
                            Serilog.Log.Error(e, e.Message);
                        } 
                    });
        }
        /// <summary>
        /// Create a cell with a mnemonic reference
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mutex"></param>
        public Cell(FSharpFunc<Unit, T> func, ICell mutex) : this(func)
        {
            Mutex = mutex;
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
        /// Create a cell from C# function
        /// </summary>
        /// <param name="func">C# function</param>
        public Cell(Func<T> func) : this(FuncConvert.FromFunc<T>(func))
        { }
        /// <summary>
        /// Create a cell from C# function
        /// </summary>
        /// <param name="func">C# function</param>
        public Cell(Func<T> func, ICell mutex) : this(FuncConvert.FromFunc<T>(func), mutex)
        { }

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
                    SetState(CellState.Calculating, ref taken);
                    if (_link)
                    {
                        Cell.Current.Value.Push(this);
                        pushed = true;
                    }

                    T t;
                    if (_func != null)
                    {
                        if (Mutex == null)
                            t = _func.Invoke(null);
                        else
                        {
                            lock (Mutex)
                            {
                                t = _func.Invoke(null);
                            }
                        }
                    }
                    else
                        t = _value;

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
                    SetState(CellState.Clean, ref taken);
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
                        RaiseChange(CellEvent.Link, this, null, _epoch, session);

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
                if (!taken) _spinLock.Enter(ref taken);
                SetState(CellState.Error, ref taken);
                RaiseChange(CellEvent.Error, this, null, epoch, null);

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
                            SetState(CellState.Dirty, ref taken);

                switch (_state)
                {
                    case (int)CellState.Clean:
                        var v = _value;
                        if (v == null && _lastException == null)
                        {
                            SetState(CellState.Dirty, ref taken);
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
                    case (int)CellState.Dirty:
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
                        SetState(CellState.Clean, ref taken);
                        var ses = Session.Current;
                        if (_isBool && _flip && (Convert.ToBoolean(value) != Convert.ToBoolean(_value)))
                        {
                            _flip = false;
                            RaiseChange(CellEvent.Link, this, null, _epoch, ses);

                        }
                        _value = value;
                        _epoch = DateTime.Now;
                        SetState(CellState.Clean, ref taken);
                        if (ses != null)
                        {
                            ses.SetValue<T>(this, value);
                            RaiseChange(CellEvent.JoinSession, this, null, DateTime.Now, ses);

                        }
                        else
                            RaiseChange(CellEvent.Calculate, this, null, _epoch, ses);

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
            RaiseChange(CellEvent.Delete, this, null, DateTime.Now, null);

            Change = delegate { };
        }

        private void PoolCalculate(DateTime epoch, ISession session)
        {
            var lastsession = Session.Current;
            Session.Current = session;
            Calculate(epoch, 0, session);
            RaiseChange(CellEvent.Calculate, this, null, epoch, session);

            Session.Current = lastsession;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (sender == this) return;
            if (Change != null)
                Change(eventType, root, this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType | CellEvent.Logging, root, this, epoch, session);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Cephei.Cell.CellState SetState(CellState value, ref bool taken)
        {
        retry: // used to enable AggressiveInlining
            var was = (CellState)Interlocked.Exchange(ref _state, (int)value);
            switch (was)
            {
                case CellState.Blocking:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                            _lockHolder = null;
                            _event.Value.Set();
                            _event.Value.Reset();
                            break;
                        case CellState.Dirty:
                        case CellState.DirtyIfClean:
                        case CellState.Calculating:
                        case CellState.Blocking:
                            Interlocked.Exchange(ref _state, (int)CellState.Blocking);
                            int cnt = 0;
                            if (taken)
                            {
                                _spinLock.Exit();
                                taken = false;
                            }
                            while (_lockHolder != null && _lockHolder != Thread.CurrentThread && _lockHolder.IsAlive && _state == (int)CellState.Blocking)
                            {
                                _event.Value.WaitOne(2000);
                                if (!Cell.IO && ++cnt > 5 && _lockHolder.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                                    _lockHolder.Interrupt();
                                else
                                    cnt = 0;
                            }
                            if (_lockHolder != null)
                                goto retry; // used to enable AggressiveInlining
                            break;
                    }
                    break;
                case CellState.Calculating:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                            _lockHolder = null;
                            break;
                        case CellState.DirtyIfClean:
                        case CellState.Calculating:
                        case CellState.Blocking:
                            Interlocked.Exchange(ref _state, (int)CellState.Blocking);
                            int cnt = 0;
                            if (taken)
                            {
                                _spinLock.Exit();
                                taken = false;
                            }
                            while (_lockHolder != null && _lockHolder != Thread.CurrentThread && _lockHolder.IsAlive && _state == (int)CellState.Blocking)
                            {
                                _event.Value.WaitOne(2000);
                                if (!Cell.IO && ++cnt > 5 && _lockHolder.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                                    _lockHolder.Interrupt();
                                else
                                    cnt = 0;
                            }
                            if (_lockHolder != null)
                                goto retry; // used to enable AggressiveInlining
                            break;
                    }
                    break;
                case CellState.Clean:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                        case CellState.DirtyIfClean:
                            _lockHolder = null;
                            break;
                        case CellState.Calculating:
                        case CellState.Blocking:
                            _lockHolder = Thread.CurrentThread;
                            break;
                    }
                    break;

                case CellState.Dirty:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                            _lockHolder = null;
                            break;
                        case CellState.DirtyIfClean:
                            Interlocked.Exchange(ref _state, (int)CellState.Dirty);
                            break;

                        case CellState.Calculating:
                        case CellState.Blocking:
                            _lockHolder = Thread.CurrentThread;
                            break;
                    }
                    break;

                case CellState.Error:
                    switch (value)
                    {
                        case CellState.Clean:
                        case CellState.Error:
                        case CellState.Dirty:
                        case CellState.DirtyIfClean:
                            _lockHolder = null;
                            break;

                        case CellState.Calculating:
                        case CellState.Blocking:
                            _lockHolder = Thread.CurrentThread;
                            break;
                    }
                    break;
            }
            if (taken)
            {
                taken = false;
                _spinLock.Exit();
            }
            return was;
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
            bool isCurrent = true;
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);

                if (source != this)
                {
                    var c = (ICell<T>)source;
                    var f = _func;
                    _func = c.Function;
                    c.Function = f;
                    Parent = c.Parent;
                    SetState(CellState.Dirty, ref taken);
                }

                // handle update of current while this cell is being constructed
                if (Parent is Model m)
                {
                    ICell cur;
                    if (m.TryGetValue(this.Mnemonic, out cur))
                    {
                        if (cur != this && cur != null && cur.GetType() == this.GetType())
                        {
                            isCurrent = false;
                            cur.Merge(this, model);
                        }
                    }
                }
            }
            finally
            {
                if (taken)
                    _spinLock.Exit();
            }
            if (isCurrent)
            {
                RaiseChange(CellEvent.CyclicCheck, this, null, DateTime.Now, null);
                Task.Run(() => RaiseChange(CellEvent.Calculate, this, null, DateTime.Now, null));
            }
        }

        public virtual void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {
            if (_disposd && root != this && eventType != CellEvent.Delete) sender.OnChange(CellEvent.Delete, this, this, epoch, session);
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (!taken)
                {
                    Task.Run(() => this.OnChange(eventType, root, sender, epoch, session));
                }
                else
                {
                    switch (eventType)
                    {
                        case CellEvent.Calculate:
                            if (session != null && session.State == SessionState.Open)
                                _pending++;
                            else if (epoch > _epoch)
                            {
                                SetState(CellState.Dirty, ref taken);
                                _epoch = epoch;
                                OnChange(CellEvent.Invalidate, root, this, epoch, session);
                                Cell.Dispatch(() =>
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
                            }
                            break;
                        case CellEvent.Delete:
                            _link = true;
                            Change -= root.OnChange;
                            break;
                        case CellEvent.Invalidate:
                            SetState(CellState.Dirty, ref taken);
                            RaiseChange(eventType, root, sender, epoch, session);
                            break;

                        case CellEvent.Link:
                            _link = true;
                            _flip = true;
                            SetState(CellState.Dirty, ref taken);
                            RaiseChange(eventType, root, sender, epoch, session);
                            break;

                        case CellEvent.JoinSession:
                            _spinLock.Exit();
                            taken = false;
                            session.Join(this);
                            RaiseChange(eventType, root, sender, epoch, session);
                            break;

                        case CellEvent.Error:
                            SetState(CellState.Error, ref taken);
                            break;

                        case CellEvent.CyclicCheck:
                            _spinLock.Exit();
                            taken = false;
                            if (root == this)
                                throw new CyclicDependencyException();
                            else
                                RaiseChange(eventType, root, sender, epoch, session);
                            break;
                    }
                }
            }
            finally
            {
                if (taken)
                    _spinLock.Exit();
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

        public CellState State => (CellState)_state;
        public Exception Error => _lastException;

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
            bool taken = false;
            SetState(CellState.Error, ref taken);
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
