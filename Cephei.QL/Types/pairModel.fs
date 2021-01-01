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
type PairModel<'TFirst, 'TSecond>
    ( first                                        : ICell<'TFirst>
    , second                                       : ICell<'TSecond>
    ) as this =

    inherit Model<Pair<'TFirst,'TSecond>> ()
(*
    Parameters
*)
    let _first                                     = first
    let _second                                    = second
(*
    Functions
*)
    let _Pair                                      = make (fun () -> new Pair<'TFirst,'TSecond> (first.Value, second.Value))
    let _first                                     = triv _Pair (fun () -> _Pair.Value.first)
    let _second                                    = triv _Pair (fun () -> _Pair.Value.second)
    let _set                                       (first : ICell<'TFirst>) (second : ICell<'TSecond>)   
                                                   = triv _Pair (fun () -> _Pair.Value.set(first.Value, second.Value)
                                                                           _Pair.Value)
    do this.Bind(_Pair)

(* 
    Externally visible/bindable properties
*)
    member this.first                              = _first 
    member this.second                             = _second 
    member this.First                              = _first
    member this.Second                             = _second
    member this.Set                                first second   
                                                   = _set first second 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PairModel1<'TFirst, 'TSecond>
    () as this =
    inherit Model<Pair<'TFirst,'TSecond>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Pair                                      = make (fun () -> new Pair<'TFirst,'TSecond> ())
    let _first                                     = triv _Pair (fun () -> _Pair.Value.first)
    let _second                                    = triv _Pair (fun () -> _Pair.Value.second)
    let _set                                       (first : ICell<'TFirst>) (second : ICell<'TSecond>)   
                                                   = triv _Pair (fun () -> _Pair.Value.set(first.Value, second.Value)
                                                                           _Pair.Value)
    do this.Bind(_Pair)

(* 
    Externally visible/bindable properties
*)
    member this.First                              = _first
    member this.Second                             = _second
    member this.Set                                first second   
                                                   = _set first second 
