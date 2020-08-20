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


  </summary> *)
[<AutoSerializable(true)>]
type OvernightIndexModel
    ( familyName                                   : ICell<string>
    , settlementDays                               : ICell<int>
    , currency                                     : ICell<Currency>
    , fixingCalendar                               : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<OvernightIndex> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _settlementDays                            = settlementDays
    let _currency                                  = currency
    let _fixingCalendar                            = fixingCalendar
    let _dayCounter                                = dayCounter
    let _h                                         = h
(*
    Functions
*)
    let _OvernightIndex                            = cell (fun () -> new OvernightIndex (familyName.Value, settlementDays.Value, currency.Value, fixingCalendar.Value, dayCounter.Value, h.Value))
    let _clone                                     (h : ICell<Handle<YieldTermStructure>>)   
                                                   = cell (fun () -> _OvernightIndex.Value.clone(h.Value))
    let _businessDayConvention                     = cell (fun () -> _OvernightIndex.Value.businessDayConvention())
    let _endOfMonth                                = cell (fun () -> _OvernightIndex.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _OvernightIndex.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = cell (fun () -> _OvernightIndex.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = cell (fun () -> _OvernightIndex.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = cell (fun () -> _OvernightIndex.Value.maturityDate(valueDate.Value))
    let _currency                                  = cell (fun () -> _OvernightIndex.Value.currency())
    let _dayCounter                                = cell (fun () -> _OvernightIndex.Value.dayCounter())
    let _familyName                                = cell (fun () -> _OvernightIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _OvernightIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = cell (fun () -> _OvernightIndex.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = cell (fun () -> _OvernightIndex.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = cell (fun () -> _OvernightIndex.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _OvernightIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _OvernightIndex.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _OvernightIndex.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = cell (fun () -> _OvernightIndex.Value.tenor())
    let _update                                    = cell (fun () -> _OvernightIndex.Value.update()
                                                                     _OvernightIndex.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _OvernightIndex.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _OvernightIndex.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _OvernightIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _OvernightIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _OvernightIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _OvernightIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _OvernightIndex.Value)
    let _allowsNativeFixings                       = cell (fun () -> _OvernightIndex.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _OvernightIndex.Value.clearFixings()
                                                                     _OvernightIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _OvernightIndex.Value.registerWith(handler.Value)
                                                                     _OvernightIndex.Value)
    let _timeSeries                                = cell (fun () -> _OvernightIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _OvernightIndex.Value.unregisterWith(handler.Value)
                                                                     _OvernightIndex.Value)
    do this.Bind(_OvernightIndex)

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.settlementDays                     = _settlementDays 
    member this.currency                           = _currency 
    member this.fixingCalendar                     = _fixingCalendar 
    member this.dayCounter                         = _dayCounter 
    member this.h                                  = _h 
    member this.Clone                              h   
                                                   = _clone h 
    member this.BusinessDayConvention              = _businessDayConvention
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
