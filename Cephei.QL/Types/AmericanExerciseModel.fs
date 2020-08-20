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
  An American option can be exercised at any time between two predefined dates; the first date might be omitted, in which case the option can be exercised at any time before the expiry.  check that everywhere the American condition is applied from earliestDate and not earlier

  </summary> *)
[<AutoSerializable(true)>]
type AmericanExerciseModel
    ( latest                                       : ICell<Date>
    , payoffAtExpiry                               : ICell<bool>
    ) as this =

    inherit Model<AmericanExercise> ()
(*
    Parameters
*)
    let _latest                                    = latest
    let _payoffAtExpiry                            = payoffAtExpiry
(*
    Functions
*)
    let _AmericanExercise                          = cell (fun () -> new AmericanExercise (latest.Value, payoffAtExpiry.Value))
    let _payoffAtExpiry                            = cell (fun () -> _AmericanExercise.Value.payoffAtExpiry())
    let _date                                      (index : ICell<int>)   
                                                   = cell (fun () -> _AmericanExercise.Value.date(index.Value))
    let _dates                                     = cell (fun () -> _AmericanExercise.Value.dates())
    let _lastDate                                  = cell (fun () -> _AmericanExercise.Value.lastDate())
    let _type                                      = cell (fun () -> _AmericanExercise.Value.TYPE())
    do this.Bind(_AmericanExercise)

(* 
    Externally visible/bindable properties
*)
    member this.latest                             = _latest 
    member this.payoffAtExpiry                     = _payoffAtExpiry 
    member this.PayoffAtExpiry                     = _payoffAtExpiry
    member this.Date                               index   
                                                   = _date index 
    member this.Dates                              = _dates
    member this.LastDate                           = _lastDate
    member this.Type                               = _type
(* <summary>
  An American option can be exercised at any time between two predefined dates; the first date might be omitted, in which case the option can be exercised at any time before the expiry.  check that everywhere the American condition is applied from earliestDate and not earlier

  </summary> *)
[<AutoSerializable(true)>]
type AmericanExerciseModel1
    ( earliestDate                                 : ICell<Date>
    , latestDate                                   : ICell<Date>
    , payoffAtExpiry                               : ICell<bool>
    ) as this =

    inherit Model<AmericanExercise> ()
(*
    Parameters
*)
    let _earliestDate                              = earliestDate
    let _latestDate                                = latestDate
    let _payoffAtExpiry                            = payoffAtExpiry
(*
    Functions
*)
    let _AmericanExercise                          = cell (fun () -> new AmericanExercise (earliestDate.Value, latestDate.Value, payoffAtExpiry.Value))
    let _payoffAtExpiry                            = cell (fun () -> _AmericanExercise.Value.payoffAtExpiry())
    let _date                                      (index : ICell<int>)   
                                                   = cell (fun () -> _AmericanExercise.Value.date(index.Value))
    let _dates                                     = cell (fun () -> _AmericanExercise.Value.dates())
    let _lastDate                                  = cell (fun () -> _AmericanExercise.Value.lastDate())
    let _type                                      = cell (fun () -> _AmericanExercise.Value.TYPE())
    do this.Bind(_AmericanExercise)

(* 
    Externally visible/bindable properties
*)
    member this.earliestDate                       = _earliestDate 
    member this.latestDate                         = _latestDate 
    member this.payoffAtExpiry                     = _payoffAtExpiry 
    member this.PayoffAtExpiry                     = _payoffAtExpiry
    member this.Date                               index   
                                                   = _date index 
    member this.Dates                              = _dates
    member this.LastDate                           = _lastDate
    member this.Type                               = _type
