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
type InterpolatedZeroCurveModel<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedZeroCurve<'Interpolator>> ()
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
    let _InterpolatedZeroCurve                     = cell (fun () -> new InterpolatedZeroCurve<'Interpolator> (dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedZeroCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedZeroCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedZeroCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedZeroCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.dates_)
    let _interpolation_                            = cell (fun () -> _InterpolatedZeroCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedZeroCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedZeroCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedZeroCurve.Value.setupInterpolation()
                                                                     _InterpolatedZeroCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedZeroCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.times_)
    let _zeroRates                                 = cell (fun () -> _InterpolatedZeroCurve.Value.zeroRates())
    do this.Bind(_InterpolatedZeroCurve)

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
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.ZeroRates                          = _zeroRates
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedZeroCurveModel1<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , yields                                       : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , interpolator                                 : ICell<'Interpolator>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    , refDate                                      : ICell<Date>
    ) as this =

    inherit Model<InterpolatedZeroCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _yields                                    = yields
    let _dayCounter                                = dayCounter
    let _interpolator                              = interpolator
    let _compounding                               = compounding
    let _frequency                                 = frequency
    let _refDate                                   = refDate
(*
    Functions
*)
    let _InterpolatedZeroCurve                     = cell (fun () -> new InterpolatedZeroCurve<'Interpolator> (dates.Value, yields.Value, dayCounter.Value, interpolator.Value, compounding.Value, frequency.Value, refDate.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedZeroCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedZeroCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedZeroCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedZeroCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.dates_)
    let _interpolation_                            = cell (fun () -> _InterpolatedZeroCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedZeroCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedZeroCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedZeroCurve.Value.setupInterpolation()
                                                                     _InterpolatedZeroCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedZeroCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.times_)
    let _zeroRates                                 = cell (fun () -> _InterpolatedZeroCurve.Value.zeroRates())
    do this.Bind(_InterpolatedZeroCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.yields                             = _yields 
    member this.dayCounter                         = _dayCounter 
    member this.interpolator                       = _interpolator 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.refDate                            = _refDate 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.ZeroRates                          = _zeroRates
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedZeroCurveModel2<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , yields                                       : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , interpolator                                 : ICell<'Interpolator>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    ) as this =

    inherit Model<InterpolatedZeroCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _yields                                    = yields
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _interpolator                              = interpolator
    let _compounding                               = compounding
    let _frequency                                 = frequency
(*
    Functions
*)
    let _InterpolatedZeroCurve                     = cell (fun () -> new InterpolatedZeroCurve<'Interpolator> (dates.Value, yields.Value, dayCounter.Value, calendar.Value, interpolator.Value, compounding.Value, frequency.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedZeroCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedZeroCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedZeroCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedZeroCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.dates_)
    let _interpolation_                            = cell (fun () -> _InterpolatedZeroCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedZeroCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedZeroCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedZeroCurve.Value.setupInterpolation()
                                                                     _InterpolatedZeroCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedZeroCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.times_)
    let _zeroRates                                 = cell (fun () -> _InterpolatedZeroCurve.Value.zeroRates())
    do this.Bind(_InterpolatedZeroCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.yields                             = _yields 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.interpolator                       = _interpolator 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.ZeroRates                          = _zeroRates
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedZeroCurveModel3<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( dates                                        : ICell<Generic.List<Date>>
    , yields                                       : ICell<Generic.List<double>>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    ) as this =

    inherit Model<InterpolatedZeroCurve<'Interpolator>> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _yields                                    = yields
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _jumps                                     = jumps
    let _jumpDates                                 = jumpDates
    let _interpolator                              = interpolator
    let _compounding                               = compounding
    let _frequency                                 = frequency
(*
    Functions
*)
    let _InterpolatedZeroCurve                     = cell (fun () -> new InterpolatedZeroCurve<'Interpolator> (dates.Value, yields.Value, dayCounter.Value, calendar.Value, jumps.Value, jumpDates.Value, interpolator.Value, compounding.Value, frequency.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedZeroCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedZeroCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedZeroCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedZeroCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.dates_)
    let _interpolation_                            = cell (fun () -> _InterpolatedZeroCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedZeroCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedZeroCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedZeroCurve.Value.setupInterpolation()
                                                                     _InterpolatedZeroCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedZeroCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.times_)
    let _zeroRates                                 = cell (fun () -> _InterpolatedZeroCurve.Value.zeroRates())
    do this.Bind(_InterpolatedZeroCurve)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.yields                             = _yields 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.jumps                              = _jumps 
    member this.jumpDates                          = _jumpDates 
    member this.interpolator                       = _interpolator 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.ZeroRates                          = _zeroRates
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedZeroCurveModel4<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedZeroCurve<'Interpolator>> ()
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
    let _InterpolatedZeroCurve                     = cell (fun () -> new InterpolatedZeroCurve<'Interpolator> (settlementDays.Value, calendar.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedZeroCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedZeroCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedZeroCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedZeroCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.dates_)
    let _interpolation_                            = cell (fun () -> _InterpolatedZeroCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedZeroCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedZeroCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedZeroCurve.Value.setupInterpolation()
                                                                     _InterpolatedZeroCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedZeroCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.times_)
    let _zeroRates                                 = cell (fun () -> _InterpolatedZeroCurve.Value.zeroRates())
    do this.Bind(_InterpolatedZeroCurve)

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
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.ZeroRates                          = _zeroRates
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedZeroCurveModel5<'Interpolator when 'Interpolator : not struct and 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , jumps                                        : ICell<Generic.List<Handle<Quote>>>
    , jumpDates                                    : ICell<Generic.List<Date>>
    , interpolator                                 : ICell<'Interpolator>
    ) as this =

    inherit Model<InterpolatedZeroCurve<'Interpolator>> ()
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
    let _InterpolatedZeroCurve                     = cell (fun () -> new InterpolatedZeroCurve<'Interpolator> (referenceDate.Value, dayCounter.Value, jumps.Value, jumpDates.Value, interpolator.Value))
    let _Clone                                     = cell (fun () -> _InterpolatedZeroCurve.Value.Clone())
    let _data                                      = cell (fun () -> _InterpolatedZeroCurve.Value.data())
    let _data_                                     = cell (fun () -> _InterpolatedZeroCurve.Value.data_)
    let _dates                                     = cell (fun () -> _InterpolatedZeroCurve.Value.dates())
    let _dates_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.dates_)
    let _interpolation_                            = cell (fun () -> _InterpolatedZeroCurve.Value.interpolation_)
    let _interpolator_                             = cell (fun () -> _InterpolatedZeroCurve.Value.interpolator_)
    let _maxDate                                   = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate())
    let _maxDate_                                  = cell (fun () -> _InterpolatedZeroCurve.Value.maxDate_)
    let _nodes                                     = cell (fun () -> _InterpolatedZeroCurve.Value.nodes())
    let _setupInterpolation                        = cell (fun () -> _InterpolatedZeroCurve.Value.setupInterpolation()
                                                                     _InterpolatedZeroCurve.Value)
    let _times                                     = cell (fun () -> _InterpolatedZeroCurve.Value.times())
    let _times_                                    = cell (fun () -> _InterpolatedZeroCurve.Value.times_)
    let _zeroRates                                 = cell (fun () -> _InterpolatedZeroCurve.Value.zeroRates())
    do this.Bind(_InterpolatedZeroCurve)

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
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.ZeroRates                          = _zeroRates
