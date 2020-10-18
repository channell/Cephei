using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cephei.Cell.Generic
{
    /// <summary>
    /// CellInline is a variant of Cell that performs calculation inline like a 
    /// normal function but with Cell samntics
    /// </summary>
    public class CellTrivial<T> : ICell<T>, ITrivial
    {
        /// <summary>
        /// reference to the function to evaluate
        /// </summary>
        private FSharpFunc<Unit, T> _func;
        /// <summary>

        public string Mnemonic { get; set; }
        public ICell Parent { get; set; }

        /// <summary>
        /// Create the cell with the F# function.  If used from C#, the Func<> formula can
        /// be converted to an F# function for usage
        /// use FuncConvert.FromFunc for C# functions
        /// </summary>
        /// <param name="func"></param>
        public CellTrivial(FSharpFunc<Unit, T> func)
        {
            _func = func;
        }
        /// <summary>
        /// Create a cell with a mnemonic reference
        /// </summary>
        /// <param name="func"></param>
        /// <param name="mnemonic"></param>
        public CellTrivial(FSharpFunc<Unit, T> func, string mnemonic) : this(func)
        {
            Mnemonic = mnemonic;
        }
        public T Value
        {
            get
            {
                return _func.Invoke(null);
            }
            set
            {
            }
        }

        public event CellChange Change;

        public void Dispose()
        {
        }

        public virtual void OnChange(CellEvent eventType, ICellEvent root, DateTime epoch, ISession session)
        {
            if (Change != null)
                Change(eventType, root, epoch, session);
        }

        /// <see cref="ICell.HasFunction"/>
        public bool HasFunction => true;
        /// <see cref="ICell.HasValue"/>
        public bool HasValue => false;

        /// <see cref="ICell.Box"/>
        public object Box
        {
            get
            {
                return Value;
            }
            set
            {
            }
        }
        public object GetFunction()
        {
            return _func;
        }


        public IEnumerable<ICellEvent> Dependants
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
        public FSharpFunc<Unit, T> Function
        {
            get
            {
                return _func;
            }
        }

        public void Clone(ICell source)
        {
            foreach (var d in source.Dependants)
            {
                Change += d.OnChange;
            }
            if (source.GetType() == this.GetType())
            {
                var c = (ICell<T>)source;
                _func = c.Function;
            }
            if (Change != null)
                Change(CellEvent.Link, this, DateTime.Now, null);
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
        }

        public void OnNext(T value)
        {
        }

        public ICell ToCell()
        {
            return new Cell<T>(_func, Mnemonic);
        }
        #endregion
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
    }
}
