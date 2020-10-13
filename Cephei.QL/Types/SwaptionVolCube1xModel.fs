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
type SwaptionVolCube1xModel
    ( atmVolStructure                              : ICell<Handle<SwaptionVolatilityStructure>>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , strikeSpreads                                : ICell<Generic.List<double>>
    , volSpreads                                   : ICell<Generic.List<Generic.List<Handle<Quote>>>>
    , swapIndexBase                                : ICell<SwapIndex>
    , shortSwapIndexBase                           : ICell<SwapIndex>
    , vegaWeightedSmileFit                         : ICell<bool>
    , parametersGuess                              : ICell<Generic.List<Generic.List<Handle<Quote>>>>
    , isParameterFixed                             : ICell<Generic.List<bool>>
    , isAtmCalibrated                              : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , maxErrorTolerance                            : ICell<Nullable<double>>
    , optMethod                                    : ICell<OptimizationMethod>
    , errorAccept                                  : ICell<Nullable<double>>
    , useMaxError                                  : ICell<bool>
    , maxGuesses                                   : ICell<int>
    , backwardFlat                                 : ICell<bool>
    , cutoffStrike                                 : ICell<double>
    ) as this =

    inherit Model<SwaptionVolCube1x> ()
(*
    Parameters
*)
    let _atmVolStructure                           = atmVolStructure
    let _optionTenors                              = optionTenors
    let _swapTenors                                = swapTenors
    let _strikeSpreads                             = strikeSpreads
    let _volSpreads                                = volSpreads
    let _swapIndexBase                             = swapIndexBase
    let _shortSwapIndexBase                        = shortSwapIndexBase
    let _vegaWeightedSmileFit                      = vegaWeightedSmileFit
    let _parametersGuess                           = parametersGuess
    let _isParameterFixed                          = isParameterFixed
    let _isAtmCalibrated                           = isAtmCalibrated
    let _endCriteria                               = endCriteria
    let _maxErrorTolerance                         = maxErrorTolerance
    let _optMethod                                 = optMethod
    let _errorAccept                               = errorAccept
    let _useMaxError                               = useMaxError
    let _maxGuesses                                = maxGuesses
    let _backwardFlat                              = backwardFlat
    let _cutoffStrike                              = cutoffStrike
