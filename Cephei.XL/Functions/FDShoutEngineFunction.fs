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
  vanillaengines  the correctness of the returned greeks is tested by reproducing numerical derivatives.
  </summary> *)
[<AutoSerializable(true)>]
module FDShoutEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FDShoutEngine_factory", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int or empty")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="gridPoints",Description = "int or empty")>] 
         gridPoints : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IFDEngine>) l

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDShoutEngine", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDShoutEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDShoutEngine>) l

                let source () = Helper.sourceFold "Fun.FDShoutEngine" 
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
                    ; subscriber = Helper.subscriberModel<FDShoutEngine> format
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
    [<ExcelFunction(Name="_FDShoutEngine1", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDShoutEngine1 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDShoutEngine>) l

                let source () = Helper.sourceFold "Fun.FDShoutEngine1" 
                                               [| _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_FDShoutEngine_registerWith", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDShoutEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDShoutEngine_reset", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).Reset
                                                       ) :> ICell
                let format (o : FDShoutEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
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
    [<ExcelFunction(Name="_FDShoutEngine_unregisterWith", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDShoutEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_FDShoutEngine_update", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).Update
                                                       ) :> ICell
                let format (o : FDShoutEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
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
    [<ExcelFunction(Name="_FDShoutEngine_ensureStrikeInGrid", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDShoutEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
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
    [<ExcelFunction(Name="_FDShoutEngine_getResidualTime", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
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
    [<ExcelFunction(Name="_FDShoutEngine_grid", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDShoutEngine_intrinsicValues_", Description="Create a FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDShoutEngine",Description = "FDShoutEngine")>] 
         fdshoutengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDShoutEngine = Helper.toCell<FDShoutEngine> fdshoutengine "FDShoutEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDShoutEngineModel.Cast _FDShoutEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDShoutEngine.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDShoutEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDShoutEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDShoutEngine_Range", Description="Create a range of FDShoutEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDShoutEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDShoutEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDShoutEngine> (c)) :> ICell
                let format (i : Generic.List<ICell<FDShoutEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDShoutEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
