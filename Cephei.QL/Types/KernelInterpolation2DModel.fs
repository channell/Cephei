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
  Implementation of the 2D kernel interpolation approach, which can be found in "Foreign Exchange Risk" by Hakala, Wystup page 256.  The kernel in the implementation is kept general, although a Gaussian is considered in the cited text.

  </summary> *)
[<AutoSerializable(true)>]
type KernelInterpolation2DModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , ySize                                        : ICell<int>
    , zData                                        : ICell<Matrix>
    , kernel                                       : ICell<IKernelFunction>
    ) as this =

    inherit Model<KernelInterpolation2D> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _ySize                                     = ySize
    let _zData                                     = zData
    let _kernel                                    = kernel
(*
    Functions
*)
    let _KernelInterpolation2D                     = cell (fun () -> new KernelInterpolation2D (xBegin.Value, size.Value, yBegin.Value, ySize.Value, zData.Value, kernel.Value))
    let _isInRange                                 (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _KernelInterpolation2D.Value.isInRange(x.Value, y.Value))
    let _locateX                                   (x : ICell<double>)   
                                                   = triv (fun () -> _KernelInterpolation2D.Value.locateX(x.Value))
    let _locateY                                   (y : ICell<double>)   
                                                   = triv (fun () -> _KernelInterpolation2D.Value.locateY(y.Value))
    let _update                                    = triv (fun () -> _KernelInterpolation2D.Value.update()
                                                                     _KernelInterpolation2D.Value)
    let _value                                     (x : ICell<double>) (y : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _KernelInterpolation2D.Value.value(x.Value, y.Value, allowExtrapolation.Value))
    let _value1                                    (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _KernelInterpolation2D.Value.value(x.Value, y.Value))
    let _xMax                                      = triv (fun () -> _KernelInterpolation2D.Value.xMax())
    let _xMin                                      = triv (fun () -> _KernelInterpolation2D.Value.xMin())
    let _xValues                                   = triv (fun () -> _KernelInterpolation2D.Value.xValues())
    let _yMax                                      = triv (fun () -> _KernelInterpolation2D.Value.yMax())
    let _yMin                                      = triv (fun () -> _KernelInterpolation2D.Value.yMin())
    let _yValues                                   = triv (fun () -> _KernelInterpolation2D.Value.yValues())
    let _zData                                     = triv (fun () -> _KernelInterpolation2D.Value.zData())
    let _allowsExtrapolation                       = triv (fun () -> _KernelInterpolation2D.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _KernelInterpolation2D.Value.disableExtrapolation(b.Value)
                                                                     _KernelInterpolation2D.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _KernelInterpolation2D.Value.enableExtrapolation(b.Value)
                                                                     _KernelInterpolation2D.Value)
    let _extrapolate                               = triv (fun () -> _KernelInterpolation2D.Value.extrapolate)
    do this.Bind(_KernelInterpolation2D)
(* 
    casting 
*)
    internal new () = new KernelInterpolation2DModel(null,null,null,null,null,null)
    member internal this.Inject v = _KernelInterpolation2D.Value <- v
    static member Cast (p : ICell<KernelInterpolation2D>) = 
        if p :? KernelInterpolation2DModel then 
            p :?> KernelInterpolation2DModel
        else
            let o = new KernelInterpolation2DModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.ySize                              = _ySize 
    member this.zData                              = _zData 
    member this.kernel                             = _kernel 
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
