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
type JointCalendarModel
    ( c1                                           : ICell<Calendar>
    , c2                                           : ICell<Calendar>
    , r                                            : ICell<JointCalendar.JointCalendarRule>
    ) as this =

    inherit Model<JointCalendar> ()
(*
    Parameters
*)
    let _c1                                        = c1
    let _c2                                        = c2
    let _r                                         = r
(*
    Functions
*)
    let mutable
        _JointCalendar                             = make (fun () -> new JointCalendar (c1.Value, c2.Value, r.Value))
    let _addedHolidays                             = triv _JointCalendar (fun () -> _JointCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.addHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _JointCalendar (fun () -> _JointCalendar.Value.calendar)
    let _empty                                     = triv _JointCalendar (fun () -> _JointCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isWeekend(w.Value))
    let _name                                      = triv _JointCalendar (fun () -> _JointCalendar.Value.name())
    let _removedHolidays                           = triv _JointCalendar (fun () -> _JointCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.removeHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    do this.Bind(_JointCalendar)
(* 
    casting 
*)
    internal new () = new JointCalendarModel(null,null,null)
    member internal this.Inject v = _JointCalendar <- v
    static member Cast (p : ICell<JointCalendar>) = 
        if p :? JointCalendarModel then 
            p :?> JointCalendarModel
        else
            let o = new JointCalendarModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c1                                 = _c1 
    member this.c2                                 = _c2 
    member this.r                                  = _r 
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
type JointCalendarModel1
    ( c1                                           : ICell<Calendar>
    , c2                                           : ICell<Calendar>
    , c3                                           : ICell<Calendar>
    ) as this =

    inherit Model<JointCalendar> ()
(*
    Parameters
*)
    let _c1                                        = c1
    let _c2                                        = c2
    let _c3                                        = c3
(*
    Functions
*)
    let mutable
        _JointCalendar                             = make (fun () -> new JointCalendar (c1.Value, c2.Value, c3.Value))
    let _addedHolidays                             = triv _JointCalendar (fun () -> _JointCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.addHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _JointCalendar (fun () -> _JointCalendar.Value.calendar)
    let _empty                                     = triv _JointCalendar (fun () -> _JointCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isWeekend(w.Value))
    let _name                                      = triv _JointCalendar (fun () -> _JointCalendar.Value.name())
    let _removedHolidays                           = triv _JointCalendar (fun () -> _JointCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.removeHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    do this.Bind(_JointCalendar)
(* 
    casting 
*)
    internal new () = new JointCalendarModel1(null,null,null)
    member internal this.Inject v = _JointCalendar <- v
    static member Cast (p : ICell<JointCalendar>) = 
        if p :? JointCalendarModel1 then 
            p :?> JointCalendarModel1
        else
            let o = new JointCalendarModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c1                                 = _c1 
    member this.c2                                 = _c2 
    member this.c3                                 = _c3 
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
type JointCalendarModel2
    ( c1                                           : ICell<Calendar>
    , c2                                           : ICell<Calendar>
    , c3                                           : ICell<Calendar>
    , r                                            : ICell<JointCalendar.JointCalendarRule>
    ) as this =

    inherit Model<JointCalendar> ()
(*
    Parameters
*)
    let _c1                                        = c1
    let _c2                                        = c2
    let _c3                                        = c3
    let _r                                         = r
(*
    Functions
*)
    let mutable
        _JointCalendar                             = make (fun () -> new JointCalendar (c1.Value, c2.Value, c3.Value, r.Value))
    let _addedHolidays                             = triv _JointCalendar (fun () -> _JointCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.addHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _JointCalendar (fun () -> _JointCalendar.Value.calendar)
    let _empty                                     = triv _JointCalendar (fun () -> _JointCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isWeekend(w.Value))
    let _name                                      = triv _JointCalendar (fun () -> _JointCalendar.Value.name())
    let _removedHolidays                           = triv _JointCalendar (fun () -> _JointCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.removeHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    do this.Bind(_JointCalendar)
(* 
    casting 
*)
    internal new () = new JointCalendarModel2(null,null,null,null)
    member internal this.Inject v = _JointCalendar <- v
    static member Cast (p : ICell<JointCalendar>) = 
        if p :? JointCalendarModel2 then 
            p :?> JointCalendarModel2
        else
            let o = new JointCalendarModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c1                                 = _c1 
    member this.c2                                 = _c2 
    member this.c3                                 = _c3 
    member this.r                                  = _r 
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
type JointCalendarModel3
    ( c1                                           : ICell<Calendar>
    , c2                                           : ICell<Calendar>
    , c3                                           : ICell<Calendar>
    , c4                                           : ICell<Calendar>
    , r                                            : ICell<JointCalendar.JointCalendarRule>
    ) as this =

    inherit Model<JointCalendar> ()
(*
    Parameters
*)
    let _c1                                        = c1
    let _c2                                        = c2
    let _c3                                        = c3
    let _c4                                        = c4
    let _r                                         = r
(*
    Functions
*)
    let mutable
        _JointCalendar                             = make (fun () -> new JointCalendar (c1.Value, c2.Value, c3.Value, c4.Value, r.Value))
    let _addedHolidays                             = triv _JointCalendar (fun () -> _JointCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.addHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _JointCalendar (fun () -> _JointCalendar.Value.calendar)
    let _empty                                     = triv _JointCalendar (fun () -> _JointCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isWeekend(w.Value))
    let _name                                      = triv _JointCalendar (fun () -> _JointCalendar.Value.name())
    let _removedHolidays                           = triv _JointCalendar (fun () -> _JointCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.removeHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    do this.Bind(_JointCalendar)
(* 
    casting 
*)
    internal new () = new JointCalendarModel3(null,null,null,null,null)
    member internal this.Inject v = _JointCalendar <- v
    static member Cast (p : ICell<JointCalendar>) = 
        if p :? JointCalendarModel3 then 
            p :?> JointCalendarModel3
        else
            let o = new JointCalendarModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c1                                 = _c1 
    member this.c2                                 = _c2 
    member this.c3                                 = _c3 
    member this.c4                                 = _c4 
    member this.r                                  = _r 
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
type JointCalendarModel4
    ( c1                                           : ICell<Calendar>
    , c2                                           : ICell<Calendar>
    , c3                                           : ICell<Calendar>
    , c4                                           : ICell<Calendar>
    ) as this =

    inherit Model<JointCalendar> ()
(*
    Parameters
*)
    let _c1                                        = c1
    let _c2                                        = c2
    let _c3                                        = c3
    let _c4                                        = c4
(*
    Functions
*)
    let mutable
        _JointCalendar                             = make (fun () -> new JointCalendar (c1.Value, c2.Value, c3.Value, c4.Value))
    let _addedHolidays                             = triv _JointCalendar (fun () -> _JointCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.addHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _JointCalendar (fun () -> _JointCalendar.Value.calendar)
    let _empty                                     = triv _JointCalendar (fun () -> _JointCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isWeekend(w.Value))
    let _name                                      = triv _JointCalendar (fun () -> _JointCalendar.Value.name())
    let _removedHolidays                           = triv _JointCalendar (fun () -> _JointCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.removeHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    do this.Bind(_JointCalendar)
(* 
    casting 
*)
    internal new () = new JointCalendarModel4(null,null,null,null)
    member internal this.Inject v = _JointCalendar <- v
    static member Cast (p : ICell<JointCalendar>) = 
        if p :? JointCalendarModel4 then 
            p :?> JointCalendarModel4
        else
            let o = new JointCalendarModel4 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c1                                 = _c1 
    member this.c2                                 = _c2 
    member this.c3                                 = _c3 
    member this.c4                                 = _c4 
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

! Depending on the chosen rule, this calendar has a set of business days given by either the union or the intersection of the sets of business days of the given calendars. \test the correctness of the returned results is tested by reproducing the calculations.
  </summary> *)
[<AutoSerializable(true)>]
type JointCalendarModel5
    ( c1                                           : ICell<Calendar>
    , c2                                           : ICell<Calendar>
    ) as this =

    inherit Model<JointCalendar> ()
(*
    Parameters
*)
    let _c1                                        = c1
    let _c2                                        = c2
(*
    Functions
*)
    let mutable
        _JointCalendar                             = make (fun () -> new JointCalendar (c1.Value, c2.Value))
    let _addedHolidays                             = triv _JointCalendar (fun () -> _JointCalendar.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.addHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _JointCalendar (fun () -> _JointCalendar.Value.calendar)
    let _empty                                     = triv _JointCalendar (fun () -> _JointCalendar.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.isWeekend(w.Value))
    let _name                                      = triv _JointCalendar (fun () -> _JointCalendar.Value.name())
    let _removedHolidays                           = triv _JointCalendar (fun () -> _JointCalendar.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _JointCalendar (fun () -> _JointCalendar.Value.removeHoliday(d.Value)
                                                                                    _JointCalendar.Value)
    do this.Bind(_JointCalendar)
(* 
    casting 
*)
    internal new () = new JointCalendarModel5(null,null)
    member internal this.Inject v = _JointCalendar <- v
    static member Cast (p : ICell<JointCalendar>) = 
        if p :? JointCalendarModel5 then 
            p :?> JointCalendarModel5
        else
            let o = new JointCalendarModel5 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c1                                 = _c1 
    member this.c2                                 = _c2 
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
