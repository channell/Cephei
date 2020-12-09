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
type FdHullWhiteSwaptionEngineModel
    ( model                                        : ICell<HullWhite>
    , tGrid                                        : ICell<int>
    , xGrid                                        : ICell<int>
    , dampingSteps                                 : ICell<int>
    , invEps                                       : ICell<double>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FdHullWhiteSwaptionEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _tGrid                                     = tGrid
    let _xGrid                                     = xGrid
    let _dampingSteps                              = dampingSteps
    let _invEps                                    = invEps
    let _schemeDesc                                = schemeDesc
(*
    Functions
*)
    let mutable
        _FdHullWhiteSwaptionEngine                 = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FdHullWhiteSwaptionEngine (model.Value, tGrid.Value, xGrid.Value, dampingSteps.Value, invEps.Value, schemeDesc.Value))))
    let _setModel                                  (model : ICell<Handle<HullWhite>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FdHullWhiteSwaptionEngine).Value.setModel(model.Value)
                                                                     _FdHullWhiteSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FdHullWhiteSwaptionEngine).Value.registerWith(handler.Value)
                                                                     _FdHullWhiteSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _FdHullWhiteSwaptionEngine).Value.reset()
                                                                     _FdHullWhiteSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FdHullWhiteSwaptionEngine).Value.unregisterWith(handler.Value)
                                                                     _FdHullWhiteSwaptionEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _FdHullWhiteSwaptionEngine).Value.update()
                                                                     _FdHullWhiteSwaptionEngine.Value)
    do this.Bind(_FdHullWhiteSwaptionEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FdHullWhiteSwaptionEngineModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _FdHullWhiteSwaptionEngine <- v
    static member Cast (p : ICell<FdHullWhiteSwaptionEngine>) = 
        if p :? FdHullWhiteSwaptionEngineModel then 
            p :?> FdHullWhiteSwaptionEngineModel
        else
            let o = new FdHullWhiteSwaptionEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.tGrid                              = _tGrid 
    member this.xGrid                              = _xGrid 
    member this.dampingSteps                       = _dampingSteps 
    member this.invEps                             = _invEps 
    member this.schemeDesc                         = _schemeDesc 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
