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

! Default constructor returning a null date.
  </summary> *)
[<AutoSerializable(true)>]
type DateModel
    () as this =
    inherit Model<Date> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Date                                      = cell (fun () -> new Date ())
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.CompareTo(obj.Value))
    let _Day                                       = triv (fun () -> _Date.Value.Day)
    let _DayOfWeek                                 = triv (fun () -> _Date.Value.DayOfWeek)
    let _DayOfYear                                 = triv (fun () -> _Date.Value.DayOfYear)
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.Equals(o.Value))
    let _fractionOfDay                             = triv (fun () -> _Date.Value.fractionOfDay())
    let _fractionOfSecond                          = triv (fun () -> _Date.Value.fractionOfSecond)
    let _hours                                     = triv (fun () -> _Date.Value.hours)
    let _milliseconds                              = triv (fun () -> _Date.Value.milliseconds)
    let _minutes                                   = triv (fun () -> _Date.Value.minutes)
    let _month                                     = triv (fun () -> _Date.Value.month())
    let _Month                                     = triv (fun () -> _Date.Value.Month)
    let _seconds                                   = triv (fun () -> _Date.Value.seconds)
    let _serialNumber                              = triv (fun () -> _Date.Value.serialNumber())
    let _ToLongDateString                          = triv (fun () -> _Date.Value.ToLongDateString())
    let _ToShortDateString                         = triv (fun () -> _Date.Value.ToShortDateString())
    let _ToString                                  = triv (fun () -> _Date.Value.ToString())
    let _ToString1                                 (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(provider.Value))
    let _ToString2                                 (format : ICell<string>) (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value, provider.Value))
    let _ToString3                                 (format : ICell<string>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value))
    let _weekday                                   = triv (fun () -> _Date.Value.weekday())
    let _year                                      = triv (fun () -> _Date.Value.year())
    let _Year                                      = triv (fun () -> _Date.Value.Year)
    do this.Bind(_Date)
(* 
    casting 
*)
    
    member internal this.Inject v = _Date.Value <- v
    static member Cast (p : ICell<Date>) = 
        if p :? DateModel then 
            p :?> DateModel
        else
            let o = new DateModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Day                                = _Day
    member this.DayOfWeek                          = _DayOfWeek
    member this.DayOfYear                          = _DayOfYear
    member this.Equals                             o   
                                                   = _Equals o 
    member this.FractionOfDay                      = _fractionOfDay
    member this.FractionOfSecond                   = _fractionOfSecond
    member this.Hours                              = _hours
    member this.Milliseconds                       = _milliseconds
    member this.Minutes                            = _minutes
    member this.Month                              = _month
    member this.Month1                             = _Month
    member this.Seconds                            = _seconds
    member this.SerialNumber                       = _serialNumber
    member this.ToLongDateString                   = _ToLongDateString
    member this.ToShortDateString                  = _ToShortDateString
    member this.ToString                           = _ToString
    member this.ToString1                          provider   
                                                   = _ToString1 provider 
    member this.ToString2                          format provider   
                                                   = _ToString2 format provider 
    member this.ToString3                          format   
                                                   = _ToString3 format 
    member this.Weekday                            = _weekday
    member this.Year                               = _year
    member this.Year1                              = _Year
(* <summary>

! Constructor taking a serial number as given by Excel. Serial numbers in Excel have a known problem with leap year 1900
  </summary> *)
[<AutoSerializable(true)>]
type DateModel1
    ( serialNumber                                 : ICell<int>
    ) as this =

    inherit Model<Date> ()
(*
    Parameters
*)
    let _serialNumber                              = serialNumber
