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
  References:  Lech A. Grzelak, Cornelis W. Oosterlee, On The Heston Model with Stochastic, http://papers.ssrn.com/sol3/papers.cfm?abstract_id=1382902  Lech A. Grzelak, Equity and Foreign Exchange Hybrid Models for Pricing Long-Maturity Financial Derivatives, http://repository.tudelft.nl/assets/uuid:a8e1a007-bd89-481a-aee3-0e22f15ade6b/PhDThesis_main.pdf  vanillaengines  the correctness of the returned value is tested by reproducing results available in web/literature, testing against QuantLib's analytic Heston, the Black-Scholes-Merton Hull-White engine and the finite difference Heston-Hull-White engine
  </summary> *)
[<AutoSerializable(true)>]
module AnalyticH1HWEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticH1HWEngine", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="hullWhiteModel",Description = "Reference to hullWhiteModel")>] 
         hullWhiteModel : obj)
        ([<ExcelArgument(Name="rhoSr",Description = "Reference to rhoSr")>] 
         rhoSr : obj)
        ([<ExcelArgument(Name="integrationOrder",Description = "Reference to integrationOrder")>] 
         integrationOrder : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<HestonModel> model "model" 
                let _hullWhiteModel = Helper.toCell<HullWhite> hullWhiteModel "hullWhiteModel" 
                let _rhoSr = Helper.toCell<double> rhoSr "rhoSr" 
                let _integrationOrder = Helper.toDefault<int> integrationOrder "integrationOrder" 144
                let builder () = withMnemonic mnemonic (Fun.AnalyticH1HWEngine 
                                                            _model.cell 
                                                            _hullWhiteModel.cell 
                                                            _rhoSr.cell 
                                                            _integrationOrder.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticH1HWEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticH1HWEngine" 
                                               [| _model.source
                                               ;  _hullWhiteModel.source
                                               ;  _rhoSr.source
                                               ;  _integrationOrder.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _hullWhiteModel.cell
                                ;  _rhoSr.cell
                                ;  _integrationOrder.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticH1HWEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_AnalyticH1HWEngine1", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        ([<ExcelArgument(Name="hullWhiteModel",Description = "Reference to hullWhiteModel")>] 
         hullWhiteModel : obj)
        ([<ExcelArgument(Name="rhoSr",Description = "Reference to rhoSr")>] 
         rhoSr : obj)
        ([<ExcelArgument(Name="relTolerance",Description = "Reference to relTolerance")>] 
         relTolerance : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _model = Helper.toCell<HestonModel> model "model" 
                let _hullWhiteModel = Helper.toCell<HullWhite> hullWhiteModel "hullWhiteModel" 
                let _rhoSr = Helper.toCell<double> rhoSr "rhoSr" 
                let _relTolerance = Helper.toCell<double> relTolerance "relTolerance" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic (Fun.AnalyticH1HWEngine1 
                                                            _model.cell 
                                                            _hullWhiteModel.cell 
                                                            _rhoSr.cell 
                                                            _relTolerance.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<AnalyticH1HWEngine>) l

                let source = Helper.sourceFold "Fun.AnalyticH1HWEngine1" 
                                               [| _model.source
                                               ;  _hullWhiteModel.source
                                               ;  _rhoSr.source
                                               ;  _relTolerance.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _model.cell
                                ;  _hullWhiteModel.cell
                                ;  _rhoSr.cell
                                ;  _relTolerance.cell
                                ;  _maxEvaluations.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<AnalyticH1HWEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)

    [<ExcelFunction(Name="_AnalyticH1HWEngine_update", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticH1HWEngine",Description = "Reference to AnalyticH1HWEngine")>] 
         analytich1hwengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticH1HWEngine = Helper.toCell<AnalyticH1HWEngine> analytich1hwengine "AnalyticH1HWEngine"  
                let builder () = withMnemonic mnemonic ((AnalyticH1HWEngineModel.Cast _AnalyticH1HWEngine.cell).Update
                                                       ) :> ICell
                let format (o : AnalyticH1HWEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticH1HWEngine.source + ".Update") 
                                               [| _AnalyticH1HWEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticH1HWEngine.cell
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
    [<ExcelFunction(Name="_AnalyticH1HWEngine_numberOfEvaluations", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_numberOfEvaluations
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticH1HWEngine",Description = "Reference to AnalyticH1HWEngine")>] 
         analytich1hwengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticH1HWEngine = Helper.toCell<AnalyticH1HWEngine> analytich1hwengine "AnalyticH1HWEngine"  
                let builder () = withMnemonic mnemonic ((AnalyticH1HWEngineModel.Cast _AnalyticH1HWEngine.cell).NumberOfEvaluations
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_AnalyticH1HWEngine.source + ".NumberOfEvaluations") 
                                               [| _AnalyticH1HWEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticH1HWEngine.cell
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
    [<ExcelFunction(Name="_AnalyticH1HWEngine_setModel", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_setModel
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticH1HWEngine",Description = "Reference to AnalyticH1HWEngine")>] 
         analytich1hwengine : obj)
        ([<ExcelArgument(Name="model",Description = "Reference to model")>] 
         model : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticH1HWEngine = Helper.toCell<AnalyticH1HWEngine> analytich1hwengine "AnalyticH1HWEngine"  
                let _model = Helper.toHandle<HestonModel> model "model" 
                let builder () = withMnemonic mnemonic ((AnalyticH1HWEngineModel.Cast _AnalyticH1HWEngine.cell).SetModel
                                                            _model.cell 
                                                       ) :> ICell
                let format (o : AnalyticH1HWEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticH1HWEngine.source + ".SetModel") 
                                               [| _AnalyticH1HWEngine.source
                                               ;  _model.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticH1HWEngine.cell
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
    [<ExcelFunction(Name="_AnalyticH1HWEngine_registerWith", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticH1HWEngine",Description = "Reference to AnalyticH1HWEngine")>] 
         analytich1hwengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticH1HWEngine = Helper.toCell<AnalyticH1HWEngine> analytich1hwengine "AnalyticH1HWEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((AnalyticH1HWEngineModel.Cast _AnalyticH1HWEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticH1HWEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticH1HWEngine.source + ".RegisterWith") 
                                               [| _AnalyticH1HWEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticH1HWEngine.cell
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
    [<ExcelFunction(Name="_AnalyticH1HWEngine_reset", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticH1HWEngine",Description = "Reference to AnalyticH1HWEngine")>] 
         analytich1hwengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticH1HWEngine = Helper.toCell<AnalyticH1HWEngine> analytich1hwengine "AnalyticH1HWEngine"  
                let builder () = withMnemonic mnemonic ((AnalyticH1HWEngineModel.Cast _AnalyticH1HWEngine.cell).Reset
                                                       ) :> ICell
                let format (o : AnalyticH1HWEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticH1HWEngine.source + ".Reset") 
                                               [| _AnalyticH1HWEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticH1HWEngine.cell
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
    [<ExcelFunction(Name="_AnalyticH1HWEngine_unregisterWith", Description="Create a AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="AnalyticH1HWEngine",Description = "Reference to AnalyticH1HWEngine")>] 
         analytich1hwengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _AnalyticH1HWEngine = Helper.toCell<AnalyticH1HWEngine> analytich1hwengine "AnalyticH1HWEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((AnalyticH1HWEngineModel.Cast _AnalyticH1HWEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : AnalyticH1HWEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_AnalyticH1HWEngine.source + ".UnregisterWith") 
                                               [| _AnalyticH1HWEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _AnalyticH1HWEngine.cell
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
    [<ExcelFunction(Name="_AnalyticH1HWEngine_Range", Description="Create a range of AnalyticH1HWEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let AnalyticH1HWEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the AnalyticH1HWEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<AnalyticH1HWEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<AnalyticH1HWEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<AnalyticH1HWEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<AnalyticH1HWEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
