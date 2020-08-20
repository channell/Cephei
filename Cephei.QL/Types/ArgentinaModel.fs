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
  Holidays for the Buenos Aires stock exchange (data from <http://www.merval.sba.com.ar/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Holy Thursday</li>
<li>Good Friday</li>
<li>Labour Day, May 1st</li>
<li>May Revolution, May 25th</li>
<li>Death of General Manuel Belgrano, third Monday of June</li>
<li>Independence Day, July 9th</li>
<li>Death of General JosÃ© de San MartÃ­n, third Monday of August</li>
<li>Columbus Day, October 12th (moved to preceding Monday if on Tuesday or Wednesday and to following if on Thursday or Friday)</li>
<li>Immaculate Conception, December 8th</li>
<li>Christmas Eve, December 24th</li>
<li>New Year's Eve, December 31th</li>
</ul>  calendars

  </summary> *)
[<AutoSerializable(true)>]
type ArgentinaModel
    () as this =
    inherit Model<Argentina> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Argentina                                 = cell (fun () -> new Argentina ())
    let _addedHolidays                             = cell (fun () -> _Argentina.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Argentina.Value.addHoliday(d.Value)
                                                                     _Argentina.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = cell (fun () -> _Argentina.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Argentina.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = cell (fun () -> _Argentina.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = cell (fun () -> _Argentina.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = cell (fun () -> _Argentina.Value.calendar)
    let _empty                                     = cell (fun () -> _Argentina.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = cell (fun () -> _Argentina.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _Argentina.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Argentina.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = cell (fun () -> _Argentina.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = cell (fun () -> _Argentina.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = cell (fun () -> _Argentina.Value.isWeekend(w.Value))
    let _name                                      = cell (fun () -> _Argentina.Value.name())
    let _removedHolidays                           = cell (fun () -> _Argentina.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = cell (fun () -> _Argentina.Value.removeHoliday(d.Value)
                                                                     _Argentina.Value)
    do this.Bind(_Argentina)

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
