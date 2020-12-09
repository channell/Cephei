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
  vanillaengines  the correctness of the returned value is tested by checking it against analytic results.

  </summary> *)
[<AutoSerializable(true)>]
type FDEuropeanEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FDEuropeanEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _gridPoints                                = gridPoints
    let _timeDependent                             = timeDependent
(*
    Functions
*)
    let mutable
        _FDEuropeanEngine                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FDEuropeanEngine (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.registerWith(handler.Value)
                                                                     _FDEuropeanEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.reset()
                                                                     _FDEuropeanEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.unregisterWith(handler.Value)
                                                                     _FDEuropeanEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.update()
                                                                     _FDEuropeanEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.ensureStrikeInGrid()
                                                                     _FDEuropeanEngine.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.getResidualTime())
    let _grid                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.grid())
    let _intrinsicValues_                          = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.intrinsicValues_)
    do this.Bind(_FDEuropeanEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FDEuropeanEngineModel(null,null,null,null,null)
    member internal this.Inject v = _FDEuropeanEngine <- v
    static member Cast (p : ICell<FDEuropeanEngine>) = 
        if p :? FDEuropeanEngineModel then 
            p :?> FDEuropeanEngineModel
        else
            let o = new FDEuropeanEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

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
  vanillaengines  the correctness of the returned value is tested by checking it against analytic results.

  </summary> *)
[<AutoSerializable(true)>]
type FDEuropeanEngineModel1
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FDEuropeanEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _gridPoints                                = gridPoints
(*
    Functions
*)
    let mutable
        _FDEuropeanEngine                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FDEuropeanEngine (Process.Value, timeSteps.Value, gridPoints.Value))))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.registerWith(handler.Value)
                                                                     _FDEuropeanEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.reset()
                                                                     _FDEuropeanEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.unregisterWith(handler.Value)
                                                                     _FDEuropeanEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.update()
                                                                     _FDEuropeanEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.ensureStrikeInGrid()
                                                                     _FDEuropeanEngine.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.getResidualTime())
    let _grid                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.grid())
    let _intrinsicValues_                          = triv (fun () -> (curryEvaluationDate _evaluationDate _FDEuropeanEngine).Value.intrinsicValues_)
    do this.Bind(_FDEuropeanEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FDEuropeanEngineModel1(null,null,null,null)
    member internal this.Inject v = _FDEuropeanEngine <- v
    static member Cast (p : ICell<FDEuropeanEngine>) = 
        if p :? FDEuropeanEngineModel1 then 
            p :?> FDEuropeanEngineModel1
        else
            let o = new FDEuropeanEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.gridPoints                         = _gridPoints 
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
