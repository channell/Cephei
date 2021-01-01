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
  These may be genuine indices published on, say, Bloomberg, or "fake" indices that are defined as the ratio of an index at different time points.

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationIndexModel
    ( familyName                                   : ICell<string>
    , region                                       : ICell<Region>
    , revised                                      : ICell<bool>
    , interpolated                                 : ICell<bool>
    , ratio                                        : ICell<bool>
    , frequency                                    : ICell<Frequency>
    , availabilityLag                              : ICell<Period>
    , currency                                     : ICell<Currency>
    , yoyInflation                                 : ICell<Handle<YoYInflationTermStructure>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YoYInflationIndex> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _familyName                                = familyName
    let _region                                    = region
    let _revised                                   = revised
    let _interpolated                              = interpolated
    let _ratio                                     = ratio
    let _frequency                                 = frequency
    let _availabilityLag                           = availabilityLag
    let _currency                                  = currency
    let _yoyInflation                              = yoyInflation
(*
    Functions
*)
    let mutable
        _YoYInflationIndex                         = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new YoYInflationIndex (familyName.Value, region.Value, revised.Value, interpolated.Value, ratio.Value, frequency.Value, availabilityLag.Value, currency.Value, yoyInflation.Value))))
    let _clone                                     (h : ICell<Handle<YoYInflationTermStructure>>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.clone(h.Value))
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _ratio                                     = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.ratio())
    let _yoyInflationTermStructure                 = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.yoyInflationTermStructure())
    let _addFixing                                 (fixingDate : ICell<Date>) (fixing : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.addFixing(fixingDate.Value, fixing.Value, forceOverwrite.Value)
                                                                                        _YoYInflationIndex.Value)
    let _availabilityLag                           = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.availabilityLag())
    let _currency                                  = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.currency())
    let _familyName                                = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.familyName())
    let _fixingCalendar                            = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.fixingCalendar())
    let _frequency                                 = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.frequency())
    let _interpolated                              = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.interpolated())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.name())
    let _region                                    = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.region())
    let _revised                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.revised())
    let _update                                    = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.update()
                                                                                        _YoYInflationIndex.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                                        _YoYInflationIndex.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.addFixings(source.Value, forceOverwrite.Value)
                                                                                        _YoYInflationIndex.Value)
    let _allowsNativeFixings                       = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.allowsNativeFixings())
    let _clearFixings                              = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.clearFixings()
                                                                                        _YoYInflationIndex.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.registerWith(handler.Value)
                                                                                        _YoYInflationIndex.Value)
    let _timeSeries                                = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _YoYInflationIndex (fun () -> (curryEvaluationDate _evaluationDate _YoYInflationIndex).Value.unregisterWith(handler.Value)
                                                                                        _YoYInflationIndex.Value)
    do this.Bind(_YoYInflationIndex)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new YoYInflationIndexModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _YoYInflationIndex <- v
    static member Cast (p : ICell<YoYInflationIndex>) = 
        if p :? YoYInflationIndexModel then 
            p :?> YoYInflationIndexModel
        else
            let o = new YoYInflationIndexModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.familyName                         = _familyName 
    member this.region                             = _region 
    member this.revised                            = _revised 
    member this.interpolated                       = _interpolated 
    member this.ratio                              = _ratio 
    member this.frequency                          = _frequency 
    member this.availabilityLag                    = _availabilityLag 
    member this.currency                           = _currency 
    member this.yoyInflation                       = _yoyInflation 
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
