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
  Constant surface, no K or T dependence.
Constructor ! calculate the reference date based on the global evaluation date
  </summary> *)
[<AutoSerializable(true)>]
type ConstantYoYOptionletVolatilityModel
    ( v                                            : ICell<double>
    , settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , dc                                           : ICell<DayCounter>
    , observationLag                               : ICell<Period>
    , frequency                                    : ICell<Frequency>
    , indexIsInterpolated                          : ICell<bool>
    , minStrike                                    : ICell<double>
    , maxStrike                                    : ICell<double>
    ) as this =

    inherit Model<ConstantYoYOptionletVolatility> ()
(*
    Parameters
*)
    let _v                                         = v
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _dc                                        = dc
    let _observationLag                            = observationLag
    let _frequency                                 = frequency
    let _indexIsInterpolated                       = indexIsInterpolated
    let _minStrike                                 = minStrike
    let _maxStrike                                 = maxStrike
(*
    Functions
*)
    let _ConstantYoYOptionletVolatility            = cell (fun () -> new ConstantYoYOptionletVolatility (v.Value, settlementDays.Value, cal.Value, bdc.Value, dc.Value, observationLag.Value, frequency.Value, indexIsInterpolated.Value, minStrike.Value, maxStrike.Value))
    let _maxDate                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _ConstantYoYOptionletVolatility.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _ConstantYoYOptionletVolatility.Value.minStrike())
    let _baseDate                                  = triv (fun () -> _ConstantYoYOptionletVolatility.Value.baseDate())
    let _baseLevel                                 = triv (fun () -> _ConstantYoYOptionletVolatility.Value.baseLevel())
    let _frequency                                 = triv (fun () -> _ConstantYoYOptionletVolatility.Value.frequency())
    let _indexIsInterpolated                       = triv (fun () -> _ConstantYoYOptionletVolatility.Value.indexIsInterpolated())
    let _observationLag                            = triv (fun () -> _ConstantYoYOptionletVolatility.Value.observationLag())
    let _timeFromBase                              (maturityDate : ICell<Date>) (obsLag : ICell<Period>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.timeFromBase(maturityDate.Value, obsLag.Value))
    let _timeFromBase1                             (maturityDate : ICell<Date>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.timeFromBase(maturityDate.Value))
    let _totalVariance                             (maturityDate : ICell<Date>) (strike : ICell<double>) (obsLag : ICell<Period>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.totalVariance(maturityDate.Value, strike.Value, obsLag.Value))
    let _totalVariance1                            (maturityDate : ICell<Date>) (strike : ICell<double>) (obsLag : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.totalVariance(maturityDate.Value, strike.Value, obsLag.Value, extrapolate.Value))
    let _totalVariance2                            (tenor : ICell<Period>) (strike : ICell<double>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.totalVariance(tenor.Value, strike.Value))
    let _totalVariance3                            (tenor : ICell<Period>) (strike : ICell<double>) (obsLag : ICell<Period>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.totalVariance(tenor.Value, strike.Value, obsLag.Value))
    let _totalVariance4                            (tenor : ICell<Period>) (strike : ICell<double>) (obsLag : ICell<Period>) (extrap : ICell<bool>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.totalVariance(tenor.Value, strike.Value, obsLag.Value, extrap.Value))
    let _totalVariance5                            (maturityDate : ICell<Date>) (strike : ICell<double>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.totalVariance(maturityDate.Value, strike.Value))
    let _volatility                                (maturityDate : ICell<Date>) (strike : ICell<double>) (obsLag : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.volatility(maturityDate.Value, strike.Value, obsLag.Value, extrapolate.Value))
    let _volatility1                               (optionTenor : ICell<Period>) (strike : ICell<double>) (obsLag : ICell<Period>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value, obsLag.Value))
    let _volatility2                               (maturityDate : ICell<Date>) (strike : ICell<double>) (obsLag : ICell<Period>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.volatility(maturityDate.Value, strike.Value, obsLag.Value))
    let _volatility3                               (optionTenor : ICell<Period>) (strike : ICell<double>) (obsLag : ICell<Period>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value, obsLag.Value, extrapolate.Value))
    let _volatility4                               (maturityDate : ICell<Date>) (strike : ICell<double>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.volatility(maturityDate.Value, strike.Value))
    let _volatility5                               (optionTenor : ICell<Period>) (strike : ICell<double>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value))
    let _businessDayConvention                     = triv (fun () -> _ConstantYoYOptionletVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _ConstantYoYOptionletVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _ConstantYoYOptionletVolatility.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _ConstantYoYOptionletVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _ConstantYoYOptionletVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _ConstantYoYOptionletVolatility.Value.update()
                                                                     _ConstantYoYOptionletVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _ConstantYoYOptionletVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.disableExtrapolation(b.Value)
                                                                     _ConstantYoYOptionletVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConstantYoYOptionletVolatility.Value.enableExtrapolation(b.Value)
                                                                     _ConstantYoYOptionletVolatility.Value)
    let _extrapolate                               = triv (fun () -> _ConstantYoYOptionletVolatility.Value.extrapolate)
    do this.Bind(_ConstantYoYOptionletVolatility)

(* 
    Externally visible/bindable properties
*)
    member this.v                                  = _v 
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.dc                                 = _dc 
    member this.observationLag                     = _observationLag 
    member this.frequency                          = _frequency 
    member this.indexIsInterpolated                = _indexIsInterpolated 
    member this.minStrike                          = _minStrike 
    member this.maxStrike                          = _maxStrike 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.BaseDate                           = _baseDate
    member this.BaseLevel                          = _baseLevel
    member this.Frequency                          = _frequency
    member this.IndexIsInterpolated                = _indexIsInterpolated
    member this.ObservationLag                     = _observationLag
    member this.TimeFromBase                       maturityDate obsLag   
                                                   = _timeFromBase maturityDate obsLag 
    member this.TimeFromBase1                      maturityDate   
                                                   = _timeFromBase1 maturityDate 
    member this.TotalVariance                      maturityDate strike obsLag   
                                                   = _totalVariance maturityDate strike obsLag 
    member this.TotalVariance1                     maturityDate strike obsLag extrapolate   
                                                   = _totalVariance1 maturityDate strike obsLag extrapolate 
    member this.TotalVariance2                     tenor strike   
                                                   = _totalVariance2 tenor strike 
    member this.TotalVariance3                     tenor strike obsLag   
                                                   = _totalVariance3 tenor strike obsLag 
    member this.TotalVariance4                     tenor strike obsLag extrap   
                                                   = _totalVariance4 tenor strike obsLag extrap 
    member this.TotalVariance5                     maturityDate strike   
                                                   = _totalVariance5 maturityDate strike 
    member this.Volatility                         maturityDate strike obsLag extrapolate   
                                                   = _volatility maturityDate strike obsLag extrapolate 
    member this.Volatility1                        optionTenor strike obsLag   
                                                   = _volatility1 optionTenor strike obsLag 
    member this.Volatility2                        maturityDate strike obsLag   
                                                   = _volatility2 maturityDate strike obsLag 
    member this.Volatility3                        optionTenor strike obsLag extrapolate   
                                                   = _volatility3 optionTenor strike obsLag extrapolate 
    member this.Volatility4                        maturityDate strike   
                                                   = _volatility4 maturityDate strike 
    member this.Volatility5                        optionTenor strike   
                                                   = _volatility5 optionTenor strike 
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
