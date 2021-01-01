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
  Holidays:
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's day, January 1st (possibly followed by one or two more holidays)</li>
<li>Labour Day, first week in May</li>
<li>National Day, one week from October 1st</li>
</ul>  Other holidays for which no rule is given (data available for 2004-2019 only):
<ul>
<li>Chinese New Year</li>
<li>Ching Ming Festival</li>
<li>Tuen Ng Festival</li>
<li>Mid-Autumn Festival</li>
<li>70th anniversary of the victory of anti-Japaneses war</li>
</ul>  SSE data from <http://www.sse.com.cn/> IB data from <http://www.chinamoney.com.cn/>  calendars

  </summary> *)
[<AutoSerializable(true)>]
type ChinaModel
    ( market                                       : ICell<China.Market>
    ) as this =

    inherit Model<China> ()
(*
    Parameters
*)
    let _market                                    = market
(*
    Functions
*)
    let mutable
        _China                                     = make (fun () -> new China (market.Value))
    let _addedHolidays                             = triv _China (fun () -> _China.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _China (fun () -> _China.Value.addHoliday(d.Value)
                                                                            _China.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _China (fun () -> _China.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _China (fun () -> _China.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _China (fun () -> _China.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _China (fun () -> _China.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _China (fun () -> _China.Value.calendar)
    let _empty                                     = triv _China (fun () -> _China.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _China (fun () -> _China.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _China (fun () -> _China.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _China (fun () -> _China.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _China (fun () -> _China.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _China (fun () -> _China.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _China (fun () -> _China.Value.isWeekend(w.Value))
    let _name                                      = triv _China (fun () -> _China.Value.name())
    let _removedHolidays                           = triv _China (fun () -> _China.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _China (fun () -> _China.Value.removeHoliday(d.Value)
                                                                            _China.Value)
    do this.Bind(_China)
(* 
    casting 
*)
    internal new () = new ChinaModel(null)
    member internal this.Inject v = _China <- v
    static member Cast (p : ICell<China>) = 
        if p :? ChinaModel then 
            p :?> ChinaModel
        else
            let o = new ChinaModel ()
            o.Inject p
            o.Bind p
            o
                            

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
