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
type MBSFixedRateBondModel
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , faceAmount                                   : ICell<double>
    , startDate                                    : ICell<Date>
    , bondTenor                                    : ICell<Period>
    , originalLength                               : ICell<Period>
    , sinkingFrequency                             : ICell<Frequency>
    , WACRate                                      : ICell<double>
    , PassThroughRate                              : ICell<double>
    , accrualDayCounter                            : ICell<DayCounter>
    , prepayModel                                  : ICell<IPrepayModel>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , issueDate                                    : ICell<Date>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<MBSFixedRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _faceAmount                                = faceAmount
    let _startDate                                 = startDate
    let _bondTenor                                 = bondTenor
    let _originalLength                            = originalLength
    let _sinkingFrequency                          = sinkingFrequency
    let _WACRate                                   = WACRate
    let _PassThroughRate                           = PassThroughRate
    let _accrualDayCounter                         = accrualDayCounter
    let _prepayModel                               = prepayModel
    let _paymentConvention                         = paymentConvention
    let _issueDate                                 = issueDate
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _MBSFixedRateBond                          = cell (fun () -> withEngine pricingEngine (new MBSFixedRateBond (settlementDays.Value, calendar.Value, faceAmount.Value, startDate.Value, bondTenor.Value, originalLength.Value, sinkingFrequency.Value, WACRate.Value, PassThroughRate.Value, accrualDayCounter.Value, prepayModel.Value, paymentConvention.Value, issueDate.Value)))
    let _BondEquivalentYield                       = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).BondEquivalentYield())
    let _BondFactors                               = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).BondFactors())
    let _expectedCashflows                         = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).expectedCashflows())
    let _MonthlyYield                              = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).MonthlyYield())
    let _SMM                                       (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).SMM(d.Value))
    let _dayCounter                                = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).dayCounter())
    let _frequency                                 = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).frequency())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).setPricingEngine(e.Value)
                                                                     _MBSFixedRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _MBSFixedRateBond).valuationDate())
    do this.Bind(_MBSFixedRateBond)
(* 
    casting 
*)
    internal new () = new MBSFixedRateBondModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _MBSFixedRateBond <- v
    static member Cast (p : ICell<MBSFixedRateBond>) = 
        if p :? MBSFixedRateBondModel then 
            p :?> MBSFixedRateBondModel
        else
            let o = new MBSFixedRateBondModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.faceAmount                         = _faceAmount 
    member this.startDate                          = _startDate 
    member this.bondTenor                          = _bondTenor 
    member this.originalLength                     = _originalLength 
    member this.sinkingFrequency                   = _sinkingFrequency 
    member this.WACRate                            = _WACRate 
    member this.PassThroughRate                    = _PassThroughRate 
    member this.accrualDayCounter                  = _accrualDayCounter 
    member this.prepayModel                        = _prepayModel 
    member this.paymentConvention                  = _paymentConvention 
    member this.issueDate                          = _issueDate 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.BondEquivalentYield                = _BondEquivalentYield
    member this.BondFactors                        = _BondFactors
    member this.ExpectedCashflows                  = _expectedCashflows
    member this.MonthlyYield                       = _MonthlyYield
    member this.SMM                                d   
                                                   = _SMM d 
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
