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
type InterpolatedSmileSectionModel<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( d                                            : ICell<Date>
    , strikes                                      : ICell<Generic.List<double>>
    , stdDevs                                      : ICell<Generic.List<double>>
    , atmLevel                                     : ICell<double>
    , dc                                           : ICell<DayCounter>
    , interpolator                                 : ICell<'Interpolator>
    , referenceDate                                : ICell<Date>
    , shift                                        : ICell<double>
    ) as this =

    inherit Model<InterpolatedSmileSection<'Interpolator>> ()
(*
    Parameters
*)
    let _d                                         = d
    let _strikes                                   = strikes
    let _stdDevs                                   = stdDevs
    let _atmLevel                                  = atmLevel
    let _dc                                        = dc
    let _interpolator                              = interpolator
    let _referenceDate                             = referenceDate
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _InterpolatedSmileSection                  = cell (fun () -> new InterpolatedSmileSection<'Interpolator> (d.Value, strikes.Value, stdDevs.Value, atmLevel.Value, dc.Value, interpolator.Value, referenceDate.Value, shift.Value))
    let _atmLevel                                  = triv (fun () -> _InterpolatedSmileSection.Value.atmLevel())
    let _Clone                                     = triv (fun () -> _InterpolatedSmileSection.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedSmileSection.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedSmileSection.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedSmileSection.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedSmileSection.Value.dates_)
    let _discounts                                 = triv (fun () -> _InterpolatedSmileSection.Value.discounts())
    let _interpolation_                            = triv (fun () -> _InterpolatedSmileSection.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedSmileSection.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedSmileSection.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedSmileSection.Value.maxDate_)
    let _maxStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.minStrike())
    let _nodes                                     = triv (fun () -> _InterpolatedSmileSection.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedSmileSection.Value.setupInterpolation()
                                                                     _InterpolatedSmileSection.Value)
    let _times                                     = triv (fun () -> _InterpolatedSmileSection.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedSmileSection.Value.times_)
    let _update                                    = triv (fun () -> _InterpolatedSmileSection.Value.update()
                                                                     _InterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> _InterpolatedSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _InterpolatedSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _InterpolatedSmileSection.Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _InterpolatedSmileSection.Value.volatilityType())
    do this.Bind(_InterpolatedSmileSection)

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.strikes                            = _strikes 
    member this.stdDevs                            = _stdDevs 
    member this.atmLevel                           = _atmLevel 
    member this.dc                                 = _dc 
    member this.interpolator                       = _interpolator 
    member this.referenceDate                      = _referenceDate 
    member this.shift                              = _shift 
    member this.AtmLevel                           = _atmLevel
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Update                             = _update
    member this.DayCounter                         = _dayCounter
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
    member this.VolatilityType                     = _volatilityType
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedSmileSectionModel1<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( d                                            : ICell<Date>
    , strikes                                      : ICell<Generic.List<double>>
    , stdDevHandles                                : ICell<Generic.List<Handle<Quote>>>
    , atmLevel                                     : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    , interpolator                                 : ICell<'Interpolator>
    , referenceDate                                : ICell<Date>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    ) as this =

    inherit Model<InterpolatedSmileSection<'Interpolator>> ()
