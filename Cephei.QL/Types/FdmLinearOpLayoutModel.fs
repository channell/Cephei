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
type FdmLinearOpLayoutModel
    ( dim                                          : ICell<Generic.List<int>>
    ) as this =

    inherit Model<FdmLinearOpLayout> ()
(*
    Parameters
*)
    let _dim                                       = dim
(*
    Functions
*)
    let _FdmLinearOpLayout                         = cell (fun () -> new FdmLinearOpLayout (dim.Value))
    let _begin                                     = triv (fun () -> _FdmLinearOpLayout.Value.BEGIN())
    let _dim                                       = triv (fun () -> _FdmLinearOpLayout.Value.dim())
    let _end                                       = triv (fun () -> _FdmLinearOpLayout.Value.END())
    let _index                                     (coordinates : ICell<Generic.List<int>>)   
                                                   = triv (fun () -> _FdmLinearOpLayout.Value.index(coordinates.Value))
    let _iter_neighbourhood                        (iterator : ICell<FdmLinearOpIterator>) (i : ICell<int>) (offset : ICell<int>)   
                                                   = triv (fun () -> _FdmLinearOpLayout.Value.iter_neighbourhood(iterator.Value, i.Value, offset.Value))
    let _neighbourhood                             (iterator : ICell<FdmLinearOpIterator>) (i1 : ICell<int>) (offset1 : ICell<int>) (i2 : ICell<int>) (offset2 : ICell<int>)   
                                                   = triv (fun () -> _FdmLinearOpLayout.Value.neighbourhood(iterator.Value, i1.Value, offset1.Value, i2.Value, offset2.Value))
    let _neighbourhood1                            (iterator : ICell<FdmLinearOpIterator>) (i : ICell<int>) (offset : ICell<int>)   
                                                   = triv (fun () -> _FdmLinearOpLayout.Value.neighbourhood(iterator.Value, i.Value, offset.Value))
    let _size                                      = triv (fun () -> _FdmLinearOpLayout.Value.size())
    let _spacing                                   = triv (fun () -> _FdmLinearOpLayout.Value.spacing())
    do this.Bind(_FdmLinearOpLayout)
(* 
    casting 
*)
    internal new () = new FdmLinearOpLayoutModel(null)
    member internal this.Inject v = _FdmLinearOpLayout.Value <- v
    static member Cast (p : ICell<FdmLinearOpLayout>) = 
        if p :? FdmLinearOpLayoutModel then 
            p :?> FdmLinearOpLayoutModel
        else
            let o = new FdmLinearOpLayoutModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.dim                                = _dim 
    member this.Begin                              = _begin
    member this.Dim                                = _dim
    member this.End                                = _end
    member this.Index                              coordinates   
                                                   = _index coordinates 
    member this.Iter_neighbourhood                 iterator i offset   
                                                   = _iter_neighbourhood iterator i offset 
    member this.Neighbourhood                      iterator i1 offset1 i2 offset2   
                                                   = _neighbourhood iterator i1 offset1 i2 offset2 
    member this.Neighbourhood1                     iterator i offset   
                                                   = _neighbourhood1 iterator i offset 
    member this.Size                               = _size
    member this.Spacing                            = _spacing
