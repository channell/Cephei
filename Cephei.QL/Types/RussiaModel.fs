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
  Public holidays (see <http://www.cbr.ru/eng/>:):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year holidays and Christmas, January 1st to 8th</li>
<li>Defender of the Fatherland Day, February 23rd (possibly moved to Monday)</li>
<li>International Women's Day, March 8th (possibly moved to Monday)</li>
<li>Labour Day, May 1st (possibly moved to Monday)</li>
<li>Victory Day, May 9th (possibly moved to Monday)</li>
<li>Russia Day, June 12th (possibly moved to Monday)</li>
<li>Unity Day, November 4th (possibly moved to Monday)</li>
</ul>  Holidays for the Moscow Exchange (MOEX) taken from
<http://moex.com/s726> and related pages.  These holidays are
<em>not</em> consistent year-to-year, may or may not correlate to public holidays, and are only available for dates since the introduction of the MOEX 'brand' (a merger of the stock and futures markets).  calendars

  </summary> *)
[<AutoSerializable(true)>]
type RussiaModel
    ( m                                            : ICell<Russia.Market>
    ) as this =

    inherit Model<Russia> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let _Russia                                    = cell (fun () -> new Russia (m.Value))
    let _addedHolidays                             = triv (fun () -> _Russia.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.addHoliday(d.Value)
                                                                     _Russia.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _Russia.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Russia.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Russia.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _Russia.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _Russia.Value.calendar)
    let _empty                                     = triv (fun () -> _Russia.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Russia.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _Russia.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _Russia.Value.name())
    let _removedHolidays                           = triv (fun () -> _Russia.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.removeHoliday(d.Value)
                                                                     _Russia.Value)
    do this.Bind(_Russia)

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
  Public holidays (see <http://www.cbr.ru/eng/>:):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year holidays and Christmas, January 1st to 8th</li>
<li>Defender of the Fatherland Day, February 23rd (possibly moved to Monday)</li>
<li>International Women's Day, March 8th (possibly moved to Monday)</li>
<li>Labour Day, May 1st (possibly moved to Monday)</li>
<li>Victory Day, May 9th (possibly moved to Monday)</li>
<li>Russia Day, June 12th (possibly moved to Monday)</li>
<li>Unity Day, November 4th (possibly moved to Monday)</li>
</ul>  Holidays for the Moscow Exchange (MOEX) taken from
<http://moex.com/s726> and related pages.  These holidays are
<em>not</em> consistent year-to-year, may or may not correlate to public holidays, and are only available for dates since the introduction of the MOEX 'brand' (a merger of the stock and futures markets).  calendars

  </summary> *)
[<AutoSerializable(true)>]
type RussiaModel1
    () as this =
    inherit Model<Russia> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Russia                                    = cell (fun () -> new Russia ())
    let _addedHolidays                             = triv (fun () -> _Russia.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.addHoliday(d.Value)
                                                                     _Russia.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _Russia.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Russia.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Russia.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _Russia.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _Russia.Value.calendar)
    let _empty                                     = triv (fun () -> _Russia.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Russia.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _Russia.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _Russia.Value.name())
    let _removedHolidays                           = triv (fun () -> _Russia.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Russia.Value.removeHoliday(d.Value)
                                                                     _Russia.Value)
    do this.Bind(_Russia)

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
