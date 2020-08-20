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
  This class provides the at-the-money volatility for a given swaption by interpolating a volatility matrix whose elements are the market volatilities of a set of swaption with given option date and swapLength.  The volatility matrix <tt>M</tt> must be defined so that: - the number of rows equals the number of option dates - the number of columns equals the number of swap tenors - <tt>M[i][j]</tt> contains the volatility corresponding to the <tt>i</tt>-th option and <tt>j</tt>-th tenor.
fixed reference date and fixed market data, option dates
  </summary> *)
[<AutoSerializable(true)>]
type SwaptionVolatilityMatrixModel
    ( today                                        : ICell<Date>
    , optionDates                                  : ICell<Generic.List<Date>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , vols                                         : ICell<Matrix>
    , dayCounter                                   : ICell<DayCounter>
    , flatExtrapolation                            : ICell<bool>
    , Type                                         : ICell<VolatilityType>
    , shifts                                       : ICell<Matrix>
    ) as this =

    inherit Model<SwaptionVolatilityMatrix> ()
(*
    Parameters
*)
    let _today                                     = today
    let _optionDates                               = optionDates
    let _swapTenors                                = swapTenors
    let _vols                                      = vols
    let _dayCounter                                = dayCounter
    let _flatExtrapolation                         = flatExtrapolation
    let _Type                                      = Type
    let _shifts                                    = shifts
(*
    Functions
*)
    let _SwaptionVolatilityMatrix                  = cell (fun () -> new SwaptionVolatilityMatrix (today.Value, optionDates.Value, swapTenors.Value, vols.Value, dayCounter.Value, flatExtrapolation.Value, Type.Value, shifts.Value))
    let _locate                                    (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionTime.Value, swapLength.Value))
    let _locate1                                   (optionDate : ICell<Date>) (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionDate.Value, swapTenor.Value))
    let _maxDate                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxStrike())
    let _maxSwapTenor                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapTenor())
    let _minStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.minStrike())
    let _volatilityType                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatilityType())
    let _optionDateFromTime                        (optionTime : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTime(optionTime.Value))
    let _optionDates                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTimes())
    let _swapLengths                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapTenors())
    let _update                                    = cell (fun () -> _SwaptionVolatilityMatrix.Value.update()
                                                                     _SwaptionVolatilityMatrix.Value)
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _SwaptionVolatilityMatrix.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _SwaptionVolatilityMatrix.Value.calendar())
    let _dayCounter                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _SwaptionVolatilityMatrix.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.disableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.enableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _extrapolate                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.extrapolate)
    do this.Bind(_SwaptionVolatilityMatrix)

