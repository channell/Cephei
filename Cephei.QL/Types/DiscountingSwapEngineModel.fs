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
type DiscountingSwapEngineModel
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , includeSettlementDateFlows                   : ICell<Nullable<bool>>
    , settlementDate                               : ICell<Date>
    , npvDate                                      : ICell<Date>
    ) as this =

    inherit Model<DiscountingSwapEngine> ()
(*
    Parameters
*)
    let _discountCurve                             = discountCurve
    let _includeSettlementDateFlows                = includeSettlementDateFlows
    let _settlementDate                            = settlementDate
    let _npvDate                                   = npvDate
(*
    Functions
*)
    let _DiscountingSwapEngine                     = cell (fun () -> new DiscountingSwapEngine (discountCurve.Value, includeSettlementDateFlows.Value, settlementDate.Value, npvDate.Value))
    do this.Bind(_DiscountingSwapEngine)
(* 
    casting 
*)
    internal new () = new DiscountingSwapEngineModel(null,null,null,null)
    member internal this.Inject v = _DiscountingSwapEngine.Value <- v
    static member Cast (p : ICell<DiscountingSwapEngine>) = 
        if p :? DiscountingSwapEngineModel then 
            p :?> DiscountingSwapEngineModel
        else
            let o = new DiscountingSwapEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.includeSettlementDateFlows         = _includeSettlementDateFlows 
    member this.settlementDate                     = _settlementDate 
    member this.npvDate                            = _npvDate 
