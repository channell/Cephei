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

! \pre the \f$ x \f$ values must be sorted.
  </summary> *)
[<AutoSerializable(true)>]
type MonotonicParabolicModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    ) as this =

    inherit Model<MonotonicParabolic> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
(*
    Functions
*)
    let _MonotonicParabolic                        = cell (fun () -> new MonotonicParabolic (xBegin.Value, size.Value, yBegin.Value))
    let _aCoefficients                             = cell (fun () -> _MonotonicParabolic.Value.aCoefficients())
    let _bCoefficients                             = cell (fun () -> _MonotonicParabolic.Value.bCoefficients())
    let _cCoefficients                             = cell (fun () -> _MonotonicParabolic.Value.cCoefficients())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _MonotonicParabolic.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = cell (fun () -> _MonotonicParabolic.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _MonotonicParabolic.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _MonotonicParabolic.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = cell (fun () -> _MonotonicParabolic.Value.update()
                                                                     _MonotonicParabolic.Value)
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _MonotonicParabolic.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = cell (fun () -> _MonotonicParabolic.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = cell (fun () -> _MonotonicParabolic.Value.xMax())
    let _xMin                                      = cell (fun () -> _MonotonicParabolic.Value.xMin())
    let _allowsExtrapolation                       = cell (fun () -> _MonotonicParabolic.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = cell (fun () -> _MonotonicParabolic.Value.disableExtrapolation(b.Value)
                                                                     _MonotonicParabolic.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = cell (fun () -> _MonotonicParabolic.Value.enableExtrapolation(b.Value)
                                                                     _MonotonicParabolic.Value)
    let _extrapolate                               = cell (fun () -> _MonotonicParabolic.Value.extrapolate)
    do this.Bind(_MonotonicParabolic)

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
