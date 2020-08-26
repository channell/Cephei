using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cephei.Cell.Generic
{
    /// <summary>
    /// CellSpot is a further specialization of Cell from CellFast for cells where the
    /// Spot value is only ever used and not referenced within a session.
    /// Spot cells nevery enlist in  session and never use session values for
    /// calculations
    /// </summary>
    public class CellSpot<T> : ICell<T>
    {
        private FSharpFunc<Unit, T> _func;
        private SpinLock _spinLock = new SpinLock(true);
        private volatile ManualResetEvent _event = new ManualResetEvent(false);

        private volatile int _state = (int)CellState.Dirty;
        //private volatile CellState _state = CellState.Dirty;
        private T _value;
        private Exception _lastException = null;
        private DateTime _epoch;

        // number of pending calculations
        volatile int _pending;

        public string Mnemonic { get; set; }
        public ICell Parent { get; set; }

        public CellSpot(FSharpFunc<Unit, T> func, ICell[] dependancies)
        {
            _func = func;
            if (Cell.Parellel && !Cell.Lazy)
                Task.Run(() => Calculate(DateTime.Now, 0));
            else if (!Cell.Lazy)
                Calculate(DateTime.Now, 0);
        }
        public CellSpot(FSharpFunc<Unit, T> func, ICell[] dependancies, string mnemonic) : this(func, dependancies)
        {
            Mnemonic = mnemonic;
        }
        public CellSpot(T value)
        {
            _value = value;
            _state = (int)CellState.Clean;
        }
        public CellSpot(T value, string mnemonic) : this(value)
        {
            Mnemonic = mnemonic;
        }
#if !DEBUG
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private T Calculate(DateTime epoch, int recurse, ISession session = null, bool retry = false)
        {
            if (recurse > 60) throw new LockRecursionException();
            bool taken = false;
            try
            {
                _spinLock.Enter(ref taken);
                if (taken)
                {
                    if (_state == (int)CellState.Clean)
                        return _value;      // don't recalculate for read
                    SetState(CellState.Calculating);
                    _spinLock.Exit(true);
                    taken = false;

                    var t = (_func != null ? _func.Invoke(null) : _value);

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
                    if (epoch > _epoch)
                    {
                        _epoch = epoch;
                        _value = t;
                    }
                    SetState(CellState.Clean);
                    return t;
                }
                else
                {
                    Thread.Sleep(recurse * 100);
                    return Calculate(epoch, recurse + 1, session);     // edge case retry lock
                }
            }
            catch (Exception e)
            {
                if (retry)
                {
                    if (taken) _spinLock.Exit(true);
                    Thread.Sleep(0);
                    return Calculate(epoch, recurse + 1, session, false);
                }
                else
                {
                    _lastException = e;
                    SetState(CellState.Error);
                    RaiseChange(CellEvent.Error, this, epoch, null);
                    throw;
                }
            }
            finally
            {
                if (taken) _spinLock.Exit(true);
            }
        }
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
                        var ses = Session.Current;
                        return (v);

                    case (int)CellState.Calculating:
                    case (int)CellState.Blocking:
                        Interlocked.Exchange(ref _state, (int)CellState.Blocking);
                        _spinLock.Exit(true);
                        taken = false;
                        for (int c = 0; c < 60000; c += 100)
                        {
                            //                            if (_event == null) _event = new ManualResetEvent(false);
                            if (_event.WaitOne(c) || _state != (int)CellState.Blocking)
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
                        _value = value;
                        _epoch = DateTime.Now;
                        _spinLock.Exit(true);
                        taken = false;
                        RaiseChange(CellEvent.Calculate, this, _epoch, null);
                    }
                }
                finally
                {
                    if (taken) _spinLock.Exit(true);
                }
            }
        }

        public IEnumerable<ICell> Dependants
        {
            get
            {
                if (Change != null)
                {
                    var l = Change.GetInvocationList();
                    var r = new ICell[l.Length];
                    for (int c = 0; c < l.Length; ++c)
                    {
                        r[c] = l[c].Target as ICell;
                    }
                    return r;
                }
                else
                    return new ICell[0];
            }
        }

        public event CellChange Change;

        public void Dispose()
        {
            RaiseChange(CellEvent.Delete, this, DateTime.Now, null);
        }

        private void PoolCalculate(DateTime epoch, ISession session)
        {
            var lastsession = Session.Current;
            Session.Current = session;
            Calculate(epoch, 0, session);
            RaiseChange(CellEvent.Calculate, this, epoch, session);
            Session.Current = lastsession;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICell root, DateTime epoch, ISession session)
        {
            if (Change != null)
                Change(eventType, root, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root, epoch, session);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Cephei.Cell.CellState SetState(CellState value)
        {
            var s = (CellState)Interlocked.Exchange(ref _state, (int)value);
            if (s == CellState.Blocking)
            {
                _event.Set();
                _event.Reset();
            }
            return s;
        }

        public virtual void OnChange(CellEvent eventType, ICell root, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Calculate:
                    if (session != null && session.State == SessionState.Open)
                        _pending++;
                    else
                    {
                        RaiseChange(CellEvent.Invalidate, root, epoch, session);
                        if (Cell.Parellel)
                            Task.Run(() => PoolCalculate(DateTime.Now, session));
                        else
                            PoolCalculate(epoch, session);
                    }
                    break;
                case CellEvent.Invalidate:
                    var lastState = (CellState)Interlocked.Exchange(ref _state, (int)CellState.Dirty);
                    if (lastState == CellState.Calculating || lastState == CellState.Blocking)
                        lastState = (CellState)Interlocked.Exchange(ref _state, (int)lastState);
                    else
                        RaiseChange(eventType, root, epoch, session);
                    break;

                case CellEvent.JoinSession:
                    session.Join(this);
                    RaiseChange(eventType, root, epoch, session);
                    break;

                case CellEvent.Error:
                    bool taken = false;
                    _spinLock.Enter(ref taken);
                    if (taken)
                    {
                        SetState(CellState.Error);
                        _spinLock.Exit();
                    }
                    else
                    {
                        Thread.Sleep(100);
                        OnChange(eventType, root, epoch, session);
                    }
                    break;
                default:
                    break;
            }
        }
        /// <see cref="ICell.HasFunction"/>
        public bool HasFunction => _func != null;
        /// <see cref="ICell.HasValue"/>
        public bool HasValue => true;

        /// <see cref="ICell.Box"/>
        public object Box
        {
            get
            {
                return _value;
            }
            set
            {
                _value = (T)Value;
            }
        }


        #region observable
        public IDisposable Subscribe(IObserver<T> observer)
        {
            Task.Run(() => Value);
            return new CellObserver<T>(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, T>>> observer)
        {
            Task.Run(() => Value);
            return new SessionObserver<T>(this, observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>> observer)
        {
            Task.Run(() => Value);
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
        #endregion
    }
}
