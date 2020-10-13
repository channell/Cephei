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
  Public holidays (see: http://www.opm.gov/fedhol/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday, or to Friday if on Saturday)</li>
<li>Martin Luther King's birthday, third Monday in January (since 1983)</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Columbus Day, second Monday in October</li>
<li>Veterans' Day, November 11th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
</ul>  Holidays for the stock exchange (data from http://www.nyse.com):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Martin Luther King's birthday, third Monday in January (since 1998)</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Good Friday</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Presidential election day, first Tuesday in November of election years (until 1980)</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Special historic closings (see http://www.nyse.com/pdfs/closings.pdf)</li>
</ul>  Holidays for the government bond market (data from http://www.bondmarkets.com):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Martin Luther King's birthday, third Monday in January</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Good Friday</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Columbus Day, second Monday in October</li>
<li>Veterans' Day, November 11th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
</ul>  Holidays for the North American Energy Reliability Council (data from http://www.nerc.com/~oc/offpeaks.html):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday)</li>
<li>Labor Day, first Monday in September</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday)</li>
</ul>  the correctness of the returned results is tested against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type UnitedStatesModel
    ( m                                            : ICell<UnitedStates.Market>
    ) as this =

    inherit Model<UnitedStates> ()
(*
    Parameters
*)
    let _m                                         = m
(*
    Functions
*)
    let _UnitedStates                              = cell (fun () -> new UnitedStates (m.Value))
    let _addedHolidays                             = triv (fun () -> _UnitedStates.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.addHoliday(d.Value)
                                                                     _UnitedStates.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _UnitedStates.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _UnitedStates.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _UnitedStates.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _UnitedStates.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _UnitedStates.Value.calendar)
    let _empty                                     = triv (fun () -> _UnitedStates.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _UnitedStates.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _UnitedStates.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _UnitedStates.Value.name())
    let _removedHolidays                           = triv (fun () -> _UnitedStates.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.removeHoliday(d.Value)
                                                                     _UnitedStates.Value)
    do this.Bind(_UnitedStates)
(* 
    casting 
*)
    internal new () = new UnitedStatesModel(null)
    member internal this.Inject v = _UnitedStates.Value <- v
    static member Cast (p : ICell<UnitedStates>) = 
        if p :? UnitedStatesModel then 
            p :?> UnitedStatesModel
        else
            let o = new UnitedStatesModel ()
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
  Public holidays (see: http://www.opm.gov/fedhol/):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday, or to Friday if on Saturday)</li>
<li>Martin Luther King's birthday, third Monday in January (since 1983)</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Columbus Day, second Monday in October</li>
<li>Veterans' Day, November 11th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
</ul>  Holidays for the stock exchange (data from http://www.nyse.com):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Martin Luther King's birthday, third Monday in January (since 1998)</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Good Friday</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Presidential election day, first Tuesday in November of election years (until 1980)</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Special historic closings (see http://www.nyse.com/pdfs/closings.pdf)</li>
</ul>  Holidays for the government bond market (data from http://www.bondmarkets.com):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Martin Luther King's birthday, third Monday in January</li>
<li>Presidents' Day (a.k.a. Washington's birthday), third Monday in February</li>
<li>Good Friday</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Labor Day, first Monday in September</li>
<li>Columbus Day, second Monday in October</li>
<li>Veterans' Day, November 11th (moved to Monday if Sunday or Friday if Saturday)</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday or Friday if Saturday)</li>
</ul>  Holidays for the North American Energy Reliability Council (data from http://www.nerc.com/~oc/offpeaks.html):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's Day, January 1st (possibly moved to Monday if actually on Sunday)</li>
<li>Memorial Day, last Monday in May</li>
<li>Independence Day, July 4th (moved to Monday if Sunday)</li>
<li>Labor Day, first Monday in September</li>
<li>Thanksgiving Day, fourth Thursday in November</li>
<li>Christmas, December 25th (moved to Monday if Sunday)</li>
</ul>  the correctness of the returned results is tested against a list of known holidays.

  </summary> *)
[<AutoSerializable(true)>]
type UnitedStatesModel1
    () as this =
    inherit Model<UnitedStates> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _UnitedStates                              = cell (fun () -> new UnitedStates ())
    let _addedHolidays                             = triv (fun () -> _UnitedStates.Value.addedHolidays)
    let _addHoliday                                (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.addHoliday(d.Value)
                                                                     _UnitedStates.Value)
    let _adjust                                    (d : ICell<Date>) (c : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _UnitedStates.Value.adjust(d.Value, c.Value))
    let _advance                                   (d : ICell<Date>) (p : ICell<Period>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _UnitedStates.Value.advance(d.Value, p.Value, c.Value, endOfMonth.Value))
    let _advance1                                  (d : ICell<Date>) (n : ICell<int>) (unit : ICell<TimeUnit>) (c : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _UnitedStates.Value.advance(d.Value, n.Value, unit.Value, c.Value, endOfMonth.Value))
    let _businessDaysBetween                       (from : ICell<Date>) (To : ICell<Date>) (includeFirst : ICell<bool>) (includeLast : ICell<bool>)   
                                                   = triv (fun () -> _UnitedStates.Value.businessDaysBetween(from.Value, To.Value, includeFirst.Value, includeLast.Value))
    let _calendar                                  = triv (fun () -> _UnitedStates.Value.calendar)
    let _empty                                     = triv (fun () -> _UnitedStates.Value.empty())
    let _endOfMonth                                (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.endOfMonth(d.Value))
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _UnitedStates.Value.Equals(o.Value))
    let _isBusinessDay                             (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.isBusinessDay(d.Value))
    let _isEndOfMonth                              (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.isEndOfMonth(d.Value))
    let _isHoliday                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.isHoliday(d.Value))
    let _isWeekend                                 (w : ICell<DayOfWeek>)   
                                                   = triv (fun () -> _UnitedStates.Value.isWeekend(w.Value))
    let _name                                      = triv (fun () -> _UnitedStates.Value.name())
    let _removedHolidays                           = triv (fun () -> _UnitedStates.Value.removedHolidays)
    let _removeHoliday                             (d : ICell<Date>)   
                                                   = triv (fun () -> _UnitedStates.Value.removeHoliday(d.Value)
                                                                     _UnitedStates.Value)
    do this.Bind(_UnitedStates)
(* 
    casting 
*)
    
    member internal this.Inject v = _UnitedStates.Value <- v
    static member Cast (p : ICell<UnitedStates>) = 
        if p :? UnitedStatesModel1 then 
            p :?> UnitedStatesModel1
        else
            let o = new UnitedStatesModel1 ()
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
