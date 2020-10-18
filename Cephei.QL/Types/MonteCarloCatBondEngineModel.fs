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
type MonteCarloCatBondEngineModel
    ( catRisk                                      : ICell<CatRisk>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , includeSettlementDateFlows                   : ICell<Nullable<bool>>
    ) as this =

    inherit Model<MonteCarloCatBondEngine> ()
(*
    Parameters
*)
    let _catRisk                                   = catRisk
    let _discountCurve                             = discountCurve
    let _includeSettlementDateFlows                = includeSettlementDateFlows
(*
    Functions
*)
    let mutable
        _MonteCarloCatBondEngine                   = cell (fun () -> new MonteCarloCatBondEngine (catRisk.Value, discountCurve.Value, includeSettlementDateFlows.Value))
    let _discountCurve                             = triv (fun () -> _MonteCarloCatBondEngine.Value.discountCurve())
    do this.Bind(_MonteCarloCatBondEngine)
(* 
    casting 
*)
    internal new () = new MonteCarloCatBondEngineModel(null,null,null)
    member internal this.Inject v = _MonteCarloCatBondEngine <- v
    static member Cast (p : ICell<MonteCarloCatBondEngine>) = 
        if p :? MonteCarloCatBondEngineModel then 
            p :?> MonteCarloCatBondEngineModel
        else
            let o = new MonteCarloCatBondEngineModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.catRisk                            = _catRisk 
    member this.discountCurve                      = _discountCurve 
    member this.includeSettlementDateFlows         = _includeSettlementDateFlows 
    member this.DiscountCurve                      = _discountCurve
