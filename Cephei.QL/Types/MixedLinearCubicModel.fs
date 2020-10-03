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
  interpolations

  </summary> *)
[<AutoSerializable(true)>]
type MixedLinearCubicModel
    ( n                                            : ICell<int>
    , behavior                                     : ICell<Behavior>
    , da                                           : ICell<CubicInterpolation.DerivativeApprox>
    , monotonic                                    : ICell<bool>
    , leftCondition                                : ICell<CubicInterpolation.BoundaryCondition>
    , leftConditionValue                           : ICell<double>
    , rightCondition                               : ICell<CubicInterpolation.BoundaryCondition>
    , rightConditionValue                          : ICell<double>
    ) as this =

    inherit Model<MixedLinearCubic> ()
(*
    Parameters
*)
    let _n                                         = n
    let _behavior                                  = behavior
    let _da                                        = da
    let _monotonic                                 = monotonic
    let _leftCondition                             = leftCondition
    let _leftConditionValue                        = leftConditionValue
    let _rightCondition                            = rightCondition
    let _rightConditionValue                       = rightConditionValue
(*
    Functions
*)
    let _MixedLinearCubic                          = cell (fun () -> new MixedLinearCubic (n.Value, behavior.Value, da.Value, monotonic.Value, leftCondition.Value, leftConditionValue.Value, rightCondition.Value, rightConditionValue.Value))
    let _global                                    = triv (fun () -> _MixedLinearCubic.Value.GLOBAL)
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (xEnd : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _MixedLinearCubic.Value.interpolate(xBegin.Value, xEnd.Value, yBegin.Value))
    let _requiredPoints                            = triv (fun () -> _MixedLinearCubic.Value.requiredPoints)
    do this.Bind(_MixedLinearCubic)
(* 
    casting 
*)
    internal new () = MixedLinearCubicModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _MixedLinearCubic.Value <- v
    static member Cast (p : ICell<MixedLinearCubic>) = 
        if p :? MixedLinearCubicModel then 
            p :?> MixedLinearCubicModel
        else
            let o = new MixedLinearCubicModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.behavior                           = _behavior 
    member this.da                                 = _da 
    member this.monotonic                          = _monotonic 
    member this.leftCondition                      = _leftCondition 
    member this.leftConditionValue                 = _leftConditionValue 
    member this.rightCondition                     = _rightCondition 
    member this.rightConditionValue                = _rightConditionValue 
    member this.Global                             = _global
    member this.Interpolate                        xBegin xEnd yBegin   
                                                   = _interpolate xBegin xEnd yBegin 
    member this.RequiredPoints                     = _requiredPoints
