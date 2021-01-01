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
<li>New Year's Day, January 1st</li>
<li>Bank Holiday, January 2nd</li>
<li>Bank Holiday, January 3rd</li>
<li>Coming of Age Day, 2nd Monday in January</li>
<li>National Foundation Day, February 11th</li>
<li>Vernal Equinox</li>
<li>Greenery Day, April 29th</li>
<li>Constitution Memorial Day, May 3rd</li>
<li>Holiday for a Nation, May 4th</li>
<li>Children's Day, May 5th</li>
<li>Marine Day, 3rd Monday in July</li>
<li>Mountain Day, August 11th (from 2016 onwards)</li>
<li>Respect for the Aged Day, 3rd Monday in September</li>
<li>Autumnal Equinox</li>
<li>Health and Sports Day, 2nd Monday in October</li>
<li>National Culture Day, November 3rd</li>
<li>Labor Thanksgiving Day, November 23rd</li>
<li>Emperor's Birthday, December 23rd</li>
<li>Bank Holiday, December 31st</li>
<li>a few one-shot holidays</li>
</ul> Holidays falling on a Sunday are observed on the Monday following except for the bank holidays associated with the new year.  calendars

  </summary> *)
[<AutoSerializable(true)>]
type JapanModel
    () as this =
    inherit Model<Japan> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Japan                                     = make (fun () -> new Japan ())
    let _addedHolidays                             = triv _Japan (fun () -> _Japan.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv _Japan (fun () -> _Japan.Value.addHoliday(d.Value)
                                                                            _Japan.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv _Japan (fun () -> _Japan.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Japan (fun () -> _Japan.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv _Japan (fun () -> _Japan.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv _Japan (fun () -> _Japan.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv _Japan (fun () -> _Japan.Value.calendar)
    let _empty                                     = triv _Japan (fun () -> _Japan.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv _Japan (fun () -> _Japan.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Japan (fun () -> _Japan.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv _Japan (fun () -> _Japan.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv _Japan (fun () -> _Japan.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv _Japan (fun () -> _Japan.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv _Japan (fun () -> _Japan.Value.isWeekend(w.Value))
    let _name                                      = triv _Japan (fun () -> _Japan.Value.name())
    let _removedHolidays                           = triv _Japan (fun () -> _Japan.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv _Japan (fun () -> _Japan.Value.removeHoliday(d.Value)
                                                                            _Japan.Value)
    do this.Bind(_Japan)
(* 
    casting 
*)
    
    member internal this.Inject v = _Japan <- v
    static member Cast (p : ICell<Japan>) = 
        if p :? JapanModel then 
            p :?> JapanModel
        else
            let o = new JapanModel ()
            o.Inject p
            o.Bind p
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
