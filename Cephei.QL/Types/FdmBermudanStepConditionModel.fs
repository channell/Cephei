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
type FdmBermudanStepConditionModel
    ( exerciseDates                                : ICell<Generic.List<Date>>
    , referenceDate                                : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , mesher                                       : ICell<FdmMesher>
    , calculator                                   : ICell<FdmInnerValueCalculator>
    ) as this =

    inherit Model<FdmBermudanStepCondition> ()
(*
    Parameters
*)
    let _exerciseDates                             = exerciseDates
    let _referenceDate                             = referenceDate
    let _dayCounter                                = dayCounter
    let _mesher                                    = mesher
    let _calculator                                = calculator
(*
    Functions
*)
    let _FdmBermudanStepCondition                  = cell (fun () -> new FdmBermudanStepCondition (exerciseDates.Value, referenceDate.Value, dayCounter.Value, mesher.Value, calculator.Value))
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmBermudanStepCondition.Value.applyTo(o.Value, t.Value)
                                                                     _FdmBermudanStepCondition.Value)
    let _exerciseTimes                             = triv (fun () -> _FdmBermudanStepCondition.Value.exerciseTimes())
    do this.Bind(_FdmBermudanStepCondition)

(* 
    Externally visible/bindable properties
*)
    member this.exerciseDates                      = _exerciseDates 
    member this.referenceDate                      = _referenceDate 
    member this.dayCounter                         = _dayCounter 
    member this.mesher                             = _mesher 
    member this.calculator                         = _calculator 
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
    member this.ExerciseTimes                      = _exerciseTimes
