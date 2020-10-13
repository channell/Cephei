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
  Integral of a 1-dimensional function using the Gauss-Kronrod methods   This class provide an adaptive integration procedure using 15 points Gauss-Kronrod integration rule.  This is more robust in that it allows to integrate less smooth functions (though singular functions should be integrated using dedicated algorithms) but less efficient beacuse it does not reuse precedently computed points during computation steps.  References:  Gauss-Kronrod Integration
<http://mathcssun1.emporia.edu/~oneilcat/ExperimentApplet3/ExperimentApplet3.html>  NMS - Numerical Analysis Library
<http://www.math.iastate.edu/burkardt/f_src/nms/nms.html>  the correctness of the result is tested by checking it against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type GaussKronrodAdaptiveModel
    ( absoluteAccuracy                             : ICell<double>
    , maxEvaluations                               : ICell<int>
    ) as this =

    inherit Model<GaussKronrodAdaptive> ()
(*
    Parameters
*)
    let _absoluteAccuracy                          = absoluteAccuracy
    let _maxEvaluations                            = maxEvaluations
(*
    Functions
*)
    let _GaussKronrodAdaptive                      = cell (fun () -> new GaussKronrodAdaptive (absoluteAccuracy.Value, maxEvaluations.Value))
    let _absoluteAccuracy                          = triv (fun () -> _GaussKronrodAdaptive.Value.absoluteAccuracy())
    let _absoluteError                             = triv (fun () -> _GaussKronrodAdaptive.Value.absoluteError())
    let _integrationSuccess                        = triv (fun () -> _GaussKronrodAdaptive.Value.integrationSuccess())
    let _maxEvaluations                            = triv (fun () -> _GaussKronrodAdaptive.Value.maxEvaluations())
    let _numberOfEvaluations                       = triv (fun () -> _GaussKronrodAdaptive.Value.numberOfEvaluations())
    let _setAbsoluteAccuracy                       (accuracy : ICell<double>)   
                                                   = triv (fun () -> _GaussKronrodAdaptive.Value.setAbsoluteAccuracy(accuracy.Value)
                                                                     _GaussKronrodAdaptive.Value)
    let _setMaxEvaluations                         (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> _GaussKronrodAdaptive.Value.setMaxEvaluations(maxEvaluations.Value)
                                                                     _GaussKronrodAdaptive.Value)
    let _value                                     (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>)   
                                                   = triv (fun () -> _GaussKronrodAdaptive.Value.value(f.Value, a.Value, b.Value))
    do this.Bind(_GaussKronrodAdaptive)
(* 
    casting 
*)
    internal new () = new GaussKronrodAdaptiveModel(null,null)
    member internal this.Inject v = _GaussKronrodAdaptive.Value <- v
    static member Cast (p : ICell<GaussKronrodAdaptive>) = 
        if p :? GaussKronrodAdaptiveModel then 
            p :?> GaussKronrodAdaptiveModel
        else
            let o = new GaussKronrodAdaptiveModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.absoluteAccuracy                   = _absoluteAccuracy 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.AbsoluteAccuracy                   = _absoluteAccuracy
    member this.AbsoluteError                      = _absoluteError
    member this.IntegrationSuccess                 = _integrationSuccess
    member this.MaxEvaluations                     = _maxEvaluations
    member this.NumberOfEvaluations                = _numberOfEvaluations
    member this.SetAbsoluteAccuracy                accuracy   
                                                   = _setAbsoluteAccuracy accuracy 
    member this.SetMaxEvaluations                  maxEvaluations   
                                                   = _setMaxEvaluations maxEvaluations 
    member this.Value                              f a b   
                                                   = _value f a b 
