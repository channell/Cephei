using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA.Gen.Model.Jet;
using M = EA.Gen.Model.Jet;

namespace Cephei.Gen.Model
{
    /// <summary>
    /// Extension methods to the EA.Gen.Model.Jet type library 
    /// </summary>
    public static class EAExtensions
    {
        /// <summary>
        /// get the base classes for the curent element 
        /// </summary>
        /// <param name="e">current element</param>
        /// <param name="ctx">the connection context</param>
        /// <returns>collection of element</returns>
        public static IEnumerable<Element> BaseClasses(this Element e, Sparx ctx)
        {
            foreach (var v in from r in ctx.Connectors.Include("EndElement")
                              where r.StartElementId == e.Id && r.EndElementId != null
                              && r.ConnectorType== "Generalization"
                              select r.EndElement)
                if (v != null)
                    yield return v;
        }

        public static IEnumerable<M.Package> Models(this Sparx ctx)
        {
            return from r in ctx.Packages
                   where r.ParentId == 0
                   select r;
        }

        /// <summary>
        /// Determine whether the class is a template by inspecting the properties
        /// </summary>
        /// <param name="e"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static bool IsTempleClass (this Element e, Sparx ctx)
        {
            var xref = (from r in ctx.Xrefs
                        where r.Client == e.GUID
                        select r).ToList();
            var temp = (from r in xref
                        where r.Description != null && r.Description.Contains("ClassifierTemplateParameter")
                        select r).Count();
            return (temp > 0);
        }

        public static EA.Gen.Model.Jet.Package GetPackageByID (this Sparx ctx, int id)
        {
            return (from r in ctx.Packages
                    where r.Id == id
                    select r).FirstOrDefault();
        }
    }
}
