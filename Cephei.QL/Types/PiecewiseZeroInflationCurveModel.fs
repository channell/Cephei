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


  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseZeroInflationCurveModel
    ( referenceDate                                : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , baseZeroRate                                 : ICell<double>
    , observationLag                               : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<PiecewiseZeroInflationCurve> ()
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
    let mutable
        _PiecewiseZeroInflationCurve               = make (fun () -> new PiecewiseZeroInflationCurve (referenceDate.Value, calendar.Value, dayCounter.Value, baseZeroRate.Value, observationLag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value))
    let _accuracy_                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.accuracy_)
    let _baseDate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseDate())
    let _Clone                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.Clone())
    let _data                                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data())
    let _data_                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data_)
    let _dates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates())
    let _dates_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate())
    let _initialValue                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue())
    let _initialValue1                             (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue(c.Value))
    let _instruments_                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.instruments_)
    let _interpolation_                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolation_)
    let _interpolator_                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolator_)
    let _maxDate                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate())
    let _maxDate_                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate_)
    let _maxIterations                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.moving_)
    let _nodes                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nodes())
    let _rates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.registerWith(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setTermStructure(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setupInterpolation                        = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setupInterpolation()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _times                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times())
    let _times_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times_)
    let _traits_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _zeroRate                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _zeroRate1                                 (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value))
    let _zeroRate2                                 (d : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value))
    let _zeroRate3                                 (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _baseRate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseRate())
    let _frequency                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.frequency())
    let _hasSeasonality                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.observationLag())
    let _seasonality                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _calendar                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.calendar())
    let _dayCounter                                = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dayCounter())
    let _maxTime                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxTime())
    let _referenceDate                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.referenceDate())
    let _settlementDays                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.update()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _allowsExtrapolation                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.disableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.enableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _extrapolate                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseZeroInflationCurve)
(* 
    casting 
*)
    internal new () = new PiecewiseZeroInflationCurveModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _PiecewiseZeroInflationCurve <- v
    static member Cast (p : ICell<PiecewiseZeroInflationCurve>) = 
        if p :? PiecewiseZeroInflationCurveModel then 
            p :?> PiecewiseZeroInflationCurveModel
        else
            let o = new PiecewiseZeroInflationCurveModel ()
            o.Inject p
            o.Bind p
            o
                            

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
    member this.InitialValue                       = _initialValue
    member this.InitialValue1                      c   
                                                   = _initialValue1 c 
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseZeroInflationCurveModel1
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , baseZeroRate                                 : ICell<double>
    , observationLag                               : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<PiecewiseZeroInflationCurve> ()
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
    let mutable
        _PiecewiseZeroInflationCurve               = make (fun () -> new PiecewiseZeroInflationCurve (settlementDays.Value, calendar.Value, dayCounter.Value, baseZeroRate.Value, observationLag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value))
    let _accuracy_                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.accuracy_)
    let _baseDate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseDate())
    let _Clone                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.Clone())
    let _data                                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data())
    let _data_                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data_)
    let _dates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates())
    let _dates_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate())
    let _initialValue                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue())
    let _initialValue1                             (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue(c.Value))
    let _instruments_                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.instruments_)
    let _interpolation_                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolation_)
    let _interpolator_                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolator_)
    let _maxDate                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate())
    let _maxDate_                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate_)
    let _maxIterations                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.moving_)
    let _nodes                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nodes())
    let _rates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.registerWith(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setTermStructure(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setupInterpolation                        = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setupInterpolation()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _times                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times())
    let _times_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times_)
    let _traits_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _zeroRate                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _zeroRate1                                 (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value))
    let _zeroRate2                                 (d : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value))
    let _zeroRate3                                 (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _baseRate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseRate())
    let _frequency                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.frequency())
    let _hasSeasonality                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.observationLag())
    let _seasonality                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _calendar                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.calendar())
    let _dayCounter                                = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dayCounter())
    let _maxTime                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxTime())
    let _referenceDate                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.referenceDate())
    let _settlementDays                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.update()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _allowsExtrapolation                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.disableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.enableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _extrapolate                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseZeroInflationCurve)
