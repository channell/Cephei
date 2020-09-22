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
  References:  Karel in't Hout, Joris Bierkens, Antoine von der Ploeg, Joe in't Panhuis, A Semi closed-from analytic pricing formula for call options in a hybrid Heston-Hull-White Model.  A. Sepp, Pricing European-Style Options under Jump Diffusion Processes with Stochastic Volatility: Applications of Fourier Transform (<http://math.ut.ee/~spartak/papers/stochjumpvols.pdf>)  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature, testing against QuantLib's analytic Heston and Black-Scholes-Merton Hull-White engine
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticHestonHullWhiteEngineFunction =

    (*
        see AnalticHestonEninge for usage of different constructors
    *)
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine1", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="hestonModel",Description = "Reference to hestonModel")>] 
         hestonModel : obj)
        ([<ExcelArgument(Name="hullWhiteModel",Description = "Reference to hullWhiteModel")>] 
         hullWhiteModel : obj)
        ([<ExcelArgument(Name="integrationOrder",Description = "Reference to integrationOrder")>] 
         integrationOrder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _hestonModel = Helper.toCell<HestonModel> hestonModel "hestonModel" true
                let _hullWhiteModel = Helper.toCell<HullWhite> hullWhiteModel "hullWhiteModel" true
                let _integrationOrder = Helper.toCell<int> integrationOrder "integrationOrder" true
                let builder () = withMnemonic mnemonic (Fun.AnalyticHestonHullWhiteEngine1 
                                                            _hestonModel.cell 
                                                            _hullWhiteModel.cell 
                                                            _integrationOrder.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticHestonHullWhiteEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticHestonHullWhiteEngine" 
                                               [| _hestonModel.source
                                               ;  _hullWhiteModel.source
                                               ;  _integrationOrder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _hestonModel.cell
                                ;  _hullWhiteModel.cell
                                ;  _integrationOrder.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="hestonModel",Description = "Reference to hestonModel")>] 
         hestonModel : obj)
        ([<ExcelArgument(Name="hullWhiteModel",Description = "Reference to hullWhiteModel")>] 
         hullWhiteModel : obj)
        ([<ExcelArgument(Name="relTolerance",Description = "Reference to relTolerance")>] 
         relTolerance : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _hestonModel = Helper.toCell<HestonModel> hestonModel "hestonModel" true
                let _hullWhiteModel = Helper.toCell<HullWhite> hullWhiteModel "hullWhiteModel" true
                let _relTolerance = Helper.toCell<double> relTolerance "relTolerance" true
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" true
                let builder () = withMnemonic mnemonic (Fun.AnalyticHestonHullWhiteEngine
                                                            _hestonModel.cell 
                                                            _hullWhiteModel.cell 
                                                            _relTolerance.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticHestonHullWhiteEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticHestonHullWhiteEngine1" 
                                               [| _hestonModel.source
                                               ;  _hullWhiteModel.source
                                               ;  _relTolerance.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _hestonModel.cell
                                ;  _hullWhiteModel.cell
                                ;  _relTolerance.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine_update", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonHullWhiteEngine",Description = "Reference to AnalyticHestonHullWhiteEngine")>] 
         analytichestonhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonHullWhiteEngine = Helper.toCell<AnalyticHestonHullWhiteEngine> analytichestonhullwhiteengine "AnalyticHestonHullWhiteEngine" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHestonHullWhiteEngine.cell :?> AnalyticHestonHullWhiteEngineModel).Update
                                                       ) :> ICell
                let format (o : AnalyticHestonHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonHullWhiteEngine.source + ".Update") 
                                               [| _AnalyticHestonHullWhiteEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine_numberOfEvaluations", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonHullWhiteEngine",Description = "Reference to AnalyticHestonHullWhiteEngine")>] 
         analytichestonhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonHullWhiteEngine = Helper.toCell<AnalyticHestonHullWhiteEngine> analytichestonhullwhiteengine "AnalyticHestonHullWhiteEngine" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHestonHullWhiteEngine.cell :?> AnalyticHestonHullWhiteEngineModel).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticHestonHullWhiteEngine.source + ".NumberOfEvaluations") 
                                               [| _AnalyticHestonHullWhiteEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine_setModel", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonHullWhiteEngine",Description = "Reference to AnalyticHestonHullWhiteEngine")>] 
         analytichestonhullwhiteengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonHullWhiteEngine = Helper.toCell<AnalyticHestonHullWhiteEngine> analytichestonhullwhiteengine "AnalyticHestonHullWhiteEngine" true 
                let _model = Helper.toHandle<'ModelType> model "model" 
                let builder () = withMnemonic mnemonic ((_AnalyticHestonHullWhiteEngine.cell :?> AnalyticHestonHullWhiteEngineModel).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : AnalyticHestonHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonHullWhiteEngine.source + ".SetModel") 
                                               [| _AnalyticHestonHullWhiteEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine_registerWith", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonHullWhiteEngine",Description = "Reference to AnalyticHestonHullWhiteEngine")>] 
         analytichestonhullwhiteengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonHullWhiteEngine = Helper.toCell<AnalyticHestonHullWhiteEngine> analytichestonhullwhiteengine "AnalyticHestonHullWhiteEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AnalyticHestonHullWhiteEngine.cell :?> AnalyticHestonHullWhiteEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHestonHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonHullWhiteEngine.source + ".RegisterWith") 
                                               [| _AnalyticHestonHullWhiteEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine_reset", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonHullWhiteEngine",Description = "Reference to AnalyticHestonHullWhiteEngine")>] 
         analytichestonhullwhiteengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonHullWhiteEngine = Helper.toCell<AnalyticHestonHullWhiteEngine> analytichestonhullwhiteengine "AnalyticHestonHullWhiteEngine" true 
                let builder () = withMnemonic mnemonic ((_AnalyticHestonHullWhiteEngine.cell :?> AnalyticHestonHullWhiteEngineModel).Reset
                                                       ) :> ICell
                let format (o : AnalyticHestonHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonHullWhiteEngine.source + ".Reset") 
                                               [| _AnalyticHestonHullWhiteEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine_unregisterWith", Description="Create a AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticHestonHullWhiteEngine",Description = "Reference to AnalyticHestonHullWhiteEngine")>] 
         analytichestonhullwhiteengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticHestonHullWhiteEngine = Helper.toCell<AnalyticHestonHullWhiteEngine> analytichestonhullwhiteengine "AnalyticHestonHullWhiteEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_AnalyticHestonHullWhiteEngine.cell :?> AnalyticHestonHullWhiteEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticHestonHullWhiteEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticHestonHullWhiteEngine.source + ".UnregisterWith") 
                                               [| _AnalyticHestonHullWhiteEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticHestonHullWhiteEngine.cell
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
    [<ExcelFunction(Name="_AnalyticHestonHullWhiteEngine_Range", Description="Create a range of AnalyticHestonHullWhiteEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let AnalyticHestonHullWhiteEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AnalyticHestonHullWhiteEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticHestonHullWhiteEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticHestonHullWhiteEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticHestonHullWhiteEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AnalyticHestonHullWhiteEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
