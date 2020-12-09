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
  Formula from "Option Pricing Formulas", E.G. Haug, McGraw-Hill, 1998, p.63-64

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticContinuousFixedLookbackEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticContinuousFixedLookbackEngine> ()
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
        _AnalyticContinuousFixedLookbackEngine     = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticContinuousFixedLookbackEngine (Process.Value))))
    do this.Bind(_AnalyticContinuousFixedLookbackEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticContinuousFixedLookbackEngineModel(null,null)
    member internal this.Inject v = _AnalyticContinuousFixedLookbackEngine <- v
    static member Cast (p : ICell<AnalyticContinuousFixedLookbackEngine>) = 
        if p :? AnalyticContinuousFixedLookbackEngineModel then 
            p :?> AnalyticContinuousFixedLookbackEngineModel
        else
            let o = new AnalyticContinuousFixedLookbackEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
