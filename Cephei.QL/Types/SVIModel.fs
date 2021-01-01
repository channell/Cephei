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
type SVIModel
    ( t                                            : ICell<double>
    , forward                                      : ICell<double>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , sigma                                        : ICell<double>
    , rho                                          : ICell<double>
    , m                                            : ICell<double>
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
    , addParams                                    : ICell<Generic.List<Nullable<double>>>
    ) as this =

    inherit Model<SVI> ()
(*
    Parameters
*)
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
        _SVI                                       = make (fun () -> new SVI (t.Value, forward.Value, a.Value, b.Value, sigma.Value, rho.Value, m.Value, aIsFixed.Value, bIsFixed.Value, sigmaIsFixed.Value, rhoIsFixed.Value, mIsFixed.Value, vegaWeighted.Value, endCriteria.Value, optMethod.Value, errorAccept.Value, useMaxError.Value, maxGuesses.Value, addParams.Value))
    let _interpolate                               (xBegin : ICell<Generic.List<double>>) (xEnd : ICell<int>) (yBegin : ICell<Generic.List<double>>)   
                                                   = triv _SVI (fun () -> _SVI.Value.interpolate(xBegin.Value, xEnd.Value, yBegin.Value))
    do this.Bind(_SVI)
(* 
    casting 
*)
    internal new () = new SVIModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SVI <- v
    static member Cast (p : ICell<SVI>) = 
        if p :? SVIModel then 
            p :?> SVIModel
        else
            let o = new SVIModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
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
    member this.Interpolate                        xBegin xEnd yBegin   
                                                   = _interpolate xBegin xEnd yBegin 
