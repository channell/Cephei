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

  </summary> *)
[<AutoSerializable(true)>]
type JamshidianSwaptionEngineModel
    ( model                                        : ICell<OneFactorAffineModel>
    ) as this =

    inherit Model<JamshidianSwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
(*
    Functions
*)
    let _JamshidianSwaptionEngine                  = cell (fun () -> new JamshidianSwaptionEngine (model.Value))
    let _setModel                                  (model : ICell<Handle<OneFactorAffineModel>>)   
                                                   = triv (fun () -> _JamshidianSwaptionEngine.Value.setModel(model.Value)
                                                                     _JamshidianSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _JamshidianSwaptionEngine.Value.registerWith(handler.Value)
                                                                     _JamshidianSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> _JamshidianSwaptionEngine.Value.reset()
                                                                     _JamshidianSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _JamshidianSwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _JamshidianSwaptionEngine.Value)
    let _update                                    = triv (fun () -> _JamshidianSwaptionEngine.Value.update()
                                                                     _JamshidianSwaptionEngine.Value)
    do this.Bind(_JamshidianSwaptionEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  swaptionengines  The engine assumes that the exercise date equals the start date of the passed swap.
! \note the term structure is only needed when the short-rate model cannot provide one itself.
  </summary> *)
[<AutoSerializable(true)>]
type JamshidianSwaptionEngineModel1
    ( model                                        : ICell<OneFactorAffineModel>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<JamshidianSwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _termStructure                             = termStructure
(*
    Functions
*)
    let _JamshidianSwaptionEngine                  = cell (fun () -> new JamshidianSwaptionEngine (model.Value, termStructure.Value))
    let _setModel                                  (model : ICell<Handle<OneFactorAffineModel>>)   
                                                   = triv (fun () -> _JamshidianSwaptionEngine.Value.setModel(model.Value)
                                                                     _JamshidianSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _JamshidianSwaptionEngine.Value.registerWith(handler.Value)
                                                                     _JamshidianSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> _JamshidianSwaptionEngine.Value.reset()
                                                                     _JamshidianSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _JamshidianSwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _JamshidianSwaptionEngine.Value)
    let _update                                    = triv (fun () -> _JamshidianSwaptionEngine.Value.update()
                                                                     _JamshidianSwaptionEngine.Value)
    do this.Bind(_JamshidianSwaptionEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.termStructure                      = _termStructure 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
