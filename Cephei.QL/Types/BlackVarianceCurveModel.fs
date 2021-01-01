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
  This class calculates time-dependent Black volatilities using as input a vector of (ATM) Black volatilities observed in the market.  The calculation is performed interpolating on the variance curve. Linear interpolation is used as default; this can be changed by the setInterpolation() method.  For strike dependence, see BlackVarianceSurface.  check time extrapolation
required for Handle
  </summary> *)
[<AutoSerializable(true)>]
type BlackVarianceCurveModel
    ( referenceDate                                : ICell<Date>
    , dates                                        : ICell<Generic.List<Date>>
    , blackVolCurve                                : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , forceMonotoneVariance                        : ICell<bool>
    ) as this =

    inherit Model<BlackVarianceCurve> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _dates                                     = dates
    let _blackVolCurve                             = blackVolCurve
    let _dayCounter                                = dayCounter
    let _forceMonotoneVariance                     = forceMonotoneVariance
(*
    Functions
*)
    let mutable
        _BlackVarianceCurve                        = make (fun () -> new BlackVarianceCurve (referenceDate.Value, dates.Value, blackVolCurve.Value, dayCounter.Value, forceMonotoneVariance.Value))
    let _dayCounter                                = triv _BlackVarianceCurve (fun () -> _BlackVarianceCurve.Value.dayCounter())
    let _maxDate                                   = triv _BlackVarianceCurve (fun () -> _BlackVarianceCurve.Value.maxDate())
    let _maxStrike                                 = triv _BlackVarianceCurve (fun () -> _BlackVarianceCurve.Value.maxStrike())
    let _minStrike                                 = triv _BlackVarianceCurve (fun () -> _BlackVarianceCurve.Value.minStrike())
    let _setInterpolation                          (i : ICell<'Interpolator>)   
                                                   = triv _BlackVarianceCurve (fun () -> _BlackVarianceCurve.Value.setInterpolation(i.Value)
                                                                                         _BlackVarianceCurve.Value)
    do this.Bind(_BlackVarianceCurve)
(* 
    casting 
*)
    internal new () = new BlackVarianceCurveModel(null,null,null,null,null)
    member internal this.Inject v = _BlackVarianceCurve <- v
    static member Cast (p : ICell<BlackVarianceCurve>) = 
        if p :? BlackVarianceCurveModel then 
            p :?> BlackVarianceCurveModel
        else
            let o = new BlackVarianceCurveModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.dates                              = _dates 
    member this.blackVolCurve                      = _blackVolCurve 
    member this.dayCounter                         = _dayCounter 
    member this.forceMonotoneVariance              = _forceMonotoneVariance 
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.SetInterpolation                   i   
                                                   = _setInterpolation i 
