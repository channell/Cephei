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

Constructors \note the term structure is only needed when the short-rate model cannot provide one itself.
  </summary> *)
[<AutoSerializable(true)>]
type TreeVanillaSwapEngineModel
    ( model                                        : ICell<ShortRateModel>
    , timeSteps                                    : ICell<int>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<TreeVanillaSwapEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _timeSteps                                 = timeSteps
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _TreeVanillaSwapEngine                     = cell (fun () -> new TreeVanillaSwapEngine (model.Value, timeSteps.Value, termStructure.Value))
    let _update                                    = triv (fun () -> _TreeVanillaSwapEngine.Value.update()
                                                                     _TreeVanillaSwapEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> _TreeVanillaSwapEngine.Value.setModel(model.Value)
                                                                     _TreeVanillaSwapEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeVanillaSwapEngine.Value.registerWith(handler.Value)
                                                                     _TreeVanillaSwapEngine.Value)
    let _reset                                     = triv (fun () -> _TreeVanillaSwapEngine.Value.reset()
                                                                     _TreeVanillaSwapEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeVanillaSwapEngine.Value.unregisterWith(handler.Value)
                                                                     _TreeVanillaSwapEngine.Value)
    do this.Bind(_TreeVanillaSwapEngine)
(* 
    casting 
*)
    internal new () = TreeVanillaSwapEngineModel(null,null,null)
    member internal this.Inject v = _TreeVanillaSwapEngine.Value <- v
    static member Cast (p : ICell<TreeVanillaSwapEngine>) = 
        if p :? TreeVanillaSwapEngineModel then 
            p :?> TreeVanillaSwapEngineModel
        else
            let o = new TreeVanillaSwapEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.timeSteps                          = _timeSteps 
    member this.termStructure                      = _termStructure 
    member this.Update                             = _update
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type TreeVanillaSwapEngineModel1
    ( model                                        : ICell<ShortRateModel>
    , timeGrid                                     : ICell<TimeGrid>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<TreeVanillaSwapEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _timeGrid                                  = timeGrid
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _TreeVanillaSwapEngine                     = cell (fun () -> new TreeVanillaSwapEngine (model.Value, timeGrid.Value, termStructure.Value))
    let _update                                    = triv (fun () -> _TreeVanillaSwapEngine.Value.update()
                                                                     _TreeVanillaSwapEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> _TreeVanillaSwapEngine.Value.setModel(model.Value)
                                                                     _TreeVanillaSwapEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeVanillaSwapEngine.Value.registerWith(handler.Value)
                                                                     _TreeVanillaSwapEngine.Value)
    let _reset                                     = triv (fun () -> _TreeVanillaSwapEngine.Value.reset()
                                                                     _TreeVanillaSwapEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeVanillaSwapEngine.Value.unregisterWith(handler.Value)
                                                                     _TreeVanillaSwapEngine.Value)
    do this.Bind(_TreeVanillaSwapEngine)
(* 
    casting 
*)
    internal new () = TreeVanillaSwapEngineModel1(null,null,null)
    member internal this.Inject v = _TreeVanillaSwapEngine.Value <- v
    static member Cast (p : ICell<TreeVanillaSwapEngine>) = 
        if p :? TreeVanillaSwapEngineModel1 then 
            p :?> TreeVanillaSwapEngineModel1
        else
            let o = new TreeVanillaSwapEngineModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.timeGrid                           = _timeGrid 
    member this.termStructure                      = _termStructure 
    member this.Update                             = _update
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
