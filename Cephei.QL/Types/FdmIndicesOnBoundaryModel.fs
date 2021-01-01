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
type FdmIndicesOnBoundaryModel
    ( layout                                       : ICell<FdmLinearOpLayout>
    , direction                                    : ICell<int>
    , side                                         : ICell<BoundaryCondition<FdmLinearOp>.Side>
    ) as this =

    inherit Model<FdmIndicesOnBoundary> ()
(*
    Parameters
*)
    let _layout                                    = layout
    let _direction                                 = direction
    let _side                                      = side
(*
    Functions
*)
    let mutable
        _FdmIndicesOnBoundary                      = make (fun () -> new FdmIndicesOnBoundary (layout.Value, direction.Value, side.Value))
    let _getIndices                                = triv _FdmIndicesOnBoundary (fun () -> _FdmIndicesOnBoundary.Value.getIndices())
    do this.Bind(_FdmIndicesOnBoundary)
(* 
    casting 
*)
    internal new () = new FdmIndicesOnBoundaryModel(null,null,null)
    member internal this.Inject v = _FdmIndicesOnBoundary <- v
    static member Cast (p : ICell<FdmIndicesOnBoundary>) = 
        if p :? FdmIndicesOnBoundaryModel then 
            p :?> FdmIndicesOnBoundaryModel
        else
            let o = new FdmIndicesOnBoundaryModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.layout                             = _layout 
    member this.direction                          = _direction 
    member this.side                               = _side 
    member this.GetIndices                         = _getIndices
