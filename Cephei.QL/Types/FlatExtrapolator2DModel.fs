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
type FlatExtrapolator2DModel
    ( decoratedInterpolation                       : ICell<Interpolation2D>
    ) as this =

    inherit Model<FlatExtrapolator2D> ()
(*
    Parameters
*)
    let _decoratedInterpolation                    = decoratedInterpolation
(*
    Functions
*)
    let mutable
        _FlatExtrapolator2D                        = cell (fun () -> new FlatExtrapolator2D (decoratedInterpolation.Value))
    let _isInRange                                 (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _FlatExtrapolator2D.Value.isInRange(x.Value, y.Value))
    let _locateX                                   (x : ICell<double>)   
                                                   = triv (fun () -> _FlatExtrapolator2D.Value.locateX(x.Value))
    let _locateY                                   (y : ICell<double>)   
                                                   = triv (fun () -> _FlatExtrapolator2D.Value.locateY(y.Value))
    let _update                                    = triv (fun () -> _FlatExtrapolator2D.Value.update()
                                                                     _FlatExtrapolator2D.Value)
    let _value                                     (x : ICell<double>) (y : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _FlatExtrapolator2D.Value.value(x.Value, y.Value, allowExtrapolation.Value))
    let _value1                                    (x : ICell<double>) (y : ICell<double>)   
                                                   = triv (fun () -> _FlatExtrapolator2D.Value.value(x.Value, y.Value))
    let _xMax                                      = triv (fun () -> _FlatExtrapolator2D.Value.xMax())
    let _xMin                                      = triv (fun () -> _FlatExtrapolator2D.Value.xMin())
    let _xValues                                   = triv (fun () -> _FlatExtrapolator2D.Value.xValues())
    let _yMax                                      = triv (fun () -> _FlatExtrapolator2D.Value.yMax())
    let _yMin                                      = triv (fun () -> _FlatExtrapolator2D.Value.yMin())
    let _yValues                                   = triv (fun () -> _FlatExtrapolator2D.Value.yValues())
    let _zData                                     = triv (fun () -> _FlatExtrapolator2D.Value.zData())
    let _allowsExtrapolation                       = triv (fun () -> _FlatExtrapolator2D.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatExtrapolator2D.Value.disableExtrapolation(b.Value)
                                                                     _FlatExtrapolator2D.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _FlatExtrapolator2D.Value.enableExtrapolation(b.Value)
                                                                     _FlatExtrapolator2D.Value)
    let _extrapolate                               = triv (fun () -> _FlatExtrapolator2D.Value.extrapolate)
    do this.Bind(_FlatExtrapolator2D)
(* 
    casting 
*)
    internal new () = new FlatExtrapolator2DModel(null)
    member internal this.Inject v = _FlatExtrapolator2D <- v
    static member Cast (p : ICell<FlatExtrapolator2D>) = 
        if p :? FlatExtrapolator2DModel then 
            p :?> FlatExtrapolator2DModel
        else
            let o = new FlatExtrapolator2DModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.decoratedInterpolation             = _decoratedInterpolation 
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
