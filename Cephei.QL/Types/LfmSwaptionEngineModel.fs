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
  swaptionengines

  </summary> *)
[<AutoSerializable(true)>]
type LfmSwaptionEngineModel
    ( model                                        : ICell<LiborForwardModel>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<LfmSwaptionEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let mutable
        _LfmSwaptionEngine                         = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new LfmSwaptionEngine (model.Value, discountCurve.Value))))
    let _setModel                                  (model : ICell<Handle<LiborForwardModel>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LfmSwaptionEngine).Value.setModel(model.Value)
                                                                     _LfmSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LfmSwaptionEngine).Value.registerWith(handler.Value)
                                                                     _LfmSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _LfmSwaptionEngine).Value.reset()
                                                                     _LfmSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _LfmSwaptionEngine).Value.unregisterWith(handler.Value)
                                                                     _LfmSwaptionEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _LfmSwaptionEngine).Value.update()
                                                                     _LfmSwaptionEngine.Value)
    do this.Bind(_LfmSwaptionEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new LfmSwaptionEngineModel(null,null,null)
    member internal this.Inject v = _LfmSwaptionEngine <- v
    static member Cast (p : ICell<LfmSwaptionEngine>) = 
        if p :? LfmSwaptionEngineModel then 
            p :?> LfmSwaptionEngineModel
        else
            let o = new LfmSwaptionEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.discountCurve                      = _discountCurve 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
