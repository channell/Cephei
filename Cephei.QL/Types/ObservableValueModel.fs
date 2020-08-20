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
  Observers can be registered with instances of this class so that they are notified when a different value is assigned to such instances. Client code can copy the contained value or pass it to functions via implicit conversion. it is not possible to call non-const method on the returned value. This is by design, as this possibility would necessarily bypass the notification code; client code should modify the value via re-assignment instead.

  </summary> *)
[<AutoSerializable(true)>]
type ObservableValueModel<'T>
    ( t                                            : ICell<'T>
    ) as this =

    inherit Model<ObservableValue<'T>> ()
(*
    Parameters
*)
    let _t                                         = t
(*
    Functions
*)
    let _ObservableValue                           = cell (fun () -> new ObservableValue<'T> (t.Value))
    let _Assign                                    (t : ICell<'T>)   
                                                   = cell (fun () -> _ObservableValue.Value.Assign(t.Value))
    let _Assign1                                   (t : ICell<ObservableValue<'T>>)   
                                                   = cell (fun () -> _ObservableValue.Value.Assign(t.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ObservableValue.Value.registerWith(handler.Value)
                                                                     _ObservableValue.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ObservableValue.Value.unregisterWith(handler.Value)
                                                                     _ObservableValue.Value)
    let _value                                     = cell (fun () -> _ObservableValue.Value.value())
    do this.Bind(_ObservableValue)

(* 
    Externally visible/bindable properties
*)
    member this.t                                  = _t 
    member this.Assign                             t   
                                                   = _Assign t 
    member this.Assign1                            t   
                                                   = _Assign1 t 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Value                              = _value
(* <summary>
  Observers can be registered with instances of this class so that they are notified when a different value is assigned to such instances. Client code can copy the contained value or pass it to functions via implicit conversion. it is not possible to call non-const method on the returned value. This is by design, as this possibility would necessarily bypass the notification code; client code should modify the value via re-assignment instead.

  </summary> *)
[<AutoSerializable(true)>]
type ObservableValueModel1<'T>
    ( t                                            : ICell<ObservableValue<'T>>
    ) as this =

    inherit Model<ObservableValue<'T>> ()
(*
    Parameters
*)
    let _t                                         = t
(*
    Functions
*)
    let _ObservableValue                           = cell (fun () -> new ObservableValue<'T> (t.Value))
    let _Assign                                    (t : ICell<'T>)   
                                                   = cell (fun () -> _ObservableValue.Value.Assign(t.Value))
    let _Assign1                                   (t : ICell<ObservableValue<'T>>)   
                                                   = cell (fun () -> _ObservableValue.Value.Assign(t.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ObservableValue.Value.registerWith(handler.Value)
                                                                     _ObservableValue.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ObservableValue.Value.unregisterWith(handler.Value)
                                                                     _ObservableValue.Value)
    let _value                                     = cell (fun () -> _ObservableValue.Value.value())
    do this.Bind(_ObservableValue)

(* 
    Externally visible/bindable properties
*)
    member this.t                                  = _t 
    member this.Assign                             t   
                                                   = _Assign t 
    member this.Assign1                            t   
                                                   = _Assign1 t 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Value                              = _value
(* <summary>
  Observers can be registered with instances of this class so that they are notified when a different value is assigned to such instances. Client code can copy the contained value or pass it to functions via implicit conversion. it is not possible to call non-const method on the returned value. This is by design, as this possibility would necessarily bypass the notification code; client code should modify the value via re-assignment instead.

  </summary> *)
[<AutoSerializable(true)>]
type ObservableValueModel2<'T>
    () as this =
    inherit Model<ObservableValue<'T>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ObservableValue                           = cell (fun () -> new ObservableValue<'T> ())
    let _Assign                                    (t : ICell<'T>)   
                                                   = cell (fun () -> _ObservableValue.Value.Assign(t.Value))
    let _Assign1                                   (t : ICell<ObservableValue<'T>>)   
                                                   = cell (fun () -> _ObservableValue.Value.Assign(t.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ObservableValue.Value.registerWith(handler.Value)
                                                                     _ObservableValue.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ObservableValue.Value.unregisterWith(handler.Value)
                                                                     _ObservableValue.Value)
    let _value                                     = cell (fun () -> _ObservableValue.Value.value())
    do this.Bind(_ObservableValue)

(* 
    Externally visible/bindable properties
*)
    member this.Assign                             t   
                                                   = _Assign t 
    member this.Assign1                            t   
                                                   = _Assign1 t 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Value                              = _value
