using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA.Gen.Model.Jet;

namespace Cephei.Gen.Model
{
    public class Method
    {
        public string Name;
        public string Notes;
        public CTSType ReturnType;
        public int Id;
        public bool IsAbstract;
        public bool IsLocking;
        public SortedList<int, Parameter> Parameters = new SortedList<int, Parameter>();
        public Class Class;
        private Context _context;

        public Method(Operation method, Context context, Element element, Class cls)
        {
            _context = context;
            Name = _context.CTSKeyWord[method.Name];
            Notes = method.Notes ?? "";
            Id = method.Id;
            IsAbstract = method.Abstract == "1";
            IsLocking = !(method.IsQuery);
            Class = cls;
            if (Name.StartsWith("operator"))
            {
                char[] c = new char[] { ' ' };
                string[] str = Name.Split(c);
                if (str.Length == 2)
                {
                    CTSType t = context.GetCTSType(str[1], element);
                    Name = str[0] + " " + t.Value;
                    ReturnType = t;
                }
            }
            else
            {
                ReturnType = context.GetCTSType(method.Type, element);
            }
            int i = 0;
            foreach (var parameter in method.Params)
            {
                Parameter p = new Parameter(parameter, element, context);
                Parameters.Add(parameter.Pos ?? i , p);
                ++i;
            }
        }

