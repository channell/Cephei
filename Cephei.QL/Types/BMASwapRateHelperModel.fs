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
  Rate helper for bootstrapping over BMA swap rates

  </summary> *)
[<AutoSerializable(true)>]
type BMASwapRateHelperModel
    ( liborFraction                                : ICell<Handle<Quote>>
    , tenor                                        : ICell<Period>
    , settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , bmaPeriod                                    : ICell<Period>
    , bmaConvention                                : ICell<BusinessDayConvention>
    , bmaDayCount                                  : ICell<DayCounter>
    , bmaIndex                                     : ICell<BMAIndex>
    , iborIndex                                    : ICell<IborIndex>
    ) as this =

    inherit Model<BMASwapRateHelper> ()
(*
    Parameters
*)
    let _liborFraction                             = liborFraction
    let _tenor                                     = tenor
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _bmaPeriod                                 = bmaPeriod
    let _bmaConvention                             = bmaConvention
    let _bmaDayCount                               = bmaDayCount
    let _bmaIndex                                  = bmaIndex
    let _iborIndex                                 = iborIndex
(*
    Functions
*)
    let mutable
        _BMASwapRateHelper                         = cell (fun () -> new BMASwapRateHelper (liborFraction.Value, tenor.Value, settlementDays.Value, calendar.Value, bmaPeriod.Value, bmaConvention.Value, bmaDayCount.Value, bmaIndex.Value, iborIndex.Value))
    let _impliedQuote                              = triv (fun () -> _BMASwapRateHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _BMASwapRateHelper.Value.setTermStructure(t.Value)
                                                                     _BMASwapRateHelper.Value)
    let _update                                    = triv (fun () -> _BMASwapRateHelper.Value.update()
                                                                     _BMASwapRateHelper.Value)
    let _earliestDate                              = triv (fun () -> _BMASwapRateHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _BMASwapRateHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _BMASwapRateHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _BMASwapRateHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _BMASwapRateHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _BMASwapRateHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _BMASwapRateHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _BMASwapRateHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _BMASwapRateHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BMASwapRateHelper.Value.registerWith(handler.Value)
                                                                     _BMASwapRateHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BMASwapRateHelper.Value.unregisterWith(handler.Value)
                                                                     _BMASwapRateHelper.Value)
    do this.Bind(_BMASwapRateHelper)
(* 
    casting 
*)
    internal new () = new BMASwapRateHelperModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _BMASwapRateHelper <- v
    static member Cast (p : ICell<BMASwapRateHelper>) = 
        if p :? BMASwapRateHelperModel then 
            p :?> BMASwapRateHelperModel
        else
            let o = new BMASwapRateHelperModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.liborFraction                      = _liborFraction 
    member this.tenor                              = _tenor 
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.bmaPeriod                          = _bmaPeriod 
    member this.bmaConvention                      = _bmaConvention 
    member this.bmaDayCount                        = _bmaDayCount 
    member this.bmaIndex                           = _bmaIndex 
    member this.iborIndex                          = _iborIndex 
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
