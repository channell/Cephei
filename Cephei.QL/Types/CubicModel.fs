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
  %Cubic interpolation factory and traits

  </summary> *)
[<AutoSerializable(true)>]
type CubicModel
    ( da                                           : ICell<CubicInterpolation.DerivativeApprox>
    , monotonic                                    : ICell<bool>
    , leftCondition                                : ICell<CubicInterpolation.BoundaryCondition>
    , leftConditionValue                           : ICell<double>
    , rightCondition                               : ICell<CubicInterpolation.BoundaryCondition>
    , rightConditionValue                          : ICell<double>
    ) as this =

    inherit Model<Cubic> ()
(*
    Parameters
*)
    let _da                                        = da
    let _monotonic                                 = monotonic
    let _leftCondition                             = leftCondition
    let _leftConditionValue                        = leftConditionValue
    let _rightCondition                            = rightCondition
    let _rightConditionValue                       = rightConditionValue
(*
    Functions
*)
    let mutable
        _Cubic                                     = cell (fun () -> new Cubic (da.Value, monotonic.Value, leftCondition.Value, leftConditionValue.Value, rightCondition.Value, rightConditionValue.Value))
    let _global                                    = triv (fun () -> _Cubic.Value.GLOBAL())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _Cubic.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    let _requiredPoints                            = triv (fun () -> _Cubic.Value.requiredPoints)
    do this.Bind(_Cubic)
(* 
    casting 
*)
    internal new () = new CubicModel(null,null,null,null,null,null)
    member internal this.Inject v = _Cubic <- v
    static member Cast (p : ICell<Cubic>) = 
        if p :? CubicModel then 
            p :?> CubicModel
        else
            let o = new CubicModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.da                                 = _da 
    member this.monotonic                          = _monotonic 
    member this.leftCondition                      = _leftCondition 
    member this.leftConditionValue                 = _leftConditionValue 
    member this.rightCondition                     = _rightCondition 
    member this.rightConditionValue                = _rightConditionValue 
    member this.Global                             = _global
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
    member this.RequiredPoints                     = _requiredPoints
(* <summary>
  %Cubic interpolation factory and traits

  </summary> *)
[<AutoSerializable(true)>]
type CubicModel1
    () as this =
    inherit Model<Cubic> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Cubic                                     = cell (fun () -> new Cubic ())
    let _global                                    = triv (fun () -> _Cubic.Value.GLOBAL())
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (size : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _Cubic.Value.interpolate(xBegin.Value, size.Value, yBegin.Value))
    let _requiredPoints                            = triv (fun () -> _Cubic.Value.requiredPoints)
    do this.Bind(_Cubic)
(* 
    casting 
*)
    
    member internal this.Inject v = _Cubic <- v
    static member Cast (p : ICell<Cubic>) = 
        if p :? CubicModel1 then 
            p :?> CubicModel1
        else
            let o = new CubicModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Global                             = _global
    member this.Interpolate                        xBegin size yBegin   
                                                   = _interpolate xBegin size yBegin 
    member this.RequiredPoints                     = _requiredPoints
