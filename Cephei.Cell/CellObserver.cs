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


using Microsoft.FSharp.Core;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Cephei.Cell
{
    internal class CellObserver<T> : IDisposable, ICellEvent
    {
        Generic.ICell<T> _source;
        IObserver<T> _target;
            internal CellObserver(Generic.ICell<T> source, IObserver<T> target)
        {
            _source = source;
            _target = target;

            source.Change += OnChange;
            System.Threading.Tasks.Task.Run(() => 
            {
                try
                {
                    Thread.Sleep(100);
                    _target.OnNext(_source.Value);
                }
                catch (Exception e)
                {
                    _target.OnError(e);
                    Log.Error(e, e.Message);
                }
            });
        }

        public void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Calculate:
                case CellEvent.CalculateLogging:
                    if (root is ICell c && c.State == CellState.Error)
                        _target.OnError(((ICell)root).Error);
                    else
                        System.Threading.Tasks.Task.Run(() => 
                        {
                            try
                            {
                                _target.OnNext(_source.Value);
                            }
                            catch (Exception e)
                            {
                                Log.Error(e, e.Message);
                            }
                        });
                    break;

                case CellEvent.Delete:
                case CellEvent.DeleteLogging:
                    _target.OnCompleted();
                    break;

                case CellEvent.Error:
                case CellEvent.ErrorLogging:
                    if (root is ICell)
                        _target.OnError(((ICell)root).Error);
                    break;
                case CellEvent.Link:
                case CellEvent.LinkLogging:
                    if (_source.Parent != null && _source.Parent is Model)
                    {
                        var source = ((Model)_source.Parent)[_source.Mnemonic] as Generic.ICell<T>;
                        if (source != null)
                        {
                            _source = source;
                            OnChange(CellEvent.Calculate, sender, sender, epoch, session);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Change -= OnChange;
        }
        public ICell Parent
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

    }

    internal class SessionObserver<T> : IDisposable, ICellEvent
    {
        Generic.ICell<T> _source;
        IObserver<KeyValuePair<ISession, KeyValuePair<string,T>>> _target;
        internal SessionObserver(Generic.ICell<T> source, IObserver<KeyValuePair<ISession, KeyValuePair<string,T>>> target)
        {
            _source = source;
            _target = target;

            source.Change += OnChange;
            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    _target.OnNext(new KeyValuePair<ISession, KeyValuePair<string, T>>(null, new KeyValuePair<string, T>(_source.Mnemonic, _source.Value)));
                }
                catch (Exception e)
                {
                    _target.OnError(e);
                    Log.Error(e, e.Message);
                }
            });
        }

        public void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Calculate:
                case CellEvent.CalculateLogging:
                    var lastsession = Session.Current;
                    Session.Current = session;
                    System.Threading.Tasks.Task.Run(() =>
                    {
                        try
                        {
                            _target.OnNext(new KeyValuePair<ISession, KeyValuePair<string, T>>(session, new KeyValuePair<string, T>(_source.Mnemonic, _source.Value)));
                        }
                        catch (Exception e)
                        {
                            Log.Error(e, e.Message);
                        }
                    });
                    Session.Current = lastsession;
                    break;

                case CellEvent.Delete:
                case CellEvent.DeleteLogging:
                    _target.OnCompleted();
                    break;

                case CellEvent.Error:
                case CellEvent.ErrorLogging:
                    if (root is ICell)
                        _target.OnError(((ICell)root).Error);
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Change -= OnChange;
        }
        public ICell Parent
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

    }

    internal class TraceObserver<T> : IDisposable, ICellEvent
    {
        Generic.ICell<T> _source;
        IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>> _target;
        internal TraceObserver(Generic.ICell<T> source, IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>> target)
        {
            _source = source;
            _target = target;

            source.Change += OnChange;
            System.Threading.Tasks.Task.Run(() => 
            {
                try
                {
                    _target.OnNext(new Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>(null, _source, CellEvent.Calculate, null, DateTime.Now));
                }
                catch (Exception e)
                {
                    _target.OnError(e);
                    Log.Error(e, e.Message);
                }
            });
        }

        public void OnChange(CellEvent eventType, ICellEvent root, ICellEvent sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Invalidate:
                case CellEvent.Delete:
                case CellEvent.JoinSession:
                case CellEvent.Link:
                case CellEvent.Calculate:
                case CellEvent.InvalidateLogging:
                case CellEvent.DeleteLogging:
                case CellEvent.JoinSessionLogging:
                case CellEvent.LinkLogging:
                case CellEvent.CalculateLogging:
                    _target.OnNext(new Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>(session, _source, eventType, ((ICell)sender), epoch));
                    break;

                case CellEvent.Error:
                case CellEvent.ErrorLogging:
                    if (root is ICell)
                        _target.OnError(((ICell)root).Error);
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Change -= OnChange;
        }
        public ICell Parent
        {
            get
            {
                return null;
            }
            set
            {

            }
        }
    }

    public class TraceSubscriber<T> : IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>>, IDisposable
    {
        IDisposable listener;
        string printline;
        FSharpFunc<T, string> _formater;
        public TraceSubscriber(Generic.ICell<T> source, FSharpFunc<T, string> formater, string prefix = "")
        {
            listener = source.Subscribe(this);
            printline = "Observed " + prefix + source.Mnemonic + " : {0}";
            _formater = formater;
            var v = source.Value;
        }

        public void OnCompleted()
        {
            Log.Verbose("{0} Complete", printline);
        }

        public void OnError(Exception error)
        {
            Log.Error(error, "{0} Error {1}", error.Message);
        }

        public void OnNext(Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime> value)
        {
            Log.Verbose("Session {0} Cell {1} Value {2} Event {3} Source {4} Epoch {5}", value.Item1, value.Item2.Mnemonic, _formater.Invoke(value.Item2.Value), value.Item3, value.Item4, value.Item5);
        }

        public void Dispose()
        {
            listener.Dispose();
            GC.SuppressFinalize(this);
        }
        ~TraceSubscriber()
        {
            listener.Dispose();
        }
    }

    public class ConsoleSubscriber<T> : IObserver<T>, IDisposable
    {
        IDisposable listener;
        string printline;
        string last = null;
        public ConsoleSubscriber(Generic.ICell<T> source, string prefix = "")
        {
            listener = source.Subscribe(this);
            printline = "Observed " + prefix + " : {0}";
            var v = source.Value;
        }

        public void OnCompleted()
        {
            Console.WriteLine(printline, "Complete");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(printline, "Error " + error.Message);
        }

        public void OnNext(T value)
        {
            var ie = value as IEnumerable;
            if (ie != null && !(ie is string))
            {
                Console.WriteLine(printline, "...");
                foreach (var v in ie)
                {
                    Console.WriteLine(", {0}", v);
                }
            }
            else if (value.ToString() != last)
            {
                Console.WriteLine(printline, value);
                last = value.ToString();
            }
        }

        public void Dispose()
        {
            listener.Dispose();
            GC.SuppressFinalize(this);
        }
        ~ConsoleSubscriber()
        {
            listener.Dispose();
        }
    }
    public class ConsoleSessionSubscriber<T> : IObserver<KeyValuePair<ISession, KeyValuePair<string,T>>>, IDisposable
        {
        IDisposable listener;
        string printline;
        bool collection = false;

        public ConsoleSessionSubscriber(Generic.ICell<T> source, string prefix = "")
        {
            if (typeof(T) != typeof(string) && typeof(T).IsSubclassOf(typeof(IEnumerable))) collection = true;
            listener = source.Subscribe(this);
            printline = "{0} Observed {1}" + prefix + source.Mnemonic + " : {2}";
            var v = source.Value;
        }

        public void OnCompleted()
        {
            Console.WriteLine("Complete");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error " + error.Message);
        }

        public void OnNext(KeyValuePair<ISession, KeyValuePair<string,T>> value)
        {
            if (collection)
            {
                Console.Write(printline, value.Key, value.Value.Key, "...");
                foreach (var v in (IEnumerable)value.Value.Value)
                {
                    Console.Write(", {0}", v);
                }
                Console.WriteLine("");
            }
            else
                Console.WriteLine(printline, value.Key, value.Value.Key, value.Value.Value);
        }
        public void Dispose()
        {
            listener.Dispose();
            GC.SuppressFinalize(this);
        }
        ~ConsoleSessionSubscriber()
        {
            listener.Dispose();
        }
    }
}