(* 
    Externally visible/bindable properties
*)
    member this.today                              = _today 
    member this.optionDates                        = _optionDates 
    member this.swapTenors                         = _swapTenors 
    member this.vols                               = _vols 
    member this.dayCounter                         = _dayCounter 
    member this.flatExtrapolation                  = _flatExtrapolation 
    member this.Type                               = _Type 
    member this.shifts                             = _shifts 
    member this.Locate                             optionTime swapLength   
                                                   = _locate optionTime swapLength 
    member this.Locate1                            optionDate swapTenor   
                                                   = _locate1 optionDate swapTenor 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
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
(* <summary>
  This class provides the at-the-money volatility for a given swaption by interpolating a volatility matrix whose elements are the market volatilities of a set of swaption with given option date and swapLength.  The volatility matrix <tt>M</tt> must be defined so that: - the number of rows equals the number of option dates - the number of columns equals the number of swap tenors - <tt>M[i][j]</tt> contains the volatility corresponding to the <tt>i</tt>-th option and <tt>j</tt>-th tenor.
! fixed reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type SwaptionVolatilityMatrixModel1
    ( referenceDate                                : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , vols                                         : ICell<Matrix>
    , dayCounter                                   : ICell<DayCounter>
    , flatExtrapolation                            : ICell<bool>
    , Type                                         : ICell<VolatilityType>
    , shifts                                       : ICell<Matrix>
    ) as this =

    inherit Model<SwaptionVolatilityMatrix> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _swapTenors                                = swapTenors
    let _vols                                      = vols
    let _dayCounter                                = dayCounter
    let _flatExtrapolation                         = flatExtrapolation
    let _Type                                      = Type
    let _shifts                                    = shifts
(*
    Functions
*)
    let _SwaptionVolatilityMatrix                  = cell (fun () -> new SwaptionVolatilityMatrix (referenceDate.Value, calendar.Value, bdc.Value, optionTenors.Value, swapTenors.Value, vols.Value, dayCounter.Value, flatExtrapolation.Value, Type.Value, shifts.Value))
    let _locate                                    (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionTime.Value, swapLength.Value))
    let _locate1                                   (optionDate : ICell<Date>) (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionDate.Value, swapTenor.Value))
    let _maxDate                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxStrike())
    let _maxSwapTenor                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapTenor())
    let _minStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.minStrike())
    let _volatilityType                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatilityType())
    let _optionDateFromTime                        (optionTime : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTime(optionTime.Value))
    let _optionDates                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTimes())
    let _swapLengths                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapTenors())
    let _update                                    = cell (fun () -> _SwaptionVolatilityMatrix.Value.update()
                                                                     _SwaptionVolatilityMatrix.Value)
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _SwaptionVolatilityMatrix.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _SwaptionVolatilityMatrix.Value.calendar())
    let _dayCounter                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _SwaptionVolatilityMatrix.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.disableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.enableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _extrapolate                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.extrapolate)
    do this.Bind(_SwaptionVolatilityMatrix)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.swapTenors                         = _swapTenors 
    member this.vols                               = _vols 
    member this.dayCounter                         = _dayCounter 
    member this.flatExtrapolation                  = _flatExtrapolation 
    member this.Type                               = _Type 
    member this.shifts                             = _shifts 
    member this.Locate                             optionTime swapLength   
                                                   = _locate optionTime swapLength 
    member this.Locate1                            optionDate swapTenor   
                                                   = _locate1 optionDate swapTenor 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
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
(* <summary>
  This class provides the at-the-money volatility for a given swaption by interpolating a volatility matrix whose elements are the market volatilities of a set of swaption with given option date and swapLength.  The volatility matrix <tt>M</tt> must be defined so that: - the number of rows equals the number of option dates - the number of columns equals the number of swap tenors - <tt>M[i][j]</tt> contains the volatility corresponding to the <tt>i</tt>-th option and <tt>j</tt>-th tenor.
! floating reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type SwaptionVolatilityMatrixModel2
    ( calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , vols                                         : ICell<Matrix>
    , dayCounter                                   : ICell<DayCounter>
    , flatExtrapolation                            : ICell<bool>
    , Type                                         : ICell<VolatilityType>
    , shifts                                       : ICell<Matrix>
    ) as this =

    inherit Model<SwaptionVolatilityMatrix> ()
(*
    Parameters
*)
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _swapTenors                                = swapTenors
    let _vols                                      = vols
    let _dayCounter                                = dayCounter
    let _flatExtrapolation                         = flatExtrapolation
    let _Type                                      = Type
    let _shifts                                    = shifts
(*
    Functions
*)
    let _SwaptionVolatilityMatrix                  = cell (fun () -> new SwaptionVolatilityMatrix (calendar.Value, bdc.Value, optionTenors.Value, swapTenors.Value, vols.Value, dayCounter.Value, flatExtrapolation.Value, Type.Value, shifts.Value))
    let _locate                                    (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionTime.Value, swapLength.Value))
    let _locate1                                   (optionDate : ICell<Date>) (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionDate.Value, swapTenor.Value))
    let _maxDate                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxStrike())
    let _maxSwapTenor                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapTenor())
    let _minStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.minStrike())
    let _volatilityType                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatilityType())
    let _optionDateFromTime                        (optionTime : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTime(optionTime.Value))
    let _optionDates                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTimes())
    let _swapLengths                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapTenors())
    let _update                                    = cell (fun () -> _SwaptionVolatilityMatrix.Value.update()
                                                                     _SwaptionVolatilityMatrix.Value)
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _SwaptionVolatilityMatrix.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _SwaptionVolatilityMatrix.Value.calendar())
    let _dayCounter                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _SwaptionVolatilityMatrix.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.disableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.enableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _extrapolate                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.extrapolate)
    do this.Bind(_SwaptionVolatilityMatrix)

