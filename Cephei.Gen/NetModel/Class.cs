using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cephei.Gen.NetModel
{
    public class Class
    {
        public string Name;
        public string Guid;
        public int Id;
        public string Notes;
        public int? ParentID;
        public bool IsInterface;
        public bool IsAbstract;
        public bool IsEnum;
        public bool Empty = false;

        public List<Class> Children = new List<Class>();
        public Package Package;
        public Class BaseClass;
        public Class Parent;
        public List<Class> Interfaces;
        public List<string> ExternalInterfaces;
        public GenericType[] Templates;
        private List<Method> _Methods;

        public Class (EA.Gen.Model.IElement element, Package package)
        {
            Name = element.Name;
            Guid = element.GUID;
            Id = element.Id;
            IsEnum = element.ObjectType == "Enumeration";
            Notes = (element.Note != null ? element.Note.Replace('!', ' ') : "");

            StringBuilder sb = new StringBuilder();

            while (Notes != null && Notes.Contains("\\"))
            {
                var i = Notes.IndexOf("\\");
                if (i == Notes.Length)
                    Notes = Notes.Substring(0, i - 1);
                else if (i == 0)
                {
                    var s = Notes.IndexOf(" ");
                    if (s > 0)
                        Notes = Notes.Substring(s);
                    else
                        Notes = "";
                }
                else if (i > 0)
                {
                    var s = Notes.IndexOf(" ", i + 1);
                    if (s > 0)
                        Notes = Notes.Substring(0, i - 1) + Notes.Substring(s);
                    else
                        Notes = Notes.Substring(0, i - 1);
                }
            }
            Package = package;
            ParentID = element.ParentID;
            IsInterface = (element.ObjectType == "Interface" ? true : false);
            IsAbstract = (element.Abstract == "1" ? true : false);

            _Methods = Method.GetMethodsByClass(this);
            if (_Methods.Count == 0)
                Empty = true;

            Templates = GenericType.GetByClass(this);
            foreach (var a in Templates)
                for (int i = 0; i < a.Type.Length; i++)
                    if (a.Type[i] != null)
                        foreach (var c in Templates)
                            a.Type[i] = a.Type[i].Replace("<" + c.Name + ">", "<'" + c.Name + ">");
        }


        public void Link (Dictionary<int,Class> byid)
        {
            ExternalInterfaces = new List<string>();
            if (ParentID.HasValue)
            {
                Class c;
                if (byid.TryGetValue(ParentID.Value, out c))
                {
                    Parent = c;
                    c.Children.Add(this);
                }
            }

            foreach (var c in (from r in Context.Generalisation.Value
                               where r.StartElementId == Id
                               select r.EndElementId.Value).ToArray())
            {
                Class cls;
                if (byid.TryGetValue(c, out cls))
                {
                    BaseClass = cls;
                }
            }
            Interfaces = new List<Class>();
            foreach (var c in (from r in Context.Realisation.Value
                               where r.StartElementId == Id
                               select r.EndElementId.Value).ToArray())
            {
                Class cls;
                if (byid.TryGetValue(c, out cls))
                {
                    Interfaces.Add(cls);
                }
            }
            foreach (var m in _Methods)
                m.Link();
        }
        public IEnumerable<Method> Methods
        {
            get
            {
                foreach (var m in _Methods)
                    if (m.Name != Name && !m.Name.StartsWith("Operator"))
                        yield return m;
                if (BaseClass != null)
                {
                    var thisMethods = (from r in _Methods
                                       select r.Name).ToLookup(p => p);
                    foreach (var m in BaseClass.Methods)
                    {
                        if (!thisMethods.Contains(m.Name))
                            yield return m;
                    }
                }
            }
        }
        public IEnumerable<Method> MethodAndConstructors
        {
            get
            {
                foreach (var m in _Methods)
                    if (!m.Name.StartsWith("Operator"))
                        yield return m;
                if (BaseClass != null)
                {
                    var thisMethods = (from r in _Methods
                                       select r.Name).ToLookup(p => p);
                    foreach (var m in BaseClass.Methods)
                    {
                        if (!thisMethods.Contains(m.Name))
                            yield return m;
                    }
                }
            }
        }
        public IEnumerable<Method> DirectMethods
        {
            get
            {
                foreach (var m in _Methods)
                    if (m.Name != Name && !m.Name.StartsWith("Operator"))
                        yield return m;
            }
        }

        public Class FindByStack(Stack<string> q, bool fromPackage = false)
        {
            string save = null;
            if (q.Peek() == Name)
            {
                save = q.Pop();
                if (q.Count == 0)
                    return this;
                foreach (var c in Children)
                {
                    var r = c.FindByStack(q);
                    if (r != null)
                        return r;
                }
            }
            if (!fromPackage)
            {
                if (save != null)   
                    q.Push(save);
                return Package.FindByStack(q);
            }
            else
                return null;
        }

        public static Dictionary<string,Class> GetClassesByPackage (Package p)
        {
            var q = (from r in Context.Current.Value.DB.Elements
                     where r.Name != "arguments"
                        && r.Name != "results"
                        && r.Name != "engine"
                        && r.Name != "LazyObject"
                        && r.Name != "Cloneable"
                        && !r.Name.EndsWith("Impl")
                        && r.Name != "ObservableValue"
                        && r.Name != "InitializedList"
                        //                        && !r.Name.EndsWith("Helper")
                        && !r.Name.StartsWith("Make")
                        && r.PackageId == p.Id
//                        && r.ObjectType != "Enumeration"
                        && r.Scope == "Public"
                        && r.IsSpec == false
                     orderby r.Name
                     select r).ToArray();

            var s = (from r in q.ToLookup(n => n.Name)
                     where r.Count() > 0
                     select new Class(r.First(), p)).ToArray();

            return (from r in s
                    where !r.Empty
                    select r).ToDictionary(n => n.Name);
        }

        public static Stack<string> Parse (string source)
        {
            if (source != "void" && source != null)
            {
                string cls = null;
                foreach (var a in source.Split(new[] { '<', '>' }))
                    if (a != null && a != "")
                        cls = a;
                var q = new Stack<string>(cls.Split('.'));
                return q;
            }
            else
                return null; 
        }

        public string FSTemplate(int version)
        {
            if (Templates.Length == 0)
                return Name + "Model" + (version > 0 ? version.ToString() : "");

            var sb = new StringBuilder();
            string delim = "";

            foreach (var v in Templates)
            {
                sb.AppendFormat("{0}{1}", delim, v.FSName);
                delim = ", ";
            }

            delim = " when";
            foreach (var v in Templates)
            {
                sb.Append(v.FSType(ref delim));
            }
            return string.Format("{0}Model{1}<{2}>", Name, (version > 0 ? version.ToString() : ""), sb.ToString());
        }
        public string FSModelFun(int version)
        {
            if (Templates.Length == 0)
                return Name + "Model" + (version > 0 ? version.ToString() : "");

            var sb = new StringBuilder();
            string delim = "";

            foreach (var v in Templates)
            {
                sb.AppendFormat("{0}{1}", delim, v.FSName);
                delim = ", ";
            }

            return string.Format("{0}Model{1}<{2}>", Name, (version > 0 ? version.ToString() : ""), sb.ToString());
        }

        public string FSTypeName
        {
            get
            {
                if (Templates.Length == 0)
                    return Name;

                var sb = new StringBuilder();
                string delim = "";
                foreach (var v in Templates)
                {
                    sb.AppendFormat("{0}{1}", delim, v.FSName.Trim());
                    delim = ",";
                }
                return string.Format("{0}<{1}>", Name, sb.ToString()).Trim();
            }
        }

        private int? _depth;
        public int DependancyDepth(int recurse = 0)
        {
            if (recurse > 20)
                _depth = recurse;
            if (_depth.HasValue) return _depth.Value;

            int d = 0;
            if (BaseClass != null) d = BaseClass.DependancyDepth(recurse + 1) + 1;
            foreach (var c in Interfaces)
            {
                int e = c.DependancyDepth() + 1;
                if (e > d) d = e;
            }

            foreach (var v in Methods)
            {
                int e = v.DependancyDepth(recurse + 1) + 1;
                if (e > d) d = e;
            }
            _depth = (HasEngine ? d + 1 : d);
            return _depth.Value;
        }

        public IEnumerable<Method> Constructors
        {
            get 
            {
                bool missing = true;
                foreach(var m in _Methods)
                {
                    if (m.Name == Name)
                    {
                        missing = false;
                        yield return m;
                    }
                }
                if (missing)
                    yield return new Method(this);
            }
        }
        
        private bool? _hasEgnine;
        public bool HasEngine
        {
            get
            {
                if (_hasEgnine.HasValue) 
                    return _hasEgnine.Value;
                else
                {
                    foreach (var m in Methods)
                        if (m.HasEngine)
                        {
                            _hasEgnine = true;
                            return true;
                        }
                    if (BaseClass != null && BaseClass.HasEngine)
                    {
                        _hasEgnine = true;
                        return true;
                    }
                    _hasEgnine = false;
                    return false;
                }
            }
        }
        public string CellReference
        {
            get
            {
                if (HasEngine)
                    return "lock _FixedRateBond (fun () -> (withEvaluationDate _evaluationDate _" + Name + "))";
                else
                    return "_" + Name + ".Value";

            }
        }
    }
}
