/*
 * Copyright Cepheis Ltd 2020 
 * All rights reserves
 */
using Microsoft.FSharp.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cephei.Cell
{
    public class List<T> : IList<Generic.ICell<T>>, Generic.ICell<T>
    {
        private IList<Generic.ICell<T>> _list;
        public List()
        {
            _list = new System.Collections.Generic.List<Generic.ICell<T>>();
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List`1 class that
        //     is empty and has the default initial capacity.
        public List(IList<Generic.ICell<T>> list)
        {
            _list = list;
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List`1 class that
        //     contains elements copied from the specified collection and has sufficient capacity
        //     to accommodate the number of elements copied.
        //
        // Parameters:
        //   collection:
        //     The collection whose elements are copied to the new list.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     collection is null.
        public List(IEnumerable<Generic.ICell<T>> collection)
        {
            _list = new System.Collections.Generic.List<Generic.ICell<T>>(collection);
            foreach (var v in _list)
                v.Parent = this;
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List`1 class that
        //     is empty and has the specified initial capacity.
        //
        // Parameters:
        //   capacity:
        //     The number of elements that the new list can initially store.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     capacity is less than 0.
        public List(int capacity)
        {
            _list = new System.Collections.Generic.List<Generic.ICell<T>>(capacity);
        }

        public FSharpFunc<Unit, T> Function
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public void Merge(ICell source, Model model)
        {
        }


        #region Cell
        public IList<Generic.ICell<T>> Value
        {
            get
            {
                return _list;
            }
            set
            {
                _list = this;
            }
        }

        public ICell Parent { get; set; }

        public IEnumerable<ICellEvent> Dependants
        {
            get
            {
                if (Change != null)
                    foreach (CellChange c in Change.GetInvocationList())
                    {
                        var t = c.Target as ICell;
                        if (t != null)
                            yield return t;
                    }
            }
        }

        public string Mnemonic { get; set; }
        T Generic.ICell<T>.Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => _list.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public Generic.ICell<T> this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                if (_list.Count >= index)
                {
                    ICell current = _list[index];
                    if (current != value)
                    {
                        LinkedList<ICellEvent> dependants = new LinkedList<ICellEvent>(current.Dependants);
                        foreach (var c in dependants)
                            value.Change += c.OnChange;
                        foreach (var c in dependants)
                            value.OnChange(CellEvent.Link, this, this, DateTime.Now, null);
                    }
                }
                value.Parent = this;
                _list[index] = value;
            }
        }

        public event CellChange Change;

        public void Dispose()
        {
            RaiseChange(CellEvent.Delete, this, this, DateTime.Now, null);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (Change != null)
                Change(eventType, root, this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root,  this, epoch, session);
        }

        public void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {
            RaiseChange(eventType, this, this, DateTime.Now, null);

        }

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


        /// <see cref="ICell.HasFunction"/>
        public bool HasFunction => false;
        /// <see cref="ICell.HasValue"/>
        public bool HasValue => true;

        /// <see cref="ICell.Box"/>
        public object Box
        {
            get
            {
                return this;
            }
            set
            {
                var e = value as IEnumerable<Generic.ICell<T>>;
                if (e != null)
                    foreach (var c in e)
                        this.Add (c);
            }
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
            this.Add(new Generic.Cell<T>(value));
        }
        #endregion

        #region List
        public int IndexOf(Generic.ICell<T> item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, Generic.ICell<T> item)
        {
            item.Parent = this;
            _list.Insert(index, item);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);

        }

        public void RemoveAt(int index)
        {
            if (_list.Count < index)
            {
                var i = _list[index];
                if (i.Parent == this) i.Parent = null;
                RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);

            }
        }

        public void Add(Generic.ICell<T> item)
        {
            item.Parent = this;
            _list.Add(item);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);

        }

        public void Clear()
        {
            _list.Clear();
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);

        }

        public bool Contains(Generic.ICell<T> item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(Generic.ICell<T>[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Generic.ICell<T> item)
        {
            var r = _list.Remove(item);
            if (r)
                RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);

            return r;
        }

        /// <summary>
        /// before eunumerating, add this list the dependants insetad of the content of the list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Generic.ICell<T>> GetEnumerator()
        {
            bool pop = false;
            var s = Cell.Current.Value;
            var c = s.Peek();
            if (c != null)
            {
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

                s.Push(null);
                pop = true;
            }
            foreach (var v in _list)
                yield return v;
            if (pop)
                s.Pop();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
            throw new NotImplementedException();
        }

        #endregion
        public void Notify(ICell listener)
        {
            Change += listener.OnChange;
        }

        public void UnNotify(ICell listener)
        {
            Change -= listener.OnChange;
        }
        public object GetFunction()
        {
            return null;
        }
    }
}
