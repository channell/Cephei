using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA.Gen.Model.Jet;

namespace Cephei.Gen.Model
{
    public class Parameter
    {
        public CTSType ParameterType;
        public string Name;
        public string Notes;
        public int Pos;
        public string Default;
        public bool IsDuplicateName = false;

        public Parameter(OperationParam parameter, Element element, Context context)
        {
            Name = context.CTSKeyWord[parameter.Name];
            Notes = parameter.Notes;
            Default = parameter.Default ?? "";
            ParameterType = context.GetCTSType(parameter.Type, element);
        }
        public string GetQualifiedType(bool includeType, string namespaceDelimiter, string prefix, string suffix)
        {
            return (includeType ? ParameterType.GetQualifiedType((Default != "" && !ParameterType.isOptional), namespaceDelimiter, prefix, suffix) : "");
        }

        public bool IsOptional
        {
            get
            {
                return (Default != "" && !ParameterType.isOptional);
            }
        }

        public string GetQualifiedCellType(string namespaceDelimiter, string prefix, string suffix)
        {
            return ("Cephei" + namespaceDelimiter + "Core" + namespaceDelimiter + "Generic" + namespaceDelimiter + "ICell<" + ParameterType.GetQualifiedTypeWithoutOption((Default != "" && !ParameterType.isOptional), namespaceDelimiter, prefix, suffix) + ">" + suffix);
        }
        public string GetQualifiedDefault()
        {
            string d = Default;
            if (d.Contains("Array"))
                d = "QuantLib::" + d;
            int i = d.LastIndexOf("<");
            if (i > 0 && d.Substring(i + 1, 4) != "bool") // Special case for default vector<bool>.. need to do a more generic version when time allows
            {
                d = d.Substring(0, i + 1) + "QuantLib::" + d.Substring(i + 1);
            }

            else if (d.Contains("(") && !d.Contains("std::"))
            {
                d = "QuantLib::" + d;
            }

            return d.Replace("QuantLib::QuantLib", "QuantLib");
        }

        public string CellHelper
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("CellHelper.CellObject");
                {
                    sb.Append("<");
                    sb.Append(ParameterType.GetQualifiedTypeWithoutOption(false, ".", "I", ""));
                }
                sb.Append(">");

                return sb.ToString().Replace("::", ".");
            }
        }
    }
}
