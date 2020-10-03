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
type FixedLocalVolSurfaceModel
    ( referenceDate                                : ICell<Date>
    , times                                        : ICell<Generic.List<double>>
    , strikes                                      : ICell<Generic.List<Generic.List<double>>>
    , localVolMatrix                               : ICell<Matrix>
    , dayCounter                                   : ICell<DayCounter>
    , lowerExtrapolation                           : ICell<FixedLocalVolSurface.Extrapolation>
    , upperExtrapolation                           : ICell<FixedLocalVolSurface.Extrapolation>
    ) as this =

    inherit Model<FixedLocalVolSurface> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _times                                     = times
    let _strikes                                   = strikes
    let _localVolMatrix                            = localVolMatrix
    let _dayCounter                                = dayCounter
    let _lowerExtrapolation                        = lowerExtrapolation
    let _upperExtrapolation                        = upperExtrapolation
(*
    Functions
*)
    let _FixedLocalVolSurface                      = cell (fun () -> new FixedLocalVolSurface (referenceDate.Value, times.Value, strikes.Value, localVolMatrix.Value, dayCounter.Value, lowerExtrapolation.Value, upperExtrapolation.Value))
    let _maxDate                                   = triv (fun () -> _FixedLocalVolSurface.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _FixedLocalVolSurface.Value.maxStrike())
    let _maxTime                                   = triv (fun () -> _FixedLocalVolSurface.Value.maxTime())
    let _minStrike                                 = triv (fun () -> _FixedLocalVolSurface.Value.minStrike())
    let _setInterpolation                          (i : ICell<'Interpolator>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.setInterpolation(i.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _FixedLocalVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _FixedLocalVolSurface.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FixedLocalVolSurface.Value.dayCounter())
    let _referenceDate                             = triv (fun () -> _FixedLocalVolSurface.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FixedLocalVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _FixedLocalVolSurface.Value.update()
                                                                     _FixedLocalVolSurface.Value)
    let _allowsExtrapolation                       = triv (fun () -> _FixedLocalVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _extrapolate                               = triv (fun () -> _FixedLocalVolSurface.Value.extrapolate)
    do this.Bind(_FixedLocalVolSurface)
(* 
    casting 
*)
    internal new () = FixedLocalVolSurfaceModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedLocalVolSurface.Value <- v
    static member Cast (p : ICell<FixedLocalVolSurface>) = 
        if p :? FixedLocalVolSurfaceModel then 
            p :?> FixedLocalVolSurfaceModel
        else
            let o = new FixedLocalVolSurfaceModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.times                              = _times 
    member this.strikes                            = _strikes 
    member this.localVolMatrix                     = _localVolMatrix 
    member this.dayCounter                         = _dayCounter 
    member this.lowerExtrapolation                 = _lowerExtrapolation 
    member this.upperExtrapolation                 = _upperExtrapolation 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxTime                            = _maxTime
    member this.MinStrike                          = _minStrike
    member this.SetInterpolation                   i   
                                                   = _setInterpolation i 
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
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


  </summary> *)
[<AutoSerializable(true)>]
type FixedLocalVolSurfaceModel1
    ( referenceDate                                : ICell<Date>
    , times                                        : ICell<Generic.List<double>>
    , strikes                                      : ICell<Generic.List<double>>
    , localVolMatrix                               : ICell<Matrix>
    , dayCounter                                   : ICell<DayCounter>
    , lowerExtrapolation                           : ICell<FixedLocalVolSurface.Extrapolation>
    , upperExtrapolation                           : ICell<FixedLocalVolSurface.Extrapolation>
    ) as this =

    inherit Model<FixedLocalVolSurface> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _times                                     = times
    let _strikes                                   = strikes
    let _localVolMatrix                            = localVolMatrix
    let _dayCounter                                = dayCounter
    let _lowerExtrapolation                        = lowerExtrapolation
    let _upperExtrapolation                        = upperExtrapolation
(*
    Functions
*)
    let _FixedLocalVolSurface                      = cell (fun () -> new FixedLocalVolSurface (referenceDate.Value, times.Value, strikes.Value, localVolMatrix.Value, dayCounter.Value, lowerExtrapolation.Value, upperExtrapolation.Value))
    let _maxDate                                   = triv (fun () -> _FixedLocalVolSurface.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _FixedLocalVolSurface.Value.maxStrike())
    let _maxTime                                   = triv (fun () -> _FixedLocalVolSurface.Value.maxTime())
    let _minStrike                                 = triv (fun () -> _FixedLocalVolSurface.Value.minStrike())
    let _setInterpolation                          (i : ICell<'Interpolator>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.setInterpolation(i.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _FixedLocalVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _FixedLocalVolSurface.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FixedLocalVolSurface.Value.dayCounter())
    let _referenceDate                             = triv (fun () -> _FixedLocalVolSurface.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FixedLocalVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _FixedLocalVolSurface.Value.update()
                                                                     _FixedLocalVolSurface.Value)
    let _allowsExtrapolation                       = triv (fun () -> _FixedLocalVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _extrapolate                               = triv (fun () -> _FixedLocalVolSurface.Value.extrapolate)
    do this.Bind(_FixedLocalVolSurface)
(* 
    casting 
*)
    internal new () = FixedLocalVolSurfaceModel1(null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedLocalVolSurface.Value <- v
    static member Cast (p : ICell<FixedLocalVolSurface>) = 
        if p :? FixedLocalVolSurfaceModel1 then 
            p :?> FixedLocalVolSurfaceModel1
        else
            let o = new FixedLocalVolSurfaceModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.times                              = _times 
    member this.strikes                            = _strikes 
    member this.localVolMatrix                     = _localVolMatrix 
    member this.dayCounter                         = _dayCounter 
    member this.lowerExtrapolation                 = _lowerExtrapolation 
    member this.upperExtrapolation                 = _upperExtrapolation 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxTime                            = _maxTime
    member this.MinStrike                          = _minStrike
    member this.SetInterpolation                   i   
                                                   = _setInterpolation i 
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
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


  </summary> *)
[<AutoSerializable(true)>]
type FixedLocalVolSurfaceModel2
    ( referenceDate                                : ICell<Date>
    , dates                                        : ICell<Generic.List<Date>>
    , strikes                                      : ICell<Generic.List<double>>
    , localVolMatrix                               : ICell<Matrix>
    , dayCounter                                   : ICell<DayCounter>
    , lowerExtrapolation                           : ICell<FixedLocalVolSurface.Extrapolation>
    , upperExtrapolation                           : ICell<FixedLocalVolSurface.Extrapolation>
    ) as this =

    inherit Model<FixedLocalVolSurface> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _dates                                     = dates
    let _strikes                                   = strikes
    let _localVolMatrix                            = localVolMatrix
    let _dayCounter                                = dayCounter
    let _lowerExtrapolation                        = lowerExtrapolation
    let _upperExtrapolation                        = upperExtrapolation
(*
    Functions
*)
    let _FixedLocalVolSurface                      = cell (fun () -> new FixedLocalVolSurface (referenceDate.Value, dates.Value, strikes.Value, localVolMatrix.Value, dayCounter.Value, lowerExtrapolation.Value, upperExtrapolation.Value))
    let _maxDate                                   = triv (fun () -> _FixedLocalVolSurface.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _FixedLocalVolSurface.Value.maxStrike())
    let _maxTime                                   = triv (fun () -> _FixedLocalVolSurface.Value.maxTime())
    let _minStrike                                 = triv (fun () -> _FixedLocalVolSurface.Value.minStrike())
    let _setInterpolation                          (i : ICell<'Interpolator>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.setInterpolation(i.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _FixedLocalVolSurface.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.optionDateFromTenor(p.Value))
    let _calendar                                  = triv (fun () -> _FixedLocalVolSurface.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FixedLocalVolSurface.Value.dayCounter())
    let _referenceDate                             = triv (fun () -> _FixedLocalVolSurface.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FixedLocalVolSurface.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _FixedLocalVolSurface.Value.update()
                                                                     _FixedLocalVolSurface.Value)
    let _allowsExtrapolation                       = triv (fun () -> _FixedLocalVolSurface.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.disableExtrapolation(b.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FixedLocalVolSurface.Value.enableExtrapolation(b.Value)
                                                                     _FixedLocalVolSurface.Value)
    let _extrapolate                               = triv (fun () -> _FixedLocalVolSurface.Value.extrapolate)
    do this.Bind(_FixedLocalVolSurface)
(* 
    casting 
*)
    internal new () = FixedLocalVolSurfaceModel2(null,null,null,null,null,null,null)
    member internal this.Inject v = _FixedLocalVolSurface.Value <- v
    static member Cast (p : ICell<FixedLocalVolSurface>) = 
        if p :? FixedLocalVolSurfaceModel2 then 
            p :?> FixedLocalVolSurfaceModel2
        else
            let o = new FixedLocalVolSurfaceModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.dates                              = _dates 
    member this.strikes                            = _strikes 
    member this.localVolMatrix                     = _localVolMatrix 
    member this.dayCounter                         = _dayCounter 
    member this.lowerExtrapolation                 = _lowerExtrapolation 
    member this.upperExtrapolation                 = _upperExtrapolation 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MaxTime                            = _maxTime
    member this.MinStrike                          = _minStrike
    member this.SetInterpolation                   i   
                                                   = _setInterpolation i 
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
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
