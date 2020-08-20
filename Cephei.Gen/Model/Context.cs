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
using System.Linq;
using EA.Gen.Model.Jet;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
//using EA;

namespace Cephei.Gen.Model
{
    public class Context
    {
        public Element currentElement = null;

        protected EA.Gen.Model.Jet.Sparx _repo;

        public string ElementName;
        public string RootName;
        public string Prefix = "";            // "I" if we are generarting and interface file, otherwith ""
        public string Suffix = "";            // "^" if we are generarting C++/CLI, otherwith ""
        public string ClassDelimiter = "";    // for C++/CLI this is "::" but for C# it is "."

        public void Init(string rootName, string elementName)
        {
            RootName = rootName;
            ElementName = elementName;
        }

        public CTSTypeDictionary CTSTypeDict = new CTSTypeDictionary();
        public CTSKeyWordDictionary CTSKeyWord = new CTSKeyWordDictionary();

        [Browsable(false)]
        public Element CurrentElement
        {
            get
            {
                if (currentElement == null)
                {
                    //                    Console.WriteLine ("finding element " + TheElementName);

                    if (ElementName == null) throw new ApplicationException("You must identify an element.");
                    var collection = GetElementsByQuery("FindByName", ElementName);
                    if (collection != null && collection.Count > 0)
                    {
                        foreach (var element in collection)
                        {
                            if (element.ObjectType == "Class")
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
        public Sparx Repository
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new Sparx();
                    Console.WriteLine("opened repository ");
                }
                if (_repo == null)
                    throw new ApplicationException("Unable to open repository");
                return _repo;
            }
            set
            {
                _repo = value;
            }
        }


        public CTSType GetCTSType(string inp, Element element)
        {
            CTSType.CallingType callingType;

            string collectionType = "";
            bool isOptional = false;

            foreach (var a in inp.Split(new char[] { ':', '<', '>' }))
            {
                switch (a)
                {
                    case "":
                    case "std":
                    case "ext":
                    case "boost":
                        continue;

                    case "vector":
                        switch (collectionType)
                        {
                            case "":
                                collectionType = "Vector";
                                continue;
                            case "Vector":
                                collectionType = "Matrix";
                                continue;
                            case "Matrix":
                                collectionType = "Cube";
                                continue;
                            default:
                                continue;
                        }

                    case "Handle":
                        callingType = CTSType.CallingType.HandleReference;
                        continue;
                    case "&":
                        callingType = CTSType.CallingType.Reference;
                        continue;
                    case "*":
                        callingType = CTSType.CallingType.Pointer;
                        continue;
                    case "optional":
                        callingType = CTSType.CallingType.Value;
                        isOptional = true;
                        continue;
                    case "shared_ptr":
                        callingType = CTSType.CallingType.BoostReference;
                        continue;
                }


            }





            const string CUBE = "std::vector<std::vector<std::vector<";
            const string MATRIX = "std::vector<std::vector<";
            const string VECTOR = "std::vector<";


            // convert traditional C++ to C++/CLI
            if (inp == null)
                inp = "";
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
                TypeLookup.Item i = EnumDefs.FindType(buff, element.GenFile, element.Id, element.ParentID, element.PackageId);
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

        protected string NativeName(string inp)
        {
            if (inp.EndsWith("&") || inp.EndsWith("*"))
            {
                return inp.Substring(0, inp.Length - 1);
            }
            return inp;
        }

        protected bool Included(Method method)
        {
            if (method.ReturnType == null || !Included(method.ReturnType.Value)) return false;

            foreach (KeyValuePair<int, Parameter> pair in method.Parameters)
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
        public bool Included2(Method method, bool Constructor)
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
            foreach (KeyValuePair<int, Parameter> pair in method.Parameters)
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

        public string GetGeneralisation(Class cls, string prefix, bool cpp)
        {
            string parents = "";
            string seper = ": ";

            foreach (Class cclass in cls.AllBaseClasses)
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

        public string GetPackageNameById(IEnumerable<EA.Gen.Model.Jet.Package> collection, int id, string delim, string topPackage)
        {
            return GetPackageNameById(collection, id, delim, topPackage, false);
        }
        private string GetPackageNameById(IEnumerable<EA.Gen.Model.Jet.Package> collection, int id, string delim, string topPackage, bool withinTop)
        {
            foreach (var package in collection)
            {
                if (package.Id == id)
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

        #region Package handling 

        ///////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>

        private Package _RootTree = null;
        [Browsable(false)]
        public Package RootTree
        {
            get
            {
                if (_RootTree == null)
                {
                    //                    Debugger.Break ();
                    Console.WriteLine("** getting packages from repository **");
                    var root = (from r in Repository.Packages
                                where r.Name == RootName || r.GUID == RootName
                                select r).FirstOrDefault();
                    _RootTree = Package.CreateFromPackage(root, null, this);
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

        private Class _currentClass = null;
        [Browsable(false)]
        public Class CurrentClass
        {
            get
            {
                if (_currentClass == null)
                {
                    _currentClass = new Class(CurrentElement, RootTree, this);

                    var collection = GetElementsByQuery("FindChildEnumeration", CurrentElement.Id.ToString());
                    if (collection != null)
                    {
                        foreach (var element in collection)
                        {
                            Package package = RootTree.GetById(element.PackageId.Value);
                            if (!package.Classes.ContainsKey(element.Name))
                                package.Classes[element.Name] = new Class(element, RootTree, this);
                        }
                    }
                    foreach (Method method in _currentClass.Methods)
                    {
                        this.LinkCTSTypes(_currentClass, method.ReturnType);

                        foreach (KeyValuePair<int, Parameter> pair in method.Parameters)
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



        public void LinkCTSTypes(Class currentClass, CTSType ctsType)
        {
            if (ctsType == null
               || ctsType.Feature != CTSType.FeatureType.Object
               || ctsType.Value == null || ctsType.Value == ""
               || ctsType.Value == "void"
               || ctsType.Value.Contains("<")
               ) return;
            List<Class> cSet = RootTree.FindClassByName(ctsType.Value);
            if (cSet.Count == 0 || cSet[0].FilledFromRepository == false)
            {
                //                if (ctsType.Value.Contains(">")) Debugger.Break();
                Console.WriteLine("\t\tCould not find " + ctsType.Value + " in memory");
                List<Element> collection;
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
                    foreach (var element in collection)
                    {
                        if (!element.IsSpec                     // explicitly excluded
                            && element.ParentID == 0            // no nested classes
                            && element.IsTempleClass(_repo)     // no parameterised interfaces
                            && element.Stereotype != "typedef"  // in this context all typedefs are templates.. so exlcude
                            && !element.Name.Contains("<")
                            && element.Name != "engine"
                            && element.Name != "arguments"
                            && element.Name != "results"
                            && element.Name != "Point"
                           )
                        {
                            Class cclass = RootTree.FindClassByElement(element);
                            if (cclass == null)
                            {
                                cclass = new Class(element, RootTree, this);
                                Package rt = RootTree.GetById(element.PackageId.Value);
                                    rt.Classes.Add(cclass.Name, cclass);
                            }
                            cSet.Add(cclass);
                        }
                    }
                }
                foreach (Class cclass in cSet)
                {
                    cclass.FilledFromRepository = true;
                }
            }
            // OK there must be at least one.. lets pick the nearest
            if (cSet.Count > 0)
            {
                Class matchedByFile = null;
                Class matchedByPackage = null;
                Class matchedByName = null;
                Class matchedByParent = null;

                Class matched;                     // best from above

                foreach (Class cclass in cSet)
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
                    foreach (Method method in currentClass.Methods)
                    {
                        if (method.ReturnType != null && method.ReturnType.Value != null && method.ReturnType.Value == ctsType.Value)
                        {
                            method.ReturnType.Class = matched;
                        }
                        foreach (KeyValuePair<int, Parameter> pair in method.Parameters)
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
                    foreach (var element in GetElementsByQuery("AllTypedefs", ""))
                    {
                        string st = element.GenLinks.Replace("Parent=", "").Replace(";", "");
                        _typedefs.Add(element.Name, GetCTSType(st, element).Value, st, element.GenFile, element.ParentID, element.PackageId);
                    }
                }
                return _typedefs;
            }
            set
            {
                _typedefs = value;
            }
        }

        public TypeLookup.Item GetCTSTypdef(string name, Element element)
        {
            try
            {
                TypeLookup.Item i = TypeDefs.FindType(name, element.GenFile, element.Id, element.ParentID, element.PackageId);
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
                    Dictionary<int, Element> parentDictionary = new Dictionary<int, Element>();
                    var collection = (from ae in _repo.Elements.Include("Parent")
                                      where ae.Stereotype == "enumeration" ||
                                      ae.Parent.Stereotype == "enumeration"
                                      select ae).ToList();
                    if (collection != null)
                    {
                        foreach (var element in collection)
                        {
                            parentDictionary.Add(element.Id, element);
                            if (element.Parent != null && !parentDictionary.ContainsKey(element.ParentID.Value))
                                parentDictionary.Add(element.ParentID.Value, element.Parent);
                        }
                        foreach (var pair in parentDictionary)
                        {
                            try
                            {
                                if (pair.Value.Stereotype == "enumeration")
                                {
                                    _enumsDefs.Add
                                        (pair.Value.Name
                                        , RootTree.GetGlobalNameById(pair.Value.PackageId.Value, "::") + "::"
                                            + (parentDictionary.ContainsKey(pair.Value.ParentID ?? 0) ? parentDictionary[pair.Value.ParentID.Value].Name + "::" : "")
                                            + pair.Value.Name + "Enum",
                                            (parentDictionary.ContainsKey(pair.Value.ParentID ?? 0) ? parentDictionary[pair.Value.ParentID.Value].Name + "::" : "") + pair.Value.Name,
                                            pair.Value.GenFile, pair.Value.ParentID, pair.Value.PackageId);

                                    // resolve partially qualified enum names
                                    if (parentDictionary.ContainsKey(pair.Value.ParentID ?? 0))
                                    {
                                        _enumsDefs.Add
                                            (parentDictionary[pair.Value.ParentID.Value].Name + "::" + pair.Value.Name
                                            , RootTree.GetGlobalNameById(pair.Value.PackageId ?? 0, "::") + "::"
                                                + parentDictionary[pair.Value.ParentID.Value].Name + "::"
                                                + pair.Value.Name + "Enum",
                                            (parentDictionary.ContainsKey(pair.Value.ParentID ?? 0) ? parentDictionary[pair.Value.ParentID.Value].Name + "::" : "") + pair.Value.Name,
                                                pair.Value.GenFile, pair.Value.ParentID, pair.Value.PackageId);
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
        private Package _CurrentPackage = null;
        [Browsable(false)]
        public Package CurrentPackage
        {
            get
            {
                if (_CurrentPackage == null)
                {

                    var p = (from r in _repo.Packages
                             where r.Id == ThePackageId
                             select r).FirstOrDefault();

                    _CurrentPackage = new Package(p, null, this);
                    foreach (var element in _CurrentPackage._Package.Elements)
                    {
                        if (!_CurrentPackage.Classes.ContainsKey(element.Name))
                            _CurrentPackage.Classes.Add(element.Name, new Class(element, _CurrentPackage, this));
                    }

                }
                return _CurrentPackage;
            }
            set
            {
                _CurrentPackage = value;
            }
        }

        public EA.Gen.Model.Jet.Element GetElementByID (int id)
        {
            return (from r in _repo.Elements
                    where r.Id == id
                    select r).FirstOrDefault();
        }
        public List<Element> GetElementsByQuery(string query, string parameter)
        {
//            return CurrentRepository.GetElementsByQuery(query, parameter);
            switch (query)
            {
                case "FindByName":
                    return (from fn in _repo.Elements
                            where fn.Name == parameter
                            select fn).ToList();

                case "FindChildEnumeration":
                        int i = Convert.ToInt32(parameter);
                        return (from fc in _repo.Elements
                                where fc.Stereotype == "enumeration"
                                && fc.ParentID == i
                                select fc).ToList();

                case "FindPackageEnumeration":
                        int p = Convert.ToInt32(parameter);
                        return (from fp in _repo.Elements
                                where fp.PackageId == p
                                && fp.Stereotype == "enumeration"
                                select fp).ToList();

                case "AllTypedefs":
                        return (from at in _repo.Elements
                                where at.Stereotype == "typedef"
                                && at.GenLinks != null
                                select at).ToList();

                case "AllEnums":
                        return (from ae in _repo.Elements.Include("Parent")
                                where ae.Stereotype == "enumeration" ||
                                ae.Parent.Stereotype == "enumeration"
                                select ae).ToList();

                default:
                    throw new NotImplementedException();

            }
        }
    }
}