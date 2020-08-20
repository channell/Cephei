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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  A. Elices, Models with time-dependent parameters using transform methods: application to Heston’s model, http://arxiv.org/pdf/0708.2020

  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseTimeDependentHestonModelModel
    ( riskFreeRate                                 : ICell<Handle<YieldTermStructure>>
    , dividendYield                                : ICell<Handle<YieldTermStructure>>
    , s0                                           : ICell<Handle<Quote>>
    , v0                                           : ICell<double>
    , theta                                        : ICell<Parameter>
    , kappa                                        : ICell<Parameter>
    , sigma                                        : ICell<Parameter>
    , rho                                          : ICell<Parameter>
    , timeGrid                                     : ICell<TimeGrid>
    ) as this =

    inherit Model<PiecewiseTimeDependentHestonModel> ()
(*
    Parameters
*)
    let _riskFreeRate                              = riskFreeRate
    let _dividendYield                             = dividendYield
    let _s0                                        = s0
    let _v0                                        = v0
    let _theta                                     = theta
    let _kappa                                     = kappa
    let _sigma                                     = sigma
    let _rho                                       = rho
    let _timeGrid                                  = timeGrid
(*
    Functions
*)
    let _PiecewiseTimeDependentHestonModel         = cell (fun () -> new PiecewiseTimeDependentHestonModel (riskFreeRate.Value, dividendYield.Value, s0.Value, v0.Value, theta.Value, kappa.Value, sigma.Value, rho.Value, timeGrid.Value))
    let _dividendYield                             = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.dividendYield())
    let _kappa                                     (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.kappa(t.Value))
    let _rho                                       (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.rho(t.Value))
    let _riskFreeRate                              = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.riskFreeRate())
    let _s0                                        = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.s0())
    let _sigma                                     (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.sigma(t.Value))
    let _theta                                     (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.theta(t.Value))
    let _timeGrid                                  = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.timeGrid())
    let _v0                                        = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.v0())
    let _calibrate                                 (instruments : ICell<Generic.List<CalibrationHelper>>) (Method : ICell<OptimizationMethod>) (endCriteria : ICell<EndCriteria>) (additionalConstraint : ICell<Constraint>) (weights : ICell<Generic.List<double>>) (fixParameters : ICell<Generic.List<bool>>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.calibrate(instruments.Value, Method.Value, endCriteria.Value, additionalConstraint.Value, weights.Value, fixParameters.Value)
                                                                     _PiecewiseTimeDependentHestonModel.Value)
    let _constraint                                = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.CONSTRAINT())
    let _endCriteria                               = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.endCriteria())
    let _notifyObservers                           = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.notifyObservers()
                                                                     _PiecewiseTimeDependentHestonModel.Value)
    let _parameters                                = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.parameters())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.registerWith(handler.Value)
                                                                     _PiecewiseTimeDependentHestonModel.Value)
    let _setParams                                 (parameters : ICell<Vector>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.setParams(parameters.Value)
                                                                     _PiecewiseTimeDependentHestonModel.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.unregisterWith(handler.Value)
                                                                     _PiecewiseTimeDependentHestonModel.Value)
    let _update                                    = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.update()
                                                                     _PiecewiseTimeDependentHestonModel.Value)
    let _value                                     (parameters : ICell<Vector>) (instruments : ICell<Generic.List<CalibrationHelper>>)   
                                                   = cell (fun () -> _PiecewiseTimeDependentHestonModel.Value.value(parameters.Value, instruments.Value))
    do this.Bind(_PiecewiseTimeDependentHestonModel)

(* 
    Externally visible/bindable properties
*)
    member this.riskFreeRate                       = _riskFreeRate 
    member this.dividendYield                      = _dividendYield 
    member this.s0                                 = _s0 
    member this.v0                                 = _v0 
    member this.theta                              = _theta 
    member this.kappa                              = _kappa 
    member this.sigma                              = _sigma 
    member this.rho                                = _rho 
    member this.timeGrid                           = _timeGrid 
    member this.DividendYield                      = _dividendYield
    member this.Kappa                              t   
                                                   = _kappa t 
    member this.Rho                                t   
                                                   = _rho t 
    member this.RiskFreeRate                       = _riskFreeRate
    member this.S0                                 = _s0
    member this.Sigma                              t   
                                                   = _sigma t 
    member this.Theta                              t   
                                                   = _theta t 
    member this.TimeGrid                           = _timeGrid
    member this.V0                                 = _v0
    member this.Calibrate                          instruments Method endCriteria additionalConstraint weights fixParameters   
                                                   = _calibrate instruments Method endCriteria additionalConstraint weights fixParameters 
    member this.Constraint                         = _constraint
    member this.EndCriteria                        = _endCriteria
    member this.NotifyObservers                    = _notifyObservers
    member this.Parameters                         = _parameters
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.SetParams                          parameters   
                                                   = _setParams parameters 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.Value                              parameters instruments   
                                                   = _value parameters instruments 
