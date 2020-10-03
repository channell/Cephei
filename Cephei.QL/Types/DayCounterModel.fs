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
This class provides methods for determining the length of a time period according to given market convention, both as a number of days and as a year fraction.

  </summary> *)
[<AutoSerializable(true)>]
type DayCounterModel
    ( d                                            : ICell<DayCounter>
    ) as this =

    inherit Model<DayCounter> ()
(*
    Parameters
*)
    let _d                                         = d
(*
    Functions
*)
    let _DayCounter                                = cell (fun () -> new DayCounter (d.Value))
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _DayCounter.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv (fun () -> _DayCounter.Value.dayCounter)
    let _empty                                     = triv (fun () -> _DayCounter.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _DayCounter.Value.Equals(o.Value))
    let _name                                      = triv (fun () -> _DayCounter.Value.name())
    let _ToString                                  = triv (fun () -> _DayCounter.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv (fun () -> _DayCounter.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _DayCounter.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_DayCounter)
(* 
    casting 
*)
    internal new () = DayCounterModel(null)
    member internal this.Inject v = _DayCounter.Value <- v
    static member Cast (p : ICell<DayCounter>) = 
        if p :? DayCounterModel then 
            p :?> DayCounterModel
        else
            let o = new DayCounterModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
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
This class provides methods for determining the length of a time period according to given market convention, both as a number of days and as a year fraction.
! The default constructor returns a day counter with a null implementation, which is therefore unusable except as a placeholder.
  </summary> *)
[<AutoSerializable(true)>]
type DayCounterModel1
    () as this =
    inherit Model<DayCounter> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _DayCounter                                = cell (fun () -> new DayCounter ())
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _DayCounter.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv (fun () -> _DayCounter.Value.dayCounter)
    let _empty                                     = triv (fun () -> _DayCounter.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _DayCounter.Value.Equals(o.Value))
    let _name                                      = triv (fun () -> _DayCounter.Value.name())
    let _ToString                                  = triv (fun () -> _DayCounter.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv (fun () -> _DayCounter.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _DayCounter.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_DayCounter)
(* 
    casting 
*)
    
    member internal this.Inject v = _DayCounter.Value <- v
    static member Cast (p : ICell<DayCounter>) = 
        if p :? DayCounterModel1 then 
            p :?> DayCounterModel1
        else
            let o = new DayCounterModel1 ()
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
