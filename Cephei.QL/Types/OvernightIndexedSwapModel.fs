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
  Overnight indexed swap: fix vs compounded overnight rate

  </summary> *)
[<AutoSerializable(true)>]
type OvernightIndexedSwapModel
    ( Type                                         : ICell<OvernightIndexedSwap.Type>
    , fixedNominal                                 : ICell<double>
    , fixedSchedule                                : ICell<Schedule>
    , fixedRate                                    : ICell<double>
    , fixedDC                                      : ICell<DayCounter>
    , overnightNominal                             : ICell<double>
    , overnightSchedule                            : ICell<Schedule>
    , overnightIndex                               : ICell<OvernightIndex>
    , spread                                       : ICell<double>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<OvernightIndexedSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _fixedNominal                              = fixedNominal
    let _fixedSchedule                             = fixedSchedule
    let _fixedRate                                 = fixedRate
    let _fixedDC                                   = fixedDC
    let _overnightNominal                          = overnightNominal
    let _overnightSchedule                         = overnightSchedule
    let _overnightIndex                            = overnightIndex
    let _spread                                    = spread
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _OvernightIndexedSwap                      = make (fun () -> withEngine pricingEngine evaluationDate (new OvernightIndexedSwap (Type.Value, fixedNominal.Value, fixedSchedule.Value, fixedRate.Value, fixedDC.Value, overnightNominal.Value, overnightSchedule.Value, overnightIndex.Value, spread.Value)))
    let _fairRate                                  = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fairRate())
    let _fairSpread                                = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fairSpread())
    let _fixedDayCount                             = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedDayCount())
    let _fixedLeg                                  = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedLeg())
    let _fixedLegBPS                               = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedLegBPS())
    let _fixedLegNPV                               = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedLegNPV())
    let _fixedNominal                              = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedNominal())
    let _fixedPaymentFrequency                     = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedPaymentFrequency())
    let _fixedRate                                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedRate())
    let _overnightLeg                              = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightLeg())
    let _overnightLegBPS                           = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightLegBPS())
    let _overnightLegNPV                           = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightLegNPV())
    let _overnightNominal                          = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightNominal())
    let _overnightPaymentFrequency                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightPaymentFrequency())
    let _spread                                    = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).spread())
    let _type                                      = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).TYPE())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).endDiscounts(j.Value))
    let _engine                                    = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).engine)
    let _isExpired                                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).legNPV(j.Value))
    let _maturityDate                              = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).maturityDate())
    let _npvDateDiscount                           = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).payer(j.Value))
    let _startDate                                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).startDiscounts(j.Value))
    let _CASH                                      = cell _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).CASH())
    let _errorEstimate                             = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).errorEstimate())
    let _NPV                                       = cell _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).setPricingEngine(e.Value)
                                                                                           _OvernightIndexedSwap.Value)
    let _valuationDate                             = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).valuationDate())
    do this.Bind(_OvernightIndexedSwap)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new OvernightIndexedSwapModel(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _OvernightIndexedSwap <- v
    static member Cast (p : ICell<OvernightIndexedSwap>) = 
        if p :? OvernightIndexedSwapModel then 
            p :?> OvernightIndexedSwapModel
        else
            let o = new OvernightIndexedSwapModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.fixedNominal                       = _fixedNominal 
    member this.fixedSchedule                      = _fixedSchedule 
    member this.fixedRate                          = _fixedRate 
    member this.fixedDC                            = _fixedDC 
    member this.overnightNominal                   = _overnightNominal 
    member this.overnightSchedule                  = _overnightSchedule 
    member this.overnightIndex                     = _overnightIndex 
    member this.spread                             = _spread 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FairRate                           = _fairRate
    member this.FairSpread                         = _fairSpread
    member this.FixedDayCount                      = _fixedDayCount
    member this.FixedLeg                           = _fixedLeg
    member this.FixedLegBPS                        = _fixedLegBPS
    member this.FixedLegNPV                        = _fixedLegNPV
    member this.FixedNominal                       = _fixedNominal
    member this.FixedPaymentFrequency              = _fixedPaymentFrequency
    member this.FixedRate                          = _fixedRate
    member this.OvernightLeg                       = _overnightLeg
    member this.OvernightLegBPS                    = _overnightLegBPS
    member this.OvernightLegNPV                    = _overnightLegNPV
    member this.OvernightNominal                   = _overnightNominal
    member this.OvernightPaymentFrequency          = _overnightPaymentFrequency
    member this.Spread                             = _spread
    member this.Type1                              = _type
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
  Overnight indexed swap: fix vs compounded overnight rate

  </summary> *)
