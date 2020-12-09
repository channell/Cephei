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
    [<ExcelFunction(Name="_ForwardVanillaEngine", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="getEngine",Description = "ForwardVanillaEngine.GetOriginalEngine")>] 
         getEngine : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _getEngine = Helper.toCell<ForwardVanillaEngine.GetOriginalEngine> getEngine "getEngine" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.ForwardVanillaEngine 
                                                            _Process.cell 
                                                            _getEngine.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ForwardVanillaEngine>) l

                let source () = Helper.sourceFold "Fun.ForwardVanillaEngine" 
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
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardVanillaEngine> format
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_GetOriginalEngine", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_GetOriginalEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaEngineModel.Cast _ForwardVanillaEngine.cell).GetOriginalEngine
                                                            _Process.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IPricingEngine>) l

                let source () = Helper.sourceFold (_ForwardVanillaEngine.source + ".GetOriginalEngine") 

                                               [| _Process.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
                                ;  _Process.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<ForwardVanillaEngine> format
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_registerWith", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaEngineModel.Cast _ForwardVanillaEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_reset", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaEngineModel.Cast _ForwardVanillaEngine.cell).Reset
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_unregisterWith", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaEngineModel.Cast _ForwardVanillaEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_update", Description="Create a ForwardVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="ForwardVanillaEngine",Description = "ForwardVanillaEngine")>] 
         forwardvanillaengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _ForwardVanillaEngine = Helper.toCell<ForwardVanillaEngine> forwardvanillaengine "ForwardVanillaEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((ForwardVanillaEngineModel.Cast _ForwardVanillaEngine.cell).Update
                                                       ) :> ICell
                let format (o : ForwardVanillaEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_ForwardVanillaEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _ForwardVanillaEngine.cell
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
    [<ExcelFunction(Name="_ForwardVanillaEngine_Range", Description="Create a range of ForwardVanillaEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let ForwardVanillaEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<ForwardVanillaEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<ForwardVanillaEngine> (c)) :> ICell
                let format (i : Generic.List<ICell<ForwardVanillaEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<ForwardVanillaEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
