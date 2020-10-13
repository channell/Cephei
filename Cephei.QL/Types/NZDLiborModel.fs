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
  New Zealand Dollar LIBOR discontinued as of 2013.

  </summary> *)
[<AutoSerializable(true)>]
type NZDLiborModel
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<NZDLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let _NZDLibor                                  = cell (fun () -> new NZDLibor (tenor.Value, h.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _NZDLibor.Value.clone(h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _NZDLibor.Value.businessDayConvention())
    let _endOfMonth                                = triv (fun () -> _NZDLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _NZDLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _NZDLibor.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _NZDLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _NZDLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _NZDLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _NZDLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _NZDLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _NZDLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _NZDLibor.Value.tenor())
    let _update                                    = triv (fun () -> _NZDLibor.Value.update()
                                                                     _NZDLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _NZDLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _NZDLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _NZDLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _NZDLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _NZDLibor.Value.clearFixings()
                                                                     _NZDLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _NZDLibor.Value.registerWith(handler.Value)
                                                                     _NZDLibor.Value)
    let _timeSeries                                = triv (fun () -> _NZDLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _NZDLibor.Value.unregisterWith(handler.Value)
                                                                     _NZDLibor.Value)
    do this.Bind(_NZDLibor)
(* 
    casting 
*)
    internal new () = new NZDLiborModel(null,null)
    member internal this.Inject v = _NZDLibor.Value <- v
    static member Cast (p : ICell<NZDLibor>) = 
        if p :? NZDLiborModel then 
            p :?> NZDLiborModel
        else
            let o = new NZDLiborModel ()
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
(* <summary>
  New Zealand Dollar LIBOR discontinued as of 2013.

  </summary> *)
[<AutoSerializable(true)>]
type NZDLiborModel1
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<NZDLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let _NZDLibor                                  = cell (fun () -> new NZDLibor (tenor.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _NZDLibor.Value.clone(h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _NZDLibor.Value.businessDayConvention())
    let _endOfMonth                                = triv (fun () -> _NZDLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _NZDLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _NZDLibor.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _NZDLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _NZDLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _NZDLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _NZDLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _NZDLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _NZDLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _NZDLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _NZDLibor.Value.tenor())
    let _update                                    = triv (fun () -> _NZDLibor.Value.update()
                                                                     _NZDLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _NZDLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _NZDLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _NZDLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _NZDLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _NZDLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _NZDLibor.Value.clearFixings()
                                                                     _NZDLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _NZDLibor.Value.registerWith(handler.Value)
                                                                     _NZDLibor.Value)
    let _timeSeries                                = triv (fun () -> _NZDLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _NZDLibor.Value.unregisterWith(handler.Value)
                                                                     _NZDLibor.Value)
    do this.Bind(_NZDLibor)
(* 
    casting 
*)
    internal new () = new NZDLiborModel1(null)
    member internal this.Inject v = _NZDLibor.Value <- v
    static member Cast (p : ICell<NZDLibor>) = 
        if p :? NZDLiborModel1 then 
            p :?> NZDLiborModel1
        else
            let o = new NZDLiborModel1 ()
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
