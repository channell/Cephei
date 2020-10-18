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
  The provided rates are not YY inflation-swap quotes. inflationtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedYoYInflationCurveModel<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( referenceDate                                : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , lag                                          : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    , dates                                        : ICell<Generic.List<Date>>
    , rates                                        : ICell<Generic.List<double>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedYoYInflationCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _calendar                                  = calendar
    let _dayCounter                                = dayCounter
    let _lag                                       = lag
    let _frequency                                 = frequency
    let _indexIsInterpolated                       = indexIsInterpolated
    let _yTS                                       = yTS
    let _dates                                     = dates
    let _rates                                     = rates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedYoYInflationCurve             = cell (fun () -> new InterpolatedYoYInflationCurve<'Interpolator> (referenceDate.Value, calendar.Value, dayCounter.Value, lag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value, dates.Value, rates.Value, interpolator.Value))
    let _baseDate                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.baseDate())
    let _Clone                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedYoYInflationCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedYoYInflationCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedYoYInflationCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.nodes())
    let _rates                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.rates())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedYoYInflationCurve.Value.setupInterpolation()
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedYoYInflationCurve.Value.times_)
    let _yoyRate                                   (d : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value))
    let _yoyRate1                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _yoyRate2                                  (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value))
    let _yoyRate3                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _baseRate                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.baseRate())
    let _frequency                                 = triv (fun () -> _InterpolatedYoYInflationCurve.Value.frequency())
    let _hasSeasonality                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv (fun () -> _InterpolatedYoYInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv (fun () -> _InterpolatedYoYInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.observationLag())
    let _seasonality                               = triv (fun () -> _InterpolatedYoYInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _calendar                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _InterpolatedYoYInflationCurve.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _InterpolatedYoYInflationCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _InterpolatedYoYInflationCurve.Value.update()
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _allowsExtrapolation                       = triv (fun () -> _InterpolatedYoYInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.disableExtrapolation(b.Value)
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.enableExtrapolation(b.Value)
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _extrapolate                               = triv (fun () -> _InterpolatedYoYInflationCurve.Value.extrapolate)
    do this.Bind(_InterpolatedYoYInflationCurve)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.calendar                           = _calendar 
    member this.dayCounter                         = _dayCounter 
    member this.lag                                = _lag 
    member this.frequency                          = _frequency 
    member this.indexIsInterpolated                = _indexIsInterpolated 
    member this.yTS                                = _yTS 
    member this.dates                              = _dates 
    member this.rates                              = _rates 
    member this.interpolator                       = _interpolator 
    member this.BaseDate                           = _baseDate
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Forwards                           = _forwards
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.Rates                              = _rates
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.YoyRate                            d   
                                                   = _yoyRate d 
    member this.YoyRate1                           d instObsLag forceLinearInterpolation extrapolate   
                                                   = _yoyRate1 d instObsLag forceLinearInterpolation extrapolate 
    member this.YoyRate2                           d instObsLag   
                                                   = _yoyRate2 d instObsLag 
    member this.YoyRate3                           d instObsLag forceLinearInterpolation   
                                                   = _yoyRate3 d instObsLag forceLinearInterpolation 
    member this.BaseRate                           = _baseRate
    member this.Frequency                          = _frequency
    member this.HasSeasonality                     = _hasSeasonality
    member this.IndexIsInterpolated                = _indexIsInterpolated
    member this.NominalTermStructure               = _nominalTermStructure
    member this.ObservationLag                     = _observationLag
    member this.Seasonality                        = _seasonality
    member this.SetSeasonality                     seasonality   
                                                   = _setSeasonality seasonality 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
(* <summary>
  The provided rates are not YY inflation-swap quotes. inflationtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedYoYInflationCurveModel1<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( referenceDate                                : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , lag                                          : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    , dates                                        : ICell<Generic.List<Date>>
    , rates                                        : ICell<Generic.List<double>>
    ) as this =

    inherit Model<InterpolatedYoYInflationCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _calendar                                  = calendar
    let _dayCounter                                = dayCounter
    let _lag                                       = lag
    let _frequency                                 = frequency
    let _indexIsInterpolated                       = indexIsInterpolated
    let _yTS                                       = yTS
    let _dates                                     = dates
    let _rates                                     = rates
(*
    Functions
*)
    let mutable
        _InterpolatedYoYInflationCurve             = cell (fun () -> new InterpolatedYoYInflationCurve<'Interpolator> (referenceDate.Value, calendar.Value, dayCounter.Value, lag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value, dates.Value, rates.Value))
    let _baseDate                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.baseDate())
    let _Clone                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedYoYInflationCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedYoYInflationCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedYoYInflationCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.nodes())
    let _rates                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.rates())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedYoYInflationCurve.Value.setupInterpolation()
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedYoYInflationCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedYoYInflationCurve.Value.times_)
    let _yoyRate                                   (d : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value))
    let _yoyRate1                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _yoyRate2                                  (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value))
    let _yoyRate3                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _baseRate                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.baseRate())
    let _frequency                                 = triv (fun () -> _InterpolatedYoYInflationCurve.Value.frequency())
    let _hasSeasonality                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv (fun () -> _InterpolatedYoYInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv (fun () -> _InterpolatedYoYInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.observationLag())
    let _seasonality                               = triv (fun () -> _InterpolatedYoYInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _calendar                                  = triv (fun () -> _InterpolatedYoYInflationCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _InterpolatedYoYInflationCurve.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _InterpolatedYoYInflationCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _InterpolatedYoYInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _InterpolatedYoYInflationCurve.Value.update()
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _allowsExtrapolation                       = triv (fun () -> _InterpolatedYoYInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.disableExtrapolation(b.Value)
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedYoYInflationCurve.Value.enableExtrapolation(b.Value)
                                                                     _InterpolatedYoYInflationCurve.Value)
    let _extrapolate                               = triv (fun () -> _InterpolatedYoYInflationCurve.Value.extrapolate)
    do this.Bind(_InterpolatedYoYInflationCurve)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.calendar                           = _calendar 
    member this.dayCounter                         = _dayCounter 
    member this.lag                                = _lag 
    member this.frequency                          = _frequency 
    member this.indexIsInterpolated                = _indexIsInterpolated 
    member this.yTS                                = _yTS 
    member this.dates                              = _dates 
    member this.rates                              = _rates 
    member this.BaseDate                           = _baseDate
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Forwards                           = _forwards
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.Rates                              = _rates
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.YoyRate                            d   
                                                   = _yoyRate d 
    member this.YoyRate1                           d instObsLag forceLinearInterpolation extrapolate   
                                                   = _yoyRate1 d instObsLag forceLinearInterpolation extrapolate 
    member this.YoyRate2                           d instObsLag   
                                                   = _yoyRate2 d instObsLag 
    member this.YoyRate3                           d instObsLag forceLinearInterpolation   
                                                   = _yoyRate3 d instObsLag forceLinearInterpolation 
    member this.BaseRate                           = _baseRate
    member this.Frequency                          = _frequency
    member this.HasSeasonality                     = _hasSeasonality
    member this.IndexIsInterpolated                = _indexIsInterpolated
    member this.NominalTermStructure               = _nominalTermStructure
    member this.ObservationLag                     = _observationLag
    member this.Seasonality                        = _seasonality
    member this.SetSeasonality                     seasonality   
                                                   = _setSeasonality seasonality 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