(*
    Functions
*)
    let _Date                                      = cell (fun () -> new Date (serialNumber.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.CompareTo(obj.Value))
    let _Day                                       = triv (fun () -> _Date.Value.Day)
    let _DayOfWeek                                 = triv (fun () -> _Date.Value.DayOfWeek)
    let _DayOfYear                                 = triv (fun () -> _Date.Value.DayOfYear)
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.Equals(o.Value))
    let _fractionOfDay                             = triv (fun () -> _Date.Value.fractionOfDay())
    let _fractionOfSecond                          = triv (fun () -> _Date.Value.fractionOfSecond)
    let _hours                                     = triv (fun () -> _Date.Value.hours)
    let _milliseconds                              = triv (fun () -> _Date.Value.milliseconds)
    let _minutes                                   = triv (fun () -> _Date.Value.minutes)
    let _month                                     = triv (fun () -> _Date.Value.month())
    let _Month                                     = triv (fun () -> _Date.Value.Month)
    let _seconds                                   = triv (fun () -> _Date.Value.seconds)
    let _serialNumber                              = triv (fun () -> _Date.Value.serialNumber())
    let _ToLongDateString                          = triv (fun () -> _Date.Value.ToLongDateString())
    let _ToShortDateString                         = triv (fun () -> _Date.Value.ToShortDateString())
    let _ToString                                  = triv (fun () -> _Date.Value.ToString())
    let _ToString1                                 (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(provider.Value))
    let _ToString2                                 (format : ICell<string>) (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value, provider.Value))
    let _ToString3                                 (format : ICell<string>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value))
    let _weekday                                   = triv (fun () -> _Date.Value.weekday())
    let _year                                      = triv (fun () -> _Date.Value.year())
    let _Year                                      = triv (fun () -> _Date.Value.Year)
    do this.Bind(_Date)
(* 
    casting 
*)
    internal new () = DateModel1(null)
    member internal this.Inject v = _Date.Value <- v
    static member Cast (p : ICell<Date>) = 
        if p :? DateModel1 then 
            p :?> DateModel1
        else
            let o = new DateModel1 ()
            o.Inject p.Value
            o

(* 
    Externally visible/bindable properties
*)
    member this.serialNumber                       = _serialNumber 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Day                                = _Day
    member this.DayOfWeek                          = _DayOfWeek
    member this.DayOfYear                          = _DayOfYear
    member this.Equals                             o   
                                                   = _Equals o 
    member this.FractionOfDay                      = _fractionOfDay
    member this.FractionOfSecond                   = _fractionOfSecond
    member this.Hours                              = _hours
    member this.Milliseconds                       = _milliseconds
    member this.Minutes                            = _minutes
    member this.Month                              = _month
    member this.Month1                             = _Month
    member this.Seconds                            = _seconds
    member this.SerialNumber                       = _serialNumber
    member this.ToLongDateString                   = _ToLongDateString
    member this.ToShortDateString                  = _ToShortDateString
    member this.ToString                           = _ToString
    member this.ToString1                          provider   
                                                   = _ToString1 provider 
    member this.ToString2                          format provider   
                                                   = _ToString2 format provider 
    member this.ToString3                          format   
                                                   = _ToString3 format 
    member this.Weekday                            = _weekday
    member this.Year                               = _year
    member this.Year1                              = _Year
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type DateModel2
    ( d                                            : ICell<int>
    , m                                            : ICell<Month>
    , y                                            : ICell<int>
    , h                                            : ICell<int>
    , mi                                           : ICell<int>
    , s                                            : ICell<int>
    , ms                                           : ICell<int>
    ) as this =

    inherit Model<Date> ()
(*
    Parameters
*)
    let _d                                         = d
    let _m                                         = m
    let _y                                         = y
    let _h                                         = h
    let _mi                                        = mi
    let _s                                         = s
    let _ms                                        = ms
(*
    Functions
*)
    let _Date                                      = cell (fun () -> new Date (d.Value, m.Value, y.Value, h.Value, mi.Value, s.Value, ms.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.CompareTo(obj.Value))
    let _Day                                       = triv (fun () -> _Date.Value.Day)
    let _DayOfWeek                                 = triv (fun () -> _Date.Value.DayOfWeek)
    let _DayOfYear                                 = triv (fun () -> _Date.Value.DayOfYear)
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.Equals(o.Value))
    let _fractionOfDay                             = triv (fun () -> _Date.Value.fractionOfDay())
    let _fractionOfSecond                          = triv (fun () -> _Date.Value.fractionOfSecond)
    let _hours                                     = triv (fun () -> _Date.Value.hours)
    let _milliseconds                              = triv (fun () -> _Date.Value.milliseconds)
    let _minutes                                   = triv (fun () -> _Date.Value.minutes)
    let _month                                     = triv (fun () -> _Date.Value.month())
    let _Month                                     = triv (fun () -> _Date.Value.Month)
    let _seconds                                   = triv (fun () -> _Date.Value.seconds)
    let _serialNumber                              = triv (fun () -> _Date.Value.serialNumber())
    let _ToLongDateString                          = triv (fun () -> _Date.Value.ToLongDateString())
    let _ToShortDateString                         = triv (fun () -> _Date.Value.ToShortDateString())
    let _ToString                                  = triv (fun () -> _Date.Value.ToString())
    let _ToString1                                 (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(provider.Value))
    let _ToString2                                 (format : ICell<string>) (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value, provider.Value))
    let _ToString3                                 (format : ICell<string>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value))
    let _weekday                                   = triv (fun () -> _Date.Value.weekday())
    let _year                                      = triv (fun () -> _Date.Value.year())
    let _Year                                      = triv (fun () -> _Date.Value.Year)
    do this.Bind(_Date)
