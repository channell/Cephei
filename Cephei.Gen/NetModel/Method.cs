using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cephei.Gen.NetModel
{
    public class Method
    {
        public string Name;
        public string Notes;
        public string ReturnType;
        public int Id;
        public bool IsLocking;
        public bool IsProperty;
        public SortedList<int, Parameter> Parameters = new SortedList<int, Parameter>();
        public int DuplicateOrder = 0;

        public Class Dependancy;
        public Class Class;

        /// <summary>
        /// For missing constructor
        /// </summary>
        public Method(Class @class)
        {
            Name = @class.Name;
            Notes = "Missing Constructor";
            Parameters = new SortedList<int, Parameter>();
            Class = @class;
        }

        public Method(EA.Gen.Model.IOperation op, Class @class)
        {
            Name = op.Name;
            Notes = op.Notes;
            ReturnType = (op.Type != null ? op.Type.Replace("double?", "Nullable<double>").Replace(" ", "") : null);
            if (ReturnType != null && ReturnType.EndsWith("?"))
                ReturnType = "Nullable<" + ReturnType.Substring(0, ReturnType.Length - 1) + ">";
            Id = op.Id;
            IsLocking = op.IsQuery;
            Class = @class;
            IsProperty = (op.Stereotype == "property" ? true : false);

            Parameters = Parameter.GetParametersByMethod(this);
        }

        public void Link()
        {
            var q = Class.Parse(ReturnType);
            if (q != null)
            {
                Dependancy = Class.FindByStack(q);
                if (Dependancy != null && Dependancy.Parent != null)
                    ReturnType = Dependancy.Parent.Name + "." + ReturnType;
            }
            foreach(var v in Parameters)
            {
                v.Value.Link();
            }
        }

        public Class FindByStack(Stack<string> q)
        {
            return Class.FindByStack(q);
        }
        public static List<Method> GetMethodsByClass (Class @class)
        {
            var q = (from r in Context.Operations.Value
                     where r.ElementId == @class.Id
                        && r.Name != "Results"
                        && !r.Name.StartsWith("operator") 
                        && !r.Name.StartsWith("~")
                        && r.Name != "GetHashCode"
                        && r.Scope == "Public"
                        && r.Name  != "notifyObserversEvent"
                        && r.IsStatic != "1"
                     orderby r.Name
                     select new Method(r, @class)).ToList();

            Method last = null;

            foreach (var m in q)
            {
                if (last != null && m.Name == last.Name)
                {
                    m.DuplicateOrder = last.DuplicateOrder + 1;
                }
                last = m;
            }
            return q;
        }
        public bool IsReturnTypeObject
        {
            get
            {
                var q = Class.Parse(ReturnType);
                if (q != null && Class.FindByStack(q) != null)
                    return true;
                else
                    return false;
            }
        }


        private int? _depth;
        public int DependancyDepth(int recurse = 0)
        {
            if (_depth.HasValue) return _depth.Value;

            int d = 0;
            if (Dependancy != null)
                d = Dependancy.DependancyDepth(recurse + 1);

            foreach (var v in Parameters)
            {
                int e = v.Value.DependancyDepth(recurse + 1);
                if (e > d) d = e;
            }
            _depth = d;
            return d;
        }

        public string FSName
        {
            get
            {
                if (DuplicateOrder > 0)
                    return Name + DuplicateOrder.ToString();
                else
                    return Name;
            }
        }

        public string CapFSName
        {
            get
            {
                if (DuplicateOrder > 0)
                    return CapName + DuplicateOrder.ToString();
                else
                    return CapName;
            }
        }

        public string CapName
        {
            get
            {
/*
                if (Name.Length == 1)
                    return Name.ToUpper();
*/
                return Name.Substring(0, 1).ToUpper() + Name.Substring(1);
            }
        }

        /// <summary>
        /// Format as an F# Parameter spec
        /// </summary>
        /// <returns></returns>
        public string FSParameters
        {
            get
            {
                if (Parameters.Count == 0)
                    return "";
                else
                {
                    var sb = new StringBuilder();
                    foreach (var p in Parameters)
                    {
                        sb.AppendFormat("ICell<{0}> -> ", p.Value.ParameterType);
                    }
                    return sb.ToString();
                }
            }
        }

        /// <summary>
        /// Format as an F# Parameter spec
        /// </summary>
        /// <returns></returns>
        public string FormatParameters (string fmt, params string[] delims )
        {
            if (Parameters.Count == 0)
                return "";
            else
            {
                var sb = new StringBuilder();
                string delim = (delims.Length > 0 ? delims[0] : "");

                foreach (var p in Parameters)
                {
                    if (Context.Keywords.Contains(p.Value.Name))

                        sb.AppendFormat(delim + fmt, p.Value.Name.ToUpper(), p.Value.ParameterType);
                    else
                        sb.AppendFormat(delim + fmt, p.Value.Name, p.Value.ParameterType);
                    delim = (delims.Length > 0 ? delims[1] : "");
                }
                return sb.ToString();
            }
        }
        /// <summary>
        /// Format as an F# Parameter spec
        /// </summary>
        /// <returns></returns>
        public string FSConstructor
        {
            get
            {
                if (Parameters.Count == 0)
                    return "    () as this =";
                else
                {
                    var sb = new StringBuilder();
                    string delim = "(";
                    foreach (var p in Parameters)
                    {
                        sb.AppendFormat("    {0} {1} : ICell<{2}>\n", delim, (Context.Keywords.Contains(p.Value.Name) ? p.Value.Name.ToUpper() : p.Value.Name).PadRight(44, ' '), p.Value.ParameterType);
                        delim = ",";
                    }
                    if (Class.HasEngine)
                    {
                        sb.AppendFormat("    {0} {1} : ICell<{2}>\n", delim, "pricingEngine".PadRight(44, ' '), "IPricingEngine");
                        delim = ",";
                        sb.AppendFormat("    {0} {1} : ICell<{2}>\n", delim, "evaluationDate".PadRight(44, ' '), "Date");
                    }
                    sb.Append("    ) as this =\n");
                    return sb.ToString();
                }
            }
        }
        /// <summary>
        /// Format as an F# Parameter spec
        /// </summary>
        /// <returns></returns>
        public string FSFun (params string[] delims)
        {
            if (Parameters.Count == 0)
                return "";
            else
            {
                var sb = new StringBuilder();
                string delim = (delims.Length > 0 ? delims[0] : "");
                foreach (var p in Parameters)
                {
                    sb.AppendFormat("{0} {1}", delim, p.Value.Name);
                    delim = (delims.Length > 0 ? delims[1] : "");
                }
                if (Class.HasEngine)
                {
                    sb.AppendFormat("{0} {1}", delim, "pricingEngine");
                    sb.AppendFormat("{0} {1}", delim , "evaluationDate");
                }
                return sb.ToString();
            }
        }

        public string FSConstruct
        {
            get
            {
                if (Parameters.Count == 0)
                {
                    if (Class.HasEngine)
                        return string.Format("    let _{0} = cell (fun () -> withEngine _pricingEngine.Value (new {1} ()))", Name.PadRight(41, ' '), Class.FSTypeName);
                    else
                        return string.Format("    let _{0} = cell (fun () -> new {1} ())", Name.PadRight(41, ' '), Class.FSTypeName);
                }
                else
                {
                    var sb = new StringBuilder();
                    string delim = "(";
                    if (Class.HasEngine)
                    {
                        sb.AppendFormat("    let _{0} = cell (fun () -> withEngine _pricingEngine.Value (new {1} ", Name.PadRight(41, ' '), Class.FSTypeName);
                        foreach (var pam in Parameters)
                        {
                            sb.AppendFormat("{0}{1}.Value", delim, pam.Value.Name);
                            delim = ", ";
                        }
                        sb.Append(")))");
                        return sb.ToString();
                    }
                    else
                    {
                        sb.AppendFormat("    let _{0} = cell (fun () -> new {1} ", Name.PadRight(41, ' '), Class.FSTypeName);
                        foreach (var pam in Parameters)
                        {
                            sb.AppendFormat("{0}{1}.Value", delim, pam.Value.Name);
                            delim = ", ";
                        }
                        sb.Append("))");
                        return sb.ToString();
                    }
                }
            }
        }

        private bool? _hasEgnine;

        public bool HasEngine
        {
            get
            {
                if (_hasEgnine.HasValue) return _hasEgnine.Value;
                if (ReturnType == "IPricingEngine")
                    return true;
                else
                    foreach (var m in Parameters)
                        if (m.Value.HasEngine)
                        {
                            _hasEgnine = true;
                            return true;
                        }
                _hasEgnine = false;
                return false;
            }
        }
    }
}
