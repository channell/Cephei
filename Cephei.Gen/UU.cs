using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using EA;

namespace Cephei.Gen
{
    public class UU
    {
        const string FSharpOption = "Microsoft.FSharp.Core.FSharpOption<";
        //        const string FSharpOption = "Microsoft.FSharp.Core.Option<";

        public Element currentElement = null;
        public bool ownsRepository = true;
        public Repository currentRepository = null;

        public string TheConnectionString;       // values provided in template
        public string TheElementName;
        public string TheRootName;
        public string ThePrefix = "";            // "I" if we are generarting and interface file, otherwith ""
        public string TheSuffix = "";            // "^" if we are generarting C++/CLI, otherwith ""
        public string TheClassDelimiter = "";    // for C++/CLI this is "::" but for C# it is "."

        public void Init(string rootName, string elementName, string connectionString)
        {
            TheRootName = rootName;
            TheElementName = elementName;
            TheConnectionString = connectionString;
        }

        protected CTSTypeDictionary CTSTypeDict = new CTSTypeDictionary();
        protected static CTSKeyWordDictionary CTSKeyWord = new CTSKeyWordDictionary();

        [Browsable(false)]
        public Element CurrentElement
        {
            get
            {
                if (currentElement == null)
                {
                    //                    Console.WriteLine ("finding element " + TheElementName);

                    if (TheElementName == null) throw new ApplicationException("You must identify an element.");
                    EA.Collection collection = GetElementsByQuery("FindByName", TheElementName);
                    if (collection != null && collection.Count > 0)
                    {
                        foreach (EA.Element element in collection)
                        {
                            if (element.Type == "Class")
                            {
                                currentElement = element;
                                break;
                            }
                        }
                    }
                }
                if (currentElement == null)
                    throw new ApplicationException("You must identify an element.");
                return currentElement;
            }
            set
            {
                currentElement = value;
            }
        }

        [Browsable(false)]
        public Repository CurrentRepository
        {
            get
            {
                if (currentRepository == null)
                {
                    if (TheConnectionString != null)
                    {
                        currentRepository = new Repository();
                        currentRepository.OpenFile(TheConnectionString);
                        Console.WriteLine("opened repository " + TheConnectionString);
                    }
                    else
                    {
                        //                       Console.WriteLine ("not opening [null] repository");
                    }
                }
                if (currentRepository == null)
                    throw new ApplicationException("Unable to open repository");
                return currentRepository;
            }
            set
            {
                currentRepository = value;
            }
        }

        [Browsable(false)]
        public bool OwnsRepository
        {
            get { return ownsRepository; }
            set { ownsRepository = value; }
        }

        public class CTSType
        {
            public enum FeatureType
            {
                Enum,
                Value,
                Object
            }

            public enum CallingType
            {
                BoostReference,
                HandleReference,
                Reference,
                Pointer,
                Value
            }

            public string Value;
            public string Source;

            public bool IsEnum
            {
                get
                {
                    return Feature == FeatureType.Enum;
                }
            }

            public string CollectionType;               // used to allow name decoration within collection
            public FeatureType Feature;
            public CallingType Calling;
            public CClass Class;
            public bool isOptional;

            public CTSType(string value, string source, FeatureType feature, CallingType calling, string collectionType, bool optional)
            {
                Value = value;
                Source = source;
                Feature = feature;
                Calling = calling;
                Class = null;
                CollectionType = collectionType;
                isOptional = optional;
            }

            public string ShowType
            {
                get
                {
                    if (CollectionType == null || CollectionType == "")
                        return Feature.ToString();
                    else
                        return CollectionType;
                }
            }

            public string GetQualifiedType(bool hasDefault, string namespaceDelimiter, string prefix, string suffix)
            {
                if (Class == null || Class.Package == null)
                {
                    string val = (Value == "String" ? "String" + suffix : Value);

                    val = (CollectionType != "" ? "Cephei" + namespaceDelimiter + "Core" + namespaceDelimiter + prefix + CollectionType + "<" + val + ">" + suffix : val);
                    return (isOptional || hasDefault ? FSharpOption.Replace(".", namespaceDelimiter) + val + ">" + suffix : val);
                }

                CPackage package = Class.Package;
                string qualifiedName = package.UpperName + namespaceDelimiter + (Feature == FeatureType.Object ? prefix : "") + Value + (Feature == FeatureType.Object ? suffix : "");
                while ((package = package.Parent) != null)
                {
                    qualifiedName = package.UpperName + namespaceDelimiter + qualifiedName;
                }
                qualifiedName = (CollectionType != "" ? "Cephei" + namespaceDelimiter + "Core" + namespaceDelimiter + prefix + CollectionType + "<" + qualifiedName + ">" + suffix : qualifiedName);
                if (hasDefault && !isOptional)
                    qualifiedName = FSharpOption.Replace(".", namespaceDelimiter) + qualifiedName + ">" + suffix;
                return qualifiedName;
            }
            public string GetQualifiedTypeWithoutCollection(bool hasDefault, string namespaceDelimiter, string prefix, string suffix)
            {
                if (Class == null || Class.Package == null)
                {
                    string val = (Value == "String" ? "String" + suffix : Value);

                    return (isOptional || hasDefault ? FSharpOption.Replace(".", namespaceDelimiter) + val + ">" + suffix : val);
                }

                CPackage package = Class.Package;
                string qualifiedName = package.UpperName + namespaceDelimiter + (Feature == FeatureType.Object ? prefix : "") + Value + (Feature == FeatureType.Object ? suffix : "");
                while ((package = package.Parent) != null)
                {
                    qualifiedName = package.UpperName + namespaceDelimiter + qualifiedName;
                }
                if (hasDefault && !isOptional)
                    qualifiedName = FSharpOption.Replace(".", namespaceDelimiter) + qualifiedName + ">" + suffix;
                return qualifiedName;
            }
            public string GetQualifiedTypeWithoutOption(bool hasDefault, string namespaceDelimiter, string prefix, string suffix)
            {
                if (Class == null || Class.Package == null)
                {
                    string val = (Value == "String" ? "String" + suffix : Value.Replace("::", namespaceDelimiter));

                    val = (CollectionType != "" ? "Cephei" + namespaceDelimiter + "Core" + namespaceDelimiter + prefix + CollectionType + "<" + val + ">" + suffix : val);
                    return val;
                }

                CPackage package = Class.Package;
                string qualifiedName = package.UpperName + namespaceDelimiter + (Feature == FeatureType.Object ? prefix : "") + Value + (Feature == FeatureType.Object ? suffix : "");
                while ((package = package.Parent) != null)
                {
                    qualifiedName = package.UpperName + namespaceDelimiter + qualifiedName;
                }
                qualifiedName = (CollectionType != "" ? "Cephei" + namespaceDelimiter + "Core" + namespaceDelimiter + prefix + CollectionType + "<" + qualifiedName + ">" + suffix : qualifiedName);
                return qualifiedName;
            }

            public string GetCppType(string ContainerPrefix, string prefix)
            {
                if (Class == null || Class.Package == null)
                {
                    string val = (Value == "String" ? "String^" : Value);
                    return (CollectionType != "" ? ContainerPrefix + CollectionType + "<" + val + ">" : val);
                }

                CPackage package = Class.Package;
                string qualifiedName = package.UpperName + "::" + (Feature == FeatureType.Object ? prefix : "") + Value + (Feature == FeatureType.Object ? "^" : "");
                while ((package = package.Parent) != null)
                {
                    qualifiedName = package.UpperName + "::" + qualifiedName;
                }

                return (CollectionType != "" ? ContainerPrefix + CollectionType + "<" + qualifiedName + ">" : qualifiedName);
            }

            public string GetQualifiedSource(string theNamespace)
            {
                if (Feature == FeatureType.Value)
                {
                    if (this.CollectionType == "")
                        return Source.Replace("&", "");

                    return Source;
                }
                else if (Feature == FeatureType.Object)
                    return Source.Replace(Value, theNamespace + Value);
                else
                {
                    return theNamespace + Source;
                }
            }

            public string CollectionCallingFunction
            {
                get
                {
                    string refFunc;
                    switch (Calling)
                    {
                        case CTSType.CallingType.Reference:
                            refFunc = "GetReference ()";
                            break;

                        case CTSType.CallingType.BoostReference:
                            refFunc = "GetShared ()";
                            break;

                        case CTSType.CallingType.Pointer:
                            refFunc = "GetPointer ()";
                            break;

                        case CTSType.CallingType.HandleReference:
                            refFunc = "GetHandle ()";
                            break;

                        default:
                            refFunc = "GetReference ()";
                            break;
                    }
                    return refFunc;
                }
            }

