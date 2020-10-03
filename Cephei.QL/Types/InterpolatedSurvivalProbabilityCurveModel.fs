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
type InterpolatedSurvivalProbabilityCurveModel<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , probabilities                                : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedSurvivalProbabilityCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _probabilities                             = probabilities
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedSurvivalProbabilityCurve      = cell (fun () -> new InterpolatedSurvivalProbabilityCurve<'Interpolator> (dates.Value, probabilities.Value, dayCounter.Value, calendar.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.dates_)
    let _discounts                                 = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.discounts())
    let _interpolation_                            = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.setupInterpolation()
                                                                     _InterpolatedSurvivalProbabilityCurve.Value)
    let _survivalProbabilities                     = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.survivalProbabilities())
    let _times                                     = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.times_)
    let _defaultDensity                            (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.defaultDensity(t.Value, extrapolate.Value))
    let _defaultDensity1                           (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.defaultDensity(d.Value, extrapolate.Value))
    let _defaultProbability                        (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.defaultProbability(d.Value, extrapolate.Value))
    let _defaultProbability1                       (t1 : ICell<double>) (t2 : ICell<double>) (extrapo : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.defaultProbability(t1.Value, t2.Value, extrapo.Value))
    let _defaultProbability2                       (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.defaultProbability(t.Value, extrapolate.Value))
    let _defaultProbability3                       (d1 : ICell<Date>) (d2 : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.defaultProbability(d1.Value, d2.Value, extrapolate.Value))
    let _hazardRate                                (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.hazardRate(d.Value, extrapolate.Value))
    let _hazardRate1                               (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.hazardRate(t.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.jumpTimes())
    let _survivalProbability                       (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.survivalProbability(t.Value, extrapolate.Value))
    let _survivalProbability1                      (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.survivalProbability(d.Value, extrapolate.Value))
    let _update                                    = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.update()
                                                                     _InterpolatedSurvivalProbabilityCurve.Value)
    let _calendar                                  = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.disableExtrapolation(b.Value)
                                                                     _InterpolatedSurvivalProbabilityCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.enableExtrapolation(b.Value)
                                                                     _InterpolatedSurvivalProbabilityCurve.Value)
    let _extrapolate                               = triv (fun () -> _InterpolatedSurvivalProbabilityCurve.Value.extrapolate)
    do this.Bind(_InterpolatedSurvivalProbabilityCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.probabilities                      = _probabilities 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.SurvivalProbabilities              = _survivalProbabilities
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.DefaultDensity                     t extrapolate   
                                                   = _defaultDensity t extrapolate 
    member this.DefaultDensity1                    d extrapolate   
                                                   = _defaultDensity1 d extrapolate 
    member this.DefaultProbability                 d extrapolate   
                                                   = _defaultProbability d extrapolate 
    member this.DefaultProbability1                t1 t2 extrapo   
                                                   = _defaultProbability1 t1 t2 extrapo 
    member this.DefaultProbability2                t extrapolate   
                                                   = _defaultProbability2 t extrapolate 
    member this.DefaultProbability3                d1 d2 extrapolate   
                                                   = _defaultProbability3 d1 d2 extrapolate 
    member this.HazardRate                         d extrapolate   
                                                   = _hazardRate d extrapolate 
    member this.HazardRate1                        t extrapolate   
                                                   = _hazardRate1 t extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.SurvivalProbability                t extrapolate   
                                                   = _survivalProbability t extrapolate 
    member this.SurvivalProbability1               d extrapolate   
                                                   = _survivalProbability1 d extrapolate 
    member this.Update                             = _update
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
