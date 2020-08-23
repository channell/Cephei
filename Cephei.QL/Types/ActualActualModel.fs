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
type ActualActualModel
    () as this =
    inherit Model<ActualActual> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ActualActual                              = cell (fun () -> new ActualActual ())
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _ActualActual.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv (fun () -> _ActualActual.Value.dayCounter)
    let _empty                                     = triv (fun () -> _ActualActual.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _ActualActual.Value.Equals(o.Value))
    let _name                                      = triv (fun () -> _ActualActual.Value.name())
    let _ToString                                  = triv (fun () -> _ActualActual.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv (fun () -> _ActualActual.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _ActualActual.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_ActualActual)

(* 
    Externally visible/bindable properties
*)
    member this.DayCount                           d1 d2   
                                                   = _dayCount d1 d2 
    member this.DayCounter                         = _dayCounter
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Name                               = _name
    member this.ToString                           = _ToString
    member this.YearFraction                       d1 d2 refPeriodStart refPeriodEnd   
                                                   = _yearFraction d1 d2 refPeriodStart refPeriodEnd 
    member this.YearFraction1                      d1 d2   
                                                   = _yearFraction1 d1 d2 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ActualActualModel1
    ( c                                            : ICell<ActualActual.Convention>
    , schedule                                     : ICell<Schedule>
    ) as this =

    inherit Model<ActualActual> ()
(*
    Parameters
*)
    let _c                                         = c
    let _schedule                                  = schedule
(*
    Functions
*)
    let _ActualActual                              = cell (fun () -> new ActualActual (c.Value, schedule.Value))
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _ActualActual.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv (fun () -> _ActualActual.Value.dayCounter)
    let _empty                                     = triv (fun () -> _ActualActual.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _ActualActual.Value.Equals(o.Value))
    let _name                                      = triv (fun () -> _ActualActual.Value.name())
    let _ToString                                  = triv (fun () -> _ActualActual.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv (fun () -> _ActualActual.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _ActualActual.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_ActualActual)

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.schedule                           = _schedule 
    member this.DayCount                           d1 d2   
                                                   = _dayCount d1 d2 
    member this.DayCounter                         = _dayCounter
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Name                               = _name
    member this.ToString                           = _ToString
    member this.YearFraction                       d1 d2 refPeriodStart refPeriodEnd   
                                                   = _yearFraction d1 d2 refPeriodStart refPeriodEnd 
    member this.YearFraction1                      d1 d2   
                                                   = _yearFraction1 d1 d2 
