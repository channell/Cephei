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

public FDEngineAdapter(GeneralizedBlackScholesProcess process, Size timeSteps=100, Size gridPoints=100, bool timeDependent = false)
  </summary> *)
[<AutoSerializable(true)>]
type FDEngineAdapterModel<'Base, 'Engine when 'Base :> FDConditionEngineTemplate and 'Base : (new : unit -> 'Base) and 'Engine :> IGenericEngine and 'Engine : (new : unit -> 'Engine)>
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    ) as this =

    inherit Model<FDEngineAdapter<'Base,'Engine>> ()
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
    let mutable
        _FDEngineAdapter                           = make (fun () -> new FDEngineAdapter<'Base,'Engine> (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.registerWith(handler.Value)
                                                                                      _FDEngineAdapter.Value)
    let _reset                                     = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.reset()
                                                                                      _FDEngineAdapter.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.unregisterWith(handler.Value)
                                                                                      _FDEngineAdapter.Value)
    let _update                                    = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.update()
                                                                                      _FDEngineAdapter.Value)
    let _ensureStrikeInGrid                        = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.ensureStrikeInGrid()
                                                                                      _FDEngineAdapter.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.getResidualTime())
    let _grid                                      = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.grid())
    let _intrinsicValues_                          = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.intrinsicValues_)
    do this.Bind(_FDEngineAdapter)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.gridPoints                         = _gridPoints 
    member this.timeDependent                      = _timeDependent 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
(* <summary>

required for generics
  </summary> *)
[<AutoSerializable(true)>]
type FDEngineAdapterModel1<'Base, 'Engine when 'Base :> FDConditionEngineTemplate and 'Base : (new : unit -> 'Base) and 'Engine :> IGenericEngine and 'Engine : (new : unit -> 'Engine)>
    () as this =
    inherit Model<FDEngineAdapter<'Base,'Engine>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _FDEngineAdapter                           = make (fun () -> new FDEngineAdapter<'Base,'Engine> ())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.registerWith(handler.Value)
                                                                                      _FDEngineAdapter.Value)
    let _reset                                     = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.reset()
                                                                                      _FDEngineAdapter.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.unregisterWith(handler.Value)
                                                                                      _FDEngineAdapter.Value)
    let _update                                    = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.update()
                                                                                      _FDEngineAdapter.Value)
    let _ensureStrikeInGrid                        = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.ensureStrikeInGrid()
                                                                                      _FDEngineAdapter.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.getResidualTime())
    let _grid                                      = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.grid())
    let _intrinsicValues_                          = triv _FDEngineAdapter (fun () -> _FDEngineAdapter.Value.intrinsicValues_)
    do this.Bind(_FDEngineAdapter)

(* 
    Externally visible/bindable properties
*)
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
