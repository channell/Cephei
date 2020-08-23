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
  From http://help.rmetrics.org/fExoticOptions/LookbackOptions.html :  For a partial-time fixed strike lookback option, the lookback period starts at a predetermined date after the initialization date of the option.  The partial-time fixed strike lookback call option payoff is given by the difference between the maximum observed price of the underlying asset during the lookback period and the fixed strike price. The partial-time fixed strike lookback put option payoff is given by the difference between the fixed strike price and the minimum observed price of the underlying asset during the lookback period. The partial-time fixed strike lookback option is cheaper than a similar standard fixed strike lookback option. Partial-time fixed strike lookback options can be priced analytically using a model introduced by Heynen and Kat (1994).

  </summary> *)
[<AutoSerializable(true)>]
type ContinuousPartialFixedLookbackOptionModel
    ( lookbackPeriodStart                          : ICell<Date>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ContinuousPartialFixedLookbackOption> ()
(*
    Parameters
*)
    let _lookbackPeriodStart                       = lookbackPeriodStart
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _ContinuousPartialFixedLookbackOption      = cell (fun () -> withEngine _pricingEngine.Value (new ContinuousPartialFixedLookbackOption (lookbackPeriodStart.Value, payoff.Value, exercise.Value)))
    let _delta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).delta())
    let _deltaForward                              = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).deltaForward())
    let _dividendRho                               = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).dividendRho())
    let _elasticity                                = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).elasticity())
    let _gamma                                     = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).gamma())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).isExpired())
    let _itmCashProbability                        = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).itmCashProbability())
    let _rho                                       = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).rho())
    let _strikeSensitivity                         = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).strikeSensitivity())
    let _theta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).theta())
    let _thetaPerDay                               = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).thetaPerDay())
    let _vega                                      = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).vega())
    let _exercise                                  = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).exercise())
    let _payoff                                    = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).payoff())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).setPricingEngine(e.Value)
                                                                     _ContinuousPartialFixedLookbackOption.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _ContinuousPartialFixedLookbackOption).valuationDate())
    do this.Bind(_ContinuousPartialFixedLookbackOption)

(* 
    Externally visible/bindable properties
*)
    member this.lookbackPeriodStart                = _lookbackPeriodStart 
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
