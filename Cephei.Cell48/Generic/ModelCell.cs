using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cephei.Cell.Generic
{
    /// <summary>
    /// Specialisation of Model for recipes models that add cell functions to an oject
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Model<T> : Model , ICell<T>
    {
        private ICell<T> _cell;
        
        public void Bind (ICell<T> cell)
        {
            _cell = cell;
            Bind();
        }

        public override IEnumerable<ICellEvent> Dependants
        {
            get
            {
                return _cell.Dependants;
            }
        }

        public override object Box
        {
            get
            {
                return _cell.Box;
            }
        }
        public override string Mnemonic 
        {
            get
            {
                return _cell.Mnemonic;
            }
            set 
            {
                _cell.Mnemonic = value;
            }
        }

        public T Value { get => _cell.Value; set => _cell.Value = value; }

        public void OnCompleted()
        {
            _cell.OnCompleted();
        }

        public void OnError(Exception error)
        {
            _cell.OnError(error);
        }

        public void OnNext(T value)
        {
            _cell.OnNext(value);
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _cell.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, T>>> observer)
        {
            return _cell.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, ICell<T>, CellEvent, ICell, DateTime>> observer)
        {
            return _cell.Subscribe(observer);
        }
        public FSharpFunc<Unit, T> Function
        {
            get
            {
                return _cell.Function;
            }
        }

        public override void Clone(ICell source)
        {
            _cell.Clone(source);
        }
        public override void Notify(ICell listener)
        {
            _cell.Notify(listener);
        }

        public override void UnNotify(ICell listener)
        {
            _cell.UnNotify(listener);
        }
    }
}
