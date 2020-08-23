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
type InterpolatedForwardCurveModel<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , forwards                                     : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedForwardCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _forwards                                  = forwards
    let _dayCounter                                = dayCounter
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedForwardCurve                  = cell (fun () -> new InterpolatedForwardCurve<'Interpolator> (dates.Value, forwards.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedForwardCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedForwardCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedForwardCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedForwardCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedForwardCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedForwardCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedForwardCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedForwardCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedForwardCurve.Value.setupInterpolation()
                                                                     _InterpolatedForwardCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedForwardCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.times_)
    do this.Bind(_InterpolatedForwardCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.forwards                           = _forwards 
    member this.dayCounter                         = _dayCounter 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Forwards                           = _forwards
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
type InterpolatedForwardCurveModel1<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , forwards                                     : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedForwardCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _forwards                                  = forwards
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedForwardCurve                  = cell (fun () -> new InterpolatedForwardCurve<'Interpolator> (dates.Value, forwards.Value, dayCounter.Value, calendar.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedForwardCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedForwardCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedForwardCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedForwardCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedForwardCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedForwardCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedForwardCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedForwardCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedForwardCurve.Value.setupInterpolation()
                                                                     _InterpolatedForwardCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedForwardCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.times_)
    do this.Bind(_InterpolatedForwardCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.forwards                           = _forwards 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Forwards                           = _forwards
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
type InterpolatedForwardCurveModel2<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , forwards                                     : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedForwardCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _forwards                                  = forwards
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedForwardCurve                  = cell (fun () -> new InterpolatedForwardCurve<'Interpolator> (dates.Value, forwards.Value, dayCounter.Value, calendar.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedForwardCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedForwardCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedForwardCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedForwardCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedForwardCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedForwardCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedForwardCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedForwardCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedForwardCurve.Value.setupInterpolation()
                                                                     _InterpolatedForwardCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedForwardCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.times_)
    do this.Bind(_InterpolatedForwardCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.forwards                           = _forwards 
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
    member this.Forwards                           = _forwards
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
type InterpolatedForwardCurveModel3<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedForwardCurve<'Interpolator>> ()
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
    let _InterpolatedForwardCurve                  = cell (fun () -> new InterpolatedForwardCurve<'Interpolator> (settlementDays.Value, calendar.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedForwardCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedForwardCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedForwardCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedForwardCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedForwardCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedForwardCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedForwardCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedForwardCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedForwardCurve.Value.setupInterpolation()
                                                                     _InterpolatedForwardCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedForwardCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.times_)
    do this.Bind(_InterpolatedForwardCurve)

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
    member this.Forwards                           = _forwards
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
type InterpolatedForwardCurveModel4<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedForwardCurve<'Interpolator>> ()
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
    let _InterpolatedForwardCurve                  = cell (fun () -> new InterpolatedForwardCurve<'Interpolator> (referenceDate.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedForwardCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedForwardCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedForwardCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedForwardCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedForwardCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedForwardCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedForwardCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedForwardCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedForwardCurve.Value.setupInterpolation()
                                                                     _InterpolatedForwardCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedForwardCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.times_)
    do this.Bind(_InterpolatedForwardCurve)

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
    member this.Forwards                           = _forwards
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
type InterpolatedForwardCurveModel5<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedForwardCurve<'Interpolator>> ()
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
    let _InterpolatedForwardCurve                  = cell (fun () -> new InterpolatedForwardCurve<'Interpolator> (dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedForwardCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedForwardCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedForwardCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedForwardCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedForwardCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedForwardCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedForwardCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedForwardCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedForwardCurve.Value.setupInterpolation()
                                                                     _InterpolatedForwardCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedForwardCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.times_)
    do this.Bind(_InterpolatedForwardCurve)

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
    member this.Forwards                           = _forwards
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
type InterpolatedForwardCurveModel6<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , forwards                                     : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedForwardCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _forwards                                  = forwards
    let _dayCounter                                = dayCounter
    let _interpolator                              = interpolator
(*
    Functions
*)
    let _InterpolatedForwardCurve                  = cell (fun () -> new InterpolatedForwardCurve<'Interpolator> (dates.Value, forwards.Value, dayCounter.Value, interpolator.Value))
    let _Clone                                     = triv (fun () -> _InterpolatedForwardCurve.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedForwardCurve.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedForwardCurve.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedForwardCurve.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.dates_)
    let _forwards                                  = triv (fun () -> _InterpolatedForwardCurve.Value.forwards())
    let _interpolation_                            = triv (fun () -> _InterpolatedForwardCurve.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedForwardCurve.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedForwardCurve.Value.maxDate_)
    let _nodes                                     = triv (fun () -> _InterpolatedForwardCurve.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedForwardCurve.Value.setupInterpolation()
                                                                     _InterpolatedForwardCurve.Value)
    let _times                                     = triv (fun () -> _InterpolatedForwardCurve.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedForwardCurve.Value.times_)
    do this.Bind(_InterpolatedForwardCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.forwards                           = _forwards 
    member this.dayCounter                         = _dayCounter 
    member this.interpolator                       = _interpolator 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Forwards                           = _forwards
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
