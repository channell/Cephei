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
type FlatSmileSectionModel
    ( exerciseTime                                 : ICell<double>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , atmLevel                                     : ICell<Nullable<double>>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FlatSmileSection> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _exerciseTime                              = exerciseTime
    let _vol                                       = vol
    let _dc                                        = dc
    let _atmLevel                                  = atmLevel
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _FlatSmileSection                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FlatSmileSection (exerciseTime.Value, vol.Value, dc.Value, atmLevel.Value, Type.Value, shift.Value))))
    let _atmLevel                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.atmLevel())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.minStrike())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.referenceDate())
    let _shift                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.shift())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.update()
                                                                     _FlatSmileSection.Value)
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.volatilityType())
    do this.Bind(_FlatSmileSection)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FlatSmileSectionModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _FlatSmileSection <- v
    static member Cast (p : ICell<FlatSmileSection>) = 
        if p :? FlatSmileSectionModel then 
            p :?> FlatSmileSectionModel
        else
            let o = new FlatSmileSectionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.exerciseTime                       = _exerciseTime 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.atmLevel                           = _atmLevel 
    member this.Type                               = _Type 
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
type FlatSmileSectionModel1
    ( d                                            : ICell<Date>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , referenceDate                                : ICell<Date>
    , atmLevel                                     : ICell<Nullable<double>>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FlatSmileSection> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _d                                         = d
    let _vol                                       = vol
    let _dc                                        = dc
    let _referenceDate                             = referenceDate
    let _atmLevel                                  = atmLevel
    let _Type                                      = Type
    let _shift                                     = shift
(*
    Functions
*)
    let mutable
        _FlatSmileSection                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new FlatSmileSection (d.Value, vol.Value, dc.Value, referenceDate.Value, atmLevel.Value, Type.Value, shift.Value))))
    let _atmLevel                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.atmLevel())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.minStrike())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.dayCounter())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _exerciseDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.exerciseTime())
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _referenceDate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.referenceDate())
    let _shift                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.shift())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.update()
                                                                     _FlatSmileSection.Value)
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.volatility(strike.Value))
    let _volatilityType                            = triv (fun () -> (curryEvaluationDate _evaluationDate _FlatSmileSection).Value.volatilityType())
    do this.Bind(_FlatSmileSection)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new FlatSmileSectionModel1(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FlatSmileSection <- v
    static member Cast (p : ICell<FlatSmileSection>) = 
        if p :? FlatSmileSectionModel1 then 
            p :?> FlatSmileSectionModel1
        else
            let o = new FlatSmileSectionModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d                                  = _d 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.referenceDate                      = _referenceDate 
    member this.atmLevel                           = _atmLevel 
    member this.Type                               = _Type 
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
