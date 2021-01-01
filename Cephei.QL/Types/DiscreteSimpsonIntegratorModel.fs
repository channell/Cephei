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
type DiscreteSimpsonIntegratorModel
    ( evaluations                                  : ICell<int>
    ) as this =

    inherit Model<DiscreteSimpsonIntegrator> ()
(*
    Parameters
*)
    let _evaluations                               = evaluations
(*
    Functions
*)
    let mutable
        _DiscreteSimpsonIntegrator                 = make (fun () -> new DiscreteSimpsonIntegrator (evaluations.Value))
    let _absoluteAccuracy                          = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.absoluteAccuracy())
    let _absoluteError                             = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.absoluteError())
    let _integrationSuccess                        = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.integrationSuccess())
    let _maxEvaluations                            = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.maxEvaluations())
    let _numberOfEvaluations                       = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.numberOfEvaluations())
    let _setAbsoluteAccuracy                       (accuracy : ICell<double>)   
                                                   = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.setAbsoluteAccuracy(accuracy.Value)
                                                                                                _DiscreteSimpsonIntegrator.Value)
    let _setMaxEvaluations                         (maxEvaluations : ICell<int>)   
                                                   = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.setMaxEvaluations(maxEvaluations.Value)
                                                                                                _DiscreteSimpsonIntegrator.Value)
    let _value                                     (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>)   
                                                   = triv _DiscreteSimpsonIntegrator (fun () -> _DiscreteSimpsonIntegrator.Value.value(f.Value, a.Value, b.Value))
    do this.Bind(_DiscreteSimpsonIntegrator)
(* 
    casting 
*)
    internal new () = new DiscreteSimpsonIntegratorModel(null)
    member internal this.Inject v = _DiscreteSimpsonIntegrator <- v
    static member Cast (p : ICell<DiscreteSimpsonIntegrator>) = 
        if p :? DiscreteSimpsonIntegratorModel then 
            p :?> DiscreteSimpsonIntegratorModel
        else
            let o = new DiscreteSimpsonIntegratorModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.evaluations                        = _evaluations 
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
