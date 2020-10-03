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

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type BackwardflatLinearModel
    () as this =
    inherit Model<BackwardflatLinear> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _BackwardflatLinear                        = cell (fun () -> new BackwardflatLinear ())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (xEnd : ICell<int>) (yBegin : ICell<Generic.List<double>>) (yEnd : ICell<int>) (z : ICell<Matrix>)   
                                                   = triv (fun () -> _BackwardflatLinear.Value.interpolate(xBegin.Value, xEnd.Value, yBegin.Value, yEnd.Value, z.Value))
    do this.Bind(_BackwardflatLinear)
(* 
    casting 
*)
    
    member internal this.Inject v = _BackwardflatLinear.Value <- v
    static member Cast (p : ICell<BackwardflatLinear>) = 
        if p :? BackwardflatLinearModel then 
            p :?> BackwardflatLinearModel
        else
            let o = new BackwardflatLinearModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Interpolate                        xBegin xEnd yBegin yEnd z   
                                                   = _interpolate xBegin xEnd yBegin yEnd z 
