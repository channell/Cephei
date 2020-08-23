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
  swaptionengines

  </summary> *)
[<AutoSerializable(true)>]
type LfmSwaptionEngineModel
    ( model                                        : ICell<LiborForwardModel>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<LfmSwaptionEngine> ()
(*
    Parameters
*)
    let _model                                     = model
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let _LfmSwaptionEngine                         = cell (fun () -> new LfmSwaptionEngine (model.Value, discountCurve.Value))
    let _setModel                                  (model : ICell<Handle<LiborForwardModel>>)   
                                                   = triv (fun () -> _LfmSwaptionEngine.Value.setModel(model.Value)
                                                                     _LfmSwaptionEngine.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LfmSwaptionEngine.Value.registerWith(handler.Value)
                                                                     _LfmSwaptionEngine.Value)
    let _reset                                     = triv (fun () -> _LfmSwaptionEngine.Value.reset()
                                                                     _LfmSwaptionEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _LfmSwaptionEngine.Value.unregisterWith(handler.Value)
                                                                     _LfmSwaptionEngine.Value)
    let _update                                    = triv (fun () -> _LfmSwaptionEngine.Value.update()
                                                                     _LfmSwaptionEngine.Value)
    do this.Bind(_LfmSwaptionEngine)

(* 
    Externally visible/bindable properties
*)
    member this.model                              = _model 
    member this.discountCurve                      = _discountCurve 
    member this.SetModel                           model   
                                                   = _setModel model 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
