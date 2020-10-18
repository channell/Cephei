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
type RootNotBracketExceptionModel
    ( message                                      : ICell<string>
    , inner                                        : ICell<Exception>
    ) as this =

    inherit Model<RootNotBracketException> ()
(*
    Parameters
*)
    let _message                                   = message
    let _inner                                     = inner
(*
    Functions
*)
    let mutable
        _RootNotBracketException                   = cell (fun () -> new RootNotBracketException (message.Value, inner.Value))
    do this.Bind(_RootNotBracketException)
(* 
    casting 
*)
    internal new () = new RootNotBracketExceptionModel(null,null)
    member internal this.Inject v = _RootNotBracketException <- v
    static member Cast (p : ICell<RootNotBracketException>) = 
        if p :? RootNotBracketExceptionModel then 
            p :?> RootNotBracketExceptionModel
        else
            let o = new RootNotBracketExceptionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.message                            = _message 
    member this.inner                              = _inner 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type RootNotBracketExceptionModel1
    ( message                                      : ICell<string>
    ) as this =

    inherit Model<RootNotBracketException> ()
(*
    Parameters
*)
    let _message                                   = message
(*
    Functions
*)
    let mutable
        _RootNotBracketException                   = cell (fun () -> new RootNotBracketException (message.Value))
    do this.Bind(_RootNotBracketException)
(* 
    casting 
*)
    internal new () = new RootNotBracketExceptionModel1(null)
    member internal this.Inject v = _RootNotBracketException <- v
    static member Cast (p : ICell<RootNotBracketException>) = 
        if p :? RootNotBracketExceptionModel1 then 
            p :?> RootNotBracketExceptionModel1
        else
            let o = new RootNotBracketExceptionModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.message                            = _message 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type RootNotBracketExceptionModel2
    () as this =
    inherit Model<RootNotBracketException> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _RootNotBracketException                   = cell (fun () -> new RootNotBracketException ())
    do this.Bind(_RootNotBracketException)
(* 
    casting 
*)
    
    member internal this.Inject v = _RootNotBracketException <- v
    static member Cast (p : ICell<RootNotBracketException>) = 
        if p :? RootNotBracketExceptionModel2 then 
            p :?> RootNotBracketExceptionModel2
        else
            let o = new RootNotBracketExceptionModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
