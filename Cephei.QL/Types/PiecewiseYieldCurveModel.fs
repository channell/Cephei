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
this is an abstract class to give access to all properties and methods of PiecewiseYieldCurve and avoiding generics

  </summary> *)
[<AutoSerializable(true)>]
type PiecewiseYieldCurveModel
    ( traits                                       : ICell<ITraits<YieldTermStructure>>
    , referenceDate                                : ICell<Date>
    , instruments                                  : ICell<List<RateHelper>>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<List<Handle<Quote>>>
    , jumpDates                                    : ICell<List<Date>>
    , accuracy                                     : ICell<double>
    , i                                            : ICell<IInterpolationFactory>
    ) as this =
    inherit Model<PiecewiseYieldCurve> ()
(*
    Parameters
*)
    let _traints                                   =  traits
    let _referenceDate                             = referenceDate
    let _instruments                               = instruments
    let _dayCounter                                = dayCounter
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _accurancy                                 = accuracy
    let _i                                         = i

(*
    Functions
*)

    let mutable
        _PiecewiseYieldCurve                       = cell (fun () -> new PiecewiseYieldCurve (_traints.Value, _referenceDate.Value, _instruments.Value, _dayCounter.Value, _jumps.Value, _jumpDates.Value, _accurancy.Value, _i.Value))
    let _accuracy_                                 = triv (fun () -> _PiecewiseYieldCurve.Value.accuracy_)
    let _Clone                                     = triv (fun () -> _PiecewiseYieldCurve.Value.Clone())
    let _data                                      = triv (fun () -> _PiecewiseYieldCurve.Value.data())
    let _data_                                     = triv (fun () -> _PiecewiseYieldCurve.Value.data_)
    let _dates                                     = triv (fun () -> _PiecewiseYieldCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _PiecewiseYieldCurve.Value.dates_)
    let _discountImpl                              (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.discountImpl(i.Value, t.Value))
    let _forwardImpl                               (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.forwardImpl(i.Value, t.Value))
    let _guess                                     (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.guess(i.Value, c.Value, validData.Value, first.Value))
    let _initialDate                               (c : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.initialDate(c.Value))
    let _initialDate1                              = triv (fun () -> _PiecewiseYieldCurve.Value.initialDate())
    let _initialValue                              = triv (fun () -> _PiecewiseYieldCurve.Value.initialValue())
    let _initialValue1                             (c : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.initialValue(c.Value))
    let _instruments_                              = triv (fun () -> _PiecewiseYieldCurve.Value.instruments_)
    let _interpolation_                            = triv (fun () -> _PiecewiseYieldCurve.Value.interpolation_)

    let _interpolator_                             = triv (fun () -> _PiecewiseYieldCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _PiecewiseYieldCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _PiecewiseYieldCurve.Value.maxDate_)
    let _maxIterations                             = triv (fun () -> _PiecewiseYieldCurve.Value.maxIterations())
    let _maxValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.maxValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _minValueAfter                             (i : ICell<int>) (c : ICell<InterpolatedCurve>) (validData : ICell<bool>) (first : ICell<int>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.minValueAfter(i.Value, c.Value, validData.Value, first.Value))
    let _moving_                                   = triv (fun () -> _PiecewiseYieldCurve.Value.moving_)
    let _nodes                                     = triv (fun () -> _PiecewiseYieldCurve.Value.nodes())
    let _registerWith                              (helper : ICell<BootstrapHelper<YieldTermStructure>>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.registerWith(helper.Value)
                                                                     _PiecewiseYieldCurve.Value)
    let _setTermStructure                          (helper : ICell<BootstrapHelper<YieldTermStructure>>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.setTermStructure(helper.Value)
                                                                     _PiecewiseYieldCurve.Value)
    let _setupInterpolation                        = triv (fun () -> _PiecewiseYieldCurve.Value.setupInterpolation()
                                                                     _PiecewiseYieldCurve.Value)
    let _times                                     = triv (fun () -> _PiecewiseYieldCurve.Value.times())
    let _times_                                    = triv (fun () -> _PiecewiseYieldCurve.Value.times_)
    let _traits_                                   = triv (fun () -> _PiecewiseYieldCurve.Value.traits_)
    let _updateGuess                               (data : ICell<Generic.List<double>>) (discount : ICell<double>) (i : ICell<int>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.updateGuess(data.Value, discount.Value, i.Value)
                                                                     _PiecewiseYieldCurve.Value)
    let _zeroYieldImpl                             (i : ICell<Interpolation>) (t : ICell<double>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.zeroYieldImpl(i.Value, t.Value))
    let _discount                                  (t : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.discount(t.Value, extrapolate.Value))
    let _discount1                                 (d : ICell<Date>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.discount(d.Value, extrapolate.Value))
    let _forwardRate                               (d : ICell<Date>) (p : ICell<Period>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.forwardRate(d.Value, p.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate1                              (d1 : ICell<Date>) (d2 : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.forwardRate(d1.Value, d2.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _forwardRate2                              (t1 : ICell<double>) (t2 : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.forwardRate(t1.Value, t2.Value, comp.Value, freq.Value, extrapolate.Value))
    let _jumpDates                                 = triv (fun () -> _PiecewiseYieldCurve.Value.jumpDates())
    let _jumpTimes                                 = triv (fun () -> _PiecewiseYieldCurve.Value.jumpTimes())
    let _update                                    = triv (fun () -> _PiecewiseYieldCurve.Value.update()
                                                                     _PiecewiseYieldCurve.Value)
    let _zeroRate                                  (t : ICell<double>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.zeroRate(t.Value, comp.Value, freq.Value, extrapolate.Value))
    let _zeroRate1                                 (d : ICell<Date>) (dayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.zeroRate(d.Value, dayCounter.Value, comp.Value, freq.Value, extrapolate.Value))
    let _calendar                                  = triv (fun () -> _PiecewiseYieldCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _PiecewiseYieldCurve.Value.dayCounter())
    let _maxTime                                   = triv (fun () -> _PiecewiseYieldCurve.Value.maxTime())
    let _referenceDate                             = triv (fun () -> _PiecewiseYieldCurve.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _PiecewiseYieldCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.timeFromReference(date.Value))
    let _allowsExtrapolation                       = triv (fun () -> _PiecewiseYieldCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.disableExtrapolation(b.Value)
                                                                     _PiecewiseYieldCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _PiecewiseYieldCurve.Value.enableExtrapolation(b.Value)
                                                                     _PiecewiseYieldCurve.Value)
    let _extrapolate                               = triv (fun () -> _PiecewiseYieldCurve.Value.extrapolate)
    do this.Bind(_PiecewiseYieldCurve)
(* 
    casting 
*)
    
    member internal this.Inject v = _PiecewiseYieldCurve <- v
    static member Cast (p : ICell<PiecewiseYieldCurve>) = 
        if p :? PiecewiseYieldCurveModel then 
            p :?> PiecewiseYieldCurveModel
        else
            let o = new PiecewiseYieldCurveModel (null,null,null,null,null,null,null,null)
            o.Inject p
            o.Bind p
            o

(* 
    Externally visible/bindable properties
*)
    member this.Accuracy_                          = _accuracy_
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.DiscountImpl                       i t   
                                                   = _discountImpl i t 
    member this.ForwardImpl                        i t   
                                                   = _forwardImpl i t 
    member this.Guess                              i c validData first   
                                                   = _guess i c validData first 
    member this.InitialDate                        c   
                                                   = _initialDate c 
    member this.InitialDate1                       = _initialDate1
    member this.InitialValue                       = _initialValue
    member this.InitialValue1                      c   
                                                   = _initialValue1 c 
    member this.Instruments_                       = _instruments_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxIterations                      = _maxIterations
    member this.MaxValueAfter                      i c validData first   
                                                   = _maxValueAfter i c validData first 
    member this.MinValueAfter                      i c validData first   
                                                   = _minValueAfter i c validData first 
    member this.Moving_                            = _moving_
    member this.Nodes                              = _nodes
    member this.RegisterWith                       helper   
                                                   = _registerWith helper 
    member this.SetTermStructure                   helper   
                                                   = _setTermStructure helper 
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Traits_                            = _traits_
    member this.UpdateGuess                        data discount i   
                                                   = _updateGuess data discount i 
    member this.ZeroYieldImpl                      i t   
                                                   = _zeroYieldImpl i t 
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
