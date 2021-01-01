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
  References:  Karel in't Hout, Joris Bierkens, Antoine von der Ploeg, Joe in't Panhuis, A Semi closed-from analytic pricing formula for call options in a hybrid Heston-Hull-White Model.  A. Sepp, Pricing European-Style Options under Jump Diffusion Processes with Stochastic Volatility: Applications of Fourier Transform (<http://math.ut.ee/~spartak/papers/stochjumpvols.pdf>)  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature, testing against QuantLib's analytic Heston and Black-Scholes-Merton Hull-White engine

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticHestonHullWhiteEngineModel
    ( hestonModel                                  : ICell<HestonModel>
    , hullWhiteModel                               : ICell<HullWhite>
    , relTolerance                                 : ICell<double>
    , maxEvaluations                               : ICell<int>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticHestonHullWhiteEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _hestonModel                               = hestonModel
    let _hullWhiteModel                            = hullWhiteModel
    let _relTolerance                              = relTolerance
    let _maxEvaluations                            = maxEvaluations
(*
    Functions
*)
    let mutable
        _AnalyticHestonHullWhiteEngine             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticHestonHullWhiteEngine (hestonModel.Value, hullWhiteModel.Value, relTolerance.Value, maxEvaluations.Value))))
    let _update                                    = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.update()
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _numberOfEvaluations                       = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.setModel(model.Value)
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.registerWith(handler.Value)
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _reset                                     = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.reset()
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.unregisterWith(handler.Value)
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    do this.Bind(_AnalyticHestonHullWhiteEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticHestonHullWhiteEngineModel(null,null,null,null,null)
    member internal this.Inject v = _AnalyticHestonHullWhiteEngine <- v
    static member Cast (p : ICell<AnalyticHestonHullWhiteEngine>) = 
        if p :? AnalyticHestonHullWhiteEngineModel then 
            p :?> AnalyticHestonHullWhiteEngineModel
        else
            let o = new AnalyticHestonHullWhiteEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.hestonModel                        = _hestonModel 
    member this.hullWhiteModel                     = _hullWhiteModel 
    member this.relTolerance                       = _relTolerance 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.Update                             = _update
    member this.NumberOfEvaluations                = _numberOfEvaluations
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  References:  Karel in't Hout, Joris Bierkens, Antoine von der Ploeg, Joe in't Panhuis, A Semi closed-from analytic pricing formula for call options in a hybrid Heston-Hull-White Model.  A. Sepp, Pricing European-Style Options under Jump Diffusion Processes with Stochastic Volatility: Applications of Fourier Transform (<http://math.ut.ee/~spartak/papers/stochjumpvols.pdf>)  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature, testing against QuantLib's analytic Heston and Black-Scholes-Merton Hull-White engine
see AnalticHestonEninge for usage of different constructors
  </summary> *)
[<AutoSerializable(true)>]
type AnalyticHestonHullWhiteEngineModel1
    ( hestonModel                                  : ICell<HestonModel>
    , hullWhiteModel                               : ICell<HullWhite>
    , integrationOrder                             : ICell<int>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticHestonHullWhiteEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _hestonModel                               = hestonModel
    let _hullWhiteModel                            = hullWhiteModel
    let _integrationOrder                          = integrationOrder
(*
    Functions
*)
    let mutable
        _AnalyticHestonHullWhiteEngine             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticHestonHullWhiteEngine (hestonModel.Value, hullWhiteModel.Value, integrationOrder.Value))))
    let _update                                    = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.update()
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _numberOfEvaluations                       = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.setModel(model.Value)
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.registerWith(handler.Value)
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _reset                                     = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.reset()
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _AnalyticHestonHullWhiteEngine (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonHullWhiteEngine).Value.unregisterWith(handler.Value)
                                                                                                    _AnalyticHestonHullWhiteEngine.Value)
    do this.Bind(_AnalyticHestonHullWhiteEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticHestonHullWhiteEngineModel1(null,null,null,null)
    member internal this.Inject v = _AnalyticHestonHullWhiteEngine <- v
    static member Cast (p : ICell<AnalyticHestonHullWhiteEngine>) = 
        if p :? AnalyticHestonHullWhiteEngineModel1 then 
            p :?> AnalyticHestonHullWhiteEngineModel1
        else
            let o = new AnalyticHestonHullWhiteEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.hestonModel                        = _hestonModel 
    member this.hullWhiteModel                     = _hullWhiteModel 
    member this.integrationOrder                   = _integrationOrder 
    member this.Update                             = _update
    member this.NumberOfEvaluations                = _numberOfEvaluations
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
