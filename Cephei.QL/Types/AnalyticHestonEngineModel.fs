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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  A. Sepp, Pricing European-Style Options under Jump Diffusion Processes with Stochastic Volatility: Applications of Fourier Transform (<http://math.ut.ee/~spartak/papers/stochjumpvols.pdf>)  R. Lord and C. Kahl, Why the rotation count algorithm works, http://papers.ssrn.com/sol3/papers.cfm?abstract_id=921335  H. Albrecher, P. Mayer, W.Schoutens and J. Tistaert, The Little Heston Trap, http://www.schoutens.be/HestonTrap.pdf  J. Gatheral, The Volatility Surface: A Practitioner's Guide, Wiley Finance  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature and comparison with Black pricing.
Simple to use constructor: Using adaptive Gauss-Lobatto integration and Gatheral's version of complex log. Be aware: using a too large number for maxEvaluations might result in a stack overflow as the Lobatto integration is a recursive algorithm.
  </summary> *)
[<AutoSerializable(true)>]
type AnalyticHestonEngineModel
    ( model                                        : ICell<HestonModel>
    , relTolerance                                 : ICell<double>
    , maxEvaluations                               : ICell<int>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticHestonEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _relTolerance                              = relTolerance
    let _maxEvaluations                            = maxEvaluations
(*
    Functions
*)
    let mutable
        _AnalyticHestonEngine                      = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticHestonEngine (model.Value, relTolerance.Value, maxEvaluations.Value))))
    let _numberOfEvaluations                       = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.setModel(model.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.registerWith(handler.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.reset()
                                                                     _AnalyticHestonEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.unregisterWith(handler.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.update()
                                                                     _AnalyticHestonEngine.Value)
    do this.Bind(_AnalyticHestonEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticHestonEngineModel(null,null,null,null)
    member internal this.Inject v = _AnalyticHestonEngine <- v
    static member Cast (p : ICell<AnalyticHestonEngine>) = 
        if p :? AnalyticHestonEngineModel then 
            p :?> AnalyticHestonEngineModel
        else
            let o = new AnalyticHestonEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.relTolerance                       = _relTolerance 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.NumberOfEvaluations                = _numberOfEvaluations
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  A. Sepp, Pricing European-Style Options under Jump Diffusion Processes with Stochastic Volatility: Applications of Fourier Transform (<http://math.ut.ee/~spartak/papers/stochjumpvols.pdf>)  R. Lord and C. Kahl, Why the rotation count algorithm works, http://papers.ssrn.com/sol3/papers.cfm?abstract_id=921335  H. Albrecher, P. Mayer, W.Schoutens and J. Tistaert, The Little Heston Trap, http://www.schoutens.be/HestonTrap.pdf  J. Gatheral, The Volatility Surface: A Practitioner's Guide, Wiley Finance  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature and comparison with Black pricing.
Constructor using Laguerre integration and Gatheral's version of complex log.
  </summary> *)
[<AutoSerializable(true)>]
type AnalyticHestonEngineModel1
    ( model                                        : ICell<HestonModel>
    , integrationOrder                             : ICell<int>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticHestonEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _integrationOrder                          = integrationOrder
(*
    Functions
*)
    let mutable
        _AnalyticHestonEngine                      = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticHestonEngine (model.Value, integrationOrder.Value))))
    let _numberOfEvaluations                       = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.setModel(model.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.registerWith(handler.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.reset()
                                                                     _AnalyticHestonEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.unregisterWith(handler.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.update()
                                                                     _AnalyticHestonEngine.Value)
    do this.Bind(_AnalyticHestonEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticHestonEngineModel1(null,null,null)
    member internal this.Inject v = _AnalyticHestonEngine <- v
    static member Cast (p : ICell<AnalyticHestonEngine>) = 
        if p :? AnalyticHestonEngineModel1 then 
            p :?> AnalyticHestonEngineModel1
        else
            let o = new AnalyticHestonEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.integrationOrder                   = _integrationOrder 
    member this.NumberOfEvaluations                = _numberOfEvaluations
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  A. Sepp, Pricing European-Style Options under Jump Diffusion Processes with Stochastic Volatility: Applications of Fourier Transform (<http://math.ut.ee/~spartak/papers/stochjumpvols.pdf>)  R. Lord and C. Kahl, Why the rotation count algorithm works, http://papers.ssrn.com/sol3/papers.cfm?abstract_id=921335  H. Albrecher, P. Mayer, W.Schoutens and J. Tistaert, The Little Heston Trap, http://www.schoutens.be/HestonTrap.pdf  J. Gatheral, The Volatility Surface: A Practitioner's Guide, Wiley Finance  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature and comparison with Black pricing.
Constructor giving full control over the Fourier integration algorithm
  </summary> *)
[<AutoSerializable(true)>]
type AnalyticHestonEngineModel2
    ( model                                        : ICell<HestonModel>
    , cpxLog                                       : ICell<AnalyticHestonEngine.ComplexLogFormula>
    , integration                                  : ICell<AnalyticHestonEngine.Integration>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticHestonEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _model                                     = model
    let _cpxLog                                    = cpxLog
    let _integration                               = integration
(*
    Functions
*)
    let mutable
        _AnalyticHestonEngine                      = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticHestonEngine (model.Value, cpxLog.Value, integration.Value))))
    let _numberOfEvaluations                       = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.setModel(model.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.registerWith(handler.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.reset()
                                                                     _AnalyticHestonEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.unregisterWith(handler.Value)
                                                                     _AnalyticHestonEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHestonEngine).Value.update()
                                                                     _AnalyticHestonEngine.Value)
    do this.Bind(_AnalyticHestonEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticHestonEngineModel2(null,null,null,null)
    member internal this.Inject v = _AnalyticHestonEngine <- v
    static member Cast (p : ICell<AnalyticHestonEngine>) = 
        if p :? AnalyticHestonEngineModel2 then 
            p :?> AnalyticHestonEngineModel2
        else
            let o = new AnalyticHestonEngineModel2 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.cpxLog                             = _cpxLog 
    member this.integration                        = _integration 
    member this.NumberOfEvaluations                = _numberOfEvaluations
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
