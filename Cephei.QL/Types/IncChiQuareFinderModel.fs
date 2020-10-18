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
type IncChiQuareFinderModel
    ( y                                            : ICell<double>
    , g                                            : ICell<Func<double,double>>
    ) as this =

    inherit Model<IncChiQuareFinder> ()
(*
    Parameters
*)
    let _y                                         = y
    let _g                                         = g
(*
    Functions
*)
    let mutable
        _IncChiQuareFinder                         = cell (fun () -> new IncChiQuareFinder (y.Value, g.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _IncChiQuareFinder.Value.value(x.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = cell (fun () -> _IncChiQuareFinder.Value.derivative(x.Value))
    do this.Bind(_IncChiQuareFinder)
(* 
    casting 
*)
    internal new () = IncChiQuareFinderModel(null,null)
    member internal this.Inject v = _IncChiQuareFinder <- v
    static member Cast (p : ICell<IncChiQuareFinder>) = 
        if p :? IncChiQuareFinderModel then 
            p :?> IncChiQuareFinderModel
        else
            let o = new IncChiQuareFinderModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = IncChiQuareFinderModel(null,null)
    static member Cast (p : ICell<IncChiQuareFinder>) = 
        if p :? IncChiQuareFinderModel then 
            p :?> IncChiQuareFinderModel
        else
            let o = new IncChiQuareFinderModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.y                                  = _y 
    member this.g                                  = _g 
    member this.Value                              x   
                                                   = _value x 
    member this.Derivative                         x   
                                                   = _derivative x 
