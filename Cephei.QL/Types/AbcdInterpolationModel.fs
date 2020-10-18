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
  interpolations
! Constructor
  </summary> *)
[<AutoSerializable(true)>]
type AbcdInterpolationModel
    ( xBegin                                       : ICell<Generic.List<double>>
    , size                                         : ICell<int>
    , yBegin                                       : ICell<Generic.List<double>>
    , a                                            : ICell<double>
    , b                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    , aIsFixed                                     : ICell<bool>
    , bIsFixed                                     : ICell<bool>
    , cIsFixed                                     : ICell<bool>
    , dIsFixed                                     : ICell<bool>
    , vegaWeighted                                 : ICell<bool>
    , endCriteria                                  : ICell<EndCriteria>
    , optMethod                                    : ICell<OptimizationMethod>
    ) as this =

    inherit Model<AbcdInterpolation> ()
(*
    Parameters
*)
    let _xBegin                                    = xBegin
    let _size                                      = size
    let _yBegin                                    = yBegin
    let _a                                         = a
    let _b                                         = b
    let _c                                         = c
    let _d                                         = d
    let _aIsFixed                                  = aIsFixed
    let _bIsFixed                                  = bIsFixed
    let _cIsFixed                                  = cIsFixed
    let _dIsFixed                                  = dIsFixed
    let _vegaWeighted                              = vegaWeighted
    let _endCriteria                               = endCriteria
    let _optMethod                                 = optMethod
(*
    Functions
*)
    let mutable
        _AbcdInterpolation                         = cell (fun () -> new AbcdInterpolation (xBegin.Value, size.Value, yBegin.Value, a.Value, b.Value, c.Value, d.Value, aIsFixed.Value, bIsFixed.Value, cIsFixed.Value, dIsFixed.Value, vegaWeighted.Value, endCriteria.Value, optMethod.Value))
    let _a                                         = triv (fun () -> _AbcdInterpolation.Value.a())
    let _b                                         = triv (fun () -> _AbcdInterpolation.Value.b())
    let _c                                         = triv (fun () -> _AbcdInterpolation.Value.c())
    let _d                                         = triv (fun () -> _AbcdInterpolation.Value.d())
    let _endCriteria                               = triv (fun () -> _AbcdInterpolation.Value.endCriteria())
    let _k                                         (t : ICell<double>) (xBegin : ICell<Generic.List<double>>) (size : ICell<int>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.k(t.Value, xBegin.Value, size.Value))
    let _k1                                        = triv (fun () -> _AbcdInterpolation.Value.k())
    let _maxError                                  = triv (fun () -> _AbcdInterpolation.Value.maxError())
    let _rmsError                                  = triv (fun () -> _AbcdInterpolation.Value.rmsError())
    let _derivative                                (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.derivative(x.Value, allowExtrapolation.Value))
    let _empty                                     = triv (fun () -> _AbcdInterpolation.Value.empty())
    let _primitive                                 (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.primitive(x.Value, allowExtrapolation.Value))
    let _secondDerivative                          (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.secondDerivative(x.Value, allowExtrapolation.Value))
    let _update                                    = triv (fun () -> _AbcdInterpolation.Value.update()
                                                                     _AbcdInterpolation.Value)
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.value(x.Value))
    let _value1                                    (x : ICell<double>) (allowExtrapolation : ICell<bool>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.value(x.Value, allowExtrapolation.Value))
    let _xMax                                      = triv (fun () -> _AbcdInterpolation.Value.xMax())
    let _xMin                                      = triv (fun () -> _AbcdInterpolation.Value.xMin())
    let _allowsExtrapolation                       = triv (fun () -> _AbcdInterpolation.Value.allowsExtrapolation())
    let _disableExtrapolation                      (b : ICell<bool>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.disableExtrapolation(b.Value)
                                                                     _AbcdInterpolation.Value)
    let _enableExtrapolation                       (b : ICell<bool>)   
                                                   = triv (fun () -> _AbcdInterpolation.Value.enableExtrapolation(b.Value)
                                                                     _AbcdInterpolation.Value)
    let _extrapolate                               = triv (fun () -> _AbcdInterpolation.Value.extrapolate)
    do this.Bind(_AbcdInterpolation)
(* 
    casting 
*)
    internal new () = new AbcdInterpolationModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _AbcdInterpolation <- v
    static member Cast (p : ICell<AbcdInterpolation>) = 
        if p :? AbcdInterpolationModel then 
            p :?> AbcdInterpolationModel
        else
            let o = new AbcdInterpolationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xBegin                             = _xBegin 
    member this.size                               = _size 
    member this.yBegin                             = _yBegin 
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.c                                  = _c 
    member this.d                                  = _d 
    member this.aIsFixed                           = _aIsFixed 
    member this.bIsFixed                           = _bIsFixed 
    member this.cIsFixed                           = _cIsFixed 
    member this.dIsFixed                           = _dIsFixed 
    member this.vegaWeighted                       = _vegaWeighted 
    member this.endCriteria                        = _endCriteria 
    member this.optMethod                          = _optMethod 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.C                                  = _c
    member this.D                                  = _d
    member this.EndCriteria                        = _endCriteria
    member this.K                                  t xBegin size   
                                                   = _k t xBegin size 
    member this.K1                                 = _k1
    member this.MaxError                           = _maxError
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
