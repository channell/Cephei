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
  swaptionengines
  </summary> *)
[<AutoSerializable(true)>]
module LfmSwaptionEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_LfmSwaptionEngine", Description="Create a LfmSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmSwaptionEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<LiborForwardModel> model "model" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let builder () = withMnemonic mnemonic (Fun.LfmSwaptionEngine 
                                                            _model.cell 
                                                            _discountCurve.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<LfmSwaptionEngine>) l

                let source = Helper.sourceFold "Fun.LfmSwaptionEngine" 
                                               [| _model.source
                                               ;  _discountCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _discountCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<LfmSwaptionEngine> format
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
    [<ExcelFunction(Name="_LfmSwaptionEngine_setModel", Description="Create a LfmSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmSwaptionEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmSwaptionEngine",Description = "Reference to LfmSwaptionEngine")>] 
         lfmswaptionengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmSwaptionEngine = Helper.toCell<LfmSwaptionEngine> lfmswaptionengine "LfmSwaptionEngine"  
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder () = withMnemonic mnemonic ((LfmSwaptionEngineModel.Cast _LfmSwaptionEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : LfmSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LfmSwaptionEngine.source + ".SetModel") 
                                               [| _LfmSwaptionEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmSwaptionEngine.cell
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
    [<ExcelFunction(Name="_LfmSwaptionEngine_registerWith", Description="Create a LfmSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmSwaptionEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmSwaptionEngine",Description = "Reference to LfmSwaptionEngine")>] 
         lfmswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmSwaptionEngine = Helper.toCell<LfmSwaptionEngine> lfmswaptionengine "LfmSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((LfmSwaptionEngineModel.Cast _LfmSwaptionEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LfmSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LfmSwaptionEngine.source + ".RegisterWith") 
                                               [| _LfmSwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmSwaptionEngine.cell
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
    [<ExcelFunction(Name="_LfmSwaptionEngine_reset", Description="Create a LfmSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmSwaptionEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmSwaptionEngine",Description = "Reference to LfmSwaptionEngine")>] 
         lfmswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmSwaptionEngine = Helper.toCell<LfmSwaptionEngine> lfmswaptionengine "LfmSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((LfmSwaptionEngineModel.Cast _LfmSwaptionEngine.cell).Reset
                                                       ) :> ICell
                let format (o : LfmSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LfmSwaptionEngine.source + ".Reset") 
                                               [| _LfmSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmSwaptionEngine.cell
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
    [<ExcelFunction(Name="_LfmSwaptionEngine_unregisterWith", Description="Create a LfmSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmSwaptionEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmSwaptionEngine",Description = "Reference to LfmSwaptionEngine")>] 
         lfmswaptionengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmSwaptionEngine = Helper.toCell<LfmSwaptionEngine> lfmswaptionengine "LfmSwaptionEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((LfmSwaptionEngineModel.Cast _LfmSwaptionEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : LfmSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LfmSwaptionEngine.source + ".UnregisterWith") 
                                               [| _LfmSwaptionEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmSwaptionEngine.cell
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
    [<ExcelFunction(Name="_LfmSwaptionEngine_update", Description="Create a LfmSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmSwaptionEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="LfmSwaptionEngine",Description = "Reference to LfmSwaptionEngine")>] 
         lfmswaptionengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _LfmSwaptionEngine = Helper.toCell<LfmSwaptionEngine> lfmswaptionengine "LfmSwaptionEngine"  
                let builder () = withMnemonic mnemonic ((LfmSwaptionEngineModel.Cast _LfmSwaptionEngine.cell).Update
                                                       ) :> ICell
                let format (o : LfmSwaptionEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_LfmSwaptionEngine.source + ".Update") 
                                               [| _LfmSwaptionEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _LfmSwaptionEngine.cell
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
    [<ExcelFunction(Name="_LfmSwaptionEngine_Range", Description="Create a range of LfmSwaptionEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let LfmSwaptionEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the LfmSwaptionEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<LfmSwaptionEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<LfmSwaptionEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<LfmSwaptionEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<LfmSwaptionEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
