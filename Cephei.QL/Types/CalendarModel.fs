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

! The default constructor returns a calendar with a null implementation, which is therefore unusable except as a placeholder.
  </summary> *)
[<AutoSerializable(true)>]
type CalendarModel
    () as this =
    inherit Model<Calendar> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Calendar                                  = make (fun () -> new Calendar ())
    let _addedHolidays                             = triv _Calendar (fun () -> _Calendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.addHoliday(d.Value)
                                                                               _Calendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _Calendar (fun () -> _Calendar.Value.calendar)
    let _empty                                     = triv _Calendar (fun () -> _Calendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isWeekend(w.Value))
    let _name                                      = triv _Calendar (fun () -> _Calendar.Value.name())
    let _removedHolidays                           = triv _Calendar (fun () -> _Calendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.removeHoliday(d.Value)
                                                                               _Calendar.Value)
    do this.Bind(_Calendar)
(* 
    casting 
*)
    
    member internal this.Inject v = _Calendar <- v
    static member Cast (p : ICell<Calendar>) = 
        if p :? CalendarModel then 
            p :?> CalendarModel
        else
            let o = new CalendarModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.AddedHolidays                      = _addedHolidays
    member this.AddHoliday                         d   
                                                   = _addHoliday d 
    member this.Adjust                             d c   
                                                   = _adjust d c 
    member this.Advance                            d p c endOfMonth   
                                                   = _advance d p c endOfMonth 
    member this.Advance1                           d n unit c endOfMonth   
                                                   = _advance1 d n unit c endOfMonth 
    member this.BusinessDaysBetween                from To includeFirst includeLast   
                                                   = _businessDaysBetween from To includeFirst includeLast 
    member this.Calendar                           = _calendar
    member this.Empty                              = _empty
    member this.EndOfMonth                         d   
                                                   = _endOfMonth d 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.IsBusinessDay                      d   
                                                   = _isBusinessDay d 
    member this.IsEndOfMonth                       d   
                                                   = _isEndOfMonth d 
    member this.IsHoliday                          d   
                                                   = _isHoliday d 
    member this.IsWeekend                          w   
                                                   = _isWeekend w 
    member this.Name                               = _name
    member this.RemovedHolidays                    = _removedHolidays
    member this.RemoveHoliday                      d   
                                                   = _removeHoliday d 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type CalendarModel1
    ( c                                            : ICell<Calendar>
    ) as this =

    inherit Model<Calendar> ()
(*
    Parameters
*)
    let _c                                         = c
(*
    Functions
*)
    let mutable
        _Calendar                                  = make (fun () -> new Calendar (c.Value))
    let _addedHolidays                             = triv _Calendar (fun () -> _Calendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.addHoliday(d.Value)
                                                                               _Calendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _Calendar (fun () -> _Calendar.Value.calendar)
    let _empty                                     = triv _Calendar (fun () -> _Calendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.isWeekend(w.Value))
    let _name                                      = triv _Calendar (fun () -> _Calendar.Value.name())
    let _removedHolidays                           = triv _Calendar (fun () -> _Calendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _Calendar (fun () -> _Calendar.Value.removeHoliday(d.Value)
                                                                               _Calendar.Value)
    do this.Bind(_Calendar)
(* 
    casting 
*)
    internal new () = new CalendarModel1(null)
    member internal this.Inject v = _Calendar <- v
    static member Cast (p : ICell<Calendar>) = 
        if p :? CalendarModel1 then 
            p :?> CalendarModel1
        else
            let o = new CalendarModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.AddedHolidays                      = _addedHolidays
    member this.AddHoliday                         d   
                                                   = _addHoliday d 
    member this.Adjust                             d c   
                                                   = _adjust d c 
    member this.Advance                            d p c endOfMonth   
                                                   = _advance d p c endOfMonth 
    member this.Advance1                           d n unit c endOfMonth   
                                                   = _advance1 d n unit c endOfMonth 
    member this.BusinessDaysBetween                from To includeFirst includeLast   
                                                   = _businessDaysBetween from To includeFirst includeLast 
    member this.Calendar                           = _calendar
    member this.Empty                              = _empty
    member this.EndOfMonth                         d   
                                                   = _endOfMonth d 
    member this.Equals                             o   
                                                   = _Equals o 
    member this.IsBusinessDay                      d   
                                                   = _isBusinessDay d 
    member this.IsEndOfMonth                       d   
                                                   = _isEndOfMonth d 
    member this.IsHoliday                          d   
                                                   = _isHoliday d 
    member this.IsWeekend                          w   
                                                   = _isWeekend w 
    member this.Name                               = _name
    member this.RemovedHolidays                    = _removedHolidays
    member this.RemoveHoliday                      d   
                                                   = _removeHoliday d 