(*
    Parameters
*)
    let _d                                         = d
    let _strikes                                   = strikes
    let _stdDevHandles                             = stdDevHandles
    let _atmLevel                                  = atmLevel
    let _dc                                        = dc
    let _interpolator                              = interpolator
    let _referenceDate                             = referenceDate
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _InterpolatedSmileSection                  = cell (fun () -> new InterpolatedSmileSection<'Interpolator> (d.Value, strikes.Value, stdDevHandles.Value, atmLevel.Value, dc.Value, interpolator.Value, referenceDate.Value, Type.Value, shift.Value))
    let _atmLevel                                  = triv (fun () -> _InterpolatedSmileSection.Value.atmLevel())
    let _Clone                                     = triv (fun () -> _InterpolatedSmileSection.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedSmileSection.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedSmileSection.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedSmileSection.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedSmileSection.Value.dates_)
    let _discounts                                 = triv (fun () -> _InterpolatedSmileSection.Value.discounts())
    let _interpolation_                            = triv (fun () -> _InterpolatedSmileSection.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedSmileSection.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedSmileSection.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedSmileSection.Value.maxDate_)
    let _maxStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.minStrike())
    let _nodes                                     = triv (fun () -> _InterpolatedSmileSection.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedSmileSection.Value.setupInterpolation()
                                                                     _InterpolatedSmileSection.Value)
    let _times                                     = triv (fun () -> _InterpolatedSmileSection.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedSmileSection.Value.times_)
    let _update                                    = triv (fun () -> _InterpolatedSmileSection.Value.update()
                                                                     _InterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> _InterpolatedSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _InterpolatedSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _InterpolatedSmileSection.Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _InterpolatedSmileSection.Value.volatilityType())
    do this.Bind(_InterpolatedSmileSection)

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.strikes                            = _strikes 
    member this.stdDevHandles                      = _stdDevHandles 
    member this.atmLevel                           = _atmLevel 
    member this.dc                                 = _dc 
    member this.interpolator                       = _interpolator 
    member this.referenceDate                      = _referenceDate 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.AtmLevel                           = _atmLevel
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Update                             = _update
    member this.DayCounter                         = _dayCounter
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
    member this.VolatilityType                     = _volatilityType
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedSmileSectionModel2<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( timeToExpiry                                 : ICell<double>
    , strikes                                      : ICell<Generic.List<double>>
    , stdDevs                                      : ICell<Generic.List<double>>
    , atmLevel                                     : ICell<double>
    , interpolator                                 : ICell<'Interpolator>
    , dc                                           : ICell<DayCounter>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    ) as this =

    inherit Model<InterpolatedSmileSection<'Interpolator>> ()
(*
    Parameters
*)
    let _timeToExpiry                              = timeToExpiry
    let _strikes                                   = strikes
    let _stdDevs                                   = stdDevs
    let _atmLevel                                  = atmLevel
    let _interpolator                              = interpolator
    let _dc                                        = dc
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _InterpolatedSmileSection                  = cell (fun () -> new InterpolatedSmileSection<'Interpolator> (timeToExpiry.Value, strikes.Value, stdDevs.Value, atmLevel.Value, interpolator.Value, dc.Value, Type.Value, shift.Value))
    let _atmLevel                                  = triv (fun () -> _InterpolatedSmileSection.Value.atmLevel())
    let _Clone                                     = triv (fun () -> _InterpolatedSmileSection.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedSmileSection.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedSmileSection.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedSmileSection.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedSmileSection.Value.dates_)
    let _discounts                                 = triv (fun () -> _InterpolatedSmileSection.Value.discounts())
    let _interpolation_                            = triv (fun () -> _InterpolatedSmileSection.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedSmileSection.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedSmileSection.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedSmileSection.Value.maxDate_)
    let _maxStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.minStrike())
    let _nodes                                     = triv (fun () -> _InterpolatedSmileSection.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedSmileSection.Value.setupInterpolation()
                                                                     _InterpolatedSmileSection.Value)
    let _times                                     = triv (fun () -> _InterpolatedSmileSection.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedSmileSection.Value.times_)
    let _update                                    = triv (fun () -> _InterpolatedSmileSection.Value.update()
                                                                     _InterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> _InterpolatedSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _InterpolatedSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _InterpolatedSmileSection.Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _InterpolatedSmileSection.Value.volatilityType())
    do this.Bind(_InterpolatedSmileSection)

(* 
    Externally visible/bindable properties
*)
    member this.timeToExpiry                       = _timeToExpiry 
    member this.strikes                            = _strikes 
    member this.stdDevs                            = _stdDevs 
    member this.atmLevel                           = _atmLevel 
    member this.interpolator                       = _interpolator 
    member this.dc                                 = _dc 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.AtmLevel                           = _atmLevel
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Update                             = _update
    member this.DayCounter                         = _dayCounter
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
    member this.VolatilityType                     = _volatilityType
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type InterpolatedSmileSectionModel3<'Interpolator when 'Interpolator :> IInterpolationFactory and 'Interpolator : (new : unit -> 'Interpolator)>
    ( timeToExpiry                                 : ICell<double>
    , strikes                                      : ICell<Generic.List<double>>
    , stdDevHandles                                : ICell<Generic.List<Handle<Quote>>>
    , atmLevel                                     : ICell<Handle<Quote>>
    , interpolator                                 : ICell<'Interpolator>
    , dc                                           : ICell<DayCounter>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    ) as this =

    inherit Model<InterpolatedSmileSection<'Interpolator>> ()
