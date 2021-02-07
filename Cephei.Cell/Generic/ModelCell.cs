using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private ICell<T> _subject = null;
        private SpinLock _spinLock = new SpinLock(true);
        /// summary: prevent recursive messages from Cell
        private bool _notInSubject = true;

        public Model () : base ()
        {
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
                        Thread.Sleep (100);
                }
                if (cell is ITrivial t)
                {
                    cell = (ICell<T>)t.ToCell();
                }

                if (_subject != null)
                {
                    foreach (var e in _subject.Dependants)
                    {
                        if (e is ICell c)
                            if (!(c.Parent != null && c.Parent is ICellModel m && m == this) && c != cell)
                                cell.Notify(c);
                    }
                    var cur = _subject;
                    _subject = cell;
                    _subject.Mnemonic = Mnemonic;
                    _subject.Parent = this;
                    _spinLock.Exit();
                    taken = false;
                    foreach (var c in this)
                    {
                        if (!(c.Value is ITrivial))
                        {
                            c.Value.OnChange(CellEvent.Link, cur, this, DateTime.Now, null);
                        }
                    }
                }
                else
                {
                    // no interest in model references, since the only references prior to bind are internal
                    if (cell != null)       
                    {
                        _subject = cell;
                        _subject.Parent = this;
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
                if (_subject != null)
                    return ModelDependants
                        .ToArray()
                        .Union(_subject.Dependants.ToArray());
                else
                    return ModelDependants;
            }
        }

        public override object Box
        {
            get
            {
                return _subject.Box;
            }
        }

        public override bool ValueIs<Base>()
        {
            return _subject.ValueIs<Base>();
        }

        public override string Mnemonic
        {
            get
            {
                return _Mnemonic;
            }
            set
            {
                if (_subject != null) _subject.Mnemonic = value;
                _Mnemonic = value;
            }
        }

        public T Value 
        {
            get
            {
                return _subject.Value;
            }
            set
            {
                _subject.Value = value;
            }
        }

        public void OnCompleted()
        {
            _subject.OnCompleted();    
        }

        public void OnError(Exception error)
        {
            _subject.OnError(error);
        }

        public void OnNext(T value)
        {
            _subject.OnNext(value);
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _subject.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, T>>> observer)
        {
            return _subject.Subscribe(observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, ICell<T>, CellEvent, ICell, DateTime>> observer)
        {
            return _subject.Subscribe(observer);
        }
        public FSharpFunc<Unit, T> Function
        {
            get
            {
                return _subject.Function;
            }
            set
            {
                _subject.Function = value;
            }
        }
        public override object GetFunction()
        {
            return _subject.GetFunction();
        }

        public ICell Subject
        {
            get
            {
                return _subject;
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
                        Thread.Sleep (100);
                }
                if (source != this)
                {
                    if (source is ICellModel sm)
                    {
                        _subject.Parent = this;
                        _subject.Merge(sm.Subject, model);
                    }
                    else
                    {
                        _subject.Parent = this;
                        _subject.Merge(source, model);
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
                        Thread.Sleep(100);
                }
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
                        Thread.Sleep(100);
                }
                if (_subject != null)
                    _subject.UnNotify(listener);
                ModelUnNotify(listener);
            }
            finally
            {
                if (taken) _spinLock.Exit();
            }
        }
        public void MigratedParentOnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            OnChange((eventType | CellEvent.Logging), root, sender, epoch, session);
        }

        public override void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {
            if (sender == Parent)
                return;

            if (_notInSubject)
            {
                if ((eventType & CellEvent.Logging) != CellEvent.Logging)
                    base.OnChange(eventType, root, this, epoch, session);
                else
                {
                    try
                    {
                        _notInSubject = false;
                        if (sender == _subject)
                            base.OnChange(eventType & CellEvent.NotLogging, root, this, epoch, session);
                        else
                            _subject.OnChange(eventType & CellEvent.NotLogging, root, this, epoch, session);
                    }
                    finally
                    {
                        _notInSubject = true;
                    }
                }

                if (Parent != null)
                    Parent.OnChange(eventType | CellEvent.Logging, root, this, epoch, session);
            }
            /*            if (sender == Parent)
                            return;

                        if ((eventType & CellEvent.Logging) != CellEvent.Logging)
                            base.OnChange(eventType, root, this, epoch, session);

                        if (Parent != null)
                            Parent.OnChange(eventType | CellEvent.Logging, root, this, epoch, session);

                        if (root != this && sender.Parent != this || sender == _subject)
                            _subject.OnChange((eventType | CellEvent.MoldelSubject) ^ CellEvent.Logging, root, this, epoch, session);
            */
        }
        public override CellState State
        {
            get
            {
                return _subject.State;
            }
        }

        public override Exception Error
        {
            get
            {
                return _subject.Error;
            }
        }
    }
}