(*
    Functions
*)
    let _SwaptionVolCube1x                         = cell (fun () -> new SwaptionVolCube1x (atmVolStructure.Value, optionTenors.Value, swapTenors.Value, strikeSpreads.Value, volSpreads.Value, swapIndexBase.Value, shortSwapIndexBase.Value, vegaWeightedSmileFit.Value, parametersGuess.Value, isParameterFixed.Value, isAtmCalibrated.Value, endCriteria.Value, maxErrorTolerance.Value, optMethod.Value, errorAccept.Value, useMaxError.Value, maxGuesses.Value, backwardFlat.Value, cutoffStrike.Value))
    let _denseSabrParameters                       = triv (fun () -> _SwaptionVolCube1x.Value.denseSabrParameters())
    let _marketVolCube                             = triv (fun () -> _SwaptionVolCube1x.Value.marketVolCube())
    let _marketVolCube1                            (i : ICell<int>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.marketVolCube(i.Value))
    let _recalibration                             (beta : ICell<double>) (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.recalibration(beta.Value, swapTenor.Value)
                                                                     _SwaptionVolCube1x.Value)
    let _recalibration1                            (swapLengths : ICell<Generic.List<Period>>) (beta : ICell<Generic.List<double>>) (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.recalibration(swapLengths.Value, beta.Value, swapTenor.Value)
                                                                     _SwaptionVolCube1x.Value)
    let _recalibration2                            (beta : ICell<Generic.List<double>>) (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.recalibration(beta.Value, swapTenor.Value)
                                                                     _SwaptionVolCube1x.Value)
    let _sabrCalibrationSection                    (marketVolCube : ICell<SwaptionVolCube1x.Cube>) (parametersCube : ICell<SwaptionVolCube1x.Cube>) (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.sabrCalibrationSection(marketVolCube.Value, parametersCube.Value, swapTenor.Value)
                                                                     _SwaptionVolCube1x.Value)
    let _sparseSabrParameters                      = triv (fun () -> _SwaptionVolCube1x.Value.sparseSabrParameters())
    let _updateAfterRecalibration                  = triv (fun () -> _SwaptionVolCube1x.Value.updateAfterRecalibration()
                                                                     _SwaptionVolCube1x.Value)
    let _volCubeAtmCalibrated                      = triv (fun () -> _SwaptionVolCube1x.Value.volCubeAtmCalibrated())
    let _atmStrike                                 (optionDate : ICell<Date>) (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.atmStrike(optionDate.Value, swapTenor.Value))
    let _atmStrike1                                (optionTenor : ICell<Period>) (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.atmStrike(optionTenor.Value, swapTenor.Value))
    let _atmVol                                    = triv (fun () -> _SwaptionVolCube1x.Value.atmVol())
    let _calendar                                  = triv (fun () -> _SwaptionVolCube1x.Value.calendar())
    let _dayCounter                                = triv (fun () -> _SwaptionVolCube1x.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _SwaptionVolCube1x.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _SwaptionVolCube1x.Value.maxStrike())
    let _maxSwapTenor                              = triv (fun () -> _SwaptionVolCube1x.Value.maxSwapTenor())
    let _maxTime                                   = triv (fun () -> _SwaptionVolCube1x.Value.maxTime())
    let _minStrike                                 = triv (fun () -> _SwaptionVolCube1x.Value.minStrike())
    let _referenceDate                             = triv (fun () -> _SwaptionVolCube1x.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _SwaptionVolCube1x.Value.settlementDays())
    let _shortSwapIndexBase                        = triv (fun () -> _SwaptionVolCube1x.Value.shortSwapIndexBase())
    let _strikeSpreads                             = triv (fun () -> _SwaptionVolCube1x.Value.strikeSpreads())
    let _swapIndexBase                             = triv (fun () -> _SwaptionVolCube1x.Value.swapIndexBase())
    let _vegaWeightedSmileFit                      = triv (fun () -> _SwaptionVolCube1x.Value.vegaWeightedSmileFit())
    let _volatilityType                            = triv (fun () -> _SwaptionVolCube1x.Value.volatilityType())
    let _volSpreads                                = triv (fun () -> _SwaptionVolCube1x.Value.volSpreads())
    let _optionDateFromTime                        (optionTime : ICell<double>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.optionDateFromTime(optionTime.Value))
    let _optionDates                               = triv (fun () -> _SwaptionVolCube1x.Value.optionDates())
    let _optionTenors                              = triv (fun () -> _SwaptionVolCube1x.Value.optionTenors())
    let _optionTimes                               = triv (fun () -> _SwaptionVolCube1x.Value.optionTimes())
    let _swapLengths                               = triv (fun () -> _SwaptionVolCube1x.Value.swapLengths())
    let _swapTenors                                = triv (fun () -> _SwaptionVolCube1x.Value.swapTenors())
    let _update                                    = triv (fun () -> _SwaptionVolCube1x.Value.update()
                                                                     _SwaptionVolCube1x.Value)
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = triv (fun () -> _SwaptionVolCube1x.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _SwaptionVolCube1x.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.optionDateFromTenor(p.Value))
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _SwaptionVolCube1x.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.disableExtrapolation(b.Value)
                                                                     _SwaptionVolCube1x.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _SwaptionVolCube1x.Value.enableExtrapolation(b.Value)
                                                                     _SwaptionVolCube1x.Value)
    let _extrapolate                               = triv (fun () -> _SwaptionVolCube1x.Value.extrapolate)
    do this.Bind(_SwaptionVolCube1x)