            public string CollectionFeature
            {
                get
                {
                    string feature;
                    switch (Calling)
                    {
                        case CTSType.CallingType.Reference:
                            feature = "NativeFeature::Value";
                            break;

                        case CTSType.CallingType.BoostReference:
                            feature = "NativeFeature::shared_ptr";
                            break;

                        case CTSType.CallingType.Pointer:
                            feature = "NativeFeature::Value";
                            break;

                        case CTSType.CallingType.HandleReference:
                            feature = "NativeFeature::Handle";
                            break;

                        default:
                            feature = "NativeFeature::Value";
                            break;
                    }
                    return feature;
                }
            }
        }

        public CTSType GetCTSType(string inp, EA.Element element)
        {
            const string CUBE = "std::vector<std::vector<std::vector<";
            const string MATRIX = "std::vector<std::vector<";
            const string VECTOR = "std::vector<";

            CTSType.CallingType callingType;

            string collectionType = "";
            bool isOptional = false;

            // convert traditional C++ to C++/CLI
            string buff = inp.Replace("\n", "").Replace("> > >", ">>>").Replace("> >", ">>").Replace(" const", "").Replace("const ", "").Replace(" ", "");

            // strip reference and pointer typs
            if (buff.Contains("boost::shared_ptr"))
            {
                if (buff.EndsWith("&")) buff = buff.Substring(0, buff.Length - 1);
                buff = StripType(buff, "boost::shared_ptr");
                callingType = CTSType.CallingType.BoostReference;
            }
            else if (buff.EndsWith("&") && buff.Contains("Handle"))
            {
                buff = StripType(buff.Substring(0, buff.Length - 1), "Handle");
                callingType = CTSType.CallingType.HandleReference;
            }
            else if (buff.EndsWith("&"))
            {
                buff = buff.Substring(0, buff.Length - 1);
                callingType = CTSType.CallingType.Reference;
            }
            else if (buff.EndsWith("*"))
            {
                buff = buff.Substring(0, buff.Length - 1);
                callingType = CTSType.CallingType.Pointer;
            }
            else if (buff.Contains("boost::optional"))
            {
                buff = StripType(buff, "boost::optional");
                callingType = CTSType.CallingType.Value;
                isOptional = true;
            }
            else
            {
                callingType = CTSType.CallingType.Value;

            }

            buff = StripType(StripType(buff, "Handle"), "boost::shared_ptr").Replace("enum ", "").Replace("\n", "").Replace("\t", "");

            if (buff.StartsWith(CUBE))
            {
                buff = inp.Substring(CUBE.Length, buff.Length - CUBE.Length - 3);
                collectionType = "Cube";
            }
            else if (buff.StartsWith(MATRIX))
            {
                buff = inp.Substring(MATRIX.Length, buff.Length - MATRIX.Length - 2);
                collectionType = "Matrix";
            }
            else if (buff.StartsWith(VECTOR))
            {
                buff = buff.Substring(VECTOR.Length, buff.Length - VECTOR.Length - 1);
                collectionType = "Vector";
            }

            // strip any contained boost pointer
            buff = StripType(StripType(StripType(buff, "std::boost::shared_ptr"), "Handle"), "boost::shared_ptr");

            // if the inner object is a simple value type
            string ctsBuff = CTSTypeDict[buff];
            if (ctsBuff != buff)
            {
                return new CTSType(ctsBuff, inp.Replace(buff, CTSTypeDict.GetNative(buff)), CTSType.FeatureType.Value, callingType, collectionType, isOptional);
            }
            else
            {
                TypeLookup.Item i = EnumDefs.FindType(buff, element.Genfile, element.ElementID, element.ParentID, element.PackageID);
                if (i != null)
                {
                    return new CTSType(i.Definition, i.NativeDefinition, CTSType.FeatureType.Enum, callingType, collectionType, isOptional);
                }
                else
                {
                    TypeLookup.Item lookup = GetCTSTypdef(buff, element);
                    if (lookup != null)
                    {
                        string new_inp = inp.Replace(lookup.Name, lookup.NativeDefinition);
                        return GetCTSType(new_inp, element);
                    }
                    return new CTSType(buff, inp, CTSType.FeatureType.Object, callingType, collectionType, isOptional);
                }
            }
        }

        protected string StripType(string inp, string text)
        {
            if (inp.StartsWith(text))
            {
                return inp.Substring(text.Length + 1, inp.Length - text.Length - 2);
            }
            return inp;
        }

        string StripToType(string inp)
        {
            const string CUBE = "std::vector<std::vector<std::vector<";
            const string MATRIX = "std::vector<std::vector<";
            const string VECTOR = "std::vector<";

            string buff = inp.Replace("\n", "").Replace("> > >", ">>>").Replace("> >", ">>");
            if (buff.EndsWith("&") || buff.EndsWith("*"))
            {
                buff = buff.Substring(0, buff.Length - 1);
            }
            buff = StripType(StripType(StripType(StripType(StripType(StripType(buff, "std::boost::shared_ptr"), "Handle"), "boost::shared_ptr"), CUBE), MATRIX), VECTOR);

            return buff;
        }
        protected string NativeName(string inp)
        {
            if (inp.EndsWith("&") || inp.EndsWith("*"))
            {
                return inp.Substring(0, inp.Length - 1);
            }
            return inp;
        }

        protected bool Included(CMethod method)
        {
            if (method.ReturnType == null || !Included(method.ReturnType.Value)) return false;

            foreach (KeyValuePair<int, CParameter> pair in method.Parameters)
            {
                if (!Included(pair.Value.ParameterType.Value))
                {
                    Console.WriteLine("! excluded method " + method.Name + " because of " + pair.Value.ParameterType.Value);
                    return false;
                }
            }

            return true;
        }
        protected bool Included(string name)
        {
            if (name.StartsWith("std::map")
                || name.StartsWith("std::ostream")
                || name == "T"
                || name.Contains("arguments")
                //                || name.Contains ("engine")
                || name.StartsWith("boost")
                || name.StartsWith("Disposable<")
                || name.EndsWith("iterator")
                || name.EndsWith("con.iterato")      // special case of Schedule.. just to tired to fully investigate
                || name == "Price::Type"
               )
            {
                return false;
            }
            {
                return true;
            }
        }
        /// <summary>
        /// strict parsing of referenced class.  Exclude if any of the parameters have not been parsed to classes in the dictionary
        /// </summary>
        /// <param name="method">the CMethod within the CClass that we're checking</param>
        /// <param name="Constructor">ignore missing rweturn types for constructores</param>
        /// <returns>true if all parameters are mapped or values</returns>
        public bool Included2(CMethod method, bool Constructor)
        {
            if (!Constructor && (method.ReturnType == null ||
                                 ((method.ReturnType.Class == null ||
                                   method.ReturnType.Class.IsSpec) && method.ReturnType.Feature == CTSType.FeatureType.Object && method.ReturnType.Source != "void")) ||
                                   method.Name == "finalize"
               )
            {
                return false;
            }

            bool redoParameters = false;
            foreach (KeyValuePair<int, CParameter> pair in method.Parameters)
            {
                if ((pair.Value.ParameterType.Class == null || pair.Value.ParameterType.Class.IsSpec) && pair.Value.ParameterType.Feature == CTSType.FeatureType.Object
                   )
                {
                    if (!(pair.Value.Default == null || pair.Value.Default == ""))
                        redoParameters = true;
                    else
                        return false;
                }
            }
            if (redoParameters) method.TrimParameters();
            return Included(method);
        }

        public string GetGeneralisation(CClass cls, string prefix, bool cpp)
        {
            string parents = "";
            string seper = ": ";

            foreach (CClass cclass in cls.AllBaseClasses)
            {
                if (!cclass.IsSpec)
                {
                    parents += seper + (cpp ? "public " : "") + cclass.Package.GlobalName + "::" + prefix + cclass.Name;
                    seper = ", ";
                }
            }
            return parents;
        }

        public string Comment(string source, string tabs)
        {
            if (source == null || source == "" || tabs == null) return "/// <summary> \n" + tabs + "/// " + "\n" + tabs + "/// </summary>";
            return "/// <summary> \n" + tabs + "/// " + source.Replace("\n", "\n" + tabs + "/// ") + "\n" + tabs + "/// </summary>";
        }

