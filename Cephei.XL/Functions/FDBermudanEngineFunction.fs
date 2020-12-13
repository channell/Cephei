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
  vanillaengines
  </summary> *)
[<AutoSerializable(true)>]
module FDBermudanEngineFunction =


    (*
        constructor
    *)
    [<ExcelFunction(Name="_FDBermudanEngine", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_create
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.FDBermudanEngine 
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDBermudanEngine>) l

                let source () = Helper.sourceFold "Fun.FDBermudanEngine" 
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
                    ; subscriber = Helper.subscriberModel<FDBermudanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDBermudanEngine_registerWith", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDBermudanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
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
    [<ExcelFunction(Name="_FDBermudanEngine_reset", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).Reset
                                                       ) :> ICell
                let format (o : FDBermudanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
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
    [<ExcelFunction(Name="_FDBermudanEngine_unregisterWith", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : FDBermudanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
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
    [<ExcelFunction(Name="_FDBermudanEngine_update", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).Update
                                                       ) :> ICell
                let format (o : FDBermudanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
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
    [<ExcelFunction(Name="_FDBermudanEngine_setStepCondition", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_setStepCondition
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        ([<ExcelArgument(Name="impl",Description = "Vector")>] 
         impl : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let _impl = Helper.toCell<Func<IStepCondition<Vector>>> impl "impl" 
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).SetStepCondition
                                                            _impl.cell 
                                                       ) :> ICell
                let format (o : FDBermudanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".SetStepCondition") 

                                               [| _impl.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
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
    [<ExcelFunction(Name="_FDBermudanEngine_ensureStrikeInGrid", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_ensureStrikeInGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).EnsureStrikeInGrid
                                                       ) :> ICell
                let format (o : FDBermudanEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".EnsureStrikeInGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
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
        this should be defined as new in each deriving class which use template iheritance in order to return a proper class to wrap
    *)
    [<ExcelFunction(Name="_FDBermudanEngine_factory", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_factory
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
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

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _timeSteps = Helper.toDefault<int> timeSteps "timeSteps" 100
                let _gridPoints = Helper.toDefault<int> gridPoints "gridPoints" 100
                let _timeDependent = Helper.toDefault<bool> timeDependent "timeDependent" false
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).Factory
                                                            _Process.cell 
                                                            _timeSteps.cell 
                                                            _gridPoints.cell 
                                                            _timeDependent.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FDVanillaEngine>) l

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".Factory") 

                                               [| _Process.source
                                               ;  _timeSteps.source
                                               ;  _gridPoints.source
                                               ;  _timeDependent.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
                                ;  _Process.cell
                                ;  _timeSteps.cell
                                ;  _gridPoints.cell
                                ;  _timeDependent.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDBermudanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDBermudanEngine_getResidualTime", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_getResidualTime
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).GetResidualTime
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".GetResidualTime") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
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
    [<ExcelFunction(Name="_FDBermudanEngine_grid", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).Grid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".Grid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDBermudanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FDBermudanEngine_intrinsicValues_", Description="Create a FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_intrinsicValues_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FDBermudanEngine",Description = "FDBermudanEngine")>] 
         fdbermudanengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FDBermudanEngine = Helper.toCell<FDBermudanEngine> fdbermudanengine "FDBermudanEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((FDBermudanEngineModel.Cast _FDBermudanEngine.cell).IntrinsicValues_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SampledCurve>) l

                let source () = Helper.sourceFold (_FDBermudanEngine.source + ".IntrinsicValues_") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _FDBermudanEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FDBermudanEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_FDBermudanEngine_Range", Description="Create a range of FDBermudanEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let FDBermudanEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FDBermudanEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<FDBermudanEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<FDBermudanEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<FDBermudanEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
