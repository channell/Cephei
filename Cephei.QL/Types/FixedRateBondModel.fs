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

! simple annual compounding coupon rates
  </summary> *)
[<AutoSerializable(true)>]
type FixedRateBondModel
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , coupons                                      : ICell<Generic.List<double>>
    , accrualDayCounter                            : ICell<DayCounter>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , paymentCalendar                              : ICell<Calendar>
    , exCouponPeriod                               : ICell<Period>
    , exCouponCalendar                             : ICell<Calendar>
    , exCouponConvention                           : ICell<BusinessDayConvention>
    , exCouponEndOfMonth                           : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FixedRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _schedule                                  = schedule
    let _coupons                                   = coupons
    let _accrualDayCounter                         = accrualDayCounter
    let _paymentConvention                         = paymentConvention
    let _redemption                                = redemption
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
    let _FixedRateBond                             = cell (fun () -> withEngine pricingEngine (new FixedRateBond (settlementDays.Value, faceAmount.Value, schedule.Value, coupons.Value, accrualDayCounter.Value, paymentConvention.Value, redemption.Value, issueDate.Value, paymentCalendar.Value, exCouponPeriod.Value, exCouponCalendar.Value, exCouponConvention.Value, exCouponEndOfMonth.Value)))
    let _dayCounter                                = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dayCounter())
    let _frequency                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).frequency())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).setPricingEngine(e.Value)
                                                                     _FixedRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).valuationDate())
    do this.Bind(_FixedRateBond)
(* 
    casting 
*)
    internal new () = FixedRateBondModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedRateBond.Value <- v
    static member Cast (p : ICell<FixedRateBond>) = 
        if p :? FixedRateBondModel then 
            p :?> FixedRateBondModel
        else
            let o = new FixedRateBondModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.schedule                           = _schedule 
    member this.coupons                            = _coupons 
    member this.accrualDayCounter                  = _accrualDayCounter 
    member this.paymentConvention                  = _paymentConvention 
    member this.redemption                         = _redemption 
    member this.issueDate                          = _issueDate 
    member this.paymentCalendar                    = _paymentCalendar 
    member this.exCouponPeriod                     = _exCouponPeriod 
    member this.exCouponCalendar                   = _exCouponCalendar 
    member this.exCouponConvention                 = _exCouponConvention 
    member this.exCouponEndOfMonth                 = _exCouponEndOfMonth 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.DayCounter                         = _dayCounter
    member this.Frequency                          = _frequency
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
(* <summary>

! simple annual compounding coupon rates with internal schedule calculation
  </summary> *)
[<AutoSerializable(true)>]
type FixedRateBondModel1
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , faceAmount                                   : ICell<double>
    , startDate                                    : ICell<Date>
    , maturityDate                                 : ICell<Date>
    , tenor                                        : ICell<Period>
    , coupons                                      : ICell<Generic.List<double>>
    , accrualDayCounter                            : ICell<DayCounter>
    , accrualConvention                            : ICell<BusinessDayConvention>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , stubDate                                     : ICell<Date>
    , rule                                         : ICell<DateGeneration.Rule>
    , endOfMonth                                   : ICell<bool>
    , paymentCalendar                              : ICell<Calendar>
    , exCouponPeriod                               : ICell<Period>
    , exCouponCalendar                             : ICell<Calendar>
    , exCouponConvention                           : ICell<BusinessDayConvention>
    , exCouponEndOfMonth                           : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FixedRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _faceAmount                                = faceAmount
    let _startDate                                 = startDate
    let _maturityDate                              = maturityDate
    let _tenor                                     = tenor
    let _coupons                                   = coupons
    let _accrualDayCounter                         = accrualDayCounter
    let _accrualConvention                         = accrualConvention
    let _paymentConvention                         = paymentConvention
    let _redemption                                = redemption
    let _issueDate                                 = issueDate
    let _stubDate                                  = stubDate
    let _rule                                      = rule
    let _endOfMonth                                = endOfMonth
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
    let _FixedRateBond                             = cell (fun () -> withEngine pricingEngine (new FixedRateBond (settlementDays.Value, calendar.Value, faceAmount.Value, startDate.Value, maturityDate.Value, tenor.Value, coupons.Value, accrualDayCounter.Value, accrualConvention.Value, paymentConvention.Value, redemption.Value, issueDate.Value, stubDate.Value, rule.Value, endOfMonth.Value, paymentCalendar.Value, exCouponPeriod.Value, exCouponCalendar.Value, exCouponConvention.Value, exCouponEndOfMonth.Value)))
    let _dayCounter                                = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dayCounter())
    let _frequency                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).frequency())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).setPricingEngine(e.Value)
                                                                     _FixedRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).valuationDate())
    do this.Bind(_FixedRateBond)
