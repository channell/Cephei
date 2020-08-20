using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cephei.Orleans
{
    /// <summary>
    /// Serialisable state for a model grain
    /// </summary>
    [Serializable]
    public class ModelData
    {
        /// <summary>
        /// Cell values that are published from the model
        /// </summary>
        public KeyValuePair<string, object>[] Publish;

        /// <summary>
        /// subscription items
        /// </summary>
        public KeyValuePair<string,object>[] Subscritions;
    }
}
