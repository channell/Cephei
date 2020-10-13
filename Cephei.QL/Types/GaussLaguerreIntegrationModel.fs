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
  generalized Gauss-Laguerre integration This class performs a 1-dimensional Gauss-Laguerre integration.

  </summary> *)
[<AutoSerializable(true)>]
type GaussLaguerreIntegrationModel
    ( n                                            : ICell<int>
    , s                                            : ICell<double>
    ) as this =

    inherit Model<GaussLaguerreIntegration> ()
(*
    Parameters
*)
    let _n                                         = n
    let _s                                         = s
(*
    Functions
*)
    let _GaussLaguerreIntegration                  = cell (fun () -> new GaussLaguerreIntegration (n.Value, s.Value))
    let _order                                     = triv (fun () -> _GaussLaguerreIntegration.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = triv (fun () -> _GaussLaguerreIntegration.Value.value(f.Value))
    let _weights                                   = triv (fun () -> _GaussLaguerreIntegration.Value.weights())
    let _x                                         = triv (fun () -> _GaussLaguerreIntegration.Value.x())
    do this.Bind(_GaussLaguerreIntegration)
(* 
    casting 
*)
    internal new () = new GaussLaguerreIntegrationModel(null,null)
    member internal this.Inject v = _GaussLaguerreIntegration.Value <- v
    static member Cast (p : ICell<GaussLaguerreIntegration>) = 
        if p :? GaussLaguerreIntegrationModel then 
            p :?> GaussLaguerreIntegrationModel
        else
            let o = new GaussLaguerreIntegrationModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.s                                  = _s 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x
