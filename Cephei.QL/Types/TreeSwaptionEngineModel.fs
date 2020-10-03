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
  swaptionengines  This engine is not guaranteed to work if the underlying swap has a start date in the past, i.e., before today's date. When using this engine, prune the initial part of the swap so that it starts at t 0  calculations are checked against cached results

  </summary> *)
[<AutoSerializable(true)>]
type TreeSwaptionEngineModel
    ( model                                        : ICell<ShortRateModel>
    , timeGrid                                     : ICell<TimeGrid>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<TreeSwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _timeGrid                                  = timeGrid
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _TreeSwaptionEngine                        = cell (fun () -> new TreeSwaptionEngine (model.Value, timeGrid.Value, termStructure.Value))
    let _update                                    = triv (fun () -> _TreeSwaptionEngine.Value.update()
                                                                     _TreeSwaptionEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.setModel(model.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.registerWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> _TreeSwaptionEngine.Value.reset()
                                                                     _TreeSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    do this.Bind(_TreeSwaptionEngine)
(* 
    casting 
*)
    internal new () = TreeSwaptionEngineModel(null,null,null)
    member internal this.Inject v = _TreeSwaptionEngine.Value <- v
    static member Cast (p : ICell<TreeSwaptionEngine>) = 
        if p :? TreeSwaptionEngineModel then 
            p :?> TreeSwaptionEngineModel
        else
            let o = new TreeSwaptionEngineModel ()
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
(* <summary>
  swaptionengines  This engine is not guaranteed to work if the underlying swap has a start date in the past, i.e., before today's date. When using this engine, prune the initial part of the swap so that it starts at t 0  calculations are checked against cached results

  </summary> *)
[<AutoSerializable(true)>]
type TreeSwaptionEngineModel1
    ( model                                        : ICell<ShortRateModel>
    , timeGrid                                     : ICell<TimeGrid>
    ) as this =

    inherit Model<TreeSwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _timeGrid                                  = timeGrid
(*
    Functions
*)
    let _TreeSwaptionEngine                        = cell (fun () -> new TreeSwaptionEngine (model.Value, timeGrid.Value))
    let _update                                    = triv (fun () -> _TreeSwaptionEngine.Value.update()
                                                                     _TreeSwaptionEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.setModel(model.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.registerWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> _TreeSwaptionEngine.Value.reset()
                                                                     _TreeSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    do this.Bind(_TreeSwaptionEngine)
(* 
    casting 
*)
    internal new () = TreeSwaptionEngineModel1(null,null)
    member internal this.Inject v = _TreeSwaptionEngine.Value <- v
    static member Cast (p : ICell<TreeSwaptionEngine>) = 
        if p :? TreeSwaptionEngineModel1 then 
            p :?> TreeSwaptionEngineModel1
        else
            let o = new TreeSwaptionEngineModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.timeGrid                           = _timeGrid 
    member this.Update                             = _update
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  swaptionengines  This engine is not guaranteed to work if the underlying swap has a start date in the past, i.e., before today's date. When using this engine, prune the initial part of the swap so that it starts at t 0  calculations are checked against cached results

  </summary> *)
[<AutoSerializable(true)>]
type TreeSwaptionEngineModel2
    ( model                                        : ICell<ShortRateModel>
    , timeSteps                                    : ICell<int>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<TreeSwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _timeSteps                                 = timeSteps
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _TreeSwaptionEngine                        = cell (fun () -> new TreeSwaptionEngine (model.Value, timeSteps.Value, termStructure.Value))
    let _update                                    = triv (fun () -> _TreeSwaptionEngine.Value.update()
                                                                     _TreeSwaptionEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.setModel(model.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.registerWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> _TreeSwaptionEngine.Value.reset()
                                                                     _TreeSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    do this.Bind(_TreeSwaptionEngine)
(* 
    casting 
*)
    internal new () = TreeSwaptionEngineModel2(null,null,null)
    member internal this.Inject v = _TreeSwaptionEngine.Value <- v
    static member Cast (p : ICell<TreeSwaptionEngine>) = 
        if p :? TreeSwaptionEngineModel2 then 
            p :?> TreeSwaptionEngineModel2
        else
            let o = new TreeSwaptionEngineModel2 ()
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
  swaptionengines  This engine is not guaranteed to work if the underlying swap has a start date in the past, i.e., before today's date. When using this engine, prune the initial part of the swap so that it starts at t 0  calculations are checked against cached results
Constructors \note the term structure is only needed when the short-rate model cannot provide one itself.
  </summary> *)
[<AutoSerializable(true)>]
type TreeSwaptionEngineModel3
    ( model                                        : ICell<ShortRateModel>
    , timeSteps                                    : ICell<int>
    ) as this =

    inherit Model<TreeSwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _timeSteps                                 = timeSteps
(*
    Functions
*)
    let _TreeSwaptionEngine                        = cell (fun () -> new TreeSwaptionEngine (model.Value, timeSteps.Value))
    let _update                                    = triv (fun () -> _TreeSwaptionEngine.Value.update()
                                                                     _TreeSwaptionEngine.Value)
    let _setModel                                  (model : ICell<Handle<ShortRateModel>>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.setModel(model.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.registerWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> _TreeSwaptionEngine.Value.reset()
                                                                     _TreeSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TreeSwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _TreeSwaptionEngine.Value)
    do this.Bind(_TreeSwaptionEngine)
(* 
    casting 
*)
    internal new () = TreeSwaptionEngineModel3(null,null)
    member internal this.Inject v = _TreeSwaptionEngine.Value <- v
    static member Cast (p : ICell<TreeSwaptionEngine>) = 
        if p :? TreeSwaptionEngineModel3 then 
            p :?> TreeSwaptionEngineModel3
        else
            let o = new TreeSwaptionEngineModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.timeSteps                          = _timeSteps 
    member this.Update                             = _update
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
