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
  The payoff can be at exercise (the default) or at expiry

  </summary> *)
[<AutoSerializable(true)>]
type EarlyExerciseModel
    ( Type                                         : ICell<Exercise.Type>
    , payoffAtExpiry                               : ICell<bool>
    ) as this =

    inherit Model<EarlyExercise> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _payoffAtExpiry                            = payoffAtExpiry
(*
    Functions
*)
    let _EarlyExercise                             = cell (fun () -> new EarlyExercise (Type.Value, payoffAtExpiry.Value))
    let _payoffAtExpiry                            = triv (fun () -> _EarlyExercise.Value.payoffAtExpiry())
    let _date                                      (index : ICell<int>)   
                                                   = triv (fun () -> _EarlyExercise.Value.date(index.Value))
    let _dates                                     = triv (fun () -> _EarlyExercise.Value.dates())
    let _lastDate                                  = triv (fun () -> _EarlyExercise.Value.lastDate())
    let _type                                      = triv (fun () -> _EarlyExercise.Value.TYPE())
    do this.Bind(_EarlyExercise)
(* 
    casting 
*)
    internal new () = new EarlyExerciseModel(null,null)
    member internal this.Inject v = _EarlyExercise.Value <- v
    static member Cast (p : ICell<EarlyExercise>) = 
        if p :? EarlyExerciseModel then 
            p :?> EarlyExerciseModel
        else
            let o = new EarlyExerciseModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.payoffAtExpiry                     = _payoffAtExpiry 
    member this.PayoffAtExpiry                     = _payoffAtExpiry
    member this.Date                               index   
                                                   = _date index 
    member this.Dates                              = _dates
    member this.LastDate                           = _lastDate
    member this.Type1                              = _type
