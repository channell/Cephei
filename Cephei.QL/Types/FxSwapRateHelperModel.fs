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
  fwdFx = spotFx + fwdPoint isFxBaseCurrencyCollateralCurrency indicates if the base currency of the fx currency pair is the one used as collateral

  </summary> *)
[<AutoSerializable(true)>]
type FxSwapRateHelperModel
    ( fwdPoint                                     : ICell<Handle<Quote>>
    , spotFx                                       : ICell<Handle<Quote>>
    , tenor                                        : ICell<Period>
    , fixingDays                                   : ICell<int>
    , calendar                                     : ICell<Calendar>
    , convention                                   : ICell<BusinessDayConvention>
    , endOfMonth                                   : ICell<bool>
    , isFxBaseCurrencyCollateralCurrency           : ICell<bool>
    , coll                                         : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<FxSwapRateHelper> ()
(*
    Parameters
*)
    let _fwdPoint                                  = fwdPoint
    let _spotFx                                    = spotFx
    let _tenor                                     = tenor
    let _fixingDays                                = fixingDays
    let _calendar                                  = calendar
    let _convention                                = convention
    let _endOfMonth                                = endOfMonth
    let _isFxBaseCurrencyCollateralCurrency        = isFxBaseCurrencyCollateralCurrency
    let _coll                                      = coll
(*
    Functions
*)
    let _FxSwapRateHelper                          = cell (fun () -> new FxSwapRateHelper (fwdPoint.Value, spotFx.Value, tenor.Value, fixingDays.Value, calendar.Value, convention.Value, endOfMonth.Value, isFxBaseCurrencyCollateralCurrency.Value, coll.Value))
    let _businessDayConvention                     = cell (fun () -> _FxSwapRateHelper.Value.businessDayConvention())
    let _calendar                                  = cell (fun () -> _FxSwapRateHelper.Value.calendar())
    let _endOfMonth                                = cell (fun () -> _FxSwapRateHelper.Value.endOfMonth())
    let _fixingDays                                = cell (fun () -> _FxSwapRateHelper.Value.fixingDays())
    let _impliedQuote                              = cell (fun () -> _FxSwapRateHelper.Value.impliedQuote())
    let _isFxBaseCurrencyCollateralCurrency        = cell (fun () -> _FxSwapRateHelper.Value.isFxBaseCurrencyCollateralCurrency())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = cell (fun () -> _FxSwapRateHelper.Value.setTermStructure(t.Value)
                                                                     _FxSwapRateHelper.Value)
    let _spot                                      = cell (fun () -> _FxSwapRateHelper.Value.spot())
    let _tenor                                     = cell (fun () -> _FxSwapRateHelper.Value.tenor())
    let _update                                    = cell (fun () -> _FxSwapRateHelper.Value.update()
                                                                     _FxSwapRateHelper.Value)
    let _earliestDate                              = cell (fun () -> _FxSwapRateHelper.Value.earliestDate())
    let _latestDate                                = cell (fun () -> _FxSwapRateHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _FxSwapRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _FxSwapRateHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _FxSwapRateHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _FxSwapRateHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _FxSwapRateHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _FxSwapRateHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _FxSwapRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _FxSwapRateHelper.Value.registerWith(handler.Value)
                                                                     _FxSwapRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _FxSwapRateHelper.Value.unregisterWith(handler.Value)
                                                                     _FxSwapRateHelper.Value)
    do this.Bind(_FxSwapRateHelper)

(* 
    Externally visible/bindable properties
*)
    member this.fwdPoint                           = _fwdPoint 
    member this.spotFx                             = _spotFx 
    member this.tenor                              = _tenor 
    member this.fixingDays                         = _fixingDays 
    member this.calendar                           = _calendar 
    member this.convention                         = _convention 
    member this.endOfMonth                         = _endOfMonth 
    member this.isFxBaseCurrencyCollateralCurrency = _isFxBaseCurrencyCollateralCurrency 
    member this.coll                               = _coll 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Calendar                           = _calendar
    member this.EndOfMonth                         = _endOfMonth
    member this.FixingDays                         = _fixingDays
    member this.ImpliedQuote                       = _impliedQuote
    member this.IsFxBaseCurrencyCollateralCurrency = _isFxBaseCurrencyCollateralCurrency
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.Spot                               = _spot
    member this.Tenor                              = _tenor
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
