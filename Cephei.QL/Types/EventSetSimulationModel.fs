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
type EventSetSimulationModel
    ( events                                       : ICell<Generic.List<KeyValuePair<Date,double>>>
    , eventsStart                                  : ICell<Date>
    , eventsEnd                                    : ICell<Date>
    , start                                        : ICell<Date>
    , End                                          : ICell<Date>
    ) as this =

    inherit Model<EventSetSimulation> ()
(*
    Parameters
*)
    let _events                                    = events
    let _eventsStart                               = eventsStart
    let _eventsEnd                                 = eventsEnd
    let _start                                     = start
    let _End                                       = End
(*
    Functions
*)
    let _EventSetSimulation                        = cell (fun () -> new EventSetSimulation (events.Value, eventsStart.Value, eventsEnd.Value, start.Value, End.Value))
    let _nextPath                                  (path : ICell<Generic.List<KeyValuePair<Date,double>>>)   
                                                   = triv (fun () -> _EventSetSimulation.Value.nextPath(path.Value))
    do this.Bind(_EventSetSimulation)
(* 
    casting 
*)
    internal new () = new EventSetSimulationModel(null,null,null,null,null)
    member internal this.Inject v = _EventSetSimulation.Value <- v
    static member Cast (p : ICell<EventSetSimulation>) = 
        if p :? EventSetSimulationModel then 
            p :?> EventSetSimulationModel
        else
            let o = new EventSetSimulationModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.events                             = _events 
    member this.eventsStart                        = _eventsStart 
    member this.eventsEnd                          = _eventsEnd 
    member this.start                              = _start 
    member this.End                                = _End 
    member this.NextPath                           path   
                                                   = _nextPath path 
