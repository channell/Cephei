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
  revise end conditions
! \pre the \f$ x \f$ and \f$ y \f$ values must be sorted.
  </summary> *)
[<AutoSerializable(true)>]
type BicubicSplineModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , ySize                                        : ICell<int>
    , zData                                        : ICell<Matrix>
    ) as this =

    inherit Model<BicubicSpline> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _ySize                                     = ySize
    let _zData                                     = zData
(*
    Functions
*)
    let mutable
        _BicubicSpline                             = cell (fun () -> new BicubicSpline (xBegin.Value, size.Value, yBegin.Value, ySize.Value, zData.Value))
    let _derivativeX                               (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.derivativeX(x.Value, y.Value))
    let _derivativeXY                              (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.derivativeXY(x.Value, y.Value))
    let _derivativeY                               (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.derivativeY(x.Value, y.Value))
    let _secondDerivativeX                         (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.secondDerivativeX(x.Value, y.Value))
    let _secondDerivativeY                         (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.secondDerivativeY(x.Value, y.Value))
    let _isInRange                                 (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.isInRange(x.Value, y.Value))
    let _locateX                                   (x : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.locateX(x.Value))
    let _locateY                                   (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.locateY(y.Value))
    let _update                                    = triv (fun () -> _BicubicSpline.Value.update()
                                                                     _BicubicSpline.Value)
    let _value                                     (x : ICell<double>) (y : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _BicubicSpline.Value.value(x.Value, y.Value, allowExtrapolation.Value))
    let _value1                                    (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _BicubicSpline.Value.value(x.Value, y.Value))
    let _xMax                                      = triv (fun () -> _BicubicSpline.Value.xMax())
    let _xMin                                      = triv (fun () -> _BicubicSpline.Value.xMin())
    let _xValues                                   = triv (fun () -> _BicubicSpline.Value.xValues())
    let _yMax                                      = triv (fun () -> _BicubicSpline.Value.yMax())
    let _yMin                                      = triv (fun () -> _BicubicSpline.Value.yMin())
    let _yValues                                   = triv (fun () -> _BicubicSpline.Value.yValues())
    let _zData                                     = triv (fun () -> _BicubicSpline.Value.zData())
    let _allowsExtrapolation                       = triv (fun () -> _BicubicSpline.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _BicubicSpline.Value.disableExtrapolation(b.Value)
                                                                     _BicubicSpline.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _BicubicSpline.Value.enableExtrapolation(b.Value)
                                                                     _BicubicSpline.Value)
    let _extrapolate                               = triv (fun () -> _BicubicSpline.Value.extrapolate)
    do this.Bind(_BicubicSpline)
(* 
    casting 
*)
    internal new () = new BicubicSplineModel(null,null,null,null,null)
    member internal this.Inject v = _BicubicSpline <- v
    static member Cast (p : ICell<BicubicSpline>) = 
        if p :? BicubicSplineModel then 
            p :?> BicubicSplineModel
        else
            let o = new BicubicSplineModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.ySize                              = _ySize 
    member this.zData                              = _zData 
    member this.DerivativeX                        x y   
                                                   = _derivativeX x y 
    member this.DerivativeXY                       x y   
                                                   = _derivativeXY x y 
    member this.DerivativeY                        x y   
                                                   = _derivativeY x y 
    member this.SecondDerivativeX                  x y   
                                                   = _secondDerivativeX x y 
    member this.SecondDerivativeY                  x y   
                                                   = _secondDerivativeY x y 
    member this.IsInRange                          x y   
                                                   = _isInRange x y 
    member this.LocateX                            x   
                                                   = _locateX x 
    member this.LocateY                            y   
                                                   = _locateY y 
    member this.Update                             = _update
    member this.Value                              x y allowExtrapolation   
                                                   = _value x y allowExtrapolation 
    member this.Value1                             x y   
                                                   = _value1 x y 
    member this.XMax                               = _xMax
    member this.XMin                               = _xMin
    member this.XValues                            = _xValues
    member this.YMax                               = _yMax
    member this.YMin                               = _yMin
    member this.YValues                            = _yValues
    member this.ZData                              = _zData
    member this.AllowsExtrapolation                = _allowsExtrapolation
    member this.DisableExtrapolation               b   
                                                   = _disableExtrapolation b 
    member this.EnableExtrapolation                b   
                                                   = _enableExtrapolation b 
    member this.Extrapolate                        = _extrapolate
