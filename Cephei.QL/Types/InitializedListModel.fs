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
this is a redefined collection class to emulate array-type behaviour at initialisation if T is a class then the list is initilized with default constructors instead of null

  </summary> *)
[<AutoSerializable(true)>]
type InitializedListModel<'T>
    () as this =
    inherit Model<InitializedList<'T>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _InitializedList                           = cell (fun () -> new InitializedList<'T> ())
    let _Erase                                     = cell (fun () -> _InitializedList.Value.Erase()
                                                                     _InitializedList.Value)
    do this.Bind(_InitializedList)

(* 
    Externally visible/bindable properties
*)
    member this.Erase                              = _Erase
(* <summary>
this is a redefined collection class to emulate array-type behaviour at initialisation if T is a class then the list is initilized with default constructors instead of null

  </summary> *)
[<AutoSerializable(true)>]
type InitializedListModel1<'T>
    ( size                                         : ICell<int>
    ) as this =

    inherit Model<InitializedList<'T>> ()
(*
    Parameters
*)
    let _size                                      = size
(*
    Functions
*)
    let _InitializedList                           = cell (fun () -> new InitializedList<'T> (size.Value))
    let _Erase                                     = cell (fun () -> _InitializedList.Value.Erase()
                                                                     _InitializedList.Value)
    do this.Bind(_InitializedList)

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.Erase                              = _Erase
(* <summary>
this is a redefined collection class to emulate array-type behaviour at initialisation if T is a class then the list is initilized with default constructors instead of null

  </summary> *)
[<AutoSerializable(true)>]
type InitializedListModel2<'T>
    ( size                                         : ICell<int>
    , value                                        : ICell<'T>
    ) as this =

    inherit Model<InitializedList<'T>> ()
(*
    Parameters
*)
    let _size                                      = size
    let _value                                     = value
(*
    Functions
*)
    let _InitializedList                           = cell (fun () -> new InitializedList<'T> (size.Value, value.Value))
    let _Erase                                     = cell (fun () -> _InitializedList.Value.Erase()
                                                                     _InitializedList.Value)
    do this.Bind(_InitializedList)

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.value                              = _value 
    member this.Erase                              = _Erase
