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
type FdmDirichletBoundaryModel
    ( mesher                                       : ICell<FdmMesher>
    , valueOnBoundary                              : ICell<double>
    , direction                                    : ICell<int>
    , side                                         : ICell<BoundaryCondition<FdmLinearOp>.Side>
    ) as this =

    inherit Model<FdmDirichletBoundary> ()
(*
    Parameters
*)
    let _mesher                                    = mesher
    let _valueOnBoundary                           = valueOnBoundary
    let _direction                                 = direction
    let _side                                      = side
(*
    Functions
*)
    let _FdmDirichletBoundary                      = cell (fun () -> new FdmDirichletBoundary (mesher.Value, valueOnBoundary.Value, direction.Value, side.Value))
    let _applyAfterApplying                        (v : ICell<Vector>)   
                                                   = triv (fun () -> _FdmDirichletBoundary.Value.applyAfterApplying(v.Value)
                                                                     _FdmDirichletBoundary.Value)
    let _applyAfterApplying1                       (x : ICell<double>) (value : ICell<double>)   
                                                   = triv (fun () -> _FdmDirichletBoundary.Value.applyAfterApplying(x.Value, value.Value))
    let _applyAfterSolving                         (v : ICell<Vector>)   
                                                   = triv (fun () -> _FdmDirichletBoundary.Value.applyAfterSolving(v.Value)
                                                                     _FdmDirichletBoundary.Value)
    let _applyBeforeApplying                       (o : ICell<IOperator>)   
                                                   = triv (fun () -> _FdmDirichletBoundary.Value.applyBeforeApplying(o.Value)
                                                                     _FdmDirichletBoundary.Value)
    let _applyBeforeSolving                        (o : ICell<IOperator>) (v : ICell<Vector>)   
                                                   = triv (fun () -> _FdmDirichletBoundary.Value.applyBeforeSolving(o.Value, v.Value)
                                                                     _FdmDirichletBoundary.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _FdmDirichletBoundary.Value.setTime(t.Value)
                                                                     _FdmDirichletBoundary.Value)
    do this.Bind(_FdmDirichletBoundary)

(* 
    Externally visible/bindable properties
*)
    member this.mesher                             = _mesher 
    member this.valueOnBoundary                    = _valueOnBoundary 
    member this.direction                          = _direction 
    member this.side                               = _side 
    member this.ApplyAfterApplying                 v   
                                                   = _applyAfterApplying v 
    member this.ApplyAfterApplying1                x value   
                                                   = _applyAfterApplying1 x value 
    member this.ApplyAfterSolving                  v   
                                                   = _applyAfterSolving v 
    member this.ApplyBeforeApplying                o   
                                                   = _applyBeforeApplying o 
    member this.ApplyBeforeSolving                 o v   
                                                   = _applyBeforeSolving o v 
    member this.SetTime                            t   
                                                   = _setTime t 
