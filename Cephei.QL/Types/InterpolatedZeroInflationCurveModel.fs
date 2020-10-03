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
type InterpolatedZeroInflationCurveModel<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
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

    inherit Model<InterpolatedZeroInflationCurve<'Interpolator>> ()
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
    let _InterpolatedZeroInflationCurve            = cell (fun () -> new InterpolatedZeroInflationCurve<'Interpolator> (referenceDate.Value, calendar.Value, dayCounter.Value, lag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value, dates.Value, rates.Value, interpolator.Value))
    let _baseDate                                  = triv (fun () -> _InterpolatedZeroInflationCurve.Value.baseDate())
    let _Clone                                     = triv (fun () -> _InterpolatedZeroInflationCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedZeroInflationCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedZeroInflationCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedZeroInflationCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedZeroInflationCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedZeroInflationCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedZeroInflationCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedZeroInflationCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedZeroInflationCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedZeroInflationCurve.Value.nodes())
    let _rates                                     = triv (fun () -> _InterpolatedZeroInflationCurve.Value.rates())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedZeroInflationCurve.Value.setupInterpolation()
                                                                     _InterpolatedZeroInflationCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedZeroInflationCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedZeroInflationCurve.Value.times_)
    let _zeroRate                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _zeroRate1                                 (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value))
    let _zeroRate2                                 (d : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.zeroRate(d.Value))
    let _zeroRate3                                 (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _baseRate                                  = triv (fun () -> _InterpolatedZeroInflationCurve.Value.baseRate())
    let _frequency                                 = triv (fun () -> _InterpolatedZeroInflationCurve.Value.frequency())
    let _hasSeasonality                            = triv (fun () -> _InterpolatedZeroInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv (fun () -> _InterpolatedZeroInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv (fun () -> _InterpolatedZeroInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = triv (fun () -> _InterpolatedZeroInflationCurve.Value.observationLag())
    let _seasonality                               = triv (fun () -> _InterpolatedZeroInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                     _InterpolatedZeroInflationCurve.Value)
    let _calendar                                  = triv (fun () -> _InterpolatedZeroInflationCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _InterpolatedZeroInflationCurve.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _InterpolatedZeroInflationCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _InterpolatedZeroInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _InterpolatedZeroInflationCurve.Value.update()
                                                                     _InterpolatedZeroInflationCurve.Value)
    let _allowsExtrapolation                       = triv (fun () -> _InterpolatedZeroInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.disableExtrapolation(b.Value)
                                                                     _InterpolatedZeroInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _InterpolatedZeroInflationCurve.Value.enableExtrapolation(b.Value)
                                                                     _InterpolatedZeroInflationCurve.Value)
    let _extrapolate                               = triv (fun () -> _InterpolatedZeroInflationCurve.Value.extrapolate)
    do this.Bind(_InterpolatedZeroInflationCurve)

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
    member this.ZeroRate                           d instObsLag forceLinearInterpolation   
                                                   = _zeroRate d instObsLag forceLinearInterpolation 
    member this.ZeroRate1                          d instObsLag   
                                                   = _zeroRate1 d instObsLag 
    member this.ZeroRate2                          d   
                                                   = _zeroRate2 d 
    member this.ZeroRate3                          d instObsLag forceLinearInterpolation extrapolate   
                                                   = _zeroRate3 d instObsLag forceLinearInterpolation extrapolate 
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
