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
  Due to the lack of reliable sources, the settlement calendar has the same holidays as the Tel Aviv stock-exchange.  Holidays for the Tel-Aviv Stock Exchange (data from <http://www.tase.co.il>):
<ul>
<li>Friday</li>
<li>Saturday</li>
</ul> Other holidays for wich no rule is given (data available for 2013-2044 only:)
<ul>
<li>Purim, Adar 14th (between Feb 24th & Mar 26th)</li>
<li>Passover I, Nisan 15th (between Mar 26th & Apr 25th)</li>
<li>Passover VII, Nisan 21st (between Apr 1st & May 1st)</li>
<li>Memorial Day, Nisan 27th (between Apr 7th & May 7th)</li>
<li>Indipendence Day, Iyar 5th (between Apr 15th & May 15th)</li>
<li>Pentecost (Shavuot), Sivan 6th (between May 15th & June 14th)</li>
<li>Fast Day</li>
<li>Jewish New Year, Tishrei 1st & 2nd (between Sep 5th & Oct 5th)</li>
<li>Yom Kippur, Tishrei 10th (between Sep 14th & Oct 14th)</li>
<li>Sukkoth, Tishrei 15th (between Sep 19th & Oct 19th)</li>
<li>Simchat Tora, Tishrei 22nd (between Sep 26th & Oct 26th)</li>
</ul>   calendars

  </summary> *)
[<AutoSerializable(true)>]
type IsraelModel
    ( m                                            : ICell<Israel.Market>
    ) as this =

    inherit Model<Israel> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let _Israel                                    = cell (fun () -> new Israel (m.Value))
    let _addedHolidays                             = cell (fun () -> _Israel.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Israel.Value.addHoliday(d.Value)
                                                                     _Israel.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _Israel.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Israel.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Israel.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = cell (fun () -> _Israel.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = cell (fun () -> _Israel.Value.calendar)
    let _empty                                     = cell (fun () -> _Israel.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Israel.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _Israel.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Israel.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = cell (fun () -> _Israel.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = cell (fun () -> _Israel.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = cell (fun () -> _Israel.Value.isWeekend(w.Value))
    let _name                                      = cell (fun () -> _Israel.Value.name())
    let _removedHolidays                           = cell (fun () -> _Israel.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Israel.Value.removeHoliday(d.Value)
                                                                     _Israel.Value)
    do this.Bind(_Israel)

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
