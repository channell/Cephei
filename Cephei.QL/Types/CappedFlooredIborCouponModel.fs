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

need by CashFlowVectors
  </summary> *)
[<AutoSerializable(true)>]
type CappedFlooredIborCouponModel
    () as this =
    inherit Model<CappedFlooredIborCoupon> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _CappedFlooredIborCoupon                   = cell (fun () -> new CappedFlooredIborCoupon ())
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<IborIndex>) (gearing : ICell<double>) (spread : ICell<double>) (cap : ICell<Nullable<double>>) (floor : ICell<Nullable<double>>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, cap.Value, floor.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _cap                                       = triv (fun () -> _CappedFlooredIborCoupon.Value.cap())
    let _convexityAdjustment                       = triv (fun () -> _CappedFlooredIborCoupon.Value.convexityAdjustment())
    let _effectiveCap                              = triv (fun () -> _CappedFlooredIborCoupon.Value.effectiveCap())
    let _effectiveFloor                            = triv (fun () -> _CappedFlooredIborCoupon.Value.effectiveFloor())
    let _floor                                     = triv (fun () -> _CappedFlooredIborCoupon.Value.floor())
    let _isCapped                                  = triv (fun () -> _CappedFlooredIborCoupon.Value.isCapped())
    let _isFloored                                 = triv (fun () -> _CappedFlooredIborCoupon.Value.isFloored())
    let _rate                                      = triv (fun () -> _CappedFlooredIborCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.setPricer(pricer.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> _CappedFlooredIborCoupon.Value.adjustedFixing)
    let _amount                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.amount())
    let _dayCounter                                = triv (fun () -> _CappedFlooredIborCoupon.Value.dayCounter())
    let _fixingDate                                = triv (fun () -> _CappedFlooredIborCoupon.Value.fixingDate())
    let _fixingDays                                = triv (fun () -> _CappedFlooredIborCoupon.Value.fixingDays)
    let _gearing                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.gearing())
    let _index                                     = triv (fun () -> _CappedFlooredIborCoupon.Value.index())
    let _indexFixing                               = triv (fun () -> _CappedFlooredIborCoupon.Value.indexFixing())
    let _isInArrears                               = triv (fun () -> _CappedFlooredIborCoupon.Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.pricer())
    let _spread                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.spread())
    let _update                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.update()
                                                                     _CappedFlooredIborCoupon.Value)
    let _accrualDays                               = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> _CappedFlooredIborCoupon.Value.date())
    let _exCouponDate                              = triv (fun () -> _CappedFlooredIborCoupon.Value.exCouponDate())
    let _nominal                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> _CappedFlooredIborCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> _CappedFlooredIborCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accept(v.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.registerWith(handler.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.unregisterWith(handler.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    do this.Bind(_CappedFlooredIborCoupon)
(* 
    casting 
*)
    
    member internal this.Inject v = _CappedFlooredIborCoupon.Value <- v
    static member Cast (p : ICell<CappedFlooredIborCoupon>) = 
        if p :? CappedFlooredIborCouponModel then 
            p :?> CappedFlooredIborCouponModel
        else
            let o = new CappedFlooredIborCouponModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread cap floor refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread cap floor refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.Cap                                = _cap
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.EffectiveCap                       = _effectiveCap
    member this.EffectiveFloor                     = _effectiveFloor
    member this.Floor                              = _floor
    member this.IsCapped                           = _isCapped
    member this.IsFloored                          = _isFloored
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type CappedFlooredIborCouponModel1
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , index                                        : ICell<IborIndex>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , cap                                          : ICell<Nullable<double>>
    , floor                                        : ICell<Nullable<double>>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , isInArrears                                  : ICell<bool>
    ) as this =

    inherit Model<CappedFlooredIborCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _index                                     = index
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _cap                                       = cap
    let _floor                                     = floor
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _dayCounter                                = dayCounter
    let _isInArrears                               = isInArrears
(*
    Functions
*)
    let _CappedFlooredIborCoupon                   = cell (fun () -> new CappedFlooredIborCoupon (paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, cap.Value, floor.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<IborIndex>) (gearing : ICell<double>) (spread : ICell<double>) (cap : ICell<Nullable<double>>) (floor : ICell<Nullable<double>>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, cap.Value, floor.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _cap                                       = triv (fun () -> _CappedFlooredIborCoupon.Value.cap())
    let _convexityAdjustment                       = triv (fun () -> _CappedFlooredIborCoupon.Value.convexityAdjustment())
    let _effectiveCap                              = triv (fun () -> _CappedFlooredIborCoupon.Value.effectiveCap())
    let _effectiveFloor                            = triv (fun () -> _CappedFlooredIborCoupon.Value.effectiveFloor())
    let _floor                                     = triv (fun () -> _CappedFlooredIborCoupon.Value.floor())
    let _isCapped                                  = triv (fun () -> _CappedFlooredIborCoupon.Value.isCapped())
    let _isFloored                                 = triv (fun () -> _CappedFlooredIborCoupon.Value.isFloored())
    let _rate                                      = triv (fun () -> _CappedFlooredIborCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.setPricer(pricer.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> _CappedFlooredIborCoupon.Value.adjustedFixing)
    let _amount                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.amount())
    let _dayCounter                                = triv (fun () -> _CappedFlooredIborCoupon.Value.dayCounter())
    let _fixingDate                                = triv (fun () -> _CappedFlooredIborCoupon.Value.fixingDate())
    let _fixingDays                                = triv (fun () -> _CappedFlooredIborCoupon.Value.fixingDays)
    let _gearing                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.gearing())
    let _index                                     = triv (fun () -> _CappedFlooredIborCoupon.Value.index())
    let _indexFixing                               = triv (fun () -> _CappedFlooredIborCoupon.Value.indexFixing())
    let _isInArrears                               = triv (fun () -> _CappedFlooredIborCoupon.Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.pricer())
    let _spread                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.spread())
    let _update                                    = triv (fun () -> _CappedFlooredIborCoupon.Value.update()
                                                                     _CappedFlooredIborCoupon.Value)
    let _accrualDays                               = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> _CappedFlooredIborCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> _CappedFlooredIborCoupon.Value.date())
    let _exCouponDate                              = triv (fun () -> _CappedFlooredIborCoupon.Value.exCouponDate())
    let _nominal                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> _CappedFlooredIborCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> _CappedFlooredIborCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.accept(v.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.registerWith(handler.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CappedFlooredIborCoupon.Value.unregisterWith(handler.Value)
                                                                     _CappedFlooredIborCoupon.Value)
    do this.Bind(_CappedFlooredIborCoupon)
(* 
    casting 
*)
    internal new () = new CappedFlooredIborCouponModel1(null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CappedFlooredIborCoupon.Value <- v
    static member Cast (p : ICell<CappedFlooredIborCoupon>) = 
        if p :? CappedFlooredIborCouponModel1 then 
            p :?> CappedFlooredIborCouponModel1
        else
            let o = new CappedFlooredIborCouponModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.index                              = _index 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.cap                                = _cap 
    member this.floor                              = _floor 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.dayCounter                         = _dayCounter 
    member this.isInArrears                        = _isInArrears 
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread cap floor refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread cap floor refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.Cap                                = _cap
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.EffectiveCap                       = _effectiveCap
    member this.EffectiveFloor                     = _effectiveFloor
    member this.Floor                              = _floor
    member this.IsCapped                           = _isCapped
    member this.IsFloored                          = _isFloored
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
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
