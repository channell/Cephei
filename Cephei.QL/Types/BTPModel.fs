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
! constructor needed for legacy non-par redemption BTPs. As of today the only remaining one is IT123456789012 that will redeem 99.999 on xx-may-2037
  </summary> *)
[<AutoSerializable(true)>]
type BTPModel
    ( maturityDate                                 : ICell<Date>
    , fixedRate                                    : ICell<double>
    , redemption                                   : ICell<double>
    , startDate                                    : ICell<Date>
    , issueDate                                    : ICell<Date>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BTP> ()
(*
    Parameters
*)
    let _maturityDate                              = maturityDate
    let _fixedRate                                 = fixedRate
    let _redemption                                = redemption
    let _startDate                                 = startDate
    let _issueDate                                 = issueDate
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _BTP                                       = triv (fun () -> withEngine _pricingEngine.Value (new BTP (maturityDate.Value, fixedRate.Value, redemption.Value, startDate.Value, issueDate.Value)))
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).accruedAmount(d.Value))
    let _yield                                     (cleanPrice : ICell<double>) (settlementDate : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).YIELD(cleanPrice.Value, settlementDate.Value, accuracy.Value, maxEvaluations.Value))
    let _dayCounter                                = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).dayCounter())
    let _frequency                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).frequency())
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).startDate())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).setPricingEngine(e.Value)
                                                                     _BTP.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).valuationDate())
    do this.Bind(_BTP)

(* 
    Externally visible/bindable properties
*)
    member this.maturityDate                       = _maturityDate 
    member this.fixedRate                          = _fixedRate 
    member this.redemption                         = _redemption 
    member this.startDate                          = _startDate 
    member this.issueDate                          = _issueDate 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Yield                              cleanPrice settlementDate accuracy maxEvaluations   
                                                   = _yield cleanPrice settlementDate accuracy maxEvaluations 
    member this.DayCounter                         = _dayCounter
    member this.Frequency                          = _frequency
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
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
(* <summary>
  instruments

  </summary> *)
[<AutoSerializable(true)>]
type BTPModel1
    ( maturityDate                                 : ICell<Date>
    , fixedRate                                    : ICell<double>
    , startDate                                    : ICell<Date>
    , issueDate                                    : ICell<Date>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BTP> ()
(*
    Parameters
*)
    let _maturityDate                              = maturityDate
    let _fixedRate                                 = fixedRate
    let _startDate                                 = startDate
    let _issueDate                                 = issueDate
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _BTP                                       = triv (fun () -> withEngine _pricingEngine.Value (new BTP (maturityDate.Value, fixedRate.Value, startDate.Value, issueDate.Value)))
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).accruedAmount(d.Value))
    let _yield                                     (cleanPrice : ICell<double>) (settlementDate : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).YIELD(cleanPrice.Value, settlementDate.Value, accuracy.Value, maxEvaluations.Value))
    let _dayCounter                                = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).dayCounter())
    let _frequency                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).frequency())
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).startDate())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _BTP).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).setPricingEngine(e.Value)
                                                                     _BTP.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _BTP).valuationDate())
    do this.Bind(_BTP)

(* 
    Externally visible/bindable properties
*)
    member this.maturityDate                       = _maturityDate 
    member this.fixedRate                          = _fixedRate 
    member this.startDate                          = _startDate 
    member this.issueDate                          = _issueDate 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Yield                              cleanPrice settlementDate accuracy maxEvaluations   
                                                   = _yield cleanPrice settlementDate accuracy maxEvaluations 
    member this.DayCounter                         = _dayCounter
    member this.Frequency                          = _frequency
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
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
