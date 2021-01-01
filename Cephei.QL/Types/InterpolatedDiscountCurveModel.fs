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
  yieldtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedDiscountCurveModel<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedDiscountCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _dayCounter                                = dayCounter
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedDiscountCurve                 = make (fun () -> new InterpolatedDiscountCurve<'Interpolator> (referenceDate.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.Clone())
    let _data                                      = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data())
    let _data_                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data_)
    let _dates                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates())
    let _dates_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates_)
    let _discounts                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discounts())
    let _interpolation_                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolation_)
    let _interpolator_                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolator_)
    let _maxDate                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate())
    let _maxDate_                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate_)
    let _nodes                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.nodes())
    let _setupInterpolation                        = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.setupInterpolation()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _times                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times())
    let _times_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times_)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpTimes())
    let _update                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.update()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.calendar())
    let _dayCounter                                = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _extrapolate                               = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.extrapolate)
    do this.Bind(_InterpolatedDiscountCurve)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.dayCounter                         = _dayCounter 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
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
  yieldtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedDiscountCurveModel1<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedDiscountCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dayCounter                                = dayCounter
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedDiscountCurve                 = make (fun () -> new InterpolatedDiscountCurve<'Interpolator> (dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.Clone())
    let _data                                      = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data())
    let _data_                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data_)
    let _dates                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates())
    let _dates_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates_)
    let _discounts                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discounts())
    let _interpolation_                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolation_)
    let _interpolator_                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolator_)
    let _maxDate                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate())
    let _maxDate_                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate_)
    let _nodes                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.nodes())
    let _setupInterpolation                        = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.setupInterpolation()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _times                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times())
    let _times_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times_)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpTimes())
    let _update                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.update()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.calendar())
    let _dayCounter                                = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _extrapolate                               = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.extrapolate)
    do this.Bind(_InterpolatedDiscountCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dayCounter                         = _dayCounter 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
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
  yieldtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedDiscountCurveModel2<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedDiscountCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _dayCounter                                = dayCounter
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedDiscountCurve                 = make (fun () -> new InterpolatedDiscountCurve<'Interpolator> (settlementDays.Value, calendar.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.Clone())
    let _data                                      = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data())
    let _data_                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data_)
    let _dates                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates())
    let _dates_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates_)
    let _discounts                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discounts())
    let _interpolation_                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolation_)
    let _interpolator_                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolator_)
    let _maxDate                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate())
    let _maxDate_                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate_)
    let _nodes                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.nodes())
    let _setupInterpolation                        = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.setupInterpolation()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _times                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times())
    let _times_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times_)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpTimes())
    let _update                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.update()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.calendar())
    let _dayCounter                                = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _extrapolate                               = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.extrapolate)
    do this.Bind(_InterpolatedDiscountCurve)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.dayCounter                         = _dayCounter 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
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
  yieldtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedDiscountCurveModel3<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , discounts                                    : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedDiscountCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _discounts                                 = discounts
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedDiscountCurve                 = make (fun () -> new InterpolatedDiscountCurve<'Interpolator> (dates.Value, discounts.Value, dayCounter.Value, calendar.Value, interpolator.Value))
    let _Clone                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.Clone())
    let _data                                      = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data())
    let _data_                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data_)
    let _dates                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates())
    let _dates_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates_)
    let _discounts                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discounts())
    let _interpolation_                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolation_)
    let _interpolator_                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolator_)
    let _maxDate                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate())
    let _maxDate_                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate_)
    let _nodes                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.nodes())
    let _setupInterpolation                        = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.setupInterpolation()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _times                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times())
    let _times_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times_)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpTimes())
    let _update                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.update()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.calendar())
    let _dayCounter                                = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _extrapolate                               = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.extrapolate)
    do this.Bind(_InterpolatedDiscountCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.discounts                          = _discounts 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
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
  yieldtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedDiscountCurveModel4<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , discounts                                    : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedDiscountCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _discounts                                 = discounts
    let _dayCounter                                = dayCounter
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedDiscountCurve                 = make (fun () -> new InterpolatedDiscountCurve<'Interpolator> (dates.Value, discounts.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.Clone())
    let _data                                      = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data())
    let _data_                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data_)
    let _dates                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates())
    let _dates_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates_)
    let _discounts                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discounts())
    let _interpolation_                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolation_)
    let _interpolator_                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolator_)
    let _maxDate                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate())
    let _maxDate_                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate_)
    let _nodes                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.nodes())
    let _setupInterpolation                        = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.setupInterpolation()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _times                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times())
    let _times_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times_)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpTimes())
    let _update                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.update()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.calendar())
    let _dayCounter                                = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _extrapolate                               = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.extrapolate)
    do this.Bind(_InterpolatedDiscountCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.discounts                          = _discounts 
    member this.dayCounter                         = _dayCounter 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
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
  yieldtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedDiscountCurveModel5<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , discounts                                    : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedDiscountCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _discounts                                 = discounts
    let _dayCounter                                = dayCounter
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedDiscountCurve                 = make (fun () -> new InterpolatedDiscountCurve<'Interpolator> (dates.Value, discounts.Value, dayCounter.Value, interpolator.Value))
    let _Clone                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.Clone())
    let _data                                      = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data())
    let _data_                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data_)
    let _dates                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates())
    let _dates_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates_)
    let _discounts                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discounts())
    let _interpolation_                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolation_)
    let _interpolator_                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolator_)
    let _maxDate                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate())
    let _maxDate_                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate_)
    let _nodes                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.nodes())
    let _setupInterpolation                        = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.setupInterpolation()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _times                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times())
    let _times_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times_)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpTimes())
    let _update                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.update()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.calendar())
    let _dayCounter                                = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _extrapolate                               = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.extrapolate)
    do this.Bind(_InterpolatedDiscountCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.discounts                          = _discounts 
    member this.dayCounter                         = _dayCounter 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
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
  yieldtermstructures

  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedDiscountCurveModel6<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , discounts                                    : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedDiscountCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _discounts                                 = discounts
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let mutable
        _InterpolatedDiscountCurve                 = make (fun () -> new InterpolatedDiscountCurve<'Interpolator> (dates.Value, discounts.Value, dayCounter.Value, calendar.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.Clone())
    let _data                                      = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data())
    let _data_                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.data_)
    let _dates                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates())
    let _dates_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dates_)
    let _discounts                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discounts())
    let _interpolation_                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolation_)
    let _interpolator_                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.interpolator_)
    let _maxDate                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate())
    let _maxDate_                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxDate_)
    let _nodes                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.nodes())
    let _setupInterpolation                        = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.setupInterpolation()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _times                                     = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times())
    let _times_                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.times_)
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.jumpTimes())
    let _update                                    = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.update()
                                                                                                _InterpolatedDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.calendar())
    let _dayCounter                                = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                                                _InterpolatedDiscountCurve.Value)
    let _extrapolate                               = triv _InterpolatedDiscountCurve (fun () -> _InterpolatedDiscountCurve.Value.extrapolate)
    do this.Bind(_InterpolatedDiscountCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.discounts                          = _discounts 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Discount                           t extrapolate   
                                                   = _discount t extrapolate 
    member this.Discount1                          d extrapolate   
                                                   = _discount1 d extrapolate 
    member this.ForwardRate                        d p dayCounter comp freq extrapolate   
                                                   = _forwardRate d p dayCounter comp freq extrapolate 
    member this.ForwardRate1                       d1 d2 dayCounter comp freq extrapolate   
                                                   = _forwardRate1 d1 d2 dayCounter comp freq extrapolate 
    member this.ForwardRate2                       t1 t2 comp freq extrapolate   
                                                   = _forwardRate2 t1 t2 comp freq extrapolate 
    member this.JumpDates                          = _jumpDates
    member this.JumpTimes                          = _jumpTimes
    member this.Update                             = _update
    member this.ZeroRate                           t comp freq extrapolate   
                                                   = _zeroRate t comp freq extrapolate 
    member this.ZeroRate1                          d dayCounter comp freq extrapolate   
                                                   = _zeroRate1 d dayCounter comp freq extrapolate 
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
