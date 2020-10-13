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
  Pricing Engine for barrier options using analytical formulae   The formulas are taken from "Option pricing formulas", E.G. Haug, McGraw-Hill, p.69 and following.  barrierengines  the correctness of the returned value is tested by reproducing results available in literature.

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticBarrierEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    ) as this =

    inherit Model<AnalyticBarrierEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
(*
    Functions
*)
    let _AnalyticBarrierEngine                     = cell (fun () -> new AnalyticBarrierEngine (Process.Value))
    do this.Bind(_AnalyticBarrierEngine)
(* 
    casting 
*)
    internal new () = new AnalyticBarrierEngineModel(null)
    member internal this.Inject v = _AnalyticBarrierEngine.Value <- v
    static member Cast (p : ICell<AnalyticBarrierEngine>) = 
        if p :? AnalyticBarrierEngineModel then 
            p :?> AnalyticBarrierEngineModel
        else
            let o = new AnalyticBarrierEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
