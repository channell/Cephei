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
This class provides an abstraction for the instruments used to bootstrap a term structure. It is advised that a bootstrap helper for an instrument contains an instance of the actual instrument class to ensure consistancy between the algorithms used during bootstrapping and later instrument pricing. This is not yet fully enforced in the available rate helpers.

  </summary> *)
[<AutoSerializable(true)>]
type BootstrapHelperModel<'TS>
    () as this =
    inherit Model<BootstrapHelper<'TS>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _BootstrapHelper                           = cell (fun () -> new BootstrapHelper<'TS> ())
    let _earliestDate                              = cell (fun () -> _BootstrapHelper.Value.earliestDate())
    let _impliedQuote                              = cell (fun () -> _BootstrapHelper.Value.impliedQuote())
    let _latestDate                                = cell (fun () -> _BootstrapHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _BootstrapHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _BootstrapHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _BootstrapHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _BootstrapHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _BootstrapHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _BootstrapHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _BootstrapHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.registerWith(handler.Value)
                                                                     _BootstrapHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.setTermStructure(ts.Value)
                                                                     _BootstrapHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.unregisterWith(handler.Value)
                                                                     _BootstrapHelper.Value)
    let _update                                    = cell (fun () -> _BootstrapHelper.Value.update()
                                                                     _BootstrapHelper.Value)
    do this.Bind(_BootstrapHelper)

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
(* <summary>
This class provides an abstraction for the instruments used to bootstrap a term structure. It is advised that a bootstrap helper for an instrument contains an instance of the actual instrument class to ensure consistancy between the algorithms used during bootstrapping and later instrument pricing. This is not yet fully enforced in the available rate helpers.
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type BootstrapHelperModel1<'TS>
    ( quote                                        : ICell<Handle<Quote>>
    ) as this =

    inherit Model<BootstrapHelper<'TS>> ()
(*
    Parameters
*)
    let _quote                                     = quote
(*
    Functions
*)
    let _BootstrapHelper                           = cell (fun () -> new BootstrapHelper<'TS> (quote.Value))
    let _earliestDate                              = cell (fun () -> _BootstrapHelper.Value.earliestDate())
    let _impliedQuote                              = cell (fun () -> _BootstrapHelper.Value.impliedQuote())
    let _latestDate                                = cell (fun () -> _BootstrapHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _BootstrapHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _BootstrapHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _BootstrapHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _BootstrapHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _BootstrapHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _BootstrapHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _BootstrapHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.registerWith(handler.Value)
                                                                     _BootstrapHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.setTermStructure(ts.Value)
                                                                     _BootstrapHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.unregisterWith(handler.Value)
                                                                     _BootstrapHelper.Value)
    let _update                                    = cell (fun () -> _BootstrapHelper.Value.update()
                                                                     _BootstrapHelper.Value)
    do this.Bind(_BootstrapHelper)

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
This class provides an abstraction for the instruments used to bootstrap a term structure. It is advised that a bootstrap helper for an instrument contains an instance of the actual instrument class to ensure consistancy between the algorithms used during bootstrapping and later instrument pricing. This is not yet fully enforced in the available rate helpers.

  </summary> *)
[<AutoSerializable(true)>]
type BootstrapHelperModel2<'TS>
    ( quote                                        : ICell<double>
    ) as this =

    inherit Model<BootstrapHelper<'TS>> ()
(*
    Parameters
*)
    let _quote                                     = quote
(*
    Functions
*)
    let _BootstrapHelper                           = cell (fun () -> new BootstrapHelper<'TS> (quote.Value))
    let _earliestDate                              = cell (fun () -> _BootstrapHelper.Value.earliestDate())
    let _impliedQuote                              = cell (fun () -> _BootstrapHelper.Value.impliedQuote())
    let _latestDate                                = cell (fun () -> _BootstrapHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _BootstrapHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _BootstrapHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _BootstrapHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _BootstrapHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _BootstrapHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _BootstrapHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _BootstrapHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.registerWith(handler.Value)
                                                                     _BootstrapHelper.Value)
    let _setTermStructure                          (ts : ICell<'TS>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.setTermStructure(ts.Value)
                                                                     _BootstrapHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BootstrapHelper.Value.unregisterWith(handler.Value)
                                                                     _BootstrapHelper.Value)
    let _update                                    = cell (fun () -> _BootstrapHelper.Value.update()
                                                                     _BootstrapHelper.Value)
    do this.Bind(_BootstrapHelper)

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
