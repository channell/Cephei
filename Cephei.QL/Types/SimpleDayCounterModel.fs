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
  This day counter tries to ensure that whole-month distances are returned as a simple fraction, i.e., 1 year = 1.0, 6 months = 0.5, 3 months = 0.25 and so forth. this day counter should be used together with NullCalendar, which ensures that dates at whole-month distances share the same day of month. It is <b>not</b> guaranteed to work with any other calendar.

  </summary> *)
[<AutoSerializable(true)>]
type SimpleDayCounterModel
    () as this =
    inherit Model<SimpleDayCounter> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _SimpleDayCounter                          = cell (fun () -> new SimpleDayCounter ())
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _SimpleDayCounter.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv (fun () -> _SimpleDayCounter.Value.dayCounter)
    let _empty                                     = triv (fun () -> _SimpleDayCounter.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _SimpleDayCounter.Value.Equals(o.Value))
    let _name                                      = triv (fun () -> _SimpleDayCounter.Value.name())
    let _ToString                                  = triv (fun () -> _SimpleDayCounter.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv (fun () -> _SimpleDayCounter.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _SimpleDayCounter.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_SimpleDayCounter)
(* 
    casting 
*)
    
    member internal this.Inject v = _SimpleDayCounter.Value <- v
    static member Cast (p : ICell<SimpleDayCounter>) = 
        if p :? SimpleDayCounterModel then 
            p :?> SimpleDayCounterModel
        else
            let o = new SimpleDayCounterModel ()
            o.Inject p.Value
            o
                            

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
