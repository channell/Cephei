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
  CPI bond helper for curve bootstrap

  </summary> *)
[<AutoSerializable(true)>]
type CPIBondHelperModel
    ( price                                        : ICell<Handle<Quote>>
    , settlementDays                               : ICell<int>
    , faceAmount                                   : ICell<double>
    , growthOnly                                   : ICell<bool>
    , baseCPI                                      : ICell<double>
    , observationLag                               : ICell<Period>
    , cpiIndex                                     : ICell<ZeroInflationIndex>
    , observationInterpolation                     : ICell<InterpolationType>
    , schedule                                     : ICell<Schedule>
    , fixedRate                                    : ICell<Generic.List<double>>
    , accrualDayCounter                            : ICell<DayCounter>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , issueDate                                    : ICell<Date>
    , paymentCalendar                              : ICell<Calendar>
    , exCouponPeriod                               : ICell<Period>
    , exCouponCalendar                             : ICell<Calendar>
    , exCouponConvention                           : ICell<BusinessDayConvention>
    , exCouponEndOfMonth                           : ICell<bool>
    , useCleanPrice                                : ICell<bool>
    ) as this =

    inherit Model<CPIBondHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _settlementDays                            = settlementDays
    let _faceAmount                                = faceAmount
    let _growthOnly                                = growthOnly
    let _baseCPI                                   = baseCPI
    let _observationLag                            = observationLag
    let _cpiIndex                                  = cpiIndex
    let _observationInterpolation                  = observationInterpolation
    let _schedule                                  = schedule
    let _fixedRate                                 = fixedRate
    let _accrualDayCounter                         = accrualDayCounter
    let _paymentConvention                         = paymentConvention
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
        _CPIBondHelper                             = make (fun () -> new CPIBondHelper (price.Value, settlementDays.Value, faceAmount.Value, growthOnly.Value, baseCPI.Value, observationLag.Value, cpiIndex.Value, observationInterpolation.Value, schedule.Value, fixedRate.Value, accrualDayCounter.Value, paymentConvention.Value, issueDate.Value, paymentCalendar.Value, exCouponPeriod.Value, exCouponCalendar.Value, exCouponConvention.Value, exCouponEndOfMonth.Value, useCleanPrice.Value))
    let _cpiBond                                   = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.cpiBond())
    let _bond                                      = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.bond())
    let _impliedQuote                              = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.setTermStructure(t.Value)
                                                                                    _CPIBondHelper.Value)
    let _useCleanPrice                             = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.useCleanPrice())
    let _earliestDate                              = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.earliestDate())
    let _latestDate                                = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.latestDate())
    let _latestRelevantDate                        = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.maturityDate())
    let _pillarDate                                = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.pillarDate())
    let _quote                                     = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.quote())
    let _quoteError                                = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.quoteError())
    let _quoteIsValid                              = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.quoteIsValid())
    let _quoteValue                                = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.registerWith(handler.Value)
                                                                                    _CPIBondHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.unregisterWith(handler.Value)
                                                                                    _CPIBondHelper.Value)
    let _update                                    = triv _CPIBondHelper (fun () -> _CPIBondHelper.Value.update()
                                                                                    _CPIBondHelper.Value)
    do this.Bind(_CPIBondHelper)
(* 
    casting 
*)
    internal new () = new CPIBondHelperModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CPIBondHelper <- v
    static member Cast (p : ICell<CPIBondHelper>) = 
        if p :? CPIBondHelperModel then 
            p :?> CPIBondHelperModel
        else
            let o = new CPIBondHelperModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.settlementDays                     = _settlementDays 
    member this.faceAmount                         = _faceAmount 
    member this.growthOnly                         = _growthOnly 
    member this.baseCPI                            = _baseCPI 
    member this.observationLag                     = _observationLag 
    member this.cpiIndex                           = _cpiIndex 
    member this.observationInterpolation           = _observationInterpolation 
    member this.schedule                           = _schedule 
    member this.fixedRate                          = _fixedRate 
    member this.accrualDayCounter                  = _accrualDayCounter 
    member this.paymentConvention                  = _paymentConvention 
    member this.issueDate                          = _issueDate 
    member this.paymentCalendar                    = _paymentCalendar 
    member this.exCouponPeriod                     = _exCouponPeriod 
    member this.exCouponCalendar                   = _exCouponCalendar 
    member this.exCouponConvention                 = _exCouponConvention 
    member this.exCouponEndOfMonth                 = _exCouponEndOfMonth 
    member this.useCleanPrice                      = _useCleanPrice 
    member this.CpiBond                            = _cpiBond
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
