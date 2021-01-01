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
  bilinear-interpolation factory
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type BilinearModel
    () as this =
    inherit Model<Bilinear> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Bilinear                                  = make (fun () -> new Bilinear ())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (xSize : ICell<int>) (yBegin : ICell<Generic.List<double>>) (ySize : ICell<int>) (zData : ICell<Matrix>)   
                                                   = triv _Bilinear (fun () -> _Bilinear.Value.interpolate(xBegin.Value, xSize.Value, yBegin.Value, ySize.Value, zData.Value))
    do this.Bind(_Bilinear)
(* 
    casting 
*)
    
    member internal this.Inject v = _Bilinear <- v
    static member Cast (p : ICell<Bilinear>) = 
        if p :? BilinearModel then 
            p :?> BilinearModel
        else
            let o = new BilinearModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Interpolate                        xBegin xSize yBegin ySize zData   
                                                   = _interpolate xBegin xSize yBegin ySize zData 
