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

! floating reference date, floating market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantCapFloorTermVolatilityModel
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , volatility                                   : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantCapFloorTermVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantCapFloorTermVolatility            = make (fun () -> new ConstantCapFloorTermVolatility (settlementDays.Value, cal.Value, bdc.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxDate())
    let _maxStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxStrike())
    let _minStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.minStrike())
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.calendar())
    let _dayCounter                                = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.dayCounter())
    let _maxTime                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxTime())
    let _referenceDate                             = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.referenceDate())
    let _settlementDays                            = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.update()
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _allowsExtrapolation                       = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.disableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.enableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _extrapolate                               = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.extrapolate)
    do this.Bind(_ConstantCapFloorTermVolatility)
(* 
    casting 
*)
    internal new () = new ConstantCapFloorTermVolatilityModel(null,null,null,null,null)
    member internal this.Inject v = _ConstantCapFloorTermVolatility <- v
    static member Cast (p : ICell<ConstantCapFloorTermVolatility>) = 
        if p :? ConstantCapFloorTermVolatilityModel then 
            p :?> ConstantCapFloorTermVolatilityModel
        else
            let o = new ConstantCapFloorTermVolatilityModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
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
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
(* <summary>

fixed reference date, fixed market data
  </summary> *)
[<AutoSerializable(true)>]
type ConstantCapFloorTermVolatilityModel1
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , volatility                                   : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantCapFloorTermVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantCapFloorTermVolatility            = make (fun () -> new ConstantCapFloorTermVolatility (referenceDate.Value, cal.Value, bdc.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxDate())
    let _maxStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxStrike())
    let _minStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.minStrike())
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.calendar())
    let _dayCounter                                = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.dayCounter())
    let _maxTime                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxTime())
    let _referenceDate                             = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.referenceDate())
    let _settlementDays                            = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.update()
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _allowsExtrapolation                       = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.disableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.enableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _extrapolate                               = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.extrapolate)
    do this.Bind(_ConstantCapFloorTermVolatility)
(* 
    casting 
*)
    internal new () = new ConstantCapFloorTermVolatilityModel1(null,null,null,null,null)
    member internal this.Inject v = _ConstantCapFloorTermVolatility <- v
    static member Cast (p : ICell<ConstantCapFloorTermVolatility>) = 
        if p :? ConstantCapFloorTermVolatilityModel1 then 
            p :?> ConstantCapFloorTermVolatilityModel1
        else
            let o = new ConstantCapFloorTermVolatilityModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
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
    member this.Update                             = _update
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
type ConstantCapFloorTermVolatilityModel2
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , volatility                                   : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantCapFloorTermVolatility> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantCapFloorTermVolatility            = make (fun () -> new ConstantCapFloorTermVolatility (settlementDays.Value, cal.Value, bdc.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxDate())
    let _maxStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxStrike())
    let _minStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.minStrike())
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.calendar())
    let _dayCounter                                = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.dayCounter())
    let _maxTime                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxTime())
    let _referenceDate                             = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.referenceDate())
    let _settlementDays                            = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.update()
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _allowsExtrapolation                       = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.disableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.enableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _extrapolate                               = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.extrapolate)
    do this.Bind(_ConstantCapFloorTermVolatility)
(* 
    casting 
*)
    internal new () = new ConstantCapFloorTermVolatilityModel2(null,null,null,null,null)
    member internal this.Inject v = _ConstantCapFloorTermVolatility <- v
    static member Cast (p : ICell<ConstantCapFloorTermVolatility>) = 
        if p :? ConstantCapFloorTermVolatilityModel2 then 
            p :?> ConstantCapFloorTermVolatilityModel2
        else
            let o = new ConstantCapFloorTermVolatilityModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
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
    member this.Update                             = _update
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
type ConstantCapFloorTermVolatilityModel3
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , bdc                                          : ICell<BusinessDayConvention>
    , volatility                                   : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<ConstantCapFloorTermVolatility> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _bdc                                       = bdc
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _ConstantCapFloorTermVolatility            = make (fun () -> new ConstantCapFloorTermVolatility (referenceDate.Value, cal.Value, bdc.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxDate())
    let _maxStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxStrike())
    let _minStrike                                 = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.minStrike())
    let _volatility                                (length : ICell<Period>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(length.Value, strike.Value, extrapolate.Value))
    let _volatility1                               (t : ICell<double>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(t.Value, strike.Value, extrapolate.Value))
    let _volatility2                               (End : ICell<Date>) (strike : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.volatility(End.Value, strike.Value, extrapolate.Value))
    let _businessDayConvention                     = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.calendar())
    let _dayCounter                                = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.dayCounter())
    let _maxTime                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.maxTime())
    let _referenceDate                             = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.referenceDate())
    let _settlementDays                            = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.timeFromReference(date.Value))
    let _update                                    = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.update()
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _allowsExtrapolation                       = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.disableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.enableExtrapolation(b.Value)
                                                                                                     _ConstantCapFloorTermVolatility.Value)
    let _extrapolate                               = triv _ConstantCapFloorTermVolatility (fun () -> _ConstantCapFloorTermVolatility.Value.extrapolate)
    do this.Bind(_ConstantCapFloorTermVolatility)
(* 
    casting 
*)
    internal new () = new ConstantCapFloorTermVolatilityModel3(null,null,null,null,null)
    member internal this.Inject v = _ConstantCapFloorTermVolatility <- v
    static member Cast (p : ICell<ConstantCapFloorTermVolatility>) = 
        if p :? ConstantCapFloorTermVolatilityModel3 then 
            p :?> ConstantCapFloorTermVolatilityModel3
        else
            let o = new ConstantCapFloorTermVolatilityModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.bdc                                = _bdc 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
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
    member this.Update                             = _update
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
