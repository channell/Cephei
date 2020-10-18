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
type doubleExponentiallyWeightedModel
    () as this =
    inherit Model<doubleExponentiallyWeighted> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _doubleExponentiallyWeighted               = cell (fun () -> new doubleExponentiallyWeighted ())
    let _weight1LargeX                             (x : ICell<double>)   
                                                   = cell (fun () -> _doubleExponentiallyWeighted.Value.weight1LargeX(x.Value))
    let _weight2LargeX                             (x : ICell<double>)   
                                                   = cell (fun () -> _doubleExponentiallyWeighted.Value.weight2LargeX(x.Value))
    let _weightSmallX                              (x : ICell<double>)   
                                                   = cell (fun () -> _doubleExponentiallyWeighted.Value.weightSmallX(x.Value))
    do this.Bind(_doubleExponentiallyWeighted)
(* 
    casting 
*)
    
    member internal this.Inject v = _doubleExponentiallyWeighted <- v
    static member Cast (p : ICell<doubleExponentiallyWeighted>) = 
        if p :? doubleExponentiallyWeightedModel then 
            p :?> doubleExponentiallyWeightedModel
        else
            let o = new doubleExponentiallyWeightedModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<doubleExponentiallyWeighted>) = 
        if p :? doubleExponentiallyWeightedModel then 
            p :?> doubleExponentiallyWeightedModel
        else
            let o = new doubleExponentiallyWeightedModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Weight1LargeX                      x   
                                                   = _weight1LargeX x 
    member this.Weight2LargeX                      x   
                                                   = _weight2LargeX x 
    member this.WeightSmallX                       x   
                                                   = _weightSmallX x 
