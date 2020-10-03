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
  Public holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Ascension Thursday</li>
<li>Whit Monday</li>
<li>Corpus Christi</li>
<li>Labour Day, May 1st</li>
<li>National Day, October 3rd</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Boxing Day, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Frankfurt Stock exchange (data from http://deutsche-boerse.com/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Xetra exchange (data from http://deutsche-boerse.com/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Eurex exchange (data from http://www.eurexchange.com/index.html):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Euwax exchange (data from http://www.boerse-stuttgart.de):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Whit Monday</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  calendars  the correctness of the returned results is tested against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type GermanyModel
    ( m                                            : ICell<Germany.Market>
    ) as this =

    inherit Model<Germany> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let _Germany                                   = cell (fun () -> new Germany (m.Value))
    let _addedHolidays                             = triv (fun () -> _Germany.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.addHoliday(d.Value)
                                                                     _Germany.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _Germany.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Germany.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Germany.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _Germany.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _Germany.Value.calendar)
    let _empty                                     = triv (fun () -> _Germany.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Germany.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _Germany.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _Germany.Value.name())
    let _removedHolidays                           = triv (fun () -> _Germany.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.removeHoliday(d.Value)
                                                                     _Germany.Value)
    do this.Bind(_Germany)
(* 
    casting 
*)
    internal new () = GermanyModel(null)
    member internal this.Inject v = _Germany.Value <- v
    static member Cast (p : ICell<Germany>) = 
        if p :? GermanyModel then 
            p :?> GermanyModel
        else
            let o = new GermanyModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.m                                  = _m 
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
  Public holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Ascension Thursday</li>
<li>Whit Monday</li>
<li>Corpus Christi</li>
<li>Labour Day, May 1st</li>
<li>National Day, October 3rd</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Boxing Day, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Frankfurt Stock exchange (data from http://deutsche-boerse.com/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Xetra exchange (data from http://deutsche-boerse.com/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Eurex exchange (data from http://www.eurexchange.com/index.html):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  Holidays for the Euwax exchange (data from http://www.boerse-stuttgart.de):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Good Friday</li>
<li>Easter Monday</li>
<li>Labour Day, May 1st</li>
<li>Whit Monday</li>
<li>Christmas' Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Christmas Holiday, December 26th</li>
<li>New Year's Eve, December 31st</li>
</ul>  calendars  the correctness of the returned results is tested against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type GermanyModel1
    () as this =
    inherit Model<Germany> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Germany                                   = cell (fun () -> new Germany ())
    let _addedHolidays                             = triv (fun () -> _Germany.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.addHoliday(d.Value)
                                                                     _Germany.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _Germany.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Germany.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Germany.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _Germany.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _Germany.Value.calendar)
    let _empty                                     = triv (fun () -> _Germany.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Germany.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _Germany.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _Germany.Value.name())
    let _removedHolidays                           = triv (fun () -> _Germany.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Germany.Value.removeHoliday(d.Value)
                                                                     _Germany.Value)
    do this.Bind(_Germany)
(* 
    casting 
*)
    
    member internal this.Inject v = _Germany.Value <- v
    static member Cast (p : ICell<Germany>) = 
        if p :? GermanyModel1 then 
            p :?> GermanyModel1
        else
            let o = new GermanyModel1 ()
            o.Inject p.Value
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
