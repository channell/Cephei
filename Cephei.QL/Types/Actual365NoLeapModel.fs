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
  "Actual/365 (No Leap)" day count convention, also known as "Act/365 (NL)", "NL/365", or "Actual/365 (JGB)".  daycounters

  </summary> *)
[<AutoSerializable(true)>]
type Actual365NoLeapModel
    () as this =
    inherit Model<Actual365NoLeap> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Actual365NoLeap                           = make (fun () -> new Actual365NoLeap ())
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.dayCounter)
    let _empty                                     = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.Equals(o.Value))
    let _name                                      = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.name())
    let _ToString                                  = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv _Actual365NoLeap (fun () -> _Actual365NoLeap.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_Actual365NoLeap)
(* 
    casting 
*)
    
    member internal this.Inject v = _Actual365NoLeap <- v
    static member Cast (p : ICell<Actual365NoLeap>) = 
        if p :? Actual365NoLeapModel then 
            p :?> Actual365NoLeapModel
        else
            let o = new Actual365NoLeapModel ()
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
