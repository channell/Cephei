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
  Convex-monotone interpolation factory and traits

  </summary> *)
[<AutoSerializable(true)>]
type ConvexMonotoneModel
    ( quadraticity                                 : ICell<double>
    , monotonicity                                 : ICell<double>
    , forcePositive                                : ICell<bool>
    ) as this =

    inherit Model<ConvexMonotone> ()
(*
    Parameters
*)
    let _quadraticity                              = quadraticity
    let _monotonicity                              = monotonicity
    let _forcePositive                             = forcePositive
(*
    Functions
*)
    let _ConvexMonotone                            = cell (fun () -> new ConvexMonotone (quadraticity.Value, monotonicity.Value, forcePositive.Value))
    let _dataSizeAdjustment                        = triv (fun () -> _ConvexMonotone.Value.dataSizeAdjustment)
    let _global                                    = triv (fun () -> _ConvexMonotone.Value.GLOBAL())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _ConvexMonotone.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    let _localInterpolate                          (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>) (localisation : ICell<int>) (prevInterpolation : ICell<ConvexMonotoneInterpolation>) (finalSize : ICell<int>)   
                                                   = triv (fun () -> _ConvexMonotone.Value.localInterpolate(xBegin.Value, size.Value, yBegin.Value, localisation.Value, prevInterpolation.Value, finalSize.Value))
    let _requiredPoints                            = triv (fun () -> _ConvexMonotone.Value.requiredPoints)
    do this.Bind(_ConvexMonotone)
(* 
    casting 
*)
    internal new () = new ConvexMonotoneModel(null,null,null)
    member internal this.Inject v = _ConvexMonotone.Value <- v
    static member Cast (p : ICell<ConvexMonotone>) = 
        if p :? ConvexMonotoneModel then 
            p :?> ConvexMonotoneModel
        else
            let o = new ConvexMonotoneModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.quadraticity                       = _quadraticity 
    member this.monotonicity                       = _monotonicity 
    member this.forcePositive                      = _forcePositive 
    member this.DataSizeAdjustment                 = _dataSizeAdjustment
    member this.Global                             = _global
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
    member this.LocalInterpolate                   xBegin size yBegin localisation prevInterpolation finalSize   
                                                   = _localInterpolate xBegin size yBegin localisation prevInterpolation finalSize 
    member this.RequiredPoints                     = _requiredPoints
(* <summary>
  Convex-monotone interpolation factory and traits

  </summary> *)
[<AutoSerializable(true)>]
type ConvexMonotoneModel1
    () as this =
    inherit Model<ConvexMonotone> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ConvexMonotone                            = cell (fun () -> new ConvexMonotone ())
    let _dataSizeAdjustment                        = triv (fun () -> _ConvexMonotone.Value.dataSizeAdjustment)
    let _global                                    = triv (fun () -> _ConvexMonotone.Value.GLOBAL())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _ConvexMonotone.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    let _localInterpolate                          (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>) (localisation : ICell<int>) (prevInterpolation : ICell<ConvexMonotoneInterpolation>) (finalSize : ICell<int>)   
                                                   = triv (fun () -> _ConvexMonotone.Value.localInterpolate(xBegin.Value, size.Value, yBegin.Value, localisation.Value, prevInterpolation.Value, finalSize.Value))
    let _requiredPoints                            = triv (fun () -> _ConvexMonotone.Value.requiredPoints)
    do this.Bind(_ConvexMonotone)
(* 
    casting 
*)
    
    member internal this.Inject v = _ConvexMonotone.Value <- v
    static member Cast (p : ICell<ConvexMonotone>) = 
        if p :? ConvexMonotoneModel1 then 
            p :?> ConvexMonotoneModel1
        else
            let o = new ConvexMonotoneModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.DataSizeAdjustment                 = _dataSizeAdjustment
    member this.Global                             = _global
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
    member this.LocalInterpolate                   xBegin size yBegin localisation prevInterpolation finalSize   
                                                   = _localInterpolate xBegin size yBegin localisation prevInterpolation finalSize 
    member this.RequiredPoints                     = _requiredPoints
