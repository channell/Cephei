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
  From http://help.rmetrics.org/fExoticOptions/LookbackOptions.html :  For a partial-time floating strike lookback option, the lookback period starts at time zero and ends at an arbitrary date before expiration. Except for the partial lookback period, the option is similar to a floating strike lookback option. The partial-time floating strike lookback option is cheaper than a similar standard floating strike lookback option. Partial-time floating strike lookback options can be priced analytically using a model introduced by Heynen and Kat (1994).

  </summary> *)
[<AutoSerializable(true)>]
type ContinuousPartialFloatingLookbackOptionModel
    ( minmax                                       : ICell<double>
    , lambda                                       : ICell<double>
    , lookbackPeriodEnd                            : ICell<Date>
    , payoff                                       : ICell<TypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ContinuousPartialFloatingLookbackOption> ()
(*
    Parameters
*)
    let _minmax                                    = minmax
    let _lambda                                    = lambda
    let _lookbackPeriodEnd                         = lookbackPeriodEnd
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _ContinuousPartialFloatingLookbackOption   = cell (fun () -> withEngine pricingEngine (new ContinuousPartialFloatingLookbackOption (minmax.Value, lambda.Value, lookbackPeriodEnd.Value, payoff.Value, exercise.Value)))
    let _delta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).delta())
    let _deltaForward                              = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).deltaForward())
    let _dividendRho                               = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).dividendRho())
    let _elasticity                                = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).elasticity())
    let _gamma                                     = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).gamma())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).isExpired())
    let _itmCashProbability                        = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).itmCashProbability())
    let _rho                                       = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).rho())
    let _strikeSensitivity                         = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).strikeSensitivity())
    let _theta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).theta())
    let _thetaPerDay                               = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).thetaPerDay())
    let _vega                                      = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).vega())
    let _exercise                                  = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).exercise())
    let _payoff                                    = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).payoff())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).setPricingEngine(e.Value)
                                                                     _ContinuousPartialFloatingLookbackOption.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFloatingLookbackOption).valuationDate())
    do this.Bind(_ContinuousPartialFloatingLookbackOption)

(* 
    Externally visible/bindable properties
*)
    member this.minmax                             = _minmax 
    member this.lambda                             = _lambda 
    member this.lookbackPeriodEnd                  = _lookbackPeriodEnd 
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
