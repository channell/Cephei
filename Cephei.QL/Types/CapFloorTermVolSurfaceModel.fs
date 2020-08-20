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

! fixed reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolSurfaceModel
    ( settlementDate                               : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , strikes                                      : ICell<Generic.List<double>>
    , vols                                         : ICell<Matrix>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolSurface> ()
(*
    Parameters
*)
    let _settlementDate                            = settlementDate
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _strikes                                   = strikes
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolSurface                    = cell (fun () -> new CapFloorTermVolSurface (settlementDate.Value, calendar.Value, bdc.Value, optionTenors.Value, strikes.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolSurface.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionTimes())
    let _strikes                                   = cell (fun () -> _CapFloorTermVolSurface.Value.strikes())
    let _update                                    = cell (fun () -> _CapFloorTermVolSurface.Value.update()
                                                                     _CapFloorTermVolSurface.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolSurface.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolSurface.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolSurface.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolSurface.Value.extrapolate)
    do this.Bind(_CapFloorTermVolSurface)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDate                     = _settlementDate 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.strikes                            = _strikes 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Strikes                            = _strikes
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

! fixed reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolSurfaceModel1
    ( settlementDate                               : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , strikes                                      : ICell<Generic.List<double>>
    , vols                                         : ICell<Generic.List<Generic.List<Handle<Quote>>>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolSurface> ()
(*
    Parameters
*)
    let _settlementDate                            = settlementDate
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _strikes                                   = strikes
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolSurface                    = cell (fun () -> new CapFloorTermVolSurface (settlementDate.Value, calendar.Value, bdc.Value, optionTenors.Value, strikes.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolSurface.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionTimes())
    let _strikes                                   = cell (fun () -> _CapFloorTermVolSurface.Value.strikes())
    let _update                                    = cell (fun () -> _CapFloorTermVolSurface.Value.update()
                                                                     _CapFloorTermVolSurface.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolSurface.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolSurface.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolSurface.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolSurface.Value.extrapolate)
    do this.Bind(_CapFloorTermVolSurface)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDate                     = _settlementDate 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.strikes                            = _strikes 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Strikes                            = _strikes
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

! floating reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolSurfaceModel2
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , strikes                                      : ICell<Generic.List<double>>
    , vols                                         : ICell<Generic.List<Generic.List<Handle<Quote>>>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolSurface> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _strikes                                   = strikes
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolSurface                    = cell (fun () -> new CapFloorTermVolSurface (settlementDays.Value, calendar.Value, bdc.Value, optionTenors.Value, strikes.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolSurface.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionTimes())
    let _strikes                                   = cell (fun () -> _CapFloorTermVolSurface.Value.strikes())
    let _update                                    = cell (fun () -> _CapFloorTermVolSurface.Value.update()
                                                                     _CapFloorTermVolSurface.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolSurface.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolSurface.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolSurface.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolSurface.Value.extrapolate)
    do this.Bind(_CapFloorTermVolSurface)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.strikes                            = _strikes 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Strikes                            = _strikes
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

! floating reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type CapFloorTermVolSurfaceModel3
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , optionTenors                                 : ICell<Generic.List<Period>>
    , strikes                                      : ICell<Generic.List<double>>
    , vols                                         : ICell<Matrix>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<CapFloorTermVolSurface> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _bdc                                       = bdc
    let _optionTenors                              = optionTenors
    let _strikes                                   = strikes
    let _vols                                      = vols
    let _dc                                        = dc
(*
    Functions
*)
    let _CapFloorTermVolSurface                    = cell (fun () -> new CapFloorTermVolSurface (settlementDays.Value, calendar.Value, bdc.Value, optionTenors.Value, strikes.Value, vols.Value, dc.Value))
    let _maxDate                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxDate())
    let _maxStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.maxStrike())
    let _minStrike                                 = cell (fun () -> _CapFloorTermVolSurface.Value.minStrike())
    let _optionDates                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionDates())
    let _optionTenors                              = cell (fun () -> _CapFloorTermVolSurface.Value.optionTenors())
    let _optionTimes                               = cell (fun () -> _CapFloorTermVolSurface.Value.optionTimes())
    let _strikes                                   = cell (fun () -> _CapFloorTermVolSurface.Value.strikes())
    let _update                                    = cell (fun () -> _CapFloorTermVolSurface.Value.update()
                                                                     _CapFloorTermVolSurface.Value)
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = cell (fun () -> _CapFloorTermVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = cell (fun () -> _CapFloorTermVolSurface.Value.calendar())
    let _dayCounter                                = cell (fun () -> _CapFloorTermVolSurface.Value.dayCounter())
    let _maxTime                                   = cell (fun () -> _CapFloorTermVolSurface.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _CapFloorTermVolSurface.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _CapFloorTermVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _CapFloorTermVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _CapFloorTermVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _CapFloorTermVolSurface.Value)
    let _extrapolate                               = cell (fun () -> _CapFloorTermVolSurface.Value.extrapolate)
    do this.Bind(_CapFloorTermVolSurface)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.bdc                                = _bdc 
    member this.optionTenors                       = _optionTenors 
    member this.strikes                            = _strikes 
    member this.vols                               = _vols 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.OptionDates                        = _optionDates
    member this.OptionTenors                       = _optionTenors
    member this.OptionTimes                        = _optionTimes
    member this.Strikes                            = _strikes
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
