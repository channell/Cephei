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
  FR HICP index

  </summary> *)
[<AutoSerializable(true)>]
type FRHICPModel
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<ZeroInflationTermStructure>>
    ) as this =

    inherit Model<FRHICP> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let _FRHICP                                    = cell (fun () -> new FRHICP (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = triv (fun () -> _FRHICP.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = triv (fun () -> _FRHICP.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _FRHICP.Value)
    let _availabilityLag                           = triv (fun () -> _FRHICP.Value.availabilityLag())
    let _currency                                  = triv (fun () -> _FRHICP.Value.currency())
    let _familyName                                = triv (fun () -> _FRHICP.Value.familyName())
    let _fixingCalendar                            = triv (fun () -> _FRHICP.Value.fixingCalendar())
    let _frequency                                 = triv (fun () -> _FRHICP.Value.frequency())
    let _interpolated                              = triv (fun () -> _FRHICP.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _FRHICP.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _FRHICP.Value.name())
    let _region                                    = triv (fun () -> _FRHICP.Value.region())
    let _revised                                   = triv (fun () -> _FRHICP.Value.revised())
    let _update                                    = triv (fun () -> _FRHICP.Value.update()
                                                                     _FRHICP.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _FRHICP.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _FRHICP.Value)
    let _allowsNativeFixings                       = triv (fun () -> _FRHICP.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _FRHICP.Value.clearFixings()
                                                                     _FRHICP.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FRHICP.Value.registerWith(handler.Value)
                                                                     _FRHICP.Value)
    let _timeSeries                                = triv (fun () -> _FRHICP.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FRHICP.Value.unregisterWith(handler.Value)
                                                                     _FRHICP.Value)
    do this.Bind(_FRHICP)
(* 
    casting 
*)
    internal new () = FRHICPModel(null,null)
    member internal this.Inject v = _FRHICP.Value <- v
    static member Cast (p : ICell<FRHICP>) = 
        if p :? FRHICPModel then 
            p :?> FRHICPModel
        else
            let o = new FRHICPModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
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
(* <summary>
  FR HICP index

  </summary> *)
[<AutoSerializable(true)>]
type FRHICPModel1
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<FRHICP> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let _FRHICP                                    = cell (fun () -> new FRHICP (interpolated.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = triv (fun () -> _FRHICP.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = triv (fun () -> _FRHICP.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _FRHICP.Value)
    let _availabilityLag                           = triv (fun () -> _FRHICP.Value.availabilityLag())
    let _currency                                  = triv (fun () -> _FRHICP.Value.currency())
    let _familyName                                = triv (fun () -> _FRHICP.Value.familyName())
    let _fixingCalendar                            = triv (fun () -> _FRHICP.Value.fixingCalendar())
    let _frequency                                 = triv (fun () -> _FRHICP.Value.frequency())
    let _interpolated                              = triv (fun () -> _FRHICP.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _FRHICP.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _FRHICP.Value.name())
    let _region                                    = triv (fun () -> _FRHICP.Value.region())
    let _revised                                   = triv (fun () -> _FRHICP.Value.revised())
    let _update                                    = triv (fun () -> _FRHICP.Value.update()
                                                                     _FRHICP.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _FRHICP.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _FRHICP.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _FRHICP.Value)
    let _allowsNativeFixings                       = triv (fun () -> _FRHICP.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _FRHICP.Value.clearFixings()
                                                                     _FRHICP.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FRHICP.Value.registerWith(handler.Value)
                                                                     _FRHICP.Value)
    let _timeSeries                                = triv (fun () -> _FRHICP.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _FRHICP.Value.unregisterWith(handler.Value)
                                                                     _FRHICP.Value)
    do this.Bind(_FRHICP)
(* 
    casting 
*)
    internal new () = FRHICPModel1(null)
    member internal this.Inject v = _FRHICP.Value <- v
    static member Cast (p : ICell<FRHICP>) = 
        if p :? FRHICPModel1 then 
            p :?> FRHICPModel1
        else
            let o = new FRHICPModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.interpolated                       = _interpolated 
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
