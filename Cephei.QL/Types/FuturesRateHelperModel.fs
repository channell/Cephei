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
  Rate helper for bootstrapping over interest-rate futures prices

  </summary> *)
[<AutoSerializable(true)>]
type FuturesRateHelperModel
    ( price                                        : ICell<Handle<Quote>>
    , iborStartDate                                : ICell<Date>
    , lengthInMonths                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    , convAdj                                      : ICell<Handle<Quote>>
    , Type                                         : ICell<Futures.Type>
    ) as this =

    inherit Model<FuturesRateHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _iborStartDate                             = iborStartDate
    let _lengthInMonths                            = lengthInMonths
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
    let _convAdj                                   = convAdj
    let _Type                                      = Type
(*
    Functions
*)
    let _FuturesRateHelper                         = cell (fun () -> new FuturesRateHelper (price.Value, iborStartDate.Value, lengthInMonths.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value, convAdj.Value, Type.Value))
    let _convexityAdjustment                       = triv (fun () -> _FuturesRateHelper.Value.convexityAdjustment())
    let _impliedQuote                              = triv (fun () -> _FuturesRateHelper.Value.impliedQuote())
    let _earliestDate                              = triv (fun () -> _FuturesRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _FuturesRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _FuturesRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _FuturesRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _FuturesRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _FuturesRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _FuturesRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _FuturesRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _FuturesRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.registerWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.setTermStructure(ts.Value)
                                                                     _FuturesRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.unregisterWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _update                                    = triv (fun () -> _FuturesRateHelper.Value.update()
                                                                     _FuturesRateHelper.Value)
    do this.Bind(_FuturesRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.iborStartDate                      = _iborStartDate 
    member this.lengthInMonths                     = _lengthInMonths 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
    member this.convAdj                            = _convAdj 
    member this.Type                               = _Type 
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.ImpliedQuote                       = _impliedQuote
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
    member this.SetTermStructure                   ts   
                                                   = _setTermStructure ts 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  Rate helper for bootstrapping over interest-rate futures prices

  </summary> *)
[<AutoSerializable(true)>]
type FuturesRateHelperModel1
    ( price                                        : ICell<double>
    , iborStartDate                                : ICell<Date>
    , i                                            : ICell<IborIndex>
    , convAdj                                      : ICell<double>
    , Type                                         : ICell<Futures.Type>
    ) as this =

    inherit Model<FuturesRateHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _iborStartDate                             = iborStartDate
    let _i                                         = i
    let _convAdj                                   = convAdj
    let _Type                                      = Type
(*
    Functions
*)
    let _FuturesRateHelper                         = cell (fun () -> new FuturesRateHelper (price.Value, iborStartDate.Value, i.Value, convAdj.Value, Type.Value))
    let _convexityAdjustment                       = triv (fun () -> _FuturesRateHelper.Value.convexityAdjustment())
    let _impliedQuote                              = triv (fun () -> _FuturesRateHelper.Value.impliedQuote())
    let _earliestDate                              = triv (fun () -> _FuturesRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _FuturesRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _FuturesRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _FuturesRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _FuturesRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _FuturesRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _FuturesRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _FuturesRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _FuturesRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.registerWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.setTermStructure(ts.Value)
                                                                     _FuturesRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.unregisterWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _update                                    = triv (fun () -> _FuturesRateHelper.Value.update()
                                                                     _FuturesRateHelper.Value)
    do this.Bind(_FuturesRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.iborStartDate                      = _iborStartDate 
    member this.i                                  = _i 
    member this.convAdj                            = _convAdj 
    member this.Type                               = _Type 
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.ImpliedQuote                       = _impliedQuote
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
    member this.SetTermStructure                   ts   
                                                   = _setTermStructure ts 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  Rate helper for bootstrapping over interest-rate futures prices

  </summary> *)
[<AutoSerializable(true)>]
type FuturesRateHelperModel2
    ( price                                        : ICell<Handle<Quote>>
    , iborStartDate                                : ICell<Date>
    , i                                            : ICell<IborIndex>
    , convAdj                                      : ICell<Handle<Quote>>
    , Type                                         : ICell<Futures.Type>
    ) as this =

    inherit Model<FuturesRateHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _iborStartDate                             = iborStartDate
    let _i                                         = i
    let _convAdj                                   = convAdj
    let _Type                                      = Type
(*
    Functions
*)
    let _FuturesRateHelper                         = cell (fun () -> new FuturesRateHelper (price.Value, iborStartDate.Value, i.Value, convAdj.Value, Type.Value))
    let _convexityAdjustment                       = triv (fun () -> _FuturesRateHelper.Value.convexityAdjustment())
    let _impliedQuote                              = triv (fun () -> _FuturesRateHelper.Value.impliedQuote())
    let _earliestDate                              = triv (fun () -> _FuturesRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _FuturesRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _FuturesRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _FuturesRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _FuturesRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _FuturesRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _FuturesRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _FuturesRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _FuturesRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.registerWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.setTermStructure(ts.Value)
                                                                     _FuturesRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.unregisterWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _update                                    = triv (fun () -> _FuturesRateHelper.Value.update()
                                                                     _FuturesRateHelper.Value)
    do this.Bind(_FuturesRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.iborStartDate                      = _iborStartDate 
    member this.i                                  = _i 
    member this.convAdj                            = _convAdj 
    member this.Type                               = _Type 
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.ImpliedQuote                       = _impliedQuote
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
    member this.SetTermStructure                   ts   
                                                   = _setTermStructure ts 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  Rate helper for bootstrapping over interest-rate futures prices

  </summary> *)
[<AutoSerializable(true)>]
type FuturesRateHelperModel3
    ( price                                        : ICell<double>
    , iborStartDate                                : ICell<Date>
    , iborEndDate                                  : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , convAdj                                      : ICell<double>
    , Type                                         : ICell<Futures.Type>
    ) as this =

    inherit Model<FuturesRateHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _iborStartDate                             = iborStartDate
    let _iborEndDate                               = iborEndDate
    let _dayCounter                                = dayCounter
    let _convAdj                                   = convAdj
    let _Type                                      = Type
(*
    Functions
*)
    let _FuturesRateHelper                         = cell (fun () -> new FuturesRateHelper (price.Value, iborStartDate.Value, iborEndDate.Value, dayCounter.Value, convAdj.Value, Type.Value))
    let _convexityAdjustment                       = triv (fun () -> _FuturesRateHelper.Value.convexityAdjustment())
    let _impliedQuote                              = triv (fun () -> _FuturesRateHelper.Value.impliedQuote())
    let _earliestDate                              = triv (fun () -> _FuturesRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _FuturesRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _FuturesRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _FuturesRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _FuturesRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _FuturesRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _FuturesRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _FuturesRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _FuturesRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.registerWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.setTermStructure(ts.Value)
                                                                     _FuturesRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.unregisterWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _update                                    = triv (fun () -> _FuturesRateHelper.Value.update()
                                                                     _FuturesRateHelper.Value)
    do this.Bind(_FuturesRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.iborStartDate                      = _iborStartDate 
    member this.iborEndDate                        = _iborEndDate 
    member this.dayCounter                         = _dayCounter 
    member this.convAdj                            = _convAdj 
    member this.Type                               = _Type 
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.ImpliedQuote                       = _impliedQuote
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
    member this.SetTermStructure                   ts   
                                                   = _setTermStructure ts 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  Rate helper for bootstrapping over interest-rate futures prices

  </summary> *)
[<AutoSerializable(true)>]
type FuturesRateHelperModel4
    ( price                                        : ICell<Handle<Quote>>
    , iborStartDate                                : ICell<Date>
    , iborEndDate                                  : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , convAdj                                      : ICell<Handle<Quote>>
    , Type                                         : ICell<Futures.Type>
    ) as this =

    inherit Model<FuturesRateHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _iborStartDate                             = iborStartDate
    let _iborEndDate                               = iborEndDate
    let _dayCounter                                = dayCounter
    let _convAdj                                   = convAdj
    let _Type                                      = Type
(*
    Functions
*)
    let _FuturesRateHelper                         = cell (fun () -> new FuturesRateHelper (price.Value, iborStartDate.Value, iborEndDate.Value, dayCounter.Value, convAdj.Value, Type.Value))
    let _convexityAdjustment                       = triv (fun () -> _FuturesRateHelper.Value.convexityAdjustment())
    let _impliedQuote                              = triv (fun () -> _FuturesRateHelper.Value.impliedQuote())
    let _earliestDate                              = triv (fun () -> _FuturesRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _FuturesRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _FuturesRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _FuturesRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _FuturesRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _FuturesRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _FuturesRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _FuturesRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _FuturesRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.registerWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.setTermStructure(ts.Value)
                                                                     _FuturesRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.unregisterWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _update                                    = triv (fun () -> _FuturesRateHelper.Value.update()
                                                                     _FuturesRateHelper.Value)
    do this.Bind(_FuturesRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.iborStartDate                      = _iborStartDate 
    member this.iborEndDate                        = _iborEndDate 
    member this.dayCounter                         = _dayCounter 
    member this.convAdj                            = _convAdj 
    member this.Type                               = _Type 
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.ImpliedQuote                       = _impliedQuote
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
    member this.SetTermStructure                   ts   
                                                   = _setTermStructure ts 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
(* <summary>
  Rate helper for bootstrapping over interest-rate futures prices

  </summary> *)
[<AutoSerializable(true)>]
type FuturesRateHelperModel5
    ( price                                        : ICell<double>
    , iborStartDate                                : ICell<Date>
    , lengthInMonths                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    , convexityAdjustment                          : ICell<double>
    , Type                                         : ICell<Futures.Type>
    ) as this =

    inherit Model<FuturesRateHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _iborStartDate                             = iborStartDate
    let _lengthInMonths                            = lengthInMonths
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
    let _convexityAdjustment                       = convexityAdjustment
    let _Type                                      = Type
(*
    Functions
*)
    let _FuturesRateHelper                         = cell (fun () -> new FuturesRateHelper (price.Value, iborStartDate.Value, lengthInMonths.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value, convexityAdjustment.Value, Type.Value))
    let _convexityAdjustment                       = triv (fun () -> _FuturesRateHelper.Value.convexityAdjustment())
    let _impliedQuote                              = triv (fun () -> _FuturesRateHelper.Value.impliedQuote())
    let _earliestDate                              = triv (fun () -> _FuturesRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _FuturesRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _FuturesRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _FuturesRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _FuturesRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _FuturesRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _FuturesRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _FuturesRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _FuturesRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.registerWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.setTermStructure(ts.Value)
                                                                     _FuturesRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FuturesRateHelper.Value.unregisterWith(handler.Value)
                                                                     _FuturesRateHelper.Value)
    let _update                                    = triv (fun () -> _FuturesRateHelper.Value.update()
                                                                     _FuturesRateHelper.Value)
    do this.Bind(_FuturesRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.iborStartDate                      = _iborStartDate 
    member this.lengthInMonths                     = _lengthInMonths 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
    member this.convexityAdjustment                = _convexityAdjustment 
    member this.Type                               = _Type 
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.ImpliedQuote                       = _impliedQuote
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
    member this.SetTermStructure                   ts   
                                                   = _setTermStructure ts 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
