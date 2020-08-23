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
  %Coupon paying a YoY-inflation type index

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationCouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , yoyIndex                                     : ICell<YoYInflationIndex>
    , observationLag                               : ICell<Period>
    , dayCounter                                   : ICell<DayCounter>
    , gearing                                      : ICell<double>
    , spread                                       : ICell<double>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    ) as this =

    inherit Model<YoYInflationCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _yoyIndex                                  = yoyIndex
    let _observationLag                            = observationLag
    let _dayCounter                                = dayCounter
    let _gearing                                   = gearing
    let _spread                                    = spread
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
(*
    Functions
*)
    let _YoYInflationCoupon                        = cell (fun () -> new YoYInflationCoupon (paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, fixingDays.Value, yoyIndex.Value, observationLag.Value, dayCounter.Value, gearing.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _adjustedFixing                            = triv (fun () -> _YoYInflationCoupon.Value.adjustedFixing())
    let _gearing                                   = triv (fun () -> _YoYInflationCoupon.Value.gearing())
    let _spread                                    = triv (fun () -> _YoYInflationCoupon.Value.spread())
    let _yoyIndex                                  = triv (fun () -> _YoYInflationCoupon.Value.yoyIndex())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.accruedAmount(d.Value))
    let _amount                                    = triv (fun () -> _YoYInflationCoupon.Value.amount())
    let _dayCounter                                = triv (fun () -> _YoYInflationCoupon.Value.dayCounter())
    let _fixingDate                                = triv (fun () -> _YoYInflationCoupon.Value.fixingDate())
    let _fixingDays                                = triv (fun () -> _YoYInflationCoupon.Value.fixingDays())
    let _index                                     = triv (fun () -> _YoYInflationCoupon.Value.index())
    let _indexFixing                               = triv (fun () -> _YoYInflationCoupon.Value.indexFixing())
    let _observationLag                            = triv (fun () -> _YoYInflationCoupon.Value.observationLag())
    let _price                                     (discountingCurve : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.price(discountingCurve.Value))
    let _pricer                                    = triv (fun () -> _YoYInflationCoupon.Value.pricer())
    let _rate                                      = triv (fun () -> _YoYInflationCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<InflationCouponPricer>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.setPricer(pricer.Value)
                                                                     _YoYInflationCoupon.Value)
    let _update                                    = triv (fun () -> _YoYInflationCoupon.Value.update()
                                                                     _YoYInflationCoupon.Value)
    let _accrualDays                               = triv (fun () -> _YoYInflationCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> _YoYInflationCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> _YoYInflationCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> _YoYInflationCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> _YoYInflationCoupon.Value.date())
    let _exCouponDate                              = triv (fun () -> _YoYInflationCoupon.Value.exCouponDate())
    let _nominal                                   = triv (fun () -> _YoYInflationCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> _YoYInflationCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> _YoYInflationCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.accept(v.Value)
                                                                     _YoYInflationCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.registerWith(handler.Value)
                                                                     _YoYInflationCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YoYInflationCoupon.Value.unregisterWith(handler.Value)
                                                                     _YoYInflationCoupon.Value)
    do this.Bind(_YoYInflationCoupon)

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.yoyIndex                           = _yoyIndex 
    member this.observationLag                     = _observationLag 
    member this.dayCounter                         = _dayCounter 
    member this.gearing                            = _gearing 
    member this.spread                             = _spread 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Gearing                            = _gearing
    member this.Spread                             = _spread
    member this.YoyIndex                           = _yoyIndex
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.ObservationLag                     = _observationLag
    member this.Price                              discountingCurve   
                                                   = _price discountingCurve 
    member this.Pricer                             = _pricer
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
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
