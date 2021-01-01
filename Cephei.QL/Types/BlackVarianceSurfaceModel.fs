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
  This class calculates time/strike dependent Black volatilities using as input a matrix of Black volatilities observed in the market.  The calculation is performed interpolating on the variance surface.  Bilinear interpolation is used as default; this can be changed by the setInterpolation() method.  check time extrapolation

  </summary> *)
[<AutoSerializable(true)>]
type BlackVarianceSurfaceModel
    ( referenceDate                                : ICell<Date>
    , calendar                                     : ICell<Calendar>
    , dates                                        : ICell<Generic.List<Date>>
    , strikes                                      : ICell<Generic.List<double>>
    , blackVolMatrix                               : ICell<Matrix>
    , dayCounter                                   : ICell<DayCounter>
    , lowerExtrapolation                           : ICell<BlackVarianceSurface.Extrapolation>
    , upperExtrapolation                           : ICell<BlackVarianceSurface.Extrapolation>
    ) as this =

    inherit Model<BlackVarianceSurface> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _calendar                                  = calendar
    let _dates                                     = dates
    let _strikes                                   = strikes
    let _blackVolMatrix                            = blackVolMatrix
    let _dayCounter                                = dayCounter
    let _lowerExtrapolation                        = lowerExtrapolation
    let _upperExtrapolation                        = upperExtrapolation
(*
    Functions
*)
    let mutable
        _BlackVarianceSurface                      = make (fun () -> new BlackVarianceSurface (referenceDate.Value, calendar.Value, dates.Value, strikes.Value, blackVolMatrix.Value, dayCounter.Value, lowerExtrapolation.Value, upperExtrapolation.Value))
    let _dates                                     = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.dates())
    let _dayCounter                                = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.dayCounter())
    let _maxDate                                   = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.maxDate())
    let _maxStrike                                 = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.maxStrike())
    let _minStrike                                 = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.minStrike())
    let _setInterpolation                          (i : ICell<'Interpolator>)   
                                                   = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.setInterpolation(i.Value)
                                                                                           _BlackVarianceSurface.Value)
    let _strikes                                   = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.strikes())
    let _times                                     = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.times())
    let _variances                                 = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.variances())
    let _volatilities                              = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.volatilities())
    do this.Bind(_BlackVarianceSurface)
(* 
    casting 
*)
    internal new () = new BlackVarianceSurfaceModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _BlackVarianceSurface <- v
    static member Cast (p : ICell<BlackVarianceSurface>) = 
        if p :? BlackVarianceSurfaceModel then 
            p :?> BlackVarianceSurfaceModel
        else
            let o = new BlackVarianceSurfaceModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.calendar                           = _calendar 
    member this.dates                              = _dates 
    member this.strikes                            = _strikes 
    member this.blackVolMatrix                     = _blackVolMatrix 
    member this.dayCounter                         = _dayCounter 
    member this.lowerExtrapolation                 = _lowerExtrapolation 
    member this.upperExtrapolation                 = _upperExtrapolation 
    member this.Dates                              = _dates
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.SetInterpolation                   i   
                                                   = _setInterpolation i 
    member this.Strikes                            = _strikes
    member this.Times                              = _times
    member this.Variances                          = _variances
    member this.Volatilities                       = _volatilities
(* <summary>
  This class calculates time/strike dependent Black volatilities using as input a matrix of Black volatilities observed in the market.  The calculation is performed interpolating on the variance surface.  Bilinear interpolation is used as default; this can be changed by the setInterpolation() method.  check time extrapolation
required for Handle
  </summary> *)
[<AutoSerializable(true)>]
type BlackVarianceSurfaceModel1
    () as this =
    inherit Model<BlackVarianceSurface> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _BlackVarianceSurface                      = make (fun () -> new BlackVarianceSurface ())
    let _dates                                     = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.dates())
    let _dayCounter                                = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.dayCounter())
    let _maxDate                                   = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.maxDate())
    let _maxStrike                                 = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.maxStrike())
    let _minStrike                                 = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.minStrike())
    let _setInterpolation                          (i : ICell<'Interpolator>)   
                                                   = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.setInterpolation(i.Value)
                                                                                           _BlackVarianceSurface.Value)
    let _strikes                                   = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.strikes())
    let _times                                     = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.times())
    let _variances                                 = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.variances())
    let _volatilities                              = triv _BlackVarianceSurface (fun () -> _BlackVarianceSurface.Value.volatilities())
    do this.Bind(_BlackVarianceSurface)
(* 
    casting 
*)
    
    member internal this.Inject v = _BlackVarianceSurface <- v
    static member Cast (p : ICell<BlackVarianceSurface>) = 
        if p :? BlackVarianceSurfaceModel1 then 
            p :?> BlackVarianceSurfaceModel1
        else
            let o = new BlackVarianceSurfaceModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Dates                              = _dates
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.SetInterpolation                   i   
                                                   = _setInterpolation i 
    member this.Strikes                            = _strikes
    member this.Times                              = _times
    member this.Variances                          = _variances
    member this.Volatilities                       = _volatilities
