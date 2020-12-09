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

! \name Constructors
@{ ! all market data are quotes
  </summary> *)
[<AutoSerializable(true)>]
type SabrInterpolatedSmileSectionModel
    ( optionDate                                   : ICell<Date>
    , forward                                      : ICell<Handle<Quote>>
    , strikes                                      : ICell<Generic.List<double>>
    , hasFloatingStrikes                           : ICell<bool>
    , atmVolatility                                : ICell<Handle<Quote>>
    , volHandles                                   : ICell<Generic.List<Handle<Quote>>>
    , alpha                                        : ICell<double>
    , beta                                         : ICell<double>
    , nu                                           : ICell<double>
    , rho                                          : ICell<double>
    , isAlphaFixed                                 : ICell<bool>
    , isBetaFixed                                  : ICell<bool>
    , isNuFixed                                    : ICell<bool>
    , isRhoFixed                                   : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , Method                                       : ICell<OptimizationMethod>
    , dc                                           : ICell<DayCounter>
    , shift                                        : ICell<double>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SabrInterpolatedSmileSection> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _optionDate                                = optionDate
    let _forward                                   = forward
    let _strikes                                   = strikes
    let _hasFloatingStrikes                        = hasFloatingStrikes
    let _atmVolatility                             = atmVolatility
    let _volHandles                                = volHandles
    let _alpha                                     = alpha
    let _beta                                      = beta
    let _nu                                        = nu
    let _rho                                       = rho
    let _isAlphaFixed                              = isAlphaFixed
    let _isBetaFixed                               = isBetaFixed
    let _isNuFixed                                 = isNuFixed
    let _isRhoFixed                                = isRhoFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _Method                                    = Method
    let _dc                                        = dc
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _SabrInterpolatedSmileSection              = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SabrInterpolatedSmileSection (optionDate.Value, forward.Value, strikes.Value, hasFloatingStrikes.Value, atmVolatility.Value, volHandles.Value, alpha.Value, beta.Value, nu.Value, rho.Value, isAlphaFixed.Value, isBetaFixed.Value, isNuFixed.Value, isRhoFixed.Value, vegaWeighted.Value, endCriteria.Value, Method.Value, dc.Value, shift.Value))))
    let _alpha                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.alpha())
    let _atmLevel                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.atmLevel())
    let _beta                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.beta())
    let _endCriteria                               = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.endCriteria())
    let _maxError                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.maxError())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.minStrike())
    let _nu                                        = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.nu())
    let _rho                                       = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.rho())
    let _rmsError                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.rmsError())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.update()
                                                                     _SabrInterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.referenceDate())
    let _shift                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.volatilityType())
    do this.Bind(_SabrInterpolatedSmileSection)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SabrInterpolatedSmileSectionModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SabrInterpolatedSmileSection <- v
    static member Cast (p : ICell<SabrInterpolatedSmileSection>) = 
        if p :? SabrInterpolatedSmileSectionModel then 
            p :?> SabrInterpolatedSmileSectionModel
        else
            let o = new SabrInterpolatedSmileSectionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.optionDate                         = _optionDate 
    member this.forward                            = _forward 
    member this.strikes                            = _strikes 
    member this.hasFloatingStrikes                 = _hasFloatingStrikes 
    member this.atmVolatility                      = _atmVolatility 
    member this.volHandles                         = _volHandles 
    member this.alpha                              = _alpha 
    member this.beta                               = _beta 
    member this.nu                                 = _nu 
    member this.rho                                = _rho 
    member this.isAlphaFixed                       = _isAlphaFixed 
    member this.isBetaFixed                        = _isBetaFixed 
    member this.isNuFixed                          = _isNuFixed 
    member this.isRhoFixed                         = _isRhoFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.Method                             = _Method 
    member this.dc                                 = _dc 
    member this.shift                              = _shift 
    member this.Alpha                              = _alpha
    member this.AtmLevel                           = _atmLevel
    member this.Beta                               = _beta
    member this.EndCriteria                        = _endCriteria
    member this.MaxError                           = _maxError
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Nu                                 = _nu
    member this.Rho                                = _rho
    member this.RmsError                           = _rmsError
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
type SabrInterpolatedSmileSectionModel1
    ( optionDate                                   : ICell<Date>
    , forward                                      : ICell<double>
    , strikes                                      : ICell<Generic.List<double>>
    , hasFloatingStrikes                           : ICell<bool>
    , atmVolatility                                : ICell<double>
    , volHandles                                   : ICell<Generic.List<double>>
    , alpha                                        : ICell<double>
    , beta                                         : ICell<double>
    , nu                                           : ICell<double>
    , rho                                          : ICell<double>
    , isAlphaFixed                                 : ICell<bool>
    , isBetaFixed                                  : ICell<bool>
    , isNuFixed                                    : ICell<bool>
    , isRhoFixed                                   : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , Method                                       : ICell<OptimizationMethod>
    , dc                                           : ICell<DayCounter>
    , shift                                        : ICell<double>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SabrInterpolatedSmileSection> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _optionDate                                = optionDate
    let _forward                                   = forward
    let _strikes                                   = strikes
    let _hasFloatingStrikes                        = hasFloatingStrikes
    let _atmVolatility                             = atmVolatility
    let _volHandles                                = volHandles
    let _alpha                                     = alpha
    let _beta                                      = beta
    let _nu                                        = nu
    let _rho                                       = rho
    let _isAlphaFixed                              = isAlphaFixed
    let _isBetaFixed                               = isBetaFixed
    let _isNuFixed                                 = isNuFixed
    let _isRhoFixed                                = isRhoFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _Method                                    = Method
    let _dc                                        = dc
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _SabrInterpolatedSmileSection              = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SabrInterpolatedSmileSection (optionDate.Value, forward.Value, strikes.Value, hasFloatingStrikes.Value, atmVolatility.Value, volHandles.Value, alpha.Value, beta.Value, nu.Value, rho.Value, isAlphaFixed.Value, isBetaFixed.Value, isNuFixed.Value, isRhoFixed.Value, vegaWeighted.Value, endCriteria.Value, Method.Value, dc.Value, shift.Value))))
    let _alpha                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.alpha())
    let _atmLevel                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.atmLevel())
    let _beta                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.beta())
    let _endCriteria                               = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.endCriteria())
    let _maxError                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.maxError())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.minStrike())
    let _nu                                        = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.nu())
    let _rho                                       = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.rho())
    let _rmsError                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.rmsError())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.update()
                                                                     _SabrInterpolatedSmileSection.Value)
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.referenceDate())
    let _shift                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.shift())
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrInterpolatedSmileSection).Value.volatilityType())
    do this.Bind(_SabrInterpolatedSmileSection)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SabrInterpolatedSmileSectionModel1(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SabrInterpolatedSmileSection <- v
    static member Cast (p : ICell<SabrInterpolatedSmileSection>) = 
        if p :? SabrInterpolatedSmileSectionModel1 then 
            p :?> SabrInterpolatedSmileSectionModel1
        else
            let o = new SabrInterpolatedSmileSectionModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.optionDate                         = _optionDate 
    member this.forward                            = _forward 
    member this.strikes                            = _strikes 
    member this.hasFloatingStrikes                 = _hasFloatingStrikes 
    member this.atmVolatility                      = _atmVolatility 
    member this.volHandles                         = _volHandles 
    member this.alpha                              = _alpha 
    member this.beta                               = _beta 
    member this.nu                                 = _nu 
    member this.rho                                = _rho 
    member this.isAlphaFixed                       = _isAlphaFixed 
    member this.isBetaFixed                        = _isBetaFixed 
    member this.isNuFixed                          = _isNuFixed 
    member this.isRhoFixed                         = _isRhoFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.Method                             = _Method 
    member this.dc                                 = _dc 
    member this.shift                              = _shift 
    member this.Alpha                              = _alpha
    member this.AtmLevel                           = _atmLevel
    member this.Beta                               = _beta
    member this.EndCriteria                        = _endCriteria
    member this.MaxError                           = _maxError
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.Nu                                 = _nu
    member this.Rho                                = _rho
    member this.RmsError                           = _rmsError
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
