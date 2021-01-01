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
  vanillaengines
constructor
  </summary> *)
[<AutoSerializable(true)>]
type FDBermudanEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<int>
    , gridPoints                                   : ICell<int>
    , timeDependent                                : ICell<bool>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FDBermudanEngine> ()
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
        _FDBermudanEngine                          = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FDBermudanEngine (Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.registerWith(handler.Value)
                                                                                       _FDBermudanEngine.Value)
    let _reset                                     = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.reset()
                                                                                       _FDBermudanEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.unregisterWith(handler.Value)
                                                                                       _FDBermudanEngine.Value)
    let _update                                    = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.update()
                                                                                       _FDBermudanEngine.Value)
    let _setStepCondition                          (impl : ICell<Func<IStepCondition<Vector>>>)   
                                                   = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.setStepCondition(impl.Value)
                                                                                       _FDBermudanEngine.Value)
    let _ensureStrikeInGrid                        = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.ensureStrikeInGrid()
                                                                                       _FDBermudanEngine.Value)
    let _factory                                   (Process : ICell<GeneralizedBlackScholesProcess>) (timeSteps : ICell<int>) (gridPoints : ICell<int>) (timeDependent : ICell<bool>)   
                                                   = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.factory(Process.Value, timeSteps.Value, gridPoints.Value, timeDependent.Value))
    let _getResidualTime                           = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.getResidualTime())
    let _grid                                      = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.grid())
    let _intrinsicValues_                          = triv _FDBermudanEngine (fun () -> (curryEvaluationDate _evaluationDate _FDBermudanEngine).Value.intrinsicValues_)
    do this.Bind(_FDBermudanEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FDBermudanEngineModel(null,null,null,null,null)
    member internal this.Inject v = _FDBermudanEngine <- v
    static member Cast (p : ICell<FDBermudanEngine>) = 
        if p :? FDBermudanEngineModel then 
            p :?> FDBermudanEngineModel
        else
            let o = new FDBermudanEngineModel ()
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
    member this.SetStepCondition                   impl   
                                                   = _setStepCondition impl 
    member this.EnsureStrikeInGrid                 = _ensureStrikeInGrid
    member this.Factory                            Process timeSteps gridPoints timeDependent   
                                                   = _factory Process timeSteps gridPoints timeDependent 
    member this.GetResidualTime                    = _getResidualTime
    member this.Grid                               = _grid
    member this.IntrinsicValues_                   = _intrinsicValues_
