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
  The given date will be the implied reference date.  This term structure will remain linked to the original structure, i.e., any changes in the latter will be reflected in this structure as well.  yieldtermstructures  - the correctness of the returned values is tested by checking them against numerical calculations. - observability against changes in the underlying term structure is checked.

  </summary> *)
[<AutoSerializable(true)>]
type ImpliedTermStructureModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    , referenceDate                                : ICell<Date>
    ) as this =

    inherit Model<ImpliedTermStructure> ()
(*
    Parameters
*)
    let _h                                         = h
    let _referenceDate                             = referenceDate
(*
    Functions
*)
    let _ImpliedTermStructure                      = cell (fun () -> new ImpliedTermStructure (h.Value, referenceDate.Value))
    let _calendar                                  = cell (fun () -> _ImpliedTermStructure.Value.calendar())
    let _dayCounter                                = cell (fun () -> _ImpliedTermStructure.Value.dayCounter())
    let _maxDate                                   = cell (fun () -> _ImpliedTermStructure.Value.maxDate())
    let _settlementDays                            = cell (fun () -> _ImpliedTermStructure.Value.settlementDays())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = cell (fun () -> _ImpliedTermStructure.Value.jumpDates())
    let _jumpTimes                                 = cell (fun () -> _ImpliedTermStructure.Value.jumpTimes())
    let _update                                    = cell (fun () -> _ImpliedTermStructure.Value.update()
                                                                     _ImpliedTermStructure.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _maxTime                                   = cell (fun () -> _ImpliedTermStructure.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _ImpliedTermStructure.Value.referenceDate())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = cell (fun () -> _ImpliedTermStructure.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.disableExtrapolation(b.Value)
                                                                     _ImpliedTermStructure.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _ImpliedTermStructure.Value.enableExtrapolation(b.Value)
                                                                     _ImpliedTermStructure.Value)
    let _extrapolate                               = cell (fun () -> _ImpliedTermStructure.Value.extrapolate)
    do this.Bind(_ImpliedTermStructure)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.referenceDate                      = _referenceDate 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.SettlementDays                     = _settlementDays
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
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.TimeFromReference                  date   
                                                   = _timeFromReference date 
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
