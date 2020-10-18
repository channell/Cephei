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
  All copies of an instance of this class refer to the same observable by means of a relinkable smart pointer. When such pointer is relinked to another observable, the change will be propagated to all the copies.
<tt>registerAsObserver</tt> is not needed since C# does automatic garbage collection

  </summary> *)
[<AutoSerializable(true)>]
type HandleModel<'T when 'T :> IObservable>
    () as this =
    inherit Model<Handle<'T>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Handle                                    = cell (fun () -> new Handle<'T> ())
    let _currentLink                               = triv (fun () -> _Handle.Value.currentLink())
    let _empty                                     = triv (fun () -> _Handle.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Handle.Value.Equals(o.Value))
    let _link                                      = triv (fun () -> _Handle.Value.link)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Handle.Value.registerWith(handler.Value)
                                                                     _Handle.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Handle.Value.unregisterWith(handler.Value)
                                                                     _Handle.Value)
    do this.Bind(_Handle)

(* 
    Externally visible/bindable properties
*)
    member this.CurrentLink                        = _currentLink
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Link                               = _link
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  All copies of an instance of this class refer to the same observable by means of a relinkable smart pointer. When such pointer is relinked to another observable, the change will be propagated to all the copies.
<tt>registerAsObserver</tt> is not needed since C# does automatic garbage collection

  </summary> *)
[<AutoSerializable(true)>]
type HandleModel1<'T when 'T :> IObservable>
    ( h                                            : ICell<'T>
    , registerAsObserver                           : ICell<bool>
    ) as this =

    inherit Model<Handle<'T>> ()
(*
    Parameters
*)
    let _h                                         = h
    let _registerAsObserver                        = registerAsObserver
(*
    Functions
*)
    let mutable
        _Handle                                    = cell (fun () -> new Handle<'T> (h.Value, registerAsObserver.Value))
    let _currentLink                               = triv (fun () -> _Handle.Value.currentLink())
    let _empty                                     = triv (fun () -> _Handle.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Handle.Value.Equals(o.Value))
    let _link                                      = triv (fun () -> _Handle.Value.link)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Handle.Value.registerWith(handler.Value)
                                                                     _Handle.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Handle.Value.unregisterWith(handler.Value)
                                                                     _Handle.Value)
    do this.Bind(_Handle)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.registerAsObserver                 = _registerAsObserver 
    member this.CurrentLink                        = _currentLink
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Link                               = _link
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  All copies of an instance of this class refer to the same observable by means of a relinkable smart pointer. When such pointer is relinked to another observable, the change will be propagated to all the copies.
<tt>registerAsObserver</tt> is not needed since C# does automatic garbage collection

  </summary> *)
[<AutoSerializable(true)>]
type HandleModel2<'T when 'T :> IObservable>
    ( h                                            : ICell<'T>
    ) as this =

    inherit Model<Handle<'T>> ()
(*
    Parameters
*)
    let _h                                         = h
(*
    Functions
*)
    let mutable
        _Handle                                    = cell (fun () -> new Handle<'T> (h.Value))
    let _currentLink                               = triv (fun () -> _Handle.Value.currentLink())
    let _empty                                     = triv (fun () -> _Handle.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Handle.Value.Equals(o.Value))
    let _link                                      = triv (fun () -> _Handle.Value.link)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Handle.Value.registerWith(handler.Value)
                                                                     _Handle.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Handle.Value.unregisterWith(handler.Value)
                                                                     _Handle.Value)
    do this.Bind(_Handle)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.CurrentLink                        = _currentLink
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Link                               = _link
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
