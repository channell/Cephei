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
  Most methods inherited from Bond (such as yield or the yield-based dirtyPrice and cleanPrice) refer to the underlying plain-vanilla bond and do not take convertibility and callability into account.

  </summary> *)
[<AutoSerializable(true)>]
type ConvertibleFixedCouponBondModel
    ( exercise                                     : ICell<Exercise>
    , conversionRatio                              : ICell<double>
    , dividends                                    : ICell<DividendSchedule>
    , callability                                  : ICell<CallabilitySchedule>
    , creditSpread                                 : ICell<Handle<Quote>>
    , issueDate                                    : ICell<Date>
    , settlementDays                               : ICell<int>
    , coupons                                      : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , schedule                                     : ICell<Schedule>
    , redemption                                   : ICell<double>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ConvertibleFixedCouponBond> ()
(*
    Parameters
*)
    let _exercise                                  = exercise
    let _conversionRatio                           = conversionRatio
    let _dividends                                 = dividends
    let _callability                               = callability
    let _creditSpread                              = creditSpread
    let _issueDate                                 = issueDate
    let _settlementDays                            = settlementDays
    let _coupons                                   = coupons
    let _dayCounter                                = dayCounter
    let _schedule                                  = schedule
    let _redemption                                = redemption
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _ConvertibleFixedCouponBond                = cell (fun () -> withEngine _pricingEngine.Value (new ConvertibleFixedCouponBond (exercise.Value, conversionRatio.Value, dividends.Value, callability.Value, creditSpread.Value, issueDate.Value, settlementDays.Value, coupons.Value, dayCounter.Value, schedule.Value, redemption.Value)))
    let _callability                               = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).callability())
    let _conversionRatio                           = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).conversionRatio())
    let _creditSpread                              = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).creditSpread())
    let _dividends                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).dividends())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).setPricingEngine(e.Value)
                                                                     _ConvertibleFixedCouponBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ConvertibleFixedCouponBond).valuationDate())
    do this.Bind(_ConvertibleFixedCouponBond)

(* 
    Externally visible/bindable properties
*)
    member this.exercise                           = _exercise 
    member this.conversionRatio                    = _conversionRatio 
    member this.dividends                          = _dividends 
    member this.callability                        = _callability 
    member this.creditSpread                       = _creditSpread 
    member this.issueDate                          = _issueDate 
    member this.settlementDays                     = _settlementDays 
    member this.coupons                            = _coupons 
    member this.dayCounter                         = _dayCounter 
    member this.schedule                           = _schedule 
    member this.redemption                         = _redemption 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Callability                        = _callability
    member this.ConversionRatio                    = _conversionRatio
    member this.CreditSpread                       = _creditSpread
    member this.Dividends                          = _dividends
    member this.AccruedAmount                      settlement   
                                                   = _accruedAmount settlement 
    member this.Calendar                           = _calendar
    member this.Cashflows                          = _cashflows
    member this.CleanPrice                         = _cleanPrice
    member this.CleanPrice1                        Yield dc comp freq settlement   
                                                   = _cleanPrice1 Yield dc comp freq settlement 
    member this.DirtyPrice                         = _dirtyPrice
    member this.DirtyPrice1                        Yield dc comp freq settlement   
                                                   = _dirtyPrice1 Yield dc comp freq settlement 
    member this.IsExpired                          = _isExpired
    member this.IssueDate                          = _issueDate
    member this.IsTradable                         d   
                                                   = _isTradable d 
    member this.MaturityDate                       = _maturityDate
    member this.NextCashFlowDate                   settlement   
                                                   = _nextCashFlowDate settlement 
    member this.NextCouponRate                     settlement   
                                                   = _nextCouponRate settlement 
    member this.Notional                           d   
                                                   = _notional d 
    member this.Notionals                          = _notionals
    member this.PreviousCashFlowDate               settlement   
                                                   = _previousCashFlowDate settlement 
    member this.PreviousCouponRate                 settlement   
                                                   = _previousCouponRate settlement 
    member this.Redemption                         = _redemption
    member this.Redemptions                        = _redemptions
    member this.SettlementDate                     date   
                                                   = _settlementDate date 
    member this.SettlementDays                     = _settlementDays
    member this.SettlementValue                    cleanPrice   
                                                   = _settlementValue cleanPrice 
    member this.SettlementValue1                   = _settlementValue1
    member this.StartDate                          = _startDate
    member this.Yield                              dc comp freq accuracy maxEvaluations   
                                                   = _yield dc comp freq accuracy maxEvaluations 
    member this.Yield1                             cleanPrice dc comp freq settlement accuracy maxEvaluations   
                                                   = _yield1 cleanPrice dc comp freq settlement accuracy maxEvaluations 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
