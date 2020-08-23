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
  The day counter is usually obtained from the inflation term structure that the inflation index uses for forecasting. There is no gearing or spread because these are relevant for YoY coupons but not zero inflation coupons.  inflation indices do not contain day counters or calendars.

  </summary> *)
[<AutoSerializable(true)>]
type InflationCouponModel
    ( paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , index                                        : ICell<InflationIndex>
    , observationLag                               : ICell<Period>
    , dayCounter                                   : ICell<DayCounter>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , exCouponDate                                 : ICell<Date>
    ) as this =

    inherit Model<InflationCoupon> ()
(*
    Parameters
*)
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _index                                     = index
    let _observationLag                            = observationLag
    let _dayCounter                                = dayCounter
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _exCouponDate                              = exCouponDate
(*
    Functions
*)
    let _InflationCoupon                           = cell (fun () -> new InflationCoupon (paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, observationLag.Value, dayCounter.Value, refPeriodStart.Value, refPeriodEnd.Value, exCouponDate.Value))
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> _InflationCoupon.Value.accruedAmount(d.Value))
    let _amount                                    = triv (fun () -> _InflationCoupon.Value.amount())
    let _dayCounter                                = triv (fun () -> _InflationCoupon.Value.dayCounter())
    let _fixingDate                                = triv (fun () -> _InflationCoupon.Value.fixingDate())
    let _fixingDays                                = triv (fun () -> _InflationCoupon.Value.fixingDays())
    let _index                                     = triv (fun () -> _InflationCoupon.Value.index())
    let _indexFixing                               = triv (fun () -> _InflationCoupon.Value.indexFixing())
    let _observationLag                            = triv (fun () -> _InflationCoupon.Value.observationLag())
    let _price                                     (discountingCurve : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _InflationCoupon.Value.price(discountingCurve.Value))
    let _pricer                                    = triv (fun () -> _InflationCoupon.Value.pricer())
    let _rate                                      = triv (fun () -> _InflationCoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<InflationCouponPricer>)   
                                                   = triv (fun () -> _InflationCoupon.Value.setPricer(pricer.Value)
                                                                     _InflationCoupon.Value)
    let _update                                    = triv (fun () -> _InflationCoupon.Value.update()
                                                                     _InflationCoupon.Value)
    let _accrualDays                               = triv (fun () -> _InflationCoupon.Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> _InflationCoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> _InflationCoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> _InflationCoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> _InflationCoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> _InflationCoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> _InflationCoupon.Value.date())
    let _exCouponDate                              = triv (fun () -> _InflationCoupon.Value.exCouponDate())
    let _nominal                                   = triv (fun () -> _InflationCoupon.Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> _InflationCoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> _InflationCoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _InflationCoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _InflationCoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _InflationCoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _InflationCoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _InflationCoupon.Value.accept(v.Value)
                                                                     _InflationCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _InflationCoupon.Value.registerWith(handler.Value)
                                                                     _InflationCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _InflationCoupon.Value.unregisterWith(handler.Value)
                                                                     _InflationCoupon.Value)
    do this.Bind(_InflationCoupon)

(* 
    Externally visible/bindable properties
*)
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.index                              = _index 
    member this.observationLag                     = _observationLag 
    member this.dayCounter                         = _dayCounter 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.exCouponDate                       = _exCouponDate 
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
