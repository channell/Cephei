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
type ClosestRoundingModel
    ( precision                                    : ICell<int>
    ) as this =

    inherit Model<ClosestRounding> ()
(*
    Parameters
*)
    let _precision                                 = precision
(*
    Functions
*)
    let _ClosestRounding                           = cell (fun () -> new ClosestRounding (precision.Value))
    let _Digit                                     = triv (fun () -> _ClosestRounding.Value.Digit)
    let _getType                                   = triv (fun () -> _ClosestRounding.Value.getType)
    let _Precision                                 = triv (fun () -> _ClosestRounding.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _ClosestRounding.Value.Round(value.Value))
    do this.Bind(_ClosestRounding)
(* 
    casting 
*)
    internal new () = ClosestRoundingModel(null)
    member internal this.Inject v = _ClosestRounding.Value <- v
    static member Cast (p : ICell<ClosestRounding>) = 
        if p :? ClosestRoundingModel then 
            p :?> ClosestRoundingModel
        else
            let o = new ClosestRoundingModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.precision                          = _precision 
    member this.Digit                              = _Digit
    member this.GetType                            = _getType
    member this.Precision                          = _Precision
    member this.Round                              value   
                                                   = _Round value 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ClosestRoundingModel1
    ( precision                                    : ICell<int>
    , digit                                        : ICell<int>
    ) as this =

    inherit Model<ClosestRounding> ()
(*
    Parameters
*)
    let _precision                                 = precision
    let _digit                                     = digit
(*
    Functions
*)
    let _ClosestRounding                           = cell (fun () -> new ClosestRounding (precision.Value, digit.Value))
    let _Digit                                     = triv (fun () -> _ClosestRounding.Value.Digit)
    let _getType                                   = triv (fun () -> _ClosestRounding.Value.getType)
    let _Precision                                 = triv (fun () -> _ClosestRounding.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _ClosestRounding.Value.Round(value.Value))
    do this.Bind(_ClosestRounding)
(* 
    casting 
*)
    internal new () = ClosestRoundingModel1(null,null)
    member internal this.Inject v = _ClosestRounding.Value <- v
    static member Cast (p : ICell<ClosestRounding>) = 
        if p :? ClosestRoundingModel1 then 
            p :?> ClosestRoundingModel1
        else
            let o = new ClosestRoundingModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.precision                          = _precision 
    member this.digit                              = _digit 
    member this.Digit                              = _Digit
    member this.GetType                            = _getType
    member this.Precision                          = _Precision
    member this.Round                              value   
                                                   = _Round value 
