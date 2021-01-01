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
  Continuous-averaging Asian option   add running average  instruments

  </summary> *)
[<AutoSerializable(true)>]
type ContinuousAveragingAsianOptionModel
    ( averageType                                  : ICell<Average.Type>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ContinuousAveragingAsianOption> ()
(*
    Parameters
*)
    let _averageType                               = averageType
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _ContinuousAveragingAsianOption            = make (fun () -> withEngine pricingEngine evaluationDate (new ContinuousAveragingAsianOption (averageType.Value, payoff.Value, exercise.Value)))
    let _delta                                     = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).delta())
    let _deltaForward                              = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).deltaForward())
    let _dividendRho                               = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).dividendRho())
    let _elasticity                                = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).elasticity())
    let _gamma                                     = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).gamma())
    let _isExpired                                 = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).isExpired())
    let _itmCashProbability                        = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).itmCashProbability())
    let _rho                                       = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).rho())
    let _strikeSensitivity                         = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).strikeSensitivity())
    let _theta                                     = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).theta())
    let _thetaPerDay                               = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).thetaPerDay())
    let _vega                                      = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).vega())
    let _exercise                                  = cell _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).exercise())
    let _payoff                                    = cell _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).payoff())
    let _CASH                                      = cell _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).CASH())
    let _errorEstimate                             = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).errorEstimate())
    let _NPV                                       = cell _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).setPricingEngine(e.Value)
                                                                                                     _ContinuousAveragingAsianOption.Value)
    let _valuationDate                             = triv _ContinuousAveragingAsianOption (fun () -> (withEvaluationDate _evaluationDate _ContinuousAveragingAsianOption).valuationDate())
    do this.Bind(_ContinuousAveragingAsianOption)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ContinuousAveragingAsianOptionModel(null,null,null,null,null)
    member internal this.Inject v = _ContinuousAveragingAsianOption <- v
    static member Cast (p : ICell<ContinuousAveragingAsianOption>) = 
        if p :? ContinuousAveragingAsianOptionModel then 
            p :?> ContinuousAveragingAsianOptionModel
        else
            let o = new ContinuousAveragingAsianOptionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.averageType                        = _averageType 
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
