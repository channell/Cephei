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
type ScheduleModel
    ( effectiveDate                                : ICell<Date>
    , terminationDate                              : ICell<Date>
    , tenor                                        : ICell<Period>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , terminationDateConvention                    : ICell<BusinessDayConvention>
    , rule                                         : ICell<DateGeneration.Rule>
    , endOfMonth                                   : ICell<bool>
    , firstDate                                    : ICell<Date>
    , nextToLastDate                               : ICell<Date>
    ) as this =

    inherit Model<Schedule> ()
(*
    Parameters
*)
    let _effectiveDate                             = effectiveDate
    let _terminationDate                           = terminationDate
    let _tenor                                     = tenor
    let _calendar                                  = calendar
    let _convention                                = convention
    let _terminationDateConvention                 = terminationDateConvention
    let _rule                                      = rule
    let _endOfMonth                                = endOfMonth
    let _firstDate                                 = firstDate
    let _nextToLastDate                            = nextToLastDate
(*
    Functions
*)
    let _Schedule                                  = cell (fun () -> new Schedule (effectiveDate.Value, terminationDate.Value, tenor.Value, calendar.Value, convention.Value, terminationDateConvention.Value, rule.Value, endOfMonth.Value, firstDate.Value, nextToLastDate.Value))
    let _at                                        (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.at(i.Value))
    let _businessDayConvention                     = triv (fun () -> _Schedule.Value.businessDayConvention())
    let _calendar                                  = triv (fun () -> _Schedule.Value.calendar())
    let _Count                                     = triv (fun () -> _Schedule.Value.Count)
    let _date                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.date(i.Value))
    let _dates                                     = triv (fun () -> _Schedule.Value.dates())
    let _empty                                     = triv (fun () -> _Schedule.Value.empty())
    let _endDate                                   = triv (fun () -> _Schedule.Value.endDate())
    let _endOfMonth                                = triv (fun () -> _Schedule.Value.endOfMonth())
    let _isRegular                                 = triv (fun () -> _Schedule.Value.isRegular())
    let _isRegular1                                (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.isRegular(i.Value))
    let _nextDate                                  (d : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.nextDate(d.Value))
    let _previousDate                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.previousDate(d.Value))
    let _rule                                      = triv (fun () -> _Schedule.Value.rule())
    let _size                                      = triv (fun () -> _Schedule.Value.size())
    let _startDate                                 = triv (fun () -> _Schedule.Value.startDate())
    let _tenor                                     = triv (fun () -> _Schedule.Value.tenor())
    let _terminationDateBusinessDayConvention      = triv (fun () -> _Schedule.Value.terminationDateBusinessDayConvention())
    let _this                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.[i.Value])
    let _until                                     (truncationDate : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.until(truncationDate.Value))
    do this.Bind(_Schedule)
(* 
    casting 
*)
    internal new () = ScheduleModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _Schedule.Value <- v
    static member Cast (p : ICell<Schedule>) = 
        if p :? ScheduleModel then 
            p :?> ScheduleModel
        else
            let o = new ScheduleModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.effectiveDate                      = _effectiveDate 
    member this.terminationDate                    = _terminationDate 
    member this.tenor                              = _tenor 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.terminationDateConvention          = _terminationDateConvention 
    member this.rule                               = _rule 
    member this.endOfMonth                         = _endOfMonth 
    member this.firstDate                          = _firstDate 
    member this.nextToLastDate                     = _nextToLastDate 
    member this.At                                 i   
                                                   = _at i 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Calendar                           = _calendar
    member this.Count                              = _Count
    member this.Date                               i   
                                                   = _date i 
    member this.Dates                              = _dates
    member this.Empty                              = _empty
    member this.EndDate                            = _endDate
    member this.EndOfMonth                         = _endOfMonth
    member this.IsRegular                          = _isRegular
    member this.IsRegular1                         i   
                                                   = _isRegular1 i 
    member this.NextDate                           d   
                                                   = _nextDate d 
    member this.PreviousDate                       d   
                                                   = _previousDate d 
    member this.Rule                               = _rule
    member this.Size                               = _size
    member this.StartDate                          = _startDate
    member this.Tenor                              = _tenor
    member this.TerminationDateBusinessDayConvention = _terminationDateBusinessDayConvention
    member this.This                               i   
                                                   = _this i 
    member this.Until                              truncationDate   
                                                   = _until truncationDate 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ScheduleModel1
    ( dates                                        : ICell<Generic.List<Date>>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , terminationDateConvention                    : ICell<Nullable<BusinessDayConvention>>
    , tenor                                        : ICell<Period>
    , rule                                         : ICell<Nullable<DateGeneration.Rule>>
    , endOfMonth                                   : ICell<Nullable<bool>>
    , isRegular                                    : ICell<Generic.IList<bool>>
    ) as this =

    inherit Model<Schedule> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _calendar                                  = calendar
    let _convention                                = convention
    let _terminationDateConvention                 = terminationDateConvention
    let _tenor                                     = tenor
    let _rule                                      = rule
    let _endOfMonth                                = endOfMonth
    let _isRegular                                 = isRegular
