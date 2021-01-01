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
  The performance is relative to the index value on the base date.  The other inflation value is taken from the refPeriodEnd date with observation lag, so any roll/calendar etc. will be built in by the caller.  By default this is done in the InflationCoupon which uses ModifiedPreceding with fixing days assumed positive meaning earlier, i.e. always stay in same month (relative to referencePeriodEnd).  This is more sophisticated than an %IndexedCashFlow because it does date calculations itself.  We do not do any convexity adjustment for lags different to the natural ZCIIS lag that was used to create the forward inflation curve.

  </summary> *)
[<AutoSerializable(true)>]
type CPICouponModel
    ( baseCPI                                      : ICell<double>
    , paymentDate                                  : ICell<Date>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixingDays                                   : ICell<int>
    , index                                        : ICell<ZeroInflationIndex>
    , observationLag                               : ICell<Period>
    , observationInterpolation                     : ICell<InterpolationType>
    , dayCounter                                   : ICell<DayCounter>
    , fixedRate                                    : ICell<double>
    , spread                                       : ICell<double>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    , exCouponDate                                 : ICell<Date>
    ) as this =

    inherit Model<CPICoupon> ()
(*
    Parameters
*)
    let _baseCPI                                   = baseCPI
    let _paymentDate                               = paymentDate
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixingDays                                = fixingDays
    let _index                                     = index
    let _observationLag                            = observationLag
    let _observationInterpolation                  = observationInterpolation
    let _dayCounter                                = dayCounter
    let _fixedRate                                 = fixedRate
    let _spread                                    = spread
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
    let _exCouponDate                              = exCouponDate
(*
    Functions
*)
    let mutable
        _CPICoupon                                 = make (fun () -> new CPICoupon (baseCPI.Value, paymentDate.Value, nominal.Value, startDate.Value, endDate.Value, fixingDays.Value, index.Value, observationLag.Value, observationInterpolation.Value, dayCounter.Value, fixedRate.Value, spread.Value, refPeriodStart.Value, refPeriodEnd.Value, exCouponDate.Value))
    let _adjustedFixing                            = triv _CPICoupon (fun () -> _CPICoupon.Value.adjustedFixing())
    let _baseCPI                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.baseCPI())
    let _cpiIndex                                  = triv _CPICoupon (fun () -> _CPICoupon.Value.cpiIndex())
    let _fixedRate                                 = triv _CPICoupon (fun () -> _CPICoupon.Value.fixedRate())
    let _indexFixing                               = triv _CPICoupon (fun () -> _CPICoupon.Value.indexFixing())
    let _indexObservation                          (onDate : ICell<Date>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.indexObservation(onDate.Value))
    let _observationInterpolation                  = triv _CPICoupon (fun () -> _CPICoupon.Value.observationInterpolation())
    let _spread                                    = triv _CPICoupon (fun () -> _CPICoupon.Value.spread())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.accruedAmount(d.Value))
    let _amount                                    = triv _CPICoupon (fun () -> _CPICoupon.Value.amount())
    let _dayCounter                                = triv _CPICoupon (fun () -> _CPICoupon.Value.dayCounter())
    let _fixingDate                                = triv _CPICoupon (fun () -> _CPICoupon.Value.fixingDate())
    let _fixingDays                                = triv _CPICoupon (fun () -> _CPICoupon.Value.fixingDays())
    let _index                                     = triv _CPICoupon (fun () -> _CPICoupon.Value.index())
    let _observationLag                            = triv _CPICoupon (fun () -> _CPICoupon.Value.observationLag())
    let _price                                     (discountingCurve : ICell<Handle<YieldTermStructure>>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.price(discountingCurve.Value))
    let _pricer                                    = triv _CPICoupon (fun () -> _CPICoupon.Value.pricer())
    let _rate                                      = triv _CPICoupon (fun () -> _CPICoupon.Value.rate())
    let _setPricer                                 (pricer : ICell<InflationCouponPricer>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.setPricer(pricer.Value)
                                                                                _CPICoupon.Value)
    let _update                                    = triv _CPICoupon (fun () -> _CPICoupon.Value.update()
                                                                                _CPICoupon.Value)
    let _accrualDays                               = triv _CPICoupon (fun () -> _CPICoupon.Value.accrualDays())
    let _accrualEndDate                            = triv _CPICoupon (fun () -> _CPICoupon.Value.accrualEndDate())
    let _accrualPeriod                             = triv _CPICoupon (fun () -> _CPICoupon.Value.accrualPeriod())
    let _accrualStartDate                          = triv _CPICoupon (fun () -> _CPICoupon.Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.accruedPeriod(d.Value))
    let _date                                      = triv _CPICoupon (fun () -> _CPICoupon.Value.date())
    let _exCouponDate                              = triv _CPICoupon (fun () -> _CPICoupon.Value.exCouponDate())
    let _nominal                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.nominal())
    let _referencePeriodEnd                        = triv _CPICoupon (fun () -> _CPICoupon.Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv _CPICoupon (fun () -> _CPICoupon.Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.accept(v.Value)
                                                                                _CPICoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.registerWith(handler.Value)
                                                                                _CPICoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _CPICoupon (fun () -> _CPICoupon.Value.unregisterWith(handler.Value)
                                                                                _CPICoupon.Value)
    do this.Bind(_CPICoupon)
(* 
    casting 
*)
    internal new () = new CPICouponModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CPICoupon <- v
    static member Cast (p : ICell<CPICoupon>) = 
        if p :? CPICouponModel then 
            p :?> CPICouponModel
        else
            let o = new CPICouponModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.baseCPI                            = _baseCPI 
    member this.paymentDate                        = _paymentDate 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixingDays                         = _fixingDays 
    member this.index                              = _index 
    member this.observationLag                     = _observationLag 
    member this.observationInterpolation           = _observationInterpolation 
    member this.dayCounter                         = _dayCounter 
    member this.fixedRate                          = _fixedRate 
    member this.spread                             = _spread 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.exCouponDate                       = _exCouponDate 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.BaseCPI                            = _baseCPI
    member this.CpiIndex                           = _cpiIndex
    member this.FixedRate                          = _fixedRate
    member this.IndexFixing                        = _indexFixing
    member this.IndexObservation                   onDate   
                                                   = _indexObservation onDate 
    member this.ObservationInterpolation           = _observationInterpolation
    member this.Spread                             = _spread
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Index                              = _index
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
