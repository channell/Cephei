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
  %callability leaving to the holder the possibility to convert

  </summary> *)
[<AutoSerializable(true)>]
type SoftCallabilityModel
    ( price                                        : ICell<Callability.Price>
    , date                                         : ICell<Date>
    , trigger                                      : ICell<double>
    ) as this =

    inherit Model<SoftCallability> ()
(*
    Parameters
*)
    let _price                                     = price
    let _date                                      = date
    let _trigger                                   = trigger
(*
    Functions
*)
    let _SoftCallability                           = cell (fun () -> new SoftCallability (price.Value, date.Value, trigger.Value))
    let _trigger                                   = triv (fun () -> _SoftCallability.Value.trigger())
    let _date                                      = triv (fun () -> _SoftCallability.Value.date())
    let _price                                     = triv (fun () -> _SoftCallability.Value.price())
    let _type                                      = triv (fun () -> _SoftCallability.Value.TYPE())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _SoftCallability.Value.accept(v.Value)
                                                                     _SoftCallability.Value)
    let _hasOccurred                               (d : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _SoftCallability.Value.hasOccurred(d.Value, includeRefDate.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SoftCallability.Value.registerWith(handler.Value)
                                                                     _SoftCallability.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SoftCallability.Value.unregisterWith(handler.Value)
                                                                     _SoftCallability.Value)
    do this.Bind(_SoftCallability)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.date                               = _date 
    member this.trigger                            = _trigger 
    member this.Trigger                            = _trigger
    member this.Date                               = _date
    member this.Price                              = _price
    member this.Type                               = _type
    member this.Accept                             v   
                                                   = _accept v 
    member this.HasOccurred                        d includeRefDate   
                                                   = _hasOccurred d includeRefDate 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
