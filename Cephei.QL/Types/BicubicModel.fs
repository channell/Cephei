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
  bicubic-spline-interpolation factory
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type BicubicModel
    () as this =
    inherit Model<Bicubic> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Bicubic                                   = cell (fun () -> new Bicubic ())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>) (ySize : ICell<int>) (zData : ICell<Matrix>)   
                                                   = triv (fun () -> _Bicubic.Value.interpolate(xBegin.Value, size.Value, yBegin.Value, ySize.Value, zData.Value))
    do this.Bind(_Bicubic)
(* 
    casting 
*)
    
    member internal this.Inject v = _Bicubic.Value <- v
    static member Cast (p : ICell<Bicubic>) = 
        if p :? BicubicModel then 
            p :?> BicubicModel
        else
            let o = new BicubicModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Interpolate                        xBegin size yBegin ySize zData   
                                                   = _interpolate xBegin size yBegin ySize zData 
