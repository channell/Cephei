using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA.Gen.Model.Jet;
using M = EA.Gen.Model.Jet;


namespace Cephei.Gen.Model
{
    public class Package
    {
        public string Name;
        public int Id;
        public Package Parent;
        public EA.Gen.Model.Jet.Package _Package;
        public List<Package> Children;
        public Dictionary<string, Class> Classes;
        public Context Context;
        private bool _loaded = false;

        /// <summary>
        /// Enumerate over all the classes that should be generated
        /// </summary>
        public IEnumerable<Class> Content
        {
            get
            {
                string lastName = "";

                foreach (var pair in Classes)
                {
                    if (!pair.Value.Name.Contains("<") &&
                        pair.Value.Element.IsSpec &&
                        !pair.Value.IsSpec &&
                        pair.Value.Name != "arguments" &&
                        pair.Value.Name != "results" &&
                        !pair.Value.Name.StartsWith("base_cubic") &&
                        !pair.Value.Name.EndsWith("iterator") &&
                        !pair.Value.IsEnum &&
                        pair.Value.Name != lastName
                        )
                    {
                        lastName = pair.Value.Name;
                        yield return pair.Value;

                    }
                }
            }
        }

        public  Package(EA.Gen.Model.Jet.Package package, Package parent, Context context)
        {
            Name = package.Name;
            Id = package.Id;
            this._Package = package;
            Parent = parent;
            Children = new List<Package>();
            Classes = new Dictionary<string, Class>();
            Context = context;
        }

        public Package(string name)
        {
            Name = name;
            Children = new List<Package>();
        }
        public void Add(Package package)
        {
            package.Parent = this;
            Children.Add(package);
        }

        /// <summary>
        /// Depth first search of packages returning a iteratable list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Stack<Package> FindById(int id)
        {
            if (Id == id)
            {
                Stack<Package> s = new Stack<Package>();
                s.Push(this);
                return s;
            }
            foreach (var child in Children)
            {
                Stack<Package> items = child.FindById(id);
                if (items != null)
                {
                    items.Push(this);
                    return items;
                }
            }
            return null;
        }

