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
type CatBondModel
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , issueDate                                    : ICell<Date>
    , notionalRisk                                 : ICell<NotionalRisk>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CatBond> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _issueDate                                 = issueDate
    let _notionalRisk                              = notionalRisk
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CatBond                                   = cell (fun () -> withEngine pricingEngine (new CatBond (settlementDays.Value, calendar.Value, issueDate.Value, notionalRisk.Value)))
    let _exhaustionProbability                     = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).exhaustionProbability())
    let _expectedLoss                              = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).expectedLoss())
    let _lossProbability                           = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).lossProbability())
    let _accruedAmount                             (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).accruedAmount(settlement.Value))
    let _calendar                                  = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).calendar())
    let _cashflows                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).cashflows())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _CatBond).cleanPrice())
    let _cleanPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CatBond).cleanPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _dirtyPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _CatBond).dirtyPrice())
    let _dirtyPrice1                               (Yield : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).dirtyPrice(Yield.Value, dc.Value, comp.Value, freq.Value, settlement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).isExpired())
    let _issueDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).issueDate())
    let _isTradable                                (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).isTradable(d.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).maturityDate())
    let _nextCashFlowDate                          (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).nextCashFlowDate(settlement.Value))
    let _nextCouponRate                            (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).nextCouponRate(settlement.Value))
    let _notional                                  (d : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).notional(d.Value))
    let _notionals                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).notionals())
    let _previousCashFlowDate                      (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).previousCashFlowDate(settlement.Value))
    let _previousCouponRate                        (settlement : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).previousCouponRate(settlement.Value))
    let _redemption                                = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).redemption())
    let _redemptions                               = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).redemptions())
    let _settlementDate                            (date : ICell<Date>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).settlementDate(date.Value))
    let _settlementDays                            = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).settlementDays())
    let _settlementValue                           (cleanPrice : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).settlementValue(cleanPrice.Value))
    let _settlementValue1                          = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).settlementValue())
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).startDate())
    let _yield                                     (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CatBond).YIELD(dc.Value, comp.Value, freq.Value, accuracy.Value, maxEvaluations.Value))
    let _yield1                                    (cleanPrice : ICell<double>) (dc : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (settlement : ICell<Date>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _CatBond).YIELD(cleanPrice.Value, dc.Value, comp.Value, freq.Value, settlement.Value, accuracy.Value, maxEvaluations.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CatBond).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CatBond).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).setPricingEngine(e.Value)
                                                                     _CatBond.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CatBond).valuationDate())
    do this.Bind(_CatBond)
(* 
    casting 
*)
    internal new () = CatBondModel(null,null,null,null,null,null)
    member internal this.Inject v = _CatBond.Value <- v
    static member Cast (p : ICell<CatBond>) = 
        if p :? CatBondModel then 
            p :?> CatBondModel
        else
            let o = new CatBondModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.issueDate                          = _issueDate 
    member this.notionalRisk                       = _notionalRisk 
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
