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
  the correctness of the returned value is tested by checking it against known good results.

  </summary> *)
[<AutoSerializable(true)>]
type InverseCumulativePoissonModel
    () as this =
    inherit Model<InverseCumulativePoisson> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _InverseCumulativePoisson                  = make (fun () -> new InverseCumulativePoisson ())
    let _value                                     (x : ICell<double>)   
                                                   = triv _InverseCumulativePoisson (fun () -> _InverseCumulativePoisson.Value.value(x.Value))
    do this.Bind(_InverseCumulativePoisson)
(* 
    casting 
*)
    
    member internal this.Inject v = _InverseCumulativePoisson <- v
    static member Cast (p : ICell<InverseCumulativePoisson>) = 
        if p :? InverseCumulativePoissonModel then 
            p :?> InverseCumulativePoissonModel
        else
            let o = new InverseCumulativePoissonModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Value                              x   
                                                   = _value x 
(* <summary>
  the correctness of the returned value is tested by checking it against known good results.

  </summary> *)
[<AutoSerializable(true)>]
type InverseCumulativePoissonModel1
    ( lambda                                       : ICell<double>
    ) as this =

    inherit Model<InverseCumulativePoisson> ()
(*
    Parameters
*)
    let _lambda                                    = lambda
(*
    Functions
*)
    let mutable
        _InverseCumulativePoisson                  = make (fun () -> new InverseCumulativePoisson (lambda.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _InverseCumulativePoisson (fun () -> _InverseCumulativePoisson.Value.value(x.Value))
    do this.Bind(_InverseCumulativePoisson)
(* 
    casting 
*)
    internal new () = new InverseCumulativePoissonModel1(null)
    member internal this.Inject v = _InverseCumulativePoisson <- v
    static member Cast (p : ICell<InverseCumulativePoisson>) = 
        if p :? InverseCumulativePoissonModel1 then 
            p :?> InverseCumulativePoissonModel1
        else
            let o = new InverseCumulativePoissonModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.lambda                             = _lambda 
    member this.Value                              x   
                                                   = _value x 
