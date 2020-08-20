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
  This class describes the Ornstein-Uhlenbeck process governed by dx = a (r - x_t) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type OrnsteinUhlenbeckProcessModel
    ( speed                                        : ICell<double>
    , vol                                          : ICell<double>
    , x0                                           : ICell<double>
    , level                                        : ICell<double>
    ) as this =

    inherit Model<OrnsteinUhlenbeckProcess> ()
(*
    Parameters
*)
    let _speed                                     = speed
    let _vol                                       = vol
    let _x0                                        = x0
    let _level                                     = level
(*
    Functions
*)
    let _OrnsteinUhlenbeckProcess                  = cell (fun () -> new OrnsteinUhlenbeckProcess (speed.Value, vol.Value, x0.Value, level.Value))
    let _diffusion                                 (UnnamedParameter1 : ICell<double>) (UnnamedParameter2 : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.diffusion(UnnamedParameter1.Value, UnnamedParameter2.Value))
    let _drift                                     (UnnamedParameter1 : ICell<double>) (x : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.drift(UnnamedParameter1.Value, x.Value))
    let _expectation                               (UnnamedParameter1 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.expectation(UnnamedParameter1.Value, x0.Value, dt.Value))
    let _level                                     = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.level())
    let _speed                                     = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.speed())
    let _stdDeviation                              (t : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.stdDeviation(t.Value, x0.Value, dt.Value))
    let _variance                                  (UnnamedParameter1 : ICell<double>) (UnnamedParameter2 : ICell<double>) (dt : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.variance(UnnamedParameter1.Value, UnnamedParameter2.Value, dt.Value))
    let _volatility                                = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.volatility())
    let _x0                                        = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.x0())
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.apply(x0.Value, dx.Value))
    let _apply1                                    (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.apply(x0.Value, dx.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _evolve1                                   (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _initialValues                             = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.initialValues())
    let _size                                      = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.registerWith(handler.Value)
                                                                     _OrnsteinUhlenbeckProcess.Value)
    let _time                                      (d : ICell<Date>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.unregisterWith(handler.Value)
                                                                     _OrnsteinUhlenbeckProcess.Value)
    let _update                                    = cell (fun () -> _OrnsteinUhlenbeckProcess.Value.update()
                                                                     _OrnsteinUhlenbeckProcess.Value)
    do this.Bind(_OrnsteinUhlenbeckProcess)

(* 
    Externally visible/bindable properties
*)
    member this.speed                              = _speed 
    member this.vol                                = _vol 
    member this.x0                                 = _x0 
    member this.level                              = _level 
    member this.Diffusion                          UnnamedParameter1 UnnamedParameter2   
                                                   = _diffusion UnnamedParameter1 UnnamedParameter2 
    member this.Drift                              UnnamedParameter1 x   
                                                   = _drift UnnamedParameter1 x 
    member this.Expectation                        UnnamedParameter1 x0 dt   
                                                   = _expectation UnnamedParameter1 x0 dt 
    member this.Level                              = _level
    member this.Speed                              = _speed
    member this.StdDeviation                       t x0 dt   
                                                   = _stdDeviation t x0 dt 
    member this.Variance                           UnnamedParameter1 UnnamedParameter2 dt   
                                                   = _variance UnnamedParameter1 UnnamedParameter2 dt 
    member this.Volatility                         = _volatility
    member this.X0                                 = _x0
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.Apply1                             x0 dx   
                                                   = _apply1 x0 dx 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Evolve1                            t0 x0 dt dw   
                                                   = _evolve1 t0 x0 dt dw 
    member this.InitialValues                      = _initialValues
    member this.Size                               = _size
    member this.Covariance                         t0 x0 dt   
                                                   = _covariance t0 x0 dt 
    member this.Factors                            = _factors
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Time                               d   
                                                   = _time d 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
