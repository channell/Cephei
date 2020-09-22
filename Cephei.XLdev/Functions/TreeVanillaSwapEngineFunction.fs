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
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_calculate", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "Reference to TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine" true 
                let builder () = withMnemonic mnemonic ((_TreeVanillaSwapEngine.cell :?> TreeVanillaSwapEngineModel).Calculate
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".Calculate") 
                                               [| _TreeVanillaSwapEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "Reference to timeGrid")>] 
         timeGrid : obj)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" true
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" true
                let _termStructure = Helper.toHandle<Handle<YieldTermStructure>> termStructure "termStructure" 
                let builder () = withMnemonic mnemonic (Fun.TreeVanillaSwapEngine 
                                                            _model.cell 
                                                            _timeGrid.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeVanillaSwapEngine>) l

                let source = Helper.sourceFold "Fun.TreeVanillaSwapEngine" 
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
        Constructors \note the term structure is only needed when the short-rate model cannot provide one itself.
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine1", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        ([<ExcelArgument(Name="termStructure",Description = "Reference to termStructure")>] 
         termStructure : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" true
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" true
                let _termStructure = Helper.toHandle<Handle<YieldTermStructure>> termStructure "termStructure" 
                let builder () = withMnemonic mnemonic (Fun.TreeVanillaSwapEngine1 
                                                            _model.cell 
                                                            _timeSteps.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeVanillaSwapEngine>) l

                let source = Helper.sourceFold "Fun.TreeVanillaSwapEngine1" 
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
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_update", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "Reference to TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine" true 
                let builder () = withMnemonic mnemonic ((_TreeVanillaSwapEngine.cell :?> TreeVanillaSwapEngineModel).Update
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".Update") 
                                               [| _TreeVanillaSwapEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_setModel", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "Reference to TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine" true 
                let _model = Helper.toHandle<Handle<'ModelType>> model "model" 
                let builder () = withMnemonic mnemonic ((_TreeVanillaSwapEngine.cell :?> TreeVanillaSwapEngineModel).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".SetModel") 
                                               [| _TreeVanillaSwapEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
                                ;  _model.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_registerWith", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "Reference to TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_TreeVanillaSwapEngine.cell :?> TreeVanillaSwapEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".RegisterWith") 
                                               [| _TreeVanillaSwapEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
                                ;  _handler.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_reset", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "Reference to TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine" true 
                let builder () = withMnemonic mnemonic ((_TreeVanillaSwapEngine.cell :?> TreeVanillaSwapEngineModel).Reset
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".Reset") 
                                               [| _TreeVanillaSwapEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_unregisterWith", Description="Create a TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeVanillaSwapEngine",Description = "Reference to TreeVanillaSwapEngine")>] 
         treevanillaswapengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeVanillaSwapEngine = Helper.toCell<TreeVanillaSwapEngine> treevanillaswapengine "TreeVanillaSwapEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_TreeVanillaSwapEngine.cell :?> TreeVanillaSwapEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeVanillaSwapEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeVanillaSwapEngine.source + ".UnregisterWith") 
                                               [| _TreeVanillaSwapEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeVanillaSwapEngine.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_TreeVanillaSwapEngine_Range", Description="Create a range of TreeVanillaSwapEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeVanillaSwapEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TreeVanillaSwapEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TreeVanillaSwapEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TreeVanillaSwapEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TreeVanillaSwapEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TreeVanillaSwapEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
