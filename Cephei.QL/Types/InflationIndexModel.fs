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
  Base class for inflation-rate indexes,
! An inflation index may return interpolated values.  These are linearly interpolated values with act/act convention within a period. Note that stored "fixings" are always flat (constant) within a period and interpolated as needed.  This is because interpolation adds an addional availability lag (because you always need the next period to give the previous period's value) and enables storage of the most recent uninterpolated value.
  </summary> *)
[<AutoSerializable(true)>]
type InflationIndexModel
    ( familyName                                   : ICell<string>
    , region                                       : ICell<Region>
    , revised                                      : ICell<bool>
    , interpolated                                 : ICell<bool>
    , frequency                                    : ICell<Frequency>
    , availabilitiyLag                             : ICell<Period>
    , currency                                     : ICell<Currency>
    ) as this =

    inherit Model<InflationIndex> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _region                                    = region
    let _revised                                   = revised
    let _interpolated                              = interpolated
    let _frequency                                 = frequency
    let _availabilitiyLag                          = availabilitiyLag
    let _currency                                  = currency
(*
    Functions
*)
    let _InflationIndex                            = cell (fun () -> new InflationIndex (familyName.Value, region.Value, revised.Value, interpolated.Value, frequency.Value, availabilitiyLag.Value, currency.Value))
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _InflationIndex.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _InflationIndex.Value)
    let _availabilityLag                           = cell (fun () -> _InflationIndex.Value.availabilityLag())
    let _currency                                  = cell (fun () -> _InflationIndex.Value.currency())
    let _familyName                                = cell (fun () -> _InflationIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = cell (fun () -> _InflationIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = cell (fun () -> _InflationIndex.Value.fixingCalendar())
    let _frequency                                 = cell (fun () -> _InflationIndex.Value.frequency())
    let _interpolated                              = cell (fun () -> _InflationIndex.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = cell (fun () -> _InflationIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = cell (fun () -> _InflationIndex.Value.name())
    let _region                                    = cell (fun () -> _InflationIndex.Value.region())
    let _revised                                   = cell (fun () -> _InflationIndex.Value.revised())
    let _update                                    = cell (fun () -> _InflationIndex.Value.update()
                                                                     _InflationIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _InflationIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _InflationIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = cell (fun () -> _InflationIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _InflationIndex.Value)
    let _allowsNativeFixings                       = cell (fun () -> _InflationIndex.Value.allowsNativeFixings())
    let _clearFixings                              = cell (fun () -> _InflationIndex.Value.clearFixings()
                                                                     _InflationIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _InflationIndex.Value.registerWith(handler.Value)
                                                                     _InflationIndex.Value)
    let _timeSeries                                = cell (fun () -> _InflationIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _InflationIndex.Value.unregisterWith(handler.Value)
                                                                     _InflationIndex.Value)
    do this.Bind(_InflationIndex)

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.region                             = _region 
    member this.revised                            = _revised 
    member this.interpolated                       = _interpolated 
    member this.frequency                          = _frequency 
    member this.availabilitiyLag                   = _availabilitiyLag 
    member this.currency                           = _currency 
    member this.AddFixing                          fixingDate fixing forceOverwrite   
                                                   = _addFixing fixingDate fixing forceOverwrite 
    member this.AvailabilityLag                    = _availabilityLag
    member this.Currency                           = _currency
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
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
