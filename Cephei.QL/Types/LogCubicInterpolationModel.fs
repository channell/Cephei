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
  %log-cubic interpolation between discrete points
! \pre the \f$ x \f$ values must be sorted.
  </summary> *)
[<AutoSerializable(true)>]
type LogCubicInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , da                                           : ICell<CubicInterpolation.DerivativeApprox>
    , monotonic                                    : ICell<bool>
    , leftC                                        : ICell<CubicInterpolation.BoundaryCondition>
    , leftConditionValue                           : ICell<double>
    , rightC                                       : ICell<CubicInterpolation.BoundaryCondition>
    , rightConditionValue                          : ICell<double>
    ) as this =

    inherit Model<LogCubicInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _da                                        = da
    let _monotonic                                 = monotonic
    let _leftC                                     = leftC
    let _leftConditionValue                        = leftConditionValue
    let _rightC                                    = rightC
    let _rightConditionValue                       = rightConditionValue
(*
    Functions
*)
    let _LogCubicInterpolation                     = cell (fun () -> new LogCubicInterpolation (xBegin.Value, size.Value, yBegin.Value, da.Value, monotonic.Value, leftC.Value, leftConditionValue.Value, rightC.Value, rightConditionValue.Value))
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _LogCubicInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = cell (fun () -> _LogCubicInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _LogCubicInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _LogCubicInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = cell (fun () -> _LogCubicInterpolation.Value.update()
                                                                     _LogCubicInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _LogCubicInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _LogCubicInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = cell (fun () -> _LogCubicInterpolation.Value.xMax())
    let _xMin                                      = cell (fun () -> _LogCubicInterpolation.Value.xMin())
    let _allowsExtrapolation                       = cell (fun () -> _LogCubicInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _LogCubicInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _LogCubicInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _LogCubicInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _LogCubicInterpolation.Value)
    let _extrapolate                               = cell (fun () -> _LogCubicInterpolation.Value.extrapolate)
    do this.Bind(_LogCubicInterpolation)

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.da                                 = _da 
    member this.monotonic                          = _monotonic 
    member this.leftC                              = _leftC 
    member this.leftConditionValue                 = _leftConditionValue 
    member this.rightC                             = _rightC 
    member this.rightConditionValue                = _rightConditionValue 
    member this.Derivative                         x allowExtrapolation   
                                                   = _derivative x allowExtrapolation 
    member this.Empty                              = _empty
    member this.Primitive                          x allowExtrapolation   
                                                   = _primitive x allowExtrapolation 
    member this.SecondDerivative                   x allowExtrapolation   
                                                   = _secondDerivative x allowExtrapolation 
    member this.Update                             = _update
    member this.Value                              x   
                                                   = _value x 
    member this.Value1                             x allowExtrapolation   
                                                   = _value1 x allowExtrapolation 
    member this.XMax                               = _xMax
    member this.XMin                               = _xMin
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
