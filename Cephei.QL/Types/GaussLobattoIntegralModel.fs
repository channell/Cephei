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
  References: This algorithm is a C++ implementation of the algorithm outlined in  W. Gander and W. Gautschi, Adaptive Quadrature - Revisited. BIT, 40(1):84-101, March 2000. CS technical report: ftp.inf.ethz.ch/pub/publications/tech-reports/3xx/306.ps.gz  The original MATLAB version can be downloaded here http://www.inf.ethz.ch/personal/gander/adaptlob.m

  </summary> *)
[<AutoSerializable(true)>]
type GaussLobattoIntegralModel
    ( maxIterations                                : ICell<int>
    , absAccuracy                                  : ICell<Nullable<double>>
    , relAccuracy                                  : ICell<Nullable<double>>
    , useConvergenceEstimate                       : ICell<bool>
    ) as this =

    inherit Model<GaussLobattoIntegral> ()
(*
    Parameters
*)
    let _maxIterations                             = maxIterations
    let _absAccuracy                               = absAccuracy
    let _relAccuracy                               = relAccuracy
    let _useConvergenceEstimate                    = useConvergenceEstimate
(*
    Functions
*)
    let mutable
        _GaussLobattoIntegral                      = cell (fun () -> new GaussLobattoIntegral (maxIterations.Value, absAccuracy.Value, relAccuracy.Value, useConvergenceEstimate.Value))
    let _absoluteAccuracy                          = triv (fun () -> _GaussLobattoIntegral.Value.absoluteAccuracy())
    let _absoluteError                             = triv (fun () -> _GaussLobattoIntegral.Value.absoluteError())
    let _integrationSuccess                        = triv (fun () -> _GaussLobattoIntegral.Value.integrationSuccess())
    let _maxEvaluations                            = triv (fun () -> _GaussLobattoIntegral.Value.maxEvaluations())
    let _numberOfEvaluations                       = triv (fun () -> _GaussLobattoIntegral.Value.numberOfEvaluations())
    let _setAbsoluteAccuracy                       (accuracy : ICell<double>)   
                                                   = triv (fun () -> _GaussLobattoIntegral.Value.setAbsoluteAccuracy(accuracy.Value)
                                                                     _GaussLobattoIntegral.Value)
    let _setMaxEvaluations                         (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> _GaussLobattoIntegral.Value.setMaxEvaluations(maxEvaluations.Value)
                                                                     _GaussLobattoIntegral.Value)
    let _value                                     (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>)   
                                                   = triv (fun () -> _GaussLobattoIntegral.Value.value(f.Value, a.Value, b.Value))
    do this.Bind(_GaussLobattoIntegral)
(* 
    casting 
*)
    internal new () = new GaussLobattoIntegralModel(null,null,null,null)
    member internal this.Inject v = _GaussLobattoIntegral <- v
    static member Cast (p : ICell<GaussLobattoIntegral>) = 
        if p :? GaussLobattoIntegralModel then 
            p :?> GaussLobattoIntegralModel
        else
            let o = new GaussLobattoIntegralModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.maxIterations                      = _maxIterations 
    member this.absAccuracy                        = _absAccuracy 
    member this.relAccuracy                        = _relAccuracy 
    member this.useConvergenceEstimate             = _useConvergenceEstimate 
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
