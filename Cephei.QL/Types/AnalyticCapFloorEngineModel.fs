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


  </summary> *)
[<AutoSerializable(true)>]
type AnalyticCapFloorEngineModel
    ( model                                        : ICell<IAffineModel>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticCapFloorEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
(*
    Functions
*)
    let mutable
        _AnalyticCapFloorEngine                    = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticCapFloorEngine (model.Value))))
    let _setModel                                  (model : ICell<Handle<IAffineModel>>)   
                                                   = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.setModel(model.Value)
                                                                                             _AnalyticCapFloorEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.registerWith(handler.Value)
                                                                                             _AnalyticCapFloorEngine.Value)
    let _reset                                     = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.reset()
                                                                                             _AnalyticCapFloorEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.unregisterWith(handler.Value)
                                                                                             _AnalyticCapFloorEngine.Value)
    let _update                                    = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.update()
                                                                                             _AnalyticCapFloorEngine.Value)
    do this.Bind(_AnalyticCapFloorEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticCapFloorEngineModel(null,null)
    member internal this.Inject v = _AnalyticCapFloorEngine <- v
    static member Cast (p : ICell<AnalyticCapFloorEngine>) = 
        if p :? AnalyticCapFloorEngineModel then 
            p :?> AnalyticCapFloorEngineModel
        else
            let o = new AnalyticCapFloorEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type AnalyticCapFloorEngineModel1
    ( model                                        : ICell<IAffineModel>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticCapFloorEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _termStructure                             = termStructure
(*
    Functions
*)
    let mutable
        _AnalyticCapFloorEngine                    = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticCapFloorEngine (model.Value, termStructure.Value))))
    let _setModel                                  (model : ICell<Handle<IAffineModel>>)   
                                                   = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.setModel(model.Value)
                                                                                             _AnalyticCapFloorEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.registerWith(handler.Value)
                                                                                             _AnalyticCapFloorEngine.Value)
    let _reset                                     = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.reset()
                                                                                             _AnalyticCapFloorEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.unregisterWith(handler.Value)
                                                                                             _AnalyticCapFloorEngine.Value)
    let _update                                    = triv _AnalyticCapFloorEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticCapFloorEngine).Value.update()
                                                                                             _AnalyticCapFloorEngine.Value)
    do this.Bind(_AnalyticCapFloorEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticCapFloorEngineModel1(null,null,null)
    member internal this.Inject v = _AnalyticCapFloorEngine <- v
    static member Cast (p : ICell<AnalyticCapFloorEngine>) = 
        if p :? AnalyticCapFloorEngineModel1 then 
            p :?> AnalyticCapFloorEngineModel1
        else
            let o = new AnalyticCapFloorEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.termStructure                      = _termStructure 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
