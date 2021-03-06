﻿(*
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
  Gauss-Jacobi integration This class performs a 1-dimensional Gauss-Jacobi integration.

  </summary> *)
[<AutoSerializable(true)>]
type GaussJacobiIntegrationModel
    ( n                                            : ICell<int>
    , alpha                                        : ICell<double>
    , beta                                         : ICell<double>
    ) as this =

    inherit Model<GaussJacobiIntegration> ()
(*
    Parameters
*)
    let _n                                         = n
    let _alpha                                     = alpha
    let _beta                                      = beta
(*
    Functions
*)
    let mutable
        _GaussJacobiIntegration                    = make (fun () -> new GaussJacobiIntegration (n.Value, alpha.Value, beta.Value))
    let _order                                     = triv _GaussJacobiIntegration (fun () -> _GaussJacobiIntegration.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = triv _GaussJacobiIntegration (fun () -> _GaussJacobiIntegration.Value.value(f.Value))
    let _weights                                   = triv _GaussJacobiIntegration (fun () -> _GaussJacobiIntegration.Value.weights())
    let _x                                         = triv _GaussJacobiIntegration (fun () -> _GaussJacobiIntegration.Value.x())
    do this.Bind(_GaussJacobiIntegration)
(* 
    casting 
*)
    internal new () = new GaussJacobiIntegrationModel(null,null,null)
    member internal this.Inject v = _GaussJacobiIntegration <- v
    static member Cast (p : ICell<GaussJacobiIntegration>) = 
        if p :? GaussJacobiIntegrationModel then 
            p :?> GaussJacobiIntegrationModel
        else
            let o = new GaussJacobiIntegrationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.alpha                              = _alpha 
    member this.beta                               = _beta 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x
