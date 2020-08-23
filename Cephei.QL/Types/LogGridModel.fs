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
type LogGridModel
    ( grid                                         : ICell<Vector>
    ) as this =

    inherit Model<LogGrid> ()
(*
    Parameters
*)
    let _grid                                      = grid
(*
    Functions
*)
    let _LogGrid                                   = cell (fun () -> new LogGrid (grid.Value))
    let _logGrid                                   (i : ICell<int>)   
                                                   = triv (fun () -> _LogGrid.Value.logGrid(i.Value))
    let _logGridArray                              = triv (fun () -> _LogGrid.Value.logGridArray())
    let _dx                                        (i : ICell<int>)   
                                                   = triv (fun () -> _LogGrid.Value.dx(i.Value))
    let _dxArray                                   = triv (fun () -> _LogGrid.Value.dxArray())
    let _dxm                                       (i : ICell<int>)   
                                                   = triv (fun () -> _LogGrid.Value.dxm(i.Value))
    let _dxmArray                                  = triv (fun () -> _LogGrid.Value.dxmArray())
    let _dxp                                       (i : ICell<int>)   
                                                   = triv (fun () -> _LogGrid.Value.dxp(i.Value))
    let _dxpArray                                  = triv (fun () -> _LogGrid.Value.dxpArray())
    let _grid                                      (i : ICell<int>)   
                                                   = triv (fun () -> _LogGrid.Value.grid(i.Value))
    let _gridArray                                 = triv (fun () -> _LogGrid.Value.gridArray())
    let _size                                      = triv (fun () -> _LogGrid.Value.size())
    let _transformedGrid                           (i : ICell<int>)   
                                                   = triv (fun () -> _LogGrid.Value.transformedGrid(i.Value))
    let _transformedGridArray                      = triv (fun () -> _LogGrid.Value.transformedGridArray())
    do this.Bind(_LogGrid)

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
    member this.LogGrid                            i   
                                                   = _logGrid i 
    member this.LogGridArray                       = _logGridArray
    member this.Dx                                 i   
                                                   = _dx i 
    member this.DxArray                            = _dxArray
    member this.Dxm                                i   
                                                   = _dxm i 
    member this.DxmArray                           = _dxmArray
    member this.Dxp                                i   
                                                   = _dxp i 
    member this.DxpArray                           = _dxpArray
    member this.Grid                               i   
                                                   = _grid i 
    member this.GridArray                          = _gridArray
    member this.Size                               = _size
    member this.TransformedGrid                    i   
                                                   = _transformedGrid i 
    member this.TransformedGridArray               = _transformedGridArray
