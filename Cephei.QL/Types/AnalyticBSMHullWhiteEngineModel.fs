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
  References:  Brigo, Mercurio, Interest Rate Models  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticBSMHullWhiteEngineModel
    ( equityShortRateCorrelation                   : ICell<double>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    , model                                        : ICell<HullWhite>
    ) as this =

    inherit Model<AnalyticBSMHullWhiteEngine> ()
(*
    Parameters
*)
    let _equityShortRateCorrelation                = equityShortRateCorrelation
    let _Process                                   = Process
    let _model                                     = model
(*
    Functions
*)
    let _AnalyticBSMHullWhiteEngine                = cell (fun () -> new AnalyticBSMHullWhiteEngine (equityShortRateCorrelation.Value, Process.Value, model.Value))
    let _calculate                                 = cell (fun () -> _AnalyticBSMHullWhiteEngine.Value.calculate()
                                                                     _AnalyticBSMHullWhiteEngine.Value)
    let _setModel                                  (model : ICell<Handle<HullWhite>>)   
                                                   = cell (fun () -> _AnalyticBSMHullWhiteEngine.Value.setModel(model.Value)
                                                                     _AnalyticBSMHullWhiteEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticBSMHullWhiteEngine.Value.registerWith(handler.Value)
                                                                     _AnalyticBSMHullWhiteEngine.Value)
    let _reset                                     = cell (fun () -> _AnalyticBSMHullWhiteEngine.Value.reset()
                                                                     _AnalyticBSMHullWhiteEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticBSMHullWhiteEngine.Value.unregisterWith(handler.Value)
                                                                     _AnalyticBSMHullWhiteEngine.Value)
    let _update                                    = cell (fun () -> _AnalyticBSMHullWhiteEngine.Value.update()
                                                                     _AnalyticBSMHullWhiteEngine.Value)
    do this.Bind(_AnalyticBSMHullWhiteEngine)

(* 
    Externally visible/bindable properties
*)
    member this.equityShortRateCorrelation         = _equityShortRateCorrelation 
    member this.Process                            = _Process 
    member this.model                              = _model 
    member this.Calculate                          = _calculate
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
