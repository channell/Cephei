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
  Integral of a one-dimensional function   Given a number N of intervals, the integral of a function f between a and b is calculated by means of the trapezoid formula f = f(x_{0}) + f(x_{1}) + f(x_{2}) + + f(x_{N-1}) + f(x_{N}) where x_0 = a x_N = b and x_i = a+i x with x = (b-a)/N  the correctness of the result is tested by checking it against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type SegmentIntegralModel
    ( intervals                                    : ICell<int>
    ) as this =

    inherit Model<SegmentIntegral> ()
(*
    Parameters
*)
    let _intervals                                 = intervals
(*
    Functions
*)
    let _SegmentIntegral                           = cell (fun () -> new SegmentIntegral (intervals.Value))
    let _absoluteAccuracy                          = triv (fun () -> _SegmentIntegral.Value.absoluteAccuracy())
    let _absoluteError                             = triv (fun () -> _SegmentIntegral.Value.absoluteError())
    let _integrationSuccess                        = triv (fun () -> _SegmentIntegral.Value.integrationSuccess())
    let _maxEvaluations                            = triv (fun () -> _SegmentIntegral.Value.maxEvaluations())
    let _numberOfEvaluations                       = triv (fun () -> _SegmentIntegral.Value.numberOfEvaluations())
    let _setAbsoluteAccuracy                       (accuracy : ICell<double>)   
                                                   = triv (fun () -> _SegmentIntegral.Value.setAbsoluteAccuracy(accuracy.Value)
                                                                     _SegmentIntegral.Value)
    let _setMaxEvaluations                         (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> _SegmentIntegral.Value.setMaxEvaluations(maxEvaluations.Value)
                                                                     _SegmentIntegral.Value)
    let _value                                     (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>)   
                                                   = triv (fun () -> _SegmentIntegral.Value.value(f.Value, a.Value, b.Value))
    do this.Bind(_SegmentIntegral)
(* 
    casting 
*)
    internal new () = new SegmentIntegralModel(null)
    member internal this.Inject v = _SegmentIntegral.Value <- v
    static member Cast (p : ICell<SegmentIntegral>) = 
        if p :? SegmentIntegralModel then 
            p :?> SegmentIntegralModel
        else
            let o = new SegmentIntegralModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.intervals                          = _intervals 
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
