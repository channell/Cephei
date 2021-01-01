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
  USA as geographical/economic region

  </summary> *)
[<AutoSerializable(true)>]
type USRegionModel
    () as this =
    inherit Model<USRegion> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _USRegion                                  = make (fun () -> new USRegion ())
    let _code                                      = triv _USRegion (fun () -> _USRegion.Value.code())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _USRegion (fun () -> _USRegion.Value.Equals(o.Value))
    let _name                                      = triv _USRegion (fun () -> _USRegion.Value.name())
    do this.Bind(_USRegion)
(* 
    casting 
*)
    
    member internal this.Inject v = _USRegion <- v
    static member Cast (p : ICell<USRegion>) = 
        if p :? USRegionModel then 
            p :?> USRegionModel
        else
            let o = new USRegionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Code                               = _code
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Name                               = _name
