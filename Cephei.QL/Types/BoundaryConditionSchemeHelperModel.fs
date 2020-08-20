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
type BoundaryConditionSchemeHelperModel
    ( bcSet                                        : ICell<Generic.List<BoundaryCondition<FdmLinearOp>>>
    ) as this =

    inherit Model<BoundaryConditionSchemeHelper> ()
(*
    Parameters
*)
    let _bcSet                                     = bcSet
(*
    Functions
*)
    let _BoundaryConditionSchemeHelper             = cell (fun () -> new BoundaryConditionSchemeHelper (bcSet.Value))
    let _applyAfterApplying                        (a : ICell<Vector>)   
                                                   = cell (fun () -> _BoundaryConditionSchemeHelper.Value.applyAfterApplying(a.Value)
                                                                     _BoundaryConditionSchemeHelper.Value)
    let _applyAfterSolving                         (a : ICell<Vector>)   
                                                   = cell (fun () -> _BoundaryConditionSchemeHelper.Value.applyAfterSolving(a.Value)
                                                                     _BoundaryConditionSchemeHelper.Value)
    let _applyBeforeApplying                       (op : ICell<IOperator>)   
                                                   = cell (fun () -> _BoundaryConditionSchemeHelper.Value.applyBeforeApplying(op.Value)
                                                                     _BoundaryConditionSchemeHelper.Value)
    let _applyBeforeSolving                        (op : ICell<IOperator>) (a : ICell<Vector>)   
                                                   = cell (fun () -> _BoundaryConditionSchemeHelper.Value.applyBeforeSolving(op.Value, a.Value)
                                                                     _BoundaryConditionSchemeHelper.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _BoundaryConditionSchemeHelper.Value.setTime(t.Value)
                                                                     _BoundaryConditionSchemeHelper.Value)
    do this.Bind(_BoundaryConditionSchemeHelper)

(* 
    Externally visible/bindable properties
*)
    member this.bcSet                              = _bcSet 
    member this.ApplyAfterApplying                 a   
                                                   = _applyAfterApplying a 
    member this.ApplyAfterSolving                  a   
                                                   = _applyAfterSolving a 
    member this.ApplyBeforeApplying                op   
                                                   = _applyBeforeApplying op 
    member this.ApplyBeforeSolving                 op a   
                                                   = _applyBeforeSolving op a 
    member this.SetTime                            t   
                                                   = _setTime t 
