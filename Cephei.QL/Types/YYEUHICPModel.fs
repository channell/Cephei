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
  Genuine year-on-year EU HICP (i.e. not a ratio of EU HICP)

  </summary> *)
[<AutoSerializable(true)>]
type YYEUHICPModel
    ( interpolated                                 : ICell<bool>
    ) as this =

    inherit Model<YYEUHICP> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
(*
    Functions
*)
    let _YYEUHICP                                  = cell (fun () -> new YYEUHICP (interpolated.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv (fun () -> _YYEUHICP.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv (fun () -> _YYEUHICP.Value.ratio())
    let _yoyInflationTermStructure                 = triv (fun () -> _YYEUHICP.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _YYEUHICP.Value)
    let _availabilityLag                           = triv (fun () -> _YYEUHICP.Value.availabilityLag())
    let _currency                                  = triv (fun () -> _YYEUHICP.Value.currency())
    let _familyName                                = triv (fun () -> _YYEUHICP.Value.familyName())
    let _fixingCalendar                            = triv (fun () -> _YYEUHICP.Value.fixingCalendar())
    let _frequency                                 = triv (fun () -> _YYEUHICP.Value.frequency())
    let _interpolated                              = triv (fun () -> _YYEUHICP.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _YYEUHICP.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _YYEUHICP.Value.name())
    let _region                                    = triv (fun () -> _YYEUHICP.Value.region())
    let _revised                                   = triv (fun () -> _YYEUHICP.Value.revised())
    let _update                                    = triv (fun () -> _YYEUHICP.Value.update()
                                                                     _YYEUHICP.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _YYEUHICP.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _YYEUHICP.Value)
    let _allowsNativeFixings                       = triv (fun () -> _YYEUHICP.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _YYEUHICP.Value.clearFixings()
                                                                     _YYEUHICP.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYEUHICP.Value.registerWith(handler.Value)
                                                                     _YYEUHICP.Value)
    let _timeSeries                                = triv (fun () -> _YYEUHICP.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYEUHICP.Value.unregisterWith(handler.Value)
                                                                     _YYEUHICP.Value)
    do this.Bind(_YYEUHICP)
(* 
    casting 
*)
    internal new () = YYEUHICPModel(null)
    member internal this.Inject v = _YYEUHICP.Value <- v
    static member Cast (p : ICell<YYEUHICP>) = 
        if p :? YYEUHICPModel then 
            p :?> YYEUHICPModel
        else
            let o = new YYEUHICPModel ()
            o.Inject p.Value
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
  Genuine year-on-year EU HICP (i.e. not a ratio of EU HICP)

  </summary> *)
[<AutoSerializable(true)>]
type YYEUHICPModel1
    ( interpolated                                 : ICell<bool>
    , ts                                           : ICell<Handle<YoYInflationTermStructure>>
    ) as this =

    inherit Model<YYEUHICP> ()
(*
    Parameters
*)
    let _interpolated                              = interpolated
    let _ts                                        = ts
(*
    Functions
*)
    let _YYEUHICP                                  = cell (fun () -> new YYEUHICP (interpolated.Value, ts.Value))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv (fun () -> _YYEUHICP.Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv (fun () -> _YYEUHICP.Value.ratio())
    let _yoyInflationTermStructure                 = triv (fun () -> _YYEUHICP.Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                     _YYEUHICP.Value)
    let _availabilityLag                           = triv (fun () -> _YYEUHICP.Value.availabilityLag())
    let _currency                                  = triv (fun () -> _YYEUHICP.Value.currency())
    let _familyName                                = triv (fun () -> _YYEUHICP.Value.familyName())
    let _fixingCalendar                            = triv (fun () -> _YYEUHICP.Value.fixingCalendar())
    let _frequency                                 = triv (fun () -> _YYEUHICP.Value.frequency())
    let _interpolated                              = triv (fun () -> _YYEUHICP.Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _YYEUHICP.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _YYEUHICP.Value.name())
    let _region                                    = triv (fun () -> _YYEUHICP.Value.region())
    let _revised                                   = triv (fun () -> _YYEUHICP.Value.revised())
    let _update                                    = triv (fun () -> _YYEUHICP.Value.update()
                                                                     _YYEUHICP.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _YYEUHICP.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _YYEUHICP.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _YYEUHICP.Value)
    let _allowsNativeFixings                       = triv (fun () -> _YYEUHICP.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _YYEUHICP.Value.clearFixings()
                                                                     _YYEUHICP.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYEUHICP.Value.registerWith(handler.Value)
                                                                     _YYEUHICP.Value)
    let _timeSeries                                = triv (fun () -> _YYEUHICP.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _YYEUHICP.Value.unregisterWith(handler.Value)
                                                                     _YYEUHICP.Value)
    do this.Bind(_YYEUHICP)
(* 
    casting 
*)
    internal new () = YYEUHICPModel1(null,null)
    member internal this.Inject v = _YYEUHICP.Value <- v
    static member Cast (p : ICell<YYEUHICP>) = 
        if p :? YYEUHICPModel1 then 
            p :?> YYEUHICPModel1
        else
            let o = new YYEUHICPModel1 ()
            o.Inject p.Value
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
