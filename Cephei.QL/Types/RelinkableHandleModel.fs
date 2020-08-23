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
  An instance of this class can be relinked so that it points to another observable. The change will be propagated to all handles that were created as copies of such instance.

  </summary> *)
[<AutoSerializable(true)>]
type RelinkableHandleModel<'T when 'T :> IObservable>
    ( h                                            : ICell<'T>
    ) as this =

    inherit Model<RelinkableHandle<'T>> ()
(*
    Parameters
*)
    let _h                                         = h
(*
    Functions
*)
    let _RelinkableHandle                          = cell (fun () -> new RelinkableHandle<'T> (h.Value))
    let _linkTo                                    (h : ICell<'T>) (registerAsObserver : ICell<bool>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.linkTo(h.Value, registerAsObserver.Value)
                                                                     _RelinkableHandle.Value)
    let _linkTo1                                   (h : ICell<'T>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.linkTo(h.Value)
                                                                     _RelinkableHandle.Value)
    let _currentLink                               = triv (fun () -> _RelinkableHandle.Value.currentLink())
    let _empty                                     = triv (fun () -> _RelinkableHandle.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.Equals(o.Value))
    let _link                                      = triv (fun () -> _RelinkableHandle.Value.link)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.registerWith(handler.Value)
                                                                     _RelinkableHandle.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.unregisterWith(handler.Value)
                                                                     _RelinkableHandle.Value)
    do this.Bind(_RelinkableHandle)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.LinkTo                             h registerAsObserver   
                                                   = _linkTo h registerAsObserver 
    member this.LinkTo1                            h   
                                                   = _linkTo1 h 
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
  An instance of this class can be relinked so that it points to another observable. The change will be propagated to all handles that were created as copies of such instance.

  </summary> *)
[<AutoSerializable(true)>]
type RelinkableHandleModel1<'T when 'T :> IObservable>
    () as this =
    inherit Model<RelinkableHandle<'T>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _RelinkableHandle                          = cell (fun () -> new RelinkableHandle<'T> ())
    let _linkTo                                    (h : ICell<'T>) (registerAsObserver : ICell<bool>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.linkTo(h.Value, registerAsObserver.Value)
                                                                     _RelinkableHandle.Value)
    let _linkTo1                                   (h : ICell<'T>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.linkTo(h.Value)
                                                                     _RelinkableHandle.Value)
    let _currentLink                               = triv (fun () -> _RelinkableHandle.Value.currentLink())
    let _empty                                     = triv (fun () -> _RelinkableHandle.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.Equals(o.Value))
    let _link                                      = triv (fun () -> _RelinkableHandle.Value.link)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.registerWith(handler.Value)
                                                                     _RelinkableHandle.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.unregisterWith(handler.Value)
                                                                     _RelinkableHandle.Value)
    do this.Bind(_RelinkableHandle)

(* 
    Externally visible/bindable properties
*)
    member this.LinkTo                             h registerAsObserver   
                                                   = _linkTo h registerAsObserver 
    member this.LinkTo1                            h   
                                                   = _linkTo1 h 
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
  An instance of this class can be relinked so that it points to another observable. The change will be propagated to all handles that were created as copies of such instance.

  </summary> *)
[<AutoSerializable(true)>]
type RelinkableHandleModel2<'T when 'T :> IObservable>
    ( h                                            : ICell<'T>
    , registerAsObserver                           : ICell<bool>
    ) as this =

    inherit Model<RelinkableHandle<'T>> ()
(*
    Parameters
*)
    let _h                                         = h
    let _registerAsObserver                        = registerAsObserver
(*
    Functions
*)
    let _RelinkableHandle                          = cell (fun () -> new RelinkableHandle<'T> (h.Value, registerAsObserver.Value))
    let _linkTo                                    (h : ICell<'T>) (registerAsObserver : ICell<bool>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.linkTo(h.Value, registerAsObserver.Value)
                                                                     _RelinkableHandle.Value)
    let _linkTo1                                   (h : ICell<'T>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.linkTo(h.Value)
                                                                     _RelinkableHandle.Value)
    let _currentLink                               = triv (fun () -> _RelinkableHandle.Value.currentLink())
    let _empty                                     = triv (fun () -> _RelinkableHandle.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.Equals(o.Value))
    let _link                                      = triv (fun () -> _RelinkableHandle.Value.link)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.registerWith(handler.Value)
                                                                     _RelinkableHandle.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RelinkableHandle.Value.unregisterWith(handler.Value)
                                                                     _RelinkableHandle.Value)
    do this.Bind(_RelinkableHandle)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.registerAsObserver                 = _registerAsObserver 
    member this.LinkTo                             h registerAsObserver   
                                                   = _linkTo h registerAsObserver 
    member this.LinkTo1                            h   
                                                   = _linkTo1 h 
    member this.CurrentLink                        = _currentLink
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Link                               = _link
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
