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
  Base class for zero inflation indices.
! Always use the evaluation date as the reference date
  </summary> *)
[<AutoSerializable(true)>]
type ZeroInflationIndexModel
    ( familyName                                   : ICell<string>
    , region                                       : ICell<Region>
    , revised                                      : ICell<bool>
    , interpolated                                 : ICell<bool>
    , frequency                                    : ICell<Frequency>
    , availabilityLag                              : ICell<Period>
    , currency                                     : ICell<Currency>
    , ts                                           : ICell<Handle<ZeroInflationTermStructure>>
    ) as this =

    inherit Model<ZeroInflationIndex> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _region                                    = region
    let _revised                                   = revised
    let _interpolated                              = interpolated
    let _frequency                                 = frequency
    let _availabilityLag                           = availabilityLag
    let _currency                                  = currency
    let _ts                                        = ts
(*
    Functions
*)
    let _ZeroInflationIndex                        = cell (fun () -> new ZeroInflationIndex (familyName.Value, region.Value, revised.Value, interpolated.Value, frequency.Value, availabilityLag.Value, currency.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = cell (fun () -> _ZeroInflationIndex.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _ZeroInflationIndex.Value)
    let _availabilityLag                           = cell (fun () -> _ZeroInflationIndex.Value.availabilityLag())
    let _currency                                  = cell (fun () -> _ZeroInflationIndex.Value.currency())
    let _familyName                                = cell (fun () -> _ZeroInflationIndex.Value.familyName())
    let _fixingCalendar                            = cell (fun () -> _ZeroInflationIndex.Value.fixingCalendar())
    let _frequency                                 = cell (fun () -> _ZeroInflationIndex.Value.frequency())
    let _interpolated                              = cell (fun () -> _ZeroInflationIndex.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _ZeroInflationIndex.Value.name())
    let _region                                    = cell (fun () -> _ZeroInflationIndex.Value.region())
    let _revised                                   = cell (fun () -> _ZeroInflationIndex.Value.revised())
    let _update                                    = cell (fun () -> _ZeroInflationIndex.Value.update()
                                                                     _ZeroInflationIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _ZeroInflationIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _ZeroInflationIndex.Value)
    let _allowsNativeFixings                       = cell (fun () -> _ZeroInflationIndex.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _ZeroInflationIndex.Value.clearFixings()
                                                                     _ZeroInflationIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.registerWith(handler.Value)
                                                                     _ZeroInflationIndex.Value)
    let _timeSeries                                = cell (fun () -> _ZeroInflationIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _ZeroInflationIndex.Value.unregisterWith(handler.Value)
                                                                     _ZeroInflationIndex.Value)
    do this.Bind(_ZeroInflationIndex)

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.region                             = _region 
    member this.revised                            = _revised 
    member this.interpolated                       = _interpolated 
    member this.frequency                          = _frequency 
    member this.availabilityLag                    = _availabilityLag 
    member this.currency                           = _currency 
    member this.ts                                 = _ts 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             aFixingDate forecastTodaysFixing   
                                                   = _fixing aFixingDate forecastTodaysFixing 
    member this.ZeroInflationTermStructure         = _zeroInflationTermStructure
    member this.AddFixing                          fixingDate fixing forceOverwrite   
                                                   = _addFixing fixingDate fixing forceOverwrite 
    member this.AvailabilityLag                    = _availabilityLag
    member this.Currency                           = _currency
    member this.FamilyName                         = _familyName
    member this.FixingCalendar                     = _fixingCalendar
    member this.Frequency                          = _frequency
    member this.Interpolated                       = _interpolated
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.Region                             = _region
    member this.Revised                            = _revised
    member this.Update                             = _update
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
