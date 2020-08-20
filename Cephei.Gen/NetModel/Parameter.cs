using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cephei.Gen.NetModel
{
    public class Parameter
    {
        public string ParameterType;
        public Class Dependancy;
        public string Name;
        public string Notes;
        public int Pos;
        public string Default;

        public Method Method;

        public Parameter (EA.Gen.Model.IOperationParam p, Method method)
        {
            ParameterType = (p.Type != "object" ? p.Type : "Object")
                .Replace("double?", "Nullable<double>")
                .Replace("List<", "Generic.List<")
                .Replace(" ", "")
                .Replace("ulong", "uint64")
                .Replace("object[]", "Object[]");
            if (ParameterType.EndsWith("?"))
                ParameterType = "Nullable<" + ParameterType.Substring(0, ParameterType.Length - 1) + ">";

            if (Context.Keywords.Contains(p.Name))
                Name = p.Name.Substring(0, 1).ToUpper() + p.Name.Substring(1);
            else
                Name = p.Name;
            Notes = p.Notes;
            Pos = (p.Pos.HasValue ? p.Pos.Value : 0);
            Default = p.Default;
            Method = method;
        }

        public void Link()
        {
            var q = Class.Parse(ParameterType);
            Dependancy = Method.FindByStack(q);
            if (Dependancy != null && Dependancy.Parent != null)
                ParameterType = Dependancy.Name + "." + ParameterType;
            else
            {
                foreach (var t in Method.Class.Templates)
                    if (ParameterType == t.Name)
                        ParameterType = "'" + ParameterType;
                    else if (ParameterType.Contains("<"))
                        ParameterType = ParameterType.Replace("<" + t.Name + ">", "<'" + t.Name + ">");

            }
        }


        public static SortedList<int, Parameter> GetParametersByMethod(Method method)
        {
            var q = (from r in Context.Paremters.Value
                     where r.OperationId == method.Id
                     select new Parameter(r, method)).ToArray();

            var ret = new SortedList<int, Parameter>();

            for(int c = 0; c < q.Length; c++)
            {
                ret.Add(c, q[c]);
            }
            return ret; 
        }
        private int? _depth;
        public int DependancyDepth(int recurse = 0)
        {
            if (_depth.HasValue) return _depth.Value;

            int d = 0;
            if (Dependancy != null)
                d = Dependancy.DependancyDepth(recurse + 1);
            _depth = d;
            return d;
        }
        public bool HasEngine
        {
            get
            {
                if (ParameterType == "IPricingEngine")
                    return true;
                else return false;
            }
        }

    }
}
