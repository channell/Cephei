using System;
using System.Collections.Generic;

namespace Cephei.Cell
{
    namespace Generic
    {
        /// <summary>
        /// Cells have a single interface, but multiple implementations depending on the
        /// session semantics and/or optimized construction
        /// </summary>
        public interface ICell<T> : 
            ICell, 
            IObservable<T>, 
            IObservable<KeyValuePair<ISession, KeyValuePair<string, T>>>, 
            IObservable<Tuple<ISession, Generic.ICell<T>, CellEvent, ICell, DateTime>>,
            IObserver<T>
        {
            /// <summary>
            /// Either the Value of the Cell, or the appropriate value for the current session
            /// </summary>
            T Value { get; set; }
        }
    }
}
