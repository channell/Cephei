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
    let mutable
        _evaluationDate                            = evaluationDate
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
type SpyModel
    ( f                                            : ICell<Func<double,double>>
    ( evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Spy> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _f                                         = f
(*
    Functions
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let mutable
        _Spy                                       = cell (fun () -> (withEvaluationDate _evaluationDate new Spy (f.Value)))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _Spy.Value.value(x.Value))
    do this.Bind(_Spy)
(* 
    casting 
*)
    let mutable
        _evaluationDate                            = evaluationDate
   interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
    internal new () = SpyModel(null)
    member internal this.Inject v = _Spy <- v
    static member Cast (p : ICell<Spy>) = 
        if p :? SpyModel then 
            p :?> SpyModel
        else
            let o = new SpyModel ()
            o.Inject p\m            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            
(* 
    casting 
*)
    let mutable
        _evaluationDate                            = evaluationDate
   interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
    internal new () = SpyModel(null)
    static member Cast (p : ICell<Spy>) = 
        if p :? SpyModel then 
            p :?> SpyModel
        else
            let o = new SpyModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    let mutable
        _evaluationDate                            = evaluationDate
    member this.f                                  = _f 
    member this.Value                              x   
                                                   = _value x 
