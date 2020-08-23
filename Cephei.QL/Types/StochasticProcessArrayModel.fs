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
  processes

  </summary> *)
[<AutoSerializable(true)>]
type StochasticProcessArrayModel
    ( processes                                    : ICell<Generic.List<StochasticProcess1D>>
    , correlation                                  : ICell<Matrix>
    ) as this =

    inherit Model<StochasticProcessArray> ()
(*
    Parameters
*)
    let _processes                                 = processes
    let _correlation                               = correlation
(*
    Functions
*)
    let _StochasticProcessArray                    = cell (fun () -> new StochasticProcessArray (processes.Value, correlation.Value))
    let _apply                                     (x0 : ICell<Vector>) (dx : ICell<Vector>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.apply(x0.Value, dx.Value))
    let _correlation                               = triv (fun () -> _StochasticProcessArray.Value.correlation())
    let _covariance                                (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.covariance(t0.Value, x0.Value, dt.Value))
    let _diffusion                                 (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.diffusion(t.Value, x.Value))
    let _drift                                     (t : ICell<double>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.drift(t.Value, x.Value))
    let _evolve                                    (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>) (dw : ICell<Vector>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.evolve(t0.Value, x0.Value, dt.Value, dw.Value))
    let _expectation                               (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.expectation(t0.Value, x0.Value, dt.Value))
    let _initialValues                             = triv (fun () -> _StochasticProcessArray.Value.initialValues())
    let _process                                   (i : ICell<int>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.PROCESS(i.Value))
    let _size                                      = triv (fun () -> _StochasticProcessArray.Value.size())
    let _stdDeviation                              (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.stdDeviation(t0.Value, x0.Value, dt.Value))
    let _time                                      (d : ICell<Date>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.time(d.Value))
    let _factors                                   = triv (fun () -> _StochasticProcessArray.Value.factors())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.registerWith(handler.Value)
                                                                     _StochasticProcessArray.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _StochasticProcessArray.Value.unregisterWith(handler.Value)
                                                                     _StochasticProcessArray.Value)
    let _update                                    = triv (fun () -> _StochasticProcessArray.Value.update()
                                                                     _StochasticProcessArray.Value)
    do this.Bind(_StochasticProcessArray)

(* 
    Externally visible/bindable properties
*)
    member this.processes                          = _processes 
    member this.correlation                        = _correlation 
    member this.Apply                              x0 dx   
                                                   = _apply x0 dx 
    member this.Correlation                        = _correlation
    member this.Covariance                         t0 x0 dt   
                                                   = _covariance t0 x0 dt 
    member this.Diffusion                          t x   
                                                   = _diffusion t x 
    member this.Drift                              t x   
                                                   = _drift t x 
    member this.Evolve                             t0 x0 dt dw   
                                                   = _evolve t0 x0 dt dw 
    member this.Expectation                        t0 x0 dt   
                                                   = _expectation t0 x0 dt 
    member this.InitialValues                      = _initialValues
    member this.Process                            i   
                                                   = _process i 
    member this.Size                               = _size
    member this.StdDeviation                       t0 x0 dt   
                                                   = _stdDeviation t0 x0 dt 
    member this.Time                               d   
                                                   = _time d 
    member this.Factors                            = _factors
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
