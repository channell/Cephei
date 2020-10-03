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
  Holidays for the Taiwan stock exchange (data from <http://www.tse.com.tw/en/trading/trading_days.php>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st</li>
<li>Peace Memorial Day, February 28</li>
<li>Labor Day, May 1st</li>
<li>Double Tenth National Day, October 10th</li>
</ul>  Other holidays for which no rule is given (data available for 2002-2013 only:)
<ul>
<li>Chinese Lunar New Year</li>
<li>Tomb Sweeping Day</li>
<li>Dragon Boat Festival</li>
<li>Moon Festival</li>
</ul>  calendars

  </summary> *)
[<AutoSerializable(true)>]
type TaiwanModel
    () as this =
    inherit Model<Taiwan> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Taiwan                                    = cell (fun () -> new Taiwan ())
    let _addedHolidays                             = triv (fun () -> _Taiwan.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Taiwan.Value.addHoliday(d.Value)
                                                                     _Taiwan.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _Taiwan.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Taiwan.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _Taiwan.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _Taiwan.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _Taiwan.Value.calendar)
    let _empty                                     = triv (fun () -> _Taiwan.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _Taiwan.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Taiwan.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Taiwan.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _Taiwan.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _Taiwan.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _Taiwan.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _Taiwan.Value.name())
    let _removedHolidays                           = triv (fun () -> _Taiwan.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _Taiwan.Value.removeHoliday(d.Value)
                                                                     _Taiwan.Value)
    do this.Bind(_Taiwan)
(* 
    casting 
*)
    
    member internal this.Inject v = _Taiwan.Value <- v
    static member Cast (p : ICell<Taiwan>) = 
        if p :? TaiwanModel then 
            p :?> TaiwanModel
        else
            let o = new TaiwanModel ()
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
