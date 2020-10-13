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
  helper class building a sequence of overnight coupons

  </summary> *)
[<AutoSerializable(true)>]
type OvernightLegModel
    ( schedule                                     : ICell<Schedule>
    , overnightIndex                               : ICell<OvernightIndex>
    ) as this =

    inherit Model<OvernightLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _overnightIndex                            = overnightIndex
(*
    Functions
*)
    let _OvernightLeg                              = cell (fun () -> new OvernightLeg (schedule.Value, overnightIndex.Value))
    let _value                                     = triv (fun () -> _OvernightLeg.Value.value())
    let _withGearings                              (gearings : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withGearings(gearings.Value))
    let _withGearings1                             (gearing : ICell<double>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withGearings(gearing.Value))
    let _withNotionals                             (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withNotionals(notionals.Value))
    let _withNotionals1                            (notional : ICell<double>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withNotionals(notional.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withPaymentAdjustment(convention.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withSpreads                               (spread : ICell<double>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withSpreads(spread.Value))
    let _withSpreads1                              (spreads : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _OvernightLeg.Value.withSpreads(spreads.Value))
    do this.Bind(_OvernightLeg)
(* 
    casting 
*)
    internal new () = new OvernightLegModel(null,null)
    member internal this.Inject v = _OvernightLeg.Value <- v
    static member Cast (p : ICell<OvernightLeg>) = 
        if p :? OvernightLegModel then 
            p :?> OvernightLegModel
        else
            let o = new OvernightLegModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.overnightIndex                     = _overnightIndex 
    member this.Value                              = _value
    member this.WithGearings                       gearings   
                                                   = _withGearings gearings 
    member this.WithGearings1                      gearing   
                                                   = _withGearings1 gearing 
    member this.WithNotionals                      notionals   
                                                   = _withNotionals notionals 
    member this.WithNotionals1                     notional   
                                                   = _withNotionals1 notional 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSpreads                        spread   
                                                   = _withSpreads spread 
    member this.WithSpreads1                       spreads   
                                                   = _withSpreads1 spreads 
