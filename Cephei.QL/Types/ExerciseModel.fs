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
  Base exercise class
constructor
  </summary> *)
[<AutoSerializable(true)>]
type ExerciseModel
    ( Type                                         : ICell<Exercise.Type>
    ) as this =

    inherit Model<Exercise> ()
(*
    Parameters
*)
    let _Type                                      = Type
(*
    Functions
*)
    let mutable
        _Exercise                                  = make (fun () -> new Exercise (Type.Value))
    let _date                                      (index : ICell<int>)   
                                                   = triv _Exercise (fun () -> _Exercise.Value.date(index.Value))
    let _dates                                     = triv _Exercise (fun () -> _Exercise.Value.dates())
    let _lastDate                                  = triv _Exercise (fun () -> _Exercise.Value.lastDate())
    let _type                                      = triv _Exercise (fun () -> _Exercise.Value.TYPE())
    do this.Bind(_Exercise)
(* 
    casting 
*)
    internal new () = new ExerciseModel(null)
    member internal this.Inject v = _Exercise <- v
    static member Cast (p : ICell<Exercise>) = 
        if p :? ExerciseModel then 
            p :?> ExerciseModel
        else
            let o = new ExerciseModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.Date                               index   
                                                   = _date index 
    member this.Dates                              = _dates
    member this.LastDate                           = _lastDate
    member this.Type1                              = _type
