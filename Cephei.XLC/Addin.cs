using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDna.Integration;
using ExcelDna.Integration.Rtd;
using ExcelDna.Integration.CustomUI;
using Cephei.XL;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Cephei.XL
{
    [ComVisible(true)]
    public class Addin : ExcelDna.Integration.IExcelAddIn
    {
        public void AutoClose()
        {
        }

        public void AutoOpen()
        {

        }
    }
}
