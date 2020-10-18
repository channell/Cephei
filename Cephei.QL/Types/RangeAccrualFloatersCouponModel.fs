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
type RangeAccrualFloatersCouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , index                                        : ICell<IborIndex>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , dayCounter                                   : ICell<DayCounter>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , observationsSchedule                         : ICell<Schedule>
    , lowerTrigger                                 : ICell<double>
    , upperTrigger                                 : ICell<double>
    ) as this =

    inherit Model<RangeAccrualFloatersCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _index                                     = index
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _dayCounter                                = dayCounter
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _observationsSchedule                      = observationsSchedule
    let _lowerTrigger                              = lowerTrigger
    let _upperTrigger                              = upperTrigger
(*
    Functions
*)
    let mutable
        _RangeAccrualFloatersCoupon                = cell (fun () -> new RangeAccrualFloatersCoupon (paymentDate.Value, nominal.Value, index.Value, startDate.Value, endDate.Value, fixingDays.Value, dayCounter.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, observationsSchedule.Value, lowerTrigger.Value, upperTrigger.Value))
    let _endTime                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.endTime())
    let _lowerTrigger                              = triv (fun () -> _RangeAccrualFloatersCoupon.Value.lowerTrigger())
    let _observationDates                          = triv (fun () -> _RangeAccrualFloatersCoupon.Value.observationDates())
    let _observationsNo                            = triv (fun () -> _RangeAccrualFloatersCoupon.Value.observationsNo())
    let _observationsSchedule                      = triv (fun () -> _RangeAccrualFloatersCoupon.Value.observationsSchedule())
    let _observationTimes                          = triv (fun () -> _RangeAccrualFloatersCoupon.Value.observationTimes())
    let _priceWithoutOptionality                   (discountCurve : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.priceWithoutOptionality(discountCurve.Value))
    let _startTime                                 = triv (fun () -> _RangeAccrualFloatersCoupon.Value.startTime())
    let _upperTrigger                              = triv (fun () -> _RangeAccrualFloatersCoupon.Value.upperTrigger())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> _RangeAccrualFloatersCoupon.Value.adjustedFixing)
    let _amount                                    = triv (fun () -> _RangeAccrualFloatersCoupon.Value.amount())
    let _convexityAdjustment                       = triv (fun () -> _RangeAccrualFloatersCoupon.Value.convexityAdjustment())
    let _dayCounter                                = triv (fun () -> _RangeAccrualFloatersCoupon.Value.dayCounter())
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<InterestRateIndex>) (gearing : ICell<double>) (spread : ICell<double>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _fixingDate                                = triv (fun () -> _RangeAccrualFloatersCoupon.Value.fixingDate())
    let _fixingDays                                = triv (fun () -> _RangeAccrualFloatersCoupon.Value.fixingDays)
    let _gearing                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.gearing())
    let _index                                     = triv (fun () -> _RangeAccrualFloatersCoupon.Value.index())
    let _indexFixing                               = triv (fun () -> _RangeAccrualFloatersCoupon.Value.indexFixing())
    let _isInArrears                               = triv (fun () -> _RangeAccrualFloatersCoupon.Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> _RangeAccrualFloatersCoupon.Value.pricer())
    let _rate                                      = triv (fun () -> _RangeAccrualFloatersCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.setPricer(pricer.Value)
                                                                     _RangeAccrualFloatersCoupon.Value)
    let _spread                                    = triv (fun () -> _RangeAccrualFloatersCoupon.Value.spread())
    let _update                                    = triv (fun () -> _RangeAccrualFloatersCoupon.Value.update()
                                                                     _RangeAccrualFloatersCoupon.Value)
    let _accrualDays                               = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> _RangeAccrualFloatersCoupon.Value.date())
    let _exCouponDate                              = triv (fun () -> _RangeAccrualFloatersCoupon.Value.exCouponDate())
    let _nominal                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> _RangeAccrualFloatersCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> _RangeAccrualFloatersCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.accept(v.Value)
                                                                     _RangeAccrualFloatersCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.registerWith(handler.Value)
                                                                     _RangeAccrualFloatersCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RangeAccrualFloatersCoupon.Value.unregisterWith(handler.Value)
                                                                     _RangeAccrualFloatersCoupon.Value)
    do this.Bind(_RangeAccrualFloatersCoupon)
(* 
    casting 
*)
    internal new () = new RangeAccrualFloatersCouponModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _RangeAccrualFloatersCoupon <- v
    static member Cast (p : ICell<RangeAccrualFloatersCoupon>) = 
        if p :? RangeAccrualFloatersCouponModel then 
            p :?> RangeAccrualFloatersCouponModel
        else
            let o = new RangeAccrualFloatersCouponModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.index                              = _index 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.dayCounter                         = _dayCounter 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.observationsSchedule               = _observationsSchedule 
    member this.lowerTrigger                       = _lowerTrigger 
    member this.upperTrigger                       = _upperTrigger 
    member this.EndTime                            = _endTime
    member this.LowerTrigger                       = _lowerTrigger
    member this.ObservationDates                   = _observationDates
    member this.ObservationsNo                     = _observationsNo
    member this.ObservationsSchedule               = _observationsSchedule
    member this.ObservationTimes                   = _observationTimes
    member this.PriceWithoutOptionality            discountCurve   
                                                   = _priceWithoutOptionality discountCurve 
    member this.StartTime                          = _startTime
    member this.UpperTrigger                       = _upperTrigger
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.DayCounter                         = _dayCounter
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.Spread                             = _spread
    member this.Update                             = _update
    member this.AccrualDays                        = _accrualDays
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualPeriod                      = _accrualPeriod
    member this.AccrualStartDate                   = _accrualStartDate
    member this.AccruedDays                        d   
                                                   = _accruedDays d 
    member this.AccruedPeriod                      d   
                                                   = _accruedPeriod d 
    member this.Date                               = _date
    member this.ExCouponDate                       = _exCouponDate
    member this.Nominal                            = _nominal
    member this.ReferencePeriodEnd                 = _referencePeriodEnd
    member this.ReferencePeriodStart               = _referencePeriodStart
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
