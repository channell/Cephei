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
  Actual/360 day count convention, also known as "Act/360", or "A/360".

  </summary> *)
[<AutoSerializable(true)>]
type Actual360Model
    ( c                                            : ICell<bool>
    ) as this =

    inherit Model<Actual360> ()
(*
    Parameters
*)
    let _c                                         = c
(*
    Functions
*)
    let _Actual360                                 = cell (fun () -> new Actual360 (c.Value))
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _Actual360.Value.dayCount(d1.Value, d2.Value))
    let _dayCounter                                = triv (fun () -> _Actual360.Value.dayCounter)
    let _empty                                     = triv (fun () -> _Actual360.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Actual360.Value.Equals(o.Value))
    let _name                                      = triv (fun () -> _Actual360.Value.name())
    let _ToString                                  = triv (fun () -> _Actual360.Value.ToString())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>)   
                                                   = triv (fun () -> _Actual360.Value.yearFraction(d1.Value, d2.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _yearFraction1                             (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _Actual360.Value.yearFraction(d1.Value, d2.Value))
    do this.Bind(_Actual360)
(* 
    casting 
*)
    internal new () = new Actual360Model(null)
    member internal this.Inject v = _Actual360.Value <- v
    static member Cast (p : ICell<Actual360>) = 
        if p :? Actual360Model then 
            p :?> Actual360Model
        else
            let o = new Actual360Model ()
            o.Inject p.Value
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
