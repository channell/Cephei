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
penalty function class for solving using a multi-dimensional solver

  </summary> *)
[<AutoSerializable(true)>]
type PenaltyFunctionModel<'T, 'U when 'T :> Curve<'U> and 'T : (new : unit -> 'T) and 'U :> TermStructure>
    ( curve                                        : ICell<'T>
    , initialIndex                                 : ICell<int>
    , rateHelpers                                  : ICell<Generic.List<BootstrapHelper<'U>>>
    , start                                        : ICell<int>
    , End                                          : ICell<int>
    ) as this =

    inherit Model<PenaltyFunction<'T,'U>> ()
(*
    Parameters
*)
    let _curve                                     = curve
    let _initialIndex                              = initialIndex
    let _rateHelpers                               = rateHelpers
    let _start                                     = start
    let _End                                       = End
(*
    Functions
*)
    let _PenaltyFunction                           = cell (fun () -> new PenaltyFunction<'T,'U> (curve.Value, initialIndex.Value, rateHelpers.Value, start.Value, End.Value))
    let _value                                     (x : ICell<Vector>)   
                                                   = cell (fun () -> _PenaltyFunction.Value.value(x.Value))
    let _values                                    (x : ICell<Vector>)   
                                                   = cell (fun () -> _PenaltyFunction.Value.values(x.Value))
    let _finiteDifferenceEpsilon                   = cell (fun () -> _PenaltyFunction.Value.finiteDifferenceEpsilon())
    let _gradient                                  (grad : ICell<Vector ref>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _PenaltyFunction.Value.gradient(grad.Value, x.Value)
                                                                     _PenaltyFunction.Value)
    let _jacobian                                  (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _PenaltyFunction.Value.jacobian(jac.Value, x.Value)
                                                                     _PenaltyFunction.Value)
    let _valueAndGradient                          (grad : ICell<Vector ref>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _PenaltyFunction.Value.valueAndGradient(grad.Value, x.Value))
    let _valuesAndJacobian                         (jac : ICell<Matrix>) (x : ICell<Vector>)   
                                                   = cell (fun () -> _PenaltyFunction.Value.valuesAndJacobian(jac.Value, x.Value))
    do this.Bind(_PenaltyFunction)

(* 
    Externally visible/bindable properties
*)
    member this.curve                              = _curve 
    member this.initialIndex                       = _initialIndex 
    member this.rateHelpers                        = _rateHelpers 
    member this.start                              = _start 
    member this.End                                = _End 
    member this.Value                              x   
                                                   = _value x 
    member this.Values                             x   
                                                   = _values x 
    member this.FiniteDifferenceEpsilon            = _finiteDifferenceEpsilon
    member this.Gradient                           grad x   
                                                   = _gradient grad x 
    member this.Jacobian                           jac x   
                                                   = _jacobian jac x 
    member this.ValueAndGradient                   grad x   
                                                   = _valueAndGradient grad x 
    member this.ValuesAndJacobian                  jac x   
                                                   = _valuesAndJacobian jac x 
