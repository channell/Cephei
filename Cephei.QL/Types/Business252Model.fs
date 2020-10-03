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
  Business/252 day count convention

  </summary> *)
[<AutoSerializable(true)>]
type Business252Model
    ( c                                            : ICell<Calendar>
    ) as this =

    inherit Model<Business252> ()
(*
    Parameters
*)
    let _c                                         = c
(*
    Functions
*)
    let _Business252                               = cell (fun () -> new Business252 (c.Value))
    let _dayCount                                  (d1 : ICell<Date>) (d2 : ICell<Date>)   
                                                   = triv (fun () -> _Business252.Value.dayCount(d1.Value, d2.Value))
    let _name                                      = triv (fun () -> _Business252.Value.name())
    let _yearFraction                              (d1 : ICell<Date>) (d2 : ICell<Date>) (d3 : ICell<Date>) (d4 : ICell<Date>)   
                                                   = triv (fun () -> _Business252.Value.yearFraction(d1.Value, d2.Value, d3.Value, d4.Value))
    let _dayCounter                                = triv (fun () -> _Business252.Value.dayCounter)
    let _empty                                     = triv (fun () -> _Business252.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Business252.Value.Equals(o.Value))
    let _ToString                                  = triv (fun () -> _Business252.Value.ToString())
    do this.Bind(_Business252)
(* 
    casting 
*)
    internal new () = Business252Model(null)
    member internal this.Inject v = _Business252.Value <- v
    static member Cast (p : ICell<Business252>) = 
        if p :? Business252Model then 
            p :?> Business252Model
        else
            let o = new Business252Model ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.c                                  = _c 
    member this.DayCount                           d1 d2   
                                                   = _dayCount d1 d2 
    member this.Name                               = _name
    member this.YearFraction                       d1 d2 d3 d4   
                                                   = _yearFraction d1 d2 d3 d4 
    member this.DayCounter                         = _dayCounter
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.ToString                           = _ToString
