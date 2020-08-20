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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  J. Gatheral, The Volatility Surface: A Practitioner's Guide, Wiley Finance  A. Elices, Models with time-dependent parameters using transform methods: application to Heston’s model, http://arxiv.org/pdf/0708.2020  vanillaengines
Simple to use constructor: Using adaptive Gauss-Lobatto integration and Gatheral's version of complex log. Be aware: using a too large number for maxEvaluations might result in a stack overflow as the Lobatto integration is a recursive algorithm.
  </summary> *)
[<AutoSerializable(true)>]
type AnalyticPTDHestonEngineModel
    ( model                                        : ICell<PiecewiseTimeDependentHestonModel>
    , relTolerance                                 : ICell<double>
    , maxEvaluations                               : ICell<int>
    ) as this =

    inherit Model<AnalyticPTDHestonEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _relTolerance                              = relTolerance
    let _maxEvaluations                            = maxEvaluations
(*
    Functions
*)
    let _AnalyticPTDHestonEngine                   = cell (fun () -> new AnalyticPTDHestonEngine (model.Value, relTolerance.Value, maxEvaluations.Value))
    let _calculate                                 = cell (fun () -> _AnalyticPTDHestonEngine.Value.calculate()
                                                                     _AnalyticPTDHestonEngine.Value)
    let _setModel                                  (model : ICell<Handle<PiecewiseTimeDependentHestonModel>>)   
                                                   = cell (fun () -> _AnalyticPTDHestonEngine.Value.setModel(model.Value)
                                                                     _AnalyticPTDHestonEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticPTDHestonEngine.Value.registerWith(handler.Value)
                                                                     _AnalyticPTDHestonEngine.Value)
    let _reset                                     = cell (fun () -> _AnalyticPTDHestonEngine.Value.reset()
                                                                     _AnalyticPTDHestonEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticPTDHestonEngine.Value.unregisterWith(handler.Value)
                                                                     _AnalyticPTDHestonEngine.Value)
    let _update                                    = cell (fun () -> _AnalyticPTDHestonEngine.Value.update()
                                                                     _AnalyticPTDHestonEngine.Value)
    do this.Bind(_AnalyticPTDHestonEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.relTolerance                       = _relTolerance 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.Calculate                          = _calculate
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  J. Gatheral, The Volatility Surface: A Practitioner's Guide, Wiley Finance  A. Elices, Models with time-dependent parameters using transform methods: application to Heston’s model, http://arxiv.org/pdf/0708.2020  vanillaengines
Constructor using Laguerre integration and Gatheral's version of complex log.
  </summary> *)
[<AutoSerializable(true)>]
type AnalyticPTDHestonEngineModel1
    ( model                                        : ICell<PiecewiseTimeDependentHestonModel>
    , integrationOrder                             : ICell<int>
    ) as this =

    inherit Model<AnalyticPTDHestonEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _integrationOrder                          = integrationOrder
(*
    Functions
*)
    let _AnalyticPTDHestonEngine                   = cell (fun () -> new AnalyticPTDHestonEngine (model.Value, integrationOrder.Value))
    let _calculate                                 = cell (fun () -> _AnalyticPTDHestonEngine.Value.calculate()
                                                                     _AnalyticPTDHestonEngine.Value)
    let _setModel                                  (model : ICell<Handle<PiecewiseTimeDependentHestonModel>>)   
                                                   = cell (fun () -> _AnalyticPTDHestonEngine.Value.setModel(model.Value)
                                                                     _AnalyticPTDHestonEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticPTDHestonEngine.Value.registerWith(handler.Value)
                                                                     _AnalyticPTDHestonEngine.Value)
    let _reset                                     = cell (fun () -> _AnalyticPTDHestonEngine.Value.reset()
                                                                     _AnalyticPTDHestonEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticPTDHestonEngine.Value.unregisterWith(handler.Value)
                                                                     _AnalyticPTDHestonEngine.Value)
    let _update                                    = cell (fun () -> _AnalyticPTDHestonEngine.Value.update()
                                                                     _AnalyticPTDHestonEngine.Value)
    do this.Bind(_AnalyticPTDHestonEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.integrationOrder                   = _integrationOrder 
    member this.Calculate                          = _calculate
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
