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
  Gauss-Chebyshev integration This class performs a 1-dimensional Gauss-Chebyshev integration.

  </summary> *)
[<AutoSerializable(true)>]
type GaussChebyshevIntegrationModel
    ( n                                            : ICell<int>
    ) as this =

    inherit Model<GaussChebyshevIntegration> ()
(*
    Parameters
*)
    let _n                                         = n
(*
    Functions
*)
    let _GaussChebyshevIntegration                 = cell (fun () -> new GaussChebyshevIntegration (n.Value))
    let _order                                     = triv (fun () -> _GaussChebyshevIntegration.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = triv (fun () -> _GaussChebyshevIntegration.Value.value(f.Value))
    let _weights                                   = triv (fun () -> _GaussChebyshevIntegration.Value.weights())
    let _x                                         = triv (fun () -> _GaussChebyshevIntegration.Value.x())
    do this.Bind(_GaussChebyshevIntegration)
(* 
    casting 
*)
    internal new () = GaussChebyshevIntegrationModel(null)
    member internal this.Inject v = _GaussChebyshevIntegration.Value <- v
    static member Cast (p : ICell<GaussChebyshevIntegration>) = 
        if p :? GaussChebyshevIntegrationModel then 
            p :?> GaussChebyshevIntegrationModel
        else
            let o = new GaussChebyshevIntegrationModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x
