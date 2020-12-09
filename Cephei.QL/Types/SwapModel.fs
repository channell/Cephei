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
Interest rate swap The cash flows belonging to the first leg are paid; the ones belonging to the second leg are received.
Multi leg constructor.
  </summary> *)
[<AutoSerializable(true)>]
type SwapModel
    ( legs                                         : ICell<Generic.List<Generic.List<CashFlow>>>
    , payer                                        : ICell<Generic.List<bool>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Swap> ()
(*
    Parameters
*)
    let _legs                                      = legs
    let _payer                                     = payer
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _Swap                                      = cell (fun () -> withEngine pricingEngine evaluationDate (new Swap (legs.Value, payer.Value)))
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _Swap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _Swap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).setPricingEngine(e.Value)
                                                                     _Swap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).valuationDate())
    do this.Bind(_Swap)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SwapModel(null,null,null,null)
    member internal this.Inject v = _Swap <- v
    static member Cast (p : ICell<Swap>) = 
        if p :? SwapModel then 
            p :?> SwapModel
        else
            let o = new SwapModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.legs                               = _legs 
    member this.payer                              = _payer 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.EndDiscounts                       j   
                                                   = _endDiscounts j 
    member this.Engine                             = _engine
    member this.IsExpired                          = _isExpired
    member this.Leg                                j   
                                                   = _leg j 
    member this.LegBPS                             j   
                                                   = _legBPS j 
    member this.LegNPV                             j   
                                                   = _legNPV j 
    member this.MaturityDate                       = _maturityDate
    member this.NpvDateDiscount                    = _npvDateDiscount
    member this.Payer                              j   
                                                   = _payer j 
    member this.StartDate                          = _startDate
    member this.StartDiscounts                     j   
                                                   = _startDiscounts j 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
(* <summary>
Interest rate swap The cash flows belonging to the first leg are paid; the ones belonging to the second leg are received.
The cash flows belonging to the first leg are paid the ones belonging to the second leg are received.
  </summary> *)
[<AutoSerializable(true)>]
type SwapModel1
    ( firstLeg                                     : ICell<Generic.List<CashFlow>>
    , secondLeg                                    : ICell<Generic.List<CashFlow>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Swap> ()
(*
    Parameters
*)
    let _firstLeg                                  = firstLeg
    let _secondLeg                                 = secondLeg
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _Swap                                      = cell (fun () -> withEngine pricingEngine evaluationDate (new Swap (firstLeg.Value, secondLeg.Value)))
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _Swap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _Swap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).setPricingEngine(e.Value)
                                                                     _Swap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Swap).valuationDate())
    do this.Bind(_Swap)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SwapModel1(null,null,null,null)
    member internal this.Inject v = _Swap <- v
    static member Cast (p : ICell<Swap>) = 
        if p :? SwapModel1 then 
            p :?> SwapModel1
        else
            let o = new SwapModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.firstLeg                           = _firstLeg 
    member this.secondLeg                          = _secondLeg 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.EndDiscounts                       j   
                                                   = _endDiscounts j 
    member this.Engine                             = _engine
    member this.IsExpired                          = _isExpired
    member this.Leg                                j   
                                                   = _leg j 
    member this.LegBPS                             j   
                                                   = _legBPS j 
    member this.LegNPV                             j   
                                                   = _legNPV j 
    member this.MaturityDate                       = _maturityDate
    member this.NpvDateDiscount                    = _npvDateDiscount
    member this.Payer                              j   
                                                   = _payer j 
    member this.StartDate                          = _startDate
    member this.StartDiscounts                     j   
                                                   = _startDiscounts j 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
