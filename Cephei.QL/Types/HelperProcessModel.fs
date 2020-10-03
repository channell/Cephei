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


  </summary> *)
[<AutoSerializable(true)>]
type HelperProcessModel
    ( theta                                        : ICell<double>
    , k                                            : ICell<double>
    , sigma                                        : ICell<double>
    , y0                                           : ICell<double>
    ) as this =

    inherit Model<HelperProcess> ()
(*
    Parameters
*)
    let _theta                                     = theta
    let _k                                         = k
    let _sigma                                     = sigma
    let _y0                                        = y0
(*
    Functions
*)
    let _HelperProcess                             = cell (fun () -> new HelperProcess (theta.Value, k.Value, sigma.Value, y0.Value))
    let _diffusion                                 (d1 : ICell<double>) (d2 : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.diffusion(d1.Value, d2.Value))
    let _drift                                     (d : ICell<double>) (y : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.drift(d.Value, y.Value))
    let _x0                                        = cell (fun () -> _HelperProcess.Value.x0())
    let _apply                                     (x0 : ICell<double>) (dx : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.apply(x0.Value, dx.Value))
    let _apply1                                    (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = cell (fun () -> _HelperProcess.Value.apply(x0.Value, dx.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = cell (fun () -> _HelperProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _evolve1                                   (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>) (dw : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _expectation1                              (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _initialValues                             = cell (fun () -> _HelperProcess.Value.initialValues())
    let _size                                      = cell (fun () -> _HelperProcess.Value.size())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _stdDeviation1                             (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _variance                                  (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _variance1                                 (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.variance(t0.Value, x0.Value, dt.Value))
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = cell (fun () -> _HelperProcess.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _factors                                   = cell (fun () -> _HelperProcess.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _HelperProcess.Value.registerWith(handler.Value)
                                                                     _HelperProcess.Value)
    let _time                                      (d : ICell<Date>)   
                                                   = cell (fun () -> _HelperProcess.Value.time(d.Value))
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _HelperProcess.Value.unregisterWith(handler.Value)
                                                                     _HelperProcess.Value)
    let _update                                    = cell (fun () -> _HelperProcess.Value.update()
                                                                     _HelperProcess.Value)
    do this.Bind(_HelperProcess)
(* 
    casting 
*)
    internal new () = HelperProcessModel(null,null,null,null)
    member internal this.Inject v = _HelperProcess.Value <- v
    static member Cast (p : ICell<HelperProcess>) = 
        if p :? HelperProcessModel then 
            p :?> HelperProcessModel
        else
            let o = new HelperProcessModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    internal new () = HelperProcessModel(null,null,null,null)
    static member Cast (p : ICell<HelperProcess>) = 
        if p :? HelperProcessModel then 
            p :?> HelperProcessModel
        else
            let o = new HelperProcessModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.theta                              = _theta 
    member this.k                                  = _k 
    member this.sigma                              = _sigma 
    member this.y0                                 = _y0 
    member this.Diffusion                          d1 d2   
                                                   = _diffusion d1 d2 
    member this.Drift                              d y   
                                                   = _drift d y 
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
