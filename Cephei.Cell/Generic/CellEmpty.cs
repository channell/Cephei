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
using System.Collections.Generic;
using System.Text;

namespace Cephei.Cell.Generic
{
    internal interface ICellEmpty
    { }

    /// <summary>
    /// Holder class for forward reference of cells before definition
    /// </summary>
    /// <typeparam name="T">type</typeparam>
    public class CellEmpty<T> : Cell<T>, ICellEmpty
    {
        public CellEmpty() : base (default(T))
        {

        }

        public CellEmpty(string mnemonic) : base (default(T))
        {
            Mnemonic = mnemonic;
        }
    }
}
