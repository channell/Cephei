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
type CallableFixedRateBondModel
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , coupons                                      : ICell<Generic.List<double>>
    , accrualDayCounter                            : ICell<DayCounter>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , putCallSchedule                              : ICell<CallabilitySchedule>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CallableFixedRateBond> ()
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
    let _putCallSchedule                           = putCallSchedule
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _CallableFixedRateBond                     = make (fun () -> withEngine pricingEngine evaluationDate (new CallableFixedRateBond (settlementDays.Value, faceAmount.Value, schedule.Value, coupons.Value, accrualDayCounter.Value, paymentConvention.Value, redemption.Value, issueDate.Value, putCallSchedule.Value)))
    let _callability                               = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).callability())
    let _cleanPriceOAS                             (oas : ICell<double>) (engineTS : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (compounding : ICell<Compounding>) (frequency : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).cleanPriceOAS(oas.Value, engineTS.Value, dayCounter.Value, compounding.Value, frequency.Value, settlement.Value))
    let _effectiveConvexity                        (oas : ICell<double>) (engineTS : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (compounding : ICell<Compounding>) (frequency : ICell<Frequency>) (bump : ICell<double>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).effectiveConvexity(oas.Value, engineTS.Value, dayCounter.Value, compounding.Value, frequency.Value, bump.Value))
    let _effectiveDuration                         (oas : ICell<double>) (engineTS : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (compounding : ICell<Compounding>) (frequency : ICell<Frequency>) (bump : ICell<double>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).effectiveDuration(oas.Value, engineTS.Value, dayCounter.Value, compounding.Value, frequency.Value, bump.Value))
    let _impliedVolatility                         (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).impliedVolatility(targetValue.Value, discountCurve.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _OAS                                       (cleanPrice : ICell<double>) (engineTS : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (compounding : ICell<Compounding>) (frequency : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxIterations : ICell<int>) (guess : ICell<double>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).OAS(cleanPrice.Value, engineTS.Value, dayCounter.Value, compounding.Value, frequency.Value, settlement.Value, accuracy.Value, maxIterations.Value, guess.Value))
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).calendar())
    let _cashflows                                 = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).cashflows())
    let _cleanPrice                                = cell _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).isExpired())
    let _issueDate                                 = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).isTradable(d.Value))
    let _maturityDate                              = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).notional(d.Value))
    let _notionals                                 = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).redemption())
    let _redemptions                               = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).settlementValue())
    let _startDate                                 = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).CASH())
    let _errorEstimate                             = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).errorEstimate())
    let _NPV                                       = cell _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).setPricingEngine(e.Value)
                                                                                            _CallableFixedRateBond.Value)
    let _valuationDate                             = triv _CallableFixedRateBond (fun () -> (withEvaluationDate _evaluationDate _CallableFixedRateBond).valuationDate())
    do this.Bind(_CallableFixedRateBond)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new CallableFixedRateBondModel(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CallableFixedRateBond <- v
    static member Cast (p : ICell<CallableFixedRateBond>) = 
        if p :? CallableFixedRateBondModel then 
            p :?> CallableFixedRateBondModel
        else
            let o = new CallableFixedRateBondModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
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
    member this.putCallSchedule                    = _putCallSchedule 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Callability                        = _callability
    member this.CleanPriceOAS                      oas engineTS dayCounter compounding frequency settlement   
                                                   = _cleanPriceOAS oas engineTS dayCounter compounding frequency settlement 
    member this.EffectiveConvexity                 oas engineTS dayCounter compounding frequency bump   
                                                   = _effectiveConvexity oas engineTS dayCounter compounding frequency bump 
    member this.EffectiveDuration                  oas engineTS dayCounter compounding frequency bump   
                                                   = _effectiveDuration oas engineTS dayCounter compounding frequency bump 
    member this.ImpliedVolatility                  targetValue discountCurve accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue discountCurve accuracy maxEvaluations minVol maxVol 
    member this.OAS                                cleanPrice engineTS dayCounter compounding frequency settlement accuracy maxIterations guess   
                                                   = _OAS cleanPrice engineTS dayCounter compounding frequency settlement accuracy maxIterations guess 
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
