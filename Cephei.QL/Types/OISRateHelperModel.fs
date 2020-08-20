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
type OISRateHelperModel
    ( settlementDays                               : ICell<int>
    , tenor                                        : ICell<Period>
    , fixedRate                                    : ICell<Handle<Quote>>
    , overnightIndex                               : ICell<OvernightIndex>
    ) as this =

    inherit Model<OISRateHelper> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _tenor                                     = tenor
    let _fixedRate                                 = fixedRate
    let _overnightIndex                            = overnightIndex
(*
    Functions
*)
    let _OISRateHelper                             = cell (fun () -> new OISRateHelper (settlementDays.Value, tenor.Value, fixedRate.Value, overnightIndex.Value))
    let _impliedQuote                              = cell (fun () -> _OISRateHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = cell (fun () -> _OISRateHelper.Value.setTermStructure(t.Value)
                                                                     _OISRateHelper.Value)
    let _swap                                      = cell (fun () -> _OISRateHelper.Value.swap())
    let _update                                    = cell (fun () -> _OISRateHelper.Value.update()
                                                                     _OISRateHelper.Value)
    let _earliestDate                              = cell (fun () -> _OISRateHelper.Value.earliestDate())
    let _latestDate                                = cell (fun () -> _OISRateHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _OISRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _OISRateHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _OISRateHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _OISRateHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _OISRateHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _OISRateHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _OISRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _OISRateHelper.Value.registerWith(handler.Value)
                                                                     _OISRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _OISRateHelper.Value.unregisterWith(handler.Value)
                                                                     _OISRateHelper.Value)
    do this.Bind(_OISRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.tenor                              = _tenor 
    member this.fixedRate                          = _fixedRate 
    member this.overnightIndex                     = _overnightIndex 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Swap                               = _swap
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
