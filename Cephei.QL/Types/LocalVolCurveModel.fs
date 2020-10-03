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
  Local volatility curve derived from a Black curve

  </summary> *)
[<AutoSerializable(true)>]
type LocalVolCurveModel
    ( curve                                        : ICell<Handle<BlackVarianceCurve>>
    ) as this =

    inherit Model<LocalVolCurve> ()
(*
    Parameters
*)
    let _curve                                     = curve
(*
    Functions
*)
    let _LocalVolCurve                             = cell (fun () -> new LocalVolCurve (curve.Value))
    let _calendar                                  = triv (fun () -> _LocalVolCurve.Value.calendar())
    let _dayCounter                                = triv (fun () -> _LocalVolCurve.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _LocalVolCurve.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _LocalVolCurve.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _LocalVolCurve.Value.minStrike())
    let _referenceDate                             = triv (fun () -> _LocalVolCurve.Value.referenceDate())
    let _localVol                                  (t : ICell<double>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolCurve.Value.localVol(t.Value, underlyingLevel.Value, extrapolate.Value))
    let _localVol1                                 (d : ICell<Date>) (underlyingLevel : ICell<double>) (extrapolate : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolCurve.Value.localVol(d.Value, underlyingLevel.Value, extrapolate.Value))
    let _businessDayConvention                     = triv (fun () -> _LocalVolCurve.Value.businessDayConvention())
    let _optionDateFromTenor                       (p : ICell<Period>)   
                                                   = triv (fun () -> _LocalVolCurve.Value.optionDateFromTenor(p.Value))
    let _maxTime                                   = triv (fun () -> _LocalVolCurve.Value.maxTime())
    let _settlementDays                            = triv (fun () -> _LocalVolCurve.Value.settlementDays())
    let _timeFromReference                         (date : ICell<Date>)   
                                                   = triv (fun () -> _LocalVolCurve.Value.timeFromReference(date.Value))
    let _update                                    = triv (fun () -> _LocalVolCurve.Value.update()
                                                                     _LocalVolCurve.Value)
    let _allowsExtrapolation                       = triv (fun () -> _LocalVolCurve.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolCurve.Value.disableExtrapolation(b.Value)
                                                                     _LocalVolCurve.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _LocalVolCurve.Value.enableExtrapolation(b.Value)
                                                                     _LocalVolCurve.Value)
    let _extrapolate                               = triv (fun () -> _LocalVolCurve.Value.extrapolate)
    do this.Bind(_LocalVolCurve)
(* 
    casting 
*)
    internal new () = LocalVolCurveModel(null)
    member internal this.Inject v = _LocalVolCurve.Value <- v
    static member Cast (p : ICell<LocalVolCurve>) = 
        if p :? LocalVolCurveModel then 
            p :?> LocalVolCurveModel
        else
            let o = new LocalVolCurveModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.curve                              = _curve 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.LocalVol                           t underlyingLevel extrapolate   
                                                   = _localVol t underlyingLevel extrapolate 
    member this.LocalVol1                          d underlyingLevel extrapolate   
                                                   = _localVol1 d underlyingLevel extrapolate 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.OptionDateFromTenor                p   
                                                   = _optionDateFromTenor p 
    member this.MaxTime                            = _maxTime
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