        public string GetPackageNameById(EA.Collection collection, int id, string delim, string topPackage)
        {
            return GetPackageNameById(collection, id, delim, topPackage, false);
        }
        private string GetPackageNameById(EA.Collection collection, int id, string delim, string topPackage, bool withinTop)
        {
            foreach (var package in collection)
            {
                if (package.PackageID == id)
                {
                    return package.Name;
                }

                string finder = GetPackageNameById(package.Children, id, delim, topPackage, (withinTop || package.Name == topPackage));
                if (finder != null)
                {
                    if (package.Name == topPackage || !withinTop)
                        return finder;
                    return package.Name + delim + finder;
                }
            }
            return null;
        }

        protected class CTSTypeDictionary
        {
            private Dictionary<string, string> _dictionary;
            private Dictionary<string, string> _nativeDictionary;

            public CTSTypeDictionary()
            {
                string[,] src = { {"QL_INTEGER",      "Int32"},
                                    {"QL_BIG_INTEGER",  "Int64"},
                                    {"QL_REAL",         "Double"},
                                    {"Decimal",         "Double"},
                                    {"Time",            "Double"},
                                    {"DiscountFactor",  "Double"},
                                    {"Rate",            "Double"},
                                    {"Spread",          "Double"},
                                    {"Volatility",      "Double"},
                                    {"Real",            "Double"},
                                    {"Integer",         "Int32"},
                                    {"int",             "Int32"},
                                    {"BigInteger",      "Int64"},
                                    {"unsigned long",   "UInt64"},
                                    {"Date",            "DateTime"},
                                    {"Size",            "UInt64"},
                                    {"Natural",         "UInt32"},
                                    {"BigNatural",      "UInt64"},
                                    {"bool",            "Boolean"},
                                    {"double",          "Double"},
                                    {"std::string",     "String"},
                                    {"Probability",     "Double"}
                                 };

                string[,] nativesrc = { {"QL_INTEGER",  "QuantLib::QL_INTEGER"},
                                    {"QL_BIG_INTEGER",  "QuantLib::QL_BIG_INTEGER"},
                                    {"QL_REAL",         "QuantLib::QL_REAL"},
                                    {"Decimal",         "QuantLib::Decimal"},
                                    {"Time",            "QuantLib::Time"},
                                    {"DiscountFactor",  "QuantLib::DiscountFactor"},
                                    {"Rate",            "QuantLib::Rate"},
                                    {"Spread",          "QuantLib::Spread"},
                                    {"Volatility",      "QuantLib::Volatility"},
                                    {"Real",            "QuantLib::Real"},
                                    {"Integer",         "QuantLib::Integer"},
                                    {"int",             "int"},
                                    {"BigInteger",      "QuantLib::BigInteger"},
                                    {"unsigned long",   "unsigned long"},
                                    {"Date",            "QuantLib::Date"},
                                    {"Size",            "QuantLib::Size"},
                                    {"Natural",         "QuantLib::Natural"},
                                    {"BigNatural",      "QuantLib::BigNatural"},
                                    {"bool",            "bool"},
                                    {"double",          "double"},
                                    {"std::string",     "std::string"},
                                    {"Probability",     "QuantLib::Probability"}
                                 };

                _dictionary = new Dictionary<string, string>();
                _nativeDictionary = new Dictionary<string, string>();

                for (int c = 0; c < src.GetLength(0); c++)
                {
                    _dictionary.Add(src[c, 0], src[c, 1]);
                    _nativeDictionary.Add(nativesrc[c, 0], nativesrc[c, 1]);
                }

            }
            public string this[string key]
            {
                get
                {
                    if (_dictionary.ContainsKey(key))
                        return _dictionary[key];
                    return key;
                }
            }
            public string GetNative(string key)
            {
                if (_nativeDictionary.ContainsKey(key))
                    return _nativeDictionary[key];
                return key;
            }
        }

        protected class CTSKeyWordDictionary
        {
            private Dictionary<string, string> _dictionary;

            public CTSKeyWordDictionary()
            {
                string[,] src = {   {"in",      "p_in"},
                                    {"params",  "p_params"},
                                 };

                _dictionary = new Dictionary<string, string>();

                for (int c = 0; c < src.GetLength(0); c++)
                {
                    _dictionary.Add(src[c, 0], src[c, 1]);
                }

            }
            public string this[string key]
            {
                get
                {
                    if (_dictionary.ContainsKey(key))
                        return _dictionary[key];
                    return key;
                }
            }
        }


        #region Package handling 

