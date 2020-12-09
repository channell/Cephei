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
type GenericModelEngineModel<'ModelType, 'ArgumentsType, 'ResultsType when 'ModelType :> IObservable and 'ArgumentsType :> IPricingEngineArguments and 'ArgumentsType : (new : unit -> 'ArgumentsType) and 'ResultsType :> IPricingEngineResults and 'ResultsType : (new : unit -> 'ResultsType)>
    ( evaluationDate                               : ICell<Date>
    ) as this =
    inherit Model<GenericModelEngine<'ModelType,'ArgumentsType,'ResultsType>> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
(*
    Functions
*)
    let mutable
        _GenericModelEngine                        = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new GenericModelEngine<'ModelType,'ArgumentsType,'ResultsType> ())))
    let _setModel                                  (model : ICell<Handle<'ModelType>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.setModel(model.Value)
                                                                     _GenericModelEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.registerWith(handler.Value)
                                                                     _GenericModelEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.reset()
                                                                     _GenericModelEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.unregisterWith(handler.Value)
                                                                     _GenericModelEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.update()
                                                                     _GenericModelEngine.Value)
    do this.Bind(_GenericModelEngine)

(* 
    Externally visible/bindable properties
*)
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
type GenericModelEngineModel1<'ModelType, 'ArgumentsType, 'ResultsType when 'ModelType :> IObservable and 'ArgumentsType :> IPricingEngineArguments and 'ArgumentsType : (new : unit -> 'ArgumentsType) and 'ResultsType :> IPricingEngineResults and 'ResultsType : (new : unit -> 'ResultsType)>
    ( model                                        : ICell<'ModelType>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<GenericModelEngine<'ModelType,'ArgumentsType,'ResultsType>> ()
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
        _GenericModelEngine                        = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new GenericModelEngine<'ModelType,'ArgumentsType,'ResultsType> (model.Value))))
    let _setModel                                  (model : ICell<Handle<'ModelType>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.setModel(model.Value)
                                                                     _GenericModelEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.registerWith(handler.Value)
                                                                     _GenericModelEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.reset()
                                                                     _GenericModelEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.unregisterWith(handler.Value)
                                                                     _GenericModelEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.update()
                                                                     _GenericModelEngine.Value)
    do this.Bind(_GenericModelEngine)

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
type GenericModelEngineModel2<'ModelType, 'ArgumentsType, 'ResultsType when 'ModelType :> IObservable and 'ArgumentsType :> IPricingEngineArguments and 'ArgumentsType : (new : unit -> 'ArgumentsType) and 'ResultsType :> IPricingEngineResults and 'ResultsType : (new : unit -> 'ResultsType)>
    ( model                                        : ICell<Handle<'ModelType>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<GenericModelEngine<'ModelType,'ArgumentsType,'ResultsType>> ()
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
        _GenericModelEngine                        = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new GenericModelEngine<'ModelType,'ArgumentsType,'ResultsType> (model.Value))))
    let _setModel                                  (model : ICell<Handle<'ModelType>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.setModel(model.Value)
                                                                     _GenericModelEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.registerWith(handler.Value)
                                                                     _GenericModelEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.reset()
                                                                     _GenericModelEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.unregisterWith(handler.Value)
                                                                     _GenericModelEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _GenericModelEngine).Value.update()
                                                                     _GenericModelEngine.Value)
    do this.Bind(_GenericModelEngine)

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
