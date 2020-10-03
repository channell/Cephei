﻿(*
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
  Forward-flat interpolation factory and traits
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type ForwardFlatModel
    () as this =
    inherit Model<ForwardFlat> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ForwardFlat                               = cell (fun () -> new ForwardFlat ())
    let _global                                    = triv (fun () -> _ForwardFlat.Value.GLOBAL())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _ForwardFlat.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    let _requiredPoints                            = triv (fun () -> _ForwardFlat.Value.requiredPoints)
    do this.Bind(_ForwardFlat)
(* 
    casting 
*)
    
    member internal this.Inject v = _ForwardFlat.Value <- v
    static member Cast (p : ICell<ForwardFlat>) = 
        if p :? ForwardFlatModel then 
            p :?> ForwardFlatModel
        else
            let o = new ForwardFlatModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Global                             = _global
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
    member this.RequiredPoints                     = _requiredPoints
