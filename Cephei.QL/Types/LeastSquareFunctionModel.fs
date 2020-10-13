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
  Cost function for least-square problems   Implements a cost function using the interface provided by the LeastSquareProblem class.
! Default constructor
  </summary> *)
[<AutoSerializable(true)>]
type LeastSquareFunctionModel
    ( lsp                                          : ICell<LeastSquareProblem>
    ) as this =

    inherit Model<LeastSquareFunction> ()
(*
    Parameters
*)
    let _lsp                                       = lsp
(*
    Functions
*)
    let _LeastSquareFunction                       = cell (fun () -> new LeastSquareFunction (lsp.Value))
    let _gradient                                  (grad_f : ICell<Vector>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LeastSquareFunction.Value.gradient(ref grad_f.Value, x.Value)
                                                                     _LeastSquareFunction.Value)
    let _value                                     (x : ICell<Vector>)   
                                                   = triv (fun () -> _LeastSquareFunction.Value.value(x.Value))
    let _valueAndGradient                          (grad_f : ICell<Vector>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LeastSquareFunction.Value.valueAndGradient(ref grad_f.Value, x.Value))
    let _values                                    (x : ICell<Vector>)   
                                                   = triv (fun () -> _LeastSquareFunction.Value.values(x.Value))
    let _finiteDifferenceEpsilon                   = triv (fun () -> _LeastSquareFunction.Value.finiteDifferenceEpsilon())
    let _jacobian                                  (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LeastSquareFunction.Value.jacobian(jac.Value, x.Value)
                                                                     _LeastSquareFunction.Value)
    let _valuesAndJacobian                         (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = triv (fun () -> _LeastSquareFunction.Value.valuesAndJacobian(jac.Value, x.Value))
    do this.Bind(_LeastSquareFunction)
(* 
    casting 
*)
    internal new () = new LeastSquareFunctionModel(null)
    member internal this.Inject v = _LeastSquareFunction.Value <- v
    static member Cast (p : ICell<LeastSquareFunction>) = 
        if p :? LeastSquareFunctionModel then 
            p :?> LeastSquareFunctionModel
        else
            let o = new LeastSquareFunctionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.lsp                                = _lsp 
    member this.Gradient                           grad_f x   
                                                   = _gradient grad_f x 
    member this.Value                              x   
                                                   = _value x 
    member this.ValueAndGradient                   grad_f x   
                                                   = _valueAndGradient grad_f x 
    member this.Values                             x   
                                                   = _values x 
    member this.FiniteDifferenceEpsilon            = _finiteDifferenceEpsilon
    member this.Jacobian                           jac x   
                                                   = _jacobian jac x 
    member this.ValuesAndJacobian                  jac x   
                                                   = _valuesAndJacobian jac x 
