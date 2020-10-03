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
  Constant callable-bond volatility, no time-strike dependence

  </summary> *)
[<AutoSerializable(true)>]
type CallableBondConstantVolatilityModel
    ( referenceDate                                : ICell<Date>
    , volatility                                   : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<CallableBondConstantVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _volatility                                = volatility
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _CallableBondConstantVolatility            = cell (fun () -> new CallableBondConstantVolatility (referenceDate.Value, volatility.Value, dayCounter.Value))
    let _dayCounter                                = triv (fun () -> _CallableBondConstantVolatility.Value.dayCounter())
    let _maxBondLength                             = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondLength())
    let _maxBondTenor                              = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondTenor())
    let _maxDate                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.minStrike())
    let _blackVariance                             (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionTime : ICell<double>) (bondLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTime.Value, bondLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _CallableBondConstantVolatility.Value.businessDayConvention())
    let _convertDates                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.convertDates(optionDate.Value, bondTenor.Value))
    let _optionDateFromTenor                       (optionTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.optionDateFromTenor(optionTenor.Value))
    let _smileSection                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionDate.Value, bondTenor.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionTenor.Value, bondTenor.Value))
    let _volatility                                (optionTenor : ICell<double>) (bondTenor : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _CallableBondConstantVolatility.Value.calendar())
    let _maxTime                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _CallableBondConstantVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _CallableBondConstantVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _CallableBondConstantVolatility.Value.update()
                                                                     _CallableBondConstantVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _CallableBondConstantVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.disableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.enableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _extrapolate                               = triv (fun () -> _CallableBondConstantVolatility.Value.extrapolate)
    do this.Bind(_CallableBondConstantVolatility)
(* 
    casting 
*)
    internal new () = CallableBondConstantVolatilityModel(null,null,null)
    member internal this.Inject v = _CallableBondConstantVolatility.Value <- v
    static member Cast (p : ICell<CallableBondConstantVolatility>) = 
        if p :? CallableBondConstantVolatilityModel then 
            p :?> CallableBondConstantVolatilityModel
        else
            let o = new CallableBondConstantVolatilityModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.volatility                         = _volatility 
    member this.dayCounter                         = _dayCounter 
    member this.DayCounter                         = _dayCounter
    member this.MaxBondLength                      = _maxBondLength
    member this.MaxBondTenor                       = _maxBondTenor
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionDate bondTenor strike extrapolate   
                                                   = _blackVariance optionDate bondTenor strike extrapolate 
    member this.BlackVariance1                     optionTime bondLength strike extrapolate   
                                                   = _blackVariance1 optionTime bondLength strike extrapolate 
    member this.BlackVariance2                     optionTenor bondTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor bondTenor strike extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.ConvertDates                       optionDate bondTenor   
                                                   = _convertDates optionDate bondTenor 
    member this.OptionDateFromTenor                optionTenor   
                                                   = _optionDateFromTenor optionTenor 
    member this.SmileSection                       optionDate bondTenor   
                                                   = _smileSection optionDate bondTenor 
    member this.SmileSection1                      optionTenor bondTenor   
                                                   = _smileSection1 optionTenor bondTenor 
    member this.Volatility                         optionTenor bondTenor strike extrapolate   
                                                   = _volatility optionTenor bondTenor strike extrapolate 
    member this.Volatility1                        optionDate bondTenor strike extrapolate   
                                                   = _volatility1 optionDate bondTenor strike extrapolate 
    member this.Volatility2                        optionTenor bondTenor strike extrapolate   
                                                   = _volatility2 optionTenor bondTenor strike extrapolate 
    member this.Calendar                           = _calendar
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
  Constant callable-bond volatility, no time-strike dependence

  </summary> *)
[<AutoSerializable(true)>]
type CallableBondConstantVolatilityModel1
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , volatility                                   : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<CallableBondConstantVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _volatility                                = volatility
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _CallableBondConstantVolatility            = cell (fun () -> new CallableBondConstantVolatility (settlementDays.Value, calendar.Value, volatility.Value, dayCounter.Value))
    let _dayCounter                                = triv (fun () -> _CallableBondConstantVolatility.Value.dayCounter())
    let _maxBondLength                             = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondLength())
    let _maxBondTenor                              = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondTenor())
    let _maxDate                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.minStrike())
    let _blackVariance                             (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionTime : ICell<double>) (bondLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTime.Value, bondLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _CallableBondConstantVolatility.Value.businessDayConvention())
    let _convertDates                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.convertDates(optionDate.Value, bondTenor.Value))
    let _optionDateFromTenor                       (optionTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.optionDateFromTenor(optionTenor.Value))
    let _smileSection                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionDate.Value, bondTenor.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionTenor.Value, bondTenor.Value))
    let _volatility                                (optionTenor : ICell<double>) (bondTenor : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _CallableBondConstantVolatility.Value.calendar())
    let _maxTime                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _CallableBondConstantVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _CallableBondConstantVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _CallableBondConstantVolatility.Value.update()
                                                                     _CallableBondConstantVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _CallableBondConstantVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.disableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.enableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _extrapolate                               = triv (fun () -> _CallableBondConstantVolatility.Value.extrapolate)
    do this.Bind(_CallableBondConstantVolatility)
