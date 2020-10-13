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
  base class for swap-rate indexes

  </summary> *)
[<AutoSerializable(true)>]
type SwapIndexModel
    ( familyName                                   : ICell<string>
    , tenor                                        : ICell<Period>
    , settlementDays                               : ICell<int>
    , currency                                     : ICell<Currency>
    , calendar                                     : ICell<Calendar>
    , fixedLegTenor                                : ICell<Period>
    , fixedLegConvention                           : ICell<BusinessDayConvention>
    , fixedLegDayCounter                           : ICell<DayCounter>
    , iborIndex                                    : ICell<IborIndex>
    , discountingTermStructure                     : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<SwapIndex> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _tenor                                     = tenor
    let _settlementDays                            = settlementDays
    let _currency                                  = currency
    let _calendar                                  = calendar
    let _fixedLegTenor                             = fixedLegTenor
    let _fixedLegConvention                        = fixedLegConvention
    let _fixedLegDayCounter                        = fixedLegDayCounter
    let _iborIndex                                 = iborIndex
    let _discountingTermStructure                  = discountingTermStructure
(*
    Functions
*)
    let _SwapIndex                                 = cell (fun () -> new SwapIndex (familyName.Value, tenor.Value, settlementDays.Value, currency.Value, calendar.Value, fixedLegTenor.Value, fixedLegConvention.Value, fixedLegDayCounter.Value, iborIndex.Value, discountingTermStructure.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _SwapIndex.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _SwapIndex.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _SwapIndex.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _SwapIndex.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _SwapIndex.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _SwapIndex.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _SwapIndex.Value.currency())
    let _dayCounter                                = triv (fun () -> _SwapIndex.Value.dayCounter())
    let _familyName                                = triv (fun () -> _SwapIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _SwapIndex.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _SwapIndex.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _SwapIndex.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _SwapIndex.Value.tenor())
    let _update                                    = triv (fun () -> _SwapIndex.Value.update()
                                                                     _SwapIndex.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _allowsNativeFixings                       = triv (fun () -> _SwapIndex.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _SwapIndex.Value.clearFixings()
                                                                     _SwapIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapIndex.Value.registerWith(handler.Value)
                                                                     _SwapIndex.Value)
    let _timeSeries                                = triv (fun () -> _SwapIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapIndex.Value.unregisterWith(handler.Value)
                                                                     _SwapIndex.Value)
    do this.Bind(_SwapIndex)
(* 
    casting 
*)
    internal new () = new SwapIndexModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwapIndex.Value <- v
    static member Cast (p : ICell<SwapIndex>) = 
        if p :? SwapIndexModel then 
            p :?> SwapIndexModel
        else
            let o = new SwapIndexModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.tenor                              = _tenor 
    member this.settlementDays                     = _settlementDays 
    member this.currency                           = _currency 
    member this.calendar                           = _calendar 
    member this.fixedLegTenor                      = _fixedLegTenor 
    member this.fixedLegConvention                 = _fixedLegConvention 
    member this.fixedLegDayCounter                 = _fixedLegDayCounter 
    member this.iborIndex                          = _iborIndex 
    member this.discountingTermStructure           = _discountingTermStructure 
    member this.Clone                              tenor   
                                                   = _clone tenor 
    member this.Clone1                             forwarding discounting   
                                                   = _clone1 forwarding discounting 
    member this.Clone2                             forwarding   
                                                   = _clone2 forwarding 
    member this.DiscountingTermStructure           = _discountingTermStructure
    member this.ExogenousDiscount                  = _exogenousDiscount
    member this.FixedLegConvention                 = _fixedLegConvention
    member this.FixedLegTenor                      = _fixedLegTenor
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.IborIndex                          = _iborIndex
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.UnderlyingSwap                     fixingDate   
                                                   = _underlyingSwap fixingDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  base class for swap-rate indexes

  </summary> *)
[<AutoSerializable(true)>]
type SwapIndexModel1
    ( familyName                                   : ICell<string>
    , tenor                                        : ICell<Period>
    , settlementDays                               : ICell<int>
    , currency                                     : ICell<Currency>
    , calendar                                     : ICell<Calendar>
    , fixedLegTenor                                : ICell<Period>
    , fixedLegConvention                           : ICell<BusinessDayConvention>
    , fixedLegDayCounter                           : ICell<DayCounter>
    , iborIndex                                    : ICell<IborIndex>
    ) as this =

    inherit Model<SwapIndex> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _tenor                                     = tenor
    let _settlementDays                            = settlementDays
    let _currency                                  = currency
    let _calendar                                  = calendar
    let _fixedLegTenor                             = fixedLegTenor
    let _fixedLegConvention                        = fixedLegConvention
    let _fixedLegDayCounter                        = fixedLegDayCounter
    let _iborIndex                                 = iborIndex
(*
    Functions
*)
    let _SwapIndex                                 = cell (fun () -> new SwapIndex (familyName.Value, tenor.Value, settlementDays.Value, currency.Value, calendar.Value, fixedLegTenor.Value, fixedLegConvention.Value, fixedLegDayCounter.Value, iborIndex.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _SwapIndex.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _SwapIndex.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _SwapIndex.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _SwapIndex.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _SwapIndex.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _SwapIndex.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _SwapIndex.Value.currency())
    let _dayCounter                                = triv (fun () -> _SwapIndex.Value.dayCounter())
    let _familyName                                = triv (fun () -> _SwapIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _SwapIndex.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _SwapIndex.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _SwapIndex.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _SwapIndex.Value.tenor())
    let _update                                    = triv (fun () -> _SwapIndex.Value.update()
                                                                     _SwapIndex.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _allowsNativeFixings                       = triv (fun () -> _SwapIndex.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _SwapIndex.Value.clearFixings()
                                                                     _SwapIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapIndex.Value.registerWith(handler.Value)
                                                                     _SwapIndex.Value)
    let _timeSeries                                = triv (fun () -> _SwapIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapIndex.Value.unregisterWith(handler.Value)
                                                                     _SwapIndex.Value)
    do this.Bind(_SwapIndex)
(* 
    casting 
*)
    internal new () = new SwapIndexModel1(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwapIndex.Value <- v
    static member Cast (p : ICell<SwapIndex>) = 
        if p :? SwapIndexModel1 then 
            p :?> SwapIndexModel1
        else
            let o = new SwapIndexModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.tenor                              = _tenor 
    member this.settlementDays                     = _settlementDays 
    member this.currency                           = _currency 
    member this.calendar                           = _calendar 
    member this.fixedLegTenor                      = _fixedLegTenor 
    member this.fixedLegConvention                 = _fixedLegConvention 
    member this.fixedLegDayCounter                 = _fixedLegDayCounter 
    member this.iborIndex                          = _iborIndex 
    member this.Clone                              tenor   
                                                   = _clone tenor 
    member this.Clone1                             forwarding discounting   
                                                   = _clone1 forwarding discounting 
    member this.Clone2                             forwarding   
                                                   = _clone2 forwarding 
    member this.DiscountingTermStructure           = _discountingTermStructure
    member this.ExogenousDiscount                  = _exogenousDiscount
    member this.FixedLegConvention                 = _fixedLegConvention
    member this.FixedLegTenor                      = _fixedLegTenor
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.IborIndex                          = _iborIndex
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.UnderlyingSwap                     fixingDate   
                                                   = _underlyingSwap fixingDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  base class for swap-rate indexes
need by CashFlowVectors
  </summary> *)
[<AutoSerializable(true)>]
type SwapIndexModel2
    () as this =
    inherit Model<SwapIndex> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _SwapIndex                                 = cell (fun () -> new SwapIndex ())
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _SwapIndex.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _SwapIndex.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _SwapIndex.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _SwapIndex.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _SwapIndex.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _SwapIndex.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _SwapIndex.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _SwapIndex.Value.currency())
    let _dayCounter                                = triv (fun () -> _SwapIndex.Value.dayCounter())
    let _familyName                                = triv (fun () -> _SwapIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _SwapIndex.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _SwapIndex.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _SwapIndex.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _SwapIndex.Value.tenor())
    let _update                                    = triv (fun () -> _SwapIndex.Value.update()
                                                                     _SwapIndex.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapIndex.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _SwapIndex.Value)
    let _allowsNativeFixings                       = triv (fun () -> _SwapIndex.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _SwapIndex.Value.clearFixings()
                                                                     _SwapIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapIndex.Value.registerWith(handler.Value)
                                                                     _SwapIndex.Value)
    let _timeSeries                                = triv (fun () -> _SwapIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapIndex.Value.unregisterWith(handler.Value)
                                                                     _SwapIndex.Value)
    do this.Bind(_SwapIndex)
(* 
    casting 
*)
    
    member internal this.Inject v = _SwapIndex.Value <- v
    static member Cast (p : ICell<SwapIndex>) = 
        if p :? SwapIndexModel2 then 
            p :?> SwapIndexModel2
        else
            let o = new SwapIndexModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Clone                              tenor   
                                                   = _clone tenor 
    member this.Clone1                             forwarding discounting   
                                                   = _clone1 forwarding discounting 
    member this.Clone2                             forwarding   
                                                   = _clone2 forwarding 
    member this.DiscountingTermStructure           = _discountingTermStructure
    member this.ExogenousDiscount                  = _exogenousDiscount
    member this.FixedLegConvention                 = _fixedLegConvention
    member this.FixedLegTenor                      = _fixedLegTenor
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.IborIndex                          = _iborIndex
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.UnderlyingSwap                     fixingDate   
                                                   = _underlyingSwap fixingDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
