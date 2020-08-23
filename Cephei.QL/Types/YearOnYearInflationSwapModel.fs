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
  Quoted as a fixed rate K  At start: P_n(0,t_i) N K = P_n(0,t_i) N - 1 where t_M is the maturity time, P_n(0,t) is the nominal discount factor at time t N is the notional, and I(t) is the inflation index value at time t  These instruments have now been changed to follow typical VanillaSwap type design conventions w.r.t. Schedules etc.

  </summary> *)
[<AutoSerializable(true)>]
type YearOnYearInflationSwapModel
    ( Type                                         : ICell<YearOnYearInflationSwap.Type>
    , nominal                                      : ICell<double>
    , fixedSchedule                                : ICell<Schedule>
    , fixedRate                                    : ICell<double>
    , fixedDayCount                                : ICell<DayCounter>
    , yoySchedule                                  : ICell<Schedule>
    , yoyIndex                                     : ICell<YoYInflationIndex>
    , observationLag                               : ICell<Period>
    , spread                                       : ICell<double>
    , yoyDayCount                                  : ICell<DayCounter>
    , paymentCalendar                              : ICell<Calendar>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YearOnYearInflationSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _fixedSchedule                             = fixedSchedule
    let _fixedRate                                 = fixedRate
    let _fixedDayCount                             = fixedDayCount
    let _yoySchedule                               = yoySchedule
    let _yoyIndex                                  = yoyIndex
    let _observationLag                            = observationLag
    let _spread                                    = spread
    let _yoyDayCount                               = yoyDayCount
    let _paymentCalendar                           = paymentCalendar
    let _paymentConvention                         = paymentConvention
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _YearOnYearInflationSwap                   = triv (fun () -> withEngine _pricingEngine.Value (new YearOnYearInflationSwap (Type.Value, nominal.Value, fixedSchedule.Value, fixedRate.Value, fixedDayCount.Value, yoySchedule.Value, yoyIndex.Value, observationLag.Value, spread.Value, yoyDayCount.Value, paymentCalendar.Value, paymentConvention.Value)))
    let _fairRate                                  = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).fairRate())
    let _fairSpread                                = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).fairSpread())
    let _fixedDayCount                             = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).fixedDayCount())
    let _fixedLeg                                  = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).fixedLeg())
    let _fixedLegNPV                               = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).fixedLegNPV())
    let _fixedRate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).fixedRate())
    let _fixedSchedule                             = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).fixedSchedule())
    let _nominal                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).nominal())
    let _observationLag                            = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).observationLag())
    let _paymentCalendar                           = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).paymentCalendar())
    let _paymentConvention                         = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).paymentConvention())
    let _spread                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).spread())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).TYPE())
    let _yoyDayCount                               = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).yoyDayCount())
    let _yoyInflationIndex                         = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).yoyInflationIndex())
    let _yoyLeg                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).yoyLeg())
    let _yoyLegNPV                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).yoyLegNPV())
    let _yoySchedule                               = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).yoySchedule())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).setPricingEngine(e.Value)
                                                                     _YearOnYearInflationSwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YearOnYearInflationSwap).valuationDate())
    do this.Bind(_YearOnYearInflationSwap)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.fixedSchedule                      = _fixedSchedule 
    member this.fixedRate                          = _fixedRate 
    member this.fixedDayCount                      = _fixedDayCount 
    member this.yoySchedule                        = _yoySchedule 
    member this.yoyIndex                           = _yoyIndex 
    member this.observationLag                     = _observationLag 
    member this.spread                             = _spread 
    member this.yoyDayCount                        = _yoyDayCount 
    member this.paymentCalendar                    = _paymentCalendar 
    member this.paymentConvention                  = _paymentConvention 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FairRate                           = _fairRate
    member this.FairSpread                         = _fairSpread
    member this.FixedDayCount                      = _fixedDayCount
    member this.FixedLeg                           = _fixedLeg
    member this.FixedLegNPV                        = _fixedLegNPV
    member this.FixedRate                          = _fixedRate
    member this.FixedSchedule                      = _fixedSchedule
    member this.Nominal                            = _nominal
    member this.ObservationLag                     = _observationLag
    member this.PaymentCalendar                    = _paymentCalendar
    member this.PaymentConvention                  = _paymentConvention
    member this.Spread                             = _spread
    member this.Type1                              = _type
    member this.YoyDayCount                        = _yoyDayCount
    member this.YoyInflationIndex                  = _yoyInflationIndex
    member this.YoyLeg                             = _yoyLeg
    member this.YoyLegNPV                          = _yoyLegNPV
    member this.YoySchedule                        = _yoySchedule
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
