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
type EventSetModel
    ( events                                       : ICell<Generic.List<KeyValuePair<Date,double>>>
    , eventsStart                                  : ICell<Date>
    , eventsEnd                                    : ICell<Date>
    ) as this =

    inherit Model<EventSet> ()
(*
    Parameters
*)
    let _events                                    = events
    let _eventsStart                               = eventsStart
    let _eventsEnd                                 = eventsEnd
(*
    Functions
*)
    let _EventSet                                  = cell (fun () -> new EventSet (events.Value, eventsStart.Value, eventsEnd.Value))
    let _newSimulation                             (start : ICell<Date>) (End : ICell<Date>)   
                                                   = cell (fun () -> _EventSet.Value.newSimulation(start.Value, End.Value))
    do this.Bind(_EventSet)

(* 
    Externally visible/bindable properties
*)
    member this.events                             = _events 
    member this.eventsStart                        = _eventsStart 
    member this.eventsEnd                          = _eventsEnd 
    member this.NewSimulation                      start End   
                                                   = _newSimulation start End 
