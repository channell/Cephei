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
type FloatingCatBondModel
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , startDate                                    : ICell<Date>
    , maturityDate                                 : ICell<Date>
    , couponFrequency                              : ICell<Frequency>
    , calendar                                     : ICell<Calendar>
    , iborIndex                                    : ICell<IborIndex>
    , accrualDayCounter                            : ICell<DayCounter>
    , notionalRisk                                 : ICell<NotionalRisk>
    , accrualConvention                            : ICell<BusinessDayConvention>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , fixingDays                                   : ICell<int>
    , gearings                                     : ICell<Generic.List<double>>
    , spreads                                      : ICell<Generic.List<double>>
    , caps                                         : ICell<List<Nullable<double>>>
    , floors                                       : ICell<List<Nullable<double>>>
    , inArrears                                    : ICell<bool>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , stubDate                                     : ICell<Date>
    , rule                                         : ICell<DateGeneration.Rule>
    , endOfMonth                                   : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FloatingCatBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _startDate                                 = startDate
    let _maturityDate                              = maturityDate
    let _couponFrequency                           = couponFrequency
    let _calendar                                  = calendar
    let _iborIndex                                 = iborIndex
    let _accrualDayCounter                         = accrualDayCounter
    let _notionalRisk                              = notionalRisk
    let _accrualConvention                         = accrualConvention
    let _paymentConvention                         = paymentConvention
    let _fixingDays                                = fixingDays
    let _gearings                                  = gearings
    let _spreads                                   = spreads
    let _caps                                      = caps
    let _floors                                    = floors
    let _inArrears                                 = inArrears
    let _redemption                                = redemption
    let _issueDate                                 = issueDate
    let _stubDate                                  = stubDate
    let _rule                                      = rule
    let _endOfMonth                                = endOfMonth
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FloatingCatBond                           = cell (fun () -> withEngine evaluationDate pricingEngine (new FloatingCatBond (settlementDays.Value, faceAmount.Value, startDate.Value, maturityDate.Value, couponFrequency.Value, calendar.Value, iborIndex.Value, accrualDayCounter.Value, notionalRisk.Value, accrualConvention.Value, paymentConvention.Value, fixingDays.Value, gearings.Value, spreads.Value, caps.Value, floors.Value, inArrears.Value, redemption.Value, issueDate.Value, stubDate.Value, rule.Value, endOfMonth.Value)))
    let _exhaustionProbability                     = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).exhaustionProbability())
    let _expectedLoss                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).expectedLoss())
    let _lossProbability                           = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).lossProbability())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).setPricingEngine(e.Value)
                                                                     _FloatingCatBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).valuationDate())
    do this.Bind(_FloatingCatBond)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.startDate                          = _startDate 
    member this.maturityDate                       = _maturityDate 
    member this.couponFrequency                    = _couponFrequency 
    member this.calendar                           = _calendar 
    member this.iborIndex                          = _iborIndex 
    member this.accrualDayCounter                  = _accrualDayCounter 
    member this.notionalRisk                       = _notionalRisk 
    member this.accrualConvention                  = _accrualConvention 
    member this.paymentConvention                  = _paymentConvention 
    member this.fixingDays                         = _fixingDays 
    member this.gearings                           = _gearings 
    member this.spreads                            = _spreads 
    member this.caps                               = _caps 
    member this.floors                             = _floors 
    member this.inArrears                          = _inArrears 
    member this.redemption                         = _redemption 
    member this.issueDate                          = _issueDate 
    member this.stubDate                           = _stubDate 
    member this.rule                               = _rule 
    member this.endOfMonth                         = _endOfMonth 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.ExhaustionProbability              = _exhaustionProbability
    member this.ExpectedLoss                       = _expectedLoss
    member this.LossProbability                    = _lossProbability
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
type FloatingCatBondModel1
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , iborIndex                                    : ICell<IborIndex>
    , paymentDayCounter                            : ICell<DayCounter>
    , notionalRisk                                 : ICell<NotionalRisk>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , fixingDays                                   : ICell<int>
    , gearings                                     : ICell<Generic.List<double>>
    , spreads                                      : ICell<Generic.List<double>>
    , caps                                         : ICell<List<Nullable<double>>>
    , floors                                       : ICell<List<Nullable<double>>>
    , inArrears                                    : ICell<bool>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FloatingCatBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _schedule                                  = schedule
    let _iborIndex                                 = iborIndex
    let _paymentDayCounter                         = paymentDayCounter
    let _notionalRisk                              = notionalRisk
    let _paymentConvention                         = paymentConvention
    let _fixingDays                                = fixingDays
    let _gearings                                  = gearings
    let _spreads                                   = spreads
    let _caps                                      = caps
    let _floors                                    = floors
    let _inArrears                                 = inArrears
    let _redemption                                = redemption
    let _issueDate                                 = issueDate
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FloatingCatBond                           = cell (fun () -> withEngine evaluationDate pricingEngine (new FloatingCatBond (settlementDays.Value, faceAmount.Value, schedule.Value, iborIndex.Value, paymentDayCounter.Value, notionalRisk.Value, paymentConvention.Value, fixingDays.Value, gearings.Value, spreads.Value, caps.Value, floors.Value, inArrears.Value, redemption.Value, issueDate.Value)))
    let _exhaustionProbability                     = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).exhaustionProbability())
    let _expectedLoss                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).expectedLoss())
    let _lossProbability                           = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).lossProbability())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).setPricingEngine(e.Value)
                                                                     _FloatingCatBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingCatBond).valuationDate())
    do this.Bind(_FloatingCatBond)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.schedule                           = _schedule 
    member this.iborIndex                          = _iborIndex 
    member this.paymentDayCounter                  = _paymentDayCounter 
    member this.notionalRisk                       = _notionalRisk 
    member this.paymentConvention                  = _paymentConvention 
    member this.fixingDays                         = _fixingDays 
    member this.gearings                           = _gearings 
    member this.spreads                            = _spreads 
    member this.caps                               = _caps 
    member this.floors                             = _floors 
    member this.inArrears                          = _inArrears 
    member this.redemption                         = _redemption 
    member this.issueDate                          = _issueDate 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.ExhaustionProbability              = _exhaustionProbability
    member this.ExpectedLoss                       = _expectedLoss
    member this.LossProbability                    = _lossProbability
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
