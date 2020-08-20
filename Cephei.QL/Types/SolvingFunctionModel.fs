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
type SolvingFunctionModel
    ( lambda                                       : ICell<Vector>
    , Bb                                           : ICell<Vector>
    ) as this =

    inherit Model<SolvingFunction> ()
(*
    Parameters
*)
    let _lambda                                    = lambda
    let _Bb                                        = Bb
(*
    Functions
*)
    let _SolvingFunction                           = cell (fun () -> new SolvingFunction (lambda.Value, Bb.Value))
    let _value                                     (y : ICell<double>)   
                                                   = cell (fun () -> _SolvingFunction.Value.value(y.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = cell (fun () -> _SolvingFunction.Value.derivative(x.Value))
    do this.Bind(_SolvingFunction)

(* 
    Externally visible/bindable properties
*)
    member this.lambda                             = _lambda 
    member this.Bb                                 = _Bb 
    member this.Value                              y   
                                                   = _value y 
    member this.Derivative                         x   
                                                   = _derivative x 
