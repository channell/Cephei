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
  purely virtual base class for market observables
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type QuoteModel
    () as this =
    inherit Model<Quote> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Quote                                     = cell (fun () -> new Quote ())
    let _isValid                                   = cell (fun () -> _Quote.Value.isValid())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _Quote.Value.registerWith(handler.Value)
                                                                     _Quote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _Quote.Value.unregisterWith(handler.Value)
                                                                     _Quote.Value)
    let _value                                     = cell (fun () -> _Quote.Value.value())
    do this.Bind(_Quote)

(* 
    Externally visible/bindable properties
*)
    member this.IsValid                            = _isValid
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Value                              = _value
