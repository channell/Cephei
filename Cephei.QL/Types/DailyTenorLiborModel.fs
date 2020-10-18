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
  One day deposit LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.
http://www.bba.org.uk/bba/jsp/polopoly.jsp?d=225&a=1412 : no o/n or s/n fixings (as the case may be) will take place when the principal centre of the currency concerned is closed but London is open on the fixing day.
  </summary> *)
[<AutoSerializable(true)>]
type DailyTenorLiborModel
    ( familyName                                   : ICell<string>
    , settlementDays                               : ICell<int>
    , currency                                     : ICell<Currency>
    , financialCenterCalendar                      : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<DailyTenorLibor> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _settlementDays                            = settlementDays
    let _currency                                  = currency
    let _financialCenterCalendar                   = financialCenterCalendar
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let mutable
        _DailyTenorLibor                           = cell (fun () -> new DailyTenorLibor (familyName.Value, settlementDays.Value, currency.Value, financialCenterCalendar.Value, dayCounter.Value))
    let _businessDayConvention                     = triv (fun () -> _DailyTenorLibor.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _DailyTenorLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _DailyTenorLibor.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.maturityDate(valueDate.Value))
    let _currency                                  = triv (fun () -> _DailyTenorLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _DailyTenorLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _DailyTenorLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _DailyTenorLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _DailyTenorLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _DailyTenorLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _DailyTenorLibor.Value.tenor())
    let _update                                    = triv (fun () -> _DailyTenorLibor.Value.update()
                                                                     _DailyTenorLibor.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _DailyTenorLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _DailyTenorLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _DailyTenorLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _DailyTenorLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _DailyTenorLibor.Value.clearFixings()
                                                                     _DailyTenorLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.registerWith(handler.Value)
                                                                     _DailyTenorLibor.Value)
    let _timeSeries                                = triv (fun () -> _DailyTenorLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.unregisterWith(handler.Value)
                                                                     _DailyTenorLibor.Value)
    do this.Bind(_DailyTenorLibor)
(* 
    casting 
*)
    internal new () = new DailyTenorLiborModel(null,null,null,null,null)
    member internal this.Inject v = _DailyTenorLibor <- v
    static member Cast (p : ICell<DailyTenorLibor>) = 
        if p :? DailyTenorLiborModel then 
            p :?> DailyTenorLiborModel
        else
            let o = new DailyTenorLiborModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.settlementDays                     = _settlementDays 
    member this.currency                           = _currency 
    member this.financialCenterCalendar            = _financialCenterCalendar 
    member this.dayCounter                         = _dayCounter 
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
  One day deposit LIBOR fixed by ICE.  See <https://www.theice.com/marketdata/reports/170>.

  </summary> *)
[<AutoSerializable(true)>]
type DailyTenorLiborModel1
    ( familyName                                   : ICell<string>
    , settlementDays                               : ICell<int>
    , currency                                     : ICell<Currency>
    , financialCenterCalendar                      : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<DailyTenorLibor> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _settlementDays                            = settlementDays
    let _currency                                  = currency
    let _financialCenterCalendar                   = financialCenterCalendar
    let _dayCounter                                = dayCounter
    let _h                                         = h
(*
    Functions
*)
    let mutable
        _DailyTenorLibor                           = cell (fun () -> new DailyTenorLibor (familyName.Value, settlementDays.Value, currency.Value, financialCenterCalendar.Value, dayCounter.Value, h.Value))
    let _businessDayConvention                     = triv (fun () -> _DailyTenorLibor.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _DailyTenorLibor.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _DailyTenorLibor.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.maturityDate(valueDate.Value))
    let _currency                                  = triv (fun () -> _DailyTenorLibor.Value.currency())
    let _dayCounter                                = triv (fun () -> _DailyTenorLibor.Value.dayCounter())
    let _familyName                                = triv (fun () -> _DailyTenorLibor.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _DailyTenorLibor.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _DailyTenorLibor.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _DailyTenorLibor.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _DailyTenorLibor.Value.tenor())
    let _update                                    = triv (fun () -> _DailyTenorLibor.Value.update()
                                                                     _DailyTenorLibor.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _DailyTenorLibor.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _DailyTenorLibor.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _DailyTenorLibor.Value)
    let _allowsNativeFixings                       = triv (fun () -> _DailyTenorLibor.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _DailyTenorLibor.Value.clearFixings()
                                                                     _DailyTenorLibor.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.registerWith(handler.Value)
                                                                     _DailyTenorLibor.Value)
    let _timeSeries                                = triv (fun () -> _DailyTenorLibor.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _DailyTenorLibor.Value.unregisterWith(handler.Value)
                                                                     _DailyTenorLibor.Value)
    do this.Bind(_DailyTenorLibor)
(* 
    casting 
*)
    internal new () = new DailyTenorLiborModel1(null,null,null,null,null,null)
    member internal this.Inject v = _DailyTenorLibor <- v
    static member Cast (p : ICell<DailyTenorLibor>) = 
        if p :? DailyTenorLiborModel1 then 
            p :?> DailyTenorLiborModel1
        else
            let o = new DailyTenorLiborModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.settlementDays                     = _settlementDays 
    member this.currency                           = _currency 
    member this.financialCenterCalendar            = _financialCenterCalendar 
    member this.dayCounter                         = _dayCounter 
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
