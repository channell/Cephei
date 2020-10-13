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
  A European option can only be exercised at one (expiry) date.

  </summary> *)
[<AutoSerializable(true)>]
type EuropeanExerciseModel
    ( date                                         : ICell<Date>
    ) as this =

    inherit Model<EuropeanExercise> ()
(*
    Parameters
*)
    let _date                                      = date
(*
    Functions
*)
    let _EuropeanExercise                          = cell (fun () -> new EuropeanExercise (date.Value))
    let _date                                      (index : ICell<int>)   
                                                   = triv (fun () -> _EuropeanExercise.Value.date(index.Value))
    let _dates                                     = triv (fun () -> _EuropeanExercise.Value.dates())
    let _lastDate                                  = triv (fun () -> _EuropeanExercise.Value.lastDate())
    let _type                                      = triv (fun () -> _EuropeanExercise.Value.TYPE())
    do this.Bind(_EuropeanExercise)
(* 
    casting 
*)
    internal new () = new EuropeanExerciseModel(null)
    member internal this.Inject v = _EuropeanExercise.Value <- v
    static member Cast (p : ICell<EuropeanExercise>) = 
        if p :? EuropeanExerciseModel then 
            p :?> EuropeanExerciseModel
        else
            let o = new EuropeanExerciseModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.date                               = _date 
    member this.Date                               index   
                                                   = _date index 
    member this.Dates                              = _dates
    member this.LastDate                           = _lastDate
    member this.Type                               = _type
