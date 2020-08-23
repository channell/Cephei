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
Use Merton73 engine as default.

  </summary> *)
[<AutoSerializable(true)>]
type FDDividendEngineModel
    () as this =
    inherit Model<FDDividendEngine> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FDDividendEngine                          = cell (fun () -> new FDDividendEngine ())
    let _factory2                                  (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.factory2(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.calculate(r.Value)
                                                                     _FDDividendEngine.Value)
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.setStepCondition(impl.Value)
                                                                     _FDDividendEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDDividendEngine.Value.ensureStrikeInGrid()
                                                                     _FDDividendEngine.Value)
    let _getResidualTime                           = triv (fun () -> _FDDividendEngine.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDDividendEngine.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDDividendEngine.Value.intrinsicValues_)
    do this.Bind(_FDDividendEngine)

(* 
    Externally visible/bindable properties
*)
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
(* <summary>
Use Merton73 engine as default.

  </summary> *)
[<AutoSerializable(true)>]
type FDDividendEngineModel1
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    ) as this =

    inherit Model<FDDividendEngine> ()
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
    let _FDDividendEngine                          = cell (fun () -> new FDDividendEngine (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _factory2                                  (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.factory2(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _calculate                                 (r : ICell<IPricingEngineResults>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.calculate(r.Value)
                                                                     _FDDividendEngine.Value)
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = triv (fun () -> _FDDividendEngine.Value.setStepCondition(impl.Value)
                                                                     _FDDividendEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> _FDDividendEngine.Value.ensureStrikeInGrid()
                                                                     _FDDividendEngine.Value)
    let _getResidualTime                           = triv (fun () -> _FDDividendEngine.Value.getResidualTime())
    let _grid                                      = triv (fun () -> _FDDividendEngine.Value.grid())
    let _intrinsicValues_                          = triv (fun () -> _FDDividendEngine.Value.intrinsicValues_)
    do this.Bind(_FDDividendEngine)

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
