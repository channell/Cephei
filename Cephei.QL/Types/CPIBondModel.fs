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
  instruments

  </summary> *)
[<AutoSerializable(true)>]
type CPIBondModel
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , growthOnly                                   : ICell<bool>
    , baseCPI                                      : ICell<double>
    , observationLag                               : ICell<Period>
    , cpiIndex                                     : ICell<ZeroInflationIndex>
    , observationInterpolation                     : ICell<InterpolationType>
    , schedule                                     : ICell<Schedule>
    , fixedRate                                    : ICell<Generic.List<double>>
    , accrualDayCounter                            : ICell<DayCounter>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , issueDate                                    : ICell<Date>
    , paymentCalendar                              : ICell<Calendar>
    , exCouponPeriod                               : ICell<Period>
    , exCouponCalendar                             : ICell<Calendar>
    , exCouponConvention                           : ICell<BusinessDayConvention>
    , exCouponEndOfMonth                           : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CPIBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _growthOnly                                = growthOnly
    let _baseCPI                                   = baseCPI
    let _observationLag                            = observationLag
    let _cpiIndex                                  = cpiIndex
    let _observationInterpolation                  = observationInterpolation
    let _schedule                                  = schedule
    let _fixedRate                                 = fixedRate
    let _accrualDayCounter                         = accrualDayCounter
    let _paymentConvention                         = paymentConvention
    let _issueDate                                 = issueDate
    let _paymentCalendar                           = paymentCalendar
    let _exCouponPeriod                            = exCouponPeriod
    let _exCouponCalendar                          = exCouponCalendar
    let _exCouponConvention                        = exCouponConvention
    let _exCouponEndOfMonth                        = exCouponEndOfMonth
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CPIBond                                   = cell (fun () -> withEngine _pricingEngine.Value (new CPIBond (settlementDays.Value, faceAmount.Value, growthOnly.Value, baseCPI.Value, observationLag.Value, cpiIndex.Value, observationInterpolation.Value, schedule.Value, fixedRate.Value, accrualDayCounter.Value, paymentConvention.Value, issueDate.Value, paymentCalendar.Value, exCouponPeriod.Value, exCouponCalendar.Value, exCouponConvention.Value, exCouponEndOfMonth.Value)))
    let _baseCPI                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).baseCPI())
    let _cpiIndex                                  = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).cpiIndex())
    let _dayCounter                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).dayCounter())
    let _frequency                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).frequency())
    let _growthOnly                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).growthOnly())
    let _observationInterpolation                  = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).observationInterpolation())
    let _observationLag                            = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).observationLag())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).accruedAmount(settlement.Value))
    let _calendar                                  = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).calendar())
    let _cashflows                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).isExpired())
    let _issueDate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).isTradable(d.Value))
    let _maturityDate                              = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).notional(d.Value))
    let _notionals                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).previousCouponRate(settlement.Value))
    let _redemption                                = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).redemption())
    let _redemptions                               = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).settlementDate(date.Value))
    let _settlementDays                            = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).settlementValue())
    let _startDate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).setPricingEngine(e.Value)
                                                                     _CPIBond.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _CPIBond).valuationDate())
    do this.Bind(_CPIBond)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.growthOnly                         = _growthOnly 
    member this.baseCPI                            = _baseCPI 
    member this.observationLag                     = _observationLag 
    member this.cpiIndex                           = _cpiIndex 
    member this.observationInterpolation           = _observationInterpolation 
    member this.schedule                           = _schedule 
    member this.fixedRate                          = _fixedRate 
    member this.accrualDayCounter                  = _accrualDayCounter 
    member this.paymentConvention                  = _paymentConvention 
    member this.issueDate                          = _issueDate 
    member this.paymentCalendar                    = _paymentCalendar 
    member this.exCouponPeriod                     = _exCouponPeriod 
    member this.exCouponCalendar                   = _exCouponCalendar 
    member this.exCouponConvention                 = _exCouponConvention 
    member this.exCouponEndOfMonth                 = _exCouponEndOfMonth 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.BaseCPI                            = _baseCPI
    member this.CpiIndex                           = _cpiIndex
    member this.DayCounter                         = _dayCounter
    member this.Frequency                          = _frequency
    member this.GrowthOnly                         = _growthOnly
    member this.ObservationInterpolation           = _observationInterpolation
    member this.ObservationLag                     = _observationLag
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
