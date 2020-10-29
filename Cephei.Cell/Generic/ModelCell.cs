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
    public class Model<T> : Model , ICell<T>, ICellModel
    {
        private ICell<T> _cell;

        public void Bind (ICell<T> cell)
        {
            _cell = cell;
            _cell.Parent = this;
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
            set
            {
                _cell.Function = value;
            }
        }

        public ICell Cell => _cell;

        public override void Merge(ICell source, Model model)
        {
            if (source != this)
            {
                Parent = model.Parent;
                if (source is ICellModel sm)
                {
                    _cell.Merge(sm.Cell, model);
                    _cell.Parent = this;
                }
                else
                {
                    _cell.Merge(source, model);
                    _cell.Parent = this;
                }
            }
                // handle update of current while this cell is being constructed
            if (Parent is Model mod)
            {
                var cur = mod[this.Mnemonic];
                if (cur != this && cur.GetType() == this.GetType())
                    cur.Merge(this, model);
            }
        }
        public override void Notify(ICell listener)
        {
            // _cell is null if one of the members being profiled tries to link to it
            if (_cell != null) _cell.Notify(listener);
        }

        public override void UnNotify(ICell listener)
        {
            _cell.UnNotify(listener);
        }
        public override void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {            
            if (sender == Parent) 
                return; 
            if (root != this)
                _cell.OnChange(eventType, root,  this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root, this, epoch, session);
        }
    }
}
