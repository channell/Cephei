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
===========================================================================// CouponSelectorToSetPricer                         // ===========================================================================

  </summary> *)
[<AutoSerializable(true)>]
type PricerSetterModel
    ( pricer                                       : ICell<FloatingRateCouponPricer>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<PricerSetter> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricer                                    = pricer
(*
    Functions
*)
    let mutable
        _PricerSetter                              = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new PricerSetter (pricer.Value))))
    let _visit                                     (c : ICell<RangeAccrualFloatersCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit1                                    (c : ICell<DigitalCmsCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit2                                    (c : ICell<CappedFlooredIborCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit3                                    (o : ICell<Object>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(o.Value)
                                                                                   _PricerSetter.Value)
    let _visit4                                    (c : ICell<CashFlow>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit5                                    (c : ICell<CmsCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit6                                    (c : ICell<Coupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit7                                    (c : ICell<FloatingRateCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit8                                    (c : ICell<CappedFlooredCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit9                                    (c : ICell<IborCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit10                                   (c : ICell<DigitalIborCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    let _visit11                                   (c : ICell<CappedFlooredCmsCoupon>)   
                                                   = triv _PricerSetter (fun () -> (curryEvaluationDate _evaluationDate _PricerSetter).Value.visit(c.Value)
                                                                                   _PricerSetter.Value)
    do this.Bind(_PricerSetter)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new PricerSetterModel(null,null)
    member internal this.Inject v = _PricerSetter <- v
    static member Cast (p : ICell<PricerSetter>) = 
        if p :? PricerSetterModel then 
            p :?> PricerSetterModel
        else
            let o = new PricerSetterModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.pricer                             = _pricer 
    member this.Visit                              c   
                                                   = _visit c 
    member this.Visit1                             c   
                                                   = _visit1 c 
    member this.Visit2                             c   
                                                   = _visit2 c 
    member this.Visit3                             o   
                                                   = _visit3 o 
    member this.Visit4                             c   
                                                   = _visit4 c 
    member this.Visit5                             c   
                                                   = _visit5 c 
    member this.Visit6                             c   
                                                   = _visit6 c 
    member this.Visit7                             c   
                                                   = _visit7 c 
    member this.Visit8                             c   
                                                   = _visit8 c 
    member this.Visit9                             c   
                                                   = _visit9 c 
    member this.Visit10                            c   
                                                   = _visit10 c 
    member this.Visit11                            c   
                                                   = _visit11 c 
