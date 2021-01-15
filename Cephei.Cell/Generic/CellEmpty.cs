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
