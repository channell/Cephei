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
type DiscountingLoanEngineModel
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , includeSettlementDateFlows                   : ICell<Nullable<bool>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DiscountingLoanEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _discountCurve                             = discountCurve
    let _includeSettlementDateFlows                = includeSettlementDateFlows
(*
    Functions
*)
    let mutable
        _DiscountingLoanEngine                     = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new DiscountingLoanEngine (discountCurve.Value, includeSettlementDateFlows.Value))))
    let _discountCurve                             = triv (fun () -> (curryEvaluationDate _evaluationDate _DiscountingLoanEngine).Value.discountCurve())
    do this.Bind(_DiscountingLoanEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DiscountingLoanEngineModel(null,null,null)
    member internal this.Inject v = _DiscountingLoanEngine <- v
    static member Cast (p : ICell<DiscountingLoanEngine>) = 
        if p :? DiscountingLoanEngineModel then 
            p :?> DiscountingLoanEngineModel
        else
            let o = new DiscountingLoanEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.includeSettlementDateFlows         = _includeSettlementDateFlows 
    member this.DiscountCurve                      = _discountCurve
