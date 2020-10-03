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
  This class fits a discount function d(t) over a set of bonds, using a user defined fitting method. The discount function is fit in such a way so that all cashflows of all input bonds, when discounted using d(t) will reproduce the set of input bond prices in an optimized sense. Minimized price errors are weighted by the inverse of their respective bond duration.  The FittedBondDiscountCurve class acts as a generic wrapper, while its inner class FittingMethod provides the implementation details. Developers thus need only derive new fitting methods from the latter. 
<b> Example: </b> FittedBondCurve.cpp compares various bond discount curve fitting methodologies  The method can be slow if there are many bonds to fit. Speed also depends on the particular choice of fitting method chosen and its convergence properties under optimization.  See also todo list for BondDiscountCurveFittingMethod.  refactor the bond helper class so that it is pure virtual and returns a generic bond or its cash flows. Derived classes would include helpers for fixed-rate and zero-coupon bonds. In this way, both bonds and bills can be used to fit a discount curve using the exact same machinery. At present, only fixed-coupon bonds are supported. An even better way to move forward might be to get rate helpers to return cashflows, in which case this class could be used to fit any set of cash flows, not just bonds.  add more fitting diagnostics: smoothness, standard deviation, student-t test, etc. Generic smoothness method may be useful for smoothing splines fitting. See Fisher, M., D. Nychka and D. Zervos: "Fitting the term structure of interest rates with smoothing splines." Board of Governors of the Federal Reserve System, Federal Resere Board Working Paper, 95-1.  add extrapolation routines  yieldtermstructures
Constructors ! reference date based on current evaluation date
  </summary> *)
[<AutoSerializable(true)>]
type FittedBondDiscountCurveModel
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , bondHelpers                                  : ICell<Generic.List<BondHelper>>
    , dayCounter                                   : ICell<DayCounter>
    , fittingMethod                                : ICell<FittedBondDiscountCurve.FittingMethod>
    , accuracy                                     : ICell<double>
    , maxEvaluations                               : ICell<int>
    , guess                                        : ICell<Vector>
    , simplexLambda                                : ICell<double>
    , maxStationaryStateIterations                 : ICell<int>
    ) as this =

    inherit Model<FittedBondDiscountCurve> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _bondHelpers                               = bondHelpers
    let _dayCounter                                = dayCounter
    let _fittingMethod                             = fittingMethod
    let _accuracy                                  = accuracy
    let _maxEvaluations                            = maxEvaluations
    let _guess                                     = guess
    let _simplexLambda                             = simplexLambda
    let _maxStationaryStateIterations              = maxStationaryStateIterations
(*
    Functions
*)
    let _FittedBondDiscountCurve                   = cell (fun () -> new FittedBondDiscountCurve (settlementDays.Value, calendar.Value, bondHelpers.Value, dayCounter.Value, fittingMethod.Value, accuracy.Value, maxEvaluations.Value, guess.Value, simplexLambda.Value, maxStationaryStateIterations.Value))
    let _maxDate                                   = triv (fun () -> _FittedBondDiscountCurve.Value.maxDate())
    let _numberOfBonds                             = triv (fun () -> _FittedBondDiscountCurve.Value.numberOfBonds())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FittedBondDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FittedBondDiscountCurve.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FittedBondDiscountCurve.Value.update()
                                                                     _FittedBondDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FittedBondDiscountCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FittedBondDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FittedBondDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FittedBondDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FittedBondDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FittedBondDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                     _FittedBondDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                     _FittedBondDiscountCurve.Value)
    let _extrapolate                               = triv (fun () -> _FittedBondDiscountCurve.Value.extrapolate)
    do this.Bind(_FittedBondDiscountCurve)
(* 
    casting 
*)
    internal new () = FittedBondDiscountCurveModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FittedBondDiscountCurve.Value <- v
    static member Cast (p : ICell<FittedBondDiscountCurve>) = 
        if p :? FittedBondDiscountCurveModel then 
            p :?> FittedBondDiscountCurveModel
        else
            let o = new FittedBondDiscountCurveModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.bondHelpers                        = _bondHelpers 
    member this.dayCounter                         = _dayCounter 
    member this.fittingMethod                      = _fittingMethod 
    member this.accuracy                           = _accuracy 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.guess                              = _guess 
    member this.simplexLambda                      = _simplexLambda 
    member this.maxStationaryStateIterations       = _maxStationaryStateIterations 
    member this.MaxDate                            = _maxDate
    member this.NumberOfBonds                      = _numberOfBonds
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
  This class fits a discount function d(t) over a set of bonds, using a user defined fitting method. The discount function is fit in such a way so that all cashflows of all input bonds, when discounted using d(t) will reproduce the set of input bond prices in an optimized sense. Minimized price errors are weighted by the inverse of their respective bond duration.  The FittedBondDiscountCurve class acts as a generic wrapper, while its inner class FittingMethod provides the implementation details. Developers thus need only derive new fitting methods from the latter. 
