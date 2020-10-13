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
  TRY LIBOR fixed by TBA.  See <http://www.trlibor.org/trlibor/english/>  check end-of-month adjustment.

  </summary> *)
[<AutoSerializable(true)>]
type TRLiborModel
    ( tenor                                        : ICell<Period>
    ) as this =

    inherit Model<TRLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
(*
    Functions
*)
    let _TRLibor                                   = cell (fun () -> new TRLibor (tenor.Value))
    let _businessDayConvention                     = triv (fun () -> _TRLibor.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _TRLibor.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _TRLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _TRLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _TRLibor.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.maturityDate(valueDate.Value))
    let _currency                                  = triv (fun () -> _TRLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _TRLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _TRLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _TRLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _TRLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _TRLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _TRLibor.Value.tenor())
    let _update                                    = triv (fun () -> _TRLibor.Value.update()
                                                                     _TRLibor.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _TRLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _TRLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _TRLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _TRLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _TRLibor.Value.clearFixings()
                                                                     _TRLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TRLibor.Value.registerWith(handler.Value)
                                                                     _TRLibor.Value)
    let _timeSeries                                = triv (fun () -> _TRLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TRLibor.Value.unregisterWith(handler.Value)
                                                                     _TRLibor.Value)
    do this.Bind(_TRLibor)
(* 
    casting 
*)
    internal new () = new TRLiborModel(null)
    member internal this.Inject v = _TRLibor.Value <- v
    static member Cast (p : ICell<TRLibor>) = 
        if p :? TRLiborModel then 
            p :?> TRLiborModel
        else
            let o = new TRLiborModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
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
  TRY LIBOR fixed by TBA.  See <http://www.trlibor.org/trlibor/english/>  check end-of-month adjustment.

  </summary> *)
[<AutoSerializable(true)>]
type TRLiborModel1
    ( tenor                                        : ICell<Period>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<TRLibor> ()
(*
    Parameters
*)
    let _tenor                                     = tenor
    let _h                                         = h
(*
    Functions
*)
    let _TRLibor                                   = cell (fun () -> new TRLibor (tenor.Value, h.Value))
    let _businessDayConvention                     = triv (fun () -> _TRLibor.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _TRLibor.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _TRLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _TRLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _TRLibor.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.maturityDate(valueDate.Value))
    let _currency                                  = triv (fun () -> _TRLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _TRLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _TRLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _TRLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _TRLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _TRLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _TRLibor.Value.tenor())
    let _update                                    = triv (fun () -> _TRLibor.Value.update()
                                                                     _TRLibor.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _TRLibor.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _TRLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _TRLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _TRLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _TRLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _TRLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _TRLibor.Value.clearFixings()
                                                                     _TRLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TRLibor.Value.registerWith(handler.Value)
                                                                     _TRLibor.Value)
    let _timeSeries                                = triv (fun () -> _TRLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _TRLibor.Value.unregisterWith(handler.Value)
                                                                     _TRLibor.Value)
    do this.Bind(_TRLibor)
(* 
    casting 
*)
    internal new () = new TRLiborModel1(null,null)
    member internal this.Inject v = _TRLibor.Value <- v
    static member Cast (p : ICell<TRLibor>) = 
        if p :? TRLiborModel1 then 
            p :?> TRLiborModel1
        else
            let o = new TRLiborModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.tenor                              = _tenor 
    member this.h                                  = _h 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
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
