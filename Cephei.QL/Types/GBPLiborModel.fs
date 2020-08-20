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
  Pound Sterling LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.

  </summary> *)
[<AutoSerializable(true)>]
type GBPLiborModel
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<GBPLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let _GBPLibor                                  = cell (fun () -> new GBPLibor (tenor.Value, h.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = cell (fun () -> _GBPLibor.Value.clone(h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = cell (fun () -> _GBPLibor.Value.businessDayConvention())
    let _endOfMonth                                = cell (fun () -> _GBPLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = cell (fun () -> _GBPLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = cell (fun () -> _GBPLibor.Value.forwardingTermStructure())
    let _currency                                  = cell (fun () -> _GBPLibor.Value.currency())
    let _dayCounter                                = cell (fun () -> _GBPLibor.Value.dayCounter())
    let _familyName                                = cell (fun () -> _GBPLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = cell (fun () -> _GBPLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = cell (fun () -> _GBPLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _GBPLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = cell (fun () -> _GBPLibor.Value.tenor())
    let _update                                    = cell (fun () -> _GBPLibor.Value.update()
                                                                     _GBPLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _GBPLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _GBPLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _GBPLibor.Value)
    let _allowsNativeFixings                       = cell (fun () -> _GBPLibor.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _GBPLibor.Value.clearFixings()
                                                                     _GBPLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _GBPLibor.Value.registerWith(handler.Value)
                                                                     _GBPLibor.Value)
    let _timeSeries                                = cell (fun () -> _GBPLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _GBPLibor.Value.unregisterWith(handler.Value)
                                                                     _GBPLibor.Value)
    do this.Bind(_GBPLibor)

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.h                                  = _h 
    member this.Clone                              h   
                                                   = _clone h 
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
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
  Pound Sterling LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.

  </summary> *)
[<AutoSerializable(true)>]
type GBPLiborModel1
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<GBPLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let _GBPLibor                                  = cell (fun () -> new GBPLibor (tenor.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = cell (fun () -> _GBPLibor.Value.clone(h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = cell (fun () -> _GBPLibor.Value.businessDayConvention())
    let _endOfMonth                                = cell (fun () -> _GBPLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = cell (fun () -> _GBPLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = cell (fun () -> _GBPLibor.Value.forwardingTermStructure())
    let _currency                                  = cell (fun () -> _GBPLibor.Value.currency())
    let _dayCounter                                = cell (fun () -> _GBPLibor.Value.dayCounter())
    let _familyName                                = cell (fun () -> _GBPLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = cell (fun () -> _GBPLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = cell (fun () -> _GBPLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _GBPLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _GBPLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = cell (fun () -> _GBPLibor.Value.tenor())
    let _update                                    = cell (fun () -> _GBPLibor.Value.update()
                                                                     _GBPLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _GBPLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _GBPLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _GBPLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _GBPLibor.Value)
    let _allowsNativeFixings                       = cell (fun () -> _GBPLibor.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _GBPLibor.Value.clearFixings()
                                                                     _GBPLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _GBPLibor.Value.registerWith(handler.Value)
                                                                     _GBPLibor.Value)
    let _timeSeries                                = cell (fun () -> _GBPLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _GBPLibor.Value.unregisterWith(handler.Value)
                                                                     _GBPLibor.Value)
    do this.Bind(_GBPLibor)

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.Clone                              h   
                                                   = _clone h 
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
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
