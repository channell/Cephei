using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace Cephei.Orleans
{
    /// <summary>
    /// Generic inteface to a model Grant
    /// </summary>
    public interface IModelGrain : IGrainWithStringKey, IGrainObserver
    {
        /// <summary>
        /// Get the values provided by the model
        /// </summary>
        /// <returns>state of completed calcualtions</returns>
        Task<KeyValuePair<string, object>[]> Values();

        /// <summary>
        /// Notifcation of any errors from the calculations
        /// </summary>
        /// <returns></returns>
        Task<Exception> ErrorNotification();


        /// <summary>
        /// Subscriptin from other models or data sources is configured for the scenario.  
        /// real-time pricing and realtime risk wouls typically subscribe to live market prices, but 
        /// back-testing and peturbations would use a historical sources
        /// </summary>
        /// <param name="providers">list of model providers</param>
        /// <returns>true if a connection could be established to all sources</returns>
        Task<bool> Subscribe(string providers);
    }
}
