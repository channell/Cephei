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
  swaptionengines  This engine is not guaranteed to work if the underlying swap has a start date in the past, i.e., before today's date. When using this engine, prune the initial part of the swap so that it starts at t 0  calculations are checked against cached results
  </summary> *)
[<AutoSerializable(true)>]
module TreeSwaptionEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_TreeSwaptionEngine", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_create
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

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder () = withMnemonic mnemonic (Fun.TreeSwaptionEngine 
                                                            _model.cell 
                                                            _timeGrid.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.TreeSwaptionEngine" 
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
                    ; subscriber = Helper.subscriberModel<TreeSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeSwaptionEngine1", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "Reference to timeGrid")>] 
         timeGrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let builder () = withMnemonic mnemonic (Fun.TreeSwaptionEngine1 
                                                            _model.cell 
                                                            _timeGrid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.TreeSwaptionEngine1" 
                                               [| _model.source
                                               ;  _timeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _timeGrid.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeSwaptionEngine2", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_create2
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

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let _termStructure = Helper.toHandle<YieldTermStructure> termStructure "termStructure" 
                let builder () = withMnemonic mnemonic (Fun.TreeSwaptionEngine2 
                                                            _model.cell 
                                                            _timeSteps.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.TreeSwaptionEngine2" 
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
                    ; subscriber = Helper.subscriberModel<TreeSwaptionEngine> format
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
    [<ExcelFunction(Name="_TreeSwaptionEngine3", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="timeSteps",Description = "Reference to timeSteps")>] 
         timeSteps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<ShortRateModel> model "model" 
                let _timeSteps = Helper.toCell<int> timeSteps "timeSteps" 
                let builder () = withMnemonic mnemonic (Fun.TreeSwaptionEngine3 
                                                            _model.cell 
                                                            _timeSteps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.TreeSwaptionEngine3" 
                                               [| _model.source
                                               ;  _timeSteps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _timeSteps.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeSwaptionEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeSwaptionEngine_update", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeSwaptionEngine",Description = "Reference to TreeSwaptionEngine")>] 
         treeswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeSwaptionEngine = Helper.toCell<TreeSwaptionEngine> treeswaptionengine "TreeSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((TreeSwaptionEngineModel.Cast _TreeSwaptionEngine.cell).Update
                                                       ) :> ICell
                let format (o : TreeSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeSwaptionEngine.source + ".Update") 
                                               [| _TreeSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeSwaptionEngine.cell
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
    (*!!
    [<ExcelFunction(Name="_TreeSwaptionEngine_setModel", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeSwaptionEngine",Description = "Reference to TreeSwaptionEngine")>] 
         treeswaptionengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeSwaptionEngine = Helper.toCell<TreeSwaptionEngine> treeswaptionengine "TreeSwaptionEngine"  
                let _model = Helper.toHandle<'ModelType>> model "model" 
                let builder () = withMnemonic mnemonic ((TreeSwaptionEngineModel.Cast _TreeSwaptionEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : TreeSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeSwaptionEngine.source + ".SetModel") 
                                               [| _TreeSwaptionEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeSwaptionEngine.cell
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
            "<WIZ>" *)
    (*
        
    *)
    [<ExcelFunction(Name="_TreeSwaptionEngine_registerWith", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeSwaptionEngine",Description = "Reference to TreeSwaptionEngine")>] 
         treeswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeSwaptionEngine = Helper.toCell<TreeSwaptionEngine> treeswaptionengine "TreeSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((TreeSwaptionEngineModel.Cast _TreeSwaptionEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeSwaptionEngine.source + ".RegisterWith") 
                                               [| _TreeSwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeSwaptionEngine.cell
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
    [<ExcelFunction(Name="_TreeSwaptionEngine_reset", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeSwaptionEngine",Description = "Reference to TreeSwaptionEngine")>] 
         treeswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeSwaptionEngine = Helper.toCell<TreeSwaptionEngine> treeswaptionengine "TreeSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((TreeSwaptionEngineModel.Cast _TreeSwaptionEngine.cell).Reset
                                                       ) :> ICell
                let format (o : TreeSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeSwaptionEngine.source + ".Reset") 
                                               [| _TreeSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeSwaptionEngine.cell
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
    [<ExcelFunction(Name="_TreeSwaptionEngine_unregisterWith", Description="Create a TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeSwaptionEngine",Description = "Reference to TreeSwaptionEngine")>] 
         treeswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeSwaptionEngine = Helper.toCell<TreeSwaptionEngine> treeswaptionengine "TreeSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((TreeSwaptionEngineModel.Cast _TreeSwaptionEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeSwaptionEngine.source + ".UnregisterWith") 
                                               [| _TreeSwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeSwaptionEngine.cell
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
    [<ExcelFunction(Name="_TreeSwaptionEngine_Range", Description="Create a range of TreeSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeSwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TreeSwaptionEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TreeSwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TreeSwaptionEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TreeSwaptionEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TreeSwaptionEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
