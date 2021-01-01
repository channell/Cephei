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
  The formulas are taken from "The complete guide to option pricing formulas 2nd Ed", E.G. Haug, McGraw-Hill, p.176 and following.  barrierengines  - the correctness of the returned value in case of cash-or-nothing at-expiry binary payoff is tested by reproducing results available in literature. - the correctness of the returned value in case of asset-or-nothing at-expiry binary payoff is tested by reproducing results available in literature.

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticBinaryBarrierEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticBinaryBarrierEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
(*
    Functions
*)
    let mutable
        _AnalyticBinaryBarrierEngine               = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticBinaryBarrierEngine (Process.Value))))
    do this.Bind(_AnalyticBinaryBarrierEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticBinaryBarrierEngineModel(null,null)
    member internal this.Inject v = _AnalyticBinaryBarrierEngine <- v
    static member Cast (p : ICell<AnalyticBinaryBarrierEngine>) = 
        if p :? AnalyticBinaryBarrierEngineModel then 
            p :?> AnalyticBinaryBarrierEngineModel
        else
            let o = new AnalyticBinaryBarrierEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
