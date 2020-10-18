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
type UniformGridMesherModel
    ( layout                                       : ICell<FdmLinearOpLayout>
    , boundaries                                   : ICell<List<Pair<Nullable<double>,Nullable<double>>>>
    ) as this =

    inherit Model<UniformGridMesher> ()
(*
    Parameters
*)
    let _layout                                    = layout
    let _boundaries                                = boundaries
(*
    Functions
*)
    let mutable
        _UniformGridMesher                         = cell (fun () -> new UniformGridMesher (layout.Value, boundaries.Value))
    let _dminus                                    (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _UniformGridMesher.Value.dminus(iter.Value, direction.Value))
    let _dplus                                     (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _UniformGridMesher.Value.dplus(iter.Value, direction.Value))
    let _location                                  (iter : ICell<FdmLinearOpIterator>) (direction : ICell<int>)   
                                                   = triv (fun () -> _UniformGridMesher.Value.location(iter.Value, direction.Value))
    let _locations                                 (direction : ICell<int>)   
                                                   = triv (fun () -> _UniformGridMesher.Value.locations(direction.Value))
    let _layout                                    = triv (fun () -> _UniformGridMesher.Value.layout())
    do this.Bind(_UniformGridMesher)
(* 
    casting 
*)
    internal new () = new UniformGridMesherModel(null,null)
    member internal this.Inject v = _UniformGridMesher <- v
    static member Cast (p : ICell<UniformGridMesher>) = 
        if p :? UniformGridMesherModel then 
            p :?> UniformGridMesherModel
        else
            let o = new UniformGridMesherModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.layout                             = _layout 
    member this.boundaries                         = _boundaries 
    member this.Dminus                             iter direction   
                                                   = _dminus iter direction 
    member this.Dplus                              iter direction   
                                                   = _dplus iter direction 
    member this.Location                           iter direction   
                                                   = _location iter direction 
    member this.Locations                          direction   
                                                   = _locations direction 
    member this.Layout                             = _layout
