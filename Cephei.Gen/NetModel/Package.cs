/*
 * Copyright(C) 2020 Cepheis Ltd(steve.channell@cepheis.com)
 * All rights reserved
 * 
 * This file is part of Cephei Project https://github.com/channell/Cephei
 * 
 * Cephei is open source software, you can redistribute it and/or modify it
 * under the terms of the Cephei license.  You should have received a
 * copy of the license along with this program; if not, license is
 * available at < https://github.com/channell/Cephei/LICENSE>.
 * 
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE.  See the license for more details.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Cephei.Gen.NetModel
{
    public class Package
    {
        public string Name;
        public int Id;
        public string Guid;
        public int? ParentId;
        public Package Parent;
        public List<Package> Children;
        public Dictionary<int, Class> ClasseByIds;
        private List<Class> _ClassByDependancy = null;

        public Package (string guid) 
        {
            var p = (from r in Context.Current.Value.DB.Packages
                     where r.GUID == guid
                     select r).FirstOrDefault();

            if (p != null)
            {
                Name = p.Name;
                Id = p.Id;
                ParentId = p.ParentId;
                Guid = p.GUID;
                Children = new List<Package>(GetPackageByParentId(Id));
            }
        }

        public Package (EA.Gen.Model.IPackage p)
        {
            Name = p.Name;
            Id = p.Id;
            ParentId = p.ParentId;

            Children = new List<Package>(GetPackageByParentId(Id));
        }

        private Dictionary<string, Class> _Classes = null;
        public Dictionary<string, Class> Classes
        {
            get
            {
                if (_Classes == null)
                {
                    _Classes = Class.GetClassesByPackage(this);
                    Link();
                }
                return _Classes;
            }
        }
        public IEnumerable<KeyValuePair<string, string>> GetEnums()
        {
            foreach (var v in from r in Context.Current.Value.DB.Elements
                              join p in Context.Current.Value.DB.Elements on r.ParentID equals p.ParentID into pp
                              from ppp in pp.DefaultIfEmpty()
                              where r.ObjectType == "Enumeration"
                              select new { n = r.Name, pa = ppp.Name })
                yield return new KeyValuePair<string, string>(v.n, v.pa);
        }

        public List<Class> ClassesByDependancy()
        {
            if (_ClassByDependancy != null) return _ClassByDependancy;

            var q = (from r in Classes
                     select r.Value);

            _ClassByDependancy = (from r in q
                                  orderby r.DependancyDepth()
                                  select r).ToList();

            return _ClassByDependancy;
        }

        private bool _linked = false;
        public void Link ()
        {
            if (_linked) return;
            ClasseByIds = (from r in Classes
                           select r.Value).ToDictionary(p => p.Id);
            foreach (var p in Children)
                p.Link();
            foreach (var v in Classes)
                v.Value.Link(ClasseByIds);
            _linked = true;
        }


        public Class FindByStack(Stack<string> q)
        {
            if (q.Peek() == Name)
                q.Pop();
            foreach (var v in Classes)
            {
                var r = v.Value.FindByStack(q, true);
                if (r != null) return r;
            }
            foreach (var v in Children)
            {
                var r = v.FindByStack(q);
                if (r != null) return r;
            }
            return null;
        }

        public Package getPackage (string guid)
        {
            if (guid == Guid) 
                return this;
            else
                foreach(var p in Children)
                {
                    var c = p.getPackage(guid);
                    if (c != null)
                        return c;
                }
            return null;
        }

        public static IEnumerable<Package> GetPackageByParentId(int id)
        {
            var q = (from r in Context.Current.Value.DB.Packages
                     where r.ParentId == id
                     select r).ToArray();

            return from r in q
                   select new Package(r);
        }            
    }
}
