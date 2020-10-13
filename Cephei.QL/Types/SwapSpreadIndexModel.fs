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
type SwapSpreadIndexModel
    ( familyName                                   : ICell<String>
    , swapIndex1                                   : ICell<SwapIndex>
    , swapIndex2                                   : ICell<SwapIndex>
    , gearing1                                     : ICell<double>
    , gearing2                                     : ICell<double>
    ) as this =

    inherit Model<SwapSpreadIndex> ()
(*
    Parameters
*)
    let _familyName                                = familyName
    let _swapIndex1                                = swapIndex1
    let _swapIndex2                                = swapIndex2
    let _gearing1                                  = gearing1
    let _gearing2                                  = gearing2
(*
    Functions
*)
    let _SwapSpreadIndex                           = cell (fun () -> new SwapSpreadIndex (familyName.Value, swapIndex1.Value, swapIndex2.Value, gearing1.Value, gearing2.Value))
    let _allowsNativeFixings                       = triv (fun () -> _SwapSpreadIndex.Value.allowsNativeFixings())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.forecastFixing(fixingDate.Value))
    let _gearing1                                  = triv (fun () -> _SwapSpreadIndex.Value.gearing1())
    let _gearing2                                  = triv (fun () -> _SwapSpreadIndex.Value.gearing2())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.maturityDate(valueDate.Value))
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.pastFixing(fixingDate.Value))
    let _swapIndex1                                = triv (fun () -> _SwapSpreadIndex.Value.swapIndex1())
    let _swapIndex2                                = triv (fun () -> _SwapSpreadIndex.Value.swapIndex2())
    let _currency                                  = triv (fun () -> _SwapSpreadIndex.Value.currency())
    let _dayCounter                                = triv (fun () -> _SwapSpreadIndex.Value.dayCounter())
    let _familyName                                = triv (fun () -> _SwapSpreadIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _SwapSpreadIndex.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _SwapSpreadIndex.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _SwapSpreadIndex.Value.name())
    let _tenor                                     = triv (fun () -> _SwapSpreadIndex.Value.tenor())
    let _update                                    = triv (fun () -> _SwapSpreadIndex.Value.update()
                                                                     _SwapSpreadIndex.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapSpreadIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapSpreadIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _SwapSpreadIndex.Value)
    let _clearFixings                              = triv (fun () -> _SwapSpreadIndex.Value.clearFixings()
                                                                     _SwapSpreadIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.registerWith(handler.Value)
                                                                     _SwapSpreadIndex.Value)
    let _timeSeries                                = triv (fun () -> _SwapSpreadIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.unregisterWith(handler.Value)
                                                                     _SwapSpreadIndex.Value)
    do this.Bind(_SwapSpreadIndex)
(* 
    casting 
*)
    internal new () = new SwapSpreadIndexModel(null,null,null,null,null)
    member internal this.Inject v = _SwapSpreadIndex.Value <- v
    static member Cast (p : ICell<SwapSpreadIndex>) = 
        if p :? SwapSpreadIndexModel then 
            p :?> SwapSpreadIndexModel
        else
            let o = new SwapSpreadIndexModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.swapIndex1                         = _swapIndex1 
    member this.swapIndex2                         = _swapIndex2 
    member this.gearing1                           = _gearing1 
    member this.gearing2                           = _gearing2 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.Gearing1                           = _gearing1
    member this.Gearing2                           = _gearing2
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.SwapIndex1                         = _swapIndex1
    member this.SwapIndex2                         = _swapIndex2
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
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>

need by CashFlowVectors
  </summary> *)
[<AutoSerializable(true)>]
type SwapSpreadIndexModel1
    () as this =
    inherit Model<SwapSpreadIndex> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _SwapSpreadIndex                           = cell (fun () -> new SwapSpreadIndex ())
    let _allowsNativeFixings                       = triv (fun () -> _SwapSpreadIndex.Value.allowsNativeFixings())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.forecastFixing(fixingDate.Value))
    let _gearing1                                  = triv (fun () -> _SwapSpreadIndex.Value.gearing1())
    let _gearing2                                  = triv (fun () -> _SwapSpreadIndex.Value.gearing2())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.maturityDate(valueDate.Value))
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.pastFixing(fixingDate.Value))
    let _swapIndex1                                = triv (fun () -> _SwapSpreadIndex.Value.swapIndex1())
    let _swapIndex2                                = triv (fun () -> _SwapSpreadIndex.Value.swapIndex2())
    let _currency                                  = triv (fun () -> _SwapSpreadIndex.Value.currency())
    let _dayCounter                                = triv (fun () -> _SwapSpreadIndex.Value.dayCounter())
    let _familyName                                = triv (fun () -> _SwapSpreadIndex.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _SwapSpreadIndex.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _SwapSpreadIndex.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _SwapSpreadIndex.Value.name())
    let _tenor                                     = triv (fun () -> _SwapSpreadIndex.Value.tenor())
    let _update                                    = triv (fun () -> _SwapSpreadIndex.Value.update()
                                                                     _SwapSpreadIndex.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapSpreadIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _SwapSpreadIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _SwapSpreadIndex.Value)
    let _clearFixings                              = triv (fun () -> _SwapSpreadIndex.Value.clearFixings()
                                                                     _SwapSpreadIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.registerWith(handler.Value)
                                                                     _SwapSpreadIndex.Value)
    let _timeSeries                                = triv (fun () -> _SwapSpreadIndex.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _SwapSpreadIndex.Value.unregisterWith(handler.Value)
                                                                     _SwapSpreadIndex.Value)
    do this.Bind(_SwapSpreadIndex)
(* 
    casting 
*)
    
    member internal this.Inject v = _SwapSpreadIndex.Value <- v
    static member Cast (p : ICell<SwapSpreadIndex>) = 
        if p :? SwapSpreadIndexModel1 then 
            p :?> SwapSpreadIndexModel1
        else
            let o = new SwapSpreadIndexModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.Gearing1                           = _gearing1
    member this.Gearing2                           = _gearing2
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.SwapIndex1                         = _swapIndex1
    member this.SwapIndex2                         = _swapIndex2
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
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
