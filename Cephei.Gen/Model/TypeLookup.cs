using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cephei.Gen.Model
{
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

        public void Add(string name, string definition, string nativeDefinition, string fileName, int? parentId, int? packageId)
        {
            Item item = new Item();

            item.Name = name;
            item.Definition = definition;
            item.NativeDefinition = nativeDefinition;
            item.FileName = fileName;
            item.ParentID = parentId ?? 0;
            item.PackageID = packageId ?? 0;

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

        public Item FindType(String name, string fileName, int objectId, int? parentid, int? packageid)
        {
            // this class contains the definition
            if (ByParentId.ContainsKey(objectId))
                if (ByParentId[objectId].ContainsKey(name))
                    return ByParentId[objectId][name];

            // this class's parent contains the definition
            if (parentid.HasValue && ByParentId.ContainsKey(parentid.Value))
                if (ByParentId[parentid.Value].ContainsKey(name))
                    return ByParentId[parentid.Value][name];

            // typedef in the same file
            if (ByFileName.ContainsKey(fileName))
                if (ByFileName[fileName].ContainsKey(name))
                    return ByFileName[fileName][name];

            // typedef within the same package
            if (packageid.HasValue && ByPackageId.ContainsKey(packageid.Value))
                if (ByPackageId[packageid.Value].ContainsKey(name))
                    return ByPackageId[packageid.Value][name];

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
}
