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
  floating-rate bond (possibly capped and/or floored)   calculations are tested by checking results against cached values.

  </summary> *)
[<AutoSerializable(true)>]
type FloatingRateBondModel
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , index                                        : ICell<IborIndex>
    , paymentDayCounter                            : ICell<DayCounter>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FloatingRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _schedule                                  = schedule
    let _index                                     = index
    let _paymentDayCounter                         = paymentDayCounter
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FloatingRateBond                          = cell (fun () -> withEngine pricingEngine (new FloatingRateBond (settlementDays.Value, faceAmount.Value, schedule.Value, index.Value, paymentDayCounter.Value)))
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).setPricingEngine(e.Value)
                                                                     _FloatingRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).valuationDate())
    do this.Bind(_FloatingRateBond)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.paymentDayCounter                  = _paymentDayCounter 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
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
  floating-rate bond (possibly capped and/or floored)   calculations are tested by checking results against cached values.

  </summary> *)
[<AutoSerializable(true)>]
type FloatingRateBondModel1
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , index                                        : ICell<IborIndex>
    , paymentDayCounter                            : ICell<DayCounter>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , fixingDays                                   : ICell<int>
    , gearings                                     : ICell<Generic.List<double>>
    , spreads                                      : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FloatingRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _schedule                                  = schedule
    let _index                                     = index
    let _paymentDayCounter                         = paymentDayCounter
    let _paymentConvention                         = paymentConvention
    let _fixingDays                                = fixingDays
    let _gearings                                  = gearings
    let _spreads                                   = spreads
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FloatingRateBond                          = cell (fun () -> withEngine pricingEngine (new FloatingRateBond (settlementDays.Value, faceAmount.Value, schedule.Value, index.Value, paymentDayCounter.Value, paymentConvention.Value, fixingDays.Value, gearings.Value, spreads.Value)))
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).setPricingEngine(e.Value)
                                                                     _FloatingRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).valuationDate())
    do this.Bind(_FloatingRateBond)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.paymentDayCounter                  = _paymentDayCounter 
    member this.paymentConvention                  = _paymentConvention 
    member this.fixingDays                         = _fixingDays 
    member this.gearings                           = _gearings 
    member this.spreads                            = _spreads 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
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
  floating-rate bond (possibly capped and/or floored)   calculations are tested by checking results against cached values.

  </summary> *)
[<AutoSerializable(true)>]
type FloatingRateBondModel2
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , index                                        : ICell<IborIndex>
    , paymentDayCounter                            : ICell<DayCounter>
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

    inherit Model<FloatingRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _schedule                                  = schedule
    let _index                                     = index
    let _paymentDayCounter                         = paymentDayCounter
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
    let _FloatingRateBond                          = cell (fun () -> withEngine pricingEngine (new FloatingRateBond (settlementDays.Value, faceAmount.Value, schedule.Value, index.Value, paymentDayCounter.Value, paymentConvention.Value, fixingDays.Value, gearings.Value, spreads.Value, caps.Value, floors.Value, inArrears.Value, redemption.Value, issueDate.Value)))
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).setPricingEngine(e.Value)
                                                                     _FloatingRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).valuationDate())
    do this.Bind(_FloatingRateBond)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.paymentDayCounter                  = _paymentDayCounter 
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
  floating-rate bond (possibly capped and/or floored)   calculations are tested by checking results against cached values.
public FloatingRateBond(int settlementDays, double faceAmount, Date startDate, Date maturityDate, Frequency couponFrequency, Calendar calendar, IborIndex index, DayCounter accrualDayCounter, BusinessDayConvention accrualConvention = Following, BusinessDayConvention paymentConvention = Following, int fixingDays = Null<Natural>(), List<double> gearings = std::vector<Real>(1, 1.0), List<double> spreads = std::vector<Spread>(1, 0.0), List<double> caps = std::vector<Rate>(), List<double> floors = std::vector<Rate>(), bool inArrears = false, double redemption = 100.0, Date issueDate = Date(), Date stubDate = Date(), DateGeneration.Rule rule = DateGeneration::Backward, bool endOfMonth = false)
  </summary> *)
[<AutoSerializable(true)>]
type FloatingRateBondModel3
    ( settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , startDate                                    : ICell<Date>
    , maturityDate                                 : ICell<Date>
    , couponFrequency                              : ICell<Frequency>
    , calendar                                     : ICell<Calendar>
    , index                                        : ICell<IborIndex>
    , accrualDayCounter                            : ICell<DayCounter>
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

    inherit Model<FloatingRateBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _startDate                                 = startDate
    let _maturityDate                              = maturityDate
    let _couponFrequency                           = couponFrequency
    let _calendar                                  = calendar
    let _index                                     = index
    let _accrualDayCounter                         = accrualDayCounter
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
    let _FloatingRateBond                          = cell (fun () -> withEngine pricingEngine (new FloatingRateBond (settlementDays.Value, faceAmount.Value, startDate.Value, maturityDate.Value, couponFrequency.Value, calendar.Value, index.Value, accrualDayCounter.Value, accrualConvention.Value, paymentConvention.Value, fixingDays.Value, gearings.Value, spreads.Value, caps.Value, floors.Value, inArrears.Value, redemption.Value, issueDate.Value, stubDate.Value, rule.Value, endOfMonth.Value)))
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).setPricingEngine(e.Value)
                                                                     _FloatingRateBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatingRateBond).valuationDate())
    do this.Bind(_FloatingRateBond)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.startDate                          = _startDate 
    member this.maturityDate                       = _maturityDate 
    member this.couponFrequency                    = _couponFrequency 
    member this.calendar                           = _calendar 
    member this.index                              = _index 
    member this.accrualDayCounter                  = _accrualDayCounter 
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
