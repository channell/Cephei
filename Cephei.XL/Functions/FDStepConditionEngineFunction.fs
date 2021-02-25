﻿(*
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
  Finite-differences pricing engine for American-style vanilla options
  </summary> *)
[<AutoSerializable(true)>]
module FDStepConditionEngineFunction =


    (*
        required for template inheritance
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine_factory", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDStepConditionEngine",Description = "FDStepConditionEngine")>] 
         fdstepconditionengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDStepConditionEngine = Helper.toModelReference<FDStepConditionEngine> fdstepconditionengine "FDStepConditionEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let builder (current : ICell) = ((FDStepConditionEngineModel.Cast _FDStepConditionEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDStepConditionEngine.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDStepConditionEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDStepConditionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        public FDStepConditionEngine(GeneralizedBlackScholesProcess process, int timeSteps, int gridPoints, bool timeDependent = false)
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool")>] 
         timeDependent : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _gridPoints = Helper.toCell<int> gridPoints "gridPoints" 
                let _timeDependent = Helper.toCell<bool> timeDependent "timeDependent" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FDStepConditionEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDStepConditionEngine>) l

                let source () = Helper.sourceFold "Fun.FDStepConditionEngine" 
                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDStepConditionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        required for generics
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine1", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.FDStepConditionEngine1 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDStepConditionEngine>) l

                let source () = Helper.sourceFold "Fun.FDStepConditionEngine1" 
                                               [| _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [|  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDStepConditionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine_setStepCondition", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDStepConditionEngine",Description = "FDStepConditionEngine")>] 
         fdstepconditionengine : obj)
        ([<ExcelArgument(Name="impl",Description = "Vector")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDStepConditionEngine = Helper.toModelReference<FDStepConditionEngine> fdstepconditionengine "FDStepConditionEngine"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = ((FDStepConditionEngineModel.Cast _FDStepConditionEngine.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDStepConditionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDStepConditionEngine.source + ".SetStepCondition") 

                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDStepConditionEngine.cell
                                ;  _impl.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine_ensureStrikeInGrid", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDStepConditionEngine",Description = "FDStepConditionEngine")>] 
         fdstepconditionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDStepConditionEngine = Helper.toModelReference<FDStepConditionEngine> fdstepconditionengine "FDStepConditionEngine"  
                let builder (current : ICell) = ((FDStepConditionEngineModel.Cast _FDStepConditionEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDStepConditionEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDStepConditionEngine.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDStepConditionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine_getResidualTime", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDStepConditionEngine",Description = "FDStepConditionEngine")>] 
         fdstepconditionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDStepConditionEngine = Helper.toModelReference<FDStepConditionEngine> fdstepconditionengine "FDStepConditionEngine"  
                let builder (current : ICell) = ((FDStepConditionEngineModel.Cast _FDStepConditionEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDStepConditionEngine.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDStepConditionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine_grid", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDStepConditionEngine",Description = "FDStepConditionEngine")>] 
         fdstepconditionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDStepConditionEngine = Helper.toModelReference<FDStepConditionEngine> fdstepconditionengine "FDStepConditionEngine"  
                let builder (current : ICell) = ((FDStepConditionEngineModel.Cast _FDStepConditionEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDStepConditionEngine.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDStepConditionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDStepConditionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDStepConditionEngine_intrinsicValues_", Description="Create a FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDStepConditionEngine",Description = "FDStepConditionEngine")>] 
         fdstepconditionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDStepConditionEngine = Helper.toModelReference<FDStepConditionEngine> fdstepconditionengine "FDStepConditionEngine"  
                let builder (current : ICell) = ((FDStepConditionEngineModel.Cast _FDStepConditionEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDStepConditionEngine.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDStepConditionEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDStepConditionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDStepConditionEngine_Range", Description="Create a range of FDStepConditionEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDStepConditionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDStepConditionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDStepConditionEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDStepConditionEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDStepConditionEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
