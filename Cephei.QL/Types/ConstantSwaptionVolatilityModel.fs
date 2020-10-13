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
  Constant swaption volatility, no time-strike dependence
! fixed reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantSwaptionVolatilityModel
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<Nullable<double>>
    ) as this =

    inherit Model<ConstantSwaptionVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let _ConstantSwaptionVolatility                = cell (fun () -> new ConstantSwaptionVolatility (referenceDate.Value, cal.Value, bdc.Value, vol.Value, dc.Value, Type.Value, shift.Value))
    let _maxDate                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.maxStrike())
    let _maxSwapTenor                              = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapTenor())
    let _minStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.minStrike())
    let _volatilityType                            = triv (fun () -> _ConstantSwaptionVolatility.Value.volatilityType())
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _ConstantSwaptionVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantSwaptionVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantSwaptionVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantSwaptionVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantSwaptionVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantSwaptionVolatility.Value.update()
                                                                     _ConstantSwaptionVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantSwaptionVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantSwaptionVolatility.Value.extrapolate)
    do this.Bind(_ConstantSwaptionVolatility)
(* 
    casting 
*)
    internal new () = new ConstantSwaptionVolatilityModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _ConstantSwaptionVolatility.Value <- v
    static member Cast (p : ICell<ConstantSwaptionVolatility>) = 
        if p :? ConstantSwaptionVolatilityModel then 
            p :?> ConstantSwaptionVolatilityModel
        else
            let o = new ConstantSwaptionVolatilityModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
    member this.VolatilityType                     = _volatilityType
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
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
(* <summary>
  Constant swaption volatility, no time-strike dependence
! floating reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantSwaptionVolatilityModel1
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<Nullable<double>>
    ) as this =

    inherit Model<ConstantSwaptionVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let _ConstantSwaptionVolatility                = cell (fun () -> new ConstantSwaptionVolatility (settlementDays.Value, cal.Value, bdc.Value, vol.Value, dc.Value, Type.Value, shift.Value))
    let _maxDate                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.maxStrike())
    let _maxSwapTenor                              = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapTenor())
    let _minStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.minStrike())
    let _volatilityType                            = triv (fun () -> _ConstantSwaptionVolatility.Value.volatilityType())
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _ConstantSwaptionVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantSwaptionVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantSwaptionVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantSwaptionVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantSwaptionVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantSwaptionVolatility.Value.update()
                                                                     _ConstantSwaptionVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantSwaptionVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantSwaptionVolatility.Value.extrapolate)
    do this.Bind(_ConstantSwaptionVolatility)
(* 
    casting 
*)
    internal new () = new ConstantSwaptionVolatilityModel1(null,null,null,null,null,null,null)
    member internal this.Inject v = _ConstantSwaptionVolatility.Value <- v
    static member Cast (p : ICell<ConstantSwaptionVolatility>) = 
        if p :? ConstantSwaptionVolatilityModel1 then 
            p :?> ConstantSwaptionVolatilityModel1
        else
            let o = new ConstantSwaptionVolatilityModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
    member this.VolatilityType                     = _volatilityType
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
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
(* <summary>
  Constant swaption volatility, no time-strike dependence
! fixed reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantSwaptionVolatilityModel2
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<Nullable<double>>
    ) as this =

    inherit Model<ConstantSwaptionVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let _ConstantSwaptionVolatility                = cell (fun () -> new ConstantSwaptionVolatility (referenceDate.Value, cal.Value, bdc.Value, vol.Value, dc.Value, Type.Value, shift.Value))
    let _maxDate                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.maxStrike())
    let _maxSwapTenor                              = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapTenor())
    let _minStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.minStrike())
    let _volatilityType                            = triv (fun () -> _ConstantSwaptionVolatility.Value.volatilityType())
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _ConstantSwaptionVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantSwaptionVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantSwaptionVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantSwaptionVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantSwaptionVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantSwaptionVolatility.Value.update()
                                                                     _ConstantSwaptionVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantSwaptionVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantSwaptionVolatility.Value.extrapolate)
    do this.Bind(_ConstantSwaptionVolatility)
