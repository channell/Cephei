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
using EA.Gen.Model;
using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.FSharp.Core.OptimizedClosures;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using System.Dynamic;

namespace Cephei.Gen.NetModel
{
    public class Context
    {
        private EA.Gen.Model.ISparx _db;

        public Context()
        {
            var c = ConfigurationManager.ConnectionStrings["Sparx"];

            if (c.ProviderName.Contains("Jet"))
                _db = new EA.Gen.Model.Jet.Sparx();
            else
                _db = new EA.Gen.Model.Sparx();
        }


        public ISparx DB => _db;

        private Package root;

        public Package getPackage(string guid)
        {
            if (root != null)
            {
                var p = root.getPackage(guid);
                root.Link();
                if (p != null)
                    return p;
            }
            root = new Package(guid);
            return root;
        }

        public static Lazy<Context> Current = new Lazy<Context>();

        public static Lazy<EA.Gen.Model.IOperation[]> Operations = new Lazy<IOperation[]>(() =>
           (from r in Current.Value.DB.Operations
            where !(r.Name.EndsWith("Arguments") || r.Name.EndsWith("Results"))
            orderby new { r.ElementId, r.Name }
            select r).ToArray());

        public static Lazy<EA.Gen.Model.IOperationParam[]> Paremters = new Lazy<IOperationParam[]>(() =>
           (from r in Current.Value.DB.OperationParams
            orderby new { r.OperationId, r.Pos }
            select r).ToArray());

        public static Lazy<EA.Gen.Model.IConnector[]> Generalisation = new Lazy<IConnector[]>(() =>
           (from r in Current.Value.DB.Connectors
            where r.ConnectorType == "Generalization" &&
                  r.StartElementId.HasValue &&
                  r.EndElementId.HasValue
            orderby r.StartElementId
            select r).ToArray());

        public static Lazy<EA.Gen.Model.IConnector[]> Realisation = new Lazy<IConnector[]>(() =>
           (from r in Current.Value.DB.Connectors
            where r.ConnectorType == "Realisation" &&
                  r.StartElementId.HasValue &&
                  r.EndElementId.HasValue
            orderby r.StartElementId
            select r).ToArray());

        public static Lazy<Xref[]> TemplateRef = new Lazy<Xref[]>(() =>
           (from r in Context.Current.Value.DB.Xrefs
            where r.Type == "element property"
               && r.Description.Contains("Type=ClassifierTemplateParameter")
            select r).ToArray());

        public static SortedSet<string> Keywords = new SortedSet<string>
        { "abstract", "and", "as", "asr", "assert", "atomic", "base", "begin", "break", "checked", "class", "component", "const", "constraint", "constructor", "continue", "default"
        , "delegate", "do", "done", "downcast", "downto", "eager", "elif", "else", "end", "event", "exception", "extern", "external", "finally", "fixed", "for", "fun", "function", "functor"
        , "global", "if", "in", "include", "inherit", "inline", "interface", "internal", "land", "lazy", "let", "lor", "lsl", "lsr", "lxor", "match", "member", "method", "mixin", "mod"
        , "module", "mutable", "namespace", "new", "not", "null", "object", "of", "open", "or", "override", "parallel", "private", "process", "protected", "public", "pure", "rec"
        , "return", "sealed", "select", "sig", "static", "struct", "tailcall", "then", "to", "trait", "try", "type", "upcast", "use", "val", "virtual", "void", "volatile", "when", "while", "with", "yield"};

    }
}
        