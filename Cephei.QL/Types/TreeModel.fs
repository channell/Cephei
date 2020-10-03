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
  %Tree approximating a single-factor diffusion

  </summary> *)
[<AutoSerializable(true)>]
type TreeModel<'T>
    ( columns                                      : ICell<int>
    ) as this =

    inherit Model<Tree<'T>> ()
(*
    Parameters
*)
    let _columns                                   = columns
(*
    Functions
*)
    let _Tree                                      = cell (fun () -> new Tree<'T> (columns.Value))
    let _columns                                   = triv (fun () -> _Tree.Value.columns())
    do this.Bind(_Tree)

(* 
    Externally visible/bindable properties
*)
    member this.columns                            = _columns 
    member this.Columns                            = _columns
(* <summary>
  %Tree approximating a single-factor diffusion
parameterless constructor is requried for generics
  </summary> *)
[<AutoSerializable(true)>]
type TreeModel1<'T>
    () as this =
    inherit Model<Tree<'T>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Tree                                      = cell (fun () -> new Tree<'T> ())
    let _columns                                   = triv (fun () -> _Tree.Value.columns())
    do this.Bind(_Tree)

(* 
    Externally visible/bindable properties
*)
    member this.Columns                            = _columns
