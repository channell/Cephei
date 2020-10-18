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
  Fixed-coupon bond helper for curve bootstrap

  </summary> *)
[<AutoSerializable(true)>]
type FixedRateBondHelperModel
    ( price                                        : ICell<Handle<Quote>>
    , settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , schedule                                     : ICell<Schedule>
    , coupons                                      : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , redemption                                   : ICell<double>
    , issueDate                                    : ICell<Date>
    , paymentCalendar                              : ICell<Calendar>
    , exCouponPeriod                               : ICell<Period>
    , exCouponCalendar                             : ICell<Calendar>
    , exCouponConvention                           : ICell<BusinessDayConvention>
    , exCouponEndOfMonth                           : ICell<bool>
    , useCleanPrice                                : ICell<bool>
    ) as this =

    inherit Model<FixedRateBondHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _schedule                                  = schedule
    let _coupons                                   = coupons
    let _dayCounter                                = dayCounter
    let _paymentConvention                         = paymentConvention
    let _redemption                                = redemption
    let _issueDate                                 = issueDate
    let _paymentCalendar                           = paymentCalendar
    let _exCouponPeriod                            = exCouponPeriod
    let _exCouponCalendar                          = exCouponCalendar
    let _exCouponConvention                        = exCouponConvention
    let _exCouponEndOfMonth                        = exCouponEndOfMonth
    let _useCleanPrice                             = useCleanPrice
(*
    Functions
*)
    let mutable
        _FixedRateBondHelper                       = cell (fun () -> new FixedRateBondHelper (price.Value, settlementDays.Value, faceAmount.Value, schedule.Value, coupons.Value, dayCounter.Value, paymentConvention.Value, redemption.Value, issueDate.Value, paymentCalendar.Value, exCouponPeriod.Value, exCouponCalendar.Value, exCouponConvention.Value, exCouponEndOfMonth.Value, useCleanPrice.Value))
    let _fixedRateBond                             = triv (fun () -> _FixedRateBondHelper.Value.fixedRateBond())
    let _bond                                      = triv (fun () -> _FixedRateBondHelper.Value.bond())
    let _impliedQuote                              = triv (fun () -> _FixedRateBondHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _FixedRateBondHelper.Value.setTermStructure(t.Value)
                                                                     _FixedRateBondHelper.Value)
    let _useCleanPrice                             = triv (fun () -> _FixedRateBondHelper.Value.useCleanPrice())
    let _earliestDate                              = triv (fun () -> _FixedRateBondHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _FixedRateBondHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _FixedRateBondHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _FixedRateBondHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _FixedRateBondHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _FixedRateBondHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _FixedRateBondHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _FixedRateBondHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _FixedRateBondHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FixedRateBondHelper.Value.registerWith(handler.Value)
                                                                     _FixedRateBondHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FixedRateBondHelper.Value.unregisterWith(handler.Value)
                                                                     _FixedRateBondHelper.Value)
    let _update                                    = triv (fun () -> _FixedRateBondHelper.Value.update()
                                                                     _FixedRateBondHelper.Value)
    do this.Bind(_FixedRateBondHelper)
(* 
    casting 
*)
    internal new () = new FixedRateBondHelperModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedRateBondHelper <- v
    static member Cast (p : ICell<FixedRateBondHelper>) = 
        if p :? FixedRateBondHelperModel then 
            p :?> FixedRateBondHelperModel
        else
            let o = new FixedRateBondHelperModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.schedule                           = _schedule 
    member this.coupons                            = _coupons 
    member this.dayCounter                         = _dayCounter 
    member this.paymentConvention                  = _paymentConvention 
    member this.redemption                         = _redemption 
    member this.issueDate                          = _issueDate 
    member this.paymentCalendar                    = _paymentCalendar 
    member this.exCouponPeriod                     = _exCouponPeriod 
    member this.exCouponCalendar                   = _exCouponCalendar 
    member this.exCouponConvention                 = _exCouponConvention 
    member this.exCouponEndOfMonth                 = _exCouponEndOfMonth 
    member this.useCleanPrice                      = _useCleanPrice 
    member this.FixedRateBond                      = _fixedRateBond
    member this.Bond                               = _bond
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.UseCleanPrice                      = _useCleanPrice
    member this.EarliestDate                       = _earliestDate
    member this.LatestDate                         = _latestDate
    member this.LatestRelevantDate                 = _latestRelevantDate
    member this.MaturityDate                       = _maturityDate
    member this.PillarDate                         = _pillarDate
    member this.Quote                              = _quote
    member this.QuoteError                         = _quoteError
    member this.QuoteIsValid                       = _quoteIsValid
    member this.QuoteValue                         = _quoteValue
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
