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
  Rate helper for bootstrapping over basis swap spreads Assumes that you have, at a minimum, either: - shortIndex with attached YieldTermStructure - longIndex with attached YieldTermStructure - Discount curve linked to discount swap engine The other leg is then solved for i.e. index curve (if no YieldTermStructure is attached to its index). The settlement date of the spot is assumed to be equal to the settlement date of the swap itself. termstructures

  </summary> *)
[<AutoSerializable(true)>]
type BasisSwapHelperModel
    ( spreadQuote                                  : ICell<Handle<Quote>>
    , settlementDays                               : ICell<int>
    , swapTenor                                    : ICell<Period>
    , settlementCalendar                           : ICell<Calendar>
    , rollConvention                               : ICell<BusinessDayConvention>
    , shortIndex                                   : ICell<IborIndex>
    , longIndex                                    : ICell<IborIndex>
    , discount                                     : ICell<Handle<YieldTermStructure>>
    , eom                                          : ICell<bool>
    , spreadOnShort                                : ICell<bool>
    ) as this =

    inherit Model<BasisSwapHelper> ()
(*
    Parameters
*)
    let _spreadQuote                               = spreadQuote
    let _settlementDays                            = settlementDays
    let _swapTenor                                 = swapTenor
    let _settlementCalendar                        = settlementCalendar
    let _rollConvention                            = rollConvention
    let _shortIndex                                = shortIndex
    let _longIndex                                 = longIndex
    let _discount                                  = discount
    let _eom                                       = eom
    let _spreadOnShort                             = spreadOnShort
(*
    Functions
*)
    let _BasisSwapHelper                           = cell (fun () -> new BasisSwapHelper (spreadQuote.Value, settlementDays.Value, swapTenor.Value, settlementCalendar.Value, rollConvention.Value, shortIndex.Value, longIndex.Value, discount.Value, eom.Value, spreadOnShort.Value))
    let _impliedQuote                              = cell (fun () -> _BasisSwapHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = cell (fun () -> _BasisSwapHelper.Value.setTermStructure(t.Value)
                                                                     _BasisSwapHelper.Value)
    let _swap                                      = cell (fun () -> _BasisSwapHelper.Value.swap())
    let _update                                    = cell (fun () -> _BasisSwapHelper.Value.update()
                                                                     _BasisSwapHelper.Value)
    let _earliestDate                              = cell (fun () -> _BasisSwapHelper.Value.earliestDate())
    let _latestDate                                = cell (fun () -> _BasisSwapHelper.Value.latestDate())
    let _latestRelevantDate                        = cell (fun () -> _BasisSwapHelper.Value.latestRelevantDate())
    let _maturityDate                              = cell (fun () -> _BasisSwapHelper.Value.maturityDate())
    let _pillarDate                                = cell (fun () -> _BasisSwapHelper.Value.pillarDate())
    let _quote                                     = cell (fun () -> _BasisSwapHelper.Value.quote())
    let _quoteError                                = cell (fun () -> _BasisSwapHelper.Value.quoteError())
    let _quoteIsValid                              = cell (fun () -> _BasisSwapHelper.Value.quoteIsValid())
    let _quoteValue                                = cell (fun () -> _BasisSwapHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BasisSwapHelper.Value.registerWith(handler.Value)
                                                                     _BasisSwapHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _BasisSwapHelper.Value.unregisterWith(handler.Value)
                                                                     _BasisSwapHelper.Value)
    do this.Bind(_BasisSwapHelper)

(* 
    Externally visible/bindable properties
*)
    member this.spreadQuote                        = _spreadQuote 
    member this.settlementDays                     = _settlementDays 
    member this.swapTenor                          = _swapTenor 
    member this.settlementCalendar                 = _settlementCalendar 
    member this.rollConvention                     = _rollConvention 
    member this.shortIndex                         = _shortIndex 
    member this.longIndex                          = _longIndex 
    member this.discount                           = _discount 
    member this.eom                                = _eom 
    member this.spreadOnShort                      = _spreadOnShort 
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
