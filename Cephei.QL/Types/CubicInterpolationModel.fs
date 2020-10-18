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
  Cubic interpolation is fully defined when the ${f_i}$ function values at points ${x_i}$ are supplemented with ${f_i}$ function derivative values.  Different type of first derivative approximations are implemented, both local and non-local. Local schemes (Fourth-order, Parabolic, Modified Parabolic, Fritsch-Butland, Akima, Kruger) use only $f$ values near $x_i$ to calculate $f_i$. Non-local schemes (Spline with different boundary conditions) use all ${f_i}$ values and obtain ${f_i}$ by solving a linear system of equations. Local schemes produce $C^1$ interpolants, while the spline scheme generates $C^2$ interpolants.  Hyman's monotonicity constraint filter is also implemented: it can be applied to all schemes to ensure that in the regions of local monotoniticity of the input (three successive increasing or decreasing values) the interpolating cubic remains monotonic. If the interpolating cubic is already monotonic, the Hyman filter leaves it unchanged preserving all its original features.  In the case of $C^2$ interpolants the Hyman filter ensures local monotonicity at the expense of the second derivative of the interpolant which will no longer be continuous in the points where the filter has been applied.  While some non-linear schemes (Modified Parabolic, Fritsch-Butland, Kruger) are guaranteed to be locally monotone in their original approximation, all other schemes must be filtered according to the Hyman criteria at the expense of their linearity.  See R. L. Dougherty, A. Edelman, and J. M. Hyman, "Nonnegativity-, Monotonicity-, or Convexity-Preserving CubicSpline and Quintic Hermite Interpolation" Mathematics Of Computation, v. 52, n. 186, April 1989, pp. 471-494.  implement missing schemes (FourthOrder and ModifiedParabolic) and missing boundary conditions (Periodic and Lagrange).  to be adapted from old ones.

  </summary> *)
[<AutoSerializable(true)>]
type CubicInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , da                                           : ICell<CubicInterpolation.DerivativeApprox>
    , monotonic                                    : ICell<bool>
    , leftCond                                     : ICell<CubicInterpolation.BoundaryCondition>
    , leftConditionValue                           : ICell<double>
    , rightCond                                    : ICell<CubicInterpolation.BoundaryCondition>
    , rightConditionValue                          : ICell<double>
    ) as this =

    inherit Model<CubicInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _da                                        = da
    let _monotonic                                 = monotonic
    let _leftCond                                  = leftCond
    let _leftConditionValue                        = leftConditionValue
    let _rightCond                                 = rightCond
    let _rightConditionValue                       = rightConditionValue
(*
    Functions
*)
    let mutable
        _CubicInterpolation                        = cell (fun () -> new CubicInterpolation (xBegin.Value, size.Value, yBegin.Value, da.Value, monotonic.Value, leftCond.Value, leftConditionValue.Value, rightCond.Value, rightConditionValue.Value))
    let _aCoefficients                             = triv (fun () -> _CubicInterpolation.Value.aCoefficients())
    let _bCoefficients                             = triv (fun () -> _CubicInterpolation.Value.bCoefficients())
    let _cCoefficients                             = triv (fun () -> _CubicInterpolation.Value.cCoefficients())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _CubicInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv (fun () -> _CubicInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _CubicInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _CubicInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv (fun () -> _CubicInterpolation.Value.update()
                                                                     _CubicInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _CubicInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _CubicInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv (fun () -> _CubicInterpolation.Value.xMax())
    let _xMin                                      = triv (fun () -> _CubicInterpolation.Value.xMin())
    let _allowsExtrapolation                       = triv (fun () -> _CubicInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _CubicInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _CubicInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _CubicInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _CubicInterpolation.Value)
    let _extrapolate                               = triv (fun () -> _CubicInterpolation.Value.extrapolate)
    do this.Bind(_CubicInterpolation)
(* 
    casting 
*)
    internal new () = new CubicInterpolationModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CubicInterpolation <- v
    static member Cast (p : ICell<CubicInterpolation>) = 
        if p :? CubicInterpolationModel then 
            p :?> CubicInterpolationModel
        else
            let o = new CubicInterpolationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.da                                 = _da 
    member this.monotonic                          = _monotonic 
    member this.leftCond                           = _leftCond 
    member this.leftConditionValue                 = _leftConditionValue 
    member this.rightCond                          = _rightCond 
    member this.rightConditionValue                = _rightConditionValue 
    member this.ACoefficients                      = _aCoefficients
    member this.BCoefficients                      = _bCoefficients
    member this.CCoefficients                      = _cCoefficients
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