        public Package GetById(int id)
        {
            if (Id == id)
            {
                return this;
            }
            foreach (var child in Children)
            {
                Package item = child.GetById(id);
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Find the package in the tree that has this name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Package FindByName(string name)
        {
            if (Name == name)
            {
                return this;
            }
            foreach (var child in Children)
            {
                Package item = child.FindByName(name);
                if (item != null)
                {
                    return item;
                }
            }
            return null;
        }

        public Package GetRoot()
        {
            if (Parent != null)
            {
                return Parent.GetRoot();
            }
            return this;
        }
        public Class FindClassByElement(Element element)
        {
            if (element.PackageId == this.Id)
            {
                if (Classes.ContainsKey(element.Name))
                    return Classes[element.Name];
                else
                    return null;
            }
            else
            {
                if (Children != null)
                {
                    foreach (var child in Children)
                    {
                        Class Class = child.FindClassByElement(element);
                        if (Class != null)
                        {
                            return Class;
                        }
                    }
                }
            }
            return null;
        }

        public List<Class> FindClassByName(string name)
        {
            List<Class> cset = new List<Class>();
            FindClassByName2(name, cset);
            return cset;
        }

        private void FindClassByName2(string name, List<Class> cSet)
        {
            string searchName = name;
            string remainderName = null;
            int i = name.IndexOf("::");
            if (i > 0)
            {
                searchName = name.Substring(0, i);
                remainderName = name.Substring(i + 2);
            }

            foreach (KeyValuePair<string, Class> pair in Classes)
            {
                if (pair.Value.Name == searchName)
                {
                    if (remainderName != null)
                    {
                        foreach (Class Class2 in pair.Value.Enums)
                        {
                            if (Class2.Name == remainderName)
                            {
                                cSet.Add(Class2);
                            }
                        }
                    }
                    else
                    {
                        cSet.Add(pair.Value);
                    }
                }
            }
            foreach (var package in Children)
            {
                if (package.Name == searchName)
                {
                    package.FindClassByName2(remainderName, cSet);
                }
                else
                {
                    package.FindClassByName2(name, cSet);
                }
            }
        }

        /// <summary>
        /// Fill the tree from the EA repository starting with the name specified
        /// </summary>
        /// <param name="name">the name of the root package</param>
        /// <param name="collection">the root node in the repository</param>
        public static Package CreateFromRepository(string name, IEnumerable<EA.Gen.Model.Jet.Package> collection, Context ctx)
        {
            foreach (var package in collection)
            {
                Package tree = CreateFromPackage(package, null, ctx);
                Package item = tree.FindByName(name);
                if (item != null)
                {
                    item.Parent = new Package("Cephei");
                    item.Parent.Children.Add(item);
                    return item;
                }
            }
            return null;
        }
        public static Package CreateFromPackage(M.Package package, Package parent, Context ctx)
        {
            Package item = new Package(package, parent, ctx);
            foreach (var child in package.Children)
            {
                item.Add(CreateFromPackage(child, item, ctx));
            }
            return item;
        }

        public void LoadAll(Context converter)
        {
            if (!_loaded)
            {
                Console.WriteLine(">> Loading classes from repository");
                LoadClasses(converter);
                Console.WriteLine(">> Linking classes from repository");
                LinkClasses(converter);
                TrimDuplicate();
                Console.WriteLine(">> Linking class hierarchy");
                LinkInheritance(converter);
            }
            _loaded = true;
        }

        public void LoadClasses(Context context)
        {
            Console.WriteLine("\t>> Loading classes for package " + this.Name + " from repositiory");
            foreach (var child in this.Children)
            {
                child.LoadClasses(context);
            }
            foreach (var element in this._Package.Elements)
            {
                if (element.ObjectType == "Class" &&
                    (element.Visibility == "Public" || element.Visibility == null) &&
                    (element.ParentID == 0 || element.Stereotype == "enumeration") &&
                    element.Name != "arguments" &&
                    element.Name != "results" &&
                    element.Name != "Point" &&
                    element.Stereotype != "typedef" &&
                    element.ObjectType != "Package" &&
                    !this.Classes.ContainsKey(element.Name)
                    )
                {
                    Class Class = new Class(element, this.GetRoot(), context);
                    Class.FilledFromRepository = true;
                    this.Classes[Class.Name] = Class;
                }
            }
        }

        public void LinkClasses(Context context)
        {
            Console.WriteLine("\t>> Linking classes for package " + this.Name);
            foreach (var child in this.Children)
            {
                child.LinkClasses(context);
            }
            foreach (KeyValuePair<string, Class> cpair in this.Classes)
            {
                foreach (Method method in cpair.Value.Methods)
                {
                    context.LinkCTSTypes(cpair.Value, method.ReturnType);

                    foreach (KeyValuePair<int, Parameter> pair in method.Parameters)
                    {
                        context.LinkCTSTypes(cpair.Value, pair.Value.ParameterType);
                        if (pair.Value.ParameterType.Class != null)
                        {
                            if (pair.Value.ParameterType.CollectionType == "Vector")
                            {
                                pair.Value.ParameterType.Class.HasVector = true;
                            }
                            else if (pair.Value.ParameterType.CollectionType == "Matrix")
                            {
                                pair.Value.ParameterType.Class.HasMatrix = true;
                            }
                            else if (pair.Value.ParameterType.CollectionType == "Cube")
                            {
                                pair.Value.ParameterType.Class.HasCube = true;
                            }
                        }
                    }
                }
            }
        }
        public void LinkInheritance(Context context)
        {
            Console.WriteLine("\t>> Linking inheritance for package " + this.Name);
            foreach (var child in this.Children)
            {
                child.LinkClasses(context);
            }
            foreach (KeyValuePair<string, Class> cpair in this.Classes)
            {
                List<Class> c = cpair.Value.BaseClasses;
            }
        }

        public string GetGlobalNameById(int id, string delimiter)
        {
            StringBuilder sb = new StringBuilder();
            Stack<Package> s = FindById(id);

            if (s == null) return "";

            string prefix = "";
            while (s.Count > 0)
            {
                sb.Append(prefix + s.Pop().UpperName);
                prefix = delimiter;
            }
            return sb.ToString();
        }
        public string GlobalName
        {
            get
            {
                if (Parent != null)
                    return Parent.GlobalName + "::" + UpperName;
                else
                    return Name;
            }
        }
        public void TrimDuplicate()
        {
            foreach (KeyValuePair<string, Class> cpair in Classes)
            {
                cpair.Value.TrimDuplicate();
            }
            if (Children != null)
            {
                foreach (var package in Children)
                {
                    package.TrimDuplicate();
                }
            }
        }
        public string UpperName
        {
            get
            {
                if (Name.Length > 1)
                {
                    return Name.Substring(0, 1).ToUpper() + Name.Substring(1);
                }
                else
                {
                    return Name.ToUpper();
                }
            }
        }
    }
}
