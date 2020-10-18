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
  Constant caplet volatility, no time-strike dependence
! fixed reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantOptionletVolatilityModel
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantOptionletVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantOptionletVolatility               = cell (fun () -> new ConstantOptionletVolatility (referenceDate.Value, cal.Value, bdc.Value, vol.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.minStrike())
    let _blackVariance                             (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTime.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionDate.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTenor.Value, strike.Value, extrapolate.Value))
    let _displacement                              = triv (fun () -> _ConstantOptionletVolatility.Value.displacement())
    let _smileSection                              (optionTime : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTime.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTenor.Value, extr.Value))
    let _smileSection2                             (optionDate : ICell<Date>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionDate.Value, extr.Value))
    let _volatility                                (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionDate.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTime.Value, strike.Value, extrapolate.Value))
    let _volatilityType                            = triv (fun () -> _ConstantOptionletVolatility.Value.volatilityType())
    let _businessDayConvention                     = triv (fun () -> _ConstantOptionletVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantOptionletVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantOptionletVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantOptionletVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantOptionletVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantOptionletVolatility.Value.update()
                                                                     _ConstantOptionletVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantOptionletVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantOptionletVolatility.Value.extrapolate)
    do this.Bind(_ConstantOptionletVolatility)
(* 
    casting 
*)
    internal new () = new ConstantOptionletVolatilityModel(null,null,null,null,null)
    member internal this.Inject v = _ConstantOptionletVolatility <- v
    static member Cast (p : ICell<ConstantOptionletVolatility>) = 
        if p :? ConstantOptionletVolatilityModel then 
            p :?> ConstantOptionletVolatilityModel
        else
            let o = new ConstantOptionletVolatilityModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionTime strike extrapolate   
                                                   = _blackVariance optionTime strike extrapolate 
    member this.BlackVariance1                     optionDate strike extrapolate   
                                                   = _blackVariance1 optionDate strike extrapolate 
    member this.BlackVariance2                     optionTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor strike extrapolate 
    member this.Displacement                       = _displacement
    member this.SmileSection                       optionTime extr   
                                                   = _smileSection optionTime extr 
    member this.SmileSection1                      optionTenor extr   
                                                   = _smileSection1 optionTenor extr 
    member this.SmileSection2                      optionDate extr   
                                                   = _smileSection2 optionDate extr 
    member this.Volatility                         optionTenor strike extrapolate   
                                                   = _volatility optionTenor strike extrapolate 
    member this.Volatility1                        optionDate strike extrapolate   
                                                   = _volatility1 optionDate strike extrapolate 
    member this.Volatility2                        optionTime strike extrapolate   
                                                   = _volatility2 optionTime strike extrapolate 
    member this.VolatilityType                     = _volatilityType
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
  Constant caplet volatility, no time-strike dependence
! floating reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantOptionletVolatilityModel1
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantOptionletVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantOptionletVolatility               = cell (fun () -> new ConstantOptionletVolatility (settlementDays.Value, cal.Value, bdc.Value, vol.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.minStrike())
    let _blackVariance                             (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTime.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionDate.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTenor.Value, strike.Value, extrapolate.Value))
    let _displacement                              = triv (fun () -> _ConstantOptionletVolatility.Value.displacement())
    let _smileSection                              (optionTime : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTime.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTenor.Value, extr.Value))
    let _smileSection2                             (optionDate : ICell<Date>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionDate.Value, extr.Value))
    let _volatility                                (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionDate.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTime.Value, strike.Value, extrapolate.Value))
    let _volatilityType                            = triv (fun () -> _ConstantOptionletVolatility.Value.volatilityType())
    let _businessDayConvention                     = triv (fun () -> _ConstantOptionletVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantOptionletVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantOptionletVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantOptionletVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantOptionletVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantOptionletVolatility.Value.update()
                                                                     _ConstantOptionletVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantOptionletVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantOptionletVolatility.Value.extrapolate)
    do this.Bind(_ConstantOptionletVolatility)
(* 
    casting 
*)
    internal new () = new ConstantOptionletVolatilityModel1(null,null,null,null,null)
    member internal this.Inject v = _ConstantOptionletVolatility <- v
    static member Cast (p : ICell<ConstantOptionletVolatility>) = 
        if p :? ConstantOptionletVolatilityModel1 then 
            p :?> ConstantOptionletVolatilityModel1
        else
            let o = new ConstantOptionletVolatilityModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionTime strike extrapolate   
                                                   = _blackVariance optionTime strike extrapolate 
    member this.BlackVariance1                     optionDate strike extrapolate   
                                                   = _blackVariance1 optionDate strike extrapolate 
    member this.BlackVariance2                     optionTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor strike extrapolate 
    member this.Displacement                       = _displacement
    member this.SmileSection                       optionTime extr   
                                                   = _smileSection optionTime extr 
    member this.SmileSection1                      optionTenor extr   
                                                   = _smileSection1 optionTenor extr 
    member this.SmileSection2                      optionDate extr   
                                                   = _smileSection2 optionDate extr 
    member this.Volatility                         optionTenor strike extrapolate   
                                                   = _volatility optionTenor strike extrapolate 
    member this.Volatility1                        optionDate strike extrapolate   
                                                   = _volatility1 optionDate strike extrapolate 
    member this.Volatility2                        optionTime strike extrapolate   
                                                   = _volatility2 optionTime strike extrapolate 
    member this.VolatilityType                     = _volatilityType
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
  Constant caplet volatility, no time-strike dependence
