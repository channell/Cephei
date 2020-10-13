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
  This class implements the LocalVolatilityTermStructure interface for a constant local volatility (no time/asset dependence).  Local volatility and Black volatility are the same when volatility is at most time dependent, so this class is basically a proxy for BlackVolatilityTermStructure.

  </summary> *)
[<AutoSerializable(true)>]
type LocalConstantVolModel
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , volatility                                   : ICell<Handle<Quote>>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<LocalConstantVol> ()
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
    let _LocalConstantVol                          = cell (fun () -> new LocalConstantVol (settlementDays.Value, calendar.Value, volatility.Value, dayCounter.Value))
    let _dayCounter                                = triv (fun () -> _LocalConstantVol.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _LocalConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _LocalConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _LocalConstantVol.Value.minStrike())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _LocalConstantVol.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _LocalConstantVol.Value.calendar())
    let _maxTime                                   = triv (fun () -> _LocalConstantVol.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _LocalConstantVol.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _LocalConstantVol.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _LocalConstantVol.Value.update()
                                                                     _LocalConstantVol.Value)
    let _allowsExtrapolation                       = triv (fun () -> _LocalConstantVol.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.disableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.enableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _extrapolate                               = triv (fun () -> _LocalConstantVol.Value.extrapolate)
    do this.Bind(_LocalConstantVol)
(* 
    casting 
*)
    internal new () = new LocalConstantVolModel(null,null,null,null)
    member internal this.Inject v = _LocalConstantVol.Value <- v
    static member Cast (p : ICell<LocalConstantVol>) = 
        if p :? LocalConstantVolModel then 
            p :?> LocalConstantVolModel
        else
            let o = new LocalConstantVolModel ()
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
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
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
(* <summary>
  This class implements the LocalVolatilityTermStructure interface for a constant local volatility (no time/asset dependence).  Local volatility and Black volatility are the same when volatility is at most time dependent, so this class is basically a proxy for BlackVolatilityTermStructure.

  </summary> *)
[<AutoSerializable(true)>]
type LocalConstantVolModel1
    ( referenceDate                                : ICell<Date>
    , volatility                                   : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<LocalConstantVol> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let _LocalConstantVol                          = cell (fun () -> new LocalConstantVol (referenceDate.Value, volatility.Value, dc.Value))
    let _dayCounter                                = triv (fun () -> _LocalConstantVol.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _LocalConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _LocalConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _LocalConstantVol.Value.minStrike())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _LocalConstantVol.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _LocalConstantVol.Value.calendar())
    let _maxTime                                   = triv (fun () -> _LocalConstantVol.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _LocalConstantVol.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _LocalConstantVol.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _LocalConstantVol.Value.update()
                                                                     _LocalConstantVol.Value)
    let _allowsExtrapolation                       = triv (fun () -> _LocalConstantVol.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.disableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.enableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _extrapolate                               = triv (fun () -> _LocalConstantVol.Value.extrapolate)
    do this.Bind(_LocalConstantVol)
(* 
    casting 
*)
    internal new () = new LocalConstantVolModel1(null,null,null)
    member internal this.Inject v = _LocalConstantVol.Value <- v
    static member Cast (p : ICell<LocalConstantVol>) = 
        if p :? LocalConstantVolModel1 then 
            p :?> LocalConstantVolModel1
        else
            let o = new LocalConstantVolModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
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
(* <summary>
  This class implements the LocalVolatilityTermStructure interface for a constant local volatility (no time/asset dependence).  Local volatility and Black volatility are the same when volatility is at most time dependent, so this class is basically a proxy for BlackVolatilityTermStructure.

  </summary> *)
[<AutoSerializable(true)>]
type LocalConstantVolModel2
    ( referenceDate                                : ICell<Date>
    , volatility                                   : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<LocalConstantVol> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let _LocalConstantVol                          = cell (fun () -> new LocalConstantVol (referenceDate.Value, volatility.Value, dc.Value))
    let _dayCounter                                = triv (fun () -> _LocalConstantVol.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _LocalConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _LocalConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _LocalConstantVol.Value.minStrike())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _LocalConstantVol.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _LocalConstantVol.Value.calendar())
    let _maxTime                                   = triv (fun () -> _LocalConstantVol.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _LocalConstantVol.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _LocalConstantVol.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _LocalConstantVol.Value.update()
                                                                     _LocalConstantVol.Value)
    let _allowsExtrapolation                       = triv (fun () -> _LocalConstantVol.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.disableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.enableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _extrapolate                               = triv (fun () -> _LocalConstantVol.Value.extrapolate)
    do this.Bind(_LocalConstantVol)
(* 
    casting 
*)
    internal new () = new LocalConstantVolModel2(null,null,null)
    member internal this.Inject v = _LocalConstantVol.Value <- v
    static member Cast (p : ICell<LocalConstantVol>) = 
        if p :? LocalConstantVolModel2 then 
            p :?> LocalConstantVolModel2
        else
            let o = new LocalConstantVolModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
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
(* <summary>
  This class implements the LocalVolatilityTermStructure interface for a constant local volatility (no time/asset dependence).  Local volatility and Black volatility are the same when volatility is at most time dependent, so this class is basically a proxy for BlackVolatilityTermStructure.

  </summary> *)
[<AutoSerializable(true)>]
type LocalConstantVolModel3
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , volatility                                   : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<LocalConstantVol> ()
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
    let _LocalConstantVol                          = cell (fun () -> new LocalConstantVol (settlementDays.Value, calendar.Value, volatility.Value, dayCounter.Value))
    let _dayCounter                                = triv (fun () -> _LocalConstantVol.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _LocalConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _LocalConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _LocalConstantVol.Value.minStrike())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _LocalConstantVol.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _LocalConstantVol.Value.calendar())
    let _maxTime                                   = triv (fun () -> _LocalConstantVol.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _LocalConstantVol.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _LocalConstantVol.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _LocalConstantVol.Value.update()
                                                                     _LocalConstantVol.Value)
    let _allowsExtrapolation                       = triv (fun () -> _LocalConstantVol.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.disableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalConstantVol.Value.enableExtrapolation(b.Value)
                                                                     _LocalConstantVol.Value)
    let _extrapolate                               = triv (fun () -> _LocalConstantVol.Value.extrapolate)
    do this.Bind(_LocalConstantVol)
(* 
    casting 
*)
    internal new () = new LocalConstantVolModel3(null,null,null,null)
    member internal this.Inject v = _LocalConstantVol.Value <- v
    static member Cast (p : ICell<LocalConstantVol>) = 
        if p :? LocalConstantVolModel3 then 
            p :?> LocalConstantVolModel3
        else
            let o = new LocalConstantVolModel3 ()
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
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
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
