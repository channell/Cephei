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

! Adapter class for turning a StrippedOptionletBase object into an OptionletVolatilityStructure.
  </summary> *)
[<AutoSerializable(true)>]
type StrippedOptionletAdapterModel
    ( s                                            : ICell<StrippedOptionletBase>
    ) as this =

    inherit Model<StrippedOptionletAdapter> ()
(*
    Parameters
*)
    let _s                                         = s
(*
    Functions
*)
    let _StrippedOptionletAdapter                  = cell (fun () -> new StrippedOptionletAdapter (s.Value))
    let _displacement                              = cell (fun () -> _StrippedOptionletAdapter.Value.displacement())
    let _maxDate                                   = cell (fun () -> _StrippedOptionletAdapter.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _StrippedOptionletAdapter.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _StrippedOptionletAdapter.Value.minStrike())
    let _update                                    = cell (fun () -> _StrippedOptionletAdapter.Value.update()
                                                                     _StrippedOptionletAdapter.Value)
    let _volatilityType                            = cell (fun () -> _StrippedOptionletAdapter.Value.volatilityType())
    let _blackVariance                             (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.blackVariance(optionTime.Value, strike.Value, extrapolate.Value))
    let _blackVariance1                            (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.blackVariance(optionDate.Value, strike.Value, extrapolate.Value))
    let _blackVariance2                            (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.blackVariance(optionTenor.Value, strike.Value, extrapolate.Value))
    let _smileSection                              (optionTime : ICell<double>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.smileSection(optionTime.Value, extr.Value))
    let _smileSection1                             (optionTenor : ICell<Period>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.smileSection(optionTenor.Value, extr.Value))
    let _smileSection2                             (optionDate : ICell<Date>) (extr : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.smileSection(optionDate.Value, extr.Value))
    let _volatility                                (optionTenor : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.volatility(optionTenor.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (optionDate : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.volatility(optionDate.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (optionTime : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.volatility(optionTime.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _StrippedOptionletAdapter.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _StrippedOptionletAdapter.Value.calendar())
    let _dayCounter                                = cell (fun () -> _StrippedOptionletAdapter.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _StrippedOptionletAdapter.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _StrippedOptionletAdapter.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _StrippedOptionletAdapter.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _StrippedOptionletAdapter.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.disableExtrapolation(b.Value)
                                                                     _StrippedOptionletAdapter.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _StrippedOptionletAdapter.Value.enableExtrapolation(b.Value)
                                                                     _StrippedOptionletAdapter.Value)
    let _extrapolate                               = cell (fun () -> _StrippedOptionletAdapter.Value.extrapolate)
    do this.Bind(_StrippedOptionletAdapter)

(* 
    Externally visible/bindable properties
*)
    member this.s                                  = _s 
    member this.Displacement                       = _displacement
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Update                             = _update
    member this.VolatilityType                     = _volatilityType
    member this.BlackVariance                      optionTime strike extrapolate   
                                                   = _blackVariance optionTime strike extrapolate 
    member this.BlackVariance1                     optionDate strike extrapolate   
                                                   = _blackVariance1 optionDate strike extrapolate 
    member this.BlackVariance2                     optionTenor strike extrapolate   
                                                   = _blackVariance2 optionTenor strike extrapolate 
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
