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
  %SABR interpolation factory and traits

  </summary> *)
[<AutoSerializable(true)>]
type SABRModel
    ( t                                            : ICell<double>
    , forward                                      : ICell<double>
    , alpha                                        : ICell<double>
    , beta                                         : ICell<double>
    , nu                                           : ICell<double>
    , rho                                          : ICell<double>
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

    inherit Model<SABR> ()
(*
    Parameters
*)
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
    let _SABR                                      = cell (fun () -> new SABR (t.Value, forward.Value, alpha.Value, beta.Value, nu.Value, rho.Value, alphaIsFixed.Value, betaIsFixed.Value, nuIsFixed.Value, rhoIsFixed.Value, vegaWeighted.Value, endCriteria.Value, optMethod.Value, errorAccept.Value, useMaxError.Value, maxGuesses.Value, shift.Value, volatilityType.Value, approximationModel.Value))
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (xEnd : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _SABR.Value.interpolate(xBegin.Value, xEnd.Value, yBegin.Value))
    do this.Bind(_SABR)
(* 
    casting 
*)
    internal new () = new SABRModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SABR.Value <- v
    static member Cast (p : ICell<SABR>) = 
        if p :? SABRModel then 
            p :?> SABRModel
        else
            let o = new SABRModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
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
    member this.Interpolate                        xBegin xEnd yBegin   
                                                   = _interpolate xBegin xEnd yBegin 
