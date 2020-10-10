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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  J. Gatheral, The Volatility Surface: A Practitioner's Guide, Wiley Finance  A. Elices, Models with time-dependent parameters using transform methods: application to Heston’s model, http://arxiv.org/pdf/0708.2020  vanillaengines
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticPTDHestonEngineFunction =

    (*
        Simple to use constructor: Using adaptive Gauss-Lobatto integration and Gatheral's version of complex log. Be aware: using a too large number for maxEvaluations might result in a stack overflow as the Lobatto integration is a recursive algorithm.
    *)
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine", Description="Create a AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="relTolerance",Description = "Reference to relTolerance")>] 
         relTolerance : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<PiecewiseTimeDependentHestonModel> model "model" 
                let _relTolerance = Helper.toCell<double> relTolerance "relTolerance" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AnalyticPTDHestonEngine 
                                                            _model.cell 
                                                            _relTolerance.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticPTDHestonEngine>) l

                let source () = Helper.sourceFold "Fun.AnalyticPTDHestonEngine" 
                                               [| _model.source
                                               ;  _relTolerance.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _relTolerance.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticPTDHestonEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Constructor using Laguerre integration and Gatheral's version of complex log.
    *)
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine1", Description="Create a AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="integrationOrder",Description = "Reference to integrationOrder")>] 
         integrationOrder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<PiecewiseTimeDependentHestonModel> model "model" 
                let _integrationOrder = Helper.toDefault<int> integrationOrder "integrationOrder" 144
                let builder (current : ICell) = withMnemonic mnemonic (Fun.AnalyticPTDHestonEngine1 
                                                            _model.cell 
                                                            _integrationOrder.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticPTDHestonEngine>) l

                let source () = Helper.sourceFold "Fun.AnalyticPTDHestonEngine1" 
                                               [| _model.source
                                               ;  _integrationOrder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _integrationOrder.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticPTDHestonEngine> format
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
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine_setModel", Description="Create a AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticPTDHestonEngine",Description = "Reference to AnalyticPTDHestonEngine")>] 
         analyticptdhestonengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticPTDHestonEngine = Helper.toCell<AnalyticPTDHestonEngine> analyticptdhestonengine "AnalyticPTDHestonEngine"  
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticPTDHestonEngineModel.Cast _AnalyticPTDHestonEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : AnalyticPTDHestonEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticPTDHestonEngine.source + ".SetModel") 
                                               [| _AnalyticPTDHestonEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticPTDHestonEngine.cell
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
            "<WIZ>" *)
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine_registerWith", Description="Create a AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticPTDHestonEngine",Description = "Reference to AnalyticPTDHestonEngine")>] 
         analyticptdhestonengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticPTDHestonEngine = Helper.toCell<AnalyticPTDHestonEngine> analyticptdhestonengine "AnalyticPTDHestonEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticPTDHestonEngineModel.Cast _AnalyticPTDHestonEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticPTDHestonEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticPTDHestonEngine.source + ".RegisterWith") 
                                               [| _AnalyticPTDHestonEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticPTDHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine_reset", Description="Create a AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticPTDHestonEngine",Description = "Reference to AnalyticPTDHestonEngine")>] 
         analyticptdhestonengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticPTDHestonEngine = Helper.toCell<AnalyticPTDHestonEngine> analyticptdhestonengine "AnalyticPTDHestonEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticPTDHestonEngineModel.Cast _AnalyticPTDHestonEngine.cell).Reset
                                                       ) :> ICell
                let format (o : AnalyticPTDHestonEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticPTDHestonEngine.source + ".Reset") 
                                               [| _AnalyticPTDHestonEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticPTDHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine_unregisterWith", Description="Create a AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticPTDHestonEngine",Description = "Reference to AnalyticPTDHestonEngine")>] 
         analyticptdhestonengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticPTDHestonEngine = Helper.toCell<AnalyticPTDHestonEngine> analyticptdhestonengine "AnalyticPTDHestonEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticPTDHestonEngineModel.Cast _AnalyticPTDHestonEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticPTDHestonEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticPTDHestonEngine.source + ".UnregisterWith") 
                                               [| _AnalyticPTDHestonEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticPTDHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine_update", Description="Create a AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticPTDHestonEngine",Description = "Reference to AnalyticPTDHestonEngine")>] 
         analyticptdhestonengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticPTDHestonEngine = Helper.toCell<AnalyticPTDHestonEngine> analyticptdhestonengine "AnalyticPTDHestonEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((AnalyticPTDHestonEngineModel.Cast _AnalyticPTDHestonEngine.cell).Update
                                                       ) :> ICell
                let format (o : AnalyticPTDHestonEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_AnalyticPTDHestonEngine.source + ".Update") 
                                               [| _AnalyticPTDHestonEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticPTDHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticPTDHestonEngine_Range", Description="Create a range of AnalyticPTDHestonEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticPTDHestonEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AnalyticPTDHestonEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticPTDHestonEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticPTDHestonEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticPTDHestonEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<AnalyticPTDHestonEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
