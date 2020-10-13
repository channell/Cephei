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
  Euro LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.  This is the rate fixed in London by BBA. Use Euribor if you're interested in the fixing by the ECB.
http://www.bba.org.uk/bba/jsp/polopoly.jsp?d=225&a=1412 : JoinBusinessDays is the fixing calendar for all indexes but o/n
  </summary> *)
[<AutoSerializable(true)>]
type EURLiborModel
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<EURLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let _EURLibor                                  = cell (fun () -> new EURLibor (tenor.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _EURLibor.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EURLibor.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _EURLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _EURLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _EURLibor.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _EURLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _EURLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _EURLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _EURLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _EURLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _EURLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _EURLibor.Value.tenor())
    let _update                                    = triv (fun () -> _EURLibor.Value.update()
                                                                     _EURLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _EURLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _EURLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _EURLibor.Value.clearFixings()
                                                                     _EURLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor.Value.registerWith(handler.Value)
                                                                     _EURLibor.Value)
    let _timeSeries                                = triv (fun () -> _EURLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor.Value.unregisterWith(handler.Value)
                                                                     _EURLibor.Value)
    do this.Bind(_EURLibor)
(* 
    casting 
*)
    internal new () = new EURLiborModel(null)
    member internal this.Inject v = _EURLibor.Value <- v
    static member Cast (p : ICell<EURLibor>) = 
        if p :? EURLiborModel then 
            p :?> EURLiborModel
        else
            let o = new EURLiborModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
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
  Euro LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.  This is the rate fixed in London by BBA. Use Euribor if you're interested in the fixing by the ECB.

  </summary> *)
[<AutoSerializable(true)>]
type EURLiborModel1
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<EURLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let _EURLibor                                  = cell (fun () -> new EURLibor (tenor.Value, h.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.maturityDate(valueDate.Value))
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.valueDate(fixingDate.Value))
    let _businessDayConvention                     = triv (fun () -> _EURLibor.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _EURLibor.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _EURLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _EURLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _EURLibor.Value.forwardingTermStructure())
    let _currency                                  = triv (fun () -> _EURLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _EURLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _EURLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _EURLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _EURLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _EURLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _EURLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _EURLibor.Value.tenor())
    let _update                                    = triv (fun () -> _EURLibor.Value.update()
                                                                     _EURLibor.Value)
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _EURLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _EURLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _EURLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _EURLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _EURLibor.Value.clearFixings()
                                                                     _EURLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor.Value.registerWith(handler.Value)
                                                                     _EURLibor.Value)
    let _timeSeries                                = triv (fun () -> _EURLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _EURLibor.Value.unregisterWith(handler.Value)
                                                                     _EURLibor.Value)
    do this.Bind(_EURLibor)
(* 
    casting 
*)
    internal new () = new EURLiborModel1(null,null)
    member internal this.Inject v = _EURLibor.Value <- v
    static member Cast (p : ICell<EURLibor>) = 
        if p :? EURLiborModel1 then 
            p :?> EURLiborModel1
        else
            let o = new EURLiborModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
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
