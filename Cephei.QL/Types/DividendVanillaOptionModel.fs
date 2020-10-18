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

  </summary> *)
[<AutoSerializable(true)>]
type DividendVanillaOptionModel
    ( payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<Exercise>
    , dividendDates                                : ICell<Generic.List<Date>>
    , dividends                                    : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DividendVanillaOption> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let _dividendDates                             = dividendDates
    let _dividends                                 = dividends
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _DividendVanillaOption                     = cell (fun () -> withEngine pricingEngine (new DividendVanillaOption (payoff.Value, exercise.Value, dividendDates.Value, dividends.Value)))
    let _impliedVolatility                         (targetValue : ICell<double>) (Process : ICell<GeneralizedBlackScholesProcess>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).impliedVolatility(targetValue.Value, Process.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _delta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).delta())
    let _deltaForward                              = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).deltaForward())
    let _dividendRho                               = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).dividendRho())
    let _elasticity                                = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).elasticity())
    let _gamma                                     = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).gamma())
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).isExpired())
    let _itmCashProbability                        = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).itmCashProbability())
    let _rho                                       = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).rho())
    let _strikeSensitivity                         = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).strikeSensitivity())
    let _theta                                     = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).theta())
    let _thetaPerDay                               = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).thetaPerDay())
    let _vega                                      = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).vega())
    let _exercise                                  = cell (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).exercise())
    let _payoff                                    = cell (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).payoff())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).setPricingEngine(e.Value)
                                                                     _DividendVanillaOption.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _DividendVanillaOption).valuationDate())
    do this.Bind(_DividendVanillaOption)
(* 
    casting 
*)
    internal new () = new DividendVanillaOptionModel(null,null,null,null,null,null)
    member internal this.Inject v = _DividendVanillaOption <- v
    static member Cast (p : ICell<DividendVanillaOption>) = 
        if p :? DividendVanillaOptionModel then 
            p :?> DividendVanillaOptionModel
        else
            let o = new DividendVanillaOptionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.dividendDates                      = _dividendDates 
    member this.dividends                          = _dividends 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.ImpliedVolatility                  targetValue Process accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue Process accuracy maxEvaluations minVol maxVol 
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
