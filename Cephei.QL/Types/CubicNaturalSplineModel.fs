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
convenience classes
! \pre the \f$ x \f$ values must be sorted.
  </summary> *)
[<AutoSerializable(true)>]
type CubicNaturalSplineModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    ) as this =

    inherit Model<CubicNaturalSpline> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
(*
    Functions
*)
    let mutable
        _CubicNaturalSpline                        = make (fun () -> new CubicNaturalSpline (xBegin.Value, size.Value, yBegin.Value))
    let _aCoefficients                             = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.aCoefficients())
    let _bCoefficients                             = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.bCoefficients())
    let _cCoefficients                             = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.cCoefficients())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.update()
                                                                                         _CubicNaturalSpline.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.xMax())
    let _xMin                                      = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.xMin())
    let _allowsExtrapolation                       = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.disableExtrapolation(b.Value)
                                                                                         _CubicNaturalSpline.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.enableExtrapolation(b.Value)
                                                                                         _CubicNaturalSpline.Value)
    let _extrapolate                               = triv _CubicNaturalSpline (fun () -> _CubicNaturalSpline.Value.extrapolate)
    do this.Bind(_CubicNaturalSpline)
(* 
    casting 
*)
    internal new () = new CubicNaturalSplineModel(null,null,null)
    member internal this.Inject v = _CubicNaturalSpline <- v
    static member Cast (p : ICell<CubicNaturalSpline>) = 
        if p :? CubicNaturalSplineModel then 
            p :?> CubicNaturalSplineModel
        else
            let o = new CubicNaturalSplineModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
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
