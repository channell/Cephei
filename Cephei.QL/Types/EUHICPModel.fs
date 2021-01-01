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
  EU HICP index

  </summary> *)
[<AutoSerializable(true)>]
type EUHICPModel
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<EUHICP> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let mutable
        _EUHICP                                    = make (fun () -> new EUHICP (interpolated.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = triv _EUHICP (fun () -> _EUHICP.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                             _EUHICP.Value)
    let _availabilityLag                           = triv _EUHICP (fun () -> _EUHICP.Value.availabilityLag())
    let _currency                                  = triv _EUHICP (fun () -> _EUHICP.Value.currency())
    let _familyName                                = triv _EUHICP (fun () -> _EUHICP.Value.familyName())
    let _fixingCalendar                            = triv _EUHICP (fun () -> _EUHICP.Value.fixingCalendar())
    let _frequency                                 = triv _EUHICP (fun () -> _EUHICP.Value.frequency())
    let _interpolated                              = triv _EUHICP (fun () -> _EUHICP.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _EUHICP (fun () -> _EUHICP.Value.name())
    let _region                                    = triv _EUHICP (fun () -> _EUHICP.Value.region())
    let _revised                                   = triv _EUHICP (fun () -> _EUHICP.Value.revised())
    let _update                                    = triv _EUHICP (fun () -> _EUHICP.Value.update()
                                                                             _EUHICP.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                             _EUHICP.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                             _EUHICP.Value)
    let _allowsNativeFixings                       = triv _EUHICP (fun () -> _EUHICP.Value.allowsNativeFixings())
    let _clearFixings                              = triv _EUHICP (fun () -> _EUHICP.Value.clearFixings()
                                                                             _EUHICP.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.registerWith(handler.Value)
                                                                             _EUHICP.Value)
    let _timeSeries                                = triv _EUHICP (fun () -> _EUHICP.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.unregisterWith(handler.Value)
                                                                             _EUHICP.Value)
    do this.Bind(_EUHICP)
(* 
    casting 
*)
    internal new () = new EUHICPModel(null)
    member internal this.Inject v = _EUHICP <- v
    static member Cast (p : ICell<EUHICP>) = 
        if p :? EUHICPModel then 
            p :?> EUHICPModel
        else
            let o = new EUHICPModel ()
            o.Inject p
            o.Bind p
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
(* <summary>
  EU HICP index

  </summary> *)
[<AutoSerializable(true)>]
type EUHICPModel1
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<ZeroInflationTermStructure>>
    ) as this =

    inherit Model<EUHICP> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let mutable
        _EUHICP                                    = make (fun () -> new EUHICP (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<ZeroInflationTermStructure>>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.clone(h.Value))
    let _fixing                                    (aFixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.fixing(aFixingDate.Value, forecastTodaysFixing.Value))
    let _zeroInflationTermStructure                = triv _EUHICP (fun () -> _EUHICP.Value.zeroInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                             _EUHICP.Value)
    let _availabilityLag                           = triv _EUHICP (fun () -> _EUHICP.Value.availabilityLag())
    let _currency                                  = triv _EUHICP (fun () -> _EUHICP.Value.currency())
    let _familyName                                = triv _EUHICP (fun () -> _EUHICP.Value.familyName())
    let _fixingCalendar                            = triv _EUHICP (fun () -> _EUHICP.Value.fixingCalendar())
    let _frequency                                 = triv _EUHICP (fun () -> _EUHICP.Value.frequency())
    let _interpolated                              = triv _EUHICP (fun () -> _EUHICP.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _EUHICP (fun () -> _EUHICP.Value.name())
    let _region                                    = triv _EUHICP (fun () -> _EUHICP.Value.region())
    let _revised                                   = triv _EUHICP (fun () -> _EUHICP.Value.revised())
    let _update                                    = triv _EUHICP (fun () -> _EUHICP.Value.update()
                                                                             _EUHICP.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                             _EUHICP.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                             _EUHICP.Value)
    let _allowsNativeFixings                       = triv _EUHICP (fun () -> _EUHICP.Value.allowsNativeFixings())
    let _clearFixings                              = triv _EUHICP (fun () -> _EUHICP.Value.clearFixings()
                                                                             _EUHICP.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.registerWith(handler.Value)
                                                                             _EUHICP.Value)
    let _timeSeries                                = triv _EUHICP (fun () -> _EUHICP.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _EUHICP (fun () -> _EUHICP.Value.unregisterWith(handler.Value)
                                                                             _EUHICP.Value)
    do this.Bind(_EUHICP)
(* 
    casting 
*)
    internal new () = new EUHICPModel1(null,null)
    member internal this.Inject v = _EUHICP <- v
    static member Cast (p : ICell<EUHICP>) = 
        if p :? EUHICPModel1 then 
            p :?> EUHICPModel1
        else
            let o = new EUHICPModel1 ()
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
