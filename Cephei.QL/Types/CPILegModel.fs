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
  Also allowing for the inflated notional at the end... especially if there is only one date in the schedule. If a fixedRate is zero you get a FixedRateCoupon, otherwise you get a ZeroInflationCoupon.  payoff is: spread + fixedRate x index

  </summary> *)
[<AutoSerializable(true)>]
type CPILegModel
    ( schedule                                     : ICell<Schedule>
    , index                                        : ICell<ZeroInflationIndex>
    , baseCPI                                      : ICell<double>
    , observationLag                               : ICell<Period>
    ) as this =

    inherit Model<CPILeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _index                                     = index
    let _baseCPI                                   = baseCPI
    let _observationLag                            = observationLag
(*
    Functions
*)
    let mutable
        _CPILeg                                    = cell (fun () -> new CPILeg (schedule.Value, index.Value, baseCPI.Value, observationLag.Value))
    let _value                                     = triv (fun () -> _CPILeg.Value.value())
    let _withCaps                                  (cap : ICell<double>)   
                                                   = triv (fun () -> _CPILeg.Value.withCaps(cap.Value))
    let _withCaps1                                 (cap : ICell<Generic.List<Nullable<double>>>)   
                                                   = triv (fun () -> _CPILeg.Value.withCaps(cap.Value))
    let _withExCouponPeriod                        (period : ICell<Period>) (cal : ICell<Calendar>) (convention : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _CPILeg.Value.withExCouponPeriod(period.Value, cal.Value, convention.Value, endOfMonth.Value))
    let _withFixedRates                            (fixedRate : ICell<double>)   
                                                   = triv (fun () -> _CPILeg.Value.withFixedRates(fixedRate.Value))
    let _withFixedRates1                           (fixedRates : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _CPILeg.Value.withFixedRates(fixedRates.Value))
    let _withFixingDays                            (fixingDays : ICell<Generic.List<int>>)   
                                                   = triv (fun () -> _CPILeg.Value.withFixingDays(fixingDays.Value))
    let _withFixingDays1                           (fixingDays : ICell<int>)   
                                                   = triv (fun () -> _CPILeg.Value.withFixingDays(fixingDays.Value))
    let _withFloors                                (floors : ICell<Generic.List<Nullable<double>>>)   
                                                   = triv (fun () -> _CPILeg.Value.withFloors(floors.Value))
    let _withFloors1                               (floors : ICell<double>)   
                                                   = triv (fun () -> _CPILeg.Value.withFloors(floors.Value))
    let _withObservationInterpolation              (interp : ICell<InterpolationType>)   
                                                   = triv (fun () -> _CPILeg.Value.withObservationInterpolation(interp.Value))
    let _withPaymentCalendar                       (cal : ICell<Calendar>)   
                                                   = triv (fun () -> _CPILeg.Value.withPaymentCalendar(cal.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _CPILeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withSpreads                               (spreads : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _CPILeg.Value.withSpreads(spreads.Value))
    let _withSpreads1                              (spread : ICell<double>)   
                                                   = triv (fun () -> _CPILeg.Value.withSpreads(spread.Value))
    let _withSubtractInflationNominal              (growthOnly : ICell<bool>)   
                                                   = triv (fun () -> _CPILeg.Value.withSubtractInflationNominal(growthOnly.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = triv (fun () -> _CPILeg.Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _CPILeg.Value.withNotionals(notionals.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _CPILeg.Value.withPaymentAdjustment(convention.Value))
    do this.Bind(_CPILeg)
(* 
    casting 
*)
    internal new () = new CPILegModel(null,null,null,null)
    member internal this.Inject v = _CPILeg <- v
    static member Cast (p : ICell<CPILeg>) = 
        if p :? CPILegModel then 
            p :?> CPILegModel
        else
            let o = new CPILegModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.baseCPI                            = _baseCPI 
    member this.observationLag                     = _observationLag 
    member this.Value                              = _value
    member this.WithCaps                           cap   
                                                   = _withCaps cap 
    member this.WithCaps1                          cap   
                                                   = _withCaps1 cap 
    member this.WithExCouponPeriod                 period cal convention endOfMonth   
                                                   = _withExCouponPeriod period cal convention endOfMonth 
    member this.WithFixedRates                     fixedRate   
                                                   = _withFixedRates fixedRate 
    member this.WithFixedRates1                    fixedRates   
                                                   = _withFixedRates1 fixedRates 
    member this.WithFixingDays                     fixingDays   
                                                   = _withFixingDays fixingDays 
    member this.WithFixingDays1                    fixingDays   
                                                   = _withFixingDays1 fixingDays 
    member this.WithFloors                         floors   
                                                   = _withFloors floors 
    member this.WithFloors1                        floors   
                                                   = _withFloors1 floors 
    member this.WithObservationInterpolation       interp   
                                                   = _withObservationInterpolation interp 
    member this.WithPaymentCalendar                cal   
                                                   = _withPaymentCalendar cal 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSpreads                        spreads   
                                                   = _withSpreads spreads 
    member this.WithSpreads1                       spread   
                                                   = _withSpreads1 spread 
    member this.WithSubtractInflationNominal       growthOnly   
                                                   = _withSubtractInflationNominal growthOnly 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
