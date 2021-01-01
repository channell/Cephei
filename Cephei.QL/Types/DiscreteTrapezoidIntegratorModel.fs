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
type DiscreteTrapezoidIntegratorModel
    ( evaluations                                  : ICell<int>
    ) as this =

    inherit Model<DiscreteTrapezoidIntegrator> ()
(*
    Parameters
*)
    let _evaluations                               = evaluations
(*
    Functions
*)
    let mutable
        _DiscreteTrapezoidIntegrator               = make (fun () -> new DiscreteTrapezoidIntegrator (evaluations.Value))
    let _absoluteAccuracy                          = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.absoluteAccuracy())
    let _absoluteError                             = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.absoluteError())
    let _integrationSuccess                        = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.integrationSuccess())
    let _maxEvaluations                            = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.maxEvaluations())
    let _numberOfEvaluations                       = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.numberOfEvaluations())
    let _setAbsoluteAccuracy                       (accuracy : ICell<double>)   
                                                   = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.setAbsoluteAccuracy(accuracy.Value)
                                                                                                  _DiscreteTrapezoidIntegrator.Value)
    let _setMaxEvaluations                         (maxEvaluations : ICell<int>)   
                                                   = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.setMaxEvaluations(maxEvaluations.Value)
                                                                                                  _DiscreteTrapezoidIntegrator.Value)
    let _value                                     (f : ICell<Func<double,double>>) (a : ICell<double>) (b : ICell<double>)   
                                                   = triv _DiscreteTrapezoidIntegrator (fun () -> _DiscreteTrapezoidIntegrator.Value.value(f.Value, a.Value, b.Value))
    do this.Bind(_DiscreteTrapezoidIntegrator)
(* 
    casting 
*)
    internal new () = new DiscreteTrapezoidIntegratorModel(null)
    member internal this.Inject v = _DiscreteTrapezoidIntegrator <- v
    static member Cast (p : ICell<DiscreteTrapezoidIntegrator>) = 
        if p :? DiscreteTrapezoidIntegratorModel then 
            p :?> DiscreteTrapezoidIntegratorModel
        else
            let o = new DiscreteTrapezoidIntegratorModel ()
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
