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
shifted lognormal type engine

  </summary> *)
[<AutoSerializable(true)>]
type BachelierSpecModel
    () as this =
    inherit Model<BachelierSpec> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _BachelierSpec                             = cell (fun () -> new BachelierSpec ())
    let _type                                      = triv (fun () -> _BachelierSpec.Value.TYPE())
    let _value                                     (Type : ICell<Option.Type>) (strike : ICell<double>) (atmForward : ICell<double>) (stdDev : ICell<double>) (annuity : ICell<double>) (displacement : ICell<double>)   
                                                   = triv (fun () -> _BachelierSpec.Value.value(Type.Value, strike.Value, atmForward.Value, stdDev.Value, annuity.Value, displacement.Value))
    let _vega                                      (strike : ICell<double>) (atmForward : ICell<double>) (stdDev : ICell<double>) (exerciseTime : ICell<double>) (annuity : ICell<double>) (displacement : ICell<double>)   
                                                   = triv (fun () -> _BachelierSpec.Value.vega(strike.Value, atmForward.Value, stdDev.Value, exerciseTime.Value, annuity.Value, displacement.Value))
    do this.Bind(_BachelierSpec)
(* 
    casting 
*)
    
    member internal this.Inject v = _BachelierSpec.Value <- v
    static member Cast (p : ICell<BachelierSpec>) = 
        if p :? BachelierSpecModel then 
            p :?> BachelierSpecModel
        else
            let o = new BachelierSpecModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _type
    member this.Value                              Type strike atmForward stdDev annuity displacement   
                                                   = _value Type strike atmForward stdDev annuity displacement 
    member this.Vega                               strike atmForward stdDev exerciseTime annuity displacement   
                                                   = _vega strike atmForward stdDev exerciseTime annuity displacement 
