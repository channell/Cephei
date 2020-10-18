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
  Gauss-Gegenbauer integration This class performs a 1-dimensional Gauss-Gegenbauer integration.

  </summary> *)
[<AutoSerializable(true)>]
type GaussGegenbauerIntegrationModel
    ( n                                            : ICell<int>
    , lambda                                       : ICell<double>
    ) as this =

    inherit Model<GaussGegenbauerIntegration> ()
(*
    Parameters
*)
    let _n                                         = n
    let _lambda                                    = lambda
(*
    Functions
*)
    let mutable
        _GaussGegenbauerIntegration                = cell (fun () -> new GaussGegenbauerIntegration (n.Value, lambda.Value))
    let _order                                     = triv (fun () -> _GaussGegenbauerIntegration.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = triv (fun () -> _GaussGegenbauerIntegration.Value.value(f.Value))
    let _weights                                   = triv (fun () -> _GaussGegenbauerIntegration.Value.weights())
    let _x                                         = triv (fun () -> _GaussGegenbauerIntegration.Value.x())
    do this.Bind(_GaussGegenbauerIntegration)
(* 
    casting 
*)
    internal new () = new GaussGegenbauerIntegrationModel(null,null)
    member internal this.Inject v = _GaussGegenbauerIntegration <- v
    static member Cast (p : ICell<GaussGegenbauerIntegration>) = 
        if p :? GaussGegenbauerIntegrationModel then 
            p :?> GaussGegenbauerIntegrationModel
        else
            let o = new GaussGegenbauerIntegrationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.lambda                             = _lambda 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x