<b> Example: </b> FittedBondCurve.cpp compares various bond discount curve fitting methodologies  The method can be slow if there are many bonds to fit. Speed also depends on the particular choice of fitting method chosen and its convergence properties under optimization.  See also todo list for BondDiscountCurveFittingMethod.  refactor the bond helper class so that it is pure virtual and returns a generic bond or its cash flows. Derived classes would include helpers for fixed-rate and zero-coupon bonds. In this way, both bonds and bills can be used to fit a discount curve using the exact same machinery. At present, only fixed-coupon bonds are supported. An even better way to move forward might be to get rate helpers to return cashflows, in which case this class could be used to fit any set of cash flows, not just bonds.  add more fitting diagnostics: smoothness, standard deviation, student-t test, etc. Generic smoothness method may be useful for smoothing splines fitting. See Fisher, M., D. Nychka and D. Zervos: "Fitting the term structure of interest rates with smoothing splines." Board of Governors of the Federal Reserve System, Federal Resere Board Working Paper, 95-1.  add extrapolation routines  yieldtermstructures
! curve reference date fixed for life of curve
  </summary> *)
[<AutoSerializable(true)>]
type FittedBondDiscountCurveModel1
    ( referenceDate                                : ICell<Date>
    , bondHelpers                                  : ICell<Generic.List<BondHelper>>
    , dayCounter                                   : ICell<DayCounter>
    , fittingMethod                                : ICell<FittedBondDiscountCurve.FittingMethod>
    , accuracy                                     : ICell<double>
    , maxEvaluations                               : ICell<int>
    , guess                                        : ICell<Vector>
    , simplexLambda                                : ICell<double>
    , maxStationaryStateIterations                 : ICell<int>
    ) as this =

    inherit Model<FittedBondDiscountCurve> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _bondHelpers                               = bondHelpers
    let _dayCounter                                = dayCounter
    let _fittingMethod                             = fittingMethod
    let _accuracy                                  = accuracy
    let _maxEvaluations                            = maxEvaluations
    let _guess                                     = guess
    let _simplexLambda                             = simplexLambda
    let _maxStationaryStateIterations              = maxStationaryStateIterations
(*
    Functions
*)
    let _FittedBondDiscountCurve                   = cell (fun () -> new FittedBondDiscountCurve (referenceDate.Value, bondHelpers.Value, dayCounter.Value, fittingMethod.Value, accuracy.Value, maxEvaluations.Value, guess.Value, simplexLambda.Value, maxStationaryStateIterations.Value))
    let _maxDate                                   = triv (fun () -> _FittedBondDiscountCurve.Value.maxDate())
    let _numberOfBonds                             = triv (fun () -> _FittedBondDiscountCurve.Value.numberOfBonds())
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _FittedBondDiscountCurve.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _FittedBondDiscountCurve.Value.jumpTimes())
    let _update                                    = triv (fun () -> _FittedBondDiscountCurve.Value.update()
                                                                     _FittedBondDiscountCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _FittedBondDiscountCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _FittedBondDiscountCurve.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _FittedBondDiscountCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _FittedBondDiscountCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _FittedBondDiscountCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _FittedBondDiscountCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.disableExtrapolation(b.Value)
                                                                     _FittedBondDiscountCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FittedBondDiscountCurve.Value.enableExtrapolation(b.Value)
                                                                     _FittedBondDiscountCurve.Value)
    let _extrapolate                               = triv (fun () -> _FittedBondDiscountCurve.Value.extrapolate)
    do this.Bind(_FittedBondDiscountCurve)
(* 
    casting 
*)
    internal new () = FittedBondDiscountCurveModel1(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FittedBondDiscountCurve.Value <- v
    static member Cast (p : ICell<FittedBondDiscountCurve>) = 
        if p :? FittedBondDiscountCurveModel1 then 
            p :?> FittedBondDiscountCurveModel1
        else
            let o = new FittedBondDiscountCurveModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.bondHelpers                        = _bondHelpers 
    member this.dayCounter                         = _dayCounter 
    member this.fittingMethod                      = _fittingMethod 
    member this.accuracy                           = _accuracy 
    member this.maxEvaluations                     = _maxEvaluations 
    member this.guess                              = _guess 
    member this.simplexLambda                      = _simplexLambda 
    member this.maxStationaryStateIterations       = _maxStationaryStateIterations 
    member this.MaxDate                            = _maxDate
    member this.NumberOfBonds                      = _numberOfBonds
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
