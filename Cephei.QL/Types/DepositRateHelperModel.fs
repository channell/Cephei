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
Rate helper for bootstrapping over deposit rates

  </summary> *)
[<AutoSerializable(true)>]
type DepositRateHelperModel
    ( rate                                         : ICell<Handle<Quote>>
    , tenor                                        : ICell<Period>
    , fixingDays                                   : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<DepositRateHelper> ()
(*
    Parameters
*)
    let _rate                                      = rate
    let _tenor                                     = tenor
    let _fixingDays                                = fixingDays
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _DepositRateHelper                         = cell (fun () -> new DepositRateHelper (rate.Value, tenor.Value, fixingDays.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value))
    let _impliedQuote                              = triv (fun () -> _DepositRateHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.setTermStructure(t.Value)
                                                                     _DepositRateHelper.Value)
    let _update                                    = triv (fun () -> _DepositRateHelper.Value.update()
                                                                     _DepositRateHelper.Value)
    let _earliestDate                              = triv (fun () -> _DepositRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _DepositRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _DepositRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _DepositRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _DepositRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _DepositRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _DepositRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _DepositRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _DepositRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.registerWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.unregisterWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    do this.Bind(_DepositRateHelper)
(* 
    casting 
*)
    internal new () = new DepositRateHelperModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _DepositRateHelper.Value <- v
    static member Cast (p : ICell<DepositRateHelper>) = 
        if p :? DepositRateHelperModel then 
            p :?> DepositRateHelperModel
        else
            let o = new DepositRateHelperModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.tenor                              = _tenor 
    member this.fixingDays                         = _fixingDays 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
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
Rate helper for bootstrapping over deposit rates

  </summary> *)
[<AutoSerializable(true)>]
type DepositRateHelperModel1
    ( rate                                         : ICell<double>
    , i                                            : ICell<IborIndex>
    ) as this =

    inherit Model<DepositRateHelper> ()
(*
    Parameters
*)
    let _rate                                      = rate
    let _i                                         = i
(*
    Functions
*)
    let _DepositRateHelper                         = cell (fun () -> new DepositRateHelper (rate.Value, i.Value))
    let _impliedQuote                              = triv (fun () -> _DepositRateHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.setTermStructure(t.Value)
                                                                     _DepositRateHelper.Value)
    let _update                                    = triv (fun () -> _DepositRateHelper.Value.update()
                                                                     _DepositRateHelper.Value)
    let _earliestDate                              = triv (fun () -> _DepositRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _DepositRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _DepositRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _DepositRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _DepositRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _DepositRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _DepositRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _DepositRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _DepositRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.registerWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.unregisterWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    do this.Bind(_DepositRateHelper)
(* 
    casting 
*)
    internal new () = new DepositRateHelperModel1(null,null)
    member internal this.Inject v = _DepositRateHelper.Value <- v
    static member Cast (p : ICell<DepositRateHelper>) = 
        if p :? DepositRateHelperModel1 then 
            p :?> DepositRateHelperModel1
        else
            let o = new DepositRateHelperModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.i                                  = _i 
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
Rate helper for bootstrapping over deposit rates

  </summary> *)
[<AutoSerializable(true)>]
type DepositRateHelperModel2
    ( rate                                         : ICell<Handle<Quote>>
    , i                                            : ICell<IborIndex>
    ) as this =

    inherit Model<DepositRateHelper> ()
(*
    Parameters
*)
    let _rate                                      = rate
    let _i                                         = i
(*
    Functions
*)
    let _DepositRateHelper                         = cell (fun () -> new DepositRateHelper (rate.Value, i.Value))
    let _impliedQuote                              = triv (fun () -> _DepositRateHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.setTermStructure(t.Value)
                                                                     _DepositRateHelper.Value)
    let _update                                    = triv (fun () -> _DepositRateHelper.Value.update()
                                                                     _DepositRateHelper.Value)
    let _earliestDate                              = triv (fun () -> _DepositRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _DepositRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _DepositRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _DepositRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _DepositRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _DepositRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _DepositRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _DepositRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _DepositRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.registerWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.unregisterWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    do this.Bind(_DepositRateHelper)
(* 
    casting 
*)
    internal new () = new DepositRateHelperModel2(null,null)
    member internal this.Inject v = _DepositRateHelper.Value <- v
    static member Cast (p : ICell<DepositRateHelper>) = 
        if p :? DepositRateHelperModel2 then 
            p :?> DepositRateHelperModel2
        else
            let o = new DepositRateHelperModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.i                                  = _i 
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
Rate helper for bootstrapping over deposit rates

  </summary> *)
[<AutoSerializable(true)>]
type DepositRateHelperModel3
    ( rate                                         : ICell<double>
    , tenor                                        : ICell<Period>
    , fixingDays                                   : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<DepositRateHelper> ()
(*
    Parameters
*)
    let _rate                                      = rate
    let _tenor                                     = tenor
    let _fixingDays                                = fixingDays
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _DepositRateHelper                         = cell (fun () -> new DepositRateHelper (rate.Value, tenor.Value, fixingDays.Value, calendar.Value, convention.Value, endOfMonth.Value, dayCounter.Value))
    let _impliedQuote                              = triv (fun () -> _DepositRateHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.setTermStructure(t.Value)
                                                                     _DepositRateHelper.Value)
    let _update                                    = triv (fun () -> _DepositRateHelper.Value.update()
                                                                     _DepositRateHelper.Value)
    let _earliestDate                              = triv (fun () -> _DepositRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _DepositRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _DepositRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _DepositRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _DepositRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _DepositRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _DepositRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _DepositRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _DepositRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.registerWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DepositRateHelper.Value.unregisterWith(handler.Value)
                                                                     _DepositRateHelper.Value)
    do this.Bind(_DepositRateHelper)
(* 
    casting 
*)
    internal new () = new DepositRateHelperModel3(null,null,null,null,null,null,null)
    member internal this.Inject v = _DepositRateHelper.Value <- v
    static member Cast (p : ICell<DepositRateHelper>) = 
        if p :? DepositRateHelperModel3 then 
            p :?> DepositRateHelperModel3
        else
            let o = new DepositRateHelperModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.tenor                              = _tenor 
    member this.fixingDays                         = _fixingDays 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.dayCounter                         = _dayCounter 
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
