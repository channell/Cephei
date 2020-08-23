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


  </summary> *)
[<AutoSerializable(true)>]
type ProjectionModel
    ( parameterValues                              : ICell<Vector>
    , fixParameters                                : ICell<Generic.List<bool>>
    ) as this =

    inherit Model<Projection> ()
(*
    Parameters
*)
    let _parameterValues                           = parameterValues
    let _fixParameters                             = fixParameters
(*
    Functions
*)
    let _Projection                                = cell (fun () -> new Projection (parameterValues.Value, fixParameters.Value))
    let _include                                   (projectedParameters : ICell<Vector>)   
                                                   = triv (fun () -> _Projection.Value.INCLUDE(projectedParameters.Value))
    let _project                                   (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _Projection.Value.project(parameters.Value))
    do this.Bind(_Projection)

(* 
    Externally visible/bindable properties
*)
    member this.parameterValues                    = _parameterValues 
    member this.fixParameters                      = _fixParameters 
    member this.Include                            projectedParameters   
                                                   = _include projectedParameters 
    member this.Project                            parameters   
                                                   = _project parameters 
