﻿(*
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
  References:  Heston, Steven L., 1993. A Closed-Form Solution for Options with Stochastic Volatility with Applications to Bond and Currency Options.  The review of Financial Studies, Volume 6, Issue 2, 327-343.  A. Sepp, Pricing European-Style Options under Jump Diffusion Processes with Stochastic Volatility: Applications of Fourier Transform (<http://math.ut.ee/~spartak/papers/stochjumpvols.pdf>)  R. Lord and C. Kahl, Why the rotation count algorithm works, http://papers.ssrn.com/sol3/papers.cfm?abstract_id=921335  H. Albrecher, P. Mayer, W.Schoutens and J. Tistaert, The Little Heston Trap, http://www.schoutens.be/HestonTrap.pdf  J. Gatheral, The Volatility Surface: A Practitioner's Guide, Wiley Finance  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature and comparison with Black pricing.
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticHestonEngineFunction =
(*!!
    (*
        Constructor giving full control over the Fourier integration algorithm
    *)
    [<ExcelFunction(Name="_AnalyticHestonEngine", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="cpxLog",Description = "Reference to cpxLog")>] 
         cpxLog : obj)
        ([<ExcelArgument(Name="integration",Description = "Reference to integration")>] 
         integration : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<HestonModel> model "model" 
                let _cpxLog = Helper.toCell<ComplexLogFormula> cpxLog "cpxLog" 
                let _integration = Helper.toCell<Integration.Integration> integration "integration" 
                let builder () = withMnemonic mnemonic (Fun.AnalyticHestonEngine 
                                                            _model.cell 
                                                            _cpxLog.cell 
                                                            _integration.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticHestonEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticHestonEngine" 
                                               [| _model.source
                                               ;  _cpxLog.source
                                               ;  _integration.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _cpxLog.cell
                                ;  _integration.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticHestonEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"*)
    (*
        Constructor using Laguerre integration and Gatheral's version of complex log.
    *)
    [<ExcelFunction(Name="_AnalyticHestonEngine1", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="integrationOrder",Description = "Reference to integrationOrder")>] 
         integrationOrder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<HestonModel> model "model" 
                let _integrationOrder = Helper.toDefault<int> integrationOrder "integrationOrder" 144
                let builder () = withMnemonic mnemonic (Fun.AnalyticHestonEngine1 
                                                            _model.cell 
                                                            _integrationOrder.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticHestonEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticHestonEngine1" 
                                               [| _model.source
                                               ;  _integrationOrder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _integrationOrder.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticHestonEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Simple to use constructor: Using adaptive Gauss-Lobatto integration and Gatheral's version of complex log. Be aware: using a too large number for maxEvaluations might result in a stack overflow as the Lobatto integration is a recursive algorithm.
    *)
    [<ExcelFunction(Name="_AnalyticHestonEngine", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_create
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

                let _model = Helper.toCell<HestonModel> model "model" 
                let _relTolerance = Helper.toCell<double> relTolerance "relTolerance" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic (Fun.AnalyticHestonEngine
                                                            _model.cell 
                                                            _relTolerance.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticHestonEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticHestonEngine" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticHestonEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticHestonEngine_numberOfEvaluations", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonEngine",Description = "Reference to AnalyticHestonEngine")>] 
         analytichestonengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonEngine = Helper.toCell<AnalyticHestonEngine> analytichestonengine "AnalyticHestonEngine"  
                let builder () = withMnemonic mnemonic ((_AnalyticHestonEngine.cell :?> AnalyticHestonEngineModel).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHestonEngine.source + ".NumberOfEvaluations") 
                                               [| _AnalyticHestonEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonEngine_setModel", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonEngine",Description = "Reference to AnalyticHestonEngine")>] 
         analytichestonengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonEngine = Helper.toCell<AnalyticHestonEngine> analytichestonengine "AnalyticHestonEngine"  
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder () = withMnemonic mnemonic ((_AnalyticHestonEngine.cell :?> AnalyticHestonEngineModel).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : AnalyticHestonEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonEngine.source + ".SetModel") 
                                               [| _AnalyticHestonEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonEngine_registerWith", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonEngine",Description = "Reference to AnalyticHestonEngine")>] 
         analytichestonengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonEngine = Helper.toCell<AnalyticHestonEngine> analytichestonengine "AnalyticHestonEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_AnalyticHestonEngine.cell :?> AnalyticHestonEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHestonEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonEngine.source + ".RegisterWith") 
                                               [| _AnalyticHestonEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonEngine_reset", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonEngine",Description = "Reference to AnalyticHestonEngine")>] 
         analytichestonengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonEngine = Helper.toCell<AnalyticHestonEngine> analytichestonengine "AnalyticHestonEngine"  
                let builder () = withMnemonic mnemonic ((_AnalyticHestonEngine.cell :?> AnalyticHestonEngineModel).Reset
                                                       ) :> ICell
                let format (o : AnalyticHestonEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonEngine.source + ".Reset") 
                                               [| _AnalyticHestonEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonEngine_unregisterWith", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonEngine",Description = "Reference to AnalyticHestonEngine")>] 
         analytichestonengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonEngine = Helper.toCell<AnalyticHestonEngine> analytichestonengine "AnalyticHestonEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_AnalyticHestonEngine.cell :?> AnalyticHestonEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHestonEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonEngine.source + ".UnregisterWith") 
                                               [| _AnalyticHestonEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonEngine_update", Description="Create a AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonEngine",Description = "Reference to AnalyticHestonEngine")>] 
         analytichestonengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonEngine = Helper.toCell<AnalyticHestonEngine> analytichestonengine "AnalyticHestonEngine"  
                let builder () = withMnemonic mnemonic ((_AnalyticHestonEngine.cell :?> AnalyticHestonEngineModel).Update
                                                       ) :> ICell
                let format (o : AnalyticHestonEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonEngine.source + ".Update") 
                                               [| _AnalyticHestonEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonEngine_Range", Description="Create a range of AnalyticHestonEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AnalyticHestonEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticHestonEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticHestonEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticHestonEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AnalyticHestonEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"