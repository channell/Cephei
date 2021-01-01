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
  Euler discretization for stochastic processes
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type EulerDiscretizationModel
    () as this =
    inherit Model<EulerDiscretization> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _EulerDiscretization                       = make (fun () -> new EulerDiscretization ())
    let _covariance                                (Process : ICell<StochasticProcess>) (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv _EulerDiscretization (fun () -> _EulerDiscretization.Value.covariance(Process.Value, t0.Value, x0.Value, dt.Value))
    let _diffusion                                 (Process : ICell<StochasticProcess1D>) (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _EulerDiscretization (fun () -> _EulerDiscretization.Value.diffusion(Process.Value, t0.Value, x0.Value, dt.Value))
    let _diffusion1                                (Process : ICell<StochasticProcess>) (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv _EulerDiscretization (fun () -> _EulerDiscretization.Value.diffusion(Process.Value, t0.Value, x0.Value, dt.Value))
    let _drift                                     (Process : ICell<StochasticProcess1D>) (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _EulerDiscretization (fun () -> _EulerDiscretization.Value.drift(Process.Value, t0.Value, x0.Value, dt.Value))
    let _drift1                                    (Process : ICell<StochasticProcess>) (t0 : ICell<double>) (x0 : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv _EulerDiscretization (fun () -> _EulerDiscretization.Value.drift(Process.Value, t0.Value, x0.Value, dt.Value))
    let _variance                                  (Process : ICell<StochasticProcess1D>) (t0 : ICell<double>) (x0 : ICell<double>) (dt : ICell<double>)   
                                                   = triv _EulerDiscretization (fun () -> _EulerDiscretization.Value.variance(Process.Value, t0.Value, x0.Value, dt.Value))
    do this.Bind(_EulerDiscretization)
(* 
    casting 
*)
    
    member internal this.Inject v = _EulerDiscretization <- v
    static member Cast (p : ICell<EulerDiscretization>) = 
        if p :? EulerDiscretizationModel then 
            p :?> EulerDiscretizationModel
        else
            let o = new EulerDiscretizationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Covariance                         Process t0 x0 dt   
                                                   = _covariance Process t0 x0 dt 
    member this.Diffusion                          Process t0 x0 dt   
                                                   = _diffusion Process t0 x0 dt 
    member this.Diffusion1                         Process t0 x0 dt   
                                                   = _diffusion1 Process t0 x0 dt 
    member this.Drift                              Process t0 x0 dt   
                                                   = _drift Process t0 x0 dt 
    member this.Drift1                             Process t0 x0 dt   
                                                   = _drift1 Process t0 x0 dt 
    member this.Variance                           Process t0 x0 dt   
                                                   = _variance Process t0 x0 dt 
