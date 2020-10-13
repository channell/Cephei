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
  %instrument callability

  </summary> *)
[<AutoSerializable(true)>]
type CallabilityModel
    ( price                                        : ICell<Callability.Price>
    , Type                                         : ICell<Callability.Type>
    , date                                         : ICell<Date>
    ) as this =

    inherit Model<Callability> ()
(*
    Parameters
*)
    let _price                                     = price
    let _Type                                      = Type
    let _date                                      = date
(*
    Functions
*)
    let _Callability                               = cell (fun () -> new Callability (price.Value, Type.Value, date.Value))
    let _date                                      = triv (fun () -> _Callability.Value.date())
    let _price                                     = triv (fun () -> _Callability.Value.price())
    let _type                                      = triv (fun () -> _Callability.Value.TYPE())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _Callability.Value.accept(v.Value)
                                                                     _Callability.Value)
    let _hasOccurred                               (d : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _Callability.Value.hasOccurred(d.Value, includeRefDate.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Callability.Value.registerWith(handler.Value)
                                                                     _Callability.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Callability.Value.unregisterWith(handler.Value)
                                                                     _Callability.Value)
    do this.Bind(_Callability)
(* 
    casting 
*)
    internal new () = new CallabilityModel(null,null,null)
    member internal this.Inject v = _Callability.Value <- v
    static member Cast (p : ICell<Callability>) = 
        if p :? CallabilityModel then 
            p :?> CallabilityModel
        else
            let o = new CallabilityModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.Type                               = _Type 
    member this.date                               = _date 
    member this.Date                               = _date
    member this.Price                              = _price
    member this.Type1                              = _type
    member this.Accept                             v   
                                                   = _accept v 
    member this.HasOccurred                        d includeRefDate   
                                                   = _hasOccurred d includeRefDate 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
