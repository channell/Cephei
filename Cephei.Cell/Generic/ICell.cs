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

            /// <summary>
            /// Access the functions for this cell for cloning
            /// </summary>
            FSharpFunc<Unit, T> Function { get; set; }
        }
    }
}