[<AutoSerializable(true)>]
type OvernightIndexedSwapModel1
    ( Type                                         : ICell<OvernightIndexedSwap.Type>
    , nominal                                      : ICell<double>
    , schedule                                     : ICell<Schedule>
    , fixedRate                                    : ICell<double>
    , fixedDC                                      : ICell<DayCounter>
    , overnightIndex                               : ICell<OvernightIndex>
    , spread                                       : ICell<double>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<OvernightIndexedSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _schedule                                  = schedule
    let _fixedRate                                 = fixedRate
    let _fixedDC                                   = fixedDC
    let _overnightIndex                            = overnightIndex
    let _spread                                    = spread
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _OvernightIndexedSwap                      = make (fun () -> withEngine pricingEngine evaluationDate (new OvernightIndexedSwap (Type.Value, nominal.Value, schedule.Value, fixedRate.Value, fixedDC.Value, overnightIndex.Value, spread.Value)))
    let _fairRate                                  = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fairRate())
    let _fairSpread                                = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fairSpread())
    let _fixedDayCount                             = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedDayCount())
    let _fixedLeg                                  = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedLeg())
    let _fixedLegBPS                               = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedLegBPS())
    let _fixedLegNPV                               = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedLegNPV())
    let _fixedNominal                              = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedNominal())
    let _fixedPaymentFrequency                     = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedPaymentFrequency())
    let _fixedRate                                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).fixedRate())
    let _overnightLeg                              = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightLeg())
    let _overnightLegBPS                           = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightLegBPS())
    let _overnightLegNPV                           = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightLegNPV())
    let _overnightNominal                          = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightNominal())
    let _overnightPaymentFrequency                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).overnightPaymentFrequency())
    let _spread                                    = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).spread())
    let _type                                      = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).TYPE())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).endDiscounts(j.Value))
    let _engine                                    = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).engine)
    let _isExpired                                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).legNPV(j.Value))
    let _maturityDate                              = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).maturityDate())
    let _npvDateDiscount                           = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).payer(j.Value))
    let _startDate                                 = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).startDiscounts(j.Value))
    let _CASH                                      = cell _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).CASH())
    let _errorEstimate                             = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).errorEstimate())
    let _NPV                                       = cell _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).setPricingEngine(e.Value)
                                                                                           _OvernightIndexedSwap.Value)
    let _valuationDate                             = triv _OvernightIndexedSwap (fun () -> (withEvaluationDate _evaluationDate _OvernightIndexedSwap).valuationDate())
    do this.Bind(_OvernightIndexedSwap)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new OvernightIndexedSwapModel1(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _OvernightIndexedSwap <- v
    static member Cast (p : ICell<OvernightIndexedSwap>) = 
        if p :? OvernightIndexedSwapModel1 then 
            p :?> OvernightIndexedSwapModel1
        else
            let o = new OvernightIndexedSwapModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.schedule                           = _schedule 
    member this.fixedRate                          = _fixedRate 
    member this.fixedDC                            = _fixedDC 
    member this.overnightIndex                     = _overnightIndex 
    member this.spread                             = _spread 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FairRate                           = _fairRate
    member this.FairSpread                         = _fairSpread
    member this.FixedDayCount                      = _fixedDayCount
    member this.FixedLeg                           = _fixedLeg
    member this.FixedLegBPS                        = _fixedLegBPS
    member this.FixedLegNPV                        = _fixedLegNPV
    member this.FixedNominal                       = _fixedNominal
    member this.FixedPaymentFrequency              = _fixedPaymentFrequency
    member this.FixedRate                          = _fixedRate
    member this.OvernightLeg                       = _overnightLeg
    member this.OvernightLegBPS                    = _overnightLegBPS
    member this.OvernightLegNPV                    = _overnightLegNPV
    member this.OvernightNominal                   = _overnightNominal
    member this.OvernightPaymentFrequency          = _overnightPaymentFrequency
    member this.Spread                             = _spread
    member this.Type1                              = _type
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
