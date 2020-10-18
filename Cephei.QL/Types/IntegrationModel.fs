(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type IntegrationModel
    () as this =
    inherit Model<Integration> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Integration                               = cell (fun () -> new Integration ())
    let _calculate                                 (c_inf : ICell<double>) (f : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _Integration.Value.calculate(c_inf.Value, f.Value))
    let _isAdaptiveIntegration                     = cell (fun () -> _Integration.Value.isAdaptiveIntegration())
    let _numberOfEvaluations                       = cell (fun () -> _Integration.Value.numberOfEvaluations())
    do this.Bind(_Integration)
(* 
    casting 
*)
    
    member internal this.Inject v = _Integration <- v
    static member Cast (p : ICell<Integration>) = 
        if p :? IntegrationModel then 
            p :?> IntegrationModel
        else
            let o = new IntegrationModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<Integration>) = 
        if p :? IntegrationModel then 
            p :?> IntegrationModel
        else
            let o = new IntegrationModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Calculate                          c_inf f   
                                                   = _calculate c_inf f 
    member this.IsAdaptiveIntegration              = _isAdaptiveIntegration
    member this.NumberOfEvaluations                = _numberOfEvaluations
