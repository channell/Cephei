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
  Hull-White stochastic process

  </summary> *)
[<AutoSerializable(true)>]
type HullWhiteProcessModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<HullWhiteProcess> ()
(*
    Parameters
*)
    let _h                                         = h
    let _a                                         = a
    let _sigma                                     = sigma
(*
    Functions
*)
    let _HullWhiteProcess                          = cell (fun () -> new HullWhiteProcess (h.Value, a.Value, sigma.Value))
    let _a                                         = triv (fun () -> _HullWhiteProcess.Value.a())
    let _alpha                                     (t : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.alpha(t.Value))
    let _diffusion                                 (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.diffusion(t.Value, x.Value))
    let _drift                                     (t : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.drift(t.Value, x.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _sigma                                     = triv (fun () -> _HullWhiteProcess.Value.sigma())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _x0                                        = triv (fun () -> _HullWhiteProcess.Value.x0())
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.apply(x0.Value, dx.Value))
    let _apply1                                    (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.apply(x0.Value, dx.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _evolve1                                   (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _initialValues                             = triv (fun () -> _HullWhiteProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _HullWhiteProcess.Value.size())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _HullWhiteProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.registerWith(handler.Value)
                                                                     _HullWhiteProcess.Value)
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _HullWhiteProcess.Value.unregisterWith(handler.Value)
                                                                     _HullWhiteProcess.Value)
    let _update                                    = triv (fun () -> _HullWhiteProcess.Value.update()
                                                                     _HullWhiteProcess.Value)
    do this.Bind(_HullWhiteProcess)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.A                                  = _a
    member this.Alpha                              t   
                                                   = _alpha t 
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.Sigma                              = _sigma
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.Variance                           t0 x0 dt   
                                                   = _variance t0 x0 dt 
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
