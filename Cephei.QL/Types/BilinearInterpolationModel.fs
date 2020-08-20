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
  %bilinear interpolation between discrete points
! \pre the \f$ x \f$ and \f$ y \f$ values must be sorted.
  </summary> *)
[<AutoSerializable(true)>]
type BilinearInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , xSize                                        : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , ySize                                        : ICell<int>
    , zData                                        : ICell<Matrix>
    ) as this =

    inherit Model<BilinearInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _xSize                                     = xSize
    let _yBegin                                    = yBegin
    let _ySize                                     = ySize
    let _zData                                     = zData
(*
    Functions
*)
    let _BilinearInterpolation                     = cell (fun () -> new BilinearInterpolation (xBegin.Value, xSize.Value, yBegin.Value, ySize.Value, zData.Value))
    let _isInRange                                 (x : ICell<double>) (y : ICell<double>)   
                                                   = cell (fun () -> _BilinearInterpolation.Value.isInRange(x.Value, y.Value))
    let _locateX                                   (x : ICell<double>)   
                                                   = cell (fun () -> _BilinearInterpolation.Value.locateX(x.Value))
    let _locateY                                   (y : ICell<double>)   
                                                   = cell (fun () -> _BilinearInterpolation.Value.locateY(y.Value))
    let _update                                    = cell (fun () -> _BilinearInterpolation.Value.update()
                                                                     _BilinearInterpolation.Value)
    let _value                                     (x : ICell<double>) (y : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _BilinearInterpolation.Value.value(x.Value, y.Value, allowExtrapolation.Value))
    let _value1                                    (x : ICell<double>) (y : ICell<double>)   
                                                   = cell (fun () -> _BilinearInterpolation.Value.value(x.Value, y.Value))
    let _xMax                                      = cell (fun () -> _BilinearInterpolation.Value.xMax())
    let _xMin                                      = cell (fun () -> _BilinearInterpolation.Value.xMin())
    let _xValues                                   = cell (fun () -> _BilinearInterpolation.Value.xValues())
    let _yMax                                      = cell (fun () -> _BilinearInterpolation.Value.yMax())
    let _yMin                                      = cell (fun () -> _BilinearInterpolation.Value.yMin())
    let _yValues                                   = cell (fun () -> _BilinearInterpolation.Value.yValues())
    let _zData                                     = cell (fun () -> _BilinearInterpolation.Value.zData())
    let _allowsExtrapolation                       = cell (fun () -> _BilinearInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _BilinearInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _BilinearInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _BilinearInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _BilinearInterpolation.Value)
    let _extrapolate                               = cell (fun () -> _BilinearInterpolation.Value.extrapolate)
    do this.Bind(_BilinearInterpolation)

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.xSize                              = _xSize 
    member this.yBegin                             = _yBegin 
    member this.ySize                              = _ySize 
    member this.zData                              = _zData 
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
