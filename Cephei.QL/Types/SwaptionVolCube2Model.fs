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
  The swaption vol cube is made up of ordered swaption vol surface layers, each layer referring to a swap index of a given length (in years), all indexes belonging to the same family. In order to identify the family (and its market conventions) an index of whatever length from that family must be passed in as swapIndexBase.  Often for short swap length the swap index family is different, e.g. the EUR case: swap vs 6M Euribor is used for length>1Y, while swap vs 3M Euribor is used for the 1Y length. The shortSwapIndexBase is used to identify this second family.

  </summary> *)
[<AutoSerializable(true)>]
type SwaptionVolCube2Model
    ( atmVolStructure                              : ICell<Handle<SwaptionVolatilityStructure>>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , strikeSpreads                                : ICell<Generic.List<double>>
    , volSpreads                                   : ICell<Generic.List<Generic.List<Handle<Quote>>>>
    , swapIndexBase                                : ICell<SwapIndex>
    , shortSwapIndexBase                           : ICell<SwapIndex>
    , vegaWeightedSmileFit                         : ICell<bool>
    ) as this =

    inherit Model<SwaptionVolCube2> ()
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
(*
    Functions
*)
    let _SwaptionVolCube2                          = cell (fun () -> new SwaptionVolCube2 (atmVolStructure.Value, optionTenors.Value, swapTenors.Value, strikeSpreads.Value, volSpreads.Value, swapIndexBase.Value, shortSwapIndexBase.Value, vegaWeightedSmileFit.Value))
    let _volSpreads                                (i : ICell<int>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.volSpreads(i.Value))
    let _atmStrike                                 (optionDate : ICell<Date>) (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.atmStrike(optionDate.Value, swapTenor.Value))
    let _atmStrike1                                (optionTenor : ICell<Period>) (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.atmStrike(optionTenor.Value, swapTenor.Value))
    let _atmVol                                    = cell (fun () -> _SwaptionVolCube2.Value.atmVol())
    let _calendar                                  = cell (fun () -> _SwaptionVolCube2.Value.calendar())
    let _dayCounter                                = cell (fun () -> _SwaptionVolCube2.Value.dayCounter())
    let _maxDate                                   = cell (fun () -> _SwaptionVolCube2.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _SwaptionVolCube2.Value.maxStrike())
    let _maxSwapTenor                              = cell (fun () -> _SwaptionVolCube2.Value.maxSwapTenor())
    let _maxTime                                   = cell (fun () -> _SwaptionVolCube2.Value.maxTime())
    let _minStrike                                 = cell (fun () -> _SwaptionVolCube2.Value.minStrike())
    let _referenceDate                             = cell (fun () -> _SwaptionVolCube2.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _SwaptionVolCube2.Value.settlementDays())
    let _shortSwapIndexBase                        = cell (fun () -> _SwaptionVolCube2.Value.shortSwapIndexBase())
    let _strikeSpreads                             = cell (fun () -> _SwaptionVolCube2.Value.strikeSpreads())
    let _swapIndexBase                             = cell (fun () -> _SwaptionVolCube2.Value.swapIndexBase())
    let _vegaWeightedSmileFit                      = cell (fun () -> _SwaptionVolCube2.Value.vegaWeightedSmileFit())
    let _volatilityType                            = cell (fun () -> _SwaptionVolCube2.Value.volatilityType())
    let _optionDateFromTime                        (optionTime : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.optionDateFromTime(optionTime.Value))
    let _optionDates                               = cell (fun () -> _SwaptionVolCube2.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _SwaptionVolCube2.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _SwaptionVolCube2.Value.optionTimes())
    let _swapLengths                               = cell (fun () -> _SwaptionVolCube2.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _SwaptionVolCube2.Value.swapTenors())
    let _update                                    = cell (fun () -> _SwaptionVolCube2.Value.update()
                                                                     _SwaptionVolCube2.Value)
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = cell (fun () -> _SwaptionVolCube2.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _SwaptionVolCube2.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.optionDateFromTenor(p.Value))
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _SwaptionVolCube2.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.disableExtrapolation(b.Value)
                                                                     _SwaptionVolCube2.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolCube2.Value.enableExtrapolation(b.Value)
                                                                     _SwaptionVolCube2.Value)
    let _extrapolate                               = cell (fun () -> _SwaptionVolCube2.Value.extrapolate)
    do this.Bind(_SwaptionVolCube2)

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
    member this.VolSpreads                         i   
                                                   = _volSpreads i 
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
