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
cost function for hypersphere and lower-diagonal algorithm

  </summary> *)
[<AutoSerializable(true)>]
type HypersphereCostFunctionModel
    ( targetMatrix                                 : ICell<Matrix>
    , targetVariance                               : ICell<Vector>
    , lowerDiagonal                                : ICell<bool>
    ) as this =

    inherit Model<HypersphereCostFunction> ()
(*
    Parameters
*)
    let _targetMatrix                              = targetMatrix
    let _targetVariance                            = targetVariance
    let _lowerDiagonal                             = lowerDiagonal
(*
    Functions
*)
    let _HypersphereCostFunction                   = cell (fun () -> new HypersphereCostFunction (targetMatrix.Value, targetVariance.Value, lowerDiagonal.Value))
    let _value                                     (x : ICell<Vector>)   
                                                   = cell (fun () -> _HypersphereCostFunction.Value.value(x.Value))
    let _values                                    (a : ICell<Vector>)   
                                                   = cell (fun () -> _HypersphereCostFunction.Value.values(a.Value))
    let _finiteDifferenceEpsilon                   = cell (fun () -> _HypersphereCostFunction.Value.finiteDifferenceEpsilon())
    let _gradient                                  (grad : ICell<Vector>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _HypersphereCostFunction.Value.gradient(grad.Value, x.Value)
                                                                     _HypersphereCostFunction.Value)
    let _jacobian                                  (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _HypersphereCostFunction.Value.jacobian(jac.Value, x.Value)
                                                                     _HypersphereCostFunction.Value)
    let _valueAndGradient                          (grad : ICell<Vector>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _HypersphereCostFunction.Value.valueAndGradient(grad.Value, x.Value))
    let _valuesAndJacobian                         (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _HypersphereCostFunction.Value.valuesAndJacobian(jac.Value, x.Value))
    do this.Bind(_HypersphereCostFunction)

(* 
    Externally visible/bindable properties
*)
    member this.targetMatrix                       = _targetMatrix 
    member this.targetVariance                     = _targetVariance 
    member this.lowerDiagonal                      = _lowerDiagonal 
    member this.Value                              x   
                                                   = _value x 
    member this.Values                             a   
                                                   = _values a 
    member this.FiniteDifferenceEpsilon            = _finiteDifferenceEpsilon
    member this.Gradient                           grad x   
                                                   = _gradient grad x 
    member this.Jacobian                           jac x   
                                                   = _jacobian jac x 
    member this.ValueAndGradient                   grad x   
                                                   = _valueAndGradient grad x 
    member this.ValuesAndJacobian                  jac x   
                                                   = _valuesAndJacobian jac x 
