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
type SabrSmileSectionModel
    ( d                                            : ICell<Date>
    , forward                                      : ICell<double>
    , sabrParams                                   : ICell<Generic.List<double>>
    , dc                                           : ICell<DayCounter>
    , volatilityType                               : ICell<VolatilityType>
    , shift                                        : ICell<double>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SabrSmileSection> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _d                                         = d
    let _forward                                   = forward
    let _sabrParams                                = sabrParams
    let _dc                                        = dc
    let _volatilityType                            = volatilityType
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _SabrSmileSection                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SabrSmileSection (d.Value, forward.Value, sabrParams.Value, dc.Value, volatilityType.Value, shift.Value))))
    let _atmLevel                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.atmLevel())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.minStrike())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.referenceDate())
    let _shift                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.shift())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.update()
                                                                     _SabrSmileSection.Value)
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.volatilityType())
    do this.Bind(_SabrSmileSection)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SabrSmileSectionModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _SabrSmileSection <- v
    static member Cast (p : ICell<SabrSmileSection>) = 
        if p :? SabrSmileSectionModel then 
            p :?> SabrSmileSectionModel
        else
            let o = new SabrSmileSectionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.forward                            = _forward 
    member this.sabrParams                         = _sabrParams 
    member this.dc                                 = _dc 
    member this.volatilityType                     = _volatilityType 
    member this.shift                              = _shift 
    member this.AtmLevel                           = _atmLevel
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
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
    member this.Update                             = _update
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
type SabrSmileSectionModel1
    ( timeToExpiry                                 : ICell<double>
    , forward                                      : ICell<double>
    , sabrParams                                   : ICell<Generic.List<double>>
    , volatilityType                               : ICell<VolatilityType>
    , shift                                        : ICell<double>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SabrSmileSection> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _timeToExpiry                              = timeToExpiry
    let _forward                                   = forward
    let _sabrParams                                = sabrParams
    let _volatilityType                            = volatilityType
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _SabrSmileSection                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SabrSmileSection (timeToExpiry.Value, forward.Value, sabrParams.Value, volatilityType.Value, shift.Value))))
    let _atmLevel                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.atmLevel())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.minStrike())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.referenceDate())
    let _shift                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.shift())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.update()
                                                                     _SabrSmileSection.Value)
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> (curryEvaluationDate _evaluationDate _SabrSmileSection).Value.volatilityType())
    do this.Bind(_SabrSmileSection)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SabrSmileSectionModel1(null,null,null,null,null,null)
    member internal this.Inject v = _SabrSmileSection <- v
    static member Cast (p : ICell<SabrSmileSection>) = 
        if p :? SabrSmileSectionModel1 then 
            p :?> SabrSmileSectionModel1
        else
            let o = new SabrSmileSectionModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.timeToExpiry                       = _timeToExpiry 
    member this.forward                            = _forward 
    member this.sabrParams                         = _sabrParams 
    member this.volatilityType                     = _volatilityType 
    member this.shift                              = _shift 
    member this.AtmLevel                           = _atmLevel
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
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
    member this.Update                             = _update
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
    member this.VolatilityType                     = _volatilityType
