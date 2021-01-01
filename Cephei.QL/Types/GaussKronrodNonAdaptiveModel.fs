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
  Integral of a 1-dimensional function using the Gauss-Kronrod methods   This class provide a non-adaptive integration procedure which uses fixed Gauss-Kronrod abscissae to sample the integrand at a maximum of 87 points.  It is provided for fast integration of smooth functions.  This function applies the Gauss-Kronrod 10-point, 21-point, 43-point and 87-point integration rules in succession until an estimate of the integral of f over (a, b) is achieved within the desired absolute and relative error limits, epsabs and epsrel. The function returns the final approximation, result, an estimate of the absolute error, abserr and the number of function evaluations used, neval. The Gauss-Kronrod rules are designed in such a way that each rule uses all the results of its predecessors, in order to minimize the total number of function evaluations.

  </summary> *)
[<AutoSerializable(true)>]
type GaussKronrodNonAdaptiveModel
    ( absoluteAccuracy                             : ICell<double>
    , maxEvaluations                               : ICell<int>
    , relativeAccuracy                             : ICell<double>
    ) as this =

    inherit Model<GaussKronrodNonAdaptive> ()
(*
    Parameters
*)
    let _absoluteAccuracy                          = absoluteAccuracy
    let _maxEvaluations                            = maxEvaluations
    let _relativeAccuracy                          = relativeAccuracy
(*
    Functions
*)
    let mutable
        _GaussKronrodNonAdaptive                   = make (fun () -> new GaussKronrodNonAdaptive (absoluteAccuracy.Value, maxEvaluations.Value, relativeAccuracy.Value))
    let _relativeAccuracy                          = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.relativeAccuracy())
    let _absoluteAccuracy                          = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.absoluteAccuracy())
    let _absoluteError                             = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.absoluteError())
    let _integrationSuccess                        = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.integrationSuccess())
    let _maxEvaluations                            = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.maxEvaluations())
    let _numberOfEvaluations                       = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.numberOfEvaluations())
    let _setAbsoluteAccuracy                       (accuracy : ICell<double>)   
                                                   = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.setAbsoluteAccuracy(accuracy.Value)
                                                                                              _GaussKronrodNonAdaptive.Value)
    let _setMaxEvaluations                         (maxEvaluations : ICell<int>)   
                                                   = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.setMaxEvaluations(maxEvaluations.Value)
                                                                                              _GaussKronrodNonAdaptive.Value)
    let _value                                     (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>)   
                                                   = triv _GaussKronrodNonAdaptive (fun () -> _GaussKronrodNonAdaptive.Value.value(f.Value, a.Value, b.Value))
    do this.Bind(_GaussKronrodNonAdaptive)
(* 
    casting 
*)
    internal new () = new GaussKronrodNonAdaptiveModel(null,null,null)
    member internal this.Inject v = _GaussKronrodNonAdaptive <- v
    static member Cast (p : ICell<GaussKronrodNonAdaptive>) = 
        if p :? GaussKronrodNonAdaptiveModel then 
            p :?> GaussKronrodNonAdaptiveModel
        else
            let o = new GaussKronrodNonAdaptiveModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.absoluteAccuracy                   = _absoluteAccuracy 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.relativeAccuracy                   = _relativeAccuracy 
    member this.RelativeAccuracy                   = _relativeAccuracy
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
