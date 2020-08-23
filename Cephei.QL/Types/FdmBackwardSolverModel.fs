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
type FdmBackwardSolverModel
    ( map                                          : ICell<FdmLinearOpComposite>
    , bcSet                                        : ICell<FdmBoundaryConditionSet>
    , condition                                    : ICell<FdmStepConditionComposite>
    , schemeDesc                                   : ICell<FdmSchemeDesc>
    ) as this =

    inherit Model<FdmBackwardSolver> ()
(*
    Parameters
*)
    let _map                                       = map
    let _bcSet                                     = bcSet
    let _condition                                 = condition
    let _schemeDesc                                = schemeDesc
(*
    Functions
*)
    let _FdmBackwardSolver                         = cell (fun () -> new FdmBackwardSolver (map.Value, bcSet.Value, condition.Value, schemeDesc.Value))
    let _rollback                                  (a : ICell<Object ref>) (from : ICell<double>) (To : ICell<double>) (steps : ICell<int>) (dampingSteps : ICell<int>)   
                                                   = triv (fun () -> _FdmBackwardSolver.Value.rollback(a.Value, from.Value, To.Value, steps.Value, dampingSteps.Value)
                                                                     _FdmBackwardSolver.Value)
    do this.Bind(_FdmBackwardSolver)

(* 
    Externally visible/bindable properties
*)
    member this.map                                = _map 
    member this.bcSet                              = _bcSet 
    member this.condition                          = _condition 
    member this.schemeDesc                         = _schemeDesc 
    member this.Rollback                           a from To steps dampingSteps   
                                                   = _rollback a from To steps dampingSteps 
