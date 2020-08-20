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
type PiecewiseYoYInflationCurveModel
    ( dayCounter                                   : ICell<DayCounter>
    , baseZeroRate                                 : ICell<double>
    , observationLag                               : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<PiecewiseYoYInflationCurve> ()
(*
    Parameters
*)
    let _dayCounter                                = dayCounter
    let _baseZeroRate                              = baseZeroRate
    let _observationLag                            = observationLag
    let _frequency                                 = frequency
    let _indexIsInterpolated                       = indexIsInterpolated
    let _yTS                                       = yTS
(*
    Functions
*)
    let _PiecewiseYoYInflationCurve                = cell (fun () -> new PiecewiseYoYInflationCurve (dayCounter.Value, baseZeroRate.Value, observationLag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value))
    let _accuracy_                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.accuracy_)
    let _baseDate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseDate())
    let _Clone                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.Clone())
    let _data                                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data())
    let _data_                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data_)
    let _dates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate())
    let _initialValue                              (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue(c.Value))
    let _initialValue1                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue())
    let _instruments_                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.instruments_)
    let _interpolation_                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate_)
    let _maxIterations                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.moving_)
    let _nodes                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nodes())
    let _rates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.registerWith(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setTermStructure(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setupInterpolation                        = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setupInterpolation()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _times                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times())
    let _times_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times_)
    let _traits_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _yoyRate                                   (d : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value))
    let _yoyRate1                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _yoyRate2                                  (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value))
    let _yoyRate3                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _baseRate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseRate())
    let _frequency                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.frequency())
    let _hasSeasonality                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.observationLag())
    let _seasonality                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _calendar                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.update()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _allowsExtrapolation                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.disableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.enableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _extrapolate                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseYoYInflationCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dayCounter                         = _dayCounter 
    member this.baseZeroRate                       = _baseZeroRate 
    member this.observationLag                     = _observationLag 
    member this.frequency                          = _frequency 
    member this.indexIsInterpolated                = _indexIsInterpolated 
    member this.yTS                                = _yTS 
    member this.Accuracy_                          = _accuracy_
    member this.BaseDate                           = _baseDate
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.DiscountImpl                       i t   
                                                   = _discountImpl i t 
    member this.ForwardImpl                        i t   
                                                   = _forwardImpl i t 
    member this.Forwards                           = _forwards
    member this.Guess                              i c validData first   
                                                   = _guess i c validData first 
    member this.InitialDate                        c   
                                                   = _initialDate c 
    member this.InitialDate1                       = _initialDate1
    member this.InitialValue                       c   
                                                   = _initialValue c 
    member this.InitialValue1                      = _initialValue1
    member this.Instruments_                       = _instruments_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxIterations                      = _maxIterations
    member this.MaxValueAfter                      i c validData first   
                                                   = _maxValueAfter i c validData first 
    member this.MinValueAfter                      i c validData first   
                                                   = _minValueAfter i c validData first 
    member this.Moving_                            = _moving_
    member this.Nodes                              = _nodes
    member this.Rates                              = _rates
    member this.RegisterWith                       helper   
                                                   = _registerWith helper 
    member this.SetTermStructure                   helper   
                                                   = _setTermStructure helper 
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Traits_                            = _traits_
    member this.UpdateGuess                        data discount i   
                                                   = _updateGuess data discount i 
    member this.ZeroYieldImpl                      i t   
                                                   = _zeroYieldImpl i t 
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


  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseYoYInflationCurveModel1
    ( referenceDate                                : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , baseZeroRate                                 : ICell<double>
    , observationLag                               : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<PiecewiseYoYInflationCurve> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _calendar                                  = calendar
    let _dayCounter                                = dayCounter
    let _baseZeroRate                              = baseZeroRate
    let _observationLag                            = observationLag
    let _frequency                                 = frequency
    let _indexIsInterpolated                       = indexIsInterpolated
    let _yTS                                       = yTS
(*
    Functions
*)
    let _PiecewiseYoYInflationCurve                = cell (fun () -> new PiecewiseYoYInflationCurve (referenceDate.Value, calendar.Value, dayCounter.Value, baseZeroRate.Value, observationLag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value))
    let _accuracy_                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.accuracy_)
    let _baseDate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseDate())
    let _Clone                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.Clone())
    let _data                                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data())
    let _data_                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data_)
    let _dates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate())
    let _initialValue                              (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue(c.Value))
    let _initialValue1                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue())
    let _instruments_                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.instruments_)
    let _interpolation_                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate_)
    let _maxIterations                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.moving_)
    let _nodes                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nodes())
    let _rates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.registerWith(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setTermStructure(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setupInterpolation                        = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setupInterpolation()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _times                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times())
    let _times_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times_)
    let _traits_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _yoyRate                                   (d : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value))
    let _yoyRate1                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _yoyRate2                                  (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value))
    let _yoyRate3                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _baseRate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseRate())
    let _frequency                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.frequency())
    let _hasSeasonality                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.observationLag())
    let _seasonality                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _calendar                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.update()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _allowsExtrapolation                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.disableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.enableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _extrapolate                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseYoYInflationCurve)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.calendar                           = _calendar 
    member this.dayCounter                         = _dayCounter 
    member this.baseZeroRate                       = _baseZeroRate 
    member this.observationLag                     = _observationLag 
    member this.frequency                          = _frequency 
    member this.indexIsInterpolated                = _indexIsInterpolated 
    member this.yTS                                = _yTS 
    member this.Accuracy_                          = _accuracy_
    member this.BaseDate                           = _baseDate
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.DiscountImpl                       i t   
                                                   = _discountImpl i t 
    member this.ForwardImpl                        i t   
                                                   = _forwardImpl i t 
    member this.Forwards                           = _forwards
    member this.Guess                              i c validData first   
                                                   = _guess i c validData first 
    member this.InitialDate                        c   
                                                   = _initialDate c 
    member this.InitialDate1                       = _initialDate1
    member this.InitialValue                       c   
                                                   = _initialValue c 
    member this.InitialValue1                      = _initialValue1
    member this.Instruments_                       = _instruments_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxIterations                      = _maxIterations
    member this.MaxValueAfter                      i c validData first   
                                                   = _maxValueAfter i c validData first 
    member this.MinValueAfter                      i c validData first   
                                                   = _minValueAfter i c validData first 
    member this.Moving_                            = _moving_
    member this.Nodes                              = _nodes
    member this.Rates                              = _rates
    member this.RegisterWith                       helper   
                                                   = _registerWith helper 
    member this.SetTermStructure                   helper   
                                                   = _setTermStructure helper 
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Traits_                            = _traits_
    member this.UpdateGuess                        data discount i   
                                                   = _updateGuess data discount i 
    member this.ZeroYieldImpl                      i t   
                                                   = _zeroYieldImpl i t 
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


  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseYoYInflationCurveModel2
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , baseZeroRate                                 : ICell<double>
    , observationLag                               : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<PiecewiseYoYInflationCurve> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _dayCounter                                = dayCounter
    let _baseZeroRate                              = baseZeroRate
    let _observationLag                            = observationLag
    let _frequency                                 = frequency
    let _indexIsInterpolated                       = indexIsInterpolated
    let _yTS                                       = yTS
