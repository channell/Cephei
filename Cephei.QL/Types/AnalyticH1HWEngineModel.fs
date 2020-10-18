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
  References:  Lech A. Grzelak, Cornelis W. Oosterlee, On The Heston Model with Stochastic, http://papers.ssrn.com/sol3/papers.cfm?abstract_id=1382902  Lech A. Grzelak, Equity and Foreign Exchange Hybrid Models for Pricing Long-Maturity Financial Derivatives, http://repository.tudelft.nl/assets/uuid:a8e1a007-bd89-481a-aee3-0e22f15ade6b/PhDThesis_main.pdf  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature, testing against QuantLib's analytic Heston, the Black-Scholes-Merton Hull-White engine and the finite difference Heston-Hull-White engine

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticH1HWEngineModel
    ( model                                        : ICell<HestonModel>
    , hullWhiteModel                               : ICell<HullWhite>
    , rhoSr                                        : ICell<double>
    , integrationOrder                             : ICell<int>
    ) as this =

    inherit Model<AnalyticH1HWEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _hullWhiteModel                            = hullWhiteModel
    let _rhoSr                                     = rhoSr
    let _integrationOrder                          = integrationOrder
(*
    Functions
*)
    let mutable
        _AnalyticH1HWEngine                        = cell (fun () -> new AnalyticH1HWEngine (model.Value, hullWhiteModel.Value, rhoSr.Value, integrationOrder.Value))
    let _update                                    = triv (fun () -> _AnalyticH1HWEngine.Value.update()
                                                                     _AnalyticH1HWEngine.Value)
    let _numberOfEvaluations                       = triv (fun () -> _AnalyticH1HWEngine.Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv (fun () -> _AnalyticH1HWEngine.Value.setModel(model.Value)
                                                                     _AnalyticH1HWEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AnalyticH1HWEngine.Value.registerWith(handler.Value)
                                                                     _AnalyticH1HWEngine.Value)
    let _reset                                     = triv (fun () -> _AnalyticH1HWEngine.Value.reset()
                                                                     _AnalyticH1HWEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AnalyticH1HWEngine.Value.unregisterWith(handler.Value)
                                                                     _AnalyticH1HWEngine.Value)
    do this.Bind(_AnalyticH1HWEngine)
(* 
    casting 
*)
    internal new () = new AnalyticH1HWEngineModel(null,null,null,null)
    member internal this.Inject v = _AnalyticH1HWEngine <- v
    static member Cast (p : ICell<AnalyticH1HWEngine>) = 
        if p :? AnalyticH1HWEngineModel then 
            p :?> AnalyticH1HWEngineModel
        else
            let o = new AnalyticH1HWEngineModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.hullWhiteModel                     = _hullWhiteModel 
    member this.rhoSr                              = _rhoSr 
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
(* <summary>
  References:  Lech A. Grzelak, Cornelis W. Oosterlee, On The Heston Model with Stochastic, http://papers.ssrn.com/sol3/papers.cfm?abstract_id=1382902  Lech A. Grzelak, Equity and Foreign Exchange Hybrid Models for Pricing Long-Maturity Financial Derivatives, http://repository.tudelft.nl/assets/uuid:a8e1a007-bd89-481a-aee3-0e22f15ade6b/PhDThesis_main.pdf  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature, testing against QuantLib's analytic Heston, the Black-Scholes-Merton Hull-White engine and the finite difference Heston-Hull-White engine

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticH1HWEngineModel1
    ( model                                        : ICell<HestonModel>
    , hullWhiteModel                               : ICell<HullWhite>
    , rhoSr                                        : ICell<double>
    , relTolerance                                 : ICell<double>
    , maxEvaluations                               : ICell<int>
    ) as this =

    inherit Model<AnalyticH1HWEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _hullWhiteModel                            = hullWhiteModel
    let _rhoSr                                     = rhoSr
    let _relTolerance                              = relTolerance
    let _maxEvaluations                            = maxEvaluations
(*
    Functions
*)
    let mutable
        _AnalyticH1HWEngine                        = cell (fun () -> new AnalyticH1HWEngine (model.Value, hullWhiteModel.Value, rhoSr.Value, relTolerance.Value, maxEvaluations.Value))
    let _update                                    = triv (fun () -> _AnalyticH1HWEngine.Value.update()
                                                                     _AnalyticH1HWEngine.Value)
    let _numberOfEvaluations                       = triv (fun () -> _AnalyticH1HWEngine.Value.numberOfEvaluations())
    let _setModel                                  (model : ICell<Handle<HestonModel>>)   
                                                   = triv (fun () -> _AnalyticH1HWEngine.Value.setModel(model.Value)
                                                                     _AnalyticH1HWEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AnalyticH1HWEngine.Value.registerWith(handler.Value)
                                                                     _AnalyticH1HWEngine.Value)
    let _reset                                     = triv (fun () -> _AnalyticH1HWEngine.Value.reset()
                                                                     _AnalyticH1HWEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AnalyticH1HWEngine.Value.unregisterWith(handler.Value)
                                                                     _AnalyticH1HWEngine.Value)
    do this.Bind(_AnalyticH1HWEngine)
(* 
    casting 
*)
    internal new () = new AnalyticH1HWEngineModel1(null,null,null,null,null)
    member internal this.Inject v = _AnalyticH1HWEngine <- v
    static member Cast (p : ICell<AnalyticH1HWEngine>) = 
        if p :? AnalyticH1HWEngineModel1 then 
            p :?> AnalyticH1HWEngineModel1
        else
            let o = new AnalyticH1HWEngineModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.hullWhiteModel                     = _hullWhiteModel 
    member this.rhoSr                              = _rhoSr 
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
