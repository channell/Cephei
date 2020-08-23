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
  The formulas are taken from "The complete guide to option pricing formulas 2nd Ed", E.G. Haug, McGraw-Hill, p.156 and following. Implements the Ikeda and Kunitomo series (see "Pricing Options with Curved Boundaries Mathematical Finance 2/1992"). This code handles only flat barriers  barrierengines  the formula holds only when strike is in the barrier range  the correctness of the returned value is tested by reproducing results available in literature.

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticDoubleBarrierEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , series                                       : ICell<int>
    ) as this =

    inherit Model<AnalyticDoubleBarrierEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _series                                    = series
(*
    Functions
*)
    let _AnalyticDoubleBarrierEngine               = cell (fun () -> new AnalyticDoubleBarrierEngine (Process.Value, series.Value))
    do this.Bind(_AnalyticDoubleBarrierEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.series                             = _series 
