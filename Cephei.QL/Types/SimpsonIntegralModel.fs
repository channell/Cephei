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
  the correctness of the result is tested by checking it against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type SimpsonIntegralModel
    ( accuracy                                     : ICell<double>
    , maxIterations                                : ICell<int>
    ) as this =

    inherit Model<SimpsonIntegral> ()
(*
    Parameters
*)
    let _accuracy                                  = accuracy
    let _maxIterations                             = maxIterations
(*
    Functions
*)
    let mutable
        _SimpsonIntegral                           = cell (fun () -> new SimpsonIntegral (accuracy.Value, maxIterations.Value))
    let _absoluteAccuracy                          = triv (fun () -> _SimpsonIntegral.Value.absoluteAccuracy())
    let _absoluteError                             = triv (fun () -> _SimpsonIntegral.Value.absoluteError())
    let _integrationSuccess                        = triv (fun () -> _SimpsonIntegral.Value.integrationSuccess())
    let _maxEvaluations                            = triv (fun () -> _SimpsonIntegral.Value.maxEvaluations())
    let _numberOfEvaluations                       = triv (fun () -> _SimpsonIntegral.Value.numberOfEvaluations())
    let _setAbsoluteAccuracy                       (accuracy : ICell<double>)   
                                                   = triv (fun () -> _SimpsonIntegral.Value.setAbsoluteAccuracy(accuracy.Value)
                                                                     _SimpsonIntegral.Value)
    let _setMaxEvaluations                         (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> _SimpsonIntegral.Value.setMaxEvaluations(maxEvaluations.Value)
                                                                     _SimpsonIntegral.Value)
    let _value                                     (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>)   
                                                   = triv (fun () -> _SimpsonIntegral.Value.value(f.Value, a.Value, b.Value))
    do this.Bind(_SimpsonIntegral)
(* 
    casting 
*)
    internal new () = new SimpsonIntegralModel(null,null)
    member internal this.Inject v = _SimpsonIntegral <- v
    static member Cast (p : ICell<SimpsonIntegral>) = 
        if p :? SimpsonIntegralModel then 
            p :?> SimpsonIntegralModel
        else
            let o = new SimpsonIntegralModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.accuracy                           = _accuracy 
    member this.maxIterations                      = _maxIterations 
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
