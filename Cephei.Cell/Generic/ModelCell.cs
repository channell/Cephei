using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Cephei.Cell.Generic
{
    /// <summary>
    /// Specialisation of Model for recipes models that add cell functions to an oject
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Model<T> : Model , ICell<T>, ICellModel
    {
        private ICell<T> _cell = null;
        private SpinLock _spinLock = new SpinLock(true);

        public Model () : base ()
        {
            _cell = new CellEmpty<T>();     // for forward references to this model that need to be migrated to during bind
        }

        public void Bind (ICell<T> cell)
        {
            bool taken = false;
            try
            {
                while (!taken)
                {
                    _spinLock.Enter(ref taken);
                    if (taken)
                        break;
                    else
                        Thread.Yield();
                }
                if (cell is ITrivial t)
                {
                    cell = (ICell<T>)t.ToCell();
                }
                if (!(_cell is ICellEmpty))
                {
                    foreach (var c in _cell.Dependants)
                    {
                        if (c is ICell e)
                            if (!(c.Parent != null && c.Parent is ICellModel m && m == this))
                                cell.Notify(e);
                            else
                                ModelNotify(e);
                    }
                    if (_cell is ICellEmpty)
                    {
                        _cell = cell;
                        _cell.Mnemonic = Mnemonic;
                        _cell.Parent = this;
                    }
                    else
                    {
                        _cell = cell;
                        _cell.Mnemonic = Mnemonic;
                        _cell.Parent = this;
                        _spinLock.Exit();
                        taken = false;
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
                    if (cell != null)
                    {
                        _cell = cell;
                        _cell.Parent = this;
                    }
                    Bind();
                }
            }
            finally
            {
                if (taken) _spinLock.Exit();
            }
        }

        public override IEnumerable<ICellEvent> Dependants
        {
            get
            {
                if (_cell is ICellEmpty)
                    return ModelDependants;
                else
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

        public override bool ValueIs<Base>()
        {
            return _cell.ValueIs<Base>();
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
                _Mnemonic = value;
            }
        }

        public T Value 
        {
            get
            {
                return _cell.Value;
            }
            set
            {
                _cell.Value = value;
            }
        }

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
        public override object GetFunction()
        {
            return _cell.GetFunction();
        }

        public ICell Cell
        {
            get
            {
                return _cell;
            }
        }

        public override void Merge(ICell source, Model model)
        {
            bool taken = false;
            try
            {
                while (!taken)
                {
                    _spinLock.Enter(ref taken);
                    if (taken)
                        break;
                    else
                        Thread.Yield();
                }
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
            finally
            {
                if (taken) _spinLock.Exit();
            }
        }
        public override void Notify(ICell listener)
        {
            bool taken = false;
            try
            {
                while (!taken)
                {
                    _spinLock.Enter(ref taken);
                    if (taken)
                        break;
                    else
                        Thread.Yield();
                }

                if (!(_cell is ICellEmpty) && !(listener.Parent != null && listener.Parent is ICellModel m && m == this))
                    _cell.Notify(listener);
                else
                    ModelNotify(listener);
            } 
            finally
            {
                if (taken) _spinLock.Exit();
            }
        }

        public override void UnNotify(ICell listener)
        {
            bool taken = false;
            try
            {
                while (!taken)
                {
                    _spinLock.Enter(ref taken);
                    if (taken)
                        break;
                    else
                        Thread.Yield();
                }
                if (_cell != null && _cell != this && !(listener.Parent != null && listener.Parent is ICellModel m && m == this))
                    _cell.UnNotify(listener);
                else
                    ModelUnNotify(listener);
            }
            finally
            {
                if (taken) _spinLock.Exit();
            }
        }
        public override void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {
            if (sender == Parent)
                return;
            if (root != this && sender.Parent != this)
                _cell.OnChange(eventType, root, this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root, this, epoch, session);
        }
        public override CellState State
        {
            get
            {
                return _cell.State;
            }
        }

        public override Exception Error
        {
            get
            {
                return _cell.Error;
            }
        }
    }
}
