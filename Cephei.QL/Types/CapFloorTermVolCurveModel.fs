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
  This class provides the at-the-money volatility for a given cap/floor interpolating a volatility vector whose elements are the market volatilities of a set of caps/floors with given length.
! floating reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolCurveModel
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , vols                                         : ICell<Generic.List<Handle<Quote>>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolCurve> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolCurve                      = cell (fun () -> new CapFloorTermVolCurve (settlementDays.Value, calendar.Value, bdc.Value, optionTenors.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolCurve.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionTimes())
    let _update                                    = cell (fun () -> _CapFloorTermVolCurve.Value.update()
                                                                     _CapFloorTermVolCurve.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolCurve.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolCurve.Value.extrapolate)
    do this.Bind(_CapFloorTermVolCurve)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Update                             = _update
    member this.Volatility                         length strike extrapolate   
                                                   = _volatility length strike extrapolate 
    member this.Volatility1                        t strike extrapolate   
                                                   = _volatility1 t strike extrapolate 
    member this.Volatility2                        End strike extrapolate   
                                                   = _volatility2 End strike extrapolate 
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
  This class provides the at-the-money volatility for a given cap/floor interpolating a volatility vector whose elements are the market volatilities of a set of caps/floors with given length.
! floating reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolCurveModel1
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , vols                                         : ICell<Generic.List<double>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolCurve> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolCurve                      = cell (fun () -> new CapFloorTermVolCurve (settlementDays.Value, calendar.Value, bdc.Value, optionTenors.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolCurve.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionTimes())
    let _update                                    = cell (fun () -> _CapFloorTermVolCurve.Value.update()
                                                                     _CapFloorTermVolCurve.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolCurve.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolCurve.Value.extrapolate)
    do this.Bind(_CapFloorTermVolCurve)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Update                             = _update
    member this.Volatility                         length strike extrapolate   
                                                   = _volatility length strike extrapolate 
    member this.Volatility1                        t strike extrapolate   
                                                   = _volatility1 t strike extrapolate 
    member this.Volatility2                        End strike extrapolate   
                                                   = _volatility2 End strike extrapolate 
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
  This class provides the at-the-money volatility for a given cap/floor interpolating a volatility vector whose elements are the market volatilities of a set of caps/floors with given length.
! fixed reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolCurveModel2
    ( settlementDate                               : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , vols                                         : ICell<Generic.List<Handle<Quote>>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolCurve> ()
(*
    Parameters
*)
    let _settlementDate                            = settlementDate
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolCurve                      = cell (fun () -> new CapFloorTermVolCurve (settlementDate.Value, calendar.Value, bdc.Value, optionTenors.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolCurve.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionTimes())
    let _update                                    = cell (fun () -> _CapFloorTermVolCurve.Value.update()
                                                                     _CapFloorTermVolCurve.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolCurve.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolCurve.Value.extrapolate)
    do this.Bind(_CapFloorTermVolCurve)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDate                     = _settlementDate 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Update                             = _update
    member this.Volatility                         length strike extrapolate   
                                                   = _volatility length strike extrapolate 
    member this.Volatility1                        t strike extrapolate   
                                                   = _volatility1 t strike extrapolate 
    member this.Volatility2                        End strike extrapolate   
                                                   = _volatility2 End strike extrapolate 
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
  This class provides the at-the-money volatility for a given cap/floor interpolating a volatility vector whose elements are the market volatilities of a set of caps/floors with given length.
! fixed reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolCurveModel3
    ( settlementDate                               : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , vols                                         : ICell<Generic.List<double>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolCurve> ()
(*
    Parameters
*)
    let _settlementDate                            = settlementDate
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolCurve                      = cell (fun () -> new CapFloorTermVolCurve (settlementDate.Value, calendar.Value, bdc.Value, optionTenors.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolCurve.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolCurve.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolCurve.Value.optionTimes())
    let _update                                    = cell (fun () -> _CapFloorTermVolCurve.Value.update()
                                                                     _CapFloorTermVolCurve.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolCurve.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolCurve.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolCurve.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolCurve.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolCurve.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolCurve.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolCurve.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolCurve.Value.extrapolate)
    do this.Bind(_CapFloorTermVolCurve)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDate                     = _settlementDate 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Update                             = _update
    member this.Volatility                         length strike extrapolate   
                                                   = _volatility length strike extrapolate 
    member this.Volatility1                        t strike extrapolate   
                                                   = _volatility1 t strike extrapolate 
    member this.Volatility2                        End strike extrapolate   
                                                   = _volatility2 End strike extrapolate 
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
