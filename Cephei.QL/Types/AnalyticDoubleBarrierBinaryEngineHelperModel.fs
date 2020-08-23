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
type AnalyticDoubleBarrierBinaryEngineHelperModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , payoff                                       : ICell<CashOrNothingPayoff>
    , arguments                                    : ICell<DoubleBarrierOption.Arguments>
    ) as this =

    inherit Model<AnalyticDoubleBarrierBinaryEngineHelper> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _payoff                                    = payoff
    let _arguments                                 = arguments
(*
    Functions
*)
    let _AnalyticDoubleBarrierBinaryEngineHelper   = cell (fun () -> new AnalyticDoubleBarrierBinaryEngineHelper (Process.Value, payoff.Value, arguments.Value))
    let _payoffAtExpiry                            (spot : ICell<double>) (variance : ICell<double>) (barrierType : ICell<DoubleBarrier.Type>) (maxIteration : ICell<int>) (requiredConvergence : ICell<double>)   
                                                   = triv (fun () -> _AnalyticDoubleBarrierBinaryEngineHelper.Value.payoffAtExpiry(spot.Value, variance.Value, barrierType.Value, maxIteration.Value, requiredConvergence.Value))
    let _payoffKIKO                                (spot : ICell<double>) (variance : ICell<double>) (barrierType : ICell<DoubleBarrier.Type>) (maxIteration : ICell<int>) (requiredConvergence : ICell<double>)   
                                                   = triv (fun () -> _AnalyticDoubleBarrierBinaryEngineHelper.Value.payoffKIKO(spot.Value, variance.Value, barrierType.Value, maxIteration.Value, requiredConvergence.Value))
    do this.Bind(_AnalyticDoubleBarrierBinaryEngineHelper)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.payoff                             = _payoff 
    member this.arguments                          = _arguments 
    member this.PayoffAtExpiry                     spot variance barrierType maxIteration requiredConvergence   
                                                   = _payoffAtExpiry spot variance barrierType maxIteration requiredConvergence 
    member this.PayoffKIKO                         spot variance barrierType maxIteration requiredConvergence   
                                                   = _payoffKIKO spot variance barrierType maxIteration requiredConvergence 