(* 
    Externally visible/bindable properties
*)
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.swapTenors                         = _swapTenors 
    member this.vols                               = _vols 
    member this.dayCounter                         = _dayCounter 
    member this.flatExtrapolation                  = _flatExtrapolation 
    member this.Type                               = _Type 
    member this.shifts                             = _shifts 
    member this.Locate                             optionTime swapLength   
                                                   = _locate optionTime swapLength 
    member this.Locate1                            optionDate swapTenor   
                                                   = _locate1 optionDate swapTenor 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
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
(* <summary>
  This class provides the at-the-money volatility for a given swaption by interpolating a volatility matrix whose elements are the market volatilities of a set of swaption with given option date and swapLength.  The volatility matrix <tt>M</tt> must be defined so that: - the number of rows equals the number of option dates - the number of columns equals the number of swap tenors - <tt>M[i][j]</tt> contains the volatility corresponding to the <tt>i</tt>-th option and <tt>j</tt>-th tenor.
! fixed reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type SwaptionVolatilityMatrixModel3
    ( referenceDate                                : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , vols                                         : ICell<Generic.List<Generic.List<Handle<Quote>>>>
    , dayCounter                                   : ICell<DayCounter>
    , flatExtrapolation                            : ICell<bool>
    , Type                                         : ICell<VolatilityType>
    , shifts                                       : ICell<Generic.List<Generic.List<double>>>
    ) as this =

    inherit Model<SwaptionVolatilityMatrix> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _swapTenors                                = swapTenors
    let _vols                                      = vols
    let _dayCounter                                = dayCounter
    let _flatExtrapolation                         = flatExtrapolation
    let _Type                                      = Type
    let _shifts                                    = shifts
(*
    Functions
*)
    let _SwaptionVolatilityMatrix                  = cell (fun () -> new SwaptionVolatilityMatrix (referenceDate.Value, calendar.Value, bdc.Value, optionTenors.Value, swapTenors.Value, vols.Value, dayCounter.Value, flatExtrapolation.Value, Type.Value, shifts.Value))
    let _locate                                    (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionTime.Value, swapLength.Value))
    let _locate1                                   (optionDate : ICell<Date>) (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionDate.Value, swapTenor.Value))
    let _maxDate                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxStrike())
    let _maxSwapTenor                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapTenor())
    let _minStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.minStrike())
    let _volatilityType                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatilityType())
    let _optionDateFromTime                        (optionTime : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTime(optionTime.Value))
    let _optionDates                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTimes())
    let _swapLengths                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapTenors())
    let _update                                    = cell (fun () -> _SwaptionVolatilityMatrix.Value.update()
                                                                     _SwaptionVolatilityMatrix.Value)
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _SwaptionVolatilityMatrix.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _SwaptionVolatilityMatrix.Value.calendar())
    let _dayCounter                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _SwaptionVolatilityMatrix.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.disableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.enableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _extrapolate                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.extrapolate)
    do this.Bind(_SwaptionVolatilityMatrix)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.swapTenors                         = _swapTenors 
    member this.vols                               = _vols 
    member this.dayCounter                         = _dayCounter 
    member this.flatExtrapolation                  = _flatExtrapolation 
    member this.Type                               = _Type 
    member this.shifts                             = _shifts 
    member this.Locate                             optionTime swapLength   
                                                   = _locate optionTime swapLength 
    member this.Locate1                            optionDate swapTenor   
                                                   = _locate1 optionDate swapTenor 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
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
(* <summary>
  This class provides the at-the-money volatility for a given swaption by interpolating a volatility matrix whose elements are the market volatilities of a set of swaption with given option date and swapLength.  The volatility matrix <tt>M</tt> must be defined so that: - the number of rows equals the number of option dates - the number of columns equals the number of swap tenors - <tt>M[i][j]</tt> contains the volatility corresponding to the <tt>i</tt>-th option and <tt>j</tt>-th tenor.
! floating reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type SwaptionVolatilityMatrixModel4
    ( calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , swapTenors                                   : ICell<Generic.List<Period>>
    , vols                                         : ICell<Generic.List<Generic.List<Handle<Quote>>>>
    , dayCounter                                   : ICell<DayCounter>
    , flatExtrapolation                            : ICell<bool>
    , Type                                         : ICell<VolatilityType>
    , shifts                                       : ICell<Generic.List<Generic.List<double>>>
    ) as this =

    inherit Model<SwaptionVolatilityMatrix> ()
(*
    Parameters
*)
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _swapTenors                                = swapTenors
    let _vols                                      = vols
    let _dayCounter                                = dayCounter
    let _flatExtrapolation                         = flatExtrapolation
    let _Type                                      = Type
    let _shifts                                    = shifts
(*
    Functions
*)
    let _SwaptionVolatilityMatrix                  = cell (fun () -> new SwaptionVolatilityMatrix (calendar.Value, bdc.Value, optionTenors.Value, swapTenors.Value, vols.Value, dayCounter.Value, flatExtrapolation.Value, Type.Value, shifts.Value))
    let _locate                                    (optionTime : ICell<double>) (swapLength : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionTime.Value, swapLength.Value))
    let _locate1                                   (optionDate : ICell<Date>) (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.locate(optionDate.Value, swapTenor.Value))
    let _maxDate                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxStrike())
    let _maxSwapTenor                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapTenor())
    let _minStrike                                 = cell (fun () -> _SwaptionVolatilityMatrix.Value.minStrike())
    let _volatilityType                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatilityType())
    let _optionDateFromTime                        (optionTime : ICell<double>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTime(optionTime.Value))
    let _optionDates                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionTimes())
    let _swapLengths                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLengths())
    let _swapTenors                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapTenors())
    let _update                                    = cell (fun () -> _SwaptionVolatilityMatrix.Value.update()
                                                                     _SwaptionVolatilityMatrix.Value)
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _SwaptionVolatilityMatrix.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _SwaptionVolatilityMatrix.Value.calendar())
    let _dayCounter                                = cell (fun () -> _SwaptionVolatilityMatrix.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _SwaptionVolatilityMatrix.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _SwaptionVolatilityMatrix.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _SwaptionVolatilityMatrix.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.disableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _SwaptionVolatilityMatrix.Value.enableExtrapolation(b.Value)
                                                                     _SwaptionVolatilityMatrix.Value)
    let _extrapolate                               = cell (fun () -> _SwaptionVolatilityMatrix.Value.extrapolate)
    do this.Bind(_SwaptionVolatilityMatrix)

(* 
    Externally visible/bindable properties
*)
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.swapTenors                         = _swapTenors 
    member this.vols                               = _vols 
    member this.dayCounter                         = _dayCounter 
    member this.flatExtrapolation                  = _flatExtrapolation 
    member this.Type                               = _Type 
    member this.shifts                             = _shifts 
    member this.Locate                             optionTime swapLength   
                                                   = _locate optionTime swapLength 
    member this.Locate1                            optionDate swapTenor   
                                                   = _locate1 optionDate swapTenor 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
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
