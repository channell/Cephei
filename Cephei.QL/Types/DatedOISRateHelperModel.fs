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
  Rate helper for bootstrapping over Overnight Indexed Swap rates

  </summary> *)
[<AutoSerializable(true)>]
type DatedOISRateHelperModel
    ( startDate                                    : ICell<Date>
    , endDate                                      : ICell<Date>
    , fixedRate                                    : ICell<Handle<Quote>>
    , overnightIndex                               : ICell<OvernightIndex>
    ) as this =

    inherit Model<DatedOISRateHelper> ()
(*
    Parameters
*)
    let _startDate                                 = startDate
    let _endDate                                   = endDate
    let _fixedRate                                 = fixedRate
    let _overnightIndex                            = overnightIndex
(*
    Functions
*)
    let _DatedOISRateHelper                        = cell (fun () -> new DatedOISRateHelper (startDate.Value, endDate.Value, fixedRate.Value, overnightIndex.Value))
    let _impliedQuote                              = cell (fun () -> _DatedOISRateHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = cell (fun () -> _DatedOISRateHelper.Value.setTermStructure(t.Value)
                                                                     _DatedOISRateHelper.Value)
    let _earliestDate                              = cell (fun () -> _DatedOISRateHelper.Value.earliestDate())
    let _latestDate                                = cell (fun () -> _DatedOISRateHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _DatedOISRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _DatedOISRateHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _DatedOISRateHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _DatedOISRateHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _DatedOISRateHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _DatedOISRateHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _DatedOISRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _DatedOISRateHelper.Value.registerWith(handler.Value)
                                                                     _DatedOISRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _DatedOISRateHelper.Value.unregisterWith(handler.Value)
                                                                     _DatedOISRateHelper.Value)
    let _update                                    = cell (fun () -> _DatedOISRateHelper.Value.update()
                                                                     _DatedOISRateHelper.Value)
    do this.Bind(_DatedOISRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.startDate                          = _startDate 
    member this.endDate                            = _endDate 
    member this.fixedRate                          = _fixedRate 
    member this.overnightIndex                     = _overnightIndex 
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
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
