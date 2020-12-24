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
        private ICell<T> _cell = null;

        public Model () : base ()
        {
            _cell = new CellEmpty<T>();     // for forward references to this model that need to be migrated to during bind
        }

        public void Bind (ICell<T> cell)
        {
            if (_cell != null && cell != this)
            {
                foreach (var c in _cell.Dependants)
                {
                    if (c is ICell)
                        cell.Notify((ICell)c);
                }
                if (_cell is ICellEmpty)
                {
                    _cell = cell;
                    _cell.Parent = this;
                }
                else
                {
                    _cell = cell;
                    _cell.Parent = this;
                    foreach (var c in this)
                    {
                        if (!(c.Value is ITrivial))
                        {
                            c.Value.OnChange(CellEvent.Link, this, this, DateTime.Now, null);
                        }
                    }
                }
            }
            else
            {
                if (cell != null && cell != this)
                {
                    _cell = cell;
                    _cell.Parent = this;
                }
                Bind();
            }
        }

        public override IEnumerable<ICellEvent> Dependants
        {
            get
            {
                if (_cell == null || _cell == this)
                    return ModelDependants;
                else
                    return _cell.Dependants;
            }
        }

        public override object Box
        {
            get
            {
                if (_cell == null || _cell == this)
                    return this;
                else
                    return _cell.Box;
            }
        }

        public override bool ValueIs<Base>()
        {
            if (_cell == null || _cell == this)
                return (typeof(Base) is T);
            else
                return _cell.ValueIs<Base>();
        }

        public override string Mnemonic 
        {
            get
            {
                if (_cell == null || _cell == this)
                    return _Mnemonic;
                else
                    return _cell.Mnemonic;
            }
            set 
            {
                if (_cell == null || _cell == this)
                    _Mnemonic = value;
                else
                    _cell.Mnemonic = value;
            }
        }

        public T Value 
        {
            get
            {
                if (_cell == null || _cell == this)
                    return default(T);
                else
                    return _cell.Value;
            }
            set
            {
                if (_cell == null || _cell == this)
                    throw new NotImplementedException();
                else
                    _cell.Value = value;
            }
        }

        public void OnCompleted()
        {
            if (_cell != null && _cell != this)
                _cell.OnCompleted();    
        }

        public void OnError(Exception error)
        {
            if (_cell != null && _cell != this)
                _cell.OnError(error);
        }

        public void OnNext(T value)
        {
            if (_cell != null && _cell != this)
               _cell.OnNext(value);
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (_cell == null || _cell == this)
                return null;
            else
                return _cell.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, T>>> observer)
        {
            if (_cell == null || _cell == this)
                return null;
            else
                return _cell.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, ICell<T>, CellEvent, ICell, DateTime>> observer)
        {
            if (_cell == null || _cell == this)
                return null;
            else
                return _cell.Subscribe(observer);
        }
        public FSharpFunc<Unit, T> Function
        {
            get
            {
                if (_cell == null || _cell == this)
                    return null;
                else
                    return _cell.Function;
            }
            set
            {
                if (_cell != null && _cell != this)
                    _cell.Function = value;
            }
        }
        public override object GetFunction()
        {
            if (_cell == null || _cell == this)
                return null;
            else
                return _cell.GetFunction();
        }

        public ICell Cell
        {
            get
            {
                if (_cell == null)
                    return this;
                else
                    return _cell;
            }
        }

        public override void Merge(ICell source, Model model)
        {
            if (_cell != null && _cell != this)
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
                    if (cur != this && cur != null && cur.GetType() == this.GetType())
                        cur.Merge(this, model);
                }
            }
        }
        public override void Notify(ICell listener)
        {
            // _cell is null if one of the members being profiled tries to link to it
            if (_cell != null && _cell != this)
                _cell.Notify(listener);
            else
                ModelNotify(listener);
        }

        public override void UnNotify(ICell listener)
        {
            if (_cell != null && _cell != this)
                _cell.UnNotify(listener);
            else
                ModelUnNotify(listener);
        }
        public override void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {            
            if (sender == Parent) 
                return; 
            if (root != this && sender.Parent != this && _cell != null)
                _cell.OnChange(eventType, root,  this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root, this, epoch, session);
        }
        public override CellState State
        {
            get
            {
                if (_cell == null || _cell == this)
                    return CellState.Clean;
                else
                    return _cell.State;
            }
        }

        public override Exception Error
        {
            get
            {
                if (_cell == null || _cell == this)
                    return null;
                else
                    return _cell.Error;
            }
        }
    }
}
