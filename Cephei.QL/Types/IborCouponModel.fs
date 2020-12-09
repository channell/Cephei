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
Coupon paying a Libor-type index

  </summary> *)
[<AutoSerializable(true)>]
type IborCouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , iborIndex                                    : ICell<IborIndex>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , isInArrears                                  : ICell<bool>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<IborCoupon> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _iborIndex                                 = iborIndex
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _dayCounter                                = dayCounter
    let _isInArrears                               = isInArrears
(*
    Functions
*)
    let mutable
        _IborCoupon                                = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new IborCoupon (paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, fixingDays.Value, iborIndex.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))))
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<InterestRateIndex>) (gearing : ICell<double>) (spread : ICell<double>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _iborIndex                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.iborIndex())
    let _indexFixing                               = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.indexFixing())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.adjustedFixing)
    let _amount                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.amount())
    let _convexityAdjustment                       = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.convexityAdjustment())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.dayCounter())
    let _fixingDate                                = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.fixingDate())
    let _fixingDays                                = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.fixingDays)
    let _gearing                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.gearing())
    let _index                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.index())
    let _isInArrears                               = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.pricer())
    let _rate                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.setPricer(pricer.Value)
                                                                     _IborCoupon.Value)
    let _spread                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.spread())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.update()
                                                                     _IborCoupon.Value)
    let _accrualDays                               = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.date())
    let _exCouponDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.exCouponDate())
    let _nominal                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accept(v.Value)
                                                                     _IborCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.registerWith(handler.Value)
                                                                     _IborCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.unregisterWith(handler.Value)
                                                                     _IborCoupon.Value)
    do this.Bind(_IborCoupon)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new IborCouponModel(null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _IborCoupon <- v
    static member Cast (p : ICell<IborCoupon>) = 
        if p :? IborCouponModel then 
            p :?> IborCouponModel
        else
            let o = new IborCouponModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.iborIndex                          = _iborIndex 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.dayCounter                         = _dayCounter 
    member this.isInArrears                        = _isInArrears 
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.IborIndex                          = _iborIndex
    member this.IndexFixing                        = _indexFixing
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
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
(* <summary>
Coupon paying a Libor-type index

  </summary> *)
[<AutoSerializable(true)>]
type IborCouponModel1
    ( evaluationDate                               : ICell<Date>
    ) as this =
    inherit Model<IborCoupon> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
(*
    Functions
*)
    let mutable
        _IborCoupon                                = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new IborCoupon ())))
    let _factory                                   (nominal : ICell<double>) (paymentDate : ICell<Date>) (startDate : ICell<Date>) (endDate : ICell<Date>) (fixingDays : ICell<int>) (index : ICell<InterestRateIndex>) (gearing : ICell<double>) (spread : ICell<double>) (refPeriodStart : ICell<Date>) (refPeriodEnd : ICell<Date>) (dayCounter : ICell<DayCounter>) (isInArrears : ICell<bool>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.factory(nominal.Value, paymentDate.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, dayCounter.Value, isInArrears.Value))
    let _iborIndex                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.iborIndex())
    let _indexFixing                               = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.indexFixing())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.adjustedFixing)
    let _amount                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.amount())
    let _convexityAdjustment                       = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.convexityAdjustment())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.dayCounter())
    let _fixingDate                                = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.fixingDate())
    let _fixingDays                                = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.fixingDays)
    let _gearing                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.gearing())
    let _index                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.index())
    let _isInArrears                               = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.pricer())
    let _rate                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.setPricer(pricer.Value)
                                                                     _IborCoupon.Value)
    let _spread                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.spread())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.update()
                                                                     _IborCoupon.Value)
    let _accrualDays                               = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.date())
    let _exCouponDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.exCouponDate())
    let _nominal                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.accept(v.Value)
                                                                     _IborCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.registerWith(handler.Value)
                                                                     _IborCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _IborCoupon).Value.unregisterWith(handler.Value)
                                                                     _IborCoupon.Value)
    do this.Bind(_IborCoupon)
(* 
    casting 
*)
    
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new IborCouponModel1(null)
    member internal this.Inject v = _IborCoupon <- v
    static member Cast (p : ICell<IborCoupon>) = 
        if p :? IborCouponModel1 then 
            p :?> IborCouponModel1
        else
            let o = new IborCouponModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears   
                                                   = _factory nominal paymentDate startDate endDate fixingDays index gearing spread refPeriodStart refPeriodEnd dayCounter isInArrears 
    member this.IborIndex                          = _iborIndex
    member this.IndexFixing                        = _indexFixing
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
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
