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
  Enhances implementation of the convex monotone method described in "Interpolation Methods for Curve Construction" by Hagan & West AMF Vol 13, No2 2006.  A setting of monotonicity = 1 and quadraticity = 0 will reproduce the basic Hagan/West method. However, this can produce excessive gradients which can mean P&L swings for some curves.  Setting monotonicity < 1 and/or quadraticity > 0 produces smoother curves.  Extra enhancement to avoid negative values (if required) is in place.

  </summary> *)
[<AutoSerializable(true)>]
type ConvexMonotoneInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , quadraticity                                 : ICell<double>
    , monotonicity                                 : ICell<double>
    , forcePositive                                : ICell<bool>
    , flatFinalPeriod                              : ICell<bool>
    , preExistingHelpers                           : ICell<Dictionary<double,ISectionHelper>>
    ) as this =

    inherit Model<ConvexMonotoneInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _quadraticity                              = quadraticity
    let _monotonicity                              = monotonicity
    let _forcePositive                             = forcePositive
    let _flatFinalPeriod                           = flatFinalPeriod
    let _preExistingHelpers                        = preExistingHelpers
(*
    Functions
*)
    let mutable
        _ConvexMonotoneInterpolation               = cell (fun () -> new ConvexMonotoneInterpolation (xBegin.Value, size.Value, yBegin.Value, quadraticity.Value, monotonicity.Value, forcePositive.Value, flatFinalPeriod.Value, preExistingHelpers.Value))
    let _getExistingHelpers                        = triv (fun () -> _ConvexMonotoneInterpolation.Value.getExistingHelpers())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv (fun () -> _ConvexMonotoneInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv (fun () -> _ConvexMonotoneInterpolation.Value.update()
                                                                     _ConvexMonotoneInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv (fun () -> _ConvexMonotoneInterpolation.Value.xMax())
    let _xMin                                      = triv (fun () -> _ConvexMonotoneInterpolation.Value.xMin())
    let _allowsExtrapolation                       = triv (fun () -> _ConvexMonotoneInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _ConvexMonotoneInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _ConvexMonotoneInterpolation.Value)
    let _extrapolate                               = triv (fun () -> _ConvexMonotoneInterpolation.Value.extrapolate)
    do this.Bind(_ConvexMonotoneInterpolation)
(* 
    casting 
*)
    internal new () = new ConvexMonotoneInterpolationModel(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _ConvexMonotoneInterpolation <- v
    static member Cast (p : ICell<ConvexMonotoneInterpolation>) = 
        if p :? ConvexMonotoneInterpolationModel then 
            p :?> ConvexMonotoneInterpolationModel
        else
            let o = new ConvexMonotoneInterpolationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.quadraticity                       = _quadraticity 
    member this.monotonicity                       = _monotonicity 
    member this.forcePositive                      = _forcePositive 
    member this.flatFinalPeriod                    = _flatFinalPeriod 
    member this.preExistingHelpers                 = _preExistingHelpers 
    member this.GetExistingHelpers                 = _getExistingHelpers
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
(* <summary>
  Enhances implementation of the convex monotone method described in "Interpolation Methods for Curve Construction" by Hagan & West AMF Vol 13, No2 2006.  A setting of monotonicity = 1 and quadraticity = 0 will reproduce the basic Hagan/West method. However, this can produce excessive gradients which can mean P&L swings for some curves.  Setting monotonicity < 1 and/or quadraticity > 0 produces smoother curves.  Extra enhancement to avoid negative values (if required) is in place.

  </summary> *)
[<AutoSerializable(true)>]
type ConvexMonotoneInterpolationModel1
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , quadraticity                                 : ICell<double>
    , monotonicity                                 : ICell<double>
    , forcePositive                                : ICell<bool>
    , flatFinalPeriod                              : ICell<bool>
    ) as this =

    inherit Model<ConvexMonotoneInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _quadraticity                              = quadraticity
    let _monotonicity                              = monotonicity
    let _forcePositive                             = forcePositive
    let _flatFinalPeriod                           = flatFinalPeriod
(*
    Functions
*)
    let mutable
        _ConvexMonotoneInterpolation               = cell (fun () -> new ConvexMonotoneInterpolation (xBegin.Value, size.Value, yBegin.Value, quadraticity.Value, monotonicity.Value, forcePositive.Value, flatFinalPeriod.Value))
    let _getExistingHelpers                        = triv (fun () -> _ConvexMonotoneInterpolation.Value.getExistingHelpers())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv (fun () -> _ConvexMonotoneInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv (fun () -> _ConvexMonotoneInterpolation.Value.update()
                                                                     _ConvexMonotoneInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv (fun () -> _ConvexMonotoneInterpolation.Value.xMax())
    let _xMin                                      = triv (fun () -> _ConvexMonotoneInterpolation.Value.xMin())
    let _allowsExtrapolation                       = triv (fun () -> _ConvexMonotoneInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _ConvexMonotoneInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _ConvexMonotoneInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _ConvexMonotoneInterpolation.Value)
    let _extrapolate                               = triv (fun () -> _ConvexMonotoneInterpolation.Value.extrapolate)
    do this.Bind(_ConvexMonotoneInterpolation)
(* 
    casting 
*)
    internal new () = new ConvexMonotoneInterpolationModel1(null,null,null,null,null,null,null)
    member internal this.Inject v = _ConvexMonotoneInterpolation <- v
    static member Cast (p : ICell<ConvexMonotoneInterpolation>) = 
        if p :? ConvexMonotoneInterpolationModel1 then 
            p :?> ConvexMonotoneInterpolationModel1
        else
            let o = new ConvexMonotoneInterpolationModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.quadraticity                       = _quadraticity 
    member this.monotonicity                       = _monotonicity 
    member this.forcePositive                      = _forcePositive 
    member this.flatFinalPeriod                    = _flatFinalPeriod 
    member this.GetExistingHelpers                 = _getExistingHelpers
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
