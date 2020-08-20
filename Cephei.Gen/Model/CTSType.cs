using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Gen.Model
{

    public class CTSType
    {
        public const string FSharpOption = "Microsoft.FSharp.Core.FSharpOption<";

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
        public Class Class;
        public bool isOptional;


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

            Package package = Class.Package;
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

            Package package = Class.Package;
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

            Package package = Class.Package;
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

            Package package = Class.Package;
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
}
