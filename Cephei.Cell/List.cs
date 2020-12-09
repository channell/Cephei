/*
 * Copyright Cepheis Ltd 2020 
 * All rights reserves
 */
using Microsoft.FSharp.Core;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cephei.Cell.Generic;

namespace Cephei.Cell
{
    /// <summary>
    /// Lust that combines the view of the a list of Cells with a list of Cells
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class List<T> : IList<ICell<T>>, ICell<System.Collections.Generic.List<T>>, IList<T>, ICell<System.Collections.Generic.List<ICell<T>>>
    {
        private System.Collections.Generic.List<Generic.ICell<T>> _list;
        private System.Collections.Generic.List<T> _cache;
        #region constructors
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
            _list = (from r in list
                     select withNotify(r)
                    ).ToList();
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.List`1 class that
        //     is empty and has the default initial capacity.
        public List(System.Collections.Generic.List<T> list)
        {
            _list = (from r in list
                     select withNotify(Cell.CreateValue<T>(r))
                     ).ToList();
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
            _list = (from r in collection
                     select withNotify(r)
                    ).ToList();
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

        public List(Generic.ICell<T>[] a)
        {
            _list = (from r in a
                     select withNotify(r)
                    ).ToList();
        }

        public List(T[] a)
        {
            _list = (from r in a
                     select withNotify(Cell.CreateValue(r))
                    ).ToList();
        }

        #endregion

        #region helper
        private Generic.ICell<T> withNotify(Generic.ICell<T> c)
        {
            c.Notify(this);
            return c;
        }

        public static implicit operator System.Collections.Generic.List<T>(List<T> v) { return v.Value; }
        public static implicit operator System.Collections.Generic.List<ICell<T>>(List<T> v) { return v._list; }

        public T[] ToArray ()
        {
            return Value.ToArray();
        }

        #endregion

        #region IList<T>
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
                            value.OnChange(CellEvent.Calculate, this, this, DateTime.Now, null);
                        _cache = null;
                    }
                }
                else
                {
                    value.Notify(this);
                    _list[index] = value;
                }
            }
        }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(ICell<T> item)
        {
            _list.Add(item);
            item.Notify(this);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(ICell<T> item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(ICell<T>[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ICell<T>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(ICell<T> item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, ICell<T> item)
        {
            _list.Insert(index, withNotify(item));
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        public bool Remove(ICell<T> item)
        {
            if (_list.Remove(item))
            {
                RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
                return true;
            }
            else
                return false;
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        #endregion

        #region Generic.ICell<List<T>>
        public System.Collections.Generic.List<T> Value 
        { 
            get
            {
                if (_cache == null)
                {
                    _cache = _list.Select(p => p.Value).ToList();

                }
                return _cache;
            }
            set
            {
                var changed = false;
                var s = value.ToHashSet();
                var ll = new System.Collections.Generic.LinkedList<Generic.ICell<T>>();
                foreach (var v in _list)
                {
                    if (s.Contains(v.Value))
                        s.Remove(v.Value);
                    else
                    {
                        ll.AddLast(v);
                        changed = true;
                    }
                }
                foreach (var v in ll)
                    _list.Remove(v);
                foreach (var v in s)
                    _list.Add(withNotify(Cell.CreateValue(v)));

                _cache = value;
                if (changed)
                    RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
            }
        }
        public FSharpFunc<Unit, System.Collections.Generic.List<T>> Function
        {
            get
            {
                return null;
            }
            set
            {

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

        public bool HasFunction => false;

        public bool HasValue => true;

        public object Box { get => Value; set => Value = (value as System.Collections.Generic.List<T>); }

        public event CellChange Change;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (Change != null)
                Change(eventType, root, this, epoch, session);
            if (Parent != null)
                Parent.OnChange(eventType, root, this, epoch, session);
        }

        public void Dispose()
        {
            RaiseChange(CellEvent.Delete, this, this, DateTime.Now, null);

        }

        public object GetFunction()
        {
            return null;
        }
        public bool ValueIs<Base>()
        {
            return typeof(T).IsSubclassOf(typeof(Base));
        }

        public void Merge(ICell source, Model model)
        {
            lock (_list)
            {
                var l = source as IList<Generic.ICell<T>>;
                var s = l.ToHashSet();
                var ll = new System.Collections.Generic.LinkedList<Generic.ICell<T>>();

                foreach (var v in _list)
                {
                    if (s.Contains(v))
                        s.Remove(v);
                    else
                        ll.AddLast(v);
                }
                foreach (var v in ll)
                    _list.Remove(v);
                foreach (var v in s)
                    _list.Add(v);
                if (ll.Count == 0 || s.Count > 0)
                    RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
            }
        }

        public void Notify(ICell listener)
        {
            Change += listener.OnChange;
        }

        public void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            RaiseChange(eventType, this, this, DateTime.Now, null);

        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(System.Collections.Generic.List<T> value)
        {
            Value = value;
        }

        public IDisposable Subscribe(IObserver<System.Collections.Generic.List<T>> observer)
        {
            return new CellObserver<System.Collections.Generic.List<T>>(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, System.Collections.Generic.List<T>>>> observer)
        {
            return new SessionObserver<System.Collections.Generic.List<T>>(this, observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, ICell<System.Collections.Generic.List<T>>, CellEvent, ICell, DateTime>> observer)
        {
            return new TraceObserver<System.Collections.Generic.List<T>>(this, observer);
        }

        public void UnNotify(ICell listener)
        {
            CellChange cellChange = null;
            foreach (var v in Change.GetInvocationList())
                if (v.Target == listener)
                {
                    cellChange = v.Target as CellChange;
                    break;
                }
            if (cellChange != null)
                Change -= cellChange;
        }
        #endregion

        #region IList<T>

        T IList<T>.this[int index]
        {
            get
            {
                return Value[index];
            }
            set
            {
                Value[index] = value;
            }
        }

        int ICollection<T>.Count => _list.Count;

        bool ICollection<T>.IsReadOnly => false;

        void ICollection<T>.Add(T item)
        {
            _list.Add(withNotify(Cell.CreateValue(item)));
            if (_cache != null) _cache.Add(item);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        void ICollection<T>.Clear()
        {
            _list.Clear();
            _cache = null;
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        bool ICollection<T>.Contains(T item)
        {
            return Value.Contains(item);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            Value.CopyTo(array, arrayIndex);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        int IList<T>.IndexOf(T item)
        {
            return Value.IndexOf(item);
        }

        void IList<T>.Insert(int index, T item)
        {
            _list.Insert(index, withNotify(Cell.CreateValue(item)));
            Value.Insert(index, item);
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }
        bool ICollection<T>.Remove(T item)
        {
            _list.RemoveAt(Value.IndexOf(item));
            return Value.Remove(item);
        }

        void IList<T>.RemoveAt(int index)
        {
            _list.RemoveAt(index);
            Value.RemoveAt(index);
        }
        #endregion

        #region ICell<System.Collections.Generic.List<ICell<T>>>
        System.Collections.Generic.List<ICell<T>> ICell<System.Collections.Generic.List<ICell<T>>>.Value 
        {
            get => _list;
            set
            {
                _list = value;
                _cache = null;
                RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
            }
        }
        FSharpFunc<Unit, System.Collections.Generic.List<ICell<T>>> ICell<System.Collections.Generic.List<ICell<T>>>.Function { get => null; set { } }

        void IObserver<System.Collections.Generic.List<ICell<T>>>.OnCompleted()
        {
        }

        void IObserver<System.Collections.Generic.List<ICell<T>>>.OnError(Exception error)
        {
        }

        void IObserver<System.Collections.Generic.List<ICell<T>>>.OnNext(System.Collections.Generic.List<ICell<T>> value)
        {
            _list = value;
            _cache = null;
            RaiseChange(CellEvent.Calculate, this, this, DateTime.Now, null);
        }

        IDisposable IObservable<System.Collections.Generic.List<ICell<T>>>.Subscribe(IObserver<System.Collections.Generic.List<ICell<T>>> observer)
        {
            return new CellObserver<System.Collections.Generic.List<ICell<T>>>(this, observer);
        }

        IDisposable IObservable<KeyValuePair<ISession, KeyValuePair<string, System.Collections.Generic.List<ICell<T>>>>>.Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, System.Collections.Generic.List<ICell<T>>>>> observer)
        {
            return new SessionObserver<System.Collections.Generic.List<ICell<T>>>(this, observer);
        }

        IDisposable IObservable<Tuple<ISession, ICell<System.Collections.Generic.List<ICell<T>>>, CellEvent, ICell, DateTime>>.Subscribe(IObserver<Tuple<ISession, ICell<System.Collections.Generic.List<ICell<T>>>, CellEvent, ICell, DateTime>> observer)
        {
            return new TraceObserver<System.Collections.Generic.List<ICell<T>>>(this, observer);
        }
        #endregion
        public CellState State => CellState.Clean;
        public Exception Error => null;
    }
}
