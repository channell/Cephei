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
  instruments  - the correctness of the returned value is tested by checking that the price of a payer (resp. receiver) swaption decreases (resp. increases) with the strike. - the correctness of the returned value is tested by checking that the price of a payer (resp. receiver) swaption increases (resp. decreases) with the spread. - the correctness of the returned value is tested by checking it against that of a swaption on a swap with no spread and a correspondingly adjusted fixed rate. - the correctness of the returned value is tested by checking it against a known good value. - the correctness of the returned value of cash settled swaptions is tested by checking the modified annuity against a value calculated without using the Swaption class.   add greeks and explicit exercise lag

  </summary> *)
[<AutoSerializable(true)>]
type SwaptionModel
    ( swap                                         : ICell<VanillaSwap>
    , exercise                                     : ICell<Exercise>
    , delivery                                     : ICell<Settlement.Type>
    , settlementMethod                             : ICell<Settlement.Method>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Swaption> ()
(*
    Parameters
*)
    let _swap                                      = swap
    let _exercise                                  = exercise
    let _delivery                                  = delivery
    let _settlementMethod                          = settlementMethod
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _Swaption                                  = cell (fun () -> withEngine pricingEngine evaluationDate (new Swaption (swap.Value, exercise.Value, delivery.Value, settlementMethod.Value)))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).engine)
    let _impliedVolatility                         (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>) (Type : ICell<VolatilityType>) (displacement : ICell<Nullable<double>>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value, Type.Value, displacement.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).isExpired())
    let _settlementMethod                          = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).settlementMethod())
    let _settlementType                            = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).settlementType())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).TYPE())
    let _underlyingSwap                            = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).underlyingSwap())
    let _validate                                  = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).validate()
                                                                     _Swaption.Value)
    let _exercise                                  = cell (fun () -> (withEvaluationDate _evaluationDate _Swaption).exercise())
    let _payoff                                    = cell (fun () -> (withEvaluationDate _evaluationDate _Swaption).payoff())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _Swaption).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _Swaption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).setPricingEngine(e.Value)
                                                                     _Swaption.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Swaption).valuationDate())
    do this.Bind(_Swaption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SwaptionModel(null,null,null,null,null,null)
    member internal this.Inject v = _Swaption <- v
    static member Cast (p : ICell<Swaption>) = 
        if p :? SwaptionModel then 
            p :?> SwaptionModel
        else
            let o = new SwaptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.swap                               = _swap 
    member this.exercise                           = _exercise 
    member this.delivery                           = _delivery 
    member this.settlementMethod                   = _settlementMethod 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Engine                             = _engine
    member this.ImpliedVolatility                  targetValue discountCurve guess accuracy maxEvaluations minVol maxVol Type displacement   
                                                   = _impliedVolatility targetValue discountCurve guess accuracy maxEvaluations minVol maxVol Type displacement 
    member this.IsExpired                          = _isExpired
    member this.SettlementMethod                   = _settlementMethod
    member this.SettlementType                     = _settlementType
    member this.Type                               = _type
    member this.UnderlyingSwap                     = _underlyingSwap
    member this.Validate                           = _validate
    member this.Exercise                           = _exercise
    member this.Payoff                             = _payoff
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
