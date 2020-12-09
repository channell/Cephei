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
  The given date will be the implied reference date. This term structure will remain linked to the original structure, i.e., any changes in the latter will be reflected in this structure as well.  It doesn't make financial sense to have an asset-dependant implied Vol Term Structure.  This class should be used with term structures that are time dependant only.

  </summary> *)
[<AutoSerializable(true)>]
type ImpliedVolTermStructureModel
    ( originalTS                                   : ICell<Handle<BlackVolTermStructure>>
    , referenceDate                                : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ImpliedVolTermStructure> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _originalTS                                = originalTS
    let _referenceDate                             = referenceDate
(*
    Functions
*)
    let mutable
        _ImpliedVolTermStructure                   = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new ImpliedVolTermStructure (originalTS.Value, referenceDate.Value))))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _ImpliedVolTermStructure).Value.accept(v.Value)
                                                                     _ImpliedVolTermStructure.Value)
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _ImpliedVolTermStructure).Value.dayCounter())
    let _maxDate                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _ImpliedVolTermStructure).Value.maxDate())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _ImpliedVolTermStructure).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _ImpliedVolTermStructure).Value.minStrike())
    do this.Bind(_ImpliedVolTermStructure)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ImpliedVolTermStructureModel(null,null,null)
    member internal this.Inject v = _ImpliedVolTermStructure <- v
    static member Cast (p : ICell<ImpliedVolTermStructure>) = 
        if p :? ImpliedVolTermStructureModel then 
            p :?> ImpliedVolTermStructureModel
        else
            let o = new ImpliedVolTermStructureModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.originalTS                         = _originalTS 
    member this.referenceDate                      = _referenceDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