(* 
    casting 
*)
    internal new () = new ConstantSwaptionVolatilityModel2(null,null,null,null,null,null,null)
    member internal this.Inject v = _ConstantSwaptionVolatility.Value <- v
    static member Cast (p : ICell<ConstantSwaptionVolatility>) = 
        if p :? ConstantSwaptionVolatilityModel2 then 
            p :?> ConstantSwaptionVolatilityModel2
        else
            let o = new ConstantSwaptionVolatilityModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
    member this.VolatilityType                     = _volatilityType
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
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
(* <summary>
  Constant swaption volatility, no time-strike dependence
! floating reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantSwaptionVolatilityModel3
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<Nullable<double>>
    ) as this =

    inherit Model<ConstantSwaptionVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let _ConstantSwaptionVolatility                = cell (fun () -> new ConstantSwaptionVolatility (settlementDays.Value, cal.Value, bdc.Value, vol.Value, dc.Value, Type.Value, shift.Value))
    let _maxDate                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.maxStrike())
    let _maxSwapTenor                              = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapTenor())
    let _minStrike                                 = triv (fun () -> _ConstantSwaptionVolatility.Value.minStrike())
    let _volatilityType                            = triv (fun () -> _ConstantSwaptionVolatility.Value.volatilityType())
    let _blackVariance                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance3                            (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance4                            (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance5                            (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.blackVariance(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _maxSwapLength                             = triv (fun () -> _ConstantSwaptionVolatility.Value.maxSwapLength())
    let _shift                                     (optionTime : ICell<double>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapLength.Value, extrapolate.Value))
    let _shift1                                    (optionDate : ICell<Date>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapLength.Value, extrapolate.Value))
    let _shift2                                    (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapTenor.Value, extrapolate.Value))
    let _shift3                                    (optionTenor : ICell<Period>) (swapLength : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTenor.Value, swapLength.Value, extrapolate.Value))
    let _shift4                                    (optionTime : ICell<double>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionTime.Value, swapTenor.Value, extrapolate.Value))
    let _shift5                                    (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.shift(optionDate.Value, swapTenor.Value, extrapolate.Value))
    let _smileSection                              (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionDate.Value, swapTenor.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTenor.Value, swapTenor.Value, extr.Value))
    let _smileSection2                             (optionTime : ICell<double>) (swapLength : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.smileSection(optionTime.Value, swapLength.Value, extr.Value))
    let _swapLength                                (start : ICell<Date>) (End : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(start.Value, End.Value))
    let _swapLength1                               (swapTenor : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.swapLength(swapTenor.Value))
    let _volatility                                (optionTime : ICell<double>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionDate : ICell<Date>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility3                               (optionTime : ICell<double>) (swapLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTime.Value, swapLength.Value, strike.Value, extrapolate.Value))
    let _volatility4                               (optionDate : ICell<Date>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionDate.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (swapTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.volatility(optionTenor.Value, swapTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _ConstantSwaptionVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantSwaptionVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantSwaptionVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantSwaptionVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantSwaptionVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantSwaptionVolatility.Value.update()
                                                                     _ConstantSwaptionVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantSwaptionVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantSwaptionVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantSwaptionVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantSwaptionVolatility.Value.extrapolate)
    do this.Bind(_ConstantSwaptionVolatility)
(* 
    casting 
*)
    internal new () = new ConstantSwaptionVolatilityModel3(null,null,null,null,null,null,null)
    member internal this.Inject v = _ConstantSwaptionVolatility.Value <- v
    static member Cast (p : ICell<ConstantSwaptionVolatility>) = 
        if p :? ConstantSwaptionVolatilityModel3 then 
            p :?> ConstantSwaptionVolatilityModel3
        else
            let o = new ConstantSwaptionVolatilityModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxSwapTenor                       = _maxSwapTenor
    member this.MinStrike                          = _minStrike
    member this.VolatilityType                     = _volatilityType
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
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
