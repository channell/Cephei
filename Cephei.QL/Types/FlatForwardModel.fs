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
  Flat interest-rate curve
constructors
  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel
    ( referenceDate                                : ICell<Date>
    , forward                                      : ICell<Quote>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (referenceDate.Value, forward.Value, dayCounter.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel1
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , forward                                      : ICell<Quote>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (settlementDays.Value, calendar.Value, forward.Value, dayCounter.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel2
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , forward                                      : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
    let _frequency                                 = frequency
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (settlementDays.Value, calendar.Value, forward.Value, dayCounter.Value, compounding.Value, frequency.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel3
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , forward                                      : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (settlementDays.Value, calendar.Value, forward.Value, dayCounter.Value, compounding.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel4
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , forward                                      : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (settlementDays.Value, calendar.Value, forward.Value, dayCounter.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel5
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , forward                                      : ICell<Quote>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
    let _frequency                                 = frequency
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (settlementDays.Value, calendar.Value, forward.Value, dayCounter.Value, compounding.Value, frequency.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel6
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , forward                                      : ICell<Quote>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (settlementDays.Value, calendar.Value, forward.Value, dayCounter.Value, compounding.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel7
    ( referenceDate                                : ICell<Date>
    , forward                                      : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
    let _frequency                                 = frequency
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (referenceDate.Value, forward.Value, dayCounter.Value, compounding.Value, frequency.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel8
    ( referenceDate                                : ICell<Date>
    , forward                                      : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (referenceDate.Value, forward.Value, dayCounter.Value, compounding.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel9
    ( referenceDate                                : ICell<Date>
    , forward                                      : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (referenceDate.Value, forward.Value, dayCounter.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel10
    ( referenceDate                                : ICell<Date>
    , forward                                      : ICell<Quote>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
    let _frequency                                 = frequency
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (referenceDate.Value, forward.Value, dayCounter.Value, compounding.Value, frequency.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.MaxDate                            = _maxDate
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
  Flat interest-rate curve

  </summary> *)
[<AutoSerializable(true)>]
type FlatForwardModel11
    ( referenceDate                                : ICell<Date>
    , forward                                      : ICell<Quote>
    , dayCounter                                   : ICell<DayCounter>
    , compounding                                  : ICell<Compounding>
    ) as this =

    inherit Model<FlatForward> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _forward                                   = forward
    let _dayCounter                                = dayCounter
    let _compounding                               = compounding
(*
    Functions
*)
    let _FlatForward                               = cell (fun () -> new FlatForward (referenceDate.Value, forward.Value, dayCounter.Value, compounding.Value))
    let _maxDate                                   = triv (fun () -> _FlatForward.Value.maxDate())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FlatForward.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FlatForward.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FlatForward.Value.update()
                                                                     _FlatForward.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FlatForward.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FlatForward.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FlatForward.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FlatForward.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FlatForward.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FlatForward.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FlatForward.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.disableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatForward.Value.enableExtrapolation(b.Value)
                                                                     _FlatForward.Value)
    let _extrapolate                               = triv (fun () -> _FlatForward.Value.extrapolate)
    do this.Bind(_FlatForward)

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.forward                            = _forward 
    member this.dayCounter                         = _dayCounter 
    member this.compounding                        = _compounding 
    member this.MaxDate                            = _maxDate
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
