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
  Square-root process class   This class describes a square-root process governed by dx = a (b - x_t) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type SquareRootProcessModel
    ( b                                            : ICell<double>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    , x0                                           : ICell<double>
    , disc                                         : ICell<IDiscretization1D>
    ) as this =

    inherit Model<SquareRootProcess> ()
(*
    Parameters
*)
    let _b                                         = b
    let _a                                         = a
    let _sigma                                     = sigma
    let _x0                                        = x0
    let _disc                                      = disc
(*
    Functions
*)
    let _SquareRootProcess                         = cell (fun () -> new SquareRootProcess (b.Value, a.Value, sigma.Value, x0.Value, disc.Value))
    let _diffusion                                 (UnnamedParameter1 : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.diffusion(UnnamedParameter1.Value, x.Value))
    let _drift                                     (UnnamedParameter1 : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.drift(UnnamedParameter1.Value, x.Value))
    let _x0                                        = triv (fun () -> _SquareRootProcess.Value.x0())
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.apply(x0.Value, dx.Value))
    let _apply1                                    (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.apply(x0.Value, dx.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _evolve1                                   (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _expectation1                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _initialValues                             = triv (fun () -> _SquareRootProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _SquareRootProcess.Value.size())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _stdDeviation1                             (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _variance1                                 (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _SquareRootProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.registerWith(handler.Value)
                                                                     _SquareRootProcess.Value)
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.unregisterWith(handler.Value)
                                                                     _SquareRootProcess.Value)
    let _update                                    = triv (fun () -> _SquareRootProcess.Value.update()
                                                                     _SquareRootProcess.Value)
    do this.Bind(_SquareRootProcess)
(* 
    casting 
*)
    internal new () = new SquareRootProcessModel(null,null,null,null,null)
    member internal this.Inject v = _SquareRootProcess.Value <- v
    static member Cast (p : ICell<SquareRootProcess>) = 
        if p :? SquareRootProcessModel then 
            p :?> SquareRootProcessModel
        else
            let o = new SquareRootProcessModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.b                                  = _b 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.x0                                 = _x0 
    member this.disc                               = _disc 
    member this.Diffusion                          UnnamedParameter1 x   
                                                   = _diffusion UnnamedParameter1 x 
    member this.Drift                              UnnamedParameter1 x   
                                                   = _drift UnnamedParameter1 x 
    member this.X0                                 = _x0
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.Apply1                             x0 dx   
                                                   = _apply1 x0 dx 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Evolve1                            t0 x0 dt dw   
                                                   = _evolve1 t0 x0 dt dw 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.Expectation1                       t0 x0 dt   
                                                   = _expectation1 t0 x0 dt 
    member this.InitialValues                      = _initialValues
    member this.Size                               = _size
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.StdDeviation1                      t0 x0 dt   
                                                   = _stdDeviation1 t0 x0 dt 
    member this.Variance                           t0 x0 dt   
                                                   = _variance t0 x0 dt 
    member this.Variance1                          t0 x0 dt   
                                                   = _variance1 t0 x0 dt 
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
(* <summary>
  Square-root process class   This class describes a square-root process governed by dx = a (b - x_t) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type SquareRootProcessModel1
    ( b                                            : ICell<double>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<SquareRootProcess> ()
(*
    Parameters
*)
    let _b                                         = b
    let _a                                         = a
    let _sigma                                     = sigma
(*
    Functions
*)
    let _SquareRootProcess                         = cell (fun () -> new SquareRootProcess (b.Value, a.Value, sigma.Value))
    let _diffusion                                 (UnnamedParameter1 : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.diffusion(UnnamedParameter1.Value, x.Value))
    let _drift                                     (UnnamedParameter1 : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.drift(UnnamedParameter1.Value, x.Value))
    let _x0                                        = triv (fun () -> _SquareRootProcess.Value.x0())
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.apply(x0.Value, dx.Value))
    let _apply1                                    (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.apply(x0.Value, dx.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _evolve1                                   (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _expectation1                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _initialValues                             = triv (fun () -> _SquareRootProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _SquareRootProcess.Value.size())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _stdDeviation1                             (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _variance1                                 (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _SquareRootProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.registerWith(handler.Value)
                                                                     _SquareRootProcess.Value)
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.unregisterWith(handler.Value)
                                                                     _SquareRootProcess.Value)
    let _update                                    = triv (fun () -> _SquareRootProcess.Value.update()
                                                                     _SquareRootProcess.Value)
    do this.Bind(_SquareRootProcess)
(* 
    casting 
*)
    internal new () = new SquareRootProcessModel1(null,null,null)
    member internal this.Inject v = _SquareRootProcess.Value <- v
    static member Cast (p : ICell<SquareRootProcess>) = 
        if p :? SquareRootProcessModel1 then 
            p :?> SquareRootProcessModel1
        else
            let o = new SquareRootProcessModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.b                                  = _b 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.Diffusion                          UnnamedParameter1 x   
                                                   = _diffusion UnnamedParameter1 x 
    member this.Drift                              UnnamedParameter1 x   
                                                   = _drift UnnamedParameter1 x 
    member this.X0                                 = _x0
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.Apply1                             x0 dx   
                                                   = _apply1 x0 dx 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Evolve1                            t0 x0 dt dw   
                                                   = _evolve1 t0 x0 dt dw 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.Expectation1                       t0 x0 dt   
                                                   = _expectation1 t0 x0 dt 
    member this.InitialValues                      = _initialValues
    member this.Size                               = _size
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.StdDeviation1                      t0 x0 dt   
                                                   = _stdDeviation1 t0 x0 dt 
    member this.Variance                           t0 x0 dt   
                                                   = _variance t0 x0 dt 
    member this.Variance1                          t0 x0 dt   
                                                   = _variance1 t0 x0 dt 
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
(* <summary>
  Square-root process class   This class describes a square-root process governed by dx = a (b - x_t) dt + dW_t.  processes

  </summary> *)
[<AutoSerializable(true)>]
type SquareRootProcessModel2
    ( b                                            : ICell<double>
    , a                                            : ICell<double>
    , sigma                                        : ICell<double>
    , x0                                           : ICell<double>
    ) as this =

    inherit Model<SquareRootProcess> ()
(*
    Parameters
*)
    let _b                                         = b
    let _a                                         = a
    let _sigma                                     = sigma
    let _x0                                        = x0
(*
    Functions
*)
    let _SquareRootProcess                         = cell (fun () -> new SquareRootProcess (b.Value, a.Value, sigma.Value, x0.Value))
    let _diffusion                                 (UnnamedParameter1 : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.diffusion(UnnamedParameter1.Value, x.Value))
    let _drift                                     (UnnamedParameter1 : ICell<double>) (x : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.drift(UnnamedParameter1.Value, x.Value))
    let _x0                                        = triv (fun () -> _SquareRootProcess.Value.x0())
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.apply(x0.Value, dx.Value))
    let _apply1                                    (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.apply(x0.Value, dx.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _evolve1                                   (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _expectation1                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _initialValues                             = triv (fun () -> _SquareRootProcess.Value.initialValues())
    let _size                                      = triv (fun () -> _SquareRootProcess.Value.size())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _stdDeviation1                             (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _variance1                                 (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = triv (fun () -> _SquareRootProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.registerWith(handler.Value)
                                                                     _SquareRootProcess.Value)
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SquareRootProcess.Value.unregisterWith(handler.Value)
                                                                     _SquareRootProcess.Value)
    let _update                                    = triv (fun () -> _SquareRootProcess.Value.update()
                                                                     _SquareRootProcess.Value)
    do this.Bind(_SquareRootProcess)
(* 
    casting 
*)
    internal new () = new SquareRootProcessModel2(null,null,null,null)
    member internal this.Inject v = _SquareRootProcess.Value <- v
    static member Cast (p : ICell<SquareRootProcess>) = 
        if p :? SquareRootProcessModel2 then 
            p :?> SquareRootProcessModel2
        else
            let o = new SquareRootProcessModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.b                                  = _b 
    member this.a                                  = _a 
    member this.sigma                              = _sigma 
    member this.x0                                 = _x0 
    member this.Diffusion                          UnnamedParameter1 x   
                                                   = _diffusion UnnamedParameter1 x 
    member this.Drift                              UnnamedParameter1 x   
                                                   = _drift UnnamedParameter1 x 
    member this.X0                                 = _x0
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.Apply1                             x0 dx   
                                                   = _apply1 x0 dx 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Evolve1                            t0 x0 dt dw   
                                                   = _evolve1 t0 x0 dt dw 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.Expectation1                       t0 x0 dt   
                                                   = _expectation1 t0 x0 dt 
    member this.InitialValues                      = _initialValues
    member this.Size                               = _size
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.StdDeviation1                      t0 x0 dt   
                                                   = _stdDeviation1 t0 x0 dt 
    member this.Variance                           t0 x0 dt   
                                                   = _variance t0 x0 dt 
    member this.Variance1                          t0 x0 dt   
                                                   = _variance1 t0 x0 dt 
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
