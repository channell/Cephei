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
  References:  M Forde, A Jacquier, R Lee, The small-time smile and term structure of implied volatility under the Heston model SIAM Journal on Financial Mathematics, 2012 - SIAM  M Lorig, S Pagliarani, A Pascucci, Explicit implied vols for multifactor local-stochastic vol models arXiv preprint arXiv:1306.5447v3, 2014 - arxiv.org  vanillaengines

  </summary> *)
[<AutoSerializable(true)>]
type HestonExpansionEngineModel
    ( model                                        : ICell<HestonModel>
    , formula                                      : ICell<HestonExpansionEngine.HestonExpansionFormula>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<HestonExpansionEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _formula                                   = formula
(*
    Functions
*)
    let mutable
        _HestonExpansionEngine                     = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new HestonExpansionEngine (model.Value, formula.Value))))
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _HestonExpansionEngine).Value.setModel(model.Value)
                                                                     _HestonExpansionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _HestonExpansionEngine).Value.registerWith(handler.Value)
                                                                     _HestonExpansionEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _HestonExpansionEngine).Value.reset()
                                                                     _HestonExpansionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _HestonExpansionEngine).Value.unregisterWith(handler.Value)
                                                                     _HestonExpansionEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _HestonExpansionEngine).Value.update()
                                                                     _HestonExpansionEngine.Value)
    do this.Bind(_HestonExpansionEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new HestonExpansionEngineModel(null,null,null)
    member internal this.Inject v = _HestonExpansionEngine <- v
    static member Cast (p : ICell<HestonExpansionEngine>) = 
        if p :? HestonExpansionEngineModel then 
            p :?> HestonExpansionEngineModel
        else
            let o = new HestonExpansionEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.formula                            = _formula 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
