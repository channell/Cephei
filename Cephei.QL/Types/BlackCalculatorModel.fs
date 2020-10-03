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
  When the variance is null, division by zero occur during the calculation of delta, delta forward, gamma, gamma forward, rho, dividend rho, vega, and strike sensitivity.

  </summary> *)
[<AutoSerializable(true)>]
type BlackCalculatorModel
    ( payoff                                       : ICell<StrikedTypePayoff>
    , forward                                      : ICell<double>
    , stdDev                                       : ICell<double>
    , discount                                     : ICell<double>
    ) as this =

    inherit Model<BlackCalculator> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _forward                                   = forward
    let _stdDev                                    = stdDev
    let _discount                                  = discount
(*
    Functions
*)
    let _BlackCalculator                           = cell (fun () -> new BlackCalculator (payoff.Value, forward.Value, stdDev.Value, discount.Value))
    let _alpha                                     = triv (fun () -> _BlackCalculator.Value.alpha())
    let _beta                                      = triv (fun () -> _BlackCalculator.Value.beta())
    let _delta                                     (spot : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.delta(spot.Value))
    let _deltaForward                              = triv (fun () -> _BlackCalculator.Value.deltaForward())
    let _dividendRho                               (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.dividendRho(maturity.Value))
    let _elasticity                                (spot : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.elasticity(spot.Value))
    let _elasticityForward                         = triv (fun () -> _BlackCalculator.Value.elasticityForward())
    let _gamma                                     (spot : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.gamma(spot.Value))
    let _gammaForward                              = triv (fun () -> _BlackCalculator.Value.gammaForward())
    let _itmAssetProbability                       = triv (fun () -> _BlackCalculator.Value.itmAssetProbability())
    let _itmCashProbability                        = triv (fun () -> _BlackCalculator.Value.itmCashProbability())
    let _rho                                       (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.rho(maturity.Value))
    let _strikeSensitivity                         = triv (fun () -> _BlackCalculator.Value.strikeSensitivity())
    let _theta                                     (spot : ICell<double>) (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.theta(spot.Value, maturity.Value))
    let _thetaPerDay                               (spot : ICell<double>) (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.thetaPerDay(spot.Value, maturity.Value))
    let _value                                     = triv (fun () -> _BlackCalculator.Value.value())
    let _vega                                      (maturity : ICell<double>)   
                                                   = triv (fun () -> _BlackCalculator.Value.vega(maturity.Value))
    do this.Bind(_BlackCalculator)
(* 
    casting 
*)
    internal new () = BlackCalculatorModel(null,null,null,null)
    member internal this.Inject v = _BlackCalculator.Value <- v
    static member Cast (p : ICell<BlackCalculator>) = 
        if p :? BlackCalculatorModel then 
            p :?> BlackCalculatorModel
        else
            let o = new BlackCalculatorModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.forward                            = _forward 
    member this.stdDev                             = _stdDev 
    member this.discount                           = _discount 
    member this.Alpha                              = _alpha
    member this.Beta                               = _beta
    member this.Delta                              spot   
                                                   = _delta spot 
    member this.DeltaForward                       = _deltaForward
    member this.DividendRho                        maturity   
                                                   = _dividendRho maturity 
    member this.Elasticity                         spot   
                                                   = _elasticity spot 
    member this.ElasticityForward                  = _elasticityForward
    member this.Gamma                              spot   
                                                   = _gamma spot 
    member this.GammaForward                       = _gammaForward
    member this.ItmAssetProbability                = _itmAssetProbability
    member this.ItmCashProbability                 = _itmCashProbability
    member this.Rho                                maturity   
                                                   = _rho maturity 
    member this.StrikeSensitivity                  = _strikeSensitivity
    member this.Theta                              spot maturity   
                                                   = _theta spot maturity 
    member this.ThetaPerDay                        spot maturity   
                                                   = _thetaPerDay spot maturity 
    member this.Value                              = _value
    member this.Vega                               maturity   
                                                   = _vega maturity 
