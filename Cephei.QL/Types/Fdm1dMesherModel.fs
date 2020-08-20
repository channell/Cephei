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
type Fdm1dMesherModel
    ( size                                         : ICell<int>
    ) as this =

    inherit Model<Fdm1dMesher> ()
(*
    Parameters
*)
    let _size                                      = size
(*
    Functions
*)
    let _Fdm1dMesher                               = cell (fun () -> new Fdm1dMesher (size.Value))
    let _dminus                                    (index : ICell<int>)   
                                                   = cell (fun () -> _Fdm1dMesher.Value.dminus(index.Value))
    let _dplus                                     (index : ICell<int>)   
                                                   = cell (fun () -> _Fdm1dMesher.Value.dplus(index.Value))
    let _location                                  (index : ICell<int>)   
                                                   = cell (fun () -> _Fdm1dMesher.Value.location(index.Value))
    let _locations                                 = cell (fun () -> _Fdm1dMesher.Value.locations())
    let _size                                      = cell (fun () -> _Fdm1dMesher.Value.size())
    do this.Bind(_Fdm1dMesher)

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
    member this.Dminus                             index   
                                                   = _dminus index 
    member this.Dplus                              index   
                                                   = _dplus index 
    member this.Location                           index   
                                                   = _location index 
    member this.Locations                          = _locations
    member this.Size                               = _size
