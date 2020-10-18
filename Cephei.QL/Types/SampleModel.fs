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
todo check for Sample for value types and Sample for object types to take care of proper object copying

  </summary> *)
[<AutoSerializable(true)>]
type SampleModel<'T>
    ( value_                                       : ICell<'T>
    , weight_                                      : ICell<double>
    ) as this =

    inherit Model<Sample<'T>> ()
(*
    Parameters
*)
    let _value_                                    = value_
    let _weight_                                   = weight_
(*
    Functions
*)
    let mutable
        _Sample                                    = cell (fun () -> new Sample<'T> (value_.Value, weight_.Value))
    let _value                                     = triv (fun () -> _Sample.Value.value)
    let _weight                                    = triv (fun () -> _Sample.Value.weight)
    do this.Bind(_Sample)

(* 
    Externally visible/bindable properties
*)
    member this.value_                             = _value_ 
    member this.weight_                            = _weight_ 
    member this.Value                              = _value
    member this.Weight                             = _weight
