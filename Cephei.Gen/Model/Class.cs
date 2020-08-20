using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA.Gen.Model.Jet;

namespace Cephei.Gen.Model
{
    public class Class
    {
        public string Name;
        public string Guid;
        public int Id;
        public string Notes;
        public string FileName;           // used to map derived names back to element
        public Package Package;
        public bool FilledFromRepository;   // has the instances of this name been filled from the repository
        public Element Element;
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

        public List<Method> Methods = new List<Method>();
        public SortedList<int, Attribute> Attributes = new SortedList<int, Attribute>();
        private List<Class> _Enums = null;
        private List<Class> _BaseClasses = null;
        public List<Class> _knownTypes = new List<Class>();
        public List<CTSType> References = new List<CTSType>();
        private List<string> _Collections = null;
        private Context _context;

        public Class(Element element, Package root, Context context)
        {
            _context = context;
            Name = element.Name;
            Notes = element.Note ?? "";
            Guid = element.GUID;
            Id = element.Id;
            FileName = element.GenFile;
            Package = (root == null ? null : root.GetById(element.PackageId.Value));
            FilledFromRepository = false;
            Element = element;
            var isTemplate = (element.PDATA3 != null && element.PDATA3.Contains("<PRM1>"));
            // Convert nested classes and template classes to spec classes
            IsSpec = (element.IsSpec || isTemplate || element.Name.Contains("<") || element.ParentID != 0 || element.Name == "engine");
            ParentID = (element.Stereotype == "enumeration" ? element.ParentID.Value : 0);
            if (element.Abstract == "1") _IsAbstract = true;
            IsEnum = (element.Stereotype == "enumeration");
            _IsStruct = (element.Stereotype == "struct");
            _IsActive = !(element.IsActive);    // used to flag QuantLib classes that rely on evaluation date
            if (!IsEnum)
            {
                foreach (var method in element.Operations)
                {
                    if (method.Scope == "Public" && method.Synchronized == "0")
                    {
                        Methods.Add(new Method(method, context, element, this));
                    }
                }
            }
            else
            {
                int c = 0;
                foreach (var attribute in element.Attributes)
                {
                    Attributes.Add(attribute.Pos ?? c, new Attribute(attribute.Name, attribute.Default, attribute.Pos ?? c));
                    c++;
                }
            }
            _BaseClasses = new List<Class>();
            foreach (Element be in Element.BaseClasses(_context.Repository)) 
            {
                Class cclass = root.FindClassByElement(be);
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
                        cclass = new Class(be, root, context);
                        cclass.Package.Classes[cclass.Name] = cclass;
                        _BaseClasses.Add(cclass);

                        foreach (Method method in cclass.Methods)
                        {
                            context.LinkCTSTypes(cclass, method.ReturnType);

                            foreach (KeyValuePair<int, Parameter> pair in method.Parameters)
                            {
                                context.LinkCTSTypes(cclass, pair.Value.ParameterType);
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

        public List<Class> BaseClasses
        {
            get
            {
                if (_BaseClasses == null)
                {
                    Package root = Package.GetRoot();
                    _BaseClasses = new List<Class>();
                    foreach (Element element in Element.BaseClasses(_context.Repository))
                    {
                        Class cclass = root.FindClassByElement(element);
                        if (cclass != null)
                        {
                            _BaseClasses.Add(cclass);
                            cclass._knownTypes.Add(this);
                        }
                        else if (element.IsSpec                         // explicitly excluded                                                                  
                                && element.ParentID == 0            // no nested classes
                                && element.Stereotype != "typedef"  // in this context all typedefs are templates.. so exlcude
                                && element.Name != "engine" 
                                && element.Name != "arguments"
                                && element.Name != "results"
                                && element.Name != "Point"
                                )
                        {
                            cclass = new Class(element, root);
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
        public IEnumerable<Class> AllBaseClasses
        {
            get
            {
                foreach (Class c in BaseClasses)
                {
                    if (!c.IsSpec)
                    {
                        yield return c;
                    }
                    else
                    {
                        foreach (Class c2 in c.AllBaseClasses)
                        {
                            yield return c2;
                        }
                    }

                }
            }
        }
        public IEnumerable<Class> AllClassCasts
        {
            get
            {
                foreach (Class c in AllBaseClasses)
                {
                    yield return c;
                }
                foreach (Class c in AllBaseClasses)
                {
                    foreach (Class c2 in c.AllClassCasts)
                    {
                        yield return c2;
                    }
                }
            }
        }
        public IEnumerable<Class> AllClassDownCasts
        {
            get
            {
                foreach (Class c in AllBaseClasses)
                {
                    yield return c;
                }
                foreach (Class c in AllBaseClasses)
                {
                    foreach (Class c2 in c.AllClassCasts)
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
                    foreach (Class c in BaseClasses)
                    {
                        if (c.hasConcreteBase)
                            return true;
                    }
                    return false;
                }
                return true;
            }
        }


        public List<Class> OverrideBaseClasses
        {
            get
            {
                int bases = 0;
                int specbases = 0;
                foreach (Class c in BaseClasses)
                {
                    if (c.IsSpec && c.hasConcreteBase)
                        specbases++;
                    else
                        bases++;
                }
                if (bases > 1 || specbases > 0 || IsSpec)
                {
                    return new List<Class>(OverrideBaseClasses2);
                }
                else return new List<Class>();
            }
        }

        public IEnumerable<Class> OverrideBaseClasses2
        {
            get
            {
                foreach (Class cls in BaseClasses)
                {
                    if (!cls.IsSpec)
                        yield return cls;
                    foreach (Class c in cls.OverrideBaseClasses2)
                        yield return c;
                }
            }
        }

        private Class _ParentClass = null;
        public Class ParentClass
        {
            get
            {
                if (_ParentClass == null)
                {
                    foreach (Class cclass in BaseClasses)
                    {
                        if (!cclass.IsSpec)
                        {
                            _ParentClass = cclass;
                            break;
                        }
                    }
                    if (_ParentClass == null)
                    {
                        foreach (Class cclass in AllBaseClasses)
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

        private List<Class> _Aggregates = null;
        /// <summary>
        /// Aggregate classes that can not be inherited because of multiple inheritance, and are accessed via a contained object instead
        /// </summary>
        public List<Class> Aggregates
        {
            get
            {
                if (_Aggregates == null)
                {
                    _Aggregates = new List<Class>();
                    foreach (Class c in AllBaseClasses)
                    {
                        if (c != ParentClass)
                        {
                            bool dupe = false;
                            foreach (Class ac in _Aggregates)
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
            foreach (Class cclass in BaseClasses)
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
            foreach (Class cclass in BaseClasses)
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
        private Parameter _pricingParameter = null;
        private bool _haveSearchedForPricingParemter = false;
        public Parameter PricingParameter()

        {
            if (_haveSearchedForPricingParemter)
                return _pricingParameter;

            foreach (string s in priceClasses)
            {
                if (Name == s)
                {
                    foreach (Method m in Methods)
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
            foreach (Class cclass in BaseClasses)
            {
                Parameter p = cclass.PricingParameter();
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

        public List<Class> Enums
        {
            get
            {
                if (_Enums == null)
                {
                    _Enums = new List<Class>();
                    foreach (KeyValuePair<string, Class> cpair in this.Package.Classes)
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
        public Class(Element element, Package root)
        {
            Name = element.Name;
            Guid = element.GUID;
            Id = element.Id;
            FileName = element.GenFile;
            Package = root.GetById(element.PackageId.Value);
            Element = element;
            IsSpec = !(element.IsSpec);
            if (element.Abstract == "1") _IsAbstract = true;
        }

        Dictionary<int, Class> _ReferencedClasses = null;
        public Dictionary<int, Class> ReferencedClasses
        {
            get
            {
                if (_ReferencedClasses == null)
                {
                    _ReferencedClasses = new Dictionary<int, Class>();

                    foreach (Method method in AllMethods)
                    {
                        if (method.ReturnType != null && method.ReturnType.Class != null)
                        {
                            _ReferencedClasses[method.ReturnType.Class.Id] = method.ReturnType.Class;
                        }
                        foreach (KeyValuePair<int, Parameter> pair in method.Parameters)
                        {
                            if (pair.Value.ParameterType.Class != null)
                            {
                                _ReferencedClasses[pair.Value.ParameterType.Class.Id] = pair.Value.ParameterType.Class;
                            }
                        }
                    }
                    foreach (Class cclass in AllBaseClasses)
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
        public Dictionary<int, Package> ReferencedPackages
        {
            get
            {
                Dictionary<int, Package> dict = new Dictionary<int, Package>();

                foreach (KeyValuePair<int, Class> pair in ReferencedClasses)
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
            Package package = this.Package.Parent;
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
            Queue<Method> q = new Queue<Method>();
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
        private List<Method> _overrideMethods = null;
        public List<Method> OverrideMethods
        {
            get
            {
                if (_overrideMethods == null)
                {
                    _overrideMethods = new List<Method>();
                    foreach (Class cls in OverrideBaseClasses)
                    {
                        if (!cls.IsSpec)
                        {
                            cls.TrimDuplicate();
                            foreach (Method m in cls.Methods)
                            {
                                bool dupe = false;
                                foreach (Method m2 in OverrideMethods)
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
                            foreach (Method m in cls.Methods)
                            {
                                bool dupe = false;
                                foreach (Method m2 in Methods)
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

        private List<Method> _AllMethods = null;
        public List<Method> AllMethods
        {
            get
            {
                if (_AllMethods == null)
                {
                    _AllMethods = new List<Method>(Methods);
                    foreach (Class cls in AllBaseClasses)
                    {
                        if (!cls.IsSpec)
                        {
                            cls.TrimDuplicate();
                            foreach (Method m in cls.AllMethods)
                            {
                                bool dupe = false;
                                foreach (Method m2 in Methods)
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
                    foreach (Method m in Methods)
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
        private Dictionary<string, Parameter> _constrctorParameters = null;
        public Dictionary<string, Parameter> ConstructorParameters
        {
            get
            {
                if (_constrctorParameters == null)
                {
                    _constrctorParameters = new Dictionary<string, Parameter>();
                    foreach (Method m in Methods)
                    {
                        if (m.Name == Name)
                            foreach (KeyValuePair<int, Parameter> p in m.Parameters)
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
}
