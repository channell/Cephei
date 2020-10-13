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
  Constrained optimization problem
! default constructor public Problem(CostFunction costFunction, Constraint constraint, Vector initialValue = Array())
  </summary> *)
[<AutoSerializable(true)>]
type ProblemModel
    ( costFunction                                 : ICell<CostFunction>
    , Constraint                                   : ICell<Constraint>
    , initialValue                                 : ICell<Vector>
    ) as this =

    inherit Model<Problem> ()
(*
    Parameters
*)
    let _costFunction                              = costFunction
    let _Constraint                                = Constraint
    let _initialValue                              = initialValue
(*
    Functions
*)
    let _Problem                                   = cell (fun () -> new Problem (costFunction.Value, Constraint.Value, initialValue.Value))
    let _constraint                                = triv (fun () -> _Problem.Value.CONSTRAINT())
    let _costFunction                              = triv (fun () -> _Problem.Value.costFunction())
    let _currentValue                              = triv (fun () -> _Problem.Value.currentValue())
    let _functionEvaluation                        = triv (fun () -> _Problem.Value.functionEvaluation())
    let _functionValue                             = triv (fun () -> _Problem.Value.functionValue())
    let _gradient                                  (grad_f : ICell<Vector>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _Problem.Value.gradient(ref grad_f.Value, x.Value)
                                                                     _Problem.Value)
    let _gradientEvaluation                        = triv (fun () -> _Problem.Value.gradientEvaluation())
    let _gradientNormValue                         = triv (fun () -> _Problem.Value.gradientNormValue())
    let _reset                                     = triv (fun () -> _Problem.Value.reset()
                                                                     _Problem.Value)
    let _setCurrentValue                           (currentValue : ICell<Vector>)   
                                                   = triv (fun () -> _Problem.Value.setCurrentValue(currentValue.Value)
                                                                     _Problem.Value)
    let _setFunctionValue                          (functionValue : ICell<double>)   
                                                   = triv (fun () -> _Problem.Value.setFunctionValue(functionValue.Value)
                                                                     _Problem.Value)
    let _setGradientNormValue                      (squaredNorm : ICell<double>)   
                                                   = triv (fun () -> _Problem.Value.setGradientNormValue(squaredNorm.Value)
                                                                     _Problem.Value)
    let _value                                     (x : ICell<Vector>)   
                                                   = triv (fun () -> _Problem.Value.value(x.Value))
    let _valueAndGradient                          (grad_f : ICell<Vector>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _Problem.Value.valueAndGradient(ref grad_f.Value, x.Value))
    let _values                                    (x : ICell<Vector>)   
                                                   = triv (fun () -> _Problem.Value.values(x.Value))
    do this.Bind(_Problem)
(* 
    casting 
*)
    internal new () = new ProblemModel(null,null,null)
    member internal this.Inject v = _Problem.Value <- v
    static member Cast (p : ICell<Problem>) = 
        if p :? ProblemModel then 
            p :?> ProblemModel
        else
            let o = new ProblemModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.costFunction                       = _costFunction 
    member this.Constraint                         = _Constraint 
    member this.initialValue                       = _initialValue 
    member this.Constraint1                        = _constraint
    member this.CostFunction                       = _costFunction
    member this.CurrentValue                       = _currentValue
    member this.FunctionEvaluation                 = _functionEvaluation
    member this.FunctionValue                      = _functionValue
    member this.Gradient                           grad_f x   
                                                   = _gradient grad_f x 
    member this.GradientEvaluation                 = _gradientEvaluation
    member this.GradientNormValue                  = _gradientNormValue
    member this.Reset                              = _reset
    member this.SetCurrentValue                    currentValue   
                                                   = _setCurrentValue currentValue 
    member this.SetFunctionValue                   functionValue   
                                                   = _setFunctionValue functionValue 
    member this.SetGradientNormValue               squaredNorm   
                                                   = _setGradientNormValue squaredNorm 
    member this.Value                              x   
                                                   = _value x 
    member this.ValueAndGradient                   grad_f x   
                                                   = _valueAndGradient grad_f x 
    member this.Values                             x   
                                                   = _values x 
