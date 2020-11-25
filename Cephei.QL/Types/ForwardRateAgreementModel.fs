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
  1. Unlike the forward contract conventions on carryable financial assets (stocks, bonds, commodities), the valueDate for a FRA is taken to be the day when the forward loan or deposit begins and when full settlement takes place (based on the NPV of the contract on that date). maturityDate is the date when the forward loan or deposit ends. In fact, the FRA settles and expires on the valueDate, not on the (later) maturityDate. It follows that (maturityDate - valueDate) is the tenor/term of the underlying loan or deposit  2. Choose position type = Long for an "FRA purchase" (future long loan, short deposit [borrower])  3. Choose position type = Short for an "FRA sale" (future short loan, long deposit [lender])  4. If strike is given in the constructor, can calculate the NPV of the contract via NPV().  5. If forward rate is desired/unknown, it can be obtained via forwardRate(). In this case, the strike variable in the constructor is irrelevant and will be ignored. 
<b>Example: </b> FRA.cs valuation of a forward-rate agreement  Add preconditions and tests  Should put an instance of ForwardRateAgreement in the FraRateHelper to ensure consistency with the piecewise yield curve.  Differentiate between BBA (British)/AFB (French) [assumed here] and ABA (Australian) banker conventions in the calculations.  This class still needs to be rigorously tested  instruments

  </summary> *)
[<AutoSerializable(true)>]
type ForwardRateAgreementModel
    ( valueDate                                    : ICell<Date>
    , maturityDate                                 : ICell<Date>
    , Type                                         : ICell<Position.Type>
    , strikeForwardRate                            : ICell<double>
    , notionalAmount                               : ICell<double>
    , index                                        : ICell<IborIndex>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ForwardRateAgreement> ()
(*
    Parameters
*)
    let _valueDate                                 = valueDate
    let _maturityDate                              = maturityDate
    let _Type                                      = Type
    let _strikeForwardRate                         = strikeForwardRate
    let _notionalAmount                            = notionalAmount
    let _index                                     = index
    let _discountCurve                             = discountCurve
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _ForwardRateAgreement                      = cell (fun () -> withEngine pricingEngine (new ForwardRateAgreement (valueDate.Value, maturityDate.Value, Type.Value, strikeForwardRate.Value, notionalAmount.Value, index.Value, discountCurve.Value)))
    let _forwardRate                               = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).forwardRate())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).isExpired())
    let _settlementDate                            = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).settlementDate())
    let _spotIncome                                (t : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).spotIncome(t.Value))
    let _spotValue                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).spotValue())
    let _forwardValue                              = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).forwardValue())
    let _impliedYield                              (underlyingSpotValue : ICell<double>) (forwardValue : ICell<double>) (settlementDate : ICell<Date>) (compoundingConvention : ICell<Compounding>) (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).impliedYield(underlyingSpotValue.Value, forwardValue.Value, settlementDate.Value, compoundingConvention.Value, dayCounter.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).setPricingEngine(e.Value)
                                                                     _ForwardRateAgreement.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ForwardRateAgreement).valuationDate())
    do this.Bind(_ForwardRateAgreement)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ForwardRateAgreementModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _ForwardRateAgreement <- v
    static member Cast (p : ICell<ForwardRateAgreement>) = 
        if p :? ForwardRateAgreementModel then 
            p :?> ForwardRateAgreementModel
        else
            let o = new ForwardRateAgreementModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.valueDate                          = _valueDate 
    member this.maturityDate                       = _maturityDate 
    member this.Type                               = _Type 
    member this.strikeForwardRate                  = _strikeForwardRate 
    member this.notionalAmount                     = _notionalAmount 
    member this.index                              = _index 
    member this.discountCurve                      = _discountCurve 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.ForwardRate                        = _forwardRate
    member this.IsExpired                          = _isExpired
    member this.SettlementDate                     = _settlementDate
    member this.SpotIncome                         t   
                                                   = _spotIncome t 
    member this.SpotValue                          = _spotValue
    member this.ForwardValue                       = _forwardValue
    member this.ImpliedYield                       underlyingSpotValue forwardValue settlementDate compoundingConvention dayCounter   
                                                   = _impliedYield underlyingSpotValue forwardValue settlementDate compoundingConvention dayCounter 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
