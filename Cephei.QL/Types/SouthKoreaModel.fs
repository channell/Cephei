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
<li>Independence Day, March 1st</li>
<li>Arbour Day, April 5th (until 2005)</li>
<li>Labour Day, May 1st</li>
<li>Children's Day, May 5th</li>
<li>Memorial Day, June 6th</li>
<li>Constitution Day, July 17th (until 2007)</li>
<li>Liberation Day, August 15th</li>
<li>National Fondation Day, October 3th</li>
<li>Christmas Day, December 25th</li>
</ul>  Other holidays for which no rule is given (data available for 2004-2032 only:)
<ul>
<li>Lunar New Year, the last day of the previous lunar year</li>
<li>Election Days</li>
<li>National Assemblies</li>
<li>Presidency</li>
<li>Regional Election Days</li>
<li>Buddha's birthday</li>
<li>Harvest Moon Day</li>
</ul>  Holidays for the Korea exchange (data from <http://www.krx.co.kr> or
<http://www.dooriworld.com/daishin/holiday/holiday.html>):
<ul>
<li>Public holidays as listed above</li>
<li>Year-end closing</li>
</ul>  calendars

  </summary> *)
[<AutoSerializable(true)>]
type SouthKoreaModel
    () as this =
    inherit Model<SouthKorea> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _SouthKorea                                = cell (fun () -> new SouthKorea ())
    let _addedHolidays                             = cell (fun () -> _SouthKorea.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.addHoliday(d.Value)
                                                                     _SouthKorea.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _SouthKorea.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _SouthKorea.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _SouthKorea.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = cell (fun () -> _SouthKorea.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = cell (fun () -> _SouthKorea.Value.calendar)
    let _empty                                     = cell (fun () -> _SouthKorea.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _SouthKorea.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = cell (fun () -> _SouthKorea.Value.isWeekend(w.Value))
    let _name                                      = cell (fun () -> _SouthKorea.Value.name())
    let _removedHolidays                           = cell (fun () -> _SouthKorea.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.removeHoliday(d.Value)
                                                                     _SouthKorea.Value)
    do this.Bind(_SouthKorea)

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
  Public holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Independence Day, March 1st</li>
<li>Arbour Day, April 5th (until 2005)</li>
<li>Labour Day, May 1st</li>
<li>Children's Day, May 5th</li>
<li>Memorial Day, June 6th</li>
<li>Constitution Day, July 17th (until 2007)</li>
<li>Liberation Day, August 15th</li>
<li>National Fondation Day, October 3th</li>
<li>Christmas Day, December 25th</li>
</ul>  Other holidays for which no rule is given (data available for 2004-2032 only:)
<ul>
<li>Lunar New Year, the last day of the previous lunar year</li>
<li>Election Days</li>
<li>National Assemblies</li>
<li>Presidency</li>
<li>Regional Election Days</li>
<li>Buddha's birthday</li>
<li>Harvest Moon Day</li>
</ul>  Holidays for the Korea exchange (data from <http://www.krx.co.kr> or
<http://www.dooriworld.com/daishin/holiday/holiday.html>):
<ul>
<li>Public holidays as listed above</li>
<li>Year-end closing</li>
</ul>  calendars

  </summary> *)
[<AutoSerializable(true)>]
type SouthKoreaModel1
    ( m                                            : ICell<SouthKorea.Market>
    ) as this =

    inherit Model<SouthKorea> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let _SouthKorea                                = cell (fun () -> new SouthKorea (m.Value))
    let _addedHolidays                             = cell (fun () -> _SouthKorea.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.addHoliday(d.Value)
                                                                     _SouthKorea.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _SouthKorea.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _SouthKorea.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _SouthKorea.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = cell (fun () -> _SouthKorea.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = cell (fun () -> _SouthKorea.Value.calendar)
    let _empty                                     = cell (fun () -> _SouthKorea.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _SouthKorea.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = cell (fun () -> _SouthKorea.Value.isWeekend(w.Value))
    let _name                                      = cell (fun () -> _SouthKorea.Value.name())
    let _removedHolidays                           = cell (fun () -> _SouthKorea.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = cell (fun () -> _SouthKorea.Value.removeHoliday(d.Value)
                                                                     _SouthKorea.Value)
    do this.Bind(_SouthKorea)

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
