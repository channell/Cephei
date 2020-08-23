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
  The BMA index is the short-term tax-exempt reference index of the Bond Market Association.  It has tenor one week, is fixed weekly on Wednesdays and is applied with a one-day's fixing gap from Thursdays on for one week.  It is the tax-exempt correspondent of the 1M USD-Libor.

  </summary> *)
[<AutoSerializable(true)>]
type BMAIndexModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<BMAIndex> ()
(*
    Parameters
*)
    let _h                                         = h
(*
    Functions
*)
    let _BMAIndex                                  = cell (fun () -> new BMAIndex (h.Value))
    let _fixingSchedule                            (start : ICell<Date>) (End : ICell<Date>)   
                                                   = triv (fun () -> _BMAIndex.Value.fixingSchedule(start.Value, End.Value))
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _BMAIndex.Value.forecastFixing(fixingDate.Value))
    let _forwardingTermStructure                   = triv (fun () -> _BMAIndex.Value.forwardingTermStructure())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _BMAIndex.Value.isValidFixingDate(fixingDate.Value))
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _BMAIndex.Value.maturityDate(valueDate.Value))
    let _name                                      = triv (fun () -> _BMAIndex.Value.name())
    let _currency                                  = triv (fun () -> _BMAIndex.Value.currency())
    let _dayCounter                                = triv (fun () -> _BMAIndex.Value.dayCounter())
    let _familyName                                = triv (fun () -> _BMAIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _BMAIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _BMAIndex.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _BMAIndex.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _BMAIndex.Value.fixingDays())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _BMAIndex.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _BMAIndex.Value.tenor())
    let _update                                    = triv (fun () -> _BMAIndex.Value.update()
                                                                     _BMAIndex.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _BMAIndex.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _BMAIndex.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _BMAIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _BMAIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _BMAIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _BMAIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _BMAIndex.Value)
    let _allowsNativeFixings                       = triv (fun () -> _BMAIndex.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _BMAIndex.Value.clearFixings()
                                                                     _BMAIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BMAIndex.Value.registerWith(handler.Value)
                                                                     _BMAIndex.Value)
    let _timeSeries                                = triv (fun () -> _BMAIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BMAIndex.Value.unregisterWith(handler.Value)
                                                                     _BMAIndex.Value)
    do this.Bind(_BMAIndex)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.FixingSchedule                     start End   
                                                   = _fixingSchedule start End 
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.Name                               = _name
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
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
