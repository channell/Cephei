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
type OdeFctWrapperModel
    ( ode1d                                        : ICell<OdeFct1d>
    ) as this =

    inherit Model<OdeFctWrapper> ()
(*
    Parameters
*)
    let _ode1d                                     = ode1d
(*
    Functions
*)
    let mutable
        _OdeFctWrapper                             = cell (fun () -> new OdeFctWrapper (ode1d.Value))
    let _value                                     (x : ICell<double>) (y : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _OdeFctWrapper.Value.value(x.Value, y.Value))
    do this.Bind(_OdeFctWrapper)
(* 
    casting 
*)
    internal new () = OdeFctWrapperModel(null)
    member internal this.Inject v = _OdeFctWrapper <- v
    static member Cast (p : ICell<OdeFctWrapper>) = 
        if p :? OdeFctWrapperModel then 
            p :?> OdeFctWrapperModel
        else
            let o = new OdeFctWrapperModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = OdeFctWrapperModel(null)
    static member Cast (p : ICell<OdeFctWrapper>) = 
        if p :? OdeFctWrapperModel then 
            p :?> OdeFctWrapperModel
        else
            let o = new OdeFctWrapperModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.ode1d                              = _ode1d 
    member this.Value                              x y   
                                                   = _value x y 
