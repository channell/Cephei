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
  vanillaengines  - the correctness of the returned value is tested by reproducing results available in literature. - the correctness of the returned greeks is tested by reproducing numerical derivatives.
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type FDAmericanEngineModel
    ( evaluationDate                               : ICell<Date>
    ) as this =
    inherit Model<FDAmericanEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
(*
    Functions
*)
    let mutable
        _FDAmericanEngine                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FDAmericanEngine ())))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.factory(Process.Value, timeSteps.Value, gridPoints.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.registerWith(handler.Value)
                                                                     _FDAmericanEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.reset()
                                                                     _FDAmericanEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.unregisterWith(handler.Value)
                                                                     _FDAmericanEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.update()
                                                                     _FDAmericanEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.ensureStrikeInGrid()
                                                                     _FDAmericanEngine.Value)
    let _getResidualTime                           = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.getResidualTime())
    let _grid                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.grid())
    let _intrinsicValues_                          = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.intrinsicValues_)
    do this.Bind(_FDAmericanEngine)
(* 
    casting 
*)
    
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FDAmericanEngineModel(null)
    member internal this.Inject v = _FDAmericanEngine <- v
    static member Cast (p : ICell<FDAmericanEngine>) = 
        if p :? FDAmericanEngineModel then 
            p :?> FDAmericanEngineModel
        else
            let o = new FDAmericanEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            Process timeSteps gridPoints   
                                                   = _factory Process timeSteps gridPoints 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
(* <summary>
  vanillaengines  - the correctness of the returned value is tested by reproducing results available in literature. - the correctness of the returned greeks is tested by reproducing numerical derivatives.

  </summary> *)
[<AutoSerializable(true)>]
type FDAmericanEngineModel1
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FDAmericanEngine> ()
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
        _FDAmericanEngine                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FDAmericanEngine (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))))
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.factory(Process.Value, timeSteps.Value, gridPoints.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.registerWith(handler.Value)
                                                                     _FDAmericanEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.reset()
                                                                     _FDAmericanEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.unregisterWith(handler.Value)
                                                                     _FDAmericanEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.update()
                                                                     _FDAmericanEngine.Value)
    let _ensureStrikeInGrid                        = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.ensureStrikeInGrid()
                                                                     _FDAmericanEngine.Value)
    let _getResidualTime                           = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.getResidualTime())
    let _grid                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.grid())
    let _intrinsicValues_                          = triv (fun () -> (curryEvaluationDate _evaluationDate _FDAmericanEngine).Value.intrinsicValues_)
    do this.Bind(_FDAmericanEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FDAmericanEngineModel1(null,null,null,null,null)
    member internal this.Inject v = _FDAmericanEngine <- v
    static member Cast (p : ICell<FDAmericanEngine>) = 
        if p :? FDAmericanEngineModel1 then 
            p :?> FDAmericanEngineModel1
        else
            let o = new FDAmericanEngineModel1 ()
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
    member this.Factory                            Process timeSteps gridPoints   
                                                   = _factory Process timeSteps gridPoints 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