(*
    Functions
*)
    let _Schedule                                  = cell (fun () -> new Schedule (dates.Value, calendar.Value, convention.Value, terminationDateConvention.Value, tenor.Value, rule.Value, endOfMonth.Value, isRegular.Value))
    let _at                                        (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.at(i.Value))
    let _businessDayConvention                     = triv (fun () -> _Schedule.Value.businessDayConvention())
    let _calendar                                  = triv (fun () -> _Schedule.Value.calendar())
    let _Count                                     = triv (fun () -> _Schedule.Value.Count)
    let _date                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.date(i.Value))
    let _dates                                     = triv (fun () -> _Schedule.Value.dates())
    let _empty                                     = triv (fun () -> _Schedule.Value.empty())
    let _endDate                                   = triv (fun () -> _Schedule.Value.endDate())
    let _endOfMonth                                = triv (fun () -> _Schedule.Value.endOfMonth())
    let _isRegular                                 = triv (fun () -> _Schedule.Value.isRegular())
    let _isRegular1                                (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.isRegular(i.Value))
    let _nextDate                                  (d : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.nextDate(d.Value))
    let _previousDate                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.previousDate(d.Value))
    let _rule                                      = triv (fun () -> _Schedule.Value.rule())
    let _size                                      = triv (fun () -> _Schedule.Value.size())
    let _startDate                                 = triv (fun () -> _Schedule.Value.startDate())
    let _tenor                                     = triv (fun () -> _Schedule.Value.tenor())
    let _terminationDateBusinessDayConvention      = triv (fun () -> _Schedule.Value.terminationDateBusinessDayConvention())
    let _this                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.[i.Value])
    let _until                                     (truncationDate : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.until(truncationDate.Value))
    do this.Bind(_Schedule)
(* 
    casting 
*)
    internal new () = ScheduleModel1(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _Schedule.Value <- v
    static member Cast (p : ICell<Schedule>) = 
        if p :? ScheduleModel1 then 
            p :?> ScheduleModel1
        else
            let o = new ScheduleModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.terminationDateConvention          = _terminationDateConvention 
    member this.tenor                              = _tenor 
    member this.rule                               = _rule 
    member this.endOfMonth                         = _endOfMonth 
    member this.isRegular                          = _isRegular 
    member this.At                                 i   
                                                   = _at i 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Calendar                           = _calendar
    member this.Count                              = _Count
    member this.Date                               i   
                                                   = _date i 
    member this.Dates                              = _dates
    member this.Empty                              = _empty
    member this.EndDate                            = _endDate
    member this.EndOfMonth                         = _endOfMonth
    member this.IsRegular                          = _isRegular
    member this.IsRegular1                         i   
                                                   = _isRegular1 i 
    member this.NextDate                           d   
                                                   = _nextDate d 
    member this.PreviousDate                       d   
                                                   = _previousDate d 
    member this.Rule                               = _rule
    member this.Size                               = _size
    member this.StartDate                          = _startDate
    member this.Tenor                              = _tenor
    member this.TerminationDateBusinessDayConvention = _terminationDateBusinessDayConvention
    member this.This                               i   
                                                   = _this i 
    member this.Until                              truncationDate   
                                                   = _until truncationDate 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ScheduleModel2
    () as this =
    inherit Model<Schedule> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Schedule                                  = cell (fun () -> new Schedule ())
    let _at                                        (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.at(i.Value))
    let _businessDayConvention                     = triv (fun () -> _Schedule.Value.businessDayConvention())
    let _calendar                                  = triv (fun () -> _Schedule.Value.calendar())
    let _Count                                     = triv (fun () -> _Schedule.Value.Count)
    let _date                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.date(i.Value))
    let _dates                                     = triv (fun () -> _Schedule.Value.dates())
    let _empty                                     = triv (fun () -> _Schedule.Value.empty())
    let _endDate                                   = triv (fun () -> _Schedule.Value.endDate())
    let _endOfMonth                                = triv (fun () -> _Schedule.Value.endOfMonth())
    let _isRegular                                 = triv (fun () -> _Schedule.Value.isRegular())
    let _isRegular1                                (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.isRegular(i.Value))
    let _nextDate                                  (d : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.nextDate(d.Value))
    let _previousDate                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.previousDate(d.Value))
    let _rule                                      = triv (fun () -> _Schedule.Value.rule())
    let _size                                      = triv (fun () -> _Schedule.Value.size())
    let _startDate                                 = triv (fun () -> _Schedule.Value.startDate())
    let _tenor                                     = triv (fun () -> _Schedule.Value.tenor())
    let _terminationDateBusinessDayConvention      = triv (fun () -> _Schedule.Value.terminationDateBusinessDayConvention())
    let _this                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Schedule.Value.[i.Value])
    let _until                                     (truncationDate : ICell<Date>)   
                                                   = triv (fun () -> _Schedule.Value.until(truncationDate.Value))
    do this.Bind(_Schedule)
(* 
    casting 
*)
    
    member internal this.Inject v = _Schedule.Value <- v
    static member Cast (p : ICell<Schedule>) = 
        if p :? ScheduleModel2 then 
            p :?> ScheduleModel2
        else
            let o = new ScheduleModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.At                                 i   
                                                   = _at i 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Calendar                           = _calendar
    member this.Count                              = _Count
    member this.Date                               i   
                                                   = _date i 
    member this.Dates                              = _dates
    member this.Empty                              = _empty
    member this.EndDate                            = _endDate
    member this.EndOfMonth                         = _endOfMonth
    member this.IsRegular                          = _isRegular
    member this.IsRegular1                         i   
                                                   = _isRegular1 i 
    member this.NextDate                           d   
                                                   = _nextDate d 
    member this.PreviousDate                       d   
                                                   = _previousDate d 
    member this.Rule                               = _rule
    member this.Size                               = _size
    member this.StartDate                          = _startDate
    member this.Tenor                              = _tenor
    member this.TerminationDateBusinessDayConvention = _terminationDateBusinessDayConvention
    member this.This                               i   
                                                   = _this i 
    member this.Until                              truncationDate   
                                                   = _until truncationDate 
