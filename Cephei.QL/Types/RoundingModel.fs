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
type RoundingModel
    ( precision                                    : ICell<int>
    , Type                                         : ICell<Rounding.Type>
    , digit                                        : ICell<int>
    ) as this =

    inherit Model<Rounding> ()
(*
    Parameters
*)
    let _precision                                 = precision
    let _Type                                      = Type
    let _digit                                     = digit
(*
    Functions
*)
    let _Rounding                                  = cell (fun () -> new Rounding (precision.Value, Type.Value, digit.Value))
    let _Digit                                     = triv (fun () -> _Rounding.Value.Digit)
    let _getType                                   = triv (fun () -> _Rounding.Value.getType)
    let _Precision                                 = triv (fun () -> _Rounding.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _Rounding.Value.Round(value.Value))
    do this.Bind(_Rounding)

(* 
    Externally visible/bindable properties
*)
    member this.precision                          = _precision 
    member this.Type                               = _Type 
    member this.digit                              = _digit 
    member this.Digit                              = _Digit
    member this.GetType                            = _getType
    member this.Precision                          = _Precision
    member this.Round                              value   
                                                   = _Round value 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type RoundingModel1
    () as this =
    inherit Model<Rounding> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Rounding                                  = cell (fun () -> new Rounding ())
    let _Digit                                     = triv (fun () -> _Rounding.Value.Digit)
    let _getType                                   = triv (fun () -> _Rounding.Value.getType)
    let _Precision                                 = triv (fun () -> _Rounding.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _Rounding.Value.Round(value.Value))
    do this.Bind(_Rounding)

(* 
    Externally visible/bindable properties
*)
    member this.Digit                              = _Digit
    member this.GetType                            = _getType
    member this.Precision                          = _Precision
    member this.Round                              value   
                                                   = _Round value 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type RoundingModel2
    ( precision                                    : ICell<int>
    , Type                                         : ICell<Rounding.Type>
    ) as this =

    inherit Model<Rounding> ()
(*
    Parameters
*)
    let _precision                                 = precision
    let _Type                                      = Type
(*
    Functions
*)
    let _Rounding                                  = cell (fun () -> new Rounding (precision.Value, Type.Value))
    let _Digit                                     = triv (fun () -> _Rounding.Value.Digit)
    let _getType                                   = triv (fun () -> _Rounding.Value.getType)
    let _Precision                                 = triv (fun () -> _Rounding.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _Rounding.Value.Round(value.Value))
    do this.Bind(_Rounding)

(* 
    Externally visible/bindable properties
*)
    member this.precision                          = _precision 
    member this.Type                               = _Type 
    member this.Digit                              = _Digit
    member this.GetType                            = _getType
    member this.Precision                          = _Precision
    member this.Round                              value   
                                                   = _Round value 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type RoundingModel3
    ( precision                                    : ICell<int>
    ) as this =

    inherit Model<Rounding> ()
(*
    Parameters
*)
    let _precision                                 = precision
(*
    Functions
*)
    let _Rounding                                  = cell (fun () -> new Rounding (precision.Value))
    let _Digit                                     = triv (fun () -> _Rounding.Value.Digit)
    let _getType                                   = triv (fun () -> _Rounding.Value.getType)
    let _Precision                                 = triv (fun () -> _Rounding.Value.Precision)
    let _Round                                     (value : ICell<double>)   
                                                   = triv (fun () -> _Rounding.Value.Round(value.Value))
    do this.Bind(_Rounding)

(* 
    Externally visible/bindable properties
*)
    member this.precision                          = _precision 
    member this.Digit                              = _Digit
    member this.GetType                            = _getType
    member this.Precision                          = _Precision
    member this.Round                              value   
                                                   = _Round value 
