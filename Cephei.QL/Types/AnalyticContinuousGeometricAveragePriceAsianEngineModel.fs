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
  This class implements a continuous geometric average price Asian option with European exercise.  The formula is from "Option Pricing Formulas", E. G. Haug (1997) pag 96-97.  asianengines  - the correctness of the returned value is tested by reproducing results available in literature, and results obtained using a discrete average approximation. - the correctness of the returned greeks is tested by reproducing numerical derivatives.  handle seasoned options

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticContinuousGeometricAveragePriceAsianEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticContinuousGeometricAveragePriceAsianEngine> ()
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
        _AnalyticContinuousGeometricAveragePriceAsianEngine = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticContinuousGeometricAveragePriceAsianEngine (Process.Value))))
    do this.Bind(_AnalyticContinuousGeometricAveragePriceAsianEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticContinuousGeometricAveragePriceAsianEngineModel(null,null)
    member internal this.Inject v = _AnalyticContinuousGeometricAveragePriceAsianEngine <- v
    static member Cast (p : ICell<AnalyticContinuousGeometricAveragePriceAsianEngine>) = 
        if p :? AnalyticContinuousGeometricAveragePriceAsianEngineModel then 
            p :?> AnalyticContinuousGeometricAveragePriceAsianEngineModel
        else
            let o = new AnalyticContinuousGeometricAveragePriceAsianEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
