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
  %SABR smile interpolation between discrete volatility points. For volatility type Normal and when the forward < 0, it is suggested to fix beta = 0.0

  </summary> *)
[<AutoSerializable(true)>]
type SABRInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , xEnd                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , t                                            : ICell<double>
    , forward                                      : ICell<double>
    , alpha                                        : ICell<Nullable<double>>
    , beta                                         : ICell<Nullable<double>>
    , nu                                           : ICell<Nullable<double>>
    , rho                                          : ICell<Nullable<double>>
    , alphaIsFixed                                 : ICell<bool>
    , betaIsFixed                                  : ICell<bool>
    , nuIsFixed                                    : ICell<bool>
    , rhoIsFixed                                   : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , optMethod                                    : ICell<OptimizationMethod>
    , errorAccept                                  : ICell<double>
    , useMaxError                                  : ICell<bool>
    , maxGuesses                                   : ICell<int>
    , shift                                        : ICell<double>
    , volatilityType                               : ICell<VolatilityType>
    , approximationModel                           : ICell<SabrApproximationModel>
    ) as this =

    inherit Model<SABRInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _xEnd                                      = xEnd
    let _yBegin                                    = yBegin
    let _t                                         = t
    let _forward                                   = forward
    let _alpha                                     = alpha
    let _beta                                      = beta
    let _nu                                        = nu
    let _rho                                       = rho
    let _alphaIsFixed                              = alphaIsFixed
    let _betaIsFixed                               = betaIsFixed
    let _nuIsFixed                                 = nuIsFixed
    let _rhoIsFixed                                = rhoIsFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _optMethod                                 = optMethod
    let _errorAccept                               = errorAccept
    let _useMaxError                               = useMaxError
    let _maxGuesses                                = maxGuesses
    let _shift                                     = shift
    let _volatilityType                            = volatilityType
    let _approximationModel                        = approximationModel
(*
    Functions
*)
    let _SABRInterpolation                         = cell (fun () -> new SABRInterpolation (xBegin.Value, xEnd.Value, yBegin.Value, t.Value, forward.Value, alpha.Value, beta.Value, nu.Value, rho.Value, alphaIsFixed.Value, betaIsFixed.Value, nuIsFixed.Value, rhoIsFixed.Value, vegaWeighted.Value, endCriteria.Value, optMethod.Value, errorAccept.Value, useMaxError.Value, maxGuesses.Value, shift.Value, volatilityType.Value, approximationModel.Value))
    let _alpha                                     = triv (fun () -> _SABRInterpolation.Value.alpha())
    let _beta                                      = triv (fun () -> _SABRInterpolation.Value.beta())
    let _endCriteria                               = triv (fun () -> _SABRInterpolation.Value.endCriteria())
    let _expiry                                    = triv (fun () -> _SABRInterpolation.Value.expiry())
    let _forward                                   = triv (fun () -> _SABRInterpolation.Value.forward())
    let _interpolationWeights                      = triv (fun () -> _SABRInterpolation.Value.interpolationWeights())
    let _maxError                                  = triv (fun () -> _SABRInterpolation.Value.maxError())
    let _nu                                        = triv (fun () -> _SABRInterpolation.Value.nu())
    let _rho                                       = triv (fun () -> _SABRInterpolation.Value.rho())
    let _rmsError                                  = triv (fun () -> _SABRInterpolation.Value.rmsError())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SABRInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv (fun () -> _SABRInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SABRInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SABRInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv (fun () -> _SABRInterpolation.Value.update()
                                                                     _SABRInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _SABRInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _SABRInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv (fun () -> _SABRInterpolation.Value.xMax())
    let _xMin                                      = triv (fun () -> _SABRInterpolation.Value.xMin())
    let _allowsExtrapolation                       = triv (fun () -> _SABRInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _SABRInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _SABRInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _SABRInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _SABRInterpolation.Value)
    let _extrapolate                               = triv (fun () -> _SABRInterpolation.Value.extrapolate)
    do this.Bind(_SABRInterpolation)
(* 
    casting 
*)
    internal new () = SABRInterpolationModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SABRInterpolation.Value <- v
    static member Cast (p : ICell<SABRInterpolation>) = 
        if p :? SABRInterpolationModel then 
            p :?> SABRInterpolationModel
        else
            let o = new SABRInterpolationModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.xEnd                               = _xEnd 
    member this.yBegin                             = _yBegin 
    member this.t                                  = _t 
    member this.forward                            = _forward 
    member this.alpha                              = _alpha 
    member this.beta                               = _beta 
    member this.nu                                 = _nu 
    member this.rho                                = _rho 
    member this.alphaIsFixed                       = _alphaIsFixed 
    member this.betaIsFixed                        = _betaIsFixed 
    member this.nuIsFixed                          = _nuIsFixed 
    member this.rhoIsFixed                         = _rhoIsFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.optMethod                          = _optMethod 
    member this.errorAccept                        = _errorAccept 
    member this.useMaxError                        = _useMaxError 
    member this.maxGuesses                         = _maxGuesses 
    member this.shift                              = _shift 
    member this.volatilityType                     = _volatilityType 
    member this.approximationModel                 = _approximationModel 
    member this.Alpha                              = _alpha
    member this.Beta                               = _beta
    member this.EndCriteria                        = _endCriteria
    member this.Expiry                             = _expiry
    member this.Forward                            = _forward
    member this.InterpolationWeights               = _interpolationWeights
    member this.MaxError                           = _maxError
    member this.Nu                                 = _nu
    member this.Rho                                = _rho
    member this.RmsError                           = _rmsError
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
