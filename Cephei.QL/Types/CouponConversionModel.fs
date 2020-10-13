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


  </summary> *)
[<AutoSerializable(true)>]
type CouponConversionModel
    ( date                                         : ICell<DateTime>
    , rate                                         : ICell<double>
    ) as this =

    inherit Model<CouponConversion> ()
(*
    Parameters
*)
    let _date                                      = date
    let _rate                                      = rate
(*
    Functions
*)
    let _CouponConversion                          = cell (fun () -> new CouponConversion (date.Value, rate.Value))
    let _Date                                      = triv (fun () -> _CouponConversion.Value.Date)
    let _Rate                                      = triv (fun () -> _CouponConversion.Value.Rate)
    let _ToString                                  = triv (fun () -> _CouponConversion.Value.ToString())
    do this.Bind(_CouponConversion)
(* 
    casting 
*)
    internal new () = new CouponConversionModel(null,null)
    member internal this.Inject v = _CouponConversion.Value <- v
    static member Cast (p : ICell<CouponConversion>) = 
        if p :? CouponConversionModel then 
            p :?> CouponConversionModel
        else
            let o = new CouponConversionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.date                               = _date 
    member this.rate                               = _rate 
    member this.Date                               = _Date
    member this.Rate                               = _Rate
    member this.ToString                           = _ToString
