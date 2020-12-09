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
  Derived engines only need to implement the <tt>calculate()</tt> method

  </summary> *)
[<AutoSerializable(true)>]
type LatticeShortRateModelEngineModel<'ArgumentsType, 'ResultsType when 'ArgumentsType :> IPricingEngineArguments and 'ArgumentsType : (new : unit -> 'ArgumentsType) and 'ResultsType :> IPricingEngineResults and 'ResultsType : (new : unit -> 'ResultsType)>
    ( model                                        : ICell<ShortRateModel>
    , timeGrid                                     : ICell<TimeGrid>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<LatticeShortRateModelEngine<'ArgumentsType,'ResultsType>> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _timeGrid                                  = timeGrid
(*
    Functions
*)
    let mutable
        _LatticeShortRateModelEngine               = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new LatticeShortRateModelEngine<'ArgumentsType,'ResultsType> (model.Value, timeGrid.Value))))
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.update()
                                                                     _LatticeShortRateModelEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.setModel(model.Value)
                                                                     _LatticeShortRateModelEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.registerWith(handler.Value)
                                                                     _LatticeShortRateModelEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.reset()
                                                                     _LatticeShortRateModelEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.unregisterWith(handler.Value)
                                                                     _LatticeShortRateModelEngine.Value)
    do this.Bind(_LatticeShortRateModelEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.timeGrid                           = _timeGrid 
    member this.Update                             = _update
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  Derived engines only need to implement the <tt>calculate()</tt> method

  </summary> *)
[<AutoSerializable(true)>]
type LatticeShortRateModelEngineModel1<'ArgumentsType, 'ResultsType when 'ArgumentsType :> IPricingEngineArguments and 'ArgumentsType : (new : unit -> 'ArgumentsType) and 'ResultsType :> IPricingEngineResults and 'ResultsType : (new : unit -> 'ResultsType)>
    ( model                                        : ICell<ShortRateModel>
    , timeSteps                                    : ICell<int>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<LatticeShortRateModelEngine<'ArgumentsType,'ResultsType>> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _timeSteps                                 = timeSteps
(*
    Functions
*)
    let mutable
        _LatticeShortRateModelEngine               = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new LatticeShortRateModelEngine<'ArgumentsType,'ResultsType> (model.Value, timeSteps.Value))))
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.update()
                                                                     _LatticeShortRateModelEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.setModel(model.Value)
                                                                     _LatticeShortRateModelEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.registerWith(handler.Value)
                                                                     _LatticeShortRateModelEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.reset()
                                                                     _LatticeShortRateModelEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LatticeShortRateModelEngine).Value.unregisterWith(handler.Value)
                                                                     _LatticeShortRateModelEngine.Value)
    do this.Bind(_LatticeShortRateModelEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.timeSteps                          = _timeSteps 
    member this.Update                             = _update
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
