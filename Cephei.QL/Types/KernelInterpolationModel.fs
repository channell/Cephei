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
  Implementation of the kernel interpolation approach, which can be found in "Foreign Exchange Risk" by Hakala, Wystup page 256.  The kernel in the implementation is kept general, although a Gaussian is considered in the cited text.
! \pre the \f$ x \f$ values must be sorted. \pre kernel needs a Real operator()(Real x) implementation
  </summary> *)
[<AutoSerializable(true)>]
type KernelInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , kernel                                       : ICell<IKernelFunction>
    ) as this =

    inherit Model<KernelInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _kernel                                    = kernel
(*
    Functions
*)
    let mutable
        _KernelInterpolation                       = make (fun () -> new KernelInterpolation (xBegin.Value, size.Value, yBegin.Value, kernel.Value))
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.update()
                                                                                          _KernelInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.xMax())
    let _xMin                                      = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.xMin())
    let _allowsExtrapolation                       = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.disableExtrapolation(b.Value)
                                                                                          _KernelInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.enableExtrapolation(b.Value)
                                                                                          _KernelInterpolation.Value)
    let _extrapolate                               = triv _KernelInterpolation (fun () -> _KernelInterpolation.Value.extrapolate)
    do this.Bind(_KernelInterpolation)
(* 
    casting 
*)
    internal new () = new KernelInterpolationModel(null,null,null,null)
    member internal this.Inject v = _KernelInterpolation <- v
    static member Cast (p : ICell<KernelInterpolation>) = 
        if p :? KernelInterpolationModel then 
            p :?> KernelInterpolationModel
        else
            let o = new KernelInterpolationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.kernel                             = _kernel 
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
