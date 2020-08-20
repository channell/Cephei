using Orleans;
using Orleans.EventSourcing;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cephei.Cell;

namespace Cephei.Orleans
{
    public class ModelGrain<ModelT> : JournaledGrain<ModelData>, IModelGrain, IObserver<KeyValuePair<ISession, KeyValuePair<string, ICell>>> where ModelT : Model, new()
    {
        private ModelT _model;
        private IDisposable _modelSubscription;
        private Dictionary<string, ICell> _publish = new Dictionary<string, ICell>();
        private Dictionary<string, ICell> _subscriptions = new Dictionary<string, ICell>();
        private HashSet<ISession> _sessions = new HashSet<ISession>();

        public ModelGrain  () :base ()
        {
            _model = new ModelT();

            foreach (var c in _model)
            {
                if (c.Value.HasFunction)
                    _publish.Add(c.Key, c.Value);
                else
                    _subscriptions.Add(c.Key, c.Value);
            }
            _model.Subscribe(this);
        }

        #region IObserver<KeyValuePair<ISession, KeyValuePair<string, ICell>>> 
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(KeyValuePair<ISession, KeyValuePair<string, ICell>> value)
        {
            _publish[value.Value.Key] = value.Value.Value;
            if (value.Key.PercentComplete == 1)
                
            
            throw new NotImplementedException();
        }
        #endregion

        #region IGrainModel
        public Task<bool> Subscribe(string providers)
        {
            throw new NotImplementedException();
        }

        public Task<KeyValuePair<string, object>[]> Values()
        {
            throw new NotImplementedException();
        }
        public Task<Exception> ErrorNotification()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
