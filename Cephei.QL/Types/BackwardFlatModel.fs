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
  Backward-flat interpolation factory and traits
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type BackwardFlatModel
    () as this =
    inherit Model<BackwardFlat> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _BackwardFlat                              = cell (fun () -> new BackwardFlat ())
    let _global                                    = triv (fun () -> _BackwardFlat.Value.GLOBAL())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _BackwardFlat.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    let _requiredPoints                            = triv (fun () -> _BackwardFlat.Value.requiredPoints)
    do this.Bind(_BackwardFlat)
(* 
    casting 
*)
    
    member internal this.Inject v = _BackwardFlat <- v
    static member Cast (p : ICell<BackwardFlat>) = 
        if p :? BackwardFlatModel then 
            p :?> BackwardFlatModel
        else
            let o = new BackwardFlatModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Global                             = _global
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
    member this.RequiredPoints                     = _requiredPoints
