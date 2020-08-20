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


  </summary> *)
[<AutoSerializable(true)>]
type RateHelperModel
    ( quote                                        : ICell<double>
    ) as this =

    inherit Model<RateHelper> ()
(*
    Parameters
*)
    let _quote                                     = quote
(*
    Functions
*)
    let _RateHelper                                = cell (fun () -> new RateHelper (quote.Value))
    let _earliestDate                              = cell (fun () -> _RateHelper.Value.earliestDate())
    let _impliedQuote                              = cell (fun () -> _RateHelper.Value.impliedQuote())
    let _latestDate                                = cell (fun () -> _RateHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _RateHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _RateHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _RateHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _RateHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _RateHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _RateHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _RateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RateHelper.Value.registerWith(handler.Value)
                                                                     _RateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = cell (fun () -> _RateHelper.Value.setTermStructure(ts.Value)
                                                                     _RateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RateHelper.Value.unregisterWith(handler.Value)
                                                                     _RateHelper.Value)
    let _update                                    = cell (fun () -> _RateHelper.Value.update()
                                                                     _RateHelper.Value)
    do this.Bind(_RateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.quote                              = _quote 
    member this.EarliestDate                       = _earliestDate
    member this.ImpliedQuote                       = _impliedQuote
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

required for generics
  </summary> *)
[<AutoSerializable(true)>]
type RateHelperModel1
    ( quote                                        : ICell<Handle<Quote>>
    ) as this =

    inherit Model<RateHelper> ()
(*
    Parameters
*)
    let _quote                                     = quote
(*
    Functions
*)
    let _RateHelper                                = cell (fun () -> new RateHelper (quote.Value))
    let _earliestDate                              = cell (fun () -> _RateHelper.Value.earliestDate())
    let _impliedQuote                              = cell (fun () -> _RateHelper.Value.impliedQuote())
    let _latestDate                                = cell (fun () -> _RateHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _RateHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _RateHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _RateHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _RateHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _RateHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _RateHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _RateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RateHelper.Value.registerWith(handler.Value)
                                                                     _RateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = cell (fun () -> _RateHelper.Value.setTermStructure(ts.Value)
                                                                     _RateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RateHelper.Value.unregisterWith(handler.Value)
                                                                     _RateHelper.Value)
    let _update                                    = cell (fun () -> _RateHelper.Value.update()
                                                                     _RateHelper.Value)
    do this.Bind(_RateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.quote                              = _quote 
    member this.EarliestDate                       = _earliestDate
    member this.ImpliedQuote                       = _impliedQuote
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


  </summary> *)
[<AutoSerializable(true)>]
type RateHelperModel2
    () as this =
    inherit Model<RateHelper> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _RateHelper                                = cell (fun () -> new RateHelper ())
    let _earliestDate                              = cell (fun () -> _RateHelper.Value.earliestDate())
    let _impliedQuote                              = cell (fun () -> _RateHelper.Value.impliedQuote())
    let _latestDate                                = cell (fun () -> _RateHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _RateHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _RateHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _RateHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _RateHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _RateHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _RateHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _RateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RateHelper.Value.registerWith(handler.Value)
                                                                     _RateHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = cell (fun () -> _RateHelper.Value.setTermStructure(ts.Value)
                                                                     _RateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RateHelper.Value.unregisterWith(handler.Value)
                                                                     _RateHelper.Value)
    let _update                                    = cell (fun () -> _RateHelper.Value.update()
                                                                     _RateHelper.Value)
    do this.Bind(_RateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.EarliestDate                       = _earliestDate
    member this.ImpliedQuote                       = _impliedQuote
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
