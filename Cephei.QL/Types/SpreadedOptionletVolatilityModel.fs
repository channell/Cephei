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
type SpreadedOptionletVolatilityModel
    ( baseVol                                      : ICell<Handle<OptionletVolatilityStructure>>
    , spread                                       : ICell<Handle<Quote>>
    ) as this =

    inherit Model<SpreadedOptionletVolatility> ()
(*
    Parameters
*)
    let _baseVol                                   = baseVol
    let _spread                                    = spread
(*
    Functions
*)
    let _SpreadedOptionletVolatility               = cell (fun () -> new SpreadedOptionletVolatility (baseVol.Value, spread.Value))
    let _businessDayConvention                     = triv (fun () -> _SpreadedOptionletVolatility.Value.businessDayConvention())
    let _calendar                                  = triv (fun () -> _SpreadedOptionletVolatility.Value.calendar())
    let _dayCounter                                = triv (fun () -> _SpreadedOptionletVolatility.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _SpreadedOptionletVolatility.Value.maxStrike())
    let _maxTime                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.maxTime())
    let _minStrike                                 = triv (fun () -> _SpreadedOptionletVolatility.Value.minStrike())
    let _referenceDate                             = triv (fun () -> _SpreadedOptionletVolatility.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _SpreadedOptionletVolatility.Value.settlementDays())
    let _blackVariance                             (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.blackVariance(optionTime.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.blackVariance(optionDate.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.blackVariance(optionTenor.Value, strike.Value, extrapolate.Value))
    let _displacement                              = triv (fun () -> _SpreadedOptionletVolatility.Value.displacement())
    let _smileSection                              (optionTime : ICell<double>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.smileSection(optionTime.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.smileSection(optionTenor.Value, extr.Value))
    let _smileSection2                             (optionDate : ICell<Date>) (extr : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.smileSection(optionDate.Value, extr.Value))
    let _volatility                                (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.volatility(optionTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.volatility(optionDate.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.volatility(optionTime.Value, strike.Value, extrapolate.Value))
    let _volatilityType                            = triv (fun () -> _SpreadedOptionletVolatility.Value.volatilityType())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.optionDateFromTenor(p.Value))
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _SpreadedOptionletVolatility.Value.update()
                                                                     _SpreadedOptionletVolatility.Value)
    let _allowsExtrapolation                       = triv (fun () -> _SpreadedOptionletVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.disableExtrapolation(b.Value)
                                                                     _SpreadedOptionletVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _SpreadedOptionletVolatility.Value.enableExtrapolation(b.Value)
                                                                     _SpreadedOptionletVolatility.Value)
    let _extrapolate                               = triv (fun () -> _SpreadedOptionletVolatility.Value.extrapolate)
    do this.Bind(_SpreadedOptionletVolatility)
(* 
    casting 
*)
    internal new () = SpreadedOptionletVolatilityModel(null,null)
    member internal this.Inject v = _SpreadedOptionletVolatility.Value <- v
    static member Cast (p : ICell<SpreadedOptionletVolatility>) = 
        if p :? SpreadedOptionletVolatilityModel then 
            p :?> SpreadedOptionletVolatilityModel
        else
            let o = new SpreadedOptionletVolatilityModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.baseVol                            = _baseVol 
    member this.spread                             = _spread 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxTime                            = _maxTime
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
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
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
