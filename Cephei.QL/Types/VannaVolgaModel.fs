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
  %VannaVolga-interpolation factory and traits

  </summary> *)
[<AutoSerializable(true)>]
type VannaVolgaModel
    ( spot                                         : ICell<double>
    , dDiscount                                    : ICell<double>
    , fDiscount                                    : ICell<double>
    , T                                            : ICell<double>
    ) as this =

    inherit Model<VannaVolga> ()
(*
    Parameters
*)
    let _spot                                      = spot
    let _dDiscount                                 = dDiscount
    let _fDiscount                                 = fDiscount
    let _T                                         = T
(*
    Functions
*)
    let _VannaVolga                                = cell (fun () -> new VannaVolga (spot.Value, dDiscount.Value, fDiscount.Value, T.Value))
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _VannaVolga.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    do this.Bind(_VannaVolga)
(* 
    casting 
*)
    internal new () = new VannaVolgaModel(null,null,null,null)
    member internal this.Inject v = _VannaVolga.Value <- v
    static member Cast (p : ICell<VannaVolga>) = 
        if p :? VannaVolgaModel then 
            p :?> VannaVolgaModel
        else
            let o = new VannaVolgaModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.spot                               = _spot 
    member this.dDiscount                          = _dDiscount 
    member this.fDiscount                          = _fDiscount 
    member this.T                                  = _T 
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
