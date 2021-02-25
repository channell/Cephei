/*
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

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Cephei.Cell
{
    /// <summary>
    /// This is the only implementation of ISession, but is a separate class to allow
    /// different session semantics to be provided
    /// </summary>
    /// <example>
    /// use session = new Session()     // when the block completes
    /// </example>
    public class Session : ISession
    {
        private DateTime _epoch = DateTime.Now;
        private string _mnemonic;
        private volatile SessionState _state = SessionState.Open;
        private ISession _last_session;
        /// <summary>
        /// Cells that have joined the session in response to "JoinSession" event and Join
        /// () call
        /// </summary>
        private HashSet<ICell> _scope = new HashSet<ICell>();
        /// <summary>
        /// Cache of boxed values for cells associated with the cell.  Boxing is used
        /// because:
        /// <ul>
        /// 	<li>it is cheaper than providing separate dictionaries for each value type
        /// The cache is automatically collected when the session goes out of scope..</li>
        /// 	<li>which would not be the case if history was retained with the cell</li>
        /// </ul>
        /// </summary>
        private ConcurrentDictionary<ICell, object> _values = new ConcurrentDictionary<ICell, object>();
        /// <summary>
        /// Thread local reference to the current session to allow Cells to join the
        /// session without explicit coding
        /// </summary>
        [ThreadStatic]
        public static ISession Current = null;

        public event SessionComplete Complete;

        public static Session Create(string mnemonic)
        {
            return new Session(mnemonic);
        }

        internal Session(string mnemonic, SessionStream parent)
        {
            _mnemonic = mnemonic;
            Session.Current = parent;
            _last_session = parent;
        }
        public Session(string mnemonic)
        {
            _mnemonic = mnemonic;
            _last_session = Session.Current;
            Session.Current = this;
        }
        public SessionState State => _state;

        public string Mnemonic => _mnemonic;

        public DateTime Epoch => _epoch;

        public int Size => _scope.Count();
        public double PercentComplete => _values.Count() / _scope.Count();

        public bool GetValue<T>(ICell cell, ref T value)
        {
            object o;
            if (_values.TryGetValue(cell, out o))
            {
                value = (T)o;
                return true;
            }
            else
                return false;
        }

        public bool HasJoined(ICell cell)
        {
            return _scope.Contains(cell);
        }

        public void Join(ICell cell)
        {
            if (!_scope.Contains(cell)) _scope.Add(cell);
            if (_last_session != null)
                _last_session.Join(cell);
        }

        public void Leave(ICell cell)
        {
            if (!_scope.Contains(cell)) _scope.Remove(cell);
            if (_scope.Count == 0)
            {
                _state = SessionState.Complete;
                if (Complete != null)
                    Complete(this);
            }
        }

        public void SetValue<T>(ICell cell, T value)
        {
            _values[cell] = value;
            if (_last_session != null)
                _last_session.SetValue(cell, value);
        }

        public void Dispose()
        {
            Calculate();
        }
        public void Calculate()
        {
            Session.Current = _last_session;
            _state = SessionState.Calculating;
            foreach (var c in _scope)
            {
                c.OnChange(CellEvent.Calculate, c, c, _epoch, this);
            }
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            foreach (var v in _scope)
            {
                yield return v;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// SessionStream is designed for overlapping sessions, where a new session is started whenever the cureent session completes
    /// Usefull for real-time risk where the end of a compute intensive calculation triggers the begining of a new one
    /// </summary>
    public class SessionStream : ISession
    {
        private ISession _last_session;
        private ISession _current;
        private ISession _next;
        public SessionStream (string mnemonic)
        {
            _current = new Session(mnemonic);
            _next = new Session(mnemonic);
            _last_session = Session.Current;
            _current.Complete += Completed;
            _next.Complete += Completed;
            Session.Current = this;
        }

        public ISession Current => _current;

        public SessionState State => _current.State;

        public string Mnemonic => _current.Mnemonic;

        public DateTime Epoch => _current.Epoch;

        public int Size => _current.Size;

        public double PercentComplete => _current.PercentComplete;

        public event SessionComplete Complete;

        public void Calculate()
        {
            _current.Calculate();
        }

        public void Dispose()
        {
            _current.Dispose();
        }

        public bool GetValue<T>(ICell cell, ref T value)
        {
            if (_current.State != SessionState.Complete)
                return _current.GetValue(cell, ref value);
            else 
                return _next.GetValue (cell, ref value);
        }

        public bool HasJoined(ICell cell)
        {
            if (_current.State != SessionState.Complete)
                return _current.HasJoined(cell);
            else
                return _next.HasJoined(cell);
        }

        public void Join(ICell cell)
        {
            if (_current.State == SessionState.Open)
                _current.Join(cell);
            else
                _next.Join(cell);
        }

        public void Leave(ICell cell)
        {
            if (_current.State != SessionState.Complete)
                _current.Leave(cell);
            else
                _next.Leave(cell);
        }

        public void SetValue<T>(ICell cell, T value)
        {
            if (_current.State != SessionState.Complete)
                _current.SetValue(cell, value);
            else
                _next.SetValue(cell, value);
        }
        internal void Completed (ISession session)
        {
            _current = _next;
            _next = new Session(session.Mnemonic);
            _next.Complete += Completed;
            if (Complete != null) 
                Complete(session);
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            if (_current.State != SessionState.Complete)
                return _current.GetEnumerator();
            else
                return _next.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
