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
  Genuine year-on-year AU CPI (i.e. not a ratio)

  </summary> *)
[<AutoSerializable(true)>]
type YYAUCPIModel
    ( frequency                                    : ICell<Frequency>
    , revised                                      : ICell<bool>
    , interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<YYAUCPI> ()
(*
    Parameters
*)
    let _frequency                                 = frequency
    let _revised                                   = revised
    let _interpolated                              = interpolated
(*
    Functions
*)
    let mutable
        _YYAUCPI                                   = make (fun () -> new YYAUCPI (frequency.Value, revised.Value, interpolated.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv _YYAUCPI (fun () -> _YYAUCPI.Value.ratio())
    let _yoyInflationTermStructure                 = triv _YYAUCPI (fun () -> _YYAUCPI.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                              _YYAUCPI.Value)
    let _availabilityLag                           = triv _YYAUCPI (fun () -> _YYAUCPI.Value.availabilityLag())
    let _currency                                  = triv _YYAUCPI (fun () -> _YYAUCPI.Value.currency())
    let _familyName                                = triv _YYAUCPI (fun () -> _YYAUCPI.Value.familyName())
    let _fixingCalendar                            = triv _YYAUCPI (fun () -> _YYAUCPI.Value.fixingCalendar())
    let _frequency                                 = triv _YYAUCPI (fun () -> _YYAUCPI.Value.frequency())
    let _interpolated                              = triv _YYAUCPI (fun () -> _YYAUCPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _YYAUCPI (fun () -> _YYAUCPI.Value.name())
    let _region                                    = triv _YYAUCPI (fun () -> _YYAUCPI.Value.region())
    let _revised                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.revised())
    let _update                                    = triv _YYAUCPI (fun () -> _YYAUCPI.Value.update()
                                                                              _YYAUCPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                              _YYAUCPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                              _YYAUCPI.Value)
    let _allowsNativeFixings                       = triv _YYAUCPI (fun () -> _YYAUCPI.Value.allowsNativeFixings())
    let _clearFixings                              = triv _YYAUCPI (fun () -> _YYAUCPI.Value.clearFixings()
                                                                              _YYAUCPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.registerWith(handler.Value)
                                                                              _YYAUCPI.Value)
    let _timeSeries                                = triv _YYAUCPI (fun () -> _YYAUCPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.unregisterWith(handler.Value)
                                                                              _YYAUCPI.Value)
    do this.Bind(_YYAUCPI)
(* 
    casting 
*)
    internal new () = new YYAUCPIModel(null,null,null)
    member internal this.Inject v = _YYAUCPI <- v
    static member Cast (p : ICell<YYAUCPI>) = 
        if p :? YYAUCPIModel then 
            p :?> YYAUCPIModel
        else
            let o = new YYAUCPIModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.frequency                          = _frequency 
    member this.revised                            = _revised 
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
  Genuine year-on-year AU CPI (i.e. not a ratio)

  </summary> *)
[<AutoSerializable(true)>]
type YYAUCPIModel1
    ( frequency                                    : ICell<Frequency>
    , revised                                      : ICell<bool>
    , interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<YoYInflationTermStructure>>
    ) as this =

    inherit Model<YYAUCPI> ()
(*
    Parameters
*)
    let _frequency                                 = frequency
    let _revised                                   = revised
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let mutable
        _YYAUCPI                                   = make (fun () -> new YYAUCPI (frequency.Value, revised.Value, interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv _YYAUCPI (fun () -> _YYAUCPI.Value.ratio())
    let _yoyInflationTermStructure                 = triv _YYAUCPI (fun () -> _YYAUCPI.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                              _YYAUCPI.Value)
    let _availabilityLag                           = triv _YYAUCPI (fun () -> _YYAUCPI.Value.availabilityLag())
    let _currency                                  = triv _YYAUCPI (fun () -> _YYAUCPI.Value.currency())
    let _familyName                                = triv _YYAUCPI (fun () -> _YYAUCPI.Value.familyName())
    let _fixingCalendar                            = triv _YYAUCPI (fun () -> _YYAUCPI.Value.fixingCalendar())
    let _frequency                                 = triv _YYAUCPI (fun () -> _YYAUCPI.Value.frequency())
    let _interpolated                              = triv _YYAUCPI (fun () -> _YYAUCPI.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _YYAUCPI (fun () -> _YYAUCPI.Value.name())
    let _region                                    = triv _YYAUCPI (fun () -> _YYAUCPI.Value.region())
    let _revised                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.revised())
    let _update                                    = triv _YYAUCPI (fun () -> _YYAUCPI.Value.update()
                                                                              _YYAUCPI.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                              _YYAUCPI.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                              _YYAUCPI.Value)
    let _allowsNativeFixings                       = triv _YYAUCPI (fun () -> _YYAUCPI.Value.allowsNativeFixings())
    let _clearFixings                              = triv _YYAUCPI (fun () -> _YYAUCPI.Value.clearFixings()
                                                                              _YYAUCPI.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.registerWith(handler.Value)
                                                                              _YYAUCPI.Value)
    let _timeSeries                                = triv _YYAUCPI (fun () -> _YYAUCPI.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YYAUCPI (fun () -> _YYAUCPI.Value.unregisterWith(handler.Value)
                                                                              _YYAUCPI.Value)
    do this.Bind(_YYAUCPI)
(* 
    casting 
*)
    internal new () = new YYAUCPIModel1(null,null,null,null)
    member internal this.Inject v = _YYAUCPI <- v
    static member Cast (p : ICell<YYAUCPI>) = 
        if p :? YYAUCPIModel1 then 
            p :?> YYAUCPIModel1
        else
            let o = new YYAUCPIModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.frequency                          = _frequency 
    member this.revised                            = _revised 
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
