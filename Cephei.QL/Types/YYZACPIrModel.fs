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
  Fake year-on-year South African CPI (i.e. a ratio of South African CPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYZACPIrModel
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<YYZACPIr> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let mutable
        _YYZACPIr                                  = cell (fun () -> new YYZACPIr (interpolated.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv (fun () -> _YYZACPIr.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv (fun () -> _YYZACPIr.Value.ratio())
    let _yoyInflationTermStructure                 = triv (fun () -> _YYZACPIr.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _YYZACPIr.Value)
    let _availabilityLag                           = triv (fun () -> _YYZACPIr.Value.availabilityLag())
    let _currency                                  = triv (fun () -> _YYZACPIr.Value.currency())
    let _familyName                                = triv (fun () -> _YYZACPIr.Value.familyName())
    let _fixingCalendar                            = triv (fun () -> _YYZACPIr.Value.fixingCalendar())
    let _frequency                                 = triv (fun () -> _YYZACPIr.Value.frequency())
    let _interpolated                              = triv (fun () -> _YYZACPIr.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _YYZACPIr.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _YYZACPIr.Value.name())
    let _region                                    = triv (fun () -> _YYZACPIr.Value.region())
    let _revised                                   = triv (fun () -> _YYZACPIr.Value.revised())
    let _update                                    = triv (fun () -> _YYZACPIr.Value.update()
                                                                     _YYZACPIr.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _YYZACPIr.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _YYZACPIr.Value)
    let _allowsNativeFixings                       = triv (fun () -> _YYZACPIr.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _YYZACPIr.Value.clearFixings()
                                                                     _YYZACPIr.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYZACPIr.Value.registerWith(handler.Value)
                                                                     _YYZACPIr.Value)
    let _timeSeries                                = triv (fun () -> _YYZACPIr.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYZACPIr.Value.unregisterWith(handler.Value)
                                                                     _YYZACPIr.Value)
    do this.Bind(_YYZACPIr)
(* 
    casting 
*)
    internal new () = new YYZACPIrModel(null)
    member internal this.Inject v = _YYZACPIr <- v
    static member Cast (p : ICell<YYZACPIr>) = 
        if p :? YYZACPIrModel then 
            p :?> YYZACPIrModel
        else
            let o = new YYZACPIrModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.Ratio                              = _ratio
    member this.YoyInflationTermStructure          = _yoyInflationTermStructure
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
(* <summary>
  Fake year-on-year South African CPI (i.e. a ratio of South African CPI)

  </summary> *)
[<AutoSerializable(true)>]
type YYZACPIrModel1
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<YoYInflationTermStructure>>
    ) as this =

    inherit Model<YYZACPIr> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let mutable
        _YYZACPIr                                  = cell (fun () -> new YYZACPIr (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv (fun () -> _YYZACPIr.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv (fun () -> _YYZACPIr.Value.ratio())
    let _yoyInflationTermStructure                 = triv (fun () -> _YYZACPIr.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _YYZACPIr.Value)
    let _availabilityLag                           = triv (fun () -> _YYZACPIr.Value.availabilityLag())
    let _currency                                  = triv (fun () -> _YYZACPIr.Value.currency())
    let _familyName                                = triv (fun () -> _YYZACPIr.Value.familyName())
    let _fixingCalendar                            = triv (fun () -> _YYZACPIr.Value.fixingCalendar())
    let _frequency                                 = triv (fun () -> _YYZACPIr.Value.frequency())
    let _interpolated                              = triv (fun () -> _YYZACPIr.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _YYZACPIr.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _YYZACPIr.Value.name())
    let _region                                    = triv (fun () -> _YYZACPIr.Value.region())
    let _revised                                   = triv (fun () -> _YYZACPIr.Value.revised())
    let _update                                    = triv (fun () -> _YYZACPIr.Value.update()
                                                                     _YYZACPIr.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _YYZACPIr.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYZACPIr.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _YYZACPIr.Value)
    let _allowsNativeFixings                       = triv (fun () -> _YYZACPIr.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _YYZACPIr.Value.clearFixings()
                                                                     _YYZACPIr.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYZACPIr.Value.registerWith(handler.Value)
                                                                     _YYZACPIr.Value)
    let _timeSeries                                = triv (fun () -> _YYZACPIr.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYZACPIr.Value.unregisterWith(handler.Value)
                                                                     _YYZACPIr.Value)
    do this.Bind(_YYZACPIr)
(* 
    casting 
*)
    internal new () = new YYZACPIrModel1(null,null)
    member internal this.Inject v = _YYZACPIr <- v
    static member Cast (p : ICell<YYZACPIr>) = 
        if p :? YYZACPIrModel1 then 
            p :?> YYZACPIrModel1
        else
            let o = new YYZACPIrModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
    member this.ts                                 = _ts 
    member this.Clone                              h   
                                                   = _clone h 
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.Ratio                              = _ratio
    member this.YoyInflationTermStructure          = _yoyInflationTermStructure
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
