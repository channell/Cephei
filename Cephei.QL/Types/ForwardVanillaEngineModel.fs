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
  forwardengines  - the correctness of the returned value is tested by reproducing results available in literature. - the correctness of the returned greeks is tested by reproducing numerical derivatives.

  </summary> *)
[<AutoSerializable(true)>]
type ForwardVanillaEngineModel
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , getEngine                                    : ICell<ForwardVanillaEngine.GetOriginalEngine>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>) as this =
    //) as this =

    inherit Model<ForwardVanillaEngine> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _getEngine                                 = getEngine
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _ForwardVanillaEngine                      = cell (fun () -> new ForwardVanillaEngine (Process.Value, getEngine.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _ForwardVanillaEngine.Value.registerWith(handler.Value)
                                                                     _ForwardVanillaEngine.Value)
    let _reset                                     = triv (fun () -> _ForwardVanillaEngine.Value.reset()
                                                                     _ForwardVanillaEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _ForwardVanillaEngine.Value.unregisterWith(handler.Value)
                                                                     _ForwardVanillaEngine.Value)
    let _update                                    = triv (fun () -> _ForwardVanillaEngine.Value.update()
                                                                     _ForwardVanillaEngine.Value)
    do this.Bind(_ForwardVanillaEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.getEngine                          = _getEngine 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
