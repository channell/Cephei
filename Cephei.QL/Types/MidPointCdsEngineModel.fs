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


  </summary> *)
[<AutoSerializable(true)>]
type MidPointCdsEngineModel
    ( probability                                  : ICell<Handle<DefaultProbabilityTermStructure>>
    , recoveryRate                                 : ICell<double>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , includeSettlementDateFlows                   : ICell<Nullable<bool>>
    ) as this =

    inherit Model<MidPointCdsEngine> ()
(*
    Parameters
*)
    let _probability                               = probability
    let _recoveryRate                              = recoveryRate
    let _discountCurve                             = discountCurve
    let _includeSettlementDateFlows                = includeSettlementDateFlows
(*
    Functions
*)
    let _MidPointCdsEngine                         = cell (fun () -> new MidPointCdsEngine (probability.Value, recoveryRate.Value, discountCurve.Value, includeSettlementDateFlows.Value))
    do this.Bind(_MidPointCdsEngine)
(* 
    casting 
*)
    internal new () = MidPointCdsEngineModel(null,null,null,null)
    member internal this.Inject v = _MidPointCdsEngine.Value <- v
    static member Cast (p : ICell<MidPointCdsEngine>) = 
        if p :? MidPointCdsEngineModel then 
            p :?> MidPointCdsEngineModel
        else
            let o = new MidPointCdsEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.probability                        = _probability 
    member this.recoveryRate                       = _recoveryRate 
    member this.discountCurve                      = _discountCurve 
    member this.includeSettlementDateFlows         = _includeSettlementDateFlows 
