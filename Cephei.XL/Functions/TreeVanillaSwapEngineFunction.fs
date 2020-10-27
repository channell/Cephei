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
module TreeVanillaSwapEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine1", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "TreeVanillaSwapEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "ShortRateModel")>] 
         model : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "TimeGrid")>] 
         timeGrid : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TreeVanillaSwapEngine1
                                                            _model.cell 
                                                            _timeGrid.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeVanillaSwapEngine>) l

                let source () = Helper.sourceFold "Fun.TreeVanillaSwapEngine1" 
                                               [| _model.source
                                               ;  _timeGrid.source
                                               ;  _termStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _timeGrid.cell
                                ;  _termStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeVanillaSwapEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Constructors \note the term structure is only needed when the short-rate model cannot provide one itself.
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TreeVanillaSwapEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "ShortRateModel")>] 
         model : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "int")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="termStructure",Description = "YieldTermStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TreeVanillaSwapEngine
                                                            _model.cell 
                                                            _timeSteps.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeVanillaSwapEngine>) l

                let source () = Helper.sourceFold "Fun.TreeVanillaSwapEngine" 
                                               [| _model.source
                                               ;  _timeSteps.source
                                               ;  _termStructure.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _timeSteps.cell
                                ;  _termStructure.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeVanillaSwapEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_update", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((TreeVanillaSwapEngineModel.Cast _TreeVanillaSwapEngine.cell).Update
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
    (*!!
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_setModel", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        ([<ExcelArgument(Name="model",Description = "'ModelType")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine"  
                let _model = Helper.toHandle<'ModelType>> model "model" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeVanillaSwapEngineModel.Cast _TreeVanillaSwapEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".SetModel") 

                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_registerWith", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeVanillaSwapEngineModel.Cast _TreeVanillaSwapEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_reset", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((TreeVanillaSwapEngineModel.Cast _TreeVanillaSwapEngine.cell).Reset
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_unregisterWith", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeVanillaSwapEngineModel.Cast _TreeVanillaSwapEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_Range", Description="Create a range of TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TreeVanillaSwapEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TreeVanillaSwapEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TreeVanillaSwapEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TreeVanillaSwapEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
