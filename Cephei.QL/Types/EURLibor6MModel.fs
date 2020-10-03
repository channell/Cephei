﻿(*
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
  6-months %EUR %Libor index

  </summary> *)
[<AutoSerializable(true)>]
type EURLibor6MModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<EURLibor6M> ()
(*
    Parameters
*)
    let _h                                         = h
(*
    Functions
*)
    let _EURLibor6M                                = cell (fun () -> new EURLibor6M (h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _EURLibor6M.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EURLibor6M.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _EURLibor6M.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _EURLibor6M.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _EURLibor6M.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _EURLibor6M.Value.currency())
    let _dayCounter                                = triv (fun () -> _EURLibor6M.Value.dayCounter())
    let _familyName                                = triv (fun () -> _EURLibor6M.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _EURLibor6M.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _EURLibor6M.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _EURLibor6M.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _EURLibor6M.Value.tenor())
    let _update                                    = triv (fun () -> _EURLibor6M.Value.update()
                                                                     _EURLibor6M.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor6M.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor6M.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _EURLibor6M.Value)
    let _allowsNativeFixings                       = triv (fun () -> _EURLibor6M.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _EURLibor6M.Value.clearFixings()
                                                                     _EURLibor6M.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor6M.Value.registerWith(handler.Value)
                                                                     _EURLibor6M.Value)
    let _timeSeries                                = triv (fun () -> _EURLibor6M.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor6M.Value.unregisterWith(handler.Value)
                                                                     _EURLibor6M.Value)
    do this.Bind(_EURLibor6M)
(* 
    casting 
*)
    internal new () = EURLibor6MModel(null)
    member internal this.Inject v = _EURLibor6M.Value <- v
    static member Cast (p : ICell<EURLibor6M>) = 
        if p :? EURLibor6MModel then 
            p :?> EURLibor6MModel
        else
            let o = new EURLibor6MModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
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
  6-months %EUR %Libor index

  </summary> *)
[<AutoSerializable(true)>]
type EURLibor6MModel1
    () as this =
    inherit Model<EURLibor6M> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _EURLibor6M                                = cell (fun () -> new EURLibor6M ())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _EURLibor6M.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EURLibor6M.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _EURLibor6M.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _EURLibor6M.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _EURLibor6M.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _EURLibor6M.Value.currency())
    let _dayCounter                                = triv (fun () -> _EURLibor6M.Value.dayCounter())
    let _familyName                                = triv (fun () -> _EURLibor6M.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _EURLibor6M.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _EURLibor6M.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _EURLibor6M.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor6M.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _EURLibor6M.Value.tenor())
    let _update                                    = triv (fun () -> _EURLibor6M.Value.update()
                                                                     _EURLibor6M.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor6M.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor6M.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor6M.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _EURLibor6M.Value)
    let _allowsNativeFixings                       = triv (fun () -> _EURLibor6M.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _EURLibor6M.Value.clearFixings()
                                                                     _EURLibor6M.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor6M.Value.registerWith(handler.Value)
                                                                     _EURLibor6M.Value)
    let _timeSeries                                = triv (fun () -> _EURLibor6M.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor6M.Value.unregisterWith(handler.Value)
                                                                     _EURLibor6M.Value)
    do this.Bind(_EURLibor6M)
(* 
    casting 
*)
    
    member internal this.Inject v = _EURLibor6M.Value <- v
    static member Cast (p : ICell<EURLibor6M>) = 
        if p :? EURLibor6MModel1 then 
            p :?> EURLibor6MModel1
        else
            let o = new EURLibor6MModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
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
