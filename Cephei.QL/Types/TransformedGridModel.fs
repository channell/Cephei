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
  This package encapuslates an array of grid points.  It is used primarily in PDE calculations.

  </summary> *)
[<AutoSerializable(true)>]
type TransformedGridModel
    ( grid                                         : ICell<Vector>
    ) as this =

    inherit Model<TransformedGrid> ()
(*
    Parameters
*)
    let _grid                                      = grid
(*
    Functions
*)
    let mutable
        _TransformedGrid                           = cell (fun () -> new TransformedGrid (grid.Value))
    let _dx                                        (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.dx(i.Value))
    let _dxArray                                   = triv (fun () -> _TransformedGrid.Value.dxArray())
    let _dxm                                       (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.dxm(i.Value))
    let _dxmArray                                  = triv (fun () -> _TransformedGrid.Value.dxmArray())
    let _dxp                                       (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.dxp(i.Value))
    let _dxpArray                                  = triv (fun () -> _TransformedGrid.Value.dxpArray())
    let _grid                                      (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.grid(i.Value))
    let _gridArray                                 = triv (fun () -> _TransformedGrid.Value.gridArray())
    let _size                                      = triv (fun () -> _TransformedGrid.Value.size())
    let _transformedGrid                           (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.transformedGrid(i.Value))
    let _transformedGridArray                      = triv (fun () -> _TransformedGrid.Value.transformedGridArray())
    do this.Bind(_TransformedGrid)
(* 
    casting 
*)
    internal new () = new TransformedGridModel(null)
    member internal this.Inject v = _TransformedGrid <- v
    static member Cast (p : ICell<TransformedGrid>) = 
        if p :? TransformedGridModel then 
            p :?> TransformedGridModel
        else
            let o = new TransformedGridModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
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
(* <summary>
  This package encapuslates an array of grid points.  It is used primarily in PDE calculations.

  </summary> *)
[<AutoSerializable(true)>]
type TransformedGridModel1
    ( grid                                         : ICell<Vector>
    , func                                         : ICell<Func<double,double>>
    ) as this =

    inherit Model<TransformedGrid> ()
(*
    Parameters
*)
    let _grid                                      = grid
    let _func                                      = func
(*
    Functions
*)
    let mutable
        _TransformedGrid                           = cell (fun () -> new TransformedGrid (grid.Value, func.Value))
    let _dx                                        (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.dx(i.Value))
    let _dxArray                                   = triv (fun () -> _TransformedGrid.Value.dxArray())
    let _dxm                                       (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.dxm(i.Value))
    let _dxmArray                                  = triv (fun () -> _TransformedGrid.Value.dxmArray())
    let _dxp                                       (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.dxp(i.Value))
    let _dxpArray                                  = triv (fun () -> _TransformedGrid.Value.dxpArray())
    let _grid                                      (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.grid(i.Value))
    let _gridArray                                 = triv (fun () -> _TransformedGrid.Value.gridArray())
    let _size                                      = triv (fun () -> _TransformedGrid.Value.size())
    let _transformedGrid                           (i : ICell<int>)   
                                                   = triv (fun () -> _TransformedGrid.Value.transformedGrid(i.Value))
    let _transformedGridArray                      = triv (fun () -> _TransformedGrid.Value.transformedGridArray())
    do this.Bind(_TransformedGrid)
(* 
    casting 
*)
    internal new () = new TransformedGridModel1(null,null)
    member internal this.Inject v = _TransformedGrid <- v
    static member Cast (p : ICell<TransformedGrid>) = 
        if p :? TransformedGridModel1 then 
            p :?> TransformedGridModel1
        else
            let o = new TransformedGridModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
    member this.func                               = _func 
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
