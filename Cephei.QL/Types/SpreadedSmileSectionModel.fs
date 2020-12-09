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
type SpreadedSmileSectionModel
    ( underlyingSection                            : ICell<SmileSection>
    , spread                                       : ICell<Handle<Quote>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SpreadedSmileSection> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _underlyingSection                         = underlyingSection
    let _spread                                    = spread
(*
    Functions
*)
    let mutable
        _SpreadedSmileSection                      = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SpreadedSmileSection (underlyingSection.Value, spread.Value))))
    let _atmLevel                                  = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.atmLevel())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.dayCounter())
    let _exerciseDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.exerciseDate())
    let _exerciseTime                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.exerciseTime())
    let _maxStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.maxStrike())
    let _minStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.minStrike())
    let _referenceDate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.referenceDate())
    let _shift                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.shift())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.update()
                                                                     _SpreadedSmileSection.Value)
    let _volatilityType                            = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.volatilityType())
    let _density                                   (strike : ICell<double>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.density(strike.Value, discount.Value, gap.Value))
    let _digitalOptionPrice                        (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>) (gap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.digitalOptionPrice(strike.Value, Type.Value, discount.Value, gap.Value))
    let _optionPrice                               (strike : ICell<double>) (Type : ICell<Option.Type>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.optionPrice(strike.Value, Type.Value, discount.Value))
    let _variance                                  (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.variance(strike.Value))
    let _vega                                      (strike : ICell<double>) (discount : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.vega(strike.Value, discount.Value))
    let _volatility                                (strike : ICell<double>) (volatilityType : ICell<VolatilityType>) (shift : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.volatility(strike.Value, volatilityType.Value, shift.Value))
    let _volatility1                               (strike : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SpreadedSmileSection).Value.volatility(strike.Value))
    do this.Bind(_SpreadedSmileSection)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SpreadedSmileSectionModel(null,null,null)
    member internal this.Inject v = _SpreadedSmileSection <- v
    static member Cast (p : ICell<SpreadedSmileSection>) = 
        if p :? SpreadedSmileSectionModel then 
            p :?> SpreadedSmileSectionModel
        else
            let o = new SpreadedSmileSectionModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.underlyingSection                  = _underlyingSection 
    member this.spread                             = _spread 
    member this.AtmLevel                           = _atmLevel
    member this.DayCounter                         = _dayCounter
    member this.ExerciseDate                       = _exerciseDate
    member this.ExerciseTime                       = _exerciseTime
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
    member this.ReferenceDate                      = _referenceDate
    member this.Shift                              = _shift
    member this.Update                             = _update
    member this.VolatilityType                     = _volatilityType
    member this.Density                            strike discount gap   
                                                   = _density strike discount gap 
    member this.DigitalOptionPrice                 strike Type discount gap   
                                                   = _digitalOptionPrice strike Type discount gap 
    member this.OptionPrice                        strike Type discount   
                                                   = _optionPrice strike Type discount 
    member this.Variance                           strike   
                                                   = _variance strike 
    member this.Vega                               strike discount   
                                                   = _vega strike discount 
    member this.Volatility                         strike volatilityType shift   
                                                   = _volatility strike volatilityType shift 
    member this.Volatility1                        strike   
                                                   = _volatility1 strike 
