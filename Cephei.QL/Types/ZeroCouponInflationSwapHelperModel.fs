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
  Zero-coupon inflation-swap bootstrap helper

  </summary> *)
[<AutoSerializable(true)>]
type ZeroCouponInflationSwapHelperModel
    ( quote                                        : ICell<Handle<Quote>>
    , swapObsLag                                   : ICell<Period>
    , maturity                                     : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , dayCounter                                   : ICell<DayCounter>
    , zii                                          : ICell<ZeroInflationIndex>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ZeroCouponInflationSwapHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _quote                                     = quote
    let _swapObsLag                                = swapObsLag
    let _maturity                                  = maturity
    let _calendar                                  = calendar
    let _paymentConvention                         = paymentConvention
    let _dayCounter                                = dayCounter
    let _zii                                       = zii
(*
    Functions
*)
    let mutable
        _ZeroCouponInflationSwapHelper             = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new ZeroCouponInflationSwapHelper (quote.Value, swapObsLag.Value, maturity.Value, calendar.Value, paymentConvention.Value, dayCounter.Value, zii.Value))))
    let _impliedQuote                              = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.impliedQuote())
    let _setTermStructure                          (z : ICell<ZeroInflationTermStructure>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.setTermStructure(z.Value)
                                                                     _ZeroCouponInflationSwapHelper.Value)
    let _earliestDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.earliestDate())
    let _latestDate                                = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.maturityDate())
    let _pillarDate                                = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.pillarDate())
    let _quote                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.quote())
    let _quoteError                                = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.registerWith(handler.Value)
                                                                     _ZeroCouponInflationSwapHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.unregisterWith(handler.Value)
                                                                     _ZeroCouponInflationSwapHelper.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _ZeroCouponInflationSwapHelper).Value.update()
                                                                     _ZeroCouponInflationSwapHelper.Value)
    do this.Bind(_ZeroCouponInflationSwapHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ZeroCouponInflationSwapHelperModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _ZeroCouponInflationSwapHelper <- v
    static member Cast (p : ICell<ZeroCouponInflationSwapHelper>) = 
        if p :? ZeroCouponInflationSwapHelperModel then 
            p :?> ZeroCouponInflationSwapHelperModel
        else
            let o = new ZeroCouponInflationSwapHelperModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.quote                              = _quote 
    member this.swapObsLag                         = _swapObsLag 
    member this.maturity                           = _maturity 
    member this.calendar                           = _calendar 
    member this.paymentConvention                  = _paymentConvention 
    member this.dayCounter                         = _dayCounter 
    member this.zii                                = _zii 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   z   
                                                   = _setTermStructure z 
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