(* 
    casting 
*)
    internal new () = DateModel2(null,null,null,null,null,null,null)
    member internal this.Inject v = _Date.Value <- v
    static member Cast (p : ICell<Date>) = 
        if p :? DateModel2 then 
            p :?> DateModel2
        else
            let o = new DateModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.m                                  = _m 
    member this.y                                  = _y 
    member this.h                                  = _h 
    member this.mi                                 = _mi 
    member this.s                                  = _s 
    member this.ms                                 = _ms 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Day                                = _Day
    member this.DayOfWeek                          = _DayOfWeek
    member this.DayOfYear                          = _DayOfYear
    member this.Equals                             o   
                                                   = _Equals o 
    member this.FractionOfDay                      = _fractionOfDay
    member this.FractionOfSecond                   = _fractionOfSecond
    member this.Hours                              = _hours
    member this.Milliseconds                       = _milliseconds
    member this.Minutes                            = _minutes
    member this.Month                              = _month
    member this.Month1                             = _Month
    member this.Seconds                            = _seconds
    member this.SerialNumber                       = _serialNumber
    member this.ToLongDateString                   = _ToLongDateString
    member this.ToShortDateString                  = _ToShortDateString
    member this.ToString                           = _ToString
    member this.ToString1                          provider   
                                                   = _ToString1 provider 
    member this.ToString2                          format provider   
                                                   = _ToString2 format provider 
    member this.ToString3                          format   
                                                   = _ToString3 format 
    member this.Weekday                            = _weekday
    member this.Year                               = _year
    member this.Year1                              = _Year
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type DateModel3
    ( d                                            : ICell<int>
    , m                                            : ICell<int>
    , y                                            : ICell<int>
    ) as this =

    inherit Model<Date> ()
(*
    Parameters
*)
    let _d                                         = d
    let _m                                         = m
    let _y                                         = y
(*
    Functions
*)
    let _Date                                      = cell (fun () -> new Date (d.Value, m.Value, y.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.CompareTo(obj.Value))
    let _Day                                       = triv (fun () -> _Date.Value.Day)
    let _DayOfWeek                                 = triv (fun () -> _Date.Value.DayOfWeek)
    let _DayOfYear                                 = triv (fun () -> _Date.Value.DayOfYear)
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.Equals(o.Value))
    let _fractionOfDay                             = triv (fun () -> _Date.Value.fractionOfDay())
    let _fractionOfSecond                          = triv (fun () -> _Date.Value.fractionOfSecond)
    let _hours                                     = triv (fun () -> _Date.Value.hours)
    let _milliseconds                              = triv (fun () -> _Date.Value.milliseconds)
    let _minutes                                   = triv (fun () -> _Date.Value.minutes)
    let _month                                     = triv (fun () -> _Date.Value.month())
    let _Month                                     = triv (fun () -> _Date.Value.Month)
    let _seconds                                   = triv (fun () -> _Date.Value.seconds)
    let _serialNumber                              = triv (fun () -> _Date.Value.serialNumber())
    let _ToLongDateString                          = triv (fun () -> _Date.Value.ToLongDateString())
    let _ToShortDateString                         = triv (fun () -> _Date.Value.ToShortDateString())
    let _ToString                                  = triv (fun () -> _Date.Value.ToString())
    let _ToString1                                 (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(provider.Value))
    let _ToString2                                 (format : ICell<string>) (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value, provider.Value))
    let _ToString3                                 (format : ICell<string>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value))
    let _weekday                                   = triv (fun () -> _Date.Value.weekday())
    let _year                                      = triv (fun () -> _Date.Value.year())
    let _Year                                      = triv (fun () -> _Date.Value.Year)
    do this.Bind(_Date)
