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
  Year-on-year inflation-swap bootstrap helper

  </summary> *)
[<AutoSerializable(true)>]
type YearOnYearInflationSwapHelperModel
    ( quote                                        : ICell<Handle<Quote>>
    , swapObsLag                                   : ICell<Period>
    , maturity                                     : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , paymentConvention                            : ICell<BusinessDayConvention>
    , dayCounter                                   : ICell<DayCounter>
    , yii                                          : ICell<YoYInflationIndex>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YearOnYearInflationSwapHelper> ()
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
    let _yii                                       = yii
(*
    Functions
*)
    let mutable
        _YearOnYearInflationSwapHelper             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new YearOnYearInflationSwapHelper (quote.Value, swapObsLag.Value, maturity.Value, calendar.Value, paymentConvention.Value, dayCounter.Value, yii.Value))))
    let _impliedQuote                              = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.impliedQuote())
    let _setTermStructure                          (y : ICell<YoYInflationTermStructure>)   
                                                   = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.setTermStructure(y.Value)
                                                                                                    _YearOnYearInflationSwapHelper.Value)
    let _earliestDate                              = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.earliestDate())
    let _latestDate                                = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.maturityDate())
    let _pillarDate                                = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.pillarDate())
    let _quote                                     = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.quote())
    let _quoteError                                = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.quoteError())
    let _quoteIsValid                              = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.registerWith(handler.Value)
                                                                                                    _YearOnYearInflationSwapHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.unregisterWith(handler.Value)
                                                                                                    _YearOnYearInflationSwapHelper.Value)
    let _update                                    = triv _YearOnYearInflationSwapHelper (fun () -> (curryEvaluationDate _evaluationDate _YearOnYearInflationSwapHelper).Value.update()
                                                                                                    _YearOnYearInflationSwapHelper.Value)
    do this.Bind(_YearOnYearInflationSwapHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new YearOnYearInflationSwapHelperModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _YearOnYearInflationSwapHelper <- v
    static member Cast (p : ICell<YearOnYearInflationSwapHelper>) = 
        if p :? YearOnYearInflationSwapHelperModel then 
            p :?> YearOnYearInflationSwapHelperModel
        else
            let o = new YearOnYearInflationSwapHelperModel ()
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
    member this.yii                                = _yii 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   y   
                                                   = _setTermStructure y 
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
