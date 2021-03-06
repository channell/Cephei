﻿/*
 * Copyright(C) 2020 Cepheis Ltd(steve.channell@cepheis.com)
 * All rights reserved
 * 
 * This file is part of Cephei Project https://github.com/channell/Cephei
 * 
 * Cephei is open source software, you can redistribute it and/or modify it
 * under the terms of the Cephei license.  You should have received a
 * copy of the license along with this program; if not, license is
 * available at < https://github.com/channell/Cephei/LICENSE>.
 * 
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE.  See the license for more details.
 */

using Cephei.Cell.Generic;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Linq;

namespace Cephei.Cell
{
    public class Model : ConcurrentDictionary<string, ICell>, 
                         ICell, 
                         IObservable<ICell>,
                         IObservable<KeyValuePair<ISession, KeyValuePair<string, ICell>>>, 
                         IObservable<Tuple<ISession, Model, CellEvent, ICell, DateTime>>,
                         IObservable<KeyValuePair<string, double>>,
                         IObservable<KeyValuePair<string, int>>,
                         IObservable<KeyValuePair<string, Decimal>>
    {
        #region ICell
        private ICell _parent;
        public ICell Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent == null || _parent != value)
                {
                    if (_parent is ICellModel m && this == m.Subject)
                        Change += m.MigratedParentOnChange;
                    _parent = value;
                }
            }
        }

        public virtual IEnumerable<ICellEvent> Dependants
        {
            get
            {
                return ModelDependants;
            }
        }
        public IEnumerable<ICellEvent> ModelDependants
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

        protected string _Mnemonic;
        public virtual string Mnemonic 
        { 
            get
            {
                return _Mnemonic;
            }
            set
            {
                _Mnemonic = value;
            }
        }

        public event CellChange Change;
        public event CellChange Listen;

        public void Dispose()
        {
            Change(CellEvent.Delete, this, this, DateTime.Now, null);
            Change = delegate { };
            Listen = delegate { };
        }

        public virtual void OnChange(CellEvent eventType, ICellEvent root,  ICellEvent sender,  DateTime epoch, ISession session)
        {
            RaiseChange(eventType, root, null, epoch, session);
        }
        private ICell _mutex;
        public virtual ICell Mutex 
        { 
            get
            {
                return _mutex;
            }
            set
            {
                _mutex = value;
            }
        }

        #endregion

        #region factory
        public Cell<T> Create<T>(FSharpFunc<Unit, T> func, string mnemonic)
        {
            var c = new Cell<T>(func);
            c.Parent = this;
            if (TryAdd(mnemonic, c))
                return c;
            else
            {
                ICell cur;
                if (TryGetValue(mnemonic, out cur))
                {
                    var t = cur as Cell<T>;
                    if (t != null)
                        return t;
                    else
                    {
                        TryUpdate(mnemonic, c, t);
                        return c;
                    }
                }
                else
                    return c;
            }
        }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void RaiseChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            if (sender == this) return;
            if ((eventType & CellEvent.Logging) == CellEvent.Logging)
            {
                if (Listen != null)
                    Listen(eventType, root, this, epoch, session);
                if (Parent != null && sender != this && eventType != CellEvent.CyclicCheck)
                    Parent.OnChange(eventType | CellEvent.Logging, root, this, epoch, session);
            }
            else if (Parent != null && sender != this && eventType != CellEvent.CyclicCheck)
                Change(eventType, root, this, epoch, session);
        }

        public Model(string mnemonic) : base()
        {
            Mnemonic = mnemonic;
        }

        #region Dictionary

        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.Dictionary`2 class
        //     that is empty, has the default initial capacity, and uses the default equality
        //     comparer for the key type.
        public Model() : base() 
        {
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.Dictionary`2 class
        //     that contains elements copied from the specified System.Collections.Generic.IDictionary`2
        //     and uses the default equality comparer for the key type.
        //
        // Parameters:
        //   dictionary:
        //     The System.Collections.Generic.IDictionary`2 whose elements are copied to the
        //     new System.Collections.Generic.Dictionary`2.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     dictionary is null.
        //
        //   T:System.ArgumentException:
        //     dictionary contains one or more duplicate keys.
        public Model(IDictionary<string, ICell> dictionary) : base(dictionary)
        {
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.Dictionary`2 class
        //     that is empty, has the default initial capacity, and uses the specified System.Collections.Generic.IEqualityComparer`1.
        //
        // Parameters:
        //   comparer:
        //     The System.Collections.Generic.IEqualityComparer`1 implementation to use when
        //     comparing keys, or null to use the default System.Collections.Generic.EqualityComparer`1
        //     for the type of the key.
        public Model(IEqualityComparer<string> comparer) : base(comparer)
        {
        }

        //
        // Summary:
        //     Initializes a new instance of the System.Collections.Generic.Dictionary`2 class
        //     that contains elements copied from the specified System.Collections.Generic.IDictionary`2
        //     and uses the specified System.Collections.Generic.IEqualityComparer`1.
        //
        // Parameters:
        //   dictionary:
        //     The System.Collections.Generic.IDictionary`2 whose elements are copied to the
        //     new System.Collections.Generic.Dictionary`2.
        //
        //   comparer:
        //     The System.Collections.Generic.IEqualityComparer`1 implementation to use when
        //     comparing keys, or null to use the default System.Collections.Generic.EqualityComparer`1
        //     for the type of the key.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     dictionary is null.
        //
        //   T:System.ArgumentException:
        //     dictionary contains one or more duplicate keys.
        public Model(IDictionary<string, ICell> dictionary, IEqualityComparer<string> comparer) : base(dictionary, comparer) 
        {
        }

        //
        // Summary:
        //     Adds a key/value pair to the System.Collections.Concurrent.ConcurrentDictionary`2
        //     if the key does not already exist.
        //
        // Parameters:
        //   key:
        //     The key of the element to add.
        //
        //   value:
        //     The value to be added, if the key does not already exist.
        //
        // Returns:
        //     The value for the key. This will be either the existing value for the key if
        //     the key is already in the dictionary, or the new value if the key was not in
        //     the dictionary.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     key is null.
        //
        //   T:System.OverflowException:
        //     The dictionary already contains the maximum number of elements (System.Int32.MaxValue).
        public new ICell GetOrAdd(string key, ICell value)
        {
            value.Parent = this;
            value.OnChange(CellEvent.Delete, this, this, DateTime.Now, null);
            return base.GetOrAdd(key, value);
        }

        //
        // Summary:
        //     Attempts to add the specified key and value to the System.Collections.Concurrent.ConcurrentDictionary`2.
        //
        // Parameters:
        //   key:
        //     The key of the element to add.
        //
        //   value:
        //     The value of the element to add. The value can be null for reference types.
        //
        // Returns:
        //     true if the key/value pair was added to the System.Collections.Concurrent.ConcurrentDictionary`2
        //     successfully; false if the key already exists.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     key is null.
        //
        //   T:System.OverflowException:
        //     The dictionary already contains the maximum number of elements (System.Int32.MaxValue).
        public new bool TryAdd(string key, ICell value)
        {
            value.Parent = this;
            value.OnChange(CellEvent.Delete, this, this, DateTime.Now, null);
            return base.TryAdd(key, value);
        }
        //
        // Summary:
        //     Attempts to remove and return the value that has the specified key from the System.Collections.Concurrent.ConcurrentDictionary`2.
        //
        // Parameters:
        //   key:
        //     The key of the element to remove and return.
        //
        //   value:
        //     When this method returns, contains the object removed from the System.Collections.Concurrent.ConcurrentDictionary`2,
        //     or the default value of the TValue type if key does not exist.
        //
        // Returns:
        //     true if the object was removed successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     key is null.
        public new bool TryRemove(string key, out ICell value)
        {
            if (base.TryRemove(key, out value))
            {
                if (value.Parent == this)
                    value.Parent = null;
                RaiseChange(CellEvent.Link, value, null, DateTime.Now, Session.Current);
                return true;
            }
            else
                return false;
        }
        //
        // Summary:
        //     Compares the existing value for the specified key with a specified value, and
        //     if they are equal, updates the key with a third value.
        //
        // Parameters:
        //   key:
        //     The key whose value is compared with comparisonValue and possibly replaced.
        //
        //   newValue:
        //     The value that replaces the value of the element that has the specified key if
        //     the comparison results in equality.
        //
        //   comparisonValue:
        //     The value that is compared to the value of the element that has the specified
        //     key.
        //
        // Returns:
        //     true if the value with key was equal to comparisonValue and was replaced with
        //     newValue; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     key is null.
        public new bool TryUpdate(string key, ICell newValue, ICell comparisonValue)
        {
            if (base.TryUpdate(key, newValue, comparisonValue))
            {
                if (newValue != comparisonValue)
                {
                    newValue.Parent = this;
                    RaiseChange(CellEvent.Link, newValue, null, DateTime.Now, Session.Current);
                    return true;
                }
                else
                    return true;
            }
            else
                return false;
        }

        //
        // Summary:
        //     Gets or sets the value associated with the specified key.
        //
        // Parameters:
        //   key:
        //     The key of the value to get or set.
        //
        // Returns:
        //     The value of the key/value pair at the specified index.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     key is null.
        //
        //   T:System.Collections.Generic.KeyNotFoundException:
        //     The property is retrieved and key does not exist in the collection.
        public new ICell this[string key]
        {
            get
            {
                ICell cell;
                ICell retr = null;
                if (TryGetValue(key, out cell))
                    return cell;
                else if (key.Contains("|"))
                {
                    var s = key.Substring(0, key.IndexOf('|'));
                    if (TryGetValue(s, out cell) && cell is Model m)
                    {
                        s = key.Substring(key.IndexOf('|') + 1);
                        retr = m[s];
                    }
                    if ((retr == null || retr is ICellEmpty) && Parent != null && Parent is Model m2)
                        return m2[key];
                    else
                        return retr;
                }
                else if (base.ContainsKey(key))
                    return base[key];
                else
                    return null;
            }
            set
            {
                value.Parent = this;
                ICell current;
                if (TryGetValue(key, out current))
                {
                    if (value != current && current.GetType().IsAssignableFrom(value.GetType()))
                    {
                        base[key] = value;
                        var dependants = current.Dependants;
                        foreach (var c in dependants)
                        {
                            if (c != null && c != this)
                                value.Change += c.OnChange;
                        }
                        foreach (var c in dependants)
                        {
                            if (this != c)
                                c.OnChange(CellEvent.Link, current, this, DateTime.Now, null);
                        }
                    }
                }
                else if (key.Contains("|"))
                {
                    var s = key.Substring(0, key.IndexOf('|'));
                    if (TryGetValue(s, out current) && current is Model m)
                    {
                        s = key.Substring(key.IndexOf('|') + 1);
                        m[s] = value;
                    }
                }
                else
                {
                    base[key] = value;
                }
            }
        }
        #endregion
        /// <summary>
        /// Get the value of this[key] with a typecast
        /// </summary>
        /// <typeparam name="T">type expected</typeparam>
        /// <param name="key">mnemonic</param>
        /// <returns></returns>
        public Generic.ICell<T> As<T>(string key)
        {
            ICell cell;
            ICell<T> retr = null;
            if (TryGetValue(key, out cell))
                return cell as Generic.ICell<T>;
            else if (key.Contains("|"))
            {
                var s = key.Substring(0, key.IndexOf('|'));
                if (TryGetValue(s, out cell) && cell is Model m)
                {
                    s = key.Substring(key.IndexOf('|') + 1);
                    retr = m[s] as Generic.ICell<T>;
                }
                if (retr is CellEmpty<T> && Parent != null && Parent is Model m2)
                    return m2[key] as Generic.ICell<T>;
                else
                    return retr;
            }
            else
                return new CellEmpty<T>(key);       // special case for forward declarartion
        }

        /// <summary>
        /// Bind mbmers of the model to the dictionar and set the mnemonic for the cell
        /// </summary>
        public void Bind ()
        {
            var properties = this.GetType().GetProperties();
            var type = typeof(ICell);

            foreach (var p in properties)
            {
                foreach (var i in p.PropertyType.GetInterfaces())
                {
                    if (i == type)
                    {
                        var c = p.GetValue(this) as ICell;
                        if (c != null)
                        {
                            this[p.Name] = c;
                            if (c.Mnemonic != null)
                                this[c.Mnemonic] = c;
                            else
                                c.Mnemonic = p.Name;
                        }
                    }
                }
            }
        }
        /// <see cref="ICell.HasFunction"/>
        public bool HasFunction => false;
        /// <see cref="ICell.HasValue"/>
        public bool HasValue => true;

        /// <see cref="ICell.Box"/>
        public virtual object Box
        {
            get
            {
                return this;
            }
            set
            {
                var e = value as IEnumerable<ICell>;
                if (e != null)
                    foreach (var c in e)
                        this[c.Mnemonic] = c;
            }
        }

        public IDisposable Subscribe(IObserver<ICell> observer)
        {
            return new ModelObserver(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<ISession, KeyValuePair<string, ICell>>> observer)
        {
            return new ModelSessionObserver(this, observer);
        }

        public IDisposable Subscribe(IObserver<Tuple<ISession, Model, CellEvent, ICell, DateTime>> observer)
        {
            return new ModelTraceObserver(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<string, double>> observer)
        {
            return new ModelCellObserver<double>(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<string, int>> observer)
        {
            return new ModelCellObserver<int>(this, observer);
        }

        public IDisposable Subscribe(IObserver<KeyValuePair<string, decimal>> observer)
        {
            return new ModelCellObserver<decimal>(this, observer);
        }

        public virtual void Merge(ICell source, Model model)
        {
            foreach (var d in source.Dependants)
            {
                Change += d.OnChange;
            }
        }
        public void ModelNotify(ICell listener)
        {
            if (listener == this) return;
            foreach (var v in Dependants)
                if (v == listener)
                    return;
            Change += listener.OnChange;
        }
        public virtual void Notify(ICell listener)
        {
            ModelNotify(listener);
        }

        public void ModelUnNotify(ICell listener)
        {
            Change -= listener.OnChange;
        }
        public virtual void UnNotify(ICell listener)
        {
            ModelUnNotify(listener);
        }
        public virtual object GetFunction()
        {
            return null;
        }
        public virtual bool ValueIs<Base>()
        {
            return typeof(Model) == typeof(Base);
        }
        public virtual CellState State => CellState.Clean;
        public virtual Exception Error => null;
    }
}
