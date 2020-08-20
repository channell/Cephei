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
  Gauss-Legendre integration This class performs a 1-dimensional Gauss-Legendre integration.

  </summary> *)
[<AutoSerializable(true)>]
type GaussLegendreIntegrationModel
    ( n                                            : ICell<int>
    ) as this =

    inherit Model<GaussLegendreIntegration> ()
(*
    Parameters
*)
    let _n                                         = n
(*
    Functions
*)
    let _GaussLegendreIntegration                  = cell (fun () -> new GaussLegendreIntegration (n.Value))
    let _order                                     = cell (fun () -> _GaussLegendreIntegration.Value.order())
    let _value                                     (f : ICell<Func<double,double>>)   
                                                   = cell (fun () -> _GaussLegendreIntegration.Value.value(f.Value))
    let _weights                                   = cell (fun () -> _GaussLegendreIntegration.Value.weights())
    let _x                                         = cell (fun () -> _GaussLegendreIntegration.Value.x())
    do this.Bind(_GaussLegendreIntegration)

(* 
    Externally visible/bindable properties
*)
    member this.n                                  = _n 
    member this.Order                              = _order
    member this.Value                              f   
                                                   = _value f 
    member this.Weights                            = _weights
    member this.X                                  = _x