        ///////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        public class CPackage
        {
            public string Name;
            public int Id;
            public CPackage Parent;
            public Package Package;
            public List<CPackage> Children;
            public Dictionary<string, CClass> Classes;

            public CPackage(Package package, CPackage parent)
            {
                Name = package.Name;
                Id = package.PackageID;
                this.Package = package;
                Parent = parent;
                Children = new List<CPackage>();
                Classes = new Dictionary<string, CClass>();
            }

            public CPackage(string name)
            {
                Name = name;
                Children = new List<CPackage>();
            }
            public void Add(CPackage package)
            {
                package.Parent = this;
                Children.Add(package);
            }

            /// <summary>
            /// Depth first search of packages returning a iteratable list
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public Stack<CPackage> FindById(int id)
            {
                if (Id == id)
                {
                    Stack<CPackage> s = new Stack<CPackage>();
                    s.Push(this);
                    return s;
                }
                foreach (CPackage child in Children)
                {
                    Stack<CPackage> items = child.FindById(id);
                    if (items != null)
                    {
                        items.Push(this);
                        return items;
                    }
                }
                return null;
            }

            public CPackage GetById(int id)
            {
                if (Id == id)
                {
                    return this;
                }
                foreach (CPackage child in Children)
                {
                    CPackage item = child.GetById(id);
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
            public CPackage FindByName(string name)
            {
                if (Name == name)
                {
                    return this;
                }
                foreach (CPackage child in Children)
                {
                    CPackage item = child.FindByName(name);
                    if (item != null)
                    {
                        return item;
                    }
                }
                return null;
            }

            public CPackage GetRoot()
            {
                if (Parent != null)
                {
                    return Parent.GetRoot();
                }
                return this;
            }
            public CClass FindClassByElement(EA.Element element)
            {
                if (element.PackageID == this.Id)
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
                        foreach (CPackage child in Children)
                        {
                            CClass cclass = child.FindClassByElement(element);
                            if (cclass != null)
                            {
                                return cclass;
                            }
                        }
                    }
                }
                return null;
            }

            public List<CClass> FindClassByName(string name)
            {
                List<CClass> cset = new List<CClass>();
                FindClassByName2(name, cset);
                return cset;
            }

            private void FindClassByName2(string name, List<CClass> cSet)
            {
                string searchName = name;
                string remainderName = null;
                int i = name.IndexOf("::");
                if (i > 0)
                {
                    searchName = name.Substring(0, i);
                    remainderName = name.Substring(i + 2);
                }

                foreach (KeyValuePair<string, CClass> pair in Classes)
                {
                    if (pair.Value.Name == searchName)
                    {
                        if (remainderName != null)
                        {
                            foreach (CClass cClass2 in pair.Value.Enums)
                            {
                                if (cClass2.Name == remainderName)
                                {
                                    cSet.Add(cClass2);
                                }
                            }
                        }
                        else
                        {
                            cSet.Add(pair.Value);
                        }
                    }
                }
                foreach (CPackage package in Children)
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
            public static CPackage CreateFromRepository(string name, EA.Collection collection)
            {
                foreach (var package in collection)
                {
                    CPackage tree = CreateFromPackage(package, null);
                    CPackage item = tree.FindByName(name);
                    if (item != null)
                    {
                        item.Parent = new CPackage("Cephei");
                        item.Parent.Children.Add(item);
                        return item;
                    }
                }
                return null;
            }
            public static CPackage CreateFromPackage(Package package, CPackage parent)
            {
                CPackage item = new CPackage(package, parent);
                foreach (var child in package.Children)
                {
                    item.Add(CreateFromPackage(child, item));
                }
                return item;
            }

            public void LoadAll(UU converter)
            {
                Console.WriteLine(">> Loading classes from repository");
                LoadClasses(converter);
                Console.WriteLine(">> Linking classes from repository");
                LinkClasses(converter);
                TrimDuplicate();
                Console.WriteLine(">> Linking class hierarchy");
                LinkInheritance(converter);
            }

            public void LoadClasses(UU converter)
            {
                Console.WriteLine("\t>> Loading classes for package " + this.Name + " from repositiory");
                foreach (CPackage child in this.Children)
                {
                    child.LoadClasses(converter);
                }
                foreach (EA.Element element in this.Package.Elements)
                {
                    if (element.Type == "Class" &&
                        element.Visibility == "Public" &&
                        //                        element.Abstract == "0" &&
                        (element.ParentID == 0 || element.Stereotype == "enumeration") &&
                        //                        element.Name != "engine" &&
                        element.Name != "arguments" &&
                        element.Name != "results" &&
                        element.Name != "Point" &&
                        element.Stereotype != "typedef" &&
                        element.Type != "Package" &&
                        !this.Classes.ContainsKey(element.Name)
                        )
                    {
                        CClass cclass = new CClass(element, this.GetRoot(), converter);
                        cclass.FilledFromRepository = true;
                        this.Classes[cclass.Name] = cclass;
                    }
                }
            }

            public void LinkClasses(UU converter)
            {
                Console.WriteLine("\t>> Linking classes for package " + this.Name);
                foreach (CPackage child in this.Children)
                {
                    child.LinkClasses(converter);
                }
                foreach (KeyValuePair<string, CClass> cpair in this.Classes)
                {
                    foreach (CMethod method in cpair.Value.Methods)
                    {
                        converter.LinkCTSTypes(cpair.Value, method.ReturnType);

                        foreach (KeyValuePair<int, CParameter> pair in method.Parameters)
                        {
                            converter.LinkCTSTypes(cpair.Value, pair.Value.ParameterType);
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
            public void LinkInheritance(UU converter)
            {
                Console.WriteLine("\t>> Linking inheritance for package " + this.Name);
                foreach (CPackage child in this.Children)
                {
                    child.LinkClasses(converter);
                }
                foreach (KeyValuePair<string, CClass> cpair in this.Classes)
                {
                    List<CClass> c = cpair.Value.BaseClasses;
                }
            }

            public string GetGlobalNameById(int id, string delimiter)
            {
                StringBuilder sb = new StringBuilder();
                Stack<CPackage> s = FindById(id);

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
                foreach (KeyValuePair<string, CClass> cpair in Classes)
                {
                    cpair.Value.TrimDuplicate();
                }
                if (Children != null)
                {
                    foreach (CPackage package in Children)
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

        private CPackage _RootTree = null;
        [Browsable(false)]
        public CPackage RootTree
        {
            get
            {
                if (_RootTree == null)
                {
                    //                    Debugger.Break ();
                    Console.WriteLine("** getting packages from repository **");
                    _RootTree = CPackage.CreateFromRepository(TheRootName, CurrentRepository.Models);
                }
                return _RootTree;
            }
            set
            {
                _RootTree = value;
            }
        }

        #endregion 

        #region Class Handling

        private CClass _currentClass = null;
        [Browsable(false)]
        public CClass CurrentClass
        {
            get
            {
                if (_currentClass == null)
                {
                    _currentClass = new CClass(CurrentElement, RootTree, this);

                    EA.Collection collection = GetElementsByQuery("FindChildEnumeration", CurrentElement.ElementID.ToString());
                    if (collection != null)
                    {
                        foreach (EA.Element element in collection)
                        {
                            CPackage package = RootTree.GetById(element.PackageID);
                            if (!package.Classes.ContainsKey(element.Name))
                                package.Classes[element.Name] = new CClass(element, RootTree, this);
                        }
                    }
                    foreach (CMethod method in _currentClass.Methods)
                    {
                        this.LinkCTSTypes(_currentClass, method.ReturnType);

                        foreach (KeyValuePair<int, CParameter> pair in method.Parameters)
                        {
                            this.LinkCTSTypes(_currentClass, pair.Value.ParameterType);
                        }
                    }

                }
                return _currentClass;
            }
            set
            {
                _currentClass = value;
            }
        }

        public class CClass
        {
            public string Name;
            public string Guid;
            public int Id;
            public string Notes;
            public string FileName;           // used to map derived names back to element
            public CPackage Package;
            public bool FilledFromRepository;   // has the instances of this name been filled from the repository
            public EA.Element Element;
            public int ParentID;
            public bool IsSpec = false;         // do not generate this item
            public bool HasVector = false;      // is it referenced by a vector
            public bool HasMatrix = false;      // is it referenced by a vector of vectors
            public bool HasCube = false;        // is it referenced by a vector of vectors of vectors
            public bool? _IsAbstract;
            public bool IsEnum;
            public bool _IsStruct;
            public bool _IsImpliedStructChecked = false;
            public bool _IsActive;

            public List<CMethod> Methods = new List<CMethod>();
            public SortedList<int, CAttribute> Attributes = new SortedList<int, CAttribute>();
            private List<CClass> _Enums = null;
            private List<CClass> _BaseClasses = null;
            public List<CClass> _knownTypes = new List<CClass>();
            public List<CTSType> References = new List<CTSType>();
            private List<string> _Collections = null;

            public CClass(EA.Element element, CPackage root, UU converter)
            {
                Name = element.Name;
                Notes = element.Notes;
                Guid = element.ElementGUID;
                Id = element.ElementID;
                FileName = element.Genfile;
                Package = (root == null ? null : root.GetById(element.PackageID));
                FilledFromRepository = false;
                Element = element;
                // Convert nested classes and template classes to spec classes
                IsSpec = (element.IsSpec || element.Subtype == 1 || element.Name.Contains("<") || element.ParentID != 0 || element.Name == "engine");
                ParentID = (element.Stereotype == "enumeration" ? element.ParentID : 0);
                if (element.Abstract == "1") _IsAbstract = true;
                IsEnum = (element.Stereotype == "enumeration");
                _IsStruct = (element.Stereotype == "struct");
                _IsActive = element.IsActive;    // used to flag QuantLib classes that rely on evaluation date
                if (!IsEnum)
                {
                    foreach (EA.Method method in element.Methods)
                    {
                        if (method.Visibility.ToLower() == "public" && !method.IsSynchronized)
                        {
                            Methods.Add(new CMethod(method, converter, element, this));
                        }
                    }
                }
                else
                {
                    foreach (EA.Attribute Attribute in element.Attributes)
                    {
                        Attributes.Add(Attribute.Pos, new CAttribute(Attribute.Name, Attribute.Default, Attribute.Pos));
                    }
                }
                _BaseClasses = new List<CClass>();
                foreach (EA.Element be in Element.BaseClasses)
                {
                    CClass cclass = root.FindClassByElement(be);
                    if (cclass != null)
                    {
                        _BaseClasses.Add(cclass);
                    }
                    else if (be.ParentID == 0              // no nested classes
                                                           //                            && be.Subtype != 1             // no parameterised interfaces
                            && be.Stereotype != "typedef"  // in this context all typedefs are templates.. so exlcude
                                                           //                            && !be.Name.Contains ("<")
                                                           //                            && be.Name != "engine"
                            && be.Name != "arguments"
                            && be.Name != "results"
                            && be.Name != "Point"
                            )
                    {
                        try
                        {
                            cclass = new CClass(be, root, converter);
                            cclass.Package.Classes[cclass.Name] = cclass;
                            _BaseClasses.Add(cclass);

                            foreach (CMethod method in cclass.Methods)
                            {
                                converter.LinkCTSTypes(cclass, method.ReturnType);

                                foreach (KeyValuePair<int, CParameter> pair in method.Parameters)
                                {
                                    converter.LinkCTSTypes(cclass, pair.Value.ParameterType);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Debugger.Break();
                        }
                    }
                }
            }

            public List<CClass> BaseClasses
            {
                get
                {
                    if (_BaseClasses == null)
                    {
                        CPackage root = Package.GetRoot();
                        _BaseClasses = new List<CClass>();
                        foreach (EA.Element element in Element.BaseClasses)
                        {
                            CClass cclass = root.FindClassByElement(element);
                            if (cclass != null)
                            {
                                _BaseClasses.Add(cclass);
                                cclass._knownTypes.Add(this);
                            }
                            else if (!element.IsSpec                  // explicitly excluded
                                                                      //                                    && element.ParentID == 0            // no nested classes
                                    && element.Stereotype != "typedef"  // in this context all typedefs are templates.. so exlcude
                                                                        //                                    && element.Name != "engine" 
                                    && element.Name != "arguments"
                                    && element.Name != "results"
                                    && element.Name != "Point"
                                    )
                            {
                                cclass = new CClass(element, root);
                                cclass.Package.Classes[cclass.Name] = cclass;
                                _BaseClasses.Add(cclass);
                            }
                        }
                    }
                    return _BaseClasses;
                }
            }

            //
            // return all the base clases, except for spec classes, where we return any non-spec bases of the spec
            // 
            public IEnumerable<CClass> AllBaseClasses
            {
                get
                {
                    foreach (CClass c in BaseClasses)
                    {
                        if (!c.IsSpec)
                        {
                            yield return c;
                        }
                        else
                        {
                            foreach (CClass c2 in c.AllBaseClasses)
                            {
                                yield return c2;
                            }
                        }

                    }
                }
            }
            public IEnumerable<CClass> AllClassCasts
            {
                get
                {
                    foreach (CClass c in AllBaseClasses)
                    {
                        yield return c;
                    }
                    foreach (CClass c in AllBaseClasses)
                    {
                        foreach (CClass c2 in c.AllClassCasts)
                        {
                            yield return c2;
                        }
                    }
                }
            }
            public IEnumerable<CClass> AllClassDownCasts
            {
                get
                {
                    foreach (CClass c in AllBaseClasses)
                    {
                        yield return c;
                    }
                    foreach (CClass c in AllBaseClasses)
                    {
                        foreach (CClass c2 in c.AllClassCasts)
                        {
                            yield return c2;
                        }
                    }
                }
            }
            public bool hasConcreteBase
            {
                get
                {
                    if (IsSpec)
                    {
                        foreach (CClass c in BaseClasses)
                        {
                            if (c.hasConcreteBase)
                                return true;
                        }
                        return false;
                    }
                    return true;
                }
            }


            public List<CClass> OverrideBaseClasses
            {
                get
                {
                    int bases = 0;
                    int specbases = 0;
                    foreach (CClass c in BaseClasses)
                    {
                        if (c.IsSpec && c.hasConcreteBase)
                            specbases++;
                        else
                            bases++;
                    }
                    if (bases > 1 || specbases > 0 || IsSpec)
                    {
                        return new List<CClass>(OverrideBaseClasses2);
                    }
                    else return new List<CClass>();
                }
            }

            public IEnumerable<CClass> OverrideBaseClasses2
            {
                get
                {
                    foreach (CClass cls in BaseClasses)
                    {
                        if (!cls.IsSpec)
                            yield return cls;
                        foreach (CClass c in cls.OverrideBaseClasses2)
                            yield return c;
                    }
                }
            }

            private CClass _ParentClass = null;
            public CClass ParentClass
            {
                get
                {
                    if (_ParentClass == null)
                    {
                        foreach (CClass cclass in BaseClasses)
                        {
                            if (!cclass.IsSpec)
                            {
                                _ParentClass = cclass;
                                break;
                            }
                        }
                        if (_ParentClass == null)
                        {
                            foreach (CClass cclass in AllBaseClasses)
                            {
                                if (!cclass.IsSpec)
                                {
                                    _ParentClass = cclass;
                                    break;
                                }
                            }
                        }
                    }
                    return _ParentClass;
                }
            }

            private List<CClass> _Aggregates = null;
            /// <summary>
            /// Aggregate classes that can not be inherited because of multiple inheritance, and are accessed via a contained object instead
            /// </summary>
            public List<CClass> Aggregates
            {
                get
                {
                    if (_Aggregates == null)
                    {
                        _Aggregates = new List<CClass>();
                        foreach (CClass c in AllBaseClasses)
                        {
                            if (c != ParentClass)
                            {
                                bool dupe = false;
                                foreach (CClass ac in _Aggregates)
                                {
                                    if (ac == c)
                                    {
                                        dupe = true;
                                        break;
                                    }

                                }
                                if (!dupe)
                                {
                                    _Aggregates.Add(c);
                                }
                            }
                        }
                    }
                    return _Aggregates;
                }
            }

            public bool IsObservable()
            {
                foreach (CClass cclass in BaseClasses)
                {
                    if (cclass.Name == "Observable")
                    {
                        return true;
                    }
                    if (cclass.IsObservable())
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool IsLazyObject()
            {
                foreach (CClass cclass in BaseClasses)
                {
                    if (cclass.Name == "LazyObject")
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Classes whos base class is Instrument need to have a pricing engine set after object creation, but before use.
            /// This function gets engine parameter so that it can be added to be object construction
            /// </summary>
            /// <returns>the pricing  parameter or null</returns>
            static string[] priceClasses =
                        { "CappedFlooredCoupon"
                        , "DigitalCoupon"
                        , "FloatingRateCoupon"
                        , "CalibrationHelper"
                        , "Instrument"
                        , "InflationCoupon"
                        , "CappedFlooredYoYInflationCoupon"
                        };
            private CParameter _pricingParameter = null;
            private bool _haveSearchedForPricingParemter = false;
            public CParameter PricingParameter()

            {
                if (_haveSearchedForPricingParemter)
                    return _pricingParameter;

                foreach (string s in priceClasses)
                {
                    if (Name == s)
                    {
                        foreach (CMethod m in Methods)
                        {
                            if (m.Name == "setPricingEngine" || m.Name == "setPricer")
                            {
                                _pricingParameter = m.Parameters[0];
                                _haveSearchedForPricingParemter = true;
                                return _pricingParameter;
                            }
                        }
                    }
                }
                foreach (CClass cclass in BaseClasses)
                {
                    CParameter p = cclass.PricingParameter();
                    if (p != null)
                    {
                        _pricingParameter = p;
                        _haveSearchedForPricingParemter = true;
                        return p;
                    }
                }
                _haveSearchedForPricingParemter = true;
                return _pricingParameter;
            }

            public List<CClass> Enums
            {
                get
                {
                    if (_Enums == null)
                    {
                        _Enums = new List<CClass>();
                        foreach (KeyValuePair<string, CClass> cpair in this.Package.Classes)
                        {
                            if (cpair.Value.ParentID == this.Id)
                            {
                                _Enums.Add(cpair.Value);
                            }
                        }
                    }
                    return _Enums;
                }
            }

            /// <summary>
            /// Construct the class from a reference 
            /// </summary>
            /// <param name="element">the searched</param>
            /// <param name="root">the package root</param>
            public CClass(EA.Element element, CPackage root)
            {
                Name = element.Name;
                Guid = element.ElementGUID;
                Id = element.ElementID;
                FileName = element.Genfile;
                Package = root.GetById(element.PackageID);
                Element = element;
                IsSpec = element.IsSpec;
                if (element.Abstract == "1") _IsAbstract = true;
            }

            Dictionary<int, CClass> _ReferencedClasses = null;
            public Dictionary<int, CClass> ReferencedClasses
            {
                get
                {
                    if (_ReferencedClasses == null)
                    {
                        _ReferencedClasses = new Dictionary<int, CClass>();

                        foreach (CMethod method in AllMethods)
                        {
                            if (method.ReturnType != null && method.ReturnType.Class != null)
                            {
                                _ReferencedClasses[method.ReturnType.Class.Id] = method.ReturnType.Class;
                            }
                            foreach (KeyValuePair<int, CParameter> pair in method.Parameters)
                            {
                                if (pair.Value.ParameterType.Class != null)
                                {
                                    _ReferencedClasses[pair.Value.ParameterType.Class.Id] = pair.Value.ParameterType.Class;
                                }
                            }
                        }
                        foreach (CClass cclass in AllBaseClasses)
                        {
                            _ReferencedClasses[cclass.Id] = cclass;
                        }

                        if (PricingParameter() != null && PricingParameter().ParameterType.Class != null)
                        {
                            _ReferencedClasses[PricingParameter().ParameterType.Class.Id] = PricingParameter().ParameterType.Class;
                        }
                    }
                    return _ReferencedClasses;
                }
            }
            public Dictionary<int, CPackage> ReferencedPackages
            {
                get
                {
                    Dictionary<int, CPackage> dict = new Dictionary<int, CPackage>();

                    foreach (KeyValuePair<int, CClass> pair in ReferencedClasses)
                    {
                        if (pair.Value.Package != null && pair.Value.Package != Package && !pair.Value.IsSpec)
                        {
                            dict[pair.Value.Package.Id] = pair.Value.Package;
                        }
                    }
                    return dict;
                }
            }
            public string GetNamespace(string delimiter)
            {
                CPackage package = this.Package.Parent;
                string buff = this.Package.UpperName;

                while (package != null)
                {
                    buff = package.UpperName + delimiter + buff;
                    package = package.Parent;
                }
                return buff;
            }

            /// <summary>
            /// Remove any duplicate methods created by simplification
            /// </summary>
            public void TrimDuplicate()
            {
                Queue<CMethod> q = new Queue<CMethod>();
                for (int c = 0; c < Methods.Count; c++)
                {
                    for (int i = c; i < Methods.Count; i++)
                    {
                        if (c != i && Methods[c].Same(Methods[i]))
                        {
                            q.Enqueue(Methods[i]);
                        }
                    }
                }
                while (q.Count > 0)
                {
                    Methods.Remove(q.Dequeue());
                }
            }
            private List<CMethod> _overrideMethods = null;
            public List<CMethod> OverrideMethods
            {
                get
                {
                    if (_overrideMethods == null)
                    {
                        _overrideMethods = new List<CMethod>();
                        foreach (CClass cls in OverrideBaseClasses)
                        {
                            if (!cls.IsSpec)
                            {
                                cls.TrimDuplicate();
                                foreach (CMethod m in cls.Methods)
                                {
                                    bool dupe = false;
                                    foreach (CMethod m2 in OverrideMethods)
                                    {
                                        if (m2.Same(m))
                                        {
                                            dupe = true;
                                            break;
                                        }
                                    }
                                    if (dupe && cls != ParentClass)
                                    {
                                        if (!_overrideMethods.Contains(m))
                                            _overrideMethods.Add(m);
                                    }
                                }
                                foreach (CMethod m in cls.Methods)
                                {
                                    bool dupe = false;
                                    foreach (CMethod m2 in Methods)
                                    {
                                        if (m2.Same(m))
                                        {
                                            dupe = true;
                                            break;
                                        }
                                    }
                                    if (dupe && cls != ParentClass)
                                    {
                                        if (!_overrideMethods.Contains(m))
                                            _overrideMethods.Add(m);
                                    }
                                }
                            }
                        }
                    }
                    return _overrideMethods;
                }
            }

            private List<CMethod> _AllMethods = null;
            public List<CMethod> AllMethods
            {
                get
                {
                    if (_AllMethods == null)
                    {
                        _AllMethods = new List<CMethod>(Methods);
                        foreach (CClass cls in AllBaseClasses)
                        {
                            if (!cls.IsSpec)
                            {
                                cls.TrimDuplicate();
                                foreach (CMethod m in cls.AllMethods)
                                {
                                    bool dupe = false;
                                    foreach (CMethod m2 in Methods)
                                    {
                                        if (m2.Same(m))
                                        {
                                            dupe = true;
                                            break;
                                        }
                                    }
                                    if (!dupe)
                                    {
                                        _AllMethods.Add(m);
                                    }
                                }
                            }
                        }
                    }
                    return _AllMethods;
                }
            }

            public bool IsAbstract
            {
                get
                {
                    if (!_IsAbstract.HasValue)
                    {
                        foreach (CMethod m in Methods)
                        {
                            if (m.IsAbstract)
                            {
                                _IsAbstract = true;
                            }
                        }
                        if (!_IsAbstract.HasValue)
                        {
                            _IsAbstract = false;
                        }
                    }
                    return _IsAbstract.Value;
                }
            }
            public List<String> Collections
            {
                get
                {
                    if (_Collections == null)
                    {
                        SortedList<string, string> refs = new SortedList<string, string>();
                        foreach (CTSType cts in References)
                        {
                            if (!refs.ContainsKey(cts.CollectionType) && cts.CollectionType != "")
                            {
                                refs.Add(cts.CollectionType, cts.CollectionType);
                            }
                        }
                        if (refs.ContainsKey("Cube") && !refs.ContainsKey("Matrix"))
                        {
                            refs.Add("Matrix", "Matrix");
                        }
                        if (refs.ContainsKey("Matrix") && !refs.ContainsKey("Vector"))
                        {
                            refs.Add("Vector", "Vector");
                        }
                        _Collections = new List<String>();
                        foreach (KeyValuePair<string, string> pair in refs)
                        {
                            _Collections.Add(pair.Key);
                        }
                    }
                    return _Collections;
                }
            }
            public bool IsStruct
            {
                get
                {
                    if (!_IsImpliedStructChecked)
                    {
                        _IsImpliedStructChecked = true;
                        foreach (CTSType cts in References)
                        {
                            // if the object is passed by value then it must have struct behavior
                            if (cts.Calling == CTSType.CallingType.Value)
                            {
                                _IsStruct = true;
                                break;
                            }
                        }
                    }
                    return _IsStruct;
                }
            }
            public string Guid2
            {
                get
                {
                    char[] cs = Guid.ToCharArray();
                    char t;
                    int b = 0;
                    int e = cs.Length - 1;
                    for (int i = 0; i < 4; i++)
                    {
                        t = cs[b]; cs[b++] = cs[e]; cs[e--] = t;
                    }
                    return new String(cs);
                }
            }
            private Dictionary<string, CParameter> _constrctorParameters = null;
            public Dictionary<string, CParameter> ConstructorParameters
            {
                get
                {
                    if (_constrctorParameters == null)
                    {
                        _constrctorParameters = new Dictionary<string, CParameter>();
                        foreach (CMethod m in Methods)
                        {
                            if (m.Name == Name)
                                foreach (KeyValuePair<int, CParameter> p in m.Parameters)
                                {
                                    if ((p.Value.ParameterType.Class != null &&
                                        !p.Value.ParameterType.Class.IsSpec) ||
                                        (p.Value.ParameterType.CollectionType != null &&
                                         p.Value.ParameterType.CollectionType != "" &&
                                        (p.Value.ParameterType.Class == null ||
                                         !p.Value.ParameterType.Class.IsSpec)
                                        ))
                                    {
                                        if (_constrctorParameters.ContainsKey(p.Value.Name))
                                            _constrctorParameters[p.Value.Name].IsDuplicateName = true;
                                        else
                                            _constrctorParameters[p.Value.Name] = p.Value;
                                    }
                                }
                        }
                    }
                    return _constrctorParameters;
                }
            }
        }

        public class CAttribute
        {
            public string Name;
            public string Value;
            public int Pos;

            public CAttribute(string name, string value, int pos)
            {
                Name = name;
                Value = value;
                Pos = pos;
            }
        }

        public class CMethod
        {
            public string Name;
            public string Notes;
            public CTSType ReturnType;
            public int Id;
            public bool IsAbstract;
            public bool IsLocking;
            public SortedList<int, CParameter> Parameters = new SortedList<int, CParameter>();
            public CClass Class;

            public CMethod(EA.Method method, UU converter, EA.Element element, CClass cls)
            {
                Name = CTSKeyWord[method.Name];
                Notes = method.Notes;
                Id = method.MethodID;
                IsAbstract = method.IsPure;
                IsLocking = !method.IsQuery;
                Class = cls;
                if (Name.StartsWith("operator"))
                {
                    char[] c = new char[] { ' ' };
                    string[] str = Name.Split(c);
                    if (str.Length == 2)
                    {
                        CTSType t = converter.GetCTSType(str[1], element);
                        Name = str[0] + " " + t.Value;
                        ReturnType = t;
                    }
                }
                else
                {
                    ReturnType = converter.GetCTSType(method.ReturnType, element);
                }

                foreach (EA.Parameter parameter in method.Parameters)
                {
                    CParameter p = new CParameter(parameter, element, converter);
                    Parameters.Add(parameter.Position, p);
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    result.Append(delimiter + pair.Value.GetQualifiedType(includeType, namespaceDelimiter, prefix, suffix) + " " + (includeType ? pair.Value.Name : prefix + pair.Value.Name));
                    delimiter = ", ";
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    result.Append(delim + prefix + pair.Value.Name + suffix);
                    delim = delimiter;
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    result.Append(delim + prefix + pair.Value.Name + "," + pair.Value.IsOptional.ToString().ToLower() + suffix);
                    delim = delimiter;
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    result.Append(delim + prefix + "XLHelper.Validate<" + pair.Value.ParameterType.GetQualifiedTypeWithoutOption(false, ".", "I", "") + "> (" + pair.Value.Name + ", " + (pair.Value.Default == "").ToString().ToLower() + ", \"" + pair.Value.Name + "\")" + suffix);
                    delim = delimiter;
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    result.Append(delim + pair.Value.GetQualifiedCellType(namespaceDelimiter, prefix, suffix) + " " + pair.Value.Name);
                    delim = ", ";
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    result.Append(delim + pair.Value.Name);
                    delim = ", ";
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    result.Append(delim + pair.Value.Name.ToLower() + " : " + pair.Value.GetQualifiedCellType(namespaceDelimiter, prefix, suffix) + " ");
                    delim = ", ";
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
                {
                    {
                        if (pair.Value.Default != "" || pair.Value.ParameterType.isOptional)
                            result.Append(delimiter + " " + prefix + "CellHelper.ToOption(" + pair.Value.Name + ")" + suffix);
                        else
                            result.Append(delimiter + " " + prefix + pair.Value.Name + ".Value" + suffix);
                    }
                    delimiter = delim;
                }
                CParameter pricer = Class.PricingParameter();
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
                foreach (KeyValuePair<int, CParameter> pair in this.Parameters)
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
                CParameter pricer = Class.PricingParameter();
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
                        foreach (CMethod m in Class.AllMethods)
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

            public bool Same(CMethod THAT)
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

                        IEnumerator<KeyValuePair<int, CParameter>> thisE = this.Parameters.GetEnumerator();
                        IEnumerator<KeyValuePair<int, CParameter>> thatE = THAT.Parameters.GetEnumerator();

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
                foreach (KeyValuePair<int, CParameter> cp in Parameters)
                    if (cp.Value.ParameterType.Feature != CTSType.FeatureType.Enum)
                        p++;
                return (p > 0);
            }

            public bool IsOveride
            {
                get
                {
                    foreach (CMethod m in Class.OverrideMethods)
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
                        foreach (KeyValuePair<int, CParameter> pair in Parameters)
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
                SortedList<int, CParameter> newParameters = new SortedList<int, CParameter>();
                foreach (KeyValuePair<int, CParameter> pair in Parameters)
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

        public class CParameter
        {
            public CTSType ParameterType;
            public string Name;
            public string Notes;
            public int Pos;
            public string Default;
            public bool IsDuplicateName = false;

            public CParameter(EA.Parameter parameter, EA.Element element, UU converter)
            {
                Name = CTSKeyWord[parameter.Name];
                Notes = parameter.Notes;
                Default = parameter.Default;
                ParameterType = converter.GetCTSType(parameter.Type, element);
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
                    /*
                                        if (this.Default != "" || this.ParameterType.isOptional)
                                        {
                                            sb.Append ("Option<");
                                            string s = ParameterType.GetQualifiedType (false, ".", "I", "");    
                                            if (s.Contains("FSharpOption"))
                                            {
                                                s = s.Replace ("Microsoft.FSharp.Core.FSharpOption<","").Replace(">", "");
                                            }
                                            sb.Append (s);
                                        }
                                        else
                    */
                    {
                        sb.Append("<");
                        sb.Append(ParameterType.GetQualifiedTypeWithoutOption(false, ".", "I", ""));
                    }
                    sb.Append(">");

                    return sb.ToString().Replace("::", ".");
                }
            }
        }

        public void LinkCTSTypes(CClass currentClass, CTSType ctsType)
        {
            if (ctsType == null
               || ctsType.Feature != CTSType.FeatureType.Object
               || ctsType.Value == null || ctsType.Value == ""
               || ctsType.Value == "void"
               || ctsType.Value.Contains("<")
               ) return;
            List<CClass> cSet = RootTree.FindClassByName(ctsType.Value);
            if (cSet.Count == 0 || cSet[0].FilledFromRepository == false)
            {
                //                if (ctsType.Value.Contains(">")) Debugger.Break();
                Console.WriteLine("\t\tCould not find " + ctsType.Value + " in memory");
                EA.Collection collection;
                if (ctsType.Value.Contains("::"))
                {
                    collection = GetElementsByQuery("FindByName", ctsType.Value.Substring(ctsType.Value.LastIndexOf("::") + 2));
                }
                else
                {
                    collection = GetElementsByQuery("FindByName", ctsType.Value);
                }
                if (collection != null)
                {
                    foreach (EA.Element element in collection)
                    {
                        if (!element.IsSpec                  // explicitly excluded
                            && element.ParentID == 0            // no nested classes
                            && element.Subtype != 1             // no parameterised interfaces
                            && element.Stereotype != "typedef"  // in this context all typedefs are templates.. so exlcude
                            && !element.Name.Contains("<")
                            && element.Name != "engine"
                            && element.Name != "arguments"
                            && element.Name != "results"
                            && element.Name != "Point"
                           )
                        {
                            CClass cclass = RootTree.FindClassByElement(element);
                            if (cclass == null)
                            {
                                cclass = new CClass(element, RootTree, this);
                                CPackage rt = RootTree.GetById(element.PackageID);
                                if (rt != null)
                                    rt.Classes.Add(cclass.Name, cclass);
                            }
                            cSet.Add(cclass);
                        }
                    }
                }
                foreach (CClass cclass in cSet)
                {
                    cclass.FilledFromRepository = true;
                }
            }
            // OK there must be at least one.. lets pick the nearest
            if (cSet.Count > 0)
            {
                CClass matchedByFile = null;
                CClass matchedByPackage = null;
                CClass matchedByName = null;
                CClass matchedByParent = null;

                CClass matched;                     // best from above

                foreach (CClass cclass in cSet)
                {
                    if (matchedByFile == null && cclass.FileName == currentClass.FileName)
                        matchedByFile = cclass;
                    if (matchedByParent == null && cclass.ParentID == currentClass.Id)
                        matchedByParent = cclass;
                    if (matchedByPackage == null && cclass.Package == currentClass.Package)
                        matchedByPackage = cclass;
                    if (matchedByName == null && cclass.Name == ctsType.Value)
                        matchedByName = cclass;
                }

                matched = (matchedByFile != null ? matchedByFile : (matchedByParent != null ? matchedByParent : (matchedByPackage != null ? matchedByPackage : matchedByName)));

                // fill in the matching class reference, and do the same for any similar references in this class.
                if (matched != null)
                {
                    ctsType.Class = matched;
                    matched.References.Add(ctsType);
                    foreach (CMethod method in currentClass.Methods)
                    {
                        if (method.ReturnType != null && method.ReturnType.Value != null && method.ReturnType.Value == ctsType.Value)
                        {
                            method.ReturnType.Class = matched;
                        }
                        foreach (KeyValuePair<int, CParameter> pair in method.Parameters)
                        {
                            if (pair.Value.ParameterType.Value != null && pair.Value.ParameterType.Value == ctsType.Value)
                            {
                                pair.Value.ParameterType.Class = matched;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Type Lookup

        public class TypeLookup
        {
            private static TypeLookup _instance = null;
            public class Item
            {
                public string Name;
                public string Definition;
                public string NativeDefinition;
                public string FileName;
                public int ParentID;
                public int PackageID;
                public string PackageName;
            }

            public static TypeLookup Instance()
            {
                if (_instance == null)
                    _instance = new TypeLookup();
                return _instance;
            }

            private Dictionary<string, Item> ByName;
            private Dictionary<string, Dictionary<string, Item>> ByFileName;
            private Dictionary<int, Dictionary<string, Item>> ByParentId;
            private Dictionary<int, Dictionary<string, Item>> ByPackageId;

            public TypeLookup()
            {
                ByName = new Dictionary<string, Item>();
                ByFileName = new Dictionary<string, Dictionary<string, Item>>();
                ByParentId = new Dictionary<int, Dictionary<string, Item>>();
                ByPackageId = new Dictionary<int, Dictionary<string, Item>>();
            }

            public void Add(string name, string definition, string nativeDefinition, string fileName, int parentId, int packageId)
            {
                Item item = new Item();

                item.Name = name;
                item.Definition = definition;
                item.NativeDefinition = nativeDefinition;
                item.FileName = fileName;
                item.ParentID = parentId;
                item.PackageID = packageId;

                if (!ByName.ContainsKey(item.Name)) ByName.Add(item.Name, item);
                if (ByFileName.ContainsKey(item.FileName))
                {
                    Dictionary<string, Item> d = ByFileName[item.FileName];
                    if (!d.ContainsKey(item.Name)) d.Add(item.Name, item);
                }
                else
                {
                    Dictionary<string, Item> d = new Dictionary<string, Item>();
                    d.Add(item.Name, item);
                    ByFileName.Add(item.FileName, d);
                }
                if (ByParentId.ContainsKey(item.ParentID))
                {
                    Dictionary<string, Item> d = ByParentId[item.ParentID];
                    if (!d.ContainsKey(item.Name)) d.Add(item.Name, item);
                }
                else
                {
                    Dictionary<string, Item> d = new Dictionary<string, Item>();
                    d.Add(item.Name, item);
                    ByParentId.Add(item.ParentID, d);
                }
                if (ByPackageId.ContainsKey(item.PackageID))
                {
                    Dictionary<string, Item> d = ByPackageId[item.PackageID];
                    if (!d.ContainsKey(item.Name)) d.Add(item.Name, item);
                }
                else
                {
                    Dictionary<string, Item> d = new Dictionary<string, Item>();
                    d.Add(item.Name, item);
                    ByPackageId.Add(item.PackageID, d);
                }
            }

            public Item FindType(String name, string fileName, int objectId, int parentid, int packageid)
            {
                // this class contains the definition
                if (ByParentId.ContainsKey(objectId))
                    if (ByParentId[objectId].ContainsKey(name))
                        return ByParentId[objectId][name];

                // this class's parent contains the definition
                if (ByParentId.ContainsKey(parentid))
                    if (ByParentId[parentid].ContainsKey(name))
                        return ByParentId[parentid][name];

                // typedef in the same file
                if (ByFileName.ContainsKey(fileName))
                    if (ByFileName[fileName].ContainsKey(name))
                        return ByFileName[fileName][name];

                // typedef within the same package
                if (ByPackageId.ContainsKey(packageid))
                    if (ByPackageId[packageid].ContainsKey(name))
                        return ByPackageId[packageid][name];

                if (ByName.ContainsKey(name))
                    return ByName[name];

                return null;
            }
            public void StorePackageName(int id, string name)
            {
                Dictionary<string, Item> d = ByPackageId[id];

                if (d == null)
                    return;

                foreach (KeyValuePair<string, Item> pair in d)
                {
                    pair.Value.PackageName = name;
                }
            }
        }

        #endregion

        #region Typdef

        private TypeLookup _typedefs = null;
        [Browsable(false)]
        public TypeLookup TypeDefs
        {
            get
            {
                if (_typedefs == null)
                {
                    _typedefs = new TypeLookup();
                    foreach (EA.Element element in GetElementsByQuery("AllTypedefs", ""))
                    {
                        string st = element.Genlinks.Replace("Parent=", "").Replace(";", "");
                        _typedefs.Add(element.Name, GetCTSType(st, element).Value, st, element.Genfile, element.ParentID, element.PackageID);
                    }
                }
                return _typedefs;
            }
            set
            {
                _typedefs = value;
            }
        }

        public TypeLookup.Item GetCTSTypdef(string name, EA.Element element)
        {
            try
            {
                TypeLookup.Item i = TypeDefs.FindType(name, element.Genfile, element.ElementID, element.ParentID, element.PackageID);
                return i;
            }
            catch (Exception)
            {
                Debugger.Break();
            }
            return null;
        }

        #endregion

        #region Enums

        private TypeLookup _enumsDefs = null;
        [Browsable(false)]
        public TypeLookup EnumDefs
        {
            get
            {
                if (_enumsDefs == null)
                {
                    _enumsDefs = new TypeLookup();
                    Dictionary<int, EA.Element> parentDictionary = new Dictionary<int, Element>();
                    EA.Collection collection = GetElementsByQuery("AllEnums", "");
                    if (collection != null)
                    {
                        foreach (EA.Element element in collection)
                        {
                            parentDictionary.Add(element.ElementID, element);
                        }
                        foreach (KeyValuePair<int, EA.Element> pair in parentDictionary)
                        {
                            try
                            {
                                if (pair.Value.Stereotype == "enumeration")
                                {
                                    _enumsDefs.Add
                                        (pair.Value.Name
                                        , RootTree.GetGlobalNameById(pair.Value.PackageID, "::") + "::"
                                            + (parentDictionary.ContainsKey(pair.Value.ParentID) ? parentDictionary[pair.Value.ParentID].Name + "::" : "")
                                            + pair.Value.Name + "Enum",
                                            (parentDictionary.ContainsKey(pair.Value.ParentID) ? parentDictionary[pair.Value.ParentID].Name + "::" : "") + pair.Value.Name,
                                            pair.Value.Genfile, pair.Value.ParentID, pair.Value.PackageID);

                                    // resolve partially qualified enum names
                                    if (parentDictionary.ContainsKey(pair.Value.ParentID))
                                    {
                                        _enumsDefs.Add
                                            (parentDictionary[pair.Value.ParentID].Name + "::" + pair.Value.Name
                                            , RootTree.GetGlobalNameById(pair.Value.PackageID, "::") + "::"
                                                + parentDictionary[pair.Value.ParentID].Name + "::"
                                                + pair.Value.Name + "Enum",
                                            (parentDictionary.ContainsKey(pair.Value.ParentID) ? parentDictionary[pair.Value.ParentID].Name + "::" : "") + pair.Value.Name,
                                                pair.Value.Genfile, pair.Value.ParentID, pair.Value.PackageID);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Debugger.Break();
                            }

                        }
                    }
                }
                return _enumsDefs;
            }
            set
            {
                _enumsDefs = value;
            }
        }

        #endregion
        public int ThePackageId;
        private CPackage _CurrentPackage = null;
        [Browsable(false)]
        public CPackage CurrentPackage
        {
            get
            {
                if (_CurrentPackage == null)
                {
                    _CurrentPackage = new CPackage(CurrentRepository.GetPackageByID(ThePackageId), null);
                    foreach (EA.Element element in _CurrentPackage.Package.Elements)
                    {
                        if (!_CurrentPackage.Classes.ContainsKey(element.Name))
                            _CurrentPackage.Classes.Add(element.Name, new CClass(element, _CurrentPackage, this));
                    }

                }
                return _CurrentPackage;
            }
            set
            {
                _CurrentPackage = value;
            }
        }
        private EA.Collection GetElementsByQuery(string query, string parameter)
        {
            return CurrentRepository.GetElementsByQuery(query, parameter);
            /*            switch (query)
                        {
                            case "FindByName":
                                return CurrentRepository.GetElementsByQuery 
                                ( @"
            SELECT ea_guid as CLASSGUID, Obje.Type as CLASSTYPE, name, note 
            from element 
            where name like '<Search Term>'"
                                , parameter
                                );

                            case "FindChildEnumeration":
                                return CurrentRepository.GetElementsByQuery
                                (@"
            SELECT Name, ea_guid AS CLASSGUID 
            FROM element 
            WHERE element.Stereotype = ""enumeration"" 
            AND (element.ParentID = < Search Term > ) "
                                , parameter
                                );

                            case "FindPackageEnumeration":
                                return CurrentRepository.GetElementsByQuery 
                                (@"
            SELECT element.ea_guid AS CLASSGUID, 
                element.Name, 
                element.Package_ID, 
                element.Stereotype, 
                element.ParentID 
            FROM element 
            WHERE (((element.Package_ID)=<Search Term>) 
            AND ((element.Stereotype)=""enumeration""))" 
                                , parameter
                                );

                            case "AllTypedefs":
                                return CurrentRepository.GetElementsByQuery
                                (@"
            SELECT element.ea_guid AS CLASSGUID, 
                element.Stereotype, 
                element.Name, 
                element.GenFile, 
                element.GenLinks, 
                element.Visibility, 
                element.Package_ID, 
                element.ParentID, 
                element.Obje.ID 
            FROM element 
            WHERE (((element.Stereotype) = ""typedef"") 
            AND((element.GenLinks) Is Not Null)) 
            ORDER BY element.Name"
                                , parameter
                                );

                            case "AllEnums":
                                return CurrentRepository.GetElementsByQuery  .GetElementsByQuery
                                (@"
            SELECT element.Name, 
            element.GenFile, 
            element.ea_guid AS CLASSGUID, 
            element.Note, 
            element.Obje.ID 
            FROM element 
            WHERE (((element.Stereotype) = ""enumeration"")) 
                OR(((element.Obje.ID) In
                (SELECT element.Obje.ID 
                 FROM element AS eleme.1 
                    INNER JOIN element ON eleme.1.ParentID = element.Obje.ID 
                WHERE(((eleme.1.Stereotype) = ""enumeration""))))) 
            ORDER BY element.ParentID; "
                                , parameter
                                );

                            default:
                                return CurrentRepository.GetElementsByQuery(query, parameter);
                        }
                }
                        */
        }
    }

}