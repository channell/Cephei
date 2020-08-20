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
type InterpolatedHazardRateCurveModel<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , hazardRates                                  : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , cal                                          : ICell<Calendar>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedHazardRateCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _hazardRates                               = hazardRates
    let _dayCounter                                = dayCounter
    let _cal                                       = cal
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedHazardRateCurve               = cell (fun () -> new InterpolatedHazardRateCurve<'Interpolator> (dates.Value, hazardRates.Value, dayCounter.Value, cal.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedHazardRateCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedHazardRateCurve.Value.dates_)
    let _discounts                                 = cell (fun () -> _InterpolatedHazardRateCurve.Value.discounts())
    let _hazardRates                               = cell (fun () -> _InterpolatedHazardRateCurve.Value.hazardRates())
    let _interpolation_                            = cell (fun () -> _InterpolatedHazardRateCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedHazardRateCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedHazardRateCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedHazardRateCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedHazardRateCurve.Value.setupInterpolation()
                                                                     _InterpolatedHazardRateCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedHazardRateCurve.Value.times_)
    do this.Bind(_InterpolatedHazardRateCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.hazardRates                        = _hazardRates 
    member this.dayCounter                         = _dayCounter 
    member this.cal                                = _cal 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.HazardRates                        = _hazardRates
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedHazardRateCurveModel1<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , hazardRates                                  : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedHazardRateCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _hazardRates                               = hazardRates
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedHazardRateCurve               = cell (fun () -> new InterpolatedHazardRateCurve<'Interpolator> (dates.Value, hazardRates.Value, dayCounter.Value, calendar.Value, interpolator.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedHazardRateCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedHazardRateCurve.Value.dates_)
    let _discounts                                 = cell (fun () -> _InterpolatedHazardRateCurve.Value.discounts())
    let _hazardRates                               = cell (fun () -> _InterpolatedHazardRateCurve.Value.hazardRates())
    let _interpolation_                            = cell (fun () -> _InterpolatedHazardRateCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedHazardRateCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedHazardRateCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedHazardRateCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedHazardRateCurve.Value.setupInterpolation()
                                                                     _InterpolatedHazardRateCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedHazardRateCurve.Value.times_)
    do this.Bind(_InterpolatedHazardRateCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.hazardRates                        = _hazardRates 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.HazardRates                        = _hazardRates
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedHazardRateCurveModel2<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , hazardRates                                  : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedHazardRateCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _hazardRates                               = hazardRates
    let _dayCounter                                = dayCounter
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedHazardRateCurve               = cell (fun () -> new InterpolatedHazardRateCurve<'Interpolator> (dates.Value, hazardRates.Value, dayCounter.Value, interpolator.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedHazardRateCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedHazardRateCurve.Value.dates_)
    let _discounts                                 = cell (fun () -> _InterpolatedHazardRateCurve.Value.discounts())
    let _hazardRates                               = cell (fun () -> _InterpolatedHazardRateCurve.Value.hazardRates())
    let _interpolation_                            = cell (fun () -> _InterpolatedHazardRateCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedHazardRateCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedHazardRateCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedHazardRateCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedHazardRateCurve.Value.setupInterpolation()
                                                                     _InterpolatedHazardRateCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedHazardRateCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedHazardRateCurve.Value.times_)
    do this.Bind(_InterpolatedHazardRateCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.hazardRates                        = _hazardRates 
    member this.dayCounter                         = _dayCounter 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.HazardRates                        = _hazardRates
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
