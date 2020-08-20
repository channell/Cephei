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
type NoExceptLocalVolSurfaceModel
    ( blackTS                                      : ICell<Handle<BlackVolTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , underlying                                   : ICell<double>
    , illegalLocalVolOverwrite                     : ICell<double>
    ) as this =

    inherit Model<NoExceptLocalVolSurface> ()
(*
    Parameters
*)
    let _blackTS                                   = blackTS
    let _riskFreeTS                                = riskFreeTS
    let _dividendTS                                = dividendTS
    let _underlying                                = underlying
    let _illegalLocalVolOverwrite                  = illegalLocalVolOverwrite
(*
    Functions
*)
    let _NoExceptLocalVolSurface                   = cell (fun () -> new NoExceptLocalVolSurface (blackTS.Value, riskFreeTS.Value, dividendTS.Value, underlying.Value, illegalLocalVolOverwrite.Value))
    let _dayCounter                                = cell (fun () -> _NoExceptLocalVolSurface.Value.dayCounter())
    let _maxDate                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _NoExceptLocalVolSurface.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _NoExceptLocalVolSurface.Value.minStrike())
    let _referenceDate                             = cell (fun () -> _NoExceptLocalVolSurface.Value.referenceDate())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _NoExceptLocalVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _NoExceptLocalVolSurface.Value.calendar())
    let _maxTime                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.maxTime())
    let _settlementDays                            = cell (fun () -> _NoExceptLocalVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = cell (fun () -> _NoExceptLocalVolSurface.Value.update()
                                                                     _NoExceptLocalVolSurface.Value)
    let _allowsExtrapolation                       = cell (fun () -> _NoExceptLocalVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _NoExceptLocalVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _NoExceptLocalVolSurface.Value)
    let _extrapolate                               = cell (fun () -> _NoExceptLocalVolSurface.Value.extrapolate)
    do this.Bind(_NoExceptLocalVolSurface)

(* 
    Externally visible/bindable properties
*)
    member this.blackTS                            = _blackTS 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.dividendTS                         = _dividendTS 
    member this.underlying                         = _underlying 
    member this.illegalLocalVolOverwrite           = _illegalLocalVolOverwrite 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.MaxTime                            = _maxTime
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


  </summary> *)
[<AutoSerializable(true)>]
type NoExceptLocalVolSurfaceModel1
    ( blackTS                                      : ICell<Handle<BlackVolTermStructure>>
    , riskFreeTS                                   : ICell<Handle<YieldTermStructure>>
    , dividendTS                                   : ICell<Handle<YieldTermStructure>>
    , underlying                                   : ICell<Handle<Quote>>
    , illegalLocalVolOverwrite                     : ICell<double>
    ) as this =

    inherit Model<NoExceptLocalVolSurface> ()
(*
    Parameters
*)
    let _blackTS                                   = blackTS
    let _riskFreeTS                                = riskFreeTS
    let _dividendTS                                = dividendTS
    let _underlying                                = underlying
    let _illegalLocalVolOverwrite                  = illegalLocalVolOverwrite
(*
    Functions
*)
    let _NoExceptLocalVolSurface                   = cell (fun () -> new NoExceptLocalVolSurface (blackTS.Value, riskFreeTS.Value, dividendTS.Value, underlying.Value, illegalLocalVolOverwrite.Value))
    let _dayCounter                                = cell (fun () -> _NoExceptLocalVolSurface.Value.dayCounter())
    let _maxDate                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _NoExceptLocalVolSurface.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _NoExceptLocalVolSurface.Value.minStrike())
    let _referenceDate                             = cell (fun () -> _NoExceptLocalVolSurface.Value.referenceDate())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _NoExceptLocalVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _NoExceptLocalVolSurface.Value.calendar())
    let _maxTime                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.maxTime())
    let _settlementDays                            = cell (fun () -> _NoExceptLocalVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = cell (fun () -> _NoExceptLocalVolSurface.Value.update()
                                                                     _NoExceptLocalVolSurface.Value)
    let _allowsExtrapolation                       = cell (fun () -> _NoExceptLocalVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _NoExceptLocalVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _NoExceptLocalVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _NoExceptLocalVolSurface.Value)
    let _extrapolate                               = cell (fun () -> _NoExceptLocalVolSurface.Value.extrapolate)
    do this.Bind(_NoExceptLocalVolSurface)

(* 
    Externally visible/bindable properties
*)
    member this.blackTS                            = _blackTS 
    member this.riskFreeTS                         = _riskFreeTS 
    member this.dividendTS                         = _dividendTS 
    member this.underlying                         = _underlying 
    member this.illegalLocalVolOverwrite           = _illegalLocalVolOverwrite 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.MaxTime                            = _maxTime
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
