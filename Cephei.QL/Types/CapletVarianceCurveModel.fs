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
type CapletVarianceCurveModel
    ( referenceDate                                : ICell<Date>
    , dates                                        : ICell<Generic.List<Date>>
    , capletVolCurve                               : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<CapletVarianceCurve> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _dates                                     = dates
    let _capletVolCurve                            = capletVolCurve
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _CapletVarianceCurve                       = cell (fun () -> new CapletVarianceCurve (referenceDate.Value, dates.Value, capletVolCurve.Value, dayCounter.Value))
    let _dayCounter                                = triv (fun () -> _CapletVarianceCurve.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _CapletVarianceCurve.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _CapletVarianceCurve.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _CapletVarianceCurve.Value.minStrike())
    let _blackVariance                             (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.blackVariance(optionTime.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.blackVariance(optionDate.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.blackVariance(optionTenor.Value, strike.Value, extrapolate.Value))
    let _displacement                              = triv (fun () -> _CapletVarianceCurve.Value.displacement())
    let _smileSection                              (optionTime : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.smileSection(optionTime.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.smileSection(optionTenor.Value, extr.Value))
    let _smileSection2                             (optionDate : ICell<Date>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.smileSection(optionDate.Value, extr.Value))
    let _volatility                                (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.volatility(optionTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.volatility(optionDate.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.volatility(optionTime.Value, strike.Value, extrapolate.Value))
    let _volatilityType                            = triv (fun () -> _CapletVarianceCurve.Value.volatilityType())
    let _businessDayConvention                     = triv (fun () -> _CapletVarianceCurve.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _CapletVarianceCurve.Value.calendar())
    let _maxTime                                   = triv (fun () -> _CapletVarianceCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _CapletVarianceCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _CapletVarianceCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _CapletVarianceCurve.Value.update()
                                                                     _CapletVarianceCurve.Value)
    let _allowsExtrapolation                       = triv (fun () -> _CapletVarianceCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.disableExtrapolation(b.Value)
                                                                     _CapletVarianceCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _CapletVarianceCurve.Value.enableExtrapolation(b.Value)
                                                                     _CapletVarianceCurve.Value)
    let _extrapolate                               = triv (fun () -> _CapletVarianceCurve.Value.extrapolate)
    do this.Bind(_CapletVarianceCurve)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.dates                              = _dates 
    member this.capletVolCurve                     = _capletVolCurve 
    member this.dayCounter                         = _dayCounter 
    member this.DayCounter                         = _dayCounter
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
