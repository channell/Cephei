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
  %CHF %Libor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am London. Annual 30/360 vs 6M Libor, 1Y vs 3M Libor. Reuters page ISDAFIX4 or CHFSFIX=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.

  </summary> *)
[<AutoSerializable(true)>]
type ChfLiborSwapIsdaFixModel
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<ChfLiborSwapIsdaFix> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let _ChfLiborSwapIsdaFix                       = cell (fun () -> new ChfLiborSwapIsdaFix (tenor.Value, h.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _ChfLiborSwapIsdaFix.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _ChfLiborSwapIsdaFix.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _ChfLiborSwapIsdaFix.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _ChfLiborSwapIsdaFix.Value.currency())
    let _dayCounter                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.dayCounter())
    let _familyName                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _ChfLiborSwapIsdaFix.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _ChfLiborSwapIsdaFix.Value.tenor())
    let _update                                    = triv (fun () -> _ChfLiborSwapIsdaFix.Value.update()
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _allowsNativeFixings                       = triv (fun () -> _ChfLiborSwapIsdaFix.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clearFixings()
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.registerWith(handler.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _timeSeries                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.unregisterWith(handler.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    do this.Bind(_ChfLiborSwapIsdaFix)
(* 
    casting 
*)
    internal new () = new ChfLiborSwapIsdaFixModel(null,null)
    member internal this.Inject v = _ChfLiborSwapIsdaFix.Value <- v
    static member Cast (p : ICell<ChfLiborSwapIsdaFix>) = 
        if p :? ChfLiborSwapIsdaFixModel then 
            p :?> ChfLiborSwapIsdaFixModel
        else
            let o = new ChfLiborSwapIsdaFixModel ()
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
  %CHF %Libor %Swap indexes fixed by ISDA in cooperation with Reuters and Intercapital Brokers at 11am London. Annual 30/360 vs 6M Libor, 1Y vs 3M Libor. Reuters page ISDAFIX4 or CHFSFIX=.  Further info can be found at <http://www.isda.org/fix/isdafix.html> or Reuters page ISDAFIX.

  </summary> *)
[<AutoSerializable(true)>]
type ChfLiborSwapIsdaFixModel1
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<ChfLiborSwapIsdaFix> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let _ChfLiborSwapIsdaFix                       = cell (fun () -> new ChfLiborSwapIsdaFix (tenor.Value))
    let _clone                                     (tenor : ICell<Period>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clone(tenor.Value))
    let _clone1                                    (forwarding : ICell<Handle<YieldTermStructure>>) (discounting : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clone(forwarding.Value, discounting.Value))
    let _clone2                                    (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clone(forwarding.Value))
    let _discountingTermStructure                  = triv (fun () -> _ChfLiborSwapIsdaFix.Value.discountingTermStructure())
    let _exogenousDiscount                         = triv (fun () -> _ChfLiborSwapIsdaFix.Value.exogenousDiscount())
    let _fixedLegConvention                        = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixedLegConvention())
    let _fixedLegTenor                             = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixedLegTenor())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.forwardingTermStructure())
    let _iborIndex                                 = triv (fun () -> _ChfLiborSwapIsdaFix.Value.iborIndex())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.maturityDate(valueDate.Value))
    let _underlyingSwap                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.underlyingSwap(fixingDate.Value))
    let _currency                                  = triv (fun () -> _ChfLiborSwapIsdaFix.Value.currency())
    let _dayCounter                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.dayCounter())
    let _familyName                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _ChfLiborSwapIsdaFix.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _ChfLiborSwapIsdaFix.Value.tenor())
    let _update                                    = triv (fun () -> _ChfLiborSwapIsdaFix.Value.update()
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _allowsNativeFixings                       = triv (fun () -> _ChfLiborSwapIsdaFix.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _ChfLiborSwapIsdaFix.Value.clearFixings()
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.registerWith(handler.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    let _timeSeries                                = triv (fun () -> _ChfLiborSwapIsdaFix.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _ChfLiborSwapIsdaFix.Value.unregisterWith(handler.Value)
                                                                     _ChfLiborSwapIsdaFix.Value)
    do this.Bind(_ChfLiborSwapIsdaFix)
(* 
    casting 
*)
    internal new () = new ChfLiborSwapIsdaFixModel1(null)
    member internal this.Inject v = _ChfLiborSwapIsdaFix.Value <- v
    static member Cast (p : ICell<ChfLiborSwapIsdaFix>) = 
        if p :? ChfLiborSwapIsdaFixModel1 then 
            p :?> ChfLiborSwapIsdaFixModel1
        else
            let o = new ChfLiborSwapIsdaFixModel1 ()
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
