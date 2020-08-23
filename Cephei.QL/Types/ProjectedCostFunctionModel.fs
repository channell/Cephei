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
  Parameterized cost function   This class creates a proxy cost function which can depend on any arbitrary subset of parameters (the other being fixed)

  </summary> *)
[<AutoSerializable(true)>]
type ProjectedCostFunctionModel
    ( costFunction                                 : ICell<CostFunction>
    , parametersValues                             : ICell<Vector>
    , parametersFreedoms                           : ICell<Generic.List<bool>>
    ) as this =

    inherit Model<ProjectedCostFunction> ()
(*
    Parameters
*)
    let _costFunction                              = costFunction
    let _parametersValues                          = parametersValues
    let _parametersFreedoms                        = parametersFreedoms
(*
    Functions
*)
    let _ProjectedCostFunction                     = cell (fun () -> new ProjectedCostFunction (costFunction.Value, parametersValues.Value, parametersFreedoms.Value))
    let _include                                   (projectedParameters : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.INCLUDE(projectedParameters.Value))
    let _project                                   (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.project(parameters.Value))
    let _value                                     (freeParameters : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.value(freeParameters.Value))
    let _values                                    (freeParameters : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.values(freeParameters.Value))
    let _finiteDifferenceEpsilon                   = triv (fun () -> _ProjectedCostFunction.Value.finiteDifferenceEpsilon())
    let _gradient                                  (grad : ICell<Vector ref>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.gradient(grad.Value, x.Value)
                                                                     _ProjectedCostFunction.Value)
    let _jacobian                                  (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.jacobian(jac.Value, x.Value)
                                                                     _ProjectedCostFunction.Value)
    let _valueAndGradient                          (grad : ICell<Vector ref>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.valueAndGradient(grad.Value, x.Value))
    let _valuesAndJacobian                         (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _ProjectedCostFunction.Value.valuesAndJacobian(jac.Value, x.Value))
    do this.Bind(_ProjectedCostFunction)

(* 
    Externally visible/bindable properties
*)
    member this.costFunction                       = _costFunction 
    member this.parametersValues                   = _parametersValues 
    member this.parametersFreedoms                 = _parametersFreedoms 
    member this.Include                            projectedParameters   
                                                   = _include projectedParameters 
    member this.Project                            parameters   
                                                   = _project parameters 
    member this.Value                              freeParameters   
                                                   = _value freeParameters 
    member this.Values                             freeParameters   
                                                   = _values freeParameters 
    member this.FiniteDifferenceEpsilon            = _finiteDifferenceEpsilon
    member this.Gradient                           grad x   
                                                   = _gradient grad x 
    member this.Jacobian                           jac x   
                                                   = _jacobian jac x 
    member this.ValueAndGradient                   grad x   
                                                   = _valueAndGradient grad x 
    member this.ValuesAndJacobian                  jac x   
                                                   = _valuesAndJacobian jac x 
