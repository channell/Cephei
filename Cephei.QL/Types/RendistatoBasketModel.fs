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


  </summary> *)
[<AutoSerializable(true)>]
type RendistatoBasketModel
    ( btps                                         : ICell<Generic.List<BTP>>
    , outstandings                                 : ICell<Generic.List<double>>
    , cleanPriceQuotes                             : ICell<Generic.List<Handle<Quote>>>
    ) as this =

    inherit Model<RendistatoBasket> ()
(*
    Parameters
*)
    let _btps                                      = btps
    let _outstandings                              = outstandings
    let _cleanPriceQuotes                          = cleanPriceQuotes
(*
    Functions
*)
    let _RendistatoBasket                          = cell (fun () -> new RendistatoBasket (btps.Value, outstandings.Value, cleanPriceQuotes.Value))
    let _btps                                      = triv (fun () -> _RendistatoBasket.Value.btps())
    let _cleanPriceQuotes                          = cell (fun () -> _RendistatoBasket.Value.cleanPriceQuotes())
    let _outstanding                               = triv (fun () -> _RendistatoBasket.Value.outstanding())
    let _outstandings                              = triv (fun () -> _RendistatoBasket.Value.outstandings())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RendistatoBasket.Value.registerWith(handler.Value)
                                                                     _RendistatoBasket.Value)
    let _size                                      = triv (fun () -> _RendistatoBasket.Value.size())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RendistatoBasket.Value.unregisterWith(handler.Value)
                                                                     _RendistatoBasket.Value)
    let _update                                    = triv (fun () -> _RendistatoBasket.Value.update()
                                                                     _RendistatoBasket.Value)
    let _weights                                   = triv (fun () -> _RendistatoBasket.Value.weights())
    do this.Bind(_RendistatoBasket)

(* 
    Externally visible/bindable properties
*)
    member this.btps                               = _btps 
    member this.outstandings                       = _outstandings 
    member this.cleanPriceQuotes                   = _cleanPriceQuotes 
    member this.Btps                               = _btps
    member this.CleanPriceQuotes                   = _cleanPriceQuotes
    member this.Outstanding                        = _outstanding
    member this.Outstandings                       = _outstandings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Size                               = _size
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.Weights                            = _weights
