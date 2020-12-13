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
Use Merton73 engine as default.
  </summary> *)
[<AutoSerializable(true)>]
module FDDividendEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngine_factory2", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_factory2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngine",Description = "FDDividendEngine")>] 
         fddividendengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int or empty")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int or empty")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool or empty")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngine = Helper.toCell<FDDividendEngine> fddividendengine "FDDividendEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let _timeDependent = Helper.toDefault<bool> timeDependent "timeDependent" false
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineModel.Cast _FDDividendEngine.cell).Factory2
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDDividendEngine.source + ".Factory2") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngine1", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int or empty")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int or empty")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool or empty")>] 
         timeDependent : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let _timeDependent = Helper.toDefault<bool> timeDependent "timeDependent" false
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDDividendEngine1 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEngine>) l

                let source () = Helper.sourceFold "Fun.FDDividendEngine1" 
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
                    ; subscriber = Helper.subscriberModel<FDDividendEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngine", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDDividendEngine 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDDividendEngine>) l

                let source () = Helper.sourceFold "Fun.FDDividendEngine" 
                                               [|  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [|  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngine_factory", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngine",Description = "FDDividendEngine")>] 
         fddividendengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int or empty")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int or empty")>] 
         gridPoints : obj)
        ([<ExcelArgument(Name="timeDependent",Description = "bool or empty")>] 
         timeDependent : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngine = Helper.toCell<FDDividendEngine> fddividendengine "FDDividendEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let _timeDependent = Helper.toDefault<bool> timeDependent "timeDependent" false
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineModel.Cast _FDDividendEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDDividendEngine.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngine_setStepCondition", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngine",Description = "FDDividendEngine")>] 
         fddividendengine : obj)
        ([<ExcelArgument(Name="impl",Description = "Vector")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngine = Helper.toCell<FDDividendEngine> fddividendengine "FDDividendEngine"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineModel.Cast _FDDividendEngine.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDDividendEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendEngine.source + ".SetStepCondition") 

                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDDividendEngine.cell
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
    [<ExcelFunction(Name="_FDDividendEngine_ensureStrikeInGrid", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngine",Description = "FDDividendEngine")>] 
         fddividendengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngine = Helper.toCell<FDDividendEngine> fddividendengine "FDDividendEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineModel.Cast _FDDividendEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDDividendEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDDividendEngine.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngine.cell
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
    [<ExcelFunction(Name="_FDDividendEngine_getResidualTime", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngine",Description = "FDDividendEngine")>] 
         fddividendengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngine = Helper.toCell<FDDividendEngine> fddividendengine "FDDividendEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineModel.Cast _FDDividendEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDDividendEngine.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngine.cell
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
    [<ExcelFunction(Name="_FDDividendEngine_grid", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngine",Description = "FDDividendEngine")>] 
         fddividendengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngine = Helper.toCell<FDDividendEngine> fddividendengine "FDDividendEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineModel.Cast _FDDividendEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDDividendEngine.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDDividendEngine_intrinsicValues_", Description="Create a FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDDividendEngine",Description = "FDDividendEngine")>] 
         fddividendengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDDividendEngine = Helper.toCell<FDDividendEngine> fddividendengine "FDDividendEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDDividendEngineModel.Cast _FDDividendEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDDividendEngine.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDDividendEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDDividendEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDDividendEngine_Range", Description="Create a range of FDDividendEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDDividendEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDDividendEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDDividendEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDDividendEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDDividendEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
