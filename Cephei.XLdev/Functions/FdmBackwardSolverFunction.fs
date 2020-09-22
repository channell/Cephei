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
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module FdmBackwardSolverFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FdmBackwardSolver", Description="Create a FdmBackwardSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBackwardSolver_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="map",Description = "Reference to map")>] 
         map : obj)
        ([<ExcelArgument(Name="bcSet",Description = "Reference to bcSet")>] 
         bcSet : obj)
        ([<ExcelArgument(Name="condition",Description = "Reference to condition")>] 
         condition : obj)
        ([<ExcelArgument(Name="schemeDesc",Description = "Reference to schemeDesc")>] 
         schemeDesc : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _map = Helper.toCell<FdmLinearOpComposite> map "map" true
                let _bcSet = Helper.toCell<FdmBoundaryConditionSet> bcSet "bcSet" true
                let _condition = Helper.toCell<FdmStepConditionComposite> condition "condition" true
                let _schemeDesc = Helper.toCell<FdmSchemeDesc> schemeDesc "schemeDesc" true
                let builder () = withMnemonic mnemonic (Fun.FdmBackwardSolver 
                                                            _map.cell 
                                                            _bcSet.cell 
                                                            _condition.cell 
                                                            _schemeDesc.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FdmBackwardSolver>) l

                let source = Helper.sourceFold "Fun.FdmBackwardSolver" 
                                               [| _map.source
                                               ;  _bcSet.source
                                               ;  _condition.source
                                               ;  _schemeDesc.source
                                               |]
                let hash = Helper.hashFold 
                                [| _map.cell
                                ;  _bcSet.cell
                                ;  _condition.cell
                                ;  _schemeDesc.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FdmBackwardSolver_rollback", Description="Create a FdmBackwardSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBackwardSolver_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FdmBackwardSolver",Description = "Reference to FdmBackwardSolver")>] 
         fdmbackwardsolver : obj)
        ([<ExcelArgument(Name="a",Description = "Reference to a")>] 
         a : obj)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        ([<ExcelArgument(Name="dampingSteps",Description = "Reference to dampingSteps")>] 
         dampingSteps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FdmBackwardSolver = Helper.toCell<FdmBackwardSolver> fdmbackwardsolver "FdmBackwardSolver" true 
                let _a = Helper.toCell<Object> a "a" true
                let _from = Helper.toCell<double> from "from" true
                let _To = Helper.toCell<double> To "To" true
                let _steps = Helper.toCell<int> steps "steps" true
                let _dampingSteps = Helper.toCell<int> dampingSteps "dampingSteps" true
                let builder () = withMnemonic mnemonic ((_FdmBackwardSolver.cell :?> FdmBackwardSolverModel).Rollback
                                                            _a.cell 
                                                            _from.cell 
                                                            _To.cell 
                                                            _steps.cell 
                                                            _dampingSteps.cell 
                                                       ) :> ICell
                let format (o : FdmBackwardSolver) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FdmBackwardSolver.source + ".Rollback") 
                                               [| _FdmBackwardSolver.source
                                               ;  _a.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _steps.source
                                               ;  _dampingSteps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FdmBackwardSolver.cell
                                ;  _a.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _steps.cell
                                ;  _dampingSteps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FdmBackwardSolver_Range", Description="Create a range of FdmBackwardSolver",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FdmBackwardSolver_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FdmBackwardSolver")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FdmBackwardSolver> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FdmBackwardSolver>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FdmBackwardSolver>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FdmBackwardSolver>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
