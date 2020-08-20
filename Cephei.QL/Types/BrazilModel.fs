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
  Banking holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Tiradentes's Day, April 21th</li>
<li>Labour Day, May 1st</li>
<li>Independence Day, September 7th</li>
<li>Nossa Sra. Aparecida Day, October 12th</li>
<li>All Souls Day, November 2nd</li>
<li>Republic Day, November 15th</li>
<li>Christmas, December 25th</li>
<li>Passion of Christ</li>
<li>Carnival</li>
<li>Corpus Christi</li>
</ul>  Holidays for the Bovespa stock exchange
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Sao Paulo City Day, January 25th</li>
<li>Tiradentes's Day, April 21th</li>
<li>Labour Day, May 1st</li>
<li>Revolution Day, July 9th</li>
<li>Independence Day, September 7th</li>
<li>Nossa Sra. Aparecida Day, October 12th</li>
<li>All Souls Day, November 2nd</li>
<li>Republic Day, November 15th</li>
<li>Black Consciousness Day, November 20th (since 2007)</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Passion of Christ</li>
<li>Carnival</li>
<li>Corpus Christi</li>
<li>the last business day of the year</li>
</ul>  calendars  the correctness of the returned results is tested against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type BrazilModel
    ( market                                       : ICell<Brazil.Market>
    ) as this =

    inherit Model<Brazil> ()
(*
    Parameters
*)
    let _market                                    = market
(*
    Functions
*)
    let _Brazil                                    = cell (fun () -> new Brazil (market.Value))
    let _addedHolidays                             = cell (fun () -> _Brazil.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.addHoliday(d.Value)
                                                                     _Brazil.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _Brazil.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Brazil.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Brazil.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = cell (fun () -> _Brazil.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = cell (fun () -> _Brazil.Value.calendar)
    let _empty                                     = cell (fun () -> _Brazil.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _Brazil.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = cell (fun () -> _Brazil.Value.isWeekend(w.Value))
    let _name                                      = cell (fun () -> _Brazil.Value.name())
    let _removedHolidays                           = cell (fun () -> _Brazil.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.removeHoliday(d.Value)
                                                                     _Brazil.Value)
    do this.Bind(_Brazil)

(* 
    Externally visible/bindable properties
*)
    member this.market                             = _market 
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
  Banking holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Tiradentes's Day, April 21th</li>
<li>Labour Day, May 1st</li>
<li>Independence Day, September 7th</li>
<li>Nossa Sra. Aparecida Day, October 12th</li>
<li>All Souls Day, November 2nd</li>
<li>Republic Day, November 15th</li>
<li>Christmas, December 25th</li>
<li>Passion of Christ</li>
<li>Carnival</li>
<li>Corpus Christi</li>
</ul>  Holidays for the Bovespa stock exchange
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Sao Paulo City Day, January 25th</li>
<li>Tiradentes's Day, April 21th</li>
<li>Labour Day, May 1st</li>
<li>Revolution Day, July 9th</li>
<li>Independence Day, September 7th</li>
<li>Nossa Sra. Aparecida Day, October 12th</li>
<li>All Souls Day, November 2nd</li>
<li>Republic Day, November 15th</li>
<li>Black Consciousness Day, November 20th (since 2007)</li>
<li>Christmas Eve, December 24th</li>
<li>Christmas, December 25th</li>
<li>Passion of Christ</li>
<li>Carnival</li>
<li>Corpus Christi</li>
<li>the last business day of the year</li>
</ul>  calendars  the correctness of the returned results is tested against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type BrazilModel1
    () as this =
    inherit Model<Brazil> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Brazil                                    = cell (fun () -> new Brazil ())
    let _addedHolidays                             = cell (fun () -> _Brazil.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.addHoliday(d.Value)
                                                                     _Brazil.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _Brazil.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Brazil.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Brazil.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = cell (fun () -> _Brazil.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = cell (fun () -> _Brazil.Value.calendar)
    let _empty                                     = cell (fun () -> _Brazil.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _Brazil.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = cell (fun () -> _Brazil.Value.isWeekend(w.Value))
    let _name                                      = cell (fun () -> _Brazil.Value.name())
    let _removedHolidays                           = cell (fun () -> _Brazil.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Brazil.Value.removeHoliday(d.Value)
                                                                     _Brazil.Value)
    do this.Bind(_Brazil)

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
