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
  References:  Brigo, Mercurio, Interest Rate Models  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticBSMHullWhiteEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="equityShortRateCorrelation",Description = "double")>] 
         equityShortRateCorrelation : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="model",Description = "HullWhite")>] 
         model : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>]
        evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _equityShortRateCorrelation = Helper.toCell<double> equityShortRateCorrelation "equityShortRateCorrelation" 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _model = Helper.toCell<HullWhite> model "model" 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"
                let builder (current : ICell) = (Fun.AnalyticBSMHullWhiteEngine 
                                                            _equityShortRateCorrelation.cell 
                                                            _Process.cell 
                                                            _model.cell 
                                                            _evaluationDate.cell
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticBSMHullWhiteEngine>) l

                let source () = Helper.sourceFold "Fun.AnalyticBSMHullWhiteEngine" 
                                               [| _equityShortRateCorrelation.source
                                               ;  _Process.source
                                               ;  _model.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _equityShortRateCorrelation.cell
                                ;  _Process.cell
                                ;  _model.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticBSMHullWhiteEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_setModel", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        ([<ExcelArgument(Name="model",Description = "HullWhite")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toModelReference<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine"  
                let _model = Helper.toHandle<HullWhite> model "model" 
                let builder (current : ICell) = ((AnalyticBSMHullWhiteEngineModel.Cast _AnalyticBSMHullWhiteEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".SetModel") 

                                               [| _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_registerWith", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toModelReference<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((AnalyticBSMHullWhiteEngineModel.Cast _AnalyticBSMHullWhiteEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_reset", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toModelReference<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine"  
                let builder (current : ICell) = ((AnalyticBSMHullWhiteEngineModel.Cast _AnalyticBSMHullWhiteEngine.cell).Reset
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_unregisterWith", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toModelReference<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = ((AnalyticBSMHullWhiteEngineModel.Cast _AnalyticBSMHullWhiteEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_update", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toModelReference<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine"  
                let builder (current : ICell) = ((AnalyticBSMHullWhiteEngineModel.Cast _AnalyticBSMHullWhiteEngine.cell).Update
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_Range", Description="Create a range of AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticBSMHullWhiteEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<AnalyticBSMHullWhiteEngine> (c)) :> ICell
                let format (i : Cephei.Cell.List<AnalyticBSMHullWhiteEngine>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<AnalyticBSMHullWhiteEngine>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
