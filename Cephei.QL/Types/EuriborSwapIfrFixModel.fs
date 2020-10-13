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
  %Euribor %Swap indexes published by IFR Markets and distributed by Reuters page TGM42281 and by Telerate. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. For more info see <http://www.ifrmarkets.com>.

  </summary> *)
[<AutoSerializable(true)>]
type EuriborSwapIfrFixModel
    ( tenor                                        : ICell<Period>
    , forwarding                                   : ICell<Handle<YieldTermStructure>>
    , discounting                                  : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<EuriborSwapIfrFix> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _forwarding                                = forwarding
    let _discounting                               = discounting
(*
    Functions
*)
    let _EuriborSwapIfrFix                         = cell (fun () -> new EuriborSwapIfrFix (tenor.Value, forwarding.Value, discounting.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _EuriborSwapIfrFix.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _EuriborSwapIfrFix.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _EuriborSwapIfrFix.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _EuriborSwapIfrFix.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _EuriborSwapIfrFix.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _EuriborSwapIfrFix.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _EuriborSwapIfrFix.Value.currency())
    let _dayCounter                                = triv (fun () -> _EuriborSwapIfrFix.Value.dayCounter())
    let _familyName                                = triv (fun () -> _EuriborSwapIfrFix.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _EuriborSwapIfrFix.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _EuriborSwapIfrFix.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _EuriborSwapIfrFix.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _EuriborSwapIfrFix.Value.tenor())
    let _update                                    = triv (fun () -> _EuriborSwapIfrFix.Value.update()
                                                                     _EuriborSwapIfrFix.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _allowsNativeFixings                       = triv (fun () -> _EuriborSwapIfrFix.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _EuriborSwapIfrFix.Value.clearFixings()
                                                                     _EuriborSwapIfrFix.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.registerWith(handler.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _timeSeries                                = triv (fun () -> _EuriborSwapIfrFix.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.unregisterWith(handler.Value)
                                                                     _EuriborSwapIfrFix.Value)
    do this.Bind(_EuriborSwapIfrFix)
(* 
    casting 
*)
    internal new () = new EuriborSwapIfrFixModel(null,null,null)
    member internal this.Inject v = _EuriborSwapIfrFix.Value <- v
    static member Cast (p : ICell<EuriborSwapIfrFix>) = 
        if p :? EuriborSwapIfrFixModel then 
            p :?> EuriborSwapIfrFixModel
        else
            let o = new EuriborSwapIfrFixModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.forwarding                         = _forwarding 
    member this.discounting                        = _discounting 
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
  %Euribor %Swap indexes published by IFR Markets and distributed by Reuters page TGM42281 and by Telerate. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. For more info see <http://www.ifrmarkets.com>.

  </summary> *)
[<AutoSerializable(true)>]
type EuriborSwapIfrFixModel1
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<EuriborSwapIfrFix> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let _EuriborSwapIfrFix                         = cell (fun () -> new EuriborSwapIfrFix (tenor.Value, h.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _EuriborSwapIfrFix.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _EuriborSwapIfrFix.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _EuriborSwapIfrFix.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _EuriborSwapIfrFix.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _EuriborSwapIfrFix.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _EuriborSwapIfrFix.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _EuriborSwapIfrFix.Value.currency())
    let _dayCounter                                = triv (fun () -> _EuriborSwapIfrFix.Value.dayCounter())
    let _familyName                                = triv (fun () -> _EuriborSwapIfrFix.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _EuriborSwapIfrFix.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _EuriborSwapIfrFix.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _EuriborSwapIfrFix.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _EuriborSwapIfrFix.Value.tenor())
    let _update                                    = triv (fun () -> _EuriborSwapIfrFix.Value.update()
                                                                     _EuriborSwapIfrFix.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _allowsNativeFixings                       = triv (fun () -> _EuriborSwapIfrFix.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _EuriborSwapIfrFix.Value.clearFixings()
                                                                     _EuriborSwapIfrFix.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.registerWith(handler.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _timeSeries                                = triv (fun () -> _EuriborSwapIfrFix.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.unregisterWith(handler.Value)
                                                                     _EuriborSwapIfrFix.Value)
    do this.Bind(_EuriborSwapIfrFix)
(* 
    casting 
*)
    internal new () = new EuriborSwapIfrFixModel1(null,null)
    member internal this.Inject v = _EuriborSwapIfrFix.Value <- v
    static member Cast (p : ICell<EuriborSwapIfrFix>) = 
        if p :? EuriborSwapIfrFixModel1 then 
            p :?> EuriborSwapIfrFixModel1
        else
            let o = new EuriborSwapIfrFixModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.h                                  = _h 
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
  %Euribor %Swap indexes published by IFR Markets and distributed by Reuters page TGM42281 and by Telerate. Annual 30/360 vs 6M Euribor, 1Y vs 3M Euribor. For more info see <http://www.ifrmarkets.com>.

  </summary> *)
[<AutoSerializable(true)>]
type EuriborSwapIfrFixModel2
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<EuriborSwapIfrFix> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let _EuriborSwapIfrFix                         = cell (fun () -> new EuriborSwapIfrFix (tenor.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _EuriborSwapIfrFix.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _EuriborSwapIfrFix.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _EuriborSwapIfrFix.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _EuriborSwapIfrFix.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _EuriborSwapIfrFix.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _EuriborSwapIfrFix.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _EuriborSwapIfrFix.Value.currency())
    let _dayCounter                                = triv (fun () -> _EuriborSwapIfrFix.Value.dayCounter())
    let _familyName                                = triv (fun () -> _EuriborSwapIfrFix.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _EuriborSwapIfrFix.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _EuriborSwapIfrFix.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _EuriborSwapIfrFix.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _EuriborSwapIfrFix.Value.tenor())
    let _update                                    = triv (fun () -> _EuriborSwapIfrFix.Value.update()
                                                                     _EuriborSwapIfrFix.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _allowsNativeFixings                       = triv (fun () -> _EuriborSwapIfrFix.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _EuriborSwapIfrFix.Value.clearFixings()
                                                                     _EuriborSwapIfrFix.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.registerWith(handler.Value)
                                                                     _EuriborSwapIfrFix.Value)
    let _timeSeries                                = triv (fun () -> _EuriborSwapIfrFix.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EuriborSwapIfrFix.Value.unregisterWith(handler.Value)
                                                                     _EuriborSwapIfrFix.Value)
    do this.Bind(_EuriborSwapIfrFix)
(* 
    casting 
*)
    internal new () = new EuriborSwapIfrFixModel2(null)
    member internal this.Inject v = _EuriborSwapIfrFix.Value <- v
    static member Cast (p : ICell<EuriborSwapIfrFix>) = 
        if p :? EuriborSwapIfrFixModel2 then 
            p :?> EuriborSwapIfrFixModel2
        else
            let o = new EuriborSwapIfrFixModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
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
