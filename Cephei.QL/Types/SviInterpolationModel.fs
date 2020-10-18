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
  %SABR smile interpolation between discrete volatility points.

  </summary> *)
[<AutoSerializable(true)>]
type SviInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , t                                            : ICell<double>
    , forward                                      : ICell<double>
    , a                                            : ICell<Nullable<double>>
    , b                                            : ICell<Nullable<double>>
    , sigma                                        : ICell<Nullable<double>>
    , rho                                          : ICell<Nullable<double>>
    , m                                            : ICell<Nullable<double>>
    , aIsFixed                                     : ICell<bool>
    , bIsFixed                                     : ICell<bool>
    , sigmaIsFixed                                 : ICell<bool>
    , rhoIsFixed                                   : ICell<bool>
    , mIsFixed                                     : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , optMethod                                    : ICell<OptimizationMethod>
    , errorAccept                                  : ICell<double>
    , useMaxError                                  : ICell<bool>
    , maxGuesses                                   : ICell<int>
    , addParams                                    : ICell<List<Nullable<double>>>
    ) as this =

    inherit Model<SviInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _t                                         = t
    let _forward                                   = forward
    let _a                                         = a
    let _b                                         = b
    let _sigma                                     = sigma
    let _rho                                       = rho
    let _m                                         = m
    let _aIsFixed                                  = aIsFixed
    let _bIsFixed                                  = bIsFixed
    let _sigmaIsFixed                              = sigmaIsFixed
    let _rhoIsFixed                                = rhoIsFixed
    let _mIsFixed                                  = mIsFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _optMethod                                 = optMethod
    let _errorAccept                               = errorAccept
    let _useMaxError                               = useMaxError
    let _maxGuesses                                = maxGuesses
    let _addParams                                 = addParams
(*
    Functions
*)
    let mutable
        _SviInterpolation                          = cell (fun () -> new SviInterpolation (xBegin.Value, size.Value, yBegin.Value, t.Value, forward.Value, a.Value, b.Value, sigma.Value, rho.Value, m.Value, aIsFixed.Value, bIsFixed.Value, sigmaIsFixed.Value, rhoIsFixed.Value, mIsFixed.Value, vegaWeighted.Value, endCriteria.Value, optMethod.Value, errorAccept.Value, useMaxError.Value, maxGuesses.Value, addParams.Value))
    let _a                                         = triv (fun () -> _SviInterpolation.Value.a())
    let _b                                         = triv (fun () -> _SviInterpolation.Value.b())
    let _endCriteria                               = triv (fun () -> _SviInterpolation.Value.endCriteria())
    let _expiry                                    = triv (fun () -> _SviInterpolation.Value.expiry())
    let _forward                                   = triv (fun () -> _SviInterpolation.Value.forward())
    let _interpolationWeights                      = triv (fun () -> _SviInterpolation.Value.interpolationWeights())
    let _m                                         = triv (fun () -> _SviInterpolation.Value.m())
    let _maxError                                  = triv (fun () -> _SviInterpolation.Value.maxError())
    let _rho                                       = triv (fun () -> _SviInterpolation.Value.rho())
    let _rmsError                                  = triv (fun () -> _SviInterpolation.Value.rmsError())
    let _sigma                                     = triv (fun () -> _SviInterpolation.Value.sigma())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SviInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv (fun () -> _SviInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SviInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SviInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv (fun () -> _SviInterpolation.Value.update()
                                                                     _SviInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _SviInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SviInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv (fun () -> _SviInterpolation.Value.xMax())
    let _xMin                                      = triv (fun () -> _SviInterpolation.Value.xMin())
    let _allowsExtrapolation                       = triv (fun () -> _SviInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _SviInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _SviInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _SviInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _SviInterpolation.Value)
    let _extrapolate                               = triv (fun () -> _SviInterpolation.Value.extrapolate)
    do this.Bind(_SviInterpolation)
(* 
    casting 
*)
    internal new () = new SviInterpolationModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SviInterpolation <- v
    static member Cast (p : ICell<SviInterpolation>) = 
        if p :? SviInterpolationModel then 
            p :?> SviInterpolationModel
        else
            let o = new SviInterpolationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.t                                  = _t 
    member this.forward                            = _forward 
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.sigma                              = _sigma 
    member this.rho                                = _rho 
    member this.m                                  = _m 
    member this.aIsFixed                           = _aIsFixed 
    member this.bIsFixed                           = _bIsFixed 
    member this.sigmaIsFixed                       = _sigmaIsFixed 
    member this.rhoIsFixed                         = _rhoIsFixed 
    member this.mIsFixed                           = _mIsFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.optMethod                          = _optMethod 
    member this.errorAccept                        = _errorAccept 
    member this.useMaxError                        = _useMaxError 
    member this.maxGuesses                         = _maxGuesses 
    member this.addParams                          = _addParams 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.EndCriteria                        = _endCriteria
    member this.Expiry                             = _expiry
    member this.Forward                            = _forward
    member this.InterpolationWeights               = _interpolationWeights
    member this.M                                  = _m
    member this.MaxError                           = _maxError
    member this.Rho                                = _rho
    member this.RmsError                           = _rmsError
    member this.Sigma                              = _sigma
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
