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
  The 30/360 day count can be calculated according to US, European, or Italian conventions. US (NASD) convention: if the starting date is the 31st of a  month, it becomes equal to the 30th of the same month.  If the ending date is the 31st of a month and the starting date is earlier than the 30th of a month, the ending date  becomes equal to the 1st of the next month, otherwise the ending date becomes equal to the 30th of the same month. Also known as "30/360", "360/360", or "Bond Basis"  European convention: starting dates or ending dates that occur on the 31st of a month become equal to the 30th of the same month. Also known as "30E/360", or "Eurobond Basis"  Italian convention: starting dates or ending dates that occur on February and are grater than 27 become equal to 30 for computational sake.

  </summary> *)
[<AutoSerializable(true)>]
type Thirty360Model
    ( c                                            : ICell<Thirty360.Thirty360Convention>
    ) as this =

    inherit Model<Thirty360> ()
(*
    Parameters
*)
    let _c                                         = c
(*
    Functions
*)
    let mutable
        _Thirty360                                 = make (fun () -> new Thirty360 (c.Value))
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv _Thirty360 (fun () -> _Thirty360.Value.dayCounter)
    let _empty                                     = triv _Thirty360 (fun () -> _Thirty360.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.Equals(o.Value))
    let _name                                      = triv _Thirty360 (fun () -> _Thirty360.Value.name())
    let _ToString                                  = triv _Thirty360 (fun () -> _Thirty360.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_Thirty360)
(* 
    casting 
*)
    internal new () = new Thirty360Model(null)
    member internal this.Inject v = _Thirty360 <- v
    static member Cast (p : ICell<Thirty360>) = 
        if p :? Thirty360Model then 
            p :?> Thirty360Model
        else
            let o = new Thirty360Model ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.DayCount                           d1 d2   
                                                   = _dayCount d1 d2 
    member this.DayCounter                         = _dayCounter
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Name                               = _name
    member this.ToString                           = _ToString
    member this.YearFraction                       d1 d2 refPeriodStart refPeriodEnd   
                                                   = _yearFraction d1 d2 refPeriodStart refPeriodEnd 
    member this.YearFraction1                      d1 d2   
                                                   = _yearFraction1 d1 d2 
(* <summary>
  The 30/360 day count can be calculated according to US, European, or Italian conventions. US (NASD) convention: if the starting date is the 31st of a  month, it becomes equal to the 30th of the same month.  If the ending date is the 31st of a month and the starting date is earlier than the 30th of a month, the ending date  becomes equal to the 1st of the next month, otherwise the ending date becomes equal to the 30th of the same month. Also known as "30/360", "360/360", or "Bond Basis"  European convention: starting dates or ending dates that occur on the 31st of a month become equal to the 30th of the same month. Also known as "30E/360", or "Eurobond Basis"  Italian convention: starting dates or ending dates that occur on February and are grater than 27 become equal to 30 for computational sake.

  </summary> *)
[<AutoSerializable(true)>]
type Thirty360Model1
    () as this =
    inherit Model<Thirty360> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Thirty360                                 = make (fun () -> new Thirty360 ())
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv _Thirty360 (fun () -> _Thirty360.Value.dayCounter)
    let _empty                                     = triv _Thirty360 (fun () -> _Thirty360.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.Equals(o.Value))
    let _name                                      = triv _Thirty360 (fun () -> _Thirty360.Value.name())
    let _ToString                                  = triv _Thirty360 (fun () -> _Thirty360.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _Thirty360 (fun () -> _Thirty360.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_Thirty360)
(* 
    casting 
*)
    
    member internal this.Inject v = _Thirty360 <- v
    static member Cast (p : ICell<Thirty360>) = 
        if p :? Thirty360Model1 then 
            p :?> Thirty360Model1
        else
            let o = new Thirty360Model1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.DayCount                           d1 d2   
                                                   = _dayCount d1 d2 
    member this.DayCounter                         = _dayCounter
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Name                               = _name
    member this.ToString                           = _ToString
    member this.YearFraction                       d1 d2 refPeriodStart refPeriodEnd   
                                                   = _yearFraction d1 d2 refPeriodStart refPeriodEnd 
    member this.YearFraction1                      d1 d2   
                                                   = _yearFraction1 d1 d2 
