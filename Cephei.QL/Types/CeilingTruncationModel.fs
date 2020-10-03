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
Ceiling truncation.



  </summary> *)
[<AutoSerializable(true)>]
type CeilingTruncationModel
    ( precision                                    : ICell<int>
    , digit                                        : ICell<int>
    ) as this =

    inherit Model<CeilingTruncation> ()
(*
    Parameters
*)
    let _precision                                 = precision
    let _digit                                     = digit
(*
    Functions
*)
    let _CeilingTruncation                         = cell (fun () -> new CeilingTruncation (precision.Value, digit.Value))
    let _Digit                                     = triv (fun () -> _CeilingTruncation.Value.Digit)
    let _getType                                   = triv (fun () -> _CeilingTruncation.Value.getType)
    let _Precision                                 = triv (fun () -> _CeilingTruncation.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _CeilingTruncation.Value.Round(value.Value))
    do this.Bind(_CeilingTruncation)
(* 
    casting 
*)
    internal new () = CeilingTruncationModel(null,null)
    member internal this.Inject v = _CeilingTruncation.Value <- v
    static member Cast (p : ICell<CeilingTruncation>) = 
        if p :? CeilingTruncationModel then 
            p :?> CeilingTruncationModel
        else
            let o = new CeilingTruncationModel ()
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
(* <summary>
Ceiling truncation.



  </summary> *)
[<AutoSerializable(true)>]
type CeilingTruncationModel1
    ( precision                                    : ICell<int>
    ) as this =

    inherit Model<CeilingTruncation> ()
(*
    Parameters
*)
    let _precision                                 = precision
(*
    Functions
*)
    let _CeilingTruncation                         = cell (fun () -> new CeilingTruncation (precision.Value))
    let _Digit                                     = triv (fun () -> _CeilingTruncation.Value.Digit)
    let _getType                                   = triv (fun () -> _CeilingTruncation.Value.getType)
    let _Precision                                 = triv (fun () -> _CeilingTruncation.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _CeilingTruncation.Value.Round(value.Value))
    do this.Bind(_CeilingTruncation)
(* 
    casting 
*)
    internal new () = CeilingTruncationModel1(null)
    member internal this.Inject v = _CeilingTruncation.Value <- v
    static member Cast (p : ICell<CeilingTruncation>) = 
        if p :? CeilingTruncationModel1 then 
            p :?> CeilingTruncationModel1
        else
            let o = new CeilingTruncationModel1 ()
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
