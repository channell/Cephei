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
  Used in CEV models
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type ZeroConditionModel<'array_type when 'array_type :> Vector>
    () as this =
    inherit Model<ZeroCondition<'array_type>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ZeroCondition                             = cell (fun () -> new ZeroCondition<'array_type> ())
    let _applyTo                                   (a : ICell<Object>) (t : ICell<double>)   
                                                   = triv (fun () -> _ZeroCondition.Value.applyTo(a.Value, t.Value)
                                                                     _ZeroCondition.Value)
    do this.Bind(_ZeroCondition)

(* 
    Externally visible/bindable properties
*)
    member this.ApplyTo                            a t   
                                                   = _applyTo a t 
