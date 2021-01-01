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
type ForwardVanillaOptionModel
    ( moneyness                                    : ICell<double>
    , resetDate                                    : ICell<Date>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ForwardVanillaOption> ()
(*
    Parameters
*)
    let _moneyness                                 = moneyness
    let _resetDate                                 = resetDate
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _ForwardVanillaOption                      = make (fun () -> withEngine pricingEngine evaluationDate (new ForwardVanillaOption (moneyness.Value, resetDate.Value, payoff.Value, exercise.Value)))
    let _delta                                     = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).delta())
    let _deltaForward                              = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).deltaForward())
    let _dividendRho                               = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).dividendRho())
    let _elasticity                                = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).elasticity())
    let _gamma                                     = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).gamma())
    let _isExpired                                 = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).isExpired())
    let _itmCashProbability                        = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).itmCashProbability())
    let _rho                                       = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).rho())
    let _strikeSensitivity                         = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).strikeSensitivity())
    let _theta                                     = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).theta())
    let _thetaPerDay                               = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).thetaPerDay())
    let _vega                                      = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).vega())
    let _exercise                                  = cell _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).exercise())
    let _payoff                                    = cell _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).payoff())
    let _CASH                                      = cell _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).CASH())
    let _errorEstimate                             = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).errorEstimate())
    let _NPV                                       = cell _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).setPricingEngine(e.Value)
                                                                                           _ForwardVanillaOption.Value)
    let _valuationDate                             = triv _ForwardVanillaOption (fun () -> (withEvaluationDate _evaluationDate _ForwardVanillaOption).valuationDate())
    do this.Bind(_ForwardVanillaOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ForwardVanillaOptionModel(null,null,null,null,null,null)
    member internal this.Inject v = _ForwardVanillaOption <- v
    static member Cast (p : ICell<ForwardVanillaOption>) = 
        if p :? ForwardVanillaOptionModel then 
            p :?> ForwardVanillaOptionModel
        else
            let o = new ForwardVanillaOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.moneyness                          = _moneyness 
    member this.resetDate                          = _resetDate 
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Delta                              = _delta
    member this.DeltaForward                       = _deltaForward
    member this.DividendRho                        = _dividendRho
    member this.Elasticity                         = _elasticity
    member this.Gamma                              = _gamma
    member this.IsExpired                          = _isExpired
    member this.ItmCashProbability                 = _itmCashProbability
    member this.Rho                                = _rho
    member this.StrikeSensitivity                  = _strikeSensitivity
    member this.Theta                              = _theta
    member this.ThetaPerDay                        = _thetaPerDay
    member this.Vega                               = _vega
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
