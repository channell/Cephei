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
module AnalyticCapFloorEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticCapFloorEngine1", Description="Create a AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "IAffineModel")>] 
         model : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<IAffineModel> model "model" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.AnalyticCapFloorEngine1 
                                                            _model.cell 
                                                            _termStructure.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.AnalyticCapFloorEngine" 
                                               [| _model.source
                                               ;  _termStructure.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _termStructure.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticCapFloorEngine", Description="Create a AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "IAffineModel")>] 
         model : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<IAffineModel> model "model" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.AnalyticCapFloorEngine
                                                            _model.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.AnalyticCapFloorEngine1" 
                                               [| _model.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticCapFloorEngine_setModel", Description="Create a AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticCapFloorEngine",Description = "AnalyticCapFloorEngine")>] 
         analyticcapfloorengine : obj)
        ([<ExcelArgument(Name="model",Description = "IAffineModel")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticCapFloorEngine = Helper.toModelReference<AnalyticCapFloorEngine> analyticcapfloorengine "AnalyticCapFloorEngine"  
                let _model = Helper.toHandle<IAffineModel> model "model" 
                let builder (current : ICell) = ((AnalyticCapFloorEngineModel.Cast _AnalyticCapFloorEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : AnalyticCapFloorEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticCapFloorEngine.source + ".SetModel") 

                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticCapFloorEngine.cell
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
    [<ExcelFunction(Name="_AnalyticCapFloorEngine_registerWith", Description="Create a AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticCapFloorEngine",Description = "AnalyticCapFloorEngine")>] 
         analyticcapfloorengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticCapFloorEngine = Helper.toModelReference<AnalyticCapFloorEngine> analyticcapfloorengine "AnalyticCapFloorEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((AnalyticCapFloorEngineModel.Cast _AnalyticCapFloorEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticCapFloorEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticCapFloorEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticCapFloorEngine.cell
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
    [<ExcelFunction(Name="_AnalyticCapFloorEngine_reset", Description="Create a AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticCapFloorEngine",Description = "AnalyticCapFloorEngine")>] 
         analyticcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticCapFloorEngine = Helper.toModelReference<AnalyticCapFloorEngine> analyticcapfloorengine "AnalyticCapFloorEngine"  
                let builder (current : ICell) = ((AnalyticCapFloorEngineModel.Cast _AnalyticCapFloorEngine.cell).Reset
                                                       ) :> ICell
                let format (o : AnalyticCapFloorEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticCapFloorEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticCapFloorEngine.cell
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
    [<ExcelFunction(Name="_AnalyticCapFloorEngine_unregisterWith", Description="Create a AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticCapFloorEngine",Description = "AnalyticCapFloorEngine")>] 
         analyticcapfloorengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticCapFloorEngine = Helper.toModelReference<AnalyticCapFloorEngine> analyticcapfloorengine "AnalyticCapFloorEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((AnalyticCapFloorEngineModel.Cast _AnalyticCapFloorEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticCapFloorEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticCapFloorEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticCapFloorEngine.cell
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
    [<ExcelFunction(Name="_AnalyticCapFloorEngine_update", Description="Create a AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticCapFloorEngine",Description = "AnalyticCapFloorEngine")>] 
         analyticcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticCapFloorEngine = Helper.toModelReference<AnalyticCapFloorEngine> analyticcapfloorengine "AnalyticCapFloorEngine"  
                let builder (current : ICell) = ((AnalyticCapFloorEngineModel.Cast _AnalyticCapFloorEngine.cell).Update
                                                       ) :> ICell
                let format (o : AnalyticCapFloorEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticCapFloorEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticCapFloorEngine.cell
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
    [<ExcelFunction(Name="_AnalyticCapFloorEngine_Range", Description="Create a range of AnalyticCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticCapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticCapFloorEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AnalyticCapFloorEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<AnalyticCapFloorEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AnalyticCapFloorEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
