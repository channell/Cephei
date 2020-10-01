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
  callablebondengines
  </summary> *)
[<AutoSerializable(true)>]
module TreeCallableFixedRateBondEngineFunction =


    (*
        Constructors \note the term structure is only needed when the short-rate model cannot provide one itself.
    *)
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine", Description="Create a TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_create
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
                let builder () = withMnemonic mnemonic (Fun.TreeCallableFixedRateBondEngine 
                                                            _model.cell 
                                                            _timeSteps.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeCallableFixedRateBondEngine>) l

                let source = Helper.sourceFold "Fun.TreeCallableFixedRateBondEngine" 
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
                    ; subscriber = Helper.subscriberModel<TreeCallableFixedRateBondEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine1", Description="Create a TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_create1
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
                let builder () = withMnemonic mnemonic (Fun.TreeCallableFixedRateBondEngine1 
                                                            _model.cell 
                                                            _timeGrid.cell 
                                                            _termStructure.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeCallableFixedRateBondEngine>) l

                let source = Helper.sourceFold "Fun.TreeCallableFixedRateBondEngine1" 
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
                    ; subscriber = Helper.subscriberModel<TreeCallableFixedRateBondEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine_update", Description="Create a TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeCallableFixedRateBondEngine",Description = "Reference to TreeCallableFixedRateBondEngine")>] 
         treecallablefixedratebondengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeCallableFixedRateBondEngine = Helper.toCell<TreeCallableFixedRateBondEngine> treecallablefixedratebondengine "TreeCallableFixedRateBondEngine"  
                let builder () = withMnemonic mnemonic ((_TreeCallableFixedRateBondEngine.cell :?> TreeCallableFixedRateBondEngineModel).Update
                                                       ) :> ICell
                let format (o : TreeCallableFixedRateBondEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeCallableFixedRateBondEngine.source + ".Update") 
                                               [| _TreeCallableFixedRateBondEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeCallableFixedRateBondEngine.cell
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
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine_setModel", Description="Create a TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeCallableFixedRateBondEngine",Description = "Reference to TreeCallableFixedRateBondEngine")>] 
         treecallablefixedratebondengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeCallableFixedRateBondEngine = Helper.toCell<TreeCallableFixedRateBondEngine> treecallablefixedratebondengine "TreeCallableFixedRateBondEngine"  
                let _model = Helper.toHandle<'ModelType>> model "model" 
                let builder () = withMnemonic mnemonic ((_TreeCallableFixedRateBondEngine.cell :?> TreeCallableFixedRateBondEngineModel).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : TreeCallableFixedRateBondEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeCallableFixedRateBondEngine.source + ".SetModel") 
                                               [| _TreeCallableFixedRateBondEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeCallableFixedRateBondEngine.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine_registerWith", Description="Create a TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeCallableFixedRateBondEngine",Description = "Reference to TreeCallableFixedRateBondEngine")>] 
         treecallablefixedratebondengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeCallableFixedRateBondEngine = Helper.toCell<TreeCallableFixedRateBondEngine> treecallablefixedratebondengine "TreeCallableFixedRateBondEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_TreeCallableFixedRateBondEngine.cell :?> TreeCallableFixedRateBondEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeCallableFixedRateBondEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeCallableFixedRateBondEngine.source + ".RegisterWith") 
                                               [| _TreeCallableFixedRateBondEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeCallableFixedRateBondEngine.cell
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
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine_reset", Description="Create a TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeCallableFixedRateBondEngine",Description = "Reference to TreeCallableFixedRateBondEngine")>] 
         treecallablefixedratebondengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeCallableFixedRateBondEngine = Helper.toCell<TreeCallableFixedRateBondEngine> treecallablefixedratebondengine "TreeCallableFixedRateBondEngine"  
                let builder () = withMnemonic mnemonic ((_TreeCallableFixedRateBondEngine.cell :?> TreeCallableFixedRateBondEngineModel).Reset
                                                       ) :> ICell
                let format (o : TreeCallableFixedRateBondEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeCallableFixedRateBondEngine.source + ".Reset") 
                                               [| _TreeCallableFixedRateBondEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeCallableFixedRateBondEngine.cell
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
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine_unregisterWith", Description="Create a TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeCallableFixedRateBondEngine",Description = "Reference to TreeCallableFixedRateBondEngine")>] 
         treecallablefixedratebondengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeCallableFixedRateBondEngine = Helper.toCell<TreeCallableFixedRateBondEngine> treecallablefixedratebondengine "TreeCallableFixedRateBondEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_TreeCallableFixedRateBondEngine.cell :?> TreeCallableFixedRateBondEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : TreeCallableFixedRateBondEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_TreeCallableFixedRateBondEngine.source + ".UnregisterWith") 
                                               [| _TreeCallableFixedRateBondEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeCallableFixedRateBondEngine.cell
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
    [<ExcelFunction(Name="_TreeCallableFixedRateBondEngine_Range", Description="Create a range of TreeCallableFixedRateBondEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let TreeCallableFixedRateBondEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TreeCallableFixedRateBondEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TreeCallableFixedRateBondEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TreeCallableFixedRateBondEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<TreeCallableFixedRateBondEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<TreeCallableFixedRateBondEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
