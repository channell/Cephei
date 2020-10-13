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
This engine uses the same algorithm that was used in quantlib in versions 0.3.11 and earlier.  It produces results that are different from the Merton 73 engine.  Review literature to see whether this is described

  </summary> *)
[<AutoSerializable(true)>]
type FDDividendEngineShiftScaleModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    ) as this =

    inherit Model<FDDividendEngineShiftScale> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _gridPoints                                = gridPoints
    let _timeDependent                             = timeDependent
(*
    Functions
*)
    let _FDDividendEngineShiftScale                = cell (fun () -> new FDDividendEngineShiftScale (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _factory2                                  (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDDividendEngineShiftScale.Value.factory2(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDDividendEngineShiftScale.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = triv (fun () -> _FDDividendEngineShiftScale.Value.calculate(r.Value)
                                                                     _FDDividendEngineShiftScale.Value)
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = triv (fun () -> _FDDividendEngineShiftScale.Value.setStepCondition(impl.Value)
                                                                     _FDDividendEngineShiftScale.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDDividendEngineShiftScale.Value.ensureStrikeInGrid()
                                                                     _FDDividendEngineShiftScale.Value)
    let _getResidualTime                           = triv (fun () -> _FDDividendEngineShiftScale.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDDividendEngineShiftScale.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDDividendEngineShiftScale.Value.intrinsicValues_)
    do this.Bind(_FDDividendEngineShiftScale)
(* 
    casting 
*)
    internal new () = new FDDividendEngineShiftScaleModel(null,null,null,null)
    member internal this.Inject v = _FDDividendEngineShiftScale.Value <- v
    static member Cast (p : ICell<FDDividendEngineShiftScale>) = 
        if p :? FDDividendEngineShiftScaleModel then 
            p :?> FDDividendEngineShiftScaleModel
        else
            let o = new FDDividendEngineShiftScaleModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.gridPoints                         = _gridPoints 
    member this.timeDependent                      = _timeDependent 
    member this.Factory2                           Process timeSteps gridPoints timeDependent   
                                                   = _factory2 Process timeSteps gridPoints timeDependent 
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.Calculate                          r   
                                                   = _calculate r 
    member this.SetStepCondition                   impl   
                                                   = _setStepCondition impl 
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
