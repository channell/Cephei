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
type AverageBMACouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , index                                        : ICell<BMAIndex>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<AverageBMACoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _index                                     = index
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _AverageBMACoupon                          = cell (fun () -> new AverageBMACoupon (paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value))
    let _convexityAdjustment                       = triv (fun () -> _AverageBMACoupon.Value.convexityAdjustment())
    let _fixingDate                                = triv (fun () -> _AverageBMACoupon.Value.fixingDate())
    let _fixingDates                               = triv (fun () -> _AverageBMACoupon.Value.fixingDates())
    let _indexFixing                               = triv (fun () -> _AverageBMACoupon.Value.indexFixing())
    let _indexFixings                              = triv (fun () -> _AverageBMACoupon.Value.indexFixings())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> _AverageBMACoupon.Value.adjustedFixing)
    let _amount                                    = triv (fun () -> _AverageBMACoupon.Value.amount())
    let _dayCounter                                = triv (fun () -> _AverageBMACoupon.Value.dayCounter())
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<InterestRateIndex>) (gearing : ICell<double>) (spread : ICell<double>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _fixingDays                                = triv (fun () -> _AverageBMACoupon.Value.fixingDays)
    let _gearing                                   = triv (fun () -> _AverageBMACoupon.Value.gearing())
    let _index                                     = triv (fun () -> _AverageBMACoupon.Value.index())
    let _isInArrears                               = triv (fun () -> _AverageBMACoupon.Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> _AverageBMACoupon.Value.pricer())
    let _rate                                      = triv (fun () -> _AverageBMACoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.setPricer(pricer.Value)
                                                                     _AverageBMACoupon.Value)
    let _spread                                    = triv (fun () -> _AverageBMACoupon.Value.spread())
    let _update                                    = triv (fun () -> _AverageBMACoupon.Value.update()
                                                                     _AverageBMACoupon.Value)
    let _accrualDays                               = triv (fun () -> _AverageBMACoupon.Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> _AverageBMACoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> _AverageBMACoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> _AverageBMACoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> _AverageBMACoupon.Value.date())
    let _exCouponDate                              = triv (fun () -> _AverageBMACoupon.Value.exCouponDate())
    let _nominal                                   = triv (fun () -> _AverageBMACoupon.Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> _AverageBMACoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> _AverageBMACoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.accept(v.Value)
                                                                     _AverageBMACoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.registerWith(handler.Value)
                                                                     _AverageBMACoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AverageBMACoupon.Value.unregisterWith(handler.Value)
                                                                     _AverageBMACoupon.Value)
    do this.Bind(_AverageBMACoupon)
(* 
    casting 
*)
    internal new () = new AverageBMACouponModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _AverageBMACoupon.Value <- v
    static member Cast (p : ICell<AverageBMACoupon>) = 
        if p :? AverageBMACouponModel then 
            p :?> AverageBMACouponModel
        else
            let o = new AverageBMACouponModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.index                              = _index 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.dayCounter                         = _dayCounter 
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.FixingDate                         = _fixingDate
    member this.FixingDates                        = _fixingDates
    member this.IndexFixing                        = _indexFixing
    member this.IndexFixings                       = _indexFixings
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
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
