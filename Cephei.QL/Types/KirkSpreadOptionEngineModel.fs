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
type KirkSpreadOptionEngineModel
    ( process1                                     : ICell<BlackProcess>
    , process2                                     : ICell<BlackProcess>
    , correlation                                  : ICell<Handle<Quote>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<KirkSpreadOptionEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _process1                                  = process1
    let _process2                                  = process2
    let _correlation                               = correlation
(*
    Functions
*)
    let mutable
        _KirkSpreadOptionEngine                    = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new KirkSpreadOptionEngine (process1.Value, process2.Value, correlation.Value))))
    do this.Bind(_KirkSpreadOptionEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new KirkSpreadOptionEngineModel(null,null,null,null)
    member internal this.Inject v = _KirkSpreadOptionEngine <- v
    static member Cast (p : ICell<KirkSpreadOptionEngine>) = 
        if p :? KirkSpreadOptionEngineModel then 
            p :?> KirkSpreadOptionEngineModel
        else
            let o = new KirkSpreadOptionEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.process1                           = _process1 
    member this.process2                           = _process2 
    member this.correlation                        = _correlation 
