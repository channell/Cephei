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
  Helper class building a sequence of capped/floored yoy inflation coupons   payoff is: spread + gearing x index

  </summary> *)
[<AutoSerializable(true)>]
type yoyInflationLegModel
    ( schedule                                     : ICell<Schedule>
    , cal                                          : ICell<Calendar>
    , index                                        : ICell<YoYInflationIndex>
    , observationLag                               : ICell<Period>
    ) as this =

    inherit Model<yoyInflationLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _cal                                       = cal
    let _index                                     = index
    let _observationLag                            = observationLag
(*
    Functions
*)
    let _yoyInflationLeg                           = cell (fun () -> new yoyInflationLeg (schedule.Value, cal.Value, index.Value, observationLag.Value))
    let _value                                     = triv (fun () -> _yoyInflationLeg.Value.value())
    let _withCaps                                  (cap : ICell<double>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withCaps(cap.Value))
    let _withCaps1                                 (caps : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withCaps(caps.Value))
    let _withFixingDays                            (fixingDays : ICell<Generic.List<int>>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withFixingDays(fixingDays.Value))
    let _withFixingDays1                           (fixingDays : ICell<int>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withFixingDays(fixingDays.Value))
    let _withFloors                                (floor : ICell<double>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withFloors(floor.Value))
    let _withFloors1                               (floors : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withFloors(floors.Value))
    let _withGearings                              (gearings : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withGearings(gearings.Value))
    let _withGearings1                             (gearing : ICell<double>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withGearings(gearing.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withSpreads                               (spread : ICell<double>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withSpreads(spread.Value))
    let _withSpreads1                              (spreads : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withSpreads(spreads.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withNotionals(notionals.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _yoyInflationLeg.Value.withPaymentAdjustment(convention.Value))
    do this.Bind(_yoyInflationLeg)
(* 
    casting 
*)
    internal new () = new yoyInflationLegModel(null,null,null,null)
    member internal this.Inject v = _yoyInflationLeg.Value <- v
    static member Cast (p : ICell<yoyInflationLeg>) = 
        if p :? yoyInflationLegModel then 
            p :?> yoyInflationLegModel
        else
            let o = new yoyInflationLegModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.cal                                = _cal 
    member this.index                              = _index 
    member this.observationLag                     = _observationLag 
    member this.Value                              = _value
    member this.WithCaps                           cap   
                                                   = _withCaps cap 
    member this.WithCaps1                          caps   
                                                   = _withCaps1 caps 
    member this.WithFixingDays                     fixingDays   
                                                   = _withFixingDays fixingDays 
    member this.WithFixingDays1                    fixingDays   
                                                   = _withFixingDays1 fixingDays 
    member this.WithFloors                         floor   
                                                   = _withFloors floor 
    member this.WithFloors1                        floors   
                                                   = _withFloors1 floors 
    member this.WithGearings                       gearings   
                                                   = _withGearings gearings 
    member this.WithGearings1                      gearing   
                                                   = _withGearings1 gearing 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSpreads                        spread   
                                                   = _withSpreads spread 
    member this.WithSpreads1                       spreads   
                                                   = _withSpreads1 spreads 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
