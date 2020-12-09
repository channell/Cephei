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
    let mutable
        _evaluationDate                            = evaluationDate
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
type BPSCalculatorModel
    ( discountCurve                                : ICell<YieldTermStructure>
    ( evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BPSCalculator> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let mutable
        _BPSCalculator                             = cell (fun () -> (withEvaluationDate _evaluationDate new BPSCalculator (discountCurve.Value)))
    let _bps                                       = cell (fun () -> _BPSCalculator.Value.bps())
    let _nonSensNPV                                = cell (fun () -> _BPSCalculator.Value.nonSensNPV())
    let _visit                                     (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _BPSCalculator.Value.visit(cf.Value)
                                                                     _BPSCalculator.Value)
    let _visit1                                    (c : ICell<Coupon>)   
                                                   = cell (fun () -> _BPSCalculator.Value.visit(c.Value)
                                                                     _BPSCalculator.Value)
    let _visit2                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _BPSCalculator.Value.visit(o.Value)
                                                                     _BPSCalculator.Value)
    do this.Bind(_BPSCalculator)
(* 
    casting 
*)
    let mutable
        _evaluationDate                            = evaluationDate
   interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
    internal new () = BPSCalculatorModel(null)
    member internal this.Inject v = _BPSCalculator <- v
    static member Cast (p : ICell<BPSCalculator>) = 
        if p :? BPSCalculatorModel then 
            p :?> BPSCalculatorModel
        else
            let o = new BPSCalculatorModel ()
            o.Inject p\m            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            
(* 
    casting 
*)
    let mutable
        _evaluationDate                            = evaluationDate
   interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
    internal new () = BPSCalculatorModel(null)
    static member Cast (p : ICell<BPSCalculator>) = 
        if p :? BPSCalculatorModel then 
            p :?> BPSCalculatorModel
        else
            let o = new BPSCalculatorModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    let mutable
        _evaluationDate                            = evaluationDate
    member this.discountCurve                      = _discountCurve 
    member this.Bps                                = _bps
    member this.NonSensNPV                         = _nonSensNPV
    member this.Visit                              cf   
                                                   = _visit cf 
    member this.Visit1                             c   
                                                   = _visit1 c 
    member this.Visit2                             o   
                                                   = _visit2 o 
