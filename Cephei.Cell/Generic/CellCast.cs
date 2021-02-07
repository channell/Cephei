using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Cell.Generic
{
    /// <summary>
    /// Simple cast of a cell from type S to T
    /// </summary>
    /// <typeparam name="T">required type</typeparam>
    /// <typeparam name="S">source type</typeparam>
    public class CellCast<T> : Generic.ICell<T> 
    {
        private ICell _real;
        public CellCast (ICell s)
        {
            _real = s;
        }

        public void Inject (ICell s)
        {
            _real = s;
        }

        #region ICell<T>
        public T Value { get => (T)_real.Box; set => throw new NotImplementedException(); }
        public FSharpFunc<Unit, T> Function 
        {
            get => FuncConvert.FromFunc<T>(() => (T)_real.Box);
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<ICellEvent> Dependants => _real.Dependants;

        public string Mnemonic { get => _real.Mnemonic; set => _real.Mnemonic = value; }

        public bool HasFunction => _real.HasFunction;

        public bool HasValue => _real.HasValue;

        public object Box { get => _real.Box; set => _real.Box = value; }

        public CellState State => _real.State;

        public Exception Error => _real.Error;

        public ICell Mutex { get => _real.Mutex; set => _real.Mutex = value; }
        public ICell Parent { get => _real.Parent; set => _real.Parent = value; }

        public event CellChange Change
        {
            add
            {
                _real.Change += value;
            }

            remove
            {
                _real.Change -= value;
            }
        }

        public void Dispose()
        {
            _real.Dispose();
        }

        public object GetFunction()
        {
            return _real.GetFunction();
        }

        public void Merge(ICell source, Model model)
        {
            _real.Merge(source, model);
        }

        public void Notify(ICell listener)
        {
            _real.Notify(listener);
        }

        public void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            _real.OnChange(eventType, root, sender, epoch, session);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(T value)
        {
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, T>>> observer)
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, ICell<T>, CellEvent, ICell, DateTime>> observer)
        {
            throw new NotImplementedException();
        }

        public void UnNotify(ICell listener)
        {
            _real.UnNotify(listener);
        }

        public bool ValueIs<Base>()
        {
            return _real.ValueIs<Base>();
        }
        #endregion
    }
}
