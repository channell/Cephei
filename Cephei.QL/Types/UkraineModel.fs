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
  Holidays for the Ukrainian stock exchange (data from <http://www.ukrse.kiev.ua/eng/>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Orthodox Christmas, January 7th</li>
<li>International Women's Day, March 8th</li>
<li>Easter Monday</li>
<li>Holy Trinity Day, 50 days after Easter</li>
<li>International Workers' Solidarity Days, May 1st and 2nd</li>
<li>Victory Day, May 9th</li>
<li>Constitution Day, June 28th</li>
<li>Independence Day, August 24th</li>
<li>Defender's Day, October 14th (since 2015)</li>
</ul> Holidays falling on a Saturday or Sunday are moved to the following Monday.  calendars

  </summary> *)
[<AutoSerializable(true)>]
type UkraineModel
    ( m                                            : ICell<Ukraine.Market>
    ) as this =

    inherit Model<Ukraine> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let mutable
        _Ukraine                                   = cell (fun () -> new Ukraine (m.Value))
    let _addedHolidays                             = triv (fun () -> _Ukraine.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Ukraine.Value.addHoliday(d.Value)
                                                                     _Ukraine.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _Ukraine.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Ukraine.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Ukraine.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _Ukraine.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _Ukraine.Value.calendar)
    let _empty                                     = triv (fun () -> _Ukraine.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Ukraine.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Ukraine.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Ukraine.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Ukraine.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _Ukraine.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _Ukraine.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _Ukraine.Value.name())
    let _removedHolidays                           = triv (fun () -> _Ukraine.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Ukraine.Value.removeHoliday(d.Value)
                                                                     _Ukraine.Value)
    do this.Bind(_Ukraine)
(* 
    casting 
*)
    internal new () = new UkraineModel(null)
    member internal this.Inject v = _Ukraine <- v
    static member Cast (p : ICell<Ukraine>) = 
        if p :? UkraineModel then 
            p :?> UkraineModel
        else
            let o = new UkraineModel ()
            o.Inject p
            o.Bind p
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
