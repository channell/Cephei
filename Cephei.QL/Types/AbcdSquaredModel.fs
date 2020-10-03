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
Helper class used by unit tests

  </summary> *)
[<AutoSerializable(true)>]
type AbcdSquaredModel
    ( a                                            : ICell<double>
    , b                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    , T                                            : ICell<double>
    , S                                            : ICell<double>
    ) as this =

    inherit Model<AbcdSquared> ()
(*
    Parameters
*)
    let _a                                         = a
    let _b                                         = b
    let _c                                         = c
    let _d                                         = d
    let _T                                         = T
    let _S                                         = S
(*
    Functions
*)
    let _AbcdSquared                               = cell (fun () -> new AbcdSquared (a.Value, b.Value, c.Value, d.Value, T.Value, S.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _AbcdSquared.Value.value(t.Value))
    do this.Bind(_AbcdSquared)
(* 
    casting 
*)
    internal new () = AbcdSquaredModel(null,null,null,null,null,null)
    member internal this.Inject v = _AbcdSquared.Value <- v
    static member Cast (p : ICell<AbcdSquared>) = 
        if p :? AbcdSquaredModel then 
            p :?> AbcdSquaredModel
        else
            let o = new AbcdSquaredModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.c                                  = _c 
    member this.d                                  = _d 
    member this.T                                  = _T 
    member this.S                                  = _S 
    member this.Value                              t   
                                                   = _value t 