(* 
    casting 
*)
    internal new () = CallableBondConstantVolatilityModel1(null,null,null,null)
    member internal this.Inject v = _CallableBondConstantVolatility.Value <- v
    static member Cast (p : ICell<CallableBondConstantVolatility>) = 
        if p :? CallableBondConstantVolatilityModel1 then 
            p :?> CallableBondConstantVolatilityModel1
        else
            let o = new CallableBondConstantVolatilityModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.volatility                         = _volatility 
    member this.dayCounter                         = _dayCounter 
    member this.DayCounter                         = _dayCounter
    member this.MaxBondLength                      = _maxBondLength
    member this.MaxBondTenor                       = _maxBondTenor
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionDate bondTenor strike extrapolate   
                                                   = _blackVariance optionDate bondTenor strike extrapolate 
    member this.BlackVariance1                     optionTime bondLength strike extrapolate   
                                                   = _blackVariance1 optionTime bondLength strike extrapolate 
    member this.BlackVariance2                     optionTenor bondTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor bondTenor strike extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.ConvertDates                       optionDate bondTenor   
                                                   = _convertDates optionDate bondTenor 
    member this.OptionDateFromTenor                optionTenor   
                                                   = _optionDateFromTenor optionTenor 
    member this.SmileSection                       optionDate bondTenor   
                                                   = _smileSection optionDate bondTenor 
    member this.SmileSection1                      optionTenor bondTenor   
                                                   = _smileSection1 optionTenor bondTenor 
    member this.Volatility                         optionTenor bondTenor strike extrapolate   
                                                   = _volatility optionTenor bondTenor strike extrapolate 
    member this.Volatility1                        optionDate bondTenor strike extrapolate   
                                                   = _volatility1 optionDate bondTenor strike extrapolate 
    member this.Volatility2                        optionTenor bondTenor strike extrapolate   
                                                   = _volatility2 optionTenor bondTenor strike extrapolate 
    member this.Calendar                           = _calendar
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
  Constant callable-bond volatility, no time-strike dependence

  </summary> *)
[<AutoSerializable(true)>]
type CallableBondConstantVolatilityModel2
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , volatility                                   : ICell<Handle<Quote>>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<CallableBondConstantVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _volatility                                = volatility
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _CallableBondConstantVolatility            = cell (fun () -> new CallableBondConstantVolatility (settlementDays.Value, calendar.Value, volatility.Value, dayCounter.Value))
    let _dayCounter                                = triv (fun () -> _CallableBondConstantVolatility.Value.dayCounter())
    let _maxBondLength                             = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondLength())
    let _maxBondTenor                              = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondTenor())
    let _maxDate                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.minStrike())
    let _blackVariance                             (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionTime : ICell<double>) (bondLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTime.Value, bondLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _CallableBondConstantVolatility.Value.businessDayConvention())
    let _convertDates                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.convertDates(optionDate.Value, bondTenor.Value))
    let _optionDateFromTenor                       (optionTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.optionDateFromTenor(optionTenor.Value))
    let _smileSection                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionDate.Value, bondTenor.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionTenor.Value, bondTenor.Value))
    let _volatility                                (optionTenor : ICell<double>) (bondTenor : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _CallableBondConstantVolatility.Value.calendar())
    let _maxTime                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _CallableBondConstantVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _CallableBondConstantVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _CallableBondConstantVolatility.Value.update()
                                                                     _CallableBondConstantVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _CallableBondConstantVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.disableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.enableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _extrapolate                               = triv (fun () -> _CallableBondConstantVolatility.Value.extrapolate)
    do this.Bind(_CallableBondConstantVolatility)
(* 
    casting 
*)
    internal new () = CallableBondConstantVolatilityModel2(null,null,null,null)
    member internal this.Inject v = _CallableBondConstantVolatility.Value <- v
    static member Cast (p : ICell<CallableBondConstantVolatility>) = 
        if p :? CallableBondConstantVolatilityModel2 then 
            p :?> CallableBondConstantVolatilityModel2
        else
            let o = new CallableBondConstantVolatilityModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.volatility                         = _volatility 
    member this.dayCounter                         = _dayCounter 
    member this.DayCounter                         = _dayCounter
    member this.MaxBondLength                      = _maxBondLength
    member this.MaxBondTenor                       = _maxBondTenor
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionDate bondTenor strike extrapolate   
                                                   = _blackVariance optionDate bondTenor strike extrapolate 
    member this.BlackVariance1                     optionTime bondLength strike extrapolate   
                                                   = _blackVariance1 optionTime bondLength strike extrapolate 
    member this.BlackVariance2                     optionTenor bondTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor bondTenor strike extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.ConvertDates                       optionDate bondTenor   
                                                   = _convertDates optionDate bondTenor 
    member this.OptionDateFromTenor                optionTenor   
                                                   = _optionDateFromTenor optionTenor 
    member this.SmileSection                       optionDate bondTenor   
                                                   = _smileSection optionDate bondTenor 
    member this.SmileSection1                      optionTenor bondTenor   
                                                   = _smileSection1 optionTenor bondTenor 
    member this.Volatility                         optionTenor bondTenor strike extrapolate   
                                                   = _volatility optionTenor bondTenor strike extrapolate 
    member this.Volatility1                        optionDate bondTenor strike extrapolate   
                                                   = _volatility1 optionDate bondTenor strike extrapolate 
    member this.Volatility2                        optionTenor bondTenor strike extrapolate   
                                                   = _volatility2 optionTenor bondTenor strike extrapolate 
    member this.Calendar                           = _calendar
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
  Constant callable-bond volatility, no time-strike dependence

  </summary> *)
