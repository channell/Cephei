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
type FdmLinearOpIteratorModel
    ( index                                        : ICell<int>
    ) as this =

    inherit Model<FdmLinearOpIterator> ()
(*
    Parameters
*)
    let _index                                     = index
(*
    Functions
*)
    let _FdmLinearOpIterator                       = cell (fun () -> new FdmLinearOpIterator (index.Value))
    let _coordinates                               = triv (fun () -> _FdmLinearOpIterator.Value.coordinates())
    let _Equals                                    (obj : ICell<Object>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.Equals(obj.Value))
    let _index                                     = triv (fun () -> _FdmLinearOpIterator.Value.index())
    let _swap                                      (iter : ICell<FdmLinearOpIterator>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.swap(iter.Value)
                                                                     _FdmLinearOpIterator.Value)
    do this.Bind(_FdmLinearOpIterator)

(* 
    Externally visible/bindable properties
*)
    member this.index                              = _index 
    member this.Coordinates                        = _coordinates
    member this.Equals                             obj   
                                                   = _Equals obj 
    member this.Index                              = _index
    member this.Swap                               iter   
                                                   = _swap iter 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmLinearOpIteratorModel1
    ( dim                                          : ICell<Generic.List<int>>
    ) as this =

    inherit Model<FdmLinearOpIterator> ()
(*
    Parameters
*)
    let _dim                                       = dim
(*
    Functions
*)
    let _FdmLinearOpIterator                       = cell (fun () -> new FdmLinearOpIterator (dim.Value))
    let _coordinates                               = triv (fun () -> _FdmLinearOpIterator.Value.coordinates())
    let _Equals                                    (obj : ICell<Object>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.Equals(obj.Value))
    let _index                                     = triv (fun () -> _FdmLinearOpIterator.Value.index())
    let _swap                                      (iter : ICell<FdmLinearOpIterator>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.swap(iter.Value)
                                                                     _FdmLinearOpIterator.Value)
    do this.Bind(_FdmLinearOpIterator)

(* 
    Externally visible/bindable properties
*)
    member this.dim                                = _dim 
    member this.Coordinates                        = _coordinates
    member this.Equals                             obj   
                                                   = _Equals obj 
    member this.Index                              = _index
    member this.Swap                               iter   
                                                   = _swap iter 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmLinearOpIteratorModel2
    ( dim                                          : ICell<Generic.List<int>>
    , coordinates                                  : ICell<Generic.List<int>>
    , index                                        : ICell<int>
    ) as this =

    inherit Model<FdmLinearOpIterator> ()
(*
    Parameters
*)
    let _dim                                       = dim
    let _coordinates                               = coordinates
    let _index                                     = index
(*
    Functions
*)
    let _FdmLinearOpIterator                       = cell (fun () -> new FdmLinearOpIterator (dim.Value, coordinates.Value, index.Value))
    let _coordinates                               = triv (fun () -> _FdmLinearOpIterator.Value.coordinates())
    let _Equals                                    (obj : ICell<Object>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.Equals(obj.Value))
    let _index                                     = triv (fun () -> _FdmLinearOpIterator.Value.index())
    let _swap                                      (iter : ICell<FdmLinearOpIterator>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.swap(iter.Value)
                                                                     _FdmLinearOpIterator.Value)
    do this.Bind(_FdmLinearOpIterator)

(* 
    Externally visible/bindable properties
*)
    member this.dim                                = _dim 
    member this.coordinates                        = _coordinates 
    member this.index                              = _index 
    member this.Coordinates                        = _coordinates
    member this.Equals                             obj   
                                                   = _Equals obj 
    member this.Index                              = _index
    member this.Swap                               iter   
                                                   = _swap iter 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type FdmLinearOpIteratorModel3
    ( iter                                         : ICell<FdmLinearOpIterator>
    ) as this =

    inherit Model<FdmLinearOpIterator> ()
(*
    Parameters
*)
    let _iter                                      = iter
(*
    Functions
*)
    let _FdmLinearOpIterator                       = cell (fun () -> new FdmLinearOpIterator (iter.Value))
    let _coordinates                               = triv (fun () -> _FdmLinearOpIterator.Value.coordinates())
    let _Equals                                    (obj : ICell<Object>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.Equals(obj.Value))
    let _index                                     = triv (fun () -> _FdmLinearOpIterator.Value.index())
    let _swap                                      (iter : ICell<FdmLinearOpIterator>)   
                                                   = triv (fun () -> _FdmLinearOpIterator.Value.swap(iter.Value)
                                                                     _FdmLinearOpIterator.Value)
    do this.Bind(_FdmLinearOpIterator)

(* 
    Externally visible/bindable properties
*)
    member this.iter                               = _iter 
    member this.Coordinates                        = _coordinates
    member this.Equals                             obj   
                                                   = _Equals obj 
    member this.Index                              = _index
    member this.Swap                               iter   
                                                   = _swap iter 
