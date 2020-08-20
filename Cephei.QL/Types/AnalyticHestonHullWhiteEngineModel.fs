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
    ) as this =

    inherit Model<AnalyticHestonHullWhiteEngine> ()
(*
    Parameters
*)
    let _hestonModel                               = hestonModel
    let _hullWhiteModel                            = hullWhiteModel
    let _relTolerance                              = relTolerance
    let _maxEvaluations                            = maxEvaluations
(*
    Functions
*)
    let _AnalyticHestonHullWhiteEngine             = cell (fun () -> new AnalyticHestonHullWhiteEngine (hestonModel.Value, hullWhiteModel.Value, relTolerance.Value, maxEvaluations.Value))
    let _calculate                                 = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.calculate()
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _update                                    = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.update()
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _numberOfEvaluations                       = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.setModel(model.Value)
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.registerWith(handler.Value)
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _reset                                     = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.reset()
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.unregisterWith(handler.Value)
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    do this.Bind(_AnalyticHestonHullWhiteEngine)

(* 
    Externally visible/bindable properties
*)
    member this.hestonModel                        = _hestonModel 
    member this.hullWhiteModel                     = _hullWhiteModel 
    member this.relTolerance                       = _relTolerance 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.Calculate                          = _calculate
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
    ) as this =

    inherit Model<AnalyticHestonHullWhiteEngine> ()
(*
    Parameters
*)
    let _hestonModel                               = hestonModel
    let _hullWhiteModel                            = hullWhiteModel
    let _integrationOrder                          = integrationOrder
(*
    Functions
*)
    let _AnalyticHestonHullWhiteEngine             = cell (fun () -> new AnalyticHestonHullWhiteEngine (hestonModel.Value, hullWhiteModel.Value, integrationOrder.Value))
    let _calculate                                 = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.calculate()
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _update                                    = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.update()
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _numberOfEvaluations                       = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.setModel(model.Value)
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.registerWith(handler.Value)
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _reset                                     = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.reset()
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticHestonHullWhiteEngine.Value.unregisterWith(handler.Value)
                                                                     _AnalyticHestonHullWhiteEngine.Value)
    do this.Bind(_AnalyticHestonHullWhiteEngine)

(* 
    Externally visible/bindable properties
*)
    member this.hestonModel                        = _hestonModel 
    member this.hullWhiteModel                     = _hullWhiteModel 
    member this.integrationOrder                   = _integrationOrder 
    member this.Calculate                          = _calculate
    member this.Update                             = _update
    member this.NumberOfEvaluations                = _numberOfEvaluations
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
