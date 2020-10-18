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
type PriceErrorModel
    ( engine                                       : ICell<IPricingEngine>
    , vol                                          : ICell<SimpleQuote>
    , targetValue                                  : ICell<double>
    ) as this =

    inherit Model<PriceError> ()
(*
    Parameters
*)
    let _engine                                    = engine
    let _vol                                       = vol
    let _targetValue                               = targetValue
(*
    Functions
*)
    let mutable
        _PriceError                                = cell (fun () -> new PriceError (engine.Value, vol.Value, targetValue.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _PriceError.Value.value(x.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _PriceError.Value.derivative(x.Value))
    do this.Bind(_PriceError)
(* 
    casting 
*)
    internal new () = new PriceErrorModel(null,null,null)
    member internal this.Inject v = _PriceError <- v
    static member Cast (p : ICell<PriceError>) = 
        if p :? PriceErrorModel then 
            p :?> PriceErrorModel
        else
            let o = new PriceErrorModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.engine                             = _engine 
    member this.vol                                = _vol 
    member this.targetValue                        = _targetValue 
    member this.Value                              x   
                                                   = _value x 
    member this.Derivative                         x   
                                                   = _derivative x 
