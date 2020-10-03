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
  Black-Scholes 1973 calculator class

  </summary> *)
[<AutoSerializable(true)>]
type BlackScholesCalculatorModel
    ( payoff                                       : ICell<StrikedTypePayoff>
    , spot                                         : ICell<double>
    , growth                                       : ICell<double>
    , stdDev                                       : ICell<double>
    , discount                                     : ICell<double>
    ) as this =

    inherit Model<BlackScholesCalculator> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _spot                                      = spot
    let _growth                                    = growth
    let _stdDev                                    = stdDev
    let _discount                                  = discount
(*
    Functions
*)
    let _BlackScholesCalculator                    = cell (fun () -> new BlackScholesCalculator (payoff.Value, spot.Value, growth.Value, stdDev.Value, discount.Value))
    let _delta                                     = triv (fun () -> _BlackScholesCalculator.Value.delta())
    let _elasticity                                = triv (fun () -> _BlackScholesCalculator.Value.elasticity())
    let _gamma                                     = triv (fun () -> _BlackScholesCalculator.Value.gamma())
    let _theta                                     (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesCalculator.Value.theta(maturity.Value))
    let _thetaPerDay                               (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesCalculator.Value.thetaPerDay(maturity.Value))
    let _alpha                                     = triv (fun () -> _BlackScholesCalculator.Value.alpha())
    let _beta                                      = triv (fun () -> _BlackScholesCalculator.Value.beta())
    let _deltaForward                              = triv (fun () -> _BlackScholesCalculator.Value.deltaForward())
    let _dividendRho                               (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesCalculator.Value.dividendRho(maturity.Value))
    let _elasticityForward                         = triv (fun () -> _BlackScholesCalculator.Value.elasticityForward())
    let _gammaForward                              = triv (fun () -> _BlackScholesCalculator.Value.gammaForward())
    let _itmAssetProbability                       = triv (fun () -> _BlackScholesCalculator.Value.itmAssetProbability())
    let _itmCashProbability                        = triv (fun () -> _BlackScholesCalculator.Value.itmCashProbability())
    let _rho                                       (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesCalculator.Value.rho(maturity.Value))
    let _strikeSensitivity                         = triv (fun () -> _BlackScholesCalculator.Value.strikeSensitivity())
    let _value                                     = triv (fun () -> _BlackScholesCalculator.Value.value())
    let _vega                                      (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackScholesCalculator.Value.vega(maturity.Value))
    do this.Bind(_BlackScholesCalculator)
(* 
    casting 
*)
    internal new () = BlackScholesCalculatorModel(null,null,null,null,null)
    member internal this.Inject v = _BlackScholesCalculator.Value <- v
    static member Cast (p : ICell<BlackScholesCalculator>) = 
        if p :? BlackScholesCalculatorModel then 
            p :?> BlackScholesCalculatorModel
        else
            let o = new BlackScholesCalculatorModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.spot                               = _spot 
    member this.growth                             = _growth 
    member this.stdDev                             = _stdDev 
    member this.discount                           = _discount 
    member this.Delta                              = _delta
    member this.Elasticity                         = _elasticity
    member this.Gamma                              = _gamma
    member this.Theta                              maturity   
                                                   = _theta maturity 
    member this.ThetaPerDay                        maturity   
                                                   = _thetaPerDay maturity 
    member this.Alpha                              = _alpha
    member this.Beta                               = _beta
    member this.DeltaForward                       = _deltaForward
    member this.DividendRho                        maturity   
                                                   = _dividendRho maturity 
    member this.ElasticityForward                  = _elasticityForward
    member this.GammaForward                       = _gammaForward
    member this.ItmAssetProbability                = _itmAssetProbability
    member this.ItmCashProbability                 = _itmCashProbability
    member this.Rho                                maturity   
                                                   = _rho maturity 
    member this.StrikeSensitivity                  = _strikeSensitivity
    member this.Value                              = _value
    member this.Vega                               maturity   
                                                   = _vega maturity 
