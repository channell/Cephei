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

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type equal_on_firstModel
    () as this =
    inherit Model<equal_on_first> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _equal_on_first                            = make (fun () -> new equal_on_first ())
    let _Equals                                    (p1 : ICell<Pair<Nullable<double>,Nullable<double>>>) (p2 : ICell<Pair<Nullable<double>,Nullable<double>>>)   
                                                   = triv _equal_on_first (fun () -> _equal_on_first.Value.Equals(p1.Value, p2.Value))
    do this.Bind(_equal_on_first)
(* 
    casting 
*)
    
    member internal this.Inject v = _equal_on_first <- v
    static member Cast (p : ICell<equal_on_first>) = 
        if p :? equal_on_firstModel then 
            p :?> equal_on_firstModel
        else
            let o = new equal_on_firstModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Equals                             p1 p2   
                                                   = _Equals p1 p2 
