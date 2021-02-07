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
(*!!
(* <summary>
  Derived engines only need to implement the <tt>calculate()</tt> method
  </summary> *)
[<AutoSerializable(true)>]
module LatticeShortRateModelEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_LatticeShortRateModelEngine", Description="Create a LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "ShortRateModel")>] 
         model : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.LatticeShortRateModelEngine 
                                                            _model.cell 
                                                            _timeSteps.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LatticeShortRateModelEngine>) l

                let source () = Helper.sourceFold "Fun.LatticeShortRateModelEngine" 
                                               [| _model.source
                                               ;  _timeSteps.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _timeSteps.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LatticeShortRateModelEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LatticeShortRateModelEngine1", Description="Create a LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "ShortRateModel")>] 
         model : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "TimeGrid")>] 
         timeGrid : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.LatticeShortRateModelEngine1 
                                                            _model.cell 
                                                            _timeGrid.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LatticeShortRateModelEngine>) l

                let source () = Helper.sourceFold "Fun.LatticeShortRateModelEngine1" 
                                               [| _model.source
                                               ;  _timeGrid.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _timeGrid.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LatticeShortRateModelEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_LatticeShortRateModelEngine_update", Description="Create a LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LatticeShortRateModelEngine",Description = "LatticeShortRateModelEngine")>] 
         latticeshortratemodelengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LatticeShortRateModelEngine = Helper.toCell<LatticeShortRateModelEngine> latticeshortratemodelengine "LatticeShortRateModelEngine"  
                let builder (current : ICell) = ((LatticeShortRateModelEngineModel.Cast _LatticeShortRateModelEngine.cell).Update
                                                       ) :> ICell
                let format (o : LatticeShortRateModelEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LatticeShortRateModelEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LatticeShortRateModelEngine.cell
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
    [<ExcelFunction(Name="_LatticeShortRateModelEngine_setModel", Description="Create a LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LatticeShortRateModelEngine",Description = "LatticeShortRateModelEngine")>] 
         latticeshortratemodelengine : obj)
        ([<ExcelArgument(Name="model",Description = "'ModelType")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LatticeShortRateModelEngine = Helper.toCell<LatticeShortRateModelEngine> latticeshortratemodelengine "LatticeShortRateModelEngine"  
                let _model = Helper.toHandle<'ModelType>> model "model" 
                let builder (current : ICell) = ((LatticeShortRateModelEngineModel.Cast _LatticeShortRateModelEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : LatticeShortRateModelEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LatticeShortRateModelEngine.source + ".SetModel") 

                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LatticeShortRateModelEngine.cell
                                ;  _model.cell
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
    [<ExcelFunction(Name="_LatticeShortRateModelEngine_registerWith", Description="Create a LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LatticeShortRateModelEngine",Description = "LatticeShortRateModelEngine")>] 
         latticeshortratemodelengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LatticeShortRateModelEngine = Helper.toCell<LatticeShortRateModelEngine> latticeshortratemodelengine "LatticeShortRateModelEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((LatticeShortRateModelEngineModel.Cast _LatticeShortRateModelEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LatticeShortRateModelEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LatticeShortRateModelEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LatticeShortRateModelEngine.cell
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
    [<ExcelFunction(Name="_LatticeShortRateModelEngine_reset", Description="Create a LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LatticeShortRateModelEngine",Description = "LatticeShortRateModelEngine")>] 
         latticeshortratemodelengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LatticeShortRateModelEngine = Helper.toCell<LatticeShortRateModelEngine> latticeshortratemodelengine "LatticeShortRateModelEngine"  
                let builder (current : ICell) = ((LatticeShortRateModelEngineModel.Cast _LatticeShortRateModelEngine.cell).Reset
                                                       ) :> ICell
                let format (o : LatticeShortRateModelEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LatticeShortRateModelEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _LatticeShortRateModelEngine.cell
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
    [<ExcelFunction(Name="_LatticeShortRateModelEngine_unregisterWith", Description="Create a LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LatticeShortRateModelEngine",Description = "LatticeShortRateModelEngine")>] 
         latticeshortratemodelengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LatticeShortRateModelEngine = Helper.toCell<LatticeShortRateModelEngine> latticeshortratemodelengine "LatticeShortRateModelEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((LatticeShortRateModelEngineModel.Cast _LatticeShortRateModelEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LatticeShortRateModelEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_LatticeShortRateModelEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LatticeShortRateModelEngine.cell
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
    [<ExcelFunction(Name="_LatticeShortRateModelEngine_Range", Description="Create a range of LatticeShortRateModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let LatticeShortRateModelEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LatticeShortRateModelEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<LatticeShortRateModelEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<LatticeShortRateModelEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<LatticeShortRateModelEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