(* 
    casting 
*)
    internal new () = new PiecewiseZeroInflationCurveModel1(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _PiecewiseZeroInflationCurve <- v
    static member Cast (p : ICell<PiecewiseZeroInflationCurve>) = 
        if p :? PiecewiseZeroInflationCurveModel1 then 
            p :?> PiecewiseZeroInflationCurveModel1
        else
            let o = new PiecewiseZeroInflationCurveModel1 ()
            o.Inject p
            o.Bind p
            o
                            

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
    member this.InitialValue                       = _initialValue
    member this.InitialValue1                      c   
                                                   = _initialValue1 c 
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseZeroInflationCurveModel2
    ( dayCounter                                   : ICell<DayCounter>
    , baseZeroRate                                 : ICell<double>
    , observationLag                               : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , yTS                                          : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<PiecewiseZeroInflationCurve> ()
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
    let mutable
        _PiecewiseZeroInflationCurve               = make (fun () -> new PiecewiseZeroInflationCurve (dayCounter.Value, baseZeroRate.Value, observationLag.Value, frequency.Value, indexIsInterpolated.Value, yTS.Value))
    let _accuracy_                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.accuracy_)
    let _baseDate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseDate())
    let _Clone                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.Clone())
    let _data                                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data())
    let _data_                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data_)
    let _dates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates())
    let _dates_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate())
    let _initialValue                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue())
    let _initialValue1                             (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue(c.Value))
    let _instruments_                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.instruments_)
    let _interpolation_                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolation_)
    let _interpolator_                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolator_)
    let _maxDate                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate())
    let _maxDate_                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate_)
    let _maxIterations                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.moving_)
    let _nodes                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nodes())
    let _rates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.registerWith(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setTermStructure(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setupInterpolation                        = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setupInterpolation()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _times                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times())
    let _times_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times_)
    let _traits_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _zeroRate                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _zeroRate1                                 (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value))
    let _zeroRate2                                 (d : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value))
    let _zeroRate3                                 (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _baseRate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseRate())
    let _frequency                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.frequency())
    let _hasSeasonality                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.observationLag())
    let _seasonality                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _calendar                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.calendar())
    let _dayCounter                                = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dayCounter())
    let _maxTime                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxTime())
    let _referenceDate                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.referenceDate())
    let _settlementDays                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.update()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _allowsExtrapolation                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.disableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.enableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _extrapolate                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseZeroInflationCurve)
(* 
    casting 
*)
    internal new () = new PiecewiseZeroInflationCurveModel2(null,null,null,null,null,null)
    member internal this.Inject v = _PiecewiseZeroInflationCurve <- v
    static member Cast (p : ICell<PiecewiseZeroInflationCurve>) = 
        if p :? PiecewiseZeroInflationCurveModel2 then 
            p :?> PiecewiseZeroInflationCurveModel2
        else
            let o = new PiecewiseZeroInflationCurveModel2 ()
            o.Inject p
            o.Bind p
            o
                            

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
    member this.InitialValue                       = _initialValue
    member this.InitialValue1                      c   
                                                   = _initialValue1 c 
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseZeroInflationCurveModel3
    () as this =
    inherit Model<PiecewiseZeroInflationCurve> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _PiecewiseZeroInflationCurve               = make (fun () -> new PiecewiseZeroInflationCurve ())
    let _accuracy_                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.accuracy_)
    let _baseDate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseDate())
    let _Clone                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.Clone())
    let _data                                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data())
    let _data_                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.data_)
    let _dates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates())
    let _dates_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwardImpl(i.Value, t.Value))
    let _forwards                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.forwards())
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate(c.Value))
    let _initialDate1                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialDate())
    let _initialValue                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue())
    let _initialValue1                             (c : ICell<ZeroInflationTermStructure>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.initialValue(c.Value))
    let _instruments_                              = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.instruments_)
    let _interpolation_                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolation_)
    let _interpolator_                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.interpolator_)
    let _maxDate                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate())
    let _maxDate_                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxDate_)
    let _maxIterations                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.moving_)
    let _nodes                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nodes())
    let _rates                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.rates())
    let _registerWith                              (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.registerWith(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<ZeroInflationTermStructure>>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setTermStructure(helper.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _setupInterpolation                        = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setupInterpolation()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _times                                     = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times())
    let _times_                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.times_)
    let _traits_                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _zeroRate                                  (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value))
    let _zeroRate1                                 (d : ICell<Date>) (instObsLag : ICell<Period>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value))
    let _zeroRate2                                 (d : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value))
    let _zeroRate3                                 (d : ICell<Date>) (instObsLag : ICell<Period>) (forceLinearInterpolation : ICell<bool>) (extrapolate : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.zeroRate(d.Value, instObsLag.Value, forceLinearInterpolation.Value, extrapolate.Value))
    let _baseRate                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.baseRate())
    let _frequency                                 = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.frequency())
    let _hasSeasonality                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.hasSeasonality())
    let _indexIsInterpolated                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.indexIsInterpolated())
    let _nominalTermStructure                      = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.nominalTermStructure())
    let _observationLag                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.observationLag())
    let _seasonality                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.seasonality())
    let _setSeasonality                            (seasonality : ICell<Seasonality>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.setSeasonality(seasonality.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _calendar                                  = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.calendar())
    let _dayCounter                                = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.dayCounter())
    let _maxTime                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.maxTime())
    let _referenceDate                             = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.referenceDate())
    let _settlementDays                            = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.update()
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _allowsExtrapolation                       = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.disableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.enableExtrapolation(b.Value)
                                                                                                  _PiecewiseZeroInflationCurve.Value)
    let _extrapolate                               = triv _PiecewiseZeroInflationCurve (fun () -> _PiecewiseZeroInflationCurve.Value.extrapolate)
    do this.Bind(_PiecewiseZeroInflationCurve)
(* 
    casting 
*)
    
    member internal this.Inject v = _PiecewiseZeroInflationCurve <- v
    static member Cast (p : ICell<PiecewiseZeroInflationCurve>) = 
        if p :? PiecewiseZeroInflationCurveModel3 then 
            p :?> PiecewiseZeroInflationCurveModel3
        else
            let o = new PiecewiseZeroInflationCurveModel3 ()
            o.Inject p
            o.Bind p
            o
                            

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
    member this.InitialValue                       = _initialValue
    member this.InitialValue1                      c   
                                                   = _initialValue1 c 
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