(* 
    casting 
*)
    internal new () = FixedRateBondModel1(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedRateBond.Value <- v
    static member Cast (p : ICell<FixedRateBond>) = 
        if p :? FixedRateBondModel1 then 
            p :?> FixedRateBondModel1
        else
            let o = new FixedRateBondModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.faceAmount                         = _faceAmount 
    member this.startDate                          = _startDate 
    member this.maturityDate                       = _maturityDate 
    member this.tenor                              = _tenor 
    member this.coupons                            = _coupons 
    member this.accrualDayCounter                  = _accrualDayCounter 
    member this.accrualConvention                  = _accrualConvention 
    member this.paymentConvention                  = _paymentConvention 
    member this.redemption                         = _redemption 
    member this.issueDate                          = _issueDate 
    member this.stubDate                           = _stubDate 
    member this.rule                               = _rule 
    member this.endOfMonth                         = _endOfMonth 
    member this.paymentCalendar                    = _paymentCalendar 
    member this.exCouponPeriod                     = _exCouponPeriod 
    member this.exCouponCalendar                   = _exCouponCalendar 
    member this.exCouponConvention                 = _exCouponConvention 
    member this.exCouponEndOfMonth                 = _exCouponEndOfMonth 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.DayCounter                         = _dayCounter
    member this.Frequency                          = _frequency
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FixedRateBondModel2
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , coupons                                      : ICell<Generic.List<InterestRate>>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , paymentCalendar                              : ICell<Calendar>
    , exCouponPeriod                               : ICell<Period>
    , exCouponCalendar                             : ICell<Calendar>
    , exCouponConvention                           : ICell<BusinessDayConvention>
    , exCouponEndOfMonth                           : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FixedRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _schedule                                  = schedule
    let _coupons                                   = coupons
    let _paymentConvention                         = paymentConvention
    let _redemption                                = redemption
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
    let _FixedRateBond                             = cell (fun () -> withEngine pricingEngine (new FixedRateBond (settlementDays.Value, faceAmount.Value, schedule.Value, coupons.Value, paymentConvention.Value, redemption.Value, issueDate.Value, paymentCalendar.Value, exCouponPeriod.Value, exCouponCalendar.Value, exCouponConvention.Value, exCouponEndOfMonth.Value)))
    let _dayCounter                                = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dayCounter())
    let _frequency                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).frequency())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).setPricingEngine(e.Value)
                                                                     _FixedRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FixedRateBond).valuationDate())
    do this.Bind(_FixedRateBond)
(* 
    casting 
*)
    internal new () = FixedRateBondModel2(null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedRateBond.Value <- v
    static member Cast (p : ICell<FixedRateBond>) = 
        if p :? FixedRateBondModel2 then 
            p :?> FixedRateBondModel2
        else
            let o = new FixedRateBondModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.schedule                           = _schedule 
    member this.coupons                            = _coupons 
    member this.paymentConvention                  = _paymentConvention 
    member this.redemption                         = _redemption 
    member this.issueDate                          = _issueDate 
    member this.paymentCalendar                    = _paymentCalendar 
    member this.exCouponPeriod                     = _exCouponPeriod 
    member this.exCouponCalendar                   = _exCouponCalendar 
    member this.exCouponConvention                 = _exCouponConvention 
    member this.exCouponEndOfMonth                 = _exCouponEndOfMonth 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.DayCounter                         = _dayCounter
    member this.Frequency                          = _frequency
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
