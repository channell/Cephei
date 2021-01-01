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
  The formulas are taken from "Barrier Option Pricing", Wulin Suo, Yong Wang.  barrierengines  the correctness of the returned value is tested by reproducing results available in literature.

  </summary> *)
[<AutoSerializable(true)>]
type WulinYongDoubleBarrierEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , series                                       : ICell<int>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<WulinYongDoubleBarrierEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
    let _series                                    = series
(*
    Functions
*)
    let mutable
        _WulinYongDoubleBarrierEngine              = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new WulinYongDoubleBarrierEngine (Process.Value, series.Value))))
    do this.Bind(_WulinYongDoubleBarrierEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new WulinYongDoubleBarrierEngineModel(null,null,null)
    member internal this.Inject v = _WulinYongDoubleBarrierEngine <- v
    static member Cast (p : ICell<WulinYongDoubleBarrierEngine>) = 
        if p :? WulinYongDoubleBarrierEngineModel then 
            p :?> WulinYongDoubleBarrierEngineModel
        else
            let o = new WulinYongDoubleBarrierEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.series                             = _series 