(*
    Functions
*)
    let _PiecewiseYoYInflationCurve                = cell (fun () -> new PiecewiseYoYInflationCurve (settlementDays.Value, calendar.Value, dayCounter.Value, baseZeroRate.Value, observationLag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value))
    let _accuracy_                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.accuracy_)
    let _baseDate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseDate())
    let _Clone                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.Clone())
    let _data                                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data())
    let _data_                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data_)
    let _dates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate())
    let _initialValue                              (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue(c.Value))
    let _initialValue1                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue())
    let _instruments_                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.instruments_)
    let _interpolation_                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate_)
    let _maxIterations                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.moving_)
    let _nodes                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nodes())
    let _rates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.registerWith(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setTermStructure(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setupInterpolation                        = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setupInterpolation()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _times                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times())
    let _times_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times_)
    let _traits_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _yoyRate                                   (d : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value))
    let _yoyRate1                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _yoyRate2                                  (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value))
    let _yoyRate3                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _baseRate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseRate())
    let _frequency                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.frequency())
    let _hasSeasonality                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.observationLag())
    let _seasonality                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _calendar                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.update()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _allowsExtrapolation                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.disableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.enableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _extrapolate                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseYoYInflationCurve)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.dayCounter                         = _dayCounter 
    member this.baseZeroRate                       = _baseZeroRate 
    member this.observationLag                     = _observationLag 
    member this.frequency                          = _frequency 
    member this.indexIsInterpolated                = _indexIsInterpolated 
    member this.yTS                                = _yTS 
    member this.Accuracy_                          = _accuracy_
    member this.BaseDate                           = _baseDate
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.DiscountImpl                       i t   
                                                   = _discountImpl i t 
    member this.ForwardImpl                        i t   
                                                   = _forwardImpl i t 
    member this.Forwards                           = _forwards
    member this.Guess                              i c validData first   
                                                   = _guess i c validData first 
    member this.InitialDate                        c   
                                                   = _initialDate c 
    member this.InitialDate1                       = _initialDate1
    member this.InitialValue                       c   
                                                   = _initialValue c 
    member this.InitialValue1                      = _initialValue1
    member this.Instruments_                       = _instruments_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxIterations                      = _maxIterations
    member this.MaxValueAfter                      i c validData first   
                                                   = _maxValueAfter i c validData first 
    member this.MinValueAfter                      i c validData first   
                                                   = _minValueAfter i c validData first 
    member this.Moving_                            = _moving_
    member this.Nodes                              = _nodes
    member this.Rates                              = _rates
    member this.RegisterWith                       helper   
                                                   = _registerWith helper 
    member this.SetTermStructure                   helper   
                                                   = _setTermStructure helper 
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Traits_                            = _traits_
    member this.UpdateGuess                        data discount i   
                                                   = _updateGuess data discount i 
    member this.ZeroYieldImpl                      i t   
                                                   = _zeroYieldImpl i t 
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


  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseYoYInflationCurveModel3
    () as this =
    inherit Model<PiecewiseYoYInflationCurve> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _PiecewiseYoYInflationCurve                = cell (fun () -> new PiecewiseYoYInflationCurve ())
    let _accuracy_                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.accuracy_)
    let _baseDate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseDate())
    let _Clone                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.Clone())
    let _data                                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data())
    let _data_                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.data_)
    let _dates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialDate())
    let _initialValue                              (c : ICell<YoYInflationTermStructure>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue(c.Value))
    let _initialValue1                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.initialValue())
    let _instruments_                              = cell (fun () -> _PiecewiseYoYInflationCurve.Value.instruments_)
    let _interpolation_                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxDate_)
    let _maxIterations                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.moving_)
    let _nodes                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nodes())
    let _rates                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.registerWith(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<YoYInflationTermStructure>>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setTermStructure(helper.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _setupInterpolation                        = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setupInterpolation()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _times                                     = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times())
    let _times_                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.times_)
    let _traits_                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _yoyRate                                   (d : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value))
    let _yoyRate1                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _yoyRate2                                  (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value))
    let _yoyRate3                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.yoyRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _baseRate                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.baseRate())
    let _frequency                                 = cell (fun () -> _PiecewiseYoYInflationCurve.Value.frequency())
    let _hasSeasonality                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = cell (fun () -> _PiecewiseYoYInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.observationLag())
    let _seasonality                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _calendar                                  = cell (fun () -> _PiecewiseYoYInflationCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _PiecewiseYoYInflationCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _PiecewiseYoYInflationCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _PiecewiseYoYInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = cell (fun () -> _PiecewiseYoYInflationCurve.Value.update()
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _allowsExtrapolation                       = cell (fun () -> _PiecewiseYoYInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.disableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _PiecewiseYoYInflationCurve.Value.enableExtrapolation(b.Value)
                                                                     _PiecewiseYoYInflationCurve.Value)
    let _extrapolate                               = cell (fun () -> _PiecewiseYoYInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseYoYInflationCurve)

(* 
    Externally visible/bindable properties
*)
    member this.Accuracy_                          = _accuracy_
    member this.BaseDate                           = _baseDate
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.DiscountImpl                       i t   
                                                   = _discountImpl i t 
    member this.ForwardImpl                        i t   
                                                   = _forwardImpl i t 
    member this.Forwards                           = _forwards
    member this.Guess                              i c validData first   
                                                   = _guess i c validData first 
    member this.InitialDate                        c   
                                                   = _initialDate c 
    member this.InitialDate1                       = _initialDate1
    member this.InitialValue                       c   
                                                   = _initialValue c 
    member this.InitialValue1                      = _initialValue1
    member this.Instruments_                       = _instruments_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxIterations                      = _maxIterations
    member this.MaxValueAfter                      i c validData first   
                                                   = _maxValueAfter i c validData first 
    member this.MinValueAfter                      i c validData first   
                                                   = _minValueAfter i c validData first 
    member this.Moving_                            = _moving_
    member this.Nodes                              = _nodes
    member this.Rates                              = _rates
    member this.RegisterWith                       helper   
                                                   = _registerWith helper 
    member this.SetTermStructure                   helper   
                                                   = _setTermStructure helper 
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Traits_                            = _traits_
    member this.UpdateGuess                        data discount i   
                                                   = _updateGuess data discount i 
    member this.ZeroYieldImpl                      i t   
                                                   = _zeroYieldImpl i t 
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
