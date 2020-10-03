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
  Australian Dollar LIBOR discontinued as of 2013.

  </summary> *)
[<AutoSerializable(true)>]
type AUDLiborModel
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<AUDLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let _AUDLibor                                  = cell (fun () -> new AUDLibor (tenor.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _AUDLibor.Value.clone(h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _AUDLibor.Value.businessDayConvention())
    let _endOfMonth                                = triv (fun () -> _AUDLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _AUDLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _AUDLibor.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _AUDLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _AUDLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _AUDLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _AUDLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _AUDLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _AUDLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _AUDLibor.Value.tenor())
    let _update                                    = triv (fun () -> _AUDLibor.Value.update()
                                                                     _AUDLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _AUDLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _AUDLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _AUDLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _AUDLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _AUDLibor.Value.clearFixings()
                                                                     _AUDLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AUDLibor.Value.registerWith(handler.Value)
                                                                     _AUDLibor.Value)
    let _timeSeries                                = triv (fun () -> _AUDLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AUDLibor.Value.unregisterWith(handler.Value)
                                                                     _AUDLibor.Value)
    do this.Bind(_AUDLibor)
(* 
    casting 
*)
    internal new () = AUDLiborModel(null)
    member internal this.Inject v = _AUDLibor.Value <- v
    static member Cast (p : ICell<AUDLibor>) = 
        if p :? AUDLiborModel then 
            p :?> AUDLiborModel
        else
            let o = new AUDLiborModel ()
            o.Inject p.Value
            o
                            

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
(* <summary>
  Australian Dollar LIBOR discontinued as of 2013.

  </summary> *)
[<AutoSerializable(true)>]
type AUDLiborModel1
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<AUDLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let _AUDLibor                                  = cell (fun () -> new AUDLibor (tenor.Value, h.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _AUDLibor.Value.clone(h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _AUDLibor.Value.businessDayConvention())
    let _endOfMonth                                = triv (fun () -> _AUDLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _AUDLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _AUDLibor.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _AUDLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _AUDLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _AUDLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _AUDLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _AUDLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _AUDLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _AUDLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _AUDLibor.Value.tenor())
    let _update                                    = triv (fun () -> _AUDLibor.Value.update()
                                                                     _AUDLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _AUDLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _AUDLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _AUDLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _AUDLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _AUDLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _AUDLibor.Value.clearFixings()
                                                                     _AUDLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AUDLibor.Value.registerWith(handler.Value)
                                                                     _AUDLibor.Value)
    let _timeSeries                                = triv (fun () -> _AUDLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _AUDLibor.Value.unregisterWith(handler.Value)
                                                                     _AUDLibor.Value)
    do this.Bind(_AUDLibor)
(* 
    casting 
*)
    internal new () = AUDLiborModel1(null,null)
    member internal this.Inject v = _AUDLibor.Value <- v
    static member Cast (p : ICell<AUDLibor>) = 
        if p :? AUDLiborModel1 then 
            p :?> AUDLiborModel1
        else
            let o = new AUDLiborModel1 ()
            o.Inject p.Value
            o
                            

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