(* 
    casting 
*)
    internal new () = DateModel3(null,null,null)
    member internal this.Inject v = _Date.Value <- v
    static member Cast (p : ICell<Date>) = 
        if p :? DateModel3 then 
            p :?> DateModel3
        else
            let o = new DateModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.m                                  = _m 
    member this.y                                  = _y 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Day                                = _Day
    member this.DayOfWeek                          = _DayOfWeek
    member this.DayOfYear                          = _DayOfYear
    member this.Equals                             o   
                                                   = _Equals o 
    member this.FractionOfDay                      = _fractionOfDay
    member this.FractionOfSecond                   = _fractionOfSecond
    member this.Hours                              = _hours
    member this.Milliseconds                       = _milliseconds
    member this.Minutes                            = _minutes
    member this.Month                              = _month
    member this.Month1                             = _Month
    member this.Seconds                            = _seconds
    member this.SerialNumber                       = _serialNumber
    member this.ToLongDateString                   = _ToLongDateString
    member this.ToShortDateString                  = _ToShortDateString
    member this.ToString                           = _ToString
    member this.ToString1                          provider   
                                                   = _ToString1 provider 
    member this.ToString2                          format provider   
                                                   = _ToString2 format provider 
    member this.ToString3                          format   
                                                   = _ToString3 format 
    member this.Weekday                            = _weekday
    member this.Year                               = _year
    member this.Year1                              = _Year
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type DateModel4
    ( d                                            : ICell<DateTime>
    ) as this =

    inherit Model<Date> ()
(*
    Parameters
*)
    let _d                                         = d
(*
    Functions
*)
    let _Date                                      = cell (fun () -> new Date (d.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.CompareTo(obj.Value))
    let _Day                                       = triv (fun () -> _Date.Value.Day)
    let _DayOfWeek                                 = triv (fun () -> _Date.Value.DayOfWeek)
    let _DayOfYear                                 = triv (fun () -> _Date.Value.DayOfYear)
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.Equals(o.Value))
    let _fractionOfDay                             = triv (fun () -> _Date.Value.fractionOfDay())
    let _fractionOfSecond                          = triv (fun () -> _Date.Value.fractionOfSecond)
    let _hours                                     = triv (fun () -> _Date.Value.hours)
    let _milliseconds                              = triv (fun () -> _Date.Value.milliseconds)
    let _minutes                                   = triv (fun () -> _Date.Value.minutes)
    let _month                                     = triv (fun () -> _Date.Value.month())
    let _Month                                     = triv (fun () -> _Date.Value.Month)
    let _seconds                                   = triv (fun () -> _Date.Value.seconds)
    let _serialNumber                              = triv (fun () -> _Date.Value.serialNumber())
    let _ToLongDateString                          = triv (fun () -> _Date.Value.ToLongDateString())
    let _ToShortDateString                         = triv (fun () -> _Date.Value.ToShortDateString())
    let _ToString                                  = triv (fun () -> _Date.Value.ToString())
    let _ToString1                                 (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(provider.Value))
    let _ToString2                                 (format : ICell<string>) (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value, provider.Value))
    let _ToString3                                 (format : ICell<string>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value))
    let _weekday                                   = triv (fun () -> _Date.Value.weekday())
    let _year                                      = triv (fun () -> _Date.Value.year())
    let _Year                                      = triv (fun () -> _Date.Value.Year)
    do this.Bind(_Date)
(* 
    casting 
*)
    internal new () = DateModel4(null)
    member internal this.Inject v = _Date.Value <- v
    static member Cast (p : ICell<Date>) = 
        if p :? DateModel4 then 
            p :?> DateModel4
        else
            let o = new DateModel4 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Day                                = _Day
    member this.DayOfWeek                          = _DayOfWeek
    member this.DayOfYear                          = _DayOfYear
    member this.Equals                             o   
                                                   = _Equals o 
    member this.FractionOfDay                      = _fractionOfDay
    member this.FractionOfSecond                   = _fractionOfSecond
    member this.Hours                              = _hours
    member this.Milliseconds                       = _milliseconds
    member this.Minutes                            = _minutes
    member this.Month                              = _month
    member this.Month1                             = _Month
    member this.Seconds                            = _seconds
    member this.SerialNumber                       = _serialNumber
    member this.ToLongDateString                   = _ToLongDateString
    member this.ToShortDateString                  = _ToShortDateString
    member this.ToString                           = _ToString
    member this.ToString1                          provider   
                                                   = _ToString1 provider 
    member this.ToString2                          format provider   
                                                   = _ToString2 format provider 
    member this.ToString3                          format   
                                                   = _ToString3 format 
    member this.Weekday                            = _weekday
    member this.Year                               = _year
    member this.Year1                              = _Year
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type DateModel5
    ( d                                            : ICell<int>
    , m                                            : ICell<int>
    , y                                            : ICell<int>
    , h                                            : ICell<int>
    , mi                                           : ICell<int>
    , s                                            : ICell<int>
    , ms                                           : ICell<int>
    ) as this =

    inherit Model<Date> ()
