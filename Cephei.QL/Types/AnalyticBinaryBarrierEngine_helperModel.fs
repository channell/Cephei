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
calc helper object

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticBinaryBarrierEngine_helperModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , payoff                                       : ICell<StrikedTypePayoff>
    , exercise                                     : ICell<AmericanExercise>
    , arguments                                    : ICell<BarrierOption.Arguments>
    ) as this =

    inherit Model<AnalyticBinaryBarrierEngine_helper> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let _arguments                                 = arguments
(*
    Functions
*)
    let _AnalyticBinaryBarrierEngine_helper        = cell (fun () -> new AnalyticBinaryBarrierEngine_helper (Process.Value, payoff.Value, exercise.Value, arguments.Value))
    let _payoffAtExpiry                            (spot : ICell<double>) (variance : ICell<double>) (discount : ICell<double>)   
                                                   = cell (fun () -> _AnalyticBinaryBarrierEngine_helper.Value.payoffAtExpiry(spot.Value, variance.Value, discount.Value))
    do this.Bind(_AnalyticBinaryBarrierEngine_helper)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.arguments                          = _arguments 
    member this.PayoffAtExpiry                     spot variance discount   
                                                   = _payoffAtExpiry spot variance discount 
