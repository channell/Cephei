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
type SviInterpolatedSmileSectionModel
    ( optionDate                                   : ICell<Date>
    , forward                                      : ICell<double>
    , strikes                                      : ICell<Generic.List<double>>
    , hasFloatingStrikes                           : ICell<bool>
    , atmVolatility                                : ICell<double>
    , volHandles                                   : ICell<Generic.List<double>>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , sigma                                        : ICell<double>
    , rho                                          : ICell<double>
    , m                                            : ICell<double>
    , isAFixed                                     : ICell<bool>
    , isBFixed                                     : ICell<bool>
    , isSigmaFixed                                 : ICell<bool>
    , isRhoFixed                                   : ICell<bool>
    , isMFixed                                     : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , Method                                       : ICell<OptimizationMethod>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<SviInterpolatedSmileSection> ()
(*
    Parameters
*)
    let _optionDate                                = optionDate
    let _forward                                   = forward
    let _strikes                                   = strikes
    let _hasFloatingStrikes                        = hasFloatingStrikes
    let _atmVolatility                             = atmVolatility
    let _volHandles                                = volHandles
    let _a                                         = a
    let _b                                         = b
    let _sigma                                     = sigma
    let _rho                                       = rho
    let _m                                         = m
    let _isAFixed                                  = isAFixed
    let _isBFixed                                  = isBFixed
    let _isSigmaFixed                              = isSigmaFixed
    let _isRhoFixed                                = isRhoFixed
    let _isMFixed                                  = isMFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _Method                                    = Method
    let _dc                                        = dc
(*
    Functions
*)
    let _SviInterpolatedSmileSection               = cell (fun () -> new SviInterpolatedSmileSection (optionDate.Value, forward.Value, strikes.Value, hasFloatingStrikes.Value, atmVolatility.Value, volHandles.Value, a.Value, b.Value, sigma.Value, rho.Value, m.Value, isAFixed.Value, isBFixed.Value, isSigmaFixed.Value, isRhoFixed.Value, isMFixed.Value, vegaWeighted.Value, endCriteria.Value, Method.Value, dc.Value))
    let _a                                         = triv (fun () -> _SviInterpolatedSmileSection.Value.a())
    let _atmLevel                                  = triv (fun () -> _SviInterpolatedSmileSection.Value.atmLevel())
    let _b                                         = triv (fun () -> _SviInterpolatedSmileSection.Value.b())
    let _endCriteria                               = triv (fun () -> _SviInterpolatedSmileSection.Value.endCriteria())
    let _m                                         = triv (fun () -> _SviInterpolatedSmileSection.Value.m())
    let _maxError                                  = triv (fun () -> _SviInterpolatedSmileSection.Value.maxError())
    let _maxStrike                                 = triv (fun () -> _SviInterpolatedSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _SviInterpolatedSmileSection.Value.minStrike())
    let _rho                                       = triv (fun () -> _SviInterpolatedSmileSection.Value.rho())
    let _rmsError                                  = triv (fun () -> _SviInterpolatedSmileSection.Value.rmsError())
    let _sigma                                     = triv (fun () -> _SviInterpolatedSmileSection.Value.sigma())
    let _update                                    = triv (fun () -> _SviInterpolatedSmileSection.Value.update()
                                                                     _SviInterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> _SviInterpolatedSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _SviInterpolatedSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _SviInterpolatedSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _SviInterpolatedSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _SviInterpolatedSmileSection.Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _SviInterpolatedSmileSection.Value.volatilityType())
    do this.Bind(_SviInterpolatedSmileSection)

(* 
    Externally visible/bindable properties
*)
    member this.optionDate                         = _optionDate 
    member this.forward                            = _forward 
    member this.strikes                            = _strikes 
    member this.hasFloatingStrikes                 = _hasFloatingStrikes 
    member this.atmVolatility                      = _atmVolatility 
    member this.volHandles                         = _volHandles 
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.sigma                              = _sigma 
    member this.rho                                = _rho 
    member this.m                                  = _m 
    member this.isAFixed                           = _isAFixed 
    member this.isBFixed                           = _isBFixed 
    member this.isSigmaFixed                       = _isSigmaFixed 
    member this.isRhoFixed                         = _isRhoFixed 
    member this.isMFixed                           = _isMFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.Method                             = _Method 
    member this.dc                                 = _dc 
    member this.A                                  = _a
    member this.AtmLevel                           = _atmLevel
    member this.B                                  = _b
    member this.EndCriteria                        = _endCriteria
    member this.M                                  = _m
    member this.MaxError                           = _maxError
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Rho                                = _rho
    member this.RmsError                           = _rmsError
    member this.Sigma                              = _sigma
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

! \name Constructors
@{ ! all market data are quotes
  </summary> *)
[<AutoSerializable(true)>]
type SviInterpolatedSmileSectionModel1
    ( optionDate                                   : ICell<Date>
    , forward                                      : ICell<Handle<Quote>>
    , strikes                                      : ICell<Generic.List<double>>
    , hasFloatingStrikes                           : ICell<bool>
    , atmVolatility                                : ICell<Handle<Quote>>
    , volHandles                                   : ICell<Generic.List<Handle<Quote>>>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , sigma                                        : ICell<double>
    , rho                                          : ICell<double>
    , m                                            : ICell<double>
    , isAFixed                                     : ICell<bool>
    , isBFixed                                     : ICell<bool>
    , isSigmaFixed                                 : ICell<bool>
    , isRhoFixed                                   : ICell<bool>
    , isMFixed                                     : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , Method                                       : ICell<OptimizationMethod>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<SviInterpolatedSmileSection> ()
(*
    Parameters
*)
    let _optionDate                                = optionDate
    let _forward                                   = forward
    let _strikes                                   = strikes
    let _hasFloatingStrikes                        = hasFloatingStrikes
    let _atmVolatility                             = atmVolatility
    let _volHandles                                = volHandles
    let _a                                         = a
    let _b                                         = b
    let _sigma                                     = sigma
    let _rho                                       = rho
    let _m                                         = m
    let _isAFixed                                  = isAFixed
    let _isBFixed                                  = isBFixed
    let _isSigmaFixed                              = isSigmaFixed
    let _isRhoFixed                                = isRhoFixed
    let _isMFixed                                  = isMFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _Method                                    = Method
    let _dc                                        = dc
(*
    Functions
*)
    let _SviInterpolatedSmileSection               = cell (fun () -> new SviInterpolatedSmileSection (optionDate.Value, forward.Value, strikes.Value, hasFloatingStrikes.Value, atmVolatility.Value, volHandles.Value, a.Value, b.Value, sigma.Value, rho.Value, m.Value, isAFixed.Value, isBFixed.Value, isSigmaFixed.Value, isRhoFixed.Value, isMFixed.Value, vegaWeighted.Value, endCriteria.Value, Method.Value, dc.Value))
    let _a                                         = triv (fun () -> _SviInterpolatedSmileSection.Value.a())
    let _atmLevel                                  = triv (fun () -> _SviInterpolatedSmileSection.Value.atmLevel())
    let _b                                         = triv (fun () -> _SviInterpolatedSmileSection.Value.b())
    let _endCriteria                               = triv (fun () -> _SviInterpolatedSmileSection.Value.endCriteria())
    let _m                                         = triv (fun () -> _SviInterpolatedSmileSection.Value.m())
    let _maxError                                  = triv (fun () -> _SviInterpolatedSmileSection.Value.maxError())
    let _maxStrike                                 = triv (fun () -> _SviInterpolatedSmileSection.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _SviInterpolatedSmileSection.Value.minStrike())
    let _rho                                       = triv (fun () -> _SviInterpolatedSmileSection.Value.rho())
    let _rmsError                                  = triv (fun () -> _SviInterpolatedSmileSection.Value.rmsError())
    let _sigma                                     = triv (fun () -> _SviInterpolatedSmileSection.Value.sigma())
    let _update                                    = triv (fun () -> _SviInterpolatedSmileSection.Value.update()
                                                                     _SviInterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> _SviInterpolatedSmileSection.Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> _SviInterpolatedSmileSection.Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> _SviInterpolatedSmileSection.Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> _SviInterpolatedSmileSection.Value.referenceDate())
    let _shift                                     = triv (fun () -> _SviInterpolatedSmileSection.Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolatedSmileSection.Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> _SviInterpolatedSmileSection.Value.volatilityType())
    do this.Bind(_SviInterpolatedSmileSection)

(* 
    Externally visible/bindable properties
*)
    member this.optionDate                         = _optionDate 
    member this.forward                            = _forward 
    member this.strikes                            = _strikes 
    member this.hasFloatingStrikes                 = _hasFloatingStrikes 
    member this.atmVolatility                      = _atmVolatility 
    member this.volHandles                         = _volHandles 
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.sigma                              = _sigma 
    member this.rho                                = _rho 
    member this.m                                  = _m 
    member this.isAFixed                           = _isAFixed 
    member this.isBFixed                           = _isBFixed 
    member this.isSigmaFixed                       = _isSigmaFixed 
    member this.isRhoFixed                         = _isRhoFixed 
    member this.isMFixed                           = _isMFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.Method                             = _Method 
    member this.dc                                 = _dc 
    member this.A                                  = _a
    member this.AtmLevel                           = _atmLevel
    member this.B                                  = _b
    member this.EndCriteria                        = _endCriteria
    member this.M                                  = _m
    member this.MaxError                           = _maxError
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Rho                                = _rho
    member this.RmsError                           = _rmsError
    member this.Sigma                              = _sigma
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
