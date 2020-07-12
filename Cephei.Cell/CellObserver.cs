using Microsoft.FSharp.Core;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cephei.Cell
{
    internal class CellObserver<T> : IDisposable
    {
        Generic.ICell<T> _source;
        IObserver<T> _target;
        internal CellObserver(Generic.ICell<T> source, IObserver<T> target)
        {
            _source = source;
            _target = target;

            source.Change += Source_Change;
        }

        private void Source_Change(CellEvent eventType, ICell sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Calculate:
                    _target.OnNext(_source.Value);
                    break;

                case CellEvent.Delete:
                    _target.OnCompleted();
                    break;

                case CellEvent.Error:
                    try
                    {
                        _target.OnNext(_source.Value);
                    }
                    catch (Exception e)
                    {
                        _target.OnError(e);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Change -= Source_Change;
        }
    }

    internal class SessionObserver<T> : IDisposable
    {
        Generic.ICell<T> _source;
        IObserver<KeyValuePair<ISession, KeyValuePair<string,T>>> _target;
        internal SessionObserver(Generic.ICell<T> source, IObserver<KeyValuePair<ISession, KeyValuePair<string,T>>> target)
        {
            _source = source;
            _target = target;

            source.Change += Source_Change;
        }

        private void Source_Change(CellEvent eventType, ICell sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Calculate:
                    var lastsession = Session.Current;
                    Session.Current = session;
                    _target.OnNext(new KeyValuePair<ISession, KeyValuePair<string,T>>(session, new KeyValuePair<string,T>(_source.Mnemonic, _source.Value)));
                    Session.Current = lastsession;
                    break;

                case CellEvent.Delete:
                    _target.OnCompleted();
                    break;

                case CellEvent.Error:
                    try
                    {
                        _target.OnNext(new KeyValuePair<ISession, KeyValuePair<string, T>>(session, new KeyValuePair<string, T>(_source.Mnemonic, _source.Value)));
                    }
                    catch (Exception e)
                    {
                        _target.OnError(e);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Change -= Source_Change;
        }
    }

    internal class TraceObserver<T> : IDisposable
    {
        Generic.ICell<T> _source;
        IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>> _target;
        internal TraceObserver(Generic.ICell<T> source, IObserver<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>> target)
        {
            _source = source;
            _target = target;

            source.Change += Source_Change;
        }

        private void Source_Change(CellEvent eventType, ICell sender, DateTime epoch, ISession session)
        {
            switch (eventType)
            {
                case CellEvent.Invalidate:
                case CellEvent.Delete:
                case CellEvent.JoinSession:
                case CellEvent.Link:
                case CellEvent.Calculate:
                    _target.OnNext(new Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>(session, _source, eventType, sender, epoch));
                    break;

                case CellEvent.Error:
                    try
                    {
                        _target.OnNext(new Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>(session, _source, eventType, sender, epoch));
                    }
                    catch (Exception e)
                    {
                        _target.OnError(e);
                    }
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _source.Change -= Source_Change;
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
