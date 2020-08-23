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
  Square-root stochastic-volatility Heston process This class describes the square root stochastic volatility

  </summary> *)
[<AutoSerializable(true)>]
type HestonProcessModel
    ( riskFreeRate                                 : ICell<Handle<YieldTermStructure>>
    , dividendYield                                : ICell<Handle<YieldTermStructure>>
    , s0                                           : ICell<Handle<Quote>>
    , v0                                           : ICell<double>
    , kappa                                        : ICell<double>
    , theta                                        : ICell<double>
    , sigma                                        : ICell<double>
    , rho                                          : ICell<double>
    , d                                            : ICell<HestonProcess.Discretization>
    ) as this =

    inherit Model<HestonProcess> ()
(*
    Parameters
*)
    let _riskFreeRate                              = riskFreeRate
    let _dividendYield                             = dividendYield
    let _s0                                        = s0
    let _v0                                        = v0
    let _kappa                                     = kappa
    let _theta                                     = theta
    let _sigma                                     = sigma
    let _rho                                       = rho
    let _d                                         = d
(*
    Functions
*)
    let _HestonProcess                             = cell (fun () -> new HestonProcess (riskFreeRate.Value, dividendYield.Value, s0.Value, v0.Value, kappa.Value, theta.Value, sigma.Value, rho.Value, d.Value))
    let _apply                                     (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _HestonProcess.Value.apply(x0.Value, dx.Value))
    let _diffusion                                 (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _HestonProcess.Value.diffusion(t.Value, x.Value))
    let _dividendYield                             = triv (fun () -> _HestonProcess.Value.dividendYield())
    let _drift                                     (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _HestonProcess.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _HestonProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _factors                                   = triv (fun () -> _HestonProcess.Value.factors())
    let _initialValues                             = triv (fun () -> _HestonProcess.Value.initialValues())
    let _kappa                                     = triv (fun () -> _HestonProcess.Value.kappa())
    let _rho                                       = triv (fun () -> _HestonProcess.Value.rho())
    let _riskFreeRate                              = triv (fun () -> _HestonProcess.Value.riskFreeRate())
    let _s0                                        = triv (fun () -> _HestonProcess.Value.s0())
    let _sigma                                     = triv (fun () -> _HestonProcess.Value.sigma())
    let _size                                      = triv (fun () -> _HestonProcess.Value.size())
    let _theta                                     = triv (fun () -> _HestonProcess.Value.theta())
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _HestonProcess.Value.time(d.Value))
    let _v0                                        = triv (fun () -> _HestonProcess.Value.v0())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HestonProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HestonProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HestonProcess.Value.registerWith(handler.Value)
                                                                     _HestonProcess.Value)
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HestonProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HestonProcess.Value.unregisterWith(handler.Value)
                                                                     _HestonProcess.Value)
    let _update                                    = triv (fun () -> _HestonProcess.Value.update()
                                                                     _HestonProcess.Value)
    do this.Bind(_HestonProcess)

(* 
    Externally visible/bindable properties
*)
    member this.riskFreeRate                       = _riskFreeRate 
    member this.dividendYield                      = _dividendYield 
    member this.s0                                 = _s0 
    member this.v0                                 = _v0 
    member this.kappa                              = _kappa 
    member this.theta                              = _theta 
    member this.sigma                              = _sigma 
    member this.rho                                = _rho 
    member this.d                                  = _d 
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.DividendYield                      = _dividendYield
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Factors                            = _factors
    member this.InitialValues                      = _initialValues
    member this.Kappa                              = _kappa
    member this.Rho                                = _rho
    member this.RiskFreeRate                       = _riskFreeRate
    member this.S0                                 = _s0
    member this.Sigma                              = _sigma
    member this.Size                               = _size
    member this.Theta                              = _theta
    member this.Time                               d   
                                                   = _time d 
    member this.V0                                 = _v0
    member this.Covariance                         t0 x0 dt   
                                                   = _covariance t0 x0 dt 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