(*
    Parameters
*)
    let _timeToExpiry                              = timeToExpiry
    let _strikes                                   = strikes
    let _stdDevHandles                             = stdDevHandles
    let _atmLevel                                  = atmLevel
    let _interpolator                              = interpolator
    let _dc                                        = dc
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _InterpolatedSmileSection                  = cell (fun () -> new InterpolatedSmileSection<'Interpolator> (timeToExpiry.Value, strikes.Value, stdDevHandles.Value, atmLevel.Value, interpolator.Value, dc.Value, Type.Value, shift.Value))
    let _atmLevel                                  = triv (fun () -> _InterpolatedSmileSection.Value.atmLevel())
    let _Clone                                     = triv (fun () -> _InterpolatedSmileSection.Value.Clone())
    let _data                                      = triv (fun () -> _InterpolatedSmileSection.Value.data())
    let _data_                                     = triv (fun () -> _InterpolatedSmileSection.Value.data_)
    let _dates                                     = triv (fun () -> _InterpolatedSmileSection.Value.dates())
    let _dates_                                    = triv (fun () -> _InterpolatedSmileSection.Value.dates_)
    let _discounts                                 = triv (fun () -> _InterpolatedSmileSection.Value.discounts())
    let _interpolation_                            = triv (fun () -> _InterpolatedSmileSection.Value.interpolation_)
    let _interpolator_                             = triv (fun () -> _InterpolatedSmileSection.Value.interpolator_)
    let _maxDate                                   = triv (fun () -> _InterpolatedSmileSection.Value.maxDate())
    let _maxDate_                                  = triv (fun () -> _InterpolatedSmileSection.Value.maxDate_)
    let _maxStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _InterpolatedSmileSection.Value.minStrike())
    let _nodes                                     = triv (fun () -> _InterpolatedSmileSection.Value.nodes())
    let _setupInterpolation                        = triv (fun () -> _InterpolatedSmileSection.Value.setupInterpolation()
                                                                     _InterpolatedSmileSection.Value)
    let _times                                     = triv (fun () -> _InterpolatedSmileSection.Value.times())
    let _times_                                    = triv (fun () -> _InterpolatedSmileSection.Value.times_)
    let _update                                    = triv (fun () -> _InterpolatedSmileSection.Value.update()
                                                                     _InterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> _InterpolatedSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _InterpolatedSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _InterpolatedSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _InterpolatedSmileSection.Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _InterpolatedSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _InterpolatedSmileSection.Value.volatilityType())
    do this.Bind(_InterpolatedSmileSection)

(* 
    Externally visible/bindable properties
*)
    member this.timeToExpiry                       = _timeToExpiry 
    member this.strikes                            = _strikes 
    member this.stdDevHandles                      = _stdDevHandles 
    member this.atmLevel                           = _atmLevel 
    member this.interpolator                       = _interpolator 
    member this.dc                                 = _dc 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.AtmLevel                           = _atmLevel
    member this.Clone                              = _Clone
    member this.Data                               = _data
    member this.Data_                              = _data_
    member this.Dates                              = _dates
    member this.Dates_                             = _dates_
    member this.Discounts                          = _discounts
    member this.Interpolation_                     = _interpolation_
    member this.Interpolator_                      = _interpolator_
    member this.MaxDate                            = _maxDate
    member this.MaxDate_                           = _maxDate_
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Nodes                              = _nodes
    member this.SetupInterpolation                 = _setupInterpolation
    member this.Times                              = _times
    member this.Times_                             = _times_
    member this.Update                             = _update
    member this.DayCounter                         = _dayCounter
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
    member this.VolatilityType                     = _volatilityType
