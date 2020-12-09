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
type VariableChangeModel
    ( f                                            : ICell<Func<double,double>>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , k                                            : ICell<int>
    ( evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<VariableChange> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _f                                         = f
    let _a                                         = a
    let _b                                         = b
    let _k                                         = k
(*
    Functions
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let mutable
        _VariableChange                            = cell (fun () -> (withEvaluationDate _evaluationDate new VariableChange (f.Value, a.Value, b.Value, k.Value)))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _VariableChange.Value.value(x.Value))
    do this.Bind(_VariableChange)
(* 
    casting 
*)
    let mutable
        _evaluationDate                            = evaluationDate
   interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
    internal new () = VariableChangeModel(null,null,null,null)
    member internal this.Inject v = _VariableChange <- v
    static member Cast (p : ICell<VariableChange>) = 
        if p :? VariableChangeModel then 
            p :?> VariableChangeModel
        else
            let o = new VariableChangeModel ()
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
    internal new () = VariableChangeModel(null,null,null,null)
    static member Cast (p : ICell<VariableChange>) = 
        if p :? VariableChangeModel then 
            p :?> VariableChangeModel
        else
            let o = new VariableChangeModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    let mutable
        _evaluationDate                            = evaluationDate
    member this.f                                  = _f 
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.k                                  = _k 
    member this.Value                              x   
                                                   = _value x 