[<AutoSerializable(true)>]
type CallableBondConstantVolatilityModel3
    ( referenceDate                                : ICell<Date>
    , volatility                                   : ICell<Handle<Quote>>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<CallableBondConstantVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _volatility                                = volatility
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _CallableBondConstantVolatility            = cell (fun () -> new CallableBondConstantVolatility (referenceDate.Value, volatility.Value, dayCounter.Value))
    let _dayCounter                                = triv (fun () -> _CallableBondConstantVolatility.Value.dayCounter())
    let _maxBondLength                             = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondLength())
    let _maxBondTenor                              = triv (fun () -> _CallableBondConstantVolatility.Value.maxBondTenor())
    let _maxDate                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _CallableBondConstantVolatility.Value.minStrike())
    let _blackVariance                             (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionTime : ICell<double>) (bondLength : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTime.Value, bondLength.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.blackVariance(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _CallableBondConstantVolatility.Value.businessDayConvention())
    let _convertDates                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.convertDates(optionDate.Value, bondTenor.Value))
    let _optionDateFromTenor                       (optionTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.optionDateFromTenor(optionTenor.Value))
    let _smileSection                              (optionDate : ICell<Date>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionDate.Value, bondTenor.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (bondTenor : ICell<Period>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.smileSection(optionTenor.Value, bondTenor.Value))
    let _volatility                                (optionTenor : ICell<double>) (bondTenor : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionDate.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTenor : ICell<Period>) (bondTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.volatility(optionTenor.Value, bondTenor.Value, strike.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _CallableBondConstantVolatility.Value.calendar())
    let _maxTime                                   = triv (fun () -> _CallableBondConstantVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _CallableBondConstantVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _CallableBondConstantVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _CallableBondConstantVolatility.Value.update()
                                                                     _CallableBondConstantVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _CallableBondConstantVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.disableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _CallableBondConstantVolatility.Value.enableExtrapolation(b.Value)
                                                                     _CallableBondConstantVolatility.Value)
    let _extrapolate                               = triv (fun () -> _CallableBondConstantVolatility.Value.extrapolate)
    do this.Bind(_CallableBondConstantVolatility)
(* 
    casting 
*)
    internal new () = CallableBondConstantVolatilityModel3(null,null,null)
    member internal this.Inject v = _CallableBondConstantVolatility.Value <- v
    static member Cast (p : ICell<CallableBondConstantVolatility>) = 
        if p :? CallableBondConstantVolatilityModel3 then 
            p :?> CallableBondConstantVolatilityModel3
        else
            let o = new CallableBondConstantVolatilityModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.volatility                         = _volatility 
    member this.dayCounter                         = _dayCounter 
    member this.DayCounter                         = _dayCounter
    member this.MaxBondLength                      = _maxBondLength
    member this.MaxBondTenor                       = _maxBondTenor
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionDate bondTenor strike extrapolate   
                                                   = _blackVariance optionDate bondTenor strike extrapolate 
    member this.BlackVariance1                     optionTime bondLength strike extrapolate   
                                                   = _blackVariance1 optionTime bondLength strike extrapolate 
    member this.BlackVariance2                     optionTenor bondTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor bondTenor strike extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.ConvertDates                       optionDate bondTenor   
                                                   = _convertDates optionDate bondTenor 
    member this.OptionDateFromTenor                optionTenor   
                                                   = _optionDateFromTenor optionTenor 
    member this.SmileSection                       optionDate bondTenor   
                                                   = _smileSection optionDate bondTenor 
    member this.SmileSection1                      optionTenor bondTenor   
                                                   = _smileSection1 optionTenor bondTenor 
    member this.Volatility                         optionTenor bondTenor strike extrapolate   
                                                   = _volatility optionTenor bondTenor strike extrapolate 
    member this.Volatility1                        optionDate bondTenor strike extrapolate   
                                                   = _volatility1 optionDate bondTenor strike extrapolate 
    member this.Volatility2                        optionTenor bondTenor strike extrapolate   
                                                   = _volatility2 optionTenor bondTenor strike extrapolate 
    member this.Calendar                           = _calendar
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