(*
    Parameters
*)
    let _d                                         = d
    let _m                                         = m
    let _y                                         = y
    let _h                                         = h
    let _mi                                        = mi
    let _s                                         = s
    let _ms                                        = ms
(*
    Functions
*)
    let _Date                                      = cell (fun () -> new Date (d.Value, m.Value, y.Value, h.Value, mi.Value, s.Value, ms.Value))
    let _CompareTo                                 (obj : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.CompareTo(obj.Value))
    let _Day                                       = triv (fun () -> _Date.Value.Day)
    let _DayOfWeek                                 = triv (fun () -> _Date.Value.DayOfWeek)
    let _DayOfYear                                 = triv (fun () -> _Date.Value.DayOfYear)
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Date.Value.Equals(o.Value))
    let _fractionOfDay                             = triv (fun () -> _Date.Value.fractionOfDay())
    let _fractionOfSecond                          = triv (fun () -> _Date.Value.fractionOfSecond)
    let _hours                                     = triv (fun () -> _Date.Value.hours)
    let _milliseconds                              = triv (fun () -> _Date.Value.milliseconds)
    let _minutes                                   = triv (fun () -> _Date.Value.minutes)
    let _month                                     = triv (fun () -> _Date.Value.month())
    let _Month                                     = triv (fun () -> _Date.Value.Month)
    let _seconds                                   = triv (fun () -> _Date.Value.seconds)
    let _serialNumber                              = triv (fun () -> _Date.Value.serialNumber())
    let _ToLongDateString                          = triv (fun () -> _Date.Value.ToLongDateString())
    let _ToShortDateString                         = triv (fun () -> _Date.Value.ToShortDateString())
    let _ToString                                  = triv (fun () -> _Date.Value.ToString())
    let _ToString1                                 (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(provider.Value))
    let _ToString2                                 (format : ICell<string>) (provider : ICell<IFormatProvider>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value, provider.Value))
    let _ToString3                                 (format : ICell<string>)   
                                                   = triv (fun () -> _Date.Value.ToString(format.Value))
    let _weekday                                   = triv (fun () -> _Date.Value.weekday())
    let _year                                      = triv (fun () -> _Date.Value.year())
    let _Year                                      = triv (fun () -> _Date.Value.Year)
    do this.Bind(_Date)
(* 
    casting 
*)
    internal new () = DateModel5(null,null,null,null,null,null,null)
    member internal this.Inject v = _Date.Value <- v
    static member Cast (p : ICell<Date>) = 
        if p :? DateModel5 then 
            p :?> DateModel5
        else
            let o = new DateModel5 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.m                                  = _m 
    member this.y                                  = _y 
    member this.h                                  = _h 
    member this.mi                                 = _mi 
    member this.s                                  = _s 
    member this.ms                                 = _ms 
    member this.CompareTo                          obj   
                                                   = _CompareTo obj 
    member this.Day                                = _Day
    member this.DayOfWeek                          = _DayOfWeek
    member this.DayOfYear                          = _DayOfYear
    member this.Equals                             o   
                                                   = _Equals o 
    member this.FractionOfDay                      = _fractionOfDay
    member this.FractionOfSecond                   = _fractionOfSecond
    member this.Hours                              = _hours
    member this.Milliseconds                       = _milliseconds
    member this.Minutes                            = _minutes
    member this.Month                              = _month
    member this.Month1                             = _Month
    member this.Seconds                            = _seconds
    member this.SerialNumber                       = _serialNumber
    member this.ToLongDateString                   = _ToLongDateString
    member this.ToShortDateString                  = _ToShortDateString
    member this.ToString                           = _ToString
    member this.ToString1                          provider   
                                                   = _ToString1 provider 
    member this.ToString2                          format provider   
                                                   = _ToString2 format provider 
    member this.ToString3                          format   
                                                   = _ToString3 format 
    member this.Weekday                            = _weekday
    member this.Year                               = _year
    member this.Year1                              = _Year
