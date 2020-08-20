using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cephei.Gen.NetModel
{
    public class GenericType
    {
        public string Name;
        public int Pos;
        public string[] Type;
        public bool RequiresNew = false;

        public GenericType(string name, int pos, string type)
        {
            Name = name.Trim();
            Pos = pos;
            if (type != null && type.Contains("&"))
            {
                var l = new LinkedList<string>();
                foreach(var cond in type.Split('&'))
                {
                    foreach (var p in cond.Split(' '))
                    {
                        switch (p)
                        {
                            case "_c_^":
                                break;
                            case "new":
                            case "()":
                                RequiresNew = true;
                                break;

                            default:
                                l.AddLast(p);
                                break;
                        }
                    }
                }
                Type = l.ToArray();
            }
            else if (type == "new ()")
            {
                RequiresNew = true;
                Type = new string[] { };
            }
            else
                Type = new string[]{ type };
        }

        public string FSName => "'" + Name;
        public string FSType (ref string delim)
        {
            if (Type.Length == 0)
                return "";
            var sb = new StringBuilder();
            foreach (var t in Type)
            {
                if (t != null)
                {
                    if (t == "class")
                        sb.AppendFormat("{0} '{1} : not struct", delim, Name);
                    else
                        sb.AppendFormat("{0} '{1} :> {2}", delim, Name, t);
                    delim = " and";
                }
            }
            if (RequiresNew)
            {
                sb.AppendFormat("{0} '{1} : (new : unit -> '{1})", delim, Name);
                delim = " and";
            }
            return sb.ToString();
        }

        public static GenericType[] GetByClass(Class @class)
        {
            var q = (from r in Context.TemplateRef.Value
                     where r.Client == @class.Guid
                        && r.Type == "element property"
                        && r.Description.Contains("Type=ClassifierTemplateParameter")
                     select r.Description).ToArray();

            List<GenericType> ret = new List<GenericType>();
            foreach (var row in q)
            {
                string name = null;
                int pos = 0;
                string type = null;

                foreach (var part in row.Split(';'))
                {
                    var items = part.Split('=');
                    var n = items[0];
                    if (items.Length > 1)
                    {
                        var v = items[1];
                        switch (n)
                        {
                            case "Name":
                                name = v;
                                break;

                            case "ConstrainingClassifierName":
                                type = v;
                                break;

                            case "Pos":
                                int.TryParse(v, out pos);
                                break;

                            default:
                                break;

                        }
                    }
                }
                if (name != null)
                    ret.Add(new GenericType(name, pos, type));
            }
            return ret.OrderBy(p => p.Pos).ToArray();
        }
    }
}