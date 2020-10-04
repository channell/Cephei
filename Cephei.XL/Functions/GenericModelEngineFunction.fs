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

  </summary> *)
[<AutoSerializable(true)>]
module GenericModelEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_GenericModelEngine", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<'ModelType> model "model" 
                let builder () = withMnemonic mnemonic (Fun.GenericModelEngine 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericModelEngine>) l

                let source = Helper.sourceFold "Fun.GenericModelEngine" 
                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericModelEngine> format
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
    
    [<ExcelFunction(Name="_GenericModelEngine1", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder () = withMnemonic mnemonic (Fun.GenericModelEngine1 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericModelEngine>) l

                let source = Helper.sourceFold "Fun.GenericModelEngine1" 
                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericModelEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"*)
    (*
        
    *)
    [<ExcelFunction(Name="_GenericModelEngine2", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.GenericModelEngine2 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<GenericModelEngine>) l

                let source = Helper.sourceFold "Fun.GenericModelEngine2" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<GenericModelEngine> format
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
    [<ExcelFunction(Name="_GenericModelEngine_setModel", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericModelEngine",Description = "Reference to GenericModelEngine")>] 
         genericmodelengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericModelEngine = Helper.toCell<GenericModelEngine> genericmodelengine "GenericModelEngine"  
                let _model = Helper.toHandle<'ModelTyp>> model "model" 
                let builder () = withMnemonic mnemonic ((GenericModelEngineModel.Cast _GenericModelEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : GenericModelEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericModelEngine.source + ".SetModel") 
                                               [| _GenericModelEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericModelEngine.cell
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
            "<WIZ>"*)

    (*
        
    *)
    [<ExcelFunction(Name="_GenericModelEngine_registerWith", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericModelEngine",Description = "Reference to GenericModelEngine")>] 
         genericmodelengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericModelEngine = Helper.toCell<GenericModelEngine> genericmodelengine "GenericModelEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((GenericModelEngineModel.Cast _GenericModelEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GenericModelEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericModelEngine.source + ".RegisterWith") 
                                               [| _GenericModelEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericModelEngine.cell
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
    [<ExcelFunction(Name="_GenericModelEngine_reset", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericModelEngine",Description = "Reference to GenericModelEngine")>] 
         genericmodelengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericModelEngine = Helper.toCell<GenericModelEngine> genericmodelengine "GenericModelEngine"  
                let builder () = withMnemonic mnemonic ((GenericModelEngineModel.Cast _GenericModelEngine.cell).Reset
                                                       ) :> ICell
                let format (o : GenericModelEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericModelEngine.source + ".Reset") 
                                               [| _GenericModelEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericModelEngine.cell
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
    [<ExcelFunction(Name="_GenericModelEngine_unregisterWith", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericModelEngine",Description = "Reference to GenericModelEngine")>] 
         genericmodelengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericModelEngine = Helper.toCell<GenericModelEngine> genericmodelengine "GenericModelEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((GenericModelEngineModel.Cast _GenericModelEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : GenericModelEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericModelEngine.source + ".UnregisterWith") 
                                               [| _GenericModelEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericModelEngine.cell
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
    [<ExcelFunction(Name="_GenericModelEngine_update", Description="Create a GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="GenericModelEngine",Description = "Reference to GenericModelEngine")>] 
         genericmodelengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _GenericModelEngine = Helper.toCell<GenericModelEngine> genericmodelengine "GenericModelEngine"  
                let builder () = withMnemonic mnemonic ((GenericModelEngineModel.Cast _GenericModelEngine.cell).Update
                                                       ) :> ICell
                let format (o : GenericModelEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_GenericModelEngine.source + ".Update") 
                                               [| _GenericModelEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _GenericModelEngine.cell
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
    [<ExcelFunction(Name="_GenericModelEngine_Range", Description="Create a range of GenericModelEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let GenericModelEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the GenericModelEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<GenericModelEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<GenericModelEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<GenericModelEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<GenericModelEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
