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
type WeakEventSourceModel
    () as this =
    inherit Model<WeakEventSource> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _WeakEventSource                           = cell (fun () -> new WeakEventSource ())
    let _Clear                                     = triv (fun () -> _WeakEventSource.Value.Clear()
                                                                     _WeakEventSource.Value)
    let _Raise                                     = triv (fun () -> _WeakEventSource.Value.Raise()
                                                                     _WeakEventSource.Value)
    let _Subscribe                                 (handler : ICell<Callback>)   
                                                   = triv (fun () -> _WeakEventSource.Value.Subscribe(handler.Value)
                                                                     _WeakEventSource.Value)
    let _Unsubscribe                               (handler : ICell<Callback>)   
                                                   = triv (fun () -> _WeakEventSource.Value.Unsubscribe(handler.Value)
                                                                     _WeakEventSource.Value)
    do this.Bind(_WeakEventSource)
(* 
    casting 
*)
    
    member internal this.Inject v = _WeakEventSource.Value <- v
    static member Cast (p : ICell<WeakEventSource>) = 
        if p :? WeakEventSourceModel then 
            p :?> WeakEventSourceModel
        else
            let o = new WeakEventSourceModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Clear                              = _Clear
    member this.Raise                              = _Raise
    member this.Subscribe                          handler   
                                                   = _Subscribe handler 
    member this.Unsubscribe                        handler   
                                                   = _Unsubscribe handler 
