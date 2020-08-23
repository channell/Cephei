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
type CompositeQuoteModel
    ( element1                                     : ICell<Handle<Quote>>
    , element2                                     : ICell<Handle<Quote>>
    , f                                            : ICell<Func<double,double,double>>
    ) as this =

    inherit Model<CompositeQuote> ()
(*
    Parameters
*)
    let _element1                                  = element1
    let _element2                                  = element2
    let _f                                         = f
(*
    Functions
*)
    let _CompositeQuote                            = cell (fun () -> new CompositeQuote (element1.Value, element2.Value, f.Value))
    let _isValid                                   = triv (fun () -> _CompositeQuote.Value.isValid())
    let _update                                    = triv (fun () -> _CompositeQuote.Value.update()
                                                                     _CompositeQuote.Value)
    let _value                                     = triv (fun () -> _CompositeQuote.Value.value())
    let _value1                                    = triv (fun () -> _CompositeQuote.Value.value1())
    let _value2                                    = triv (fun () -> _CompositeQuote.Value.value2())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CompositeQuote.Value.registerWith(handler.Value)
                                                                     _CompositeQuote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CompositeQuote.Value.unregisterWith(handler.Value)
                                                                     _CompositeQuote.Value)
    do this.Bind(_CompositeQuote)

(* 
    Externally visible/bindable properties
*)
    member this.element1                           = _element1 
    member this.element2                           = _element2 
    member this.f                                  = _f 
    member this.IsValid                            = _isValid
    member this.Update                             = _update
    member this.Value                              = _value
    member this.Value1                             = _value1
    member this.Value2                             = _value2
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
