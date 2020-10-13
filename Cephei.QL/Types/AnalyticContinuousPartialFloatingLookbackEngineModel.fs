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
  Formula from "Option Pricing Formulas, Second Edition", E.G. Haug, 2006, p.146

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticContinuousPartialFloatingLookbackEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    ) as this =

    inherit Model<AnalyticContinuousPartialFloatingLookbackEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
(*
    Functions
*)
    let _AnalyticContinuousPartialFloatingLookbackEngine = cell (fun () -> new AnalyticContinuousPartialFloatingLookbackEngine (Process.Value))
    do this.Bind(_AnalyticContinuousPartialFloatingLookbackEngine)
(* 
    casting 
*)
    internal new () = new AnalyticContinuousPartialFloatingLookbackEngineModel(null)
    member internal this.Inject v = _AnalyticContinuousPartialFloatingLookbackEngine.Value <- v
    static member Cast (p : ICell<AnalyticContinuousPartialFloatingLookbackEngine>) = 
        if p :? AnalyticContinuousPartialFloatingLookbackEngineModel then 
            p :?> AnalyticContinuousPartialFloatingLookbackEngineModel
        else
            let o = new AnalyticContinuousPartialFloatingLookbackEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