(* 
    casting 
*)
    internal new () = new SwaptionVolCube1xModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwaptionVolCube1x.Value <- v
    static member Cast (p : ICell<SwaptionVolCube1x>) = 
        if p :? SwaptionVolCube1xModel then 
            p :?> SwaptionVolCube1xModel
        else
            let o = new SwaptionVolCube1xModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.atmVolStructure                    = _atmVolStructure 
    member this.optionTenors                       = _optionTenors 
    member this.swapTenors                         = _swapTenors 
    member this.strikeSpreads                      = _strikeSpreads 
    member this.volSpreads                         = _volSpreads 
    member this.swapIndexBase                      = _swapIndexBase 
    member this.shortSwapIndexBase                 = _shortSwapIndexBase 
    member this.vegaWeightedSmileFit               = _vegaWeightedSmileFit 
    member this.parametersGuess                    = _parametersGuess 
    member this.isParameterFixed                   = _isParameterFixed 
    member this.isAtmCalibrated                    = _isAtmCalibrated 
    member this.endCriteria                        = _endCriteria 
    member this.maxErrorTolerance                  = _maxErrorTolerance 
    member this.optMethod                          = _optMethod 
    member this.errorAccept                        = _errorAccept 
    member this.useMaxError                        = _useMaxError 
    member this.maxGuesses                         = _maxGuesses 
    member this.backwardFlat                       = _backwardFlat 
    member this.cutoffStrike                       = _cutoffStrike 
    member this.DenseSabrParameters                = _denseSabrParameters
    member this.MarketVolCube                      = _marketVolCube
    member this.MarketVolCube1                     i   
                                                   = _marketVolCube1 i 
    member this.Recalibration                      beta swapTenor   
                                                   = _recalibration beta swapTenor 
    member this.Recalibration1                     swapLengths beta swapTenor   
                                                   = _recalibration1 swapLengths beta swapTenor 
    member this.Recalibration2                     beta swapTenor   
                                                   = _recalibration2 beta swapTenor 
    member this.SabrCalibrationSection             marketVolCube parametersCube swapTenor   
                                                   = _sabrCalibrationSection marketVolCube parametersCube swapTenor 
    member this.SparseSabrParameters               = _sparseSabrParameters
    member this.UpdateAfterRecalibration           = _updateAfterRecalibration
    member this.VolCubeAtmCalibrated               = _volCubeAtmCalibrated
    member this.AtmStrike                          optionDate swapTenor   
                                                   = _atmStrike optionDate swapTenor 
    member this.AtmStrike1                         optionTenor swapTenor   
                                                   = _atmStrike1 optionTenor swapTenor 
    member this.AtmVol                             = _atmVol
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MaxTime                            = _maxTime
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
    member this.ShortSwapIndexBase                 = _shortSwapIndexBase
    member this.StrikeSpreads                      = _strikeSpreads
    member this.SwapIndexBase                      = _swapIndexBase
    member this.VegaWeightedSmileFit               = _vegaWeightedSmileFit
    member this.VolatilityType                     = _volatilityType
    member this.VolSpreads                         = _volSpreads
    member this.OptionDateFromTime                 optionTime   
                                                   = _optionDateFromTime optionTime 
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.SwapLengths                        = _swapLengths
    member this.SwapTenors                         = _swapTenors
    member this.Update                             = _update
    member this.BlackVariance                      optionTenor swapTenor strike extrapolate   
                                                   = _blackVariance optionTenor swapTenor strike extrapolate 
    member this.BlackVariance1                     optionDate swapTenor strike extrapolate   
                                                   = _blackVariance1 optionDate swapTenor strike extrapolate 
    member this.BlackVariance2                     optionTime swapTenor strike extrapolate   
                                                   = _blackVariance2 optionTime swapTenor strike extrapolate 
    member this.BlackVariance3                     optionTenor swapLength strike extrapolate   
                                                   = _blackVariance3 optionTenor swapLength strike extrapolate 
    member this.BlackVariance4                     optionTime swapLength strike extrapolate   
                                                   = _blackVariance4 optionTime swapLength strike extrapolate 
    member this.BlackVariance5                     optionDate swapLength strike extrapolate   
                                                   = _blackVariance5 optionDate swapLength strike extrapolate 
    member this.MaxSwapLength                      = _maxSwapLength
    member this.Shift                              optionTime swapLength extrapolate   
                                                   = _shift optionTime swapLength extrapolate 
    member this.Shift1                             optionDate swapLength extrapolate   
                                                   = _shift1 optionDate swapLength extrapolate 
    member this.Shift2                             optionTenor swapTenor extrapolate   
                                                   = _shift2 optionTenor swapTenor extrapolate 
    member this.Shift3                             optionTenor swapLength extrapolate   
                                                   = _shift3 optionTenor swapLength extrapolate 
    member this.Shift4                             optionTime swapTenor extrapolate   
                                                   = _shift4 optionTime swapTenor extrapolate 
    member this.Shift5                             optionDate swapTenor extrapolate   
                                                   = _shift5 optionDate swapTenor extrapolate 
    member this.SmileSection                       optionDate swapTenor extr   
                                                   = _smileSection optionDate swapTenor extr 
    member this.SmileSection1                      optionTenor swapTenor extr   
                                                   = _smileSection1 optionTenor swapTenor extr 
    member this.SmileSection2                      optionTime swapLength extr   
                                                   = _smileSection2 optionTime swapLength extr 
    member this.SwapLength                         start End   
                                                   = _swapLength start End 
    member this.SwapLength1                        swapTenor   
                                                   = _swapLength1 swapTenor 
    member this.Volatility                         optionTime swapTenor strike extrapolate   
                                                   = _volatility optionTime swapTenor strike extrapolate 
    member this.Volatility1                        optionTenor swapLength strike extrapolate   
                                                   = _volatility1 optionTenor swapLength strike extrapolate 
    member this.Volatility2                        optionDate swapLength strike extrapolate   
                                                   = _volatility2 optionDate swapLength strike extrapolate 
    member this.Volatility3                        optionTime swapLength strike extrapolate   
                                                   = _volatility3 optionTime swapLength strike extrapolate 
    member this.Volatility4                        optionDate swapTenor strike extrapolate   
                                                   = _volatility4 optionDate swapTenor strike extrapolate 
    member this.Volatility5                        optionTenor swapTenor strike extrapolate   
                                                   = _volatility5 optionTenor swapTenor strike extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
