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
  generalized Gauss-Hermite integration This class performs a 1-dimensional Gauss-Hermite integration.

  </summary> *)
[<AutoSerializable(true)>]
type GaussHermiteIntegrationModel
    ( n                                            : ICell<int>
    , mu                                           : ICell<double>
    ) as this =

    inherit Model<GaussHermiteIntegration> ()
(*
    Parameters
*)
    let _n                                         = n
    let _mu                                        = mu
(*
    Functions
*)
    let mutable
        _GaussHermiteIntegration                   = cell (fun () -> new GaussHermiteIntegration (n.Value, mu.Value))
    let _order                                     = triv (fun () -> _GaussHermiteIntegration.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = triv (fun () -> _GaussHermiteIntegration.Value.value(f.Value))
    let _weights                                   = triv (fun () -> _GaussHermiteIntegration.Value.weights())
    let _x                                         = triv (fun () -> _GaussHermiteIntegration.Value.x())
    do this.Bind(_GaussHermiteIntegration)
(* 
    casting 
*)
    internal new () = new GaussHermiteIntegrationModel(null,null)
    member internal this.Inject v = _GaussHermiteIntegration <- v
    static member Cast (p : ICell<GaussHermiteIntegration>) = 
        if p :? GaussHermiteIntegrationModel then 
            p :?> GaussHermiteIntegrationModel
        else
            let o = new GaussHermiteIntegrationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.mu                                 = _mu 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x
