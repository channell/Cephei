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
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel
    ( rate                                         : ICell<double>
    , periodToStart                                : ICell<Period>
    , iborIndex                                    : ICell<IborIndex>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _periodToStart                             = periodToStart
    let _iborIndex                                 = iborIndex
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, periodToStart.Value, iborIndex.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel(null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel then 
            p :?> FraRateHelperModel
        else
            let o = new FraRateHelperModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.periodToStart                      = _periodToStart 
    member this.iborIndex                          = _iborIndex 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
(* <summary>
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel1
    ( rate                                         : ICell<Handle<Quote>>
    , periodToStart                                : ICell<Period>
    , iborIndex                                    : ICell<IborIndex>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _periodToStart                             = periodToStart
    let _iborIndex                                 = iborIndex
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, periodToStart.Value, iborIndex.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel1(null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel1 then 
            p :?> FraRateHelperModel1
        else
            let o = new FraRateHelperModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.periodToStart                      = _periodToStart 
    member this.iborIndex                          = _iborIndex 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
(* <summary>
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel2
    ( rate                                         : ICell<double>
    , periodToStart                                : ICell<Period>
    , lengthInMonths                               : ICell<int>
    , fixingDays                                   : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _periodToStart                             = periodToStart
    let _lengthInMonths                            = lengthInMonths
    let _fixingDays                                = fixingDays
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, periodToStart.Value, lengthInMonths.Value, fixingDays.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel2(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel2 then 
            p :?> FraRateHelperModel2
        else
            let o = new FraRateHelperModel2 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.periodToStart                      = _periodToStart 
    member this.lengthInMonths                     = _lengthInMonths 
    member this.fixingDays                         = _fixingDays 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
(* <summary>
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel3
    ( rate                                         : ICell<Handle<Quote>>
    , periodToStart                                : ICell<Period>
    , lengthInMonths                               : ICell<int>
    , fixingDays                                   : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _periodToStart                             = periodToStart
    let _lengthInMonths                            = lengthInMonths
    let _fixingDays                                = fixingDays
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, periodToStart.Value, lengthInMonths.Value, fixingDays.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel3(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel3 then 
            p :?> FraRateHelperModel3
        else
            let o = new FraRateHelperModel3 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.periodToStart                      = _periodToStart 
    member this.lengthInMonths                     = _lengthInMonths 
    member this.fixingDays                         = _fixingDays 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
(* <summary>
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel4
    ( rate                                         : ICell<double>
    , monthsToStart                                : ICell<int>
    , i                                            : ICell<IborIndex>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _monthsToStart                             = monthsToStart
    let _i                                         = i
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, monthsToStart.Value, i.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel4(null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel4 then 
            p :?> FraRateHelperModel4
        else
            let o = new FraRateHelperModel4 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.monthsToStart                      = _monthsToStart 
    member this.i                                  = _i 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
(* <summary>
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel5
    ( rate                                         : ICell<Handle<Quote>>
    , monthsToStart                                : ICell<int>
    , i                                            : ICell<IborIndex>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _monthsToStart                             = monthsToStart
    let _i                                         = i
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, monthsToStart.Value, i.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel5(null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel5 then 
            p :?> FraRateHelperModel5
        else
            let o = new FraRateHelperModel5 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.monthsToStart                      = _monthsToStart 
    member this.i                                  = _i 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
(* <summary>
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel6
    ( rate                                         : ICell<double>
    , monthsToStart                                : ICell<int>
    , monthsToEnd                                  : ICell<int>
    , fixingDays                                   : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _monthsToStart                             = monthsToStart
    let _monthsToEnd                               = monthsToEnd
    let _fixingDays                                = fixingDays
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, monthsToStart.Value, monthsToEnd.Value, fixingDays.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel6(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel6 then 
            p :?> FraRateHelperModel6
        else
            let o = new FraRateHelperModel6 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.monthsToStart                      = _monthsToStart 
    member this.monthsToEnd                        = _monthsToEnd 
    member this.fixingDays                         = _fixingDays 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
(* <summary>
  Rate helper for bootstrapping over %FRA rates

  </summary> *)
[<AutoSerializable(true)>]
type FraRateHelperModel7
    ( rate                                         : ICell<Handle<Quote>>
    , monthsToStart                                : ICell<int>
    , monthsToEnd                                  : ICell<int>
    , fixingDays                                   : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    , pillarChoice                                 : ICell<Pillar.Choice>
    , customPillarDate                             : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FraRateHelper> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _rate                                      = rate
    let _monthsToStart                             = monthsToStart
    let _monthsToEnd                               = monthsToEnd
    let _fixingDays                                = fixingDays
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
    let _pillarChoice                              = pillarChoice
    let _customPillarDate                          = customPillarDate
(*
    Functions
*)
    let mutable
        _FraRateHelper                             = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FraRateHelper (rate.Value, monthsToStart.Value, monthsToEnd.Value, fixingDays.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value, pillarChoice.Value, customPillarDate.Value))))
    let _impliedQuote                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.setTermStructure(t.Value)
                                                                                    _FraRateHelper.Value)
    let _update                                    = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.update()
                                                                                    _FraRateHelper.Value)
    let _earliestDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.earliestDate())
    let _latestDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestDate())
    let _latestRelevantDate                        = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.latestRelevantDate())
    let _maturityDate                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.maturityDate())
    let _pillarDate                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.pillarDate())
    let _quote                                     = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quote())
    let _quoteError                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteError())
    let _quoteIsValid                              = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteIsValid())
    let _quoteValue                                = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.registerWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _FraRateHelper (fun () -> (curryEvaluationDate _evaluationDate _FraRateHelper).Value.unregisterWith(handler.Value)
                                                                                    _FraRateHelper.Value)
    do this.Bind(_FraRateHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FraRateHelperModel7(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FraRateHelper <- v
    static member Cast (p : ICell<FraRateHelper>) = 
        if p :? FraRateHelperModel7 then 
            p :?> FraRateHelperModel7
        else
            let o = new FraRateHelperModel7 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.monthsToStart                      = _monthsToStart 
    member this.monthsToEnd                        = _monthsToEnd 
    member this.fixingDays                         = _fixingDays 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
    member this.pillarChoice                       = _pillarChoice 
    member this.customPillarDate                   = _customPillarDate 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Update                             = _update
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