! fixed reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantOptionletVolatilityModel2
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantOptionletVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantOptionletVolatility               = cell (fun () -> new ConstantOptionletVolatility (referenceDate.Value, cal.Value, bdc.Value, vol.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.minStrike())
    let _blackVariance                             (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTime.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionDate.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTenor.Value, strike.Value, extrapolate.Value))
    let _displacement                              = triv (fun () -> _ConstantOptionletVolatility.Value.displacement())
    let _smileSection                              (optionTime : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTime.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTenor.Value, extr.Value))
    let _smileSection2                             (optionDate : ICell<Date>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionDate.Value, extr.Value))
    let _volatility                                (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionDate.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTime.Value, strike.Value, extrapolate.Value))
    let _volatilityType                            = triv (fun () -> _ConstantOptionletVolatility.Value.volatilityType())
    let _businessDayConvention                     = triv (fun () -> _ConstantOptionletVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantOptionletVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantOptionletVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantOptionletVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantOptionletVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantOptionletVolatility.Value.update()
                                                                     _ConstantOptionletVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantOptionletVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantOptionletVolatility.Value.extrapolate)
    do this.Bind(_ConstantOptionletVolatility)
(* 
    casting 
*)
    internal new () = new ConstantOptionletVolatilityModel2(null,null,null,null,null)
    member internal this.Inject v = _ConstantOptionletVolatility <- v
    static member Cast (p : ICell<ConstantOptionletVolatility>) = 
        if p :? ConstantOptionletVolatilityModel2 then 
            p :?> ConstantOptionletVolatilityModel2
        else
            let o = new ConstantOptionletVolatilityModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionTime strike extrapolate   
                                                   = _blackVariance optionTime strike extrapolate 
    member this.BlackVariance1                     optionDate strike extrapolate   
                                                   = _blackVariance1 optionDate strike extrapolate 
    member this.BlackVariance2                     optionTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor strike extrapolate 
    member this.Displacement                       = _displacement
    member this.SmileSection                       optionTime extr   
                                                   = _smileSection optionTime extr 
    member this.SmileSection1                      optionTenor extr   
                                                   = _smileSection1 optionTenor extr 
    member this.SmileSection2                      optionDate extr   
                                                   = _smileSection2 optionDate extr 
    member this.Volatility                         optionTenor strike extrapolate   
                                                   = _volatility optionTenor strike extrapolate 
    member this.Volatility1                        optionDate strike extrapolate   
                                                   = _volatility1 optionDate strike extrapolate 
    member this.Volatility2                        optionTime strike extrapolate   
                                                   = _volatility2 optionTime strike extrapolate 
    member this.VolatilityType                     = _volatilityType
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
  Constant caplet volatility, no time-strike dependence
! floating reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantOptionletVolatilityModel3
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantOptionletVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _vol                                       = vol
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantOptionletVolatility               = cell (fun () -> new ConstantOptionletVolatility (settlementDays.Value, cal.Value, bdc.Value, vol.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _ConstantOptionletVolatility.Value.minStrike())
    let _blackVariance                             (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTime.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionDate.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.blackVariance(optionTenor.Value, strike.Value, extrapolate.Value))
    let _displacement                              = triv (fun () -> _ConstantOptionletVolatility.Value.displacement())
    let _smileSection                              (optionTime : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTime.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionTenor.Value, extr.Value))
    let _smileSection2                             (optionDate : ICell<Date>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.smileSection(optionDate.Value, extr.Value))
    let _volatility                                (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionDate.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.volatility(optionTime.Value, strike.Value, extrapolate.Value))
    let _volatilityType                            = triv (fun () -> _ConstantOptionletVolatility.Value.volatilityType())
    let _businessDayConvention                     = triv (fun () -> _ConstantOptionletVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantOptionletVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantOptionletVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantOptionletVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantOptionletVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantOptionletVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantOptionletVolatility.Value.update()
                                                                     _ConstantOptionletVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantOptionletVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantOptionletVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantOptionletVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantOptionletVolatility.Value.extrapolate)
    do this.Bind(_ConstantOptionletVolatility)
(* 
    casting 
*)
    internal new () = new ConstantOptionletVolatilityModel3(null,null,null,null,null)
    member internal this.Inject v = _ConstantOptionletVolatility <- v
    static member Cast (p : ICell<ConstantOptionletVolatility>) = 
        if p :? ConstantOptionletVolatilityModel3 then 
            p :?> ConstantOptionletVolatilityModel3
        else
            let o = new ConstantOptionletVolatilityModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BlackVariance                      optionTime strike extrapolate   
                                                   = _blackVariance optionTime strike extrapolate 
    member this.BlackVariance1                     optionDate strike extrapolate   
                                                   = _blackVariance1 optionDate strike extrapolate 
    member this.BlackVariance2                     optionTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor strike extrapolate 
    member this.Displacement                       = _displacement
    member this.SmileSection                       optionTime extr   
                                                   = _smileSection optionTime extr 
    member this.SmileSection1                      optionTenor extr   
                                                   = _smileSection1 optionTenor extr 
    member this.SmileSection2                      optionDate extr   
                                                   = _smileSection2 optionDate extr 
    member this.Volatility                         optionTenor strike extrapolate   
                                                   = _volatility optionTenor strike extrapolate 
    member this.Volatility1                        optionDate strike extrapolate   
                                                   = _volatility1 optionDate strike extrapolate 
    member this.Volatility2                        optionTime strike extrapolate   
                                                   = _volatility2 optionTime strike extrapolate 
    member this.VolatilityType                     = _volatilityType
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
