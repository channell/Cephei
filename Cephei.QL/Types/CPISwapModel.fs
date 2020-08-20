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
  fixed x zero-inflation, i.e. fixed x CPI(i'th fixing)/CPI(base) versus floating + spread  Note that this does ony the inflation-vs-floating-leg. Extension to inflation-vs-fixed-leg.  is simple - just replace the floating leg with a fixed leg.  Typically there are notional exchanges at the end: either inflated-notional vs notional; or just (inflated-notional - notional) vs zero.  The latter is perhaphs more typical. Setting subtractInflationNominal to true means that the original inflation nominal is subtracted from both nominals before they are exchanged, even if they are different.  This swap can mimic a ZCIIS where [(1+q)^n - 1] is exchanged against (cpi ratio - 1), by using differnt nominals on each leg and setting subtractInflationNominal to true.  ALSO - there must be just one date in each schedule.  The two legs can have different schedules, fixing (days vs lag), settlement, and roll conventions.  N.B. accrual adjustment periods are already in the schedules.  Trade date and swap settlement date are outside the scope of the instrument.

  </summary> *)
[<AutoSerializable(true)>]
type CPISwapModel
    ( Type                                         : ICell<CPISwap.Type>
    , nominal                                      : ICell<double>
    , subtractInflationNominal                     : ICell<bool>
    , spread                                       : ICell<double>
    , floatDayCount                                : ICell<DayCounter>
    , floatSchedule                                : ICell<Schedule>
    , floatPaymentRoll                             : ICell<BusinessDayConvention>
    , fixingDays                                   : ICell<int>
    , floatIndex                                   : ICell<IborIndex>
    , fixedRate                                    : ICell<double>
    , baseCPI                                      : ICell<double>
    , fixedDayCount                                : ICell<DayCounter>
    , fixedSchedule                                : ICell<Schedule>
    , fixedPaymentRoll                             : ICell<BusinessDayConvention>
    , observationLag                               : ICell<Period>
    , fixedIndex                                   : ICell<ZeroInflationIndex>
    , observationInterpolation                     : ICell<InterpolationType>
    , inflationNominal                             : ICell<Nullable<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CPISwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _subtractInflationNominal                  = subtractInflationNominal
    let _spread                                    = spread
    let _floatDayCount                             = floatDayCount
    let _floatSchedule                             = floatSchedule
    let _floatPaymentRoll                          = floatPaymentRoll
    let _fixingDays                                = fixingDays
    let _floatIndex                                = floatIndex
    let _fixedRate                                 = fixedRate
    let _baseCPI                                   = baseCPI
    let _fixedDayCount                             = fixedDayCount
    let _fixedSchedule                             = fixedSchedule
    let _fixedPaymentRoll                          = fixedPaymentRoll
    let _observationLag                            = observationLag
    let _fixedIndex                                = fixedIndex
    let _observationInterpolation                  = observationInterpolation
    let _inflationNominal                          = inflationNominal
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CPISwap                                   = cell (fun () -> withEngine _pricingEngine.Value (new CPISwap (Type.Value, nominal.Value, subtractInflationNominal.Value, spread.Value, floatDayCount.Value, floatSchedule.Value, floatPaymentRoll.Value, fixingDays.Value, floatIndex.Value, fixedRate.Value, baseCPI.Value, fixedDayCount.Value, fixedSchedule.Value, fixedPaymentRoll.Value, observationLag.Value, fixedIndex.Value, observationInterpolation.Value, inflationNominal.Value)))
    let _baseCPI                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).baseCPI())
    let _cpiLeg                                    = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).cpiLeg())
    let _fairRate                                  = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fairRate())
    let _fairSpread                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fairSpread())
    let _fixedDayCount                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fixedDayCount())
    let _fixedIndex                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fixedIndex())
    let _fixedLegNPV                               = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fixedLegNPV())
    let _fixedPaymentRoll                          = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fixedPaymentRoll())
    let _fixedRate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fixedRate())
    let _fixedSchedule                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fixedSchedule())
    let _fixingDays                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).fixingDays())
    let _floatDayCount                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).floatDayCount())
    let _floatIndex                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).floatIndex())
    let _floatLeg                                  = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).floatLeg())
    let _floatLegNPV                               = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).floatLegNPV())
    let _floatPaymentRoll                          = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).floatPaymentRoll())
    let _floatSchedule                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).floatSchedule())
    let _inflationNominal                          = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).inflationNominal())
    let _nominal                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).nominal())
    let _observationInterpolation                  = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).observationInterpolation())
    let _observationLag                            = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).observationLag())
    let _spread                                    = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).spread())
    let _subtractInflationNominal                  = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).subtractInflationNominal())
    let _type                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).TYPE())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).endDiscounts(j.Value))
    let _engine                                    = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).engine)
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).legNPV(j.Value))
    let _maturityDate                              = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).maturityDate())
    let _npvDateDiscount                           = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).payer(j.Value))
    let _startDate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).setPricingEngine(e.Value)
                                                                     _CPISwap.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPISwap).valuationDate())
    do this.Bind(_CPISwap)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.subtractInflationNominal           = _subtractInflationNominal 
    member this.spread                             = _spread 
    member this.floatDayCount                      = _floatDayCount 
    member this.floatSchedule                      = _floatSchedule 
    member this.floatPaymentRoll                   = _floatPaymentRoll 
    member this.fixingDays                         = _fixingDays 
    member this.floatIndex                         = _floatIndex 
    member this.fixedRate                          = _fixedRate 
    member this.baseCPI                            = _baseCPI 
    member this.fixedDayCount                      = _fixedDayCount 
    member this.fixedSchedule                      = _fixedSchedule 
    member this.fixedPaymentRoll                   = _fixedPaymentRoll 
    member this.observationLag                     = _observationLag 
    member this.fixedIndex                         = _fixedIndex 
    member this.observationInterpolation           = _observationInterpolation 
    member this.inflationNominal                   = _inflationNominal 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.BaseCPI                            = _baseCPI
    member this.CpiLeg                             = _cpiLeg
    member this.FairRate                           = _fairRate
    member this.FairSpread                         = _fairSpread
    member this.FixedDayCount                      = _fixedDayCount
    member this.FixedIndex                         = _fixedIndex
    member this.FixedLegNPV                        = _fixedLegNPV
    member this.FixedPaymentRoll                   = _fixedPaymentRoll
    member this.FixedRate                          = _fixedRate
    member this.FixedSchedule                      = _fixedSchedule
    member this.FixingDays                         = _fixingDays
    member this.FloatDayCount                      = _floatDayCount
    member this.FloatIndex                         = _floatIndex
    member this.FloatLeg                           = _floatLeg
    member this.FloatLegNPV                        = _floatLegNPV
    member this.FloatPaymentRoll                   = _floatPaymentRoll
    member this.FloatSchedule                      = _floatSchedule
    member this.InflationNominal                   = _inflationNominal
    member this.Nominal                            = _nominal
    member this.ObservationInterpolation           = _observationInterpolation
    member this.ObservationLag                     = _observationLag
    member this.Spread                             = _spread
    member this.SubtractInflationNominal           = _subtractInflationNominal
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
