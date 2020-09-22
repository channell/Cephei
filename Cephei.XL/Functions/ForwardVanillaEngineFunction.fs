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
  forwardengines  - the correctness of the returned value is tested by reproducing results available in literature. - the correctness of the returned greeks is tested by reproducing numerical derivatives.
  </summary> *)
[<AutoSerializable(true)>]
module ForwardVanillaEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_ForwardVanillaEngine", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="getEngine",Description = "Reference to getEngine")>] 
         getEngine : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _getEngine = Helper.toCell<ForwardVanillaEngine.GetOriginalEngine> getEngine "getEngine" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.ForwardVanillaEngine 
                                                            _Process.cell 
                                                            _getEngine.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardVanillaEngine>) l

                let source = Helper.sourceFold "Fun.ForwardVanillaEngine" 
                                               [| _Process.source
                                               ;  _getEngine.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _getEngine.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
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
    (*!!omitted 
    [<ExcelFunction(Name="_ForwardVanillaEngine_GetOriginalEngine", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_GetOriginalEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "Reference to ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine" true 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let builder () = withMnemonic mnemonic ((_ForwardVanillaEngine.cell :?> ForwardVanillaEngineModel).GetOriginalEngine
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IPricingEngine>) l

                let source = Helper.sourceFold (_ForwardVanillaEngine.source + ".GetOriginalEngine") 
                                               [| _ForwardVanillaEngine.source
                                               ;  _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
                                ;  _Process.cell
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
            *)
    (*
        
    *)
    [<ExcelFunction(Name="_ForwardVanillaEngine_registerWith", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "Reference to ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ForwardVanillaEngine.cell :?> ForwardVanillaEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardVanillaEngine.source + ".RegisterWith") 
                                               [| _ForwardVanillaEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_reset", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "Reference to ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine" true 
                let builder () = withMnemonic mnemonic ((_ForwardVanillaEngine.cell :?> ForwardVanillaEngineModel).Reset
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardVanillaEngine.source + ".Reset") 
                                               [| _ForwardVanillaEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_unregisterWith", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "Reference to ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_ForwardVanillaEngine.cell :?> ForwardVanillaEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardVanillaEngine.source + ".UnregisterWith") 
                                               [| _ForwardVanillaEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_update", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "Reference to ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine" true 
                let builder () = withMnemonic mnemonic ((_ForwardVanillaEngine.cell :?> ForwardVanillaEngineModel).Update
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_ForwardVanillaEngine.source + ".Update") 
                                               [| _ForwardVanillaEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_Range", Description="Create a range of ForwardVanillaEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the ForwardVanillaEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardVanillaEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<ForwardVanillaEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<ForwardVanillaEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<ForwardVanillaEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
