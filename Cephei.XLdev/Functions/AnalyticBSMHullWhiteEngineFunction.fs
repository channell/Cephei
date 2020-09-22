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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="equityShortRateCorrelation",Description = "Reference to equityShortRateCorrelation")>] 
         equityShortRateCorrelation : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _equityShortRateCorrelation = Helper.toCell<double> equityShortRateCorrelation "equityShortRateCorrelation" true
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _model = Helper.toCell<HullWhite> model "model" true
                let builder () = withMnemonic mnemonic (Fun.AnalyticBSMHullWhiteEngine 
                                                            _equityShortRateCorrelation.cell 
                                                            _Process.cell 
                                                            _model.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticBSMHullWhiteEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticBSMHullWhiteEngine" 
                                               [| _equityShortRateCorrelation.source
                                               ;  _Process.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _equityShortRateCorrelation.cell
                                ;  _Process.cell
                                ;  _model.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_calculate", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "Reference to AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toCell<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine" true 
                let builder () = withMnemonic mnemonic ((_AnalyticBSMHullWhiteEngine.cell :?> AnalyticBSMHullWhiteEngineModel).Calculate
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".Calculate") 
                                               [| _AnalyticBSMHullWhiteEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_setModel", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "Reference to AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toCell<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine" true 
                let _model = Helper.toHandle<Handle<'ModelType>> model "model" 
                let builder () = withMnemonic mnemonic ((_AnalyticBSMHullWhiteEngine.cell :?> AnalyticBSMHullWhiteEngineModel).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".SetModel") 
                                               [| _AnalyticBSMHullWhiteEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_registerWith", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "Reference to AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toCell<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AnalyticBSMHullWhiteEngine.cell :?> AnalyticBSMHullWhiteEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".RegisterWith") 
                                               [| _AnalyticBSMHullWhiteEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_reset", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "Reference to AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toCell<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine" true 
                let builder () = withMnemonic mnemonic ((_AnalyticBSMHullWhiteEngine.cell :?> AnalyticBSMHullWhiteEngineModel).Reset
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".Reset") 
                                               [| _AnalyticBSMHullWhiteEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_unregisterWith", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "Reference to AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toCell<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AnalyticBSMHullWhiteEngine.cell :?> AnalyticBSMHullWhiteEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".UnregisterWith") 
                                               [| _AnalyticBSMHullWhiteEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_update", Description="Create a AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticBSMHullWhiteEngine",Description = "Reference to AnalyticBSMHullWhiteEngine")>] 
         analyticbsmhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticBSMHullWhiteEngine = Helper.toCell<AnalyticBSMHullWhiteEngine> analyticbsmhullwhiteengine "AnalyticBSMHullWhiteEngine" true 
                let builder () = withMnemonic mnemonic ((_AnalyticBSMHullWhiteEngine.cell :?> AnalyticBSMHullWhiteEngineModel).Update
                                                       ) :> ICell
                let format (o : AnalyticBSMHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticBSMHullWhiteEngine.source + ".Update") 
                                               [| _AnalyticBSMHullWhiteEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticBSMHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticBSMHullWhiteEngine_Range", Description="Create a range of AnalyticBSMHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticBSMHullWhiteEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AnalyticBSMHullWhiteEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticBSMHullWhiteEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticBSMHullWhiteEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticBSMHullWhiteEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AnalyticBSMHullWhiteEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