        /// <summary>
        /// Get a string with all the parameters and types specified for output to source file
        /// </summary>
        /// <param name="includeType">include types in function spec (false is inline code to do a call)</param>
        /// <param name="prefix">"I" if we're using the interface name </param>
        /// <param name="suffix">"^" if we're generating C++/CLI</param>
        /// <param name="namespaceDelimiter">"::" for C++/CLI, "." for c#</param>
        /// <returns></returns>
        public string GetParamConstructor(bool includeType, string prefix, string suffix, string namespaceDelimiter)
        {
            StringBuilder result = new StringBuilder();
            string delimiter = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delimiter + pair.Value.GetQualifiedType(includeType, namespaceDelimiter, prefix, suffix) + " " + (includeType ? pair.Value.Name : prefix + pair.Value.Name));
                delimiter = ", ";
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null)
            {
                result.Append(delimiter + (includeType ? pricer.GetQualifiedType(includeType, namespaceDelimiter, prefix, suffix) : "")
                    + " " + (includeType ? "QL_Pricer" : prefix + "QL_Pricer"));

            }
            return result.ToString();
        }

        /// <summary>
        /// Get a string with all the parameters and types specified for output to source file.
        /// as above, but exclude any pricing engine parameters.
        /// </summary>
        /// <param name="includeType">include types in function spec (false is inline code to do a call)</param>
        /// <param name="prefix">"I" if we're using the interface name </param>
        /// <param name="suffix">"^" if we're generating C++/CLI</param>
        /// <param name="namespaceDelimiter">"::" for C++/CLI, "." for c#</param>
        /// <returns></returns>
        public string GetParamString(bool includeType, string prefix, string suffix, string namespaceDelimiter)
        {
            StringBuilder result = new StringBuilder();
            string delimiter = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delimiter + pair.Value.GetQualifiedType(includeType, namespaceDelimiter, prefix, suffix) + " " + (includeType ? pair.Value.Name : prefix + pair.Value.Name));
                delimiter = ", ";
            }
            return result.ToString();
        }

        public string GetParamCallString(string prefix, string suffix, string delimiter)
        {
            StringBuilder result = new StringBuilder();
            string delim = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delim + prefix + pair.Value.Name + suffix);
                delim = delimiter;
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null && Name == Class.Name)
            {
                result.Append(delimiter + prefix + "QL_Pricer" + suffix);
            }
            return result.ToString();
        }

        public string GetParamCallStringWithOption(string prefix, string suffix, string delimiter)
        {
            StringBuilder result = new StringBuilder();
            string delim = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delim + prefix + pair.Value.Name + "," + pair.Value.IsOptional.ToString().ToLower() + suffix);
                delim = delimiter;
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null && Name == Class.Name)
            {
                result.Append(delimiter + prefix + "QL_Pricer,false" + suffix);
            }
            return result.ToString();
        }

        public string GetParamCallStringXL(string prefix, string suffix, string delimiter)
        {
            StringBuilder result = new StringBuilder();
            string delim = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delim + prefix + "XLHelper.Validate<" + pair.Value.ParameterType.GetQualifiedTypeWithoutOption(false, ".", "I", "") + "> (" + pair.Value.Name + ", " + (pair.Value.Default == "").ToString().ToLower() + ", \"" + pair.Value.Name + "\")" + suffix);
                delim = delimiter;
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null && Name == Class.Name)
            {
                result.Append(delimiter + prefix + "XLHelper.AssertToString (QL_Pricer, true, \"QL_Pricer\")" + suffix);
            }
            return result.ToString();
        }

        public string GetCellParamConstructor(string prefix, string suffix, string namespaceDelimiter)
        {
            StringBuilder result = new StringBuilder();
            string delim = "";
            if (Name != Class.Name)
            {
                result.Append("Cephei.Core.Generic.ICell<" + Class.GetNamespace(".") + ".I" + Class.Name + "> " + Class.Name);
                delim = ", ";
            }
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delim + pair.Value.GetQualifiedCellType(namespaceDelimiter, prefix, suffix) + " " + pair.Value.Name);
                delim = ", ";
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null && Name == Class.Name)
            {
                result.Append(", " + pricer.GetQualifiedCellType(namespaceDelimiter, prefix, suffix) + " QL_Pricer");
            }
            return result.ToString();
        }
        public string GetCellParamCallConstructor2(string prefix, string suffix, string namespaceDelimiter)
        {
            StringBuilder result = new StringBuilder();
            string delim = "";
            if (Name != Class.Name)
            {
                result.Append(Class.Name);
                delim = ", ";
            }
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delim + pair.Value.Name);
                delim = ", ";
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null && Name == Class.Name)
            {
                result.Append(", QL_Pricer");
            }
            return result.ToString();
        }

        public string GetFSConstructor(string prefix, string suffix, string namespaceDelimiter)
        {
            StringBuilder result = new StringBuilder();
            string delim = "";
            if (Name != Class.Name)
            {
                result.Append(Class.Name.ToLower() + " : Cephei.Core.Generic.ICell<" + Class.GetNamespace(".") + ".I" + Class.Name + "> ");
                delim = ", ";
            }
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delim + pair.Value.Name.ToLower() + " : " + pair.Value.GetQualifiedCellType(namespaceDelimiter, prefix, suffix) + " ");
                delim = ", ";
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null && Name == Class.Name)
            {
                result.Append(", ql_Pricer : " + pricer.GetQualifiedCellType(namespaceDelimiter, prefix, suffix));
            }
            return result.ToString();
        }

        public string GetCellParamString(string prefix, string suffix, string namespaceDelimiter)
        {
            StringBuilder result = new StringBuilder();
            string delimiter = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                result.Append(delimiter + pair.Value.GetQualifiedCellType(namespaceDelimiter, prefix, suffix) + " " + pair.Value.Name);
                delimiter = ", ";
            }
            return result.ToString();
        }

        public string GetCellParamCall(string prefix, string suffix, string delim)
        {
            StringBuilder result = new StringBuilder();

            string delimiter = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                {
                    if (pair.Value.Default != "" || pair.Value.ParameterType.isOptional)
                        result.Append(delimiter + " " + prefix + "CellHelper.ToOption(" + pair.Value.Name + ")" + suffix);
                    else
                        result.Append(delimiter + " " + prefix + pair.Value.Name + ".Value" + suffix);
                }
                delimiter = delim;
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null && Name == Class.Name)
            {
                result.Append(delimiter + " " + prefix + "QL_Pricer.Value" + suffix);

            }
            return result.ToString();
        }

        public string GetCellParamCallConstructor(string prefix, string suffix)
        {
            StringBuilder result = new StringBuilder();
            string delimiter = "";
            foreach (KeyValuePair<int, Parameter> pair in this.Parameters)
            {
                if (pair.Value.ParameterType.Feature == CTSType.FeatureType.Enum)
                {
                    result.Append(delimiter + " " + prefix + pair.Value.Name);
                }
                else
                {
                    result.Append(delimiter + " " + prefix + pair.Value.Name + "->Value" + suffix);
                }
                delimiter = ", ";
            }
            Parameter pricer = Class.PricingParameter();
            if (pricer != null)
            {
                result.Append(delimiter + " " + prefix + "QL_Pricer->Value" + suffix);

            }
            return result.ToString();
        }
        bool? _IsNameUnique;
        public bool IsNameUnique
        {
            get
            {
                if (!_IsNameUnique.HasValue)
                {
                    foreach (Method m in Class.AllMethods)
                    {
                        if (m.Name == Name && m != this && (m.Parameters.Count != 0 || Parameters.Count != 0))
                        {
                            _IsNameUnique = false;
                            break;
                        }
                    }
                    if (!_IsNameUnique.HasValue)
                    {
                        _IsNameUnique = true;
                    }
                }
                return _IsNameUnique.Value;
            }
        }

        public string XMLAttributeName
        {
            get
            {
                if (Name == Class.Name)
                {
                    return Class.GetNamespace("_") + "_" + Name + (IsNameUnique ? "" : "_" + Id.ToString());
                }
                else
                {
                    return Class.GetNamespace("_") + "_" + Class.Name + "_" + Name + (IsNameUnique ? "" : "_" + Id.ToString());
                }
            }
        }

        public bool Same(Method THAT)
        {
            if (this == THAT) return true;
            if (this.Name == THAT.Name)
            {
                if (this.ReturnType == null && THAT.ReturnType == null)
                    return true;
                if ((this.ReturnType == null && THAT.ReturnType != null)
                    || (this.ReturnType != null && THAT.ReturnType == null)
                   )
                    return false;

                if (this.Name == THAT.Name && this.ReturnType.Value == THAT.ReturnType.Value)
                {
                    if (Parameters == null && THAT.Parameters == null)
                        return true;
                    if ((Parameters == null && THAT.Parameters != null)
                        || (Parameters != null && THAT.Parameters == null)
                       )
                        return false;
                    if (Parameters.Count == 0 && THAT.Parameters.Count == 0)
                        return true;

                    IEnumerator<KeyValuePair<int, Parameter>> thisE = this.Parameters.GetEnumerator();
                    IEnumerator<KeyValuePair<int, Parameter>> thatE = THAT.Parameters.GetEnumerator();

                    while (thisE.MoveNext())
                    {
                        if (!thatE.MoveNext()) return false;
                        if (thisE.Current.Value.ParameterType.Value != thatE.Current.Value.ParameterType.Value) return false;
                    }
                    return !thatE.MoveNext();
                }
            }
            return false;
        }

        public bool IsProperty()
        {
            return (Parameters.Count == 0 && ReturnType != null);
        }
        public string UpperName
        {
            get
            {
                return Name.Substring(0, 1).ToUpper() + Name.Substring(1);
            }
        }

        public bool CellParameters()
        {
            int p = 0;
            foreach (KeyValuePair<int, Parameter> cp in Parameters)
                if (cp.Value.ParameterType.Feature != CTSType.FeatureType.Enum)
                    p++;
            return (p > 0);
        }

        public bool IsOveride
        {
            get
            {
                foreach (Method m in Class.OverrideMethods)
                {
                    if (this == m) return true;
                    /*                        if (Class != m.Class && Same (m))
                                                return true;
                                        */
                }
                return false;
            }
        }
        public string DataClassName
        {
            get
            {
                return XLClassName.Replace("_", ".");
            }
        }
        public string XLClassName
        {
            get
            {
                if (Name == Class.Name && IsNameUnique)
                {
                    return Class.Name;
                }
                else if (IsNameUnique)
                {
                    if (UpperName == "Calculate")
                        return "CCalculate";
                    else if (Class.Name.ToUpper() == Name.ToUpper() && Name != Class.Name)
                        return Name;
                    else
                        return UpperName;
                }
                else
                {
                    StringBuilder sb = new StringBuilder(UpperName);
                    string prefix = "";
                    if (Parameters.Count > 0)
                        sb.Append("_");
                    foreach (KeyValuePair<int, Parameter> pair in Parameters)
                    {
                        string s = pair.Value.ParameterType.Value;
                        if (s.Contains("::"))
                        {
                            string[] ss = s.Split(':');
                            s = ss[ss.Length - 1];
                        }
                        s = s.Replace("32", "").Replace("64", "");
                        //                            sb.Append (s.Substring(0,2));
                        sb.Append(prefix).Append(s);
                        prefix = "_";
                    }
                    return sb.ToString();
                }
            }
        }
        // trim the spec parameters that have a default value to allow generation of function without optional parameters
        public void TrimParameters()
        {
            SortedList<int, Parameter> newParameters = new SortedList<int, Parameter>();
            foreach (KeyValuePair<int, Parameter> pair in Parameters)
            {
                if ((pair.Value.ParameterType.Class == null || pair.Value.ParameterType.Class.IsSpec) &&
                    pair.Value.ParameterType.Feature == CTSType.FeatureType.Object &&
                    !(pair.Value.Default == null || pair.Value.Default == ""))
                {
                    Console.WriteLine("! dropping {0} ", pair.Value.Name);
                }
                else
                    newParameters.Add(pair.Key, pair.Value);
            }
            Parameters = newParameters;
        }
    }
}
