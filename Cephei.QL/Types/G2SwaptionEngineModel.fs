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
  swaptionengines  The engine assumes that the exercise date equals the start date of the passed swap.
range is the number of standard deviations to use in the exponential term of the integral for the european swaption. intervals is the number of intervals to use in the integration.
  </summary> *)
[<AutoSerializable(true)>]
type G2SwaptionEngineModel
    ( model                                        : ICell<G2>
    , range                                        : ICell<double>
    , intervals                                    : ICell<int>
    ) as this =

    inherit Model<G2SwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _range                                     = range
    let _intervals                                 = intervals
(*
    Functions
*)
    let _G2SwaptionEngine                          = cell (fun () -> new G2SwaptionEngine (model.Value, range.Value, intervals.Value))
    let _calculate                                 = cell (fun () -> _G2SwaptionEngine.Value.calculate()
                                                                     _G2SwaptionEngine.Value)
    let _setModel                                  (model : ICell<Handle<G2>>)   
                                                   = cell (fun () -> _G2SwaptionEngine.Value.setModel(model.Value)
                                                                     _G2SwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _G2SwaptionEngine.Value.registerWith(handler.Value)
                                                                     _G2SwaptionEngine.Value)
    let _reset                                     = cell (fun () -> _G2SwaptionEngine.Value.reset()
                                                                     _G2SwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _G2SwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _G2SwaptionEngine.Value)
    let _update                                    = cell (fun () -> _G2SwaptionEngine.Value.update()
                                                                     _G2SwaptionEngine.Value)
    do this.Bind(_G2SwaptionEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.range                              = _range 
    member this.intervals                          = _intervals 
    member this.Calculate                          = _calculate
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
