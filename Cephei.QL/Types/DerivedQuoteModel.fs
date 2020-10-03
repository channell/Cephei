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
type DerivedQuoteModel
    ( element                                      : ICell<Handle<Quote>>
    , f                                            : ICell<Func<double,double>>
    ) as this =

    inherit Model<DerivedQuote> ()
(*
    Parameters
*)
    let _element                                   = element
    let _f                                         = f
(*
    Functions
*)
    let _DerivedQuote                              = cell (fun () -> new DerivedQuote (element.Value, f.Value))
    let _isValid                                   = triv (fun () -> _DerivedQuote.Value.isValid())
    let _update                                    = triv (fun () -> _DerivedQuote.Value.update()
                                                                     _DerivedQuote.Value)
    let _value                                     = triv (fun () -> _DerivedQuote.Value.value())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DerivedQuote.Value.registerWith(handler.Value)
                                                                     _DerivedQuote.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DerivedQuote.Value.unregisterWith(handler.Value)
                                                                     _DerivedQuote.Value)
    do this.Bind(_DerivedQuote)
(* 
    casting 
*)
    internal new () = DerivedQuoteModel(null,null)
    member internal this.Inject v = _DerivedQuote.Value <- v
    static member Cast (p : ICell<DerivedQuote>) = 
        if p :? DerivedQuoteModel then 
            p :?> DerivedQuoteModel
        else
            let o = new DerivedQuoteModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.element                            = _element 
    member this.f                                  = _f 
    member this.IsValid                            = _isValid
    member this.Update                             = _update
    member this.Value                              = _value
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
