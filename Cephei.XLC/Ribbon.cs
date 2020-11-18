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
using System.Windows.Forms;
using System.IO;
using Serilog;

namespace Cephei.XL
{
    [ComVisible(true)]
    public class CepheiRibbon : ExcelRibbon
    {
        public override string GetCustomUI(string RibbonID)
        {
            return @"
    <customUI xmlns='http://schemas.microsoft.com/office/2009/07/customui' loadImage='LoadImage'>
      <ribbon>
        <tabs>
          <tab id='CustomTab' label='Cephei'>
            <group id='gBuild' label='Build'>
              <button id='cmdGenerate' label='Generate' image='generate' size='large' onAction='OnGenerate'/>
            </group >   
          </tab>
        </tabs>
      </ribbon>
    </customUI>";
        }

        /// <summary>
        /// Generate the F# source code for this model
        /// </summary>
        /// <param name="control"></param>
        public void OnGenerate(IRibbonControl control)
        {
            try
            {
                ExcelReference ActiveSheetID = (ExcelReference)XlCall.Excel(XlCall.xlSheetId);
                string ActiveSheetName = (string)XlCall.Excel(XlCall.xlSheetNm, ActiveSheetID);

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "F# source (*.fs)|*.fs|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                dialog.Title = "Generate model to F# source";
                dialog.FileName = ActiveSheetName.Substring(ActiveSheetName.IndexOf(']') + 1) + ".fs";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string name = dialog.FileName.Substring(dialog.FileName.LastIndexOfAny(new char[] { '/', '\\' }));
                    name = name.Substring(1, name.IndexOf('.') - 1);
                    var source = Model.sourcecode(name);
                    using (var stream = dialog.OpenFile())
                    {
                        var writer = new StreamWriter(stream);
                        writer.Write(source);
                        writer.Close();
                        MessageBox.Show("Saved model to " + dialog.FileName, "Generate");
                    }
                }
            }
            catch (Exception e)
            {
                var st = e.StackTrace;
                Log.Error(e, e.Message);
                MessageBox.Show(e.Message, "Generate Error");
            }
        }
    }
}
