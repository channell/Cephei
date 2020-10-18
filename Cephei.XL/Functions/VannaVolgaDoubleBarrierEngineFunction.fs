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

  </summary> *)
[<AutoSerializable(true)>]
module VannaVolgaDoubleBarrierEngineFunction =


    (*
        
    *)
    (*!!
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_GetOriginalEngine", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_GetOriginalEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "IPricingEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        ([<ExcelArgument(Name="Process",Description = "GeneralizedBlackScholesProcess")>] 
         Process : obj)
        ([<ExcelArgument(Name="series",Description = "IPricingEngine")>] 
         series : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine"  
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" 
                let _series = Helper.toDefault<int> series "series" 5
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaDoubleBarrierEngineModel.Cast _VannaVolgaDoubleBarrierEngine.cell).GetOriginalEngine
                                                            _Process.cell 
                                                            _series.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IPricingEngine>) l

                let source () = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".GetOriginalEngine") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               ;  _Process.source
                                               ;  _series.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
                                ;  _Process.cell
                                ;  _series.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VannaVolgaDoubleBarrierEngine> format
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "VannaVolgaDoubleBarrierEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="atmVol",Description = "DeltaVolQuote")>] 
         atmVol : obj)
        ([<ExcelArgument(Name="vol25Put",Description = "DeltaVolQuote")>] 
         vol25Put : obj)
        ([<ExcelArgument(Name="vol25Call",Description = "DeltaVolQuote")>] 
         vol25Call : obj)
        ([<ExcelArgument(Name="spotFX",Description = "Quote")>] 
         spotFX : obj)
        ([<ExcelArgument(Name="domesticTS",Description = "YieldTermStructure")>] 
         domesticTS : obj)
        ([<ExcelArgument(Name="foreignTS",Description = "YieldTermStructure")>] 
         foreignTS : obj)
        ([<ExcelArgument(Name="getEngine",Description = "VannaVolgaDoubleBarrierEngine.GetOriginalEngine")>] 
         getEngine : obj)
        ([<ExcelArgument(Name="adaptVanDelta",Description = "VannaVolgaDoubleBarrierEngine")>] 
         adaptVanDelta : obj)
        ([<ExcelArgument(Name="bsPriceWithSmile",Description = "VannaVolgaDoubleBarrierEngine")>] 
         bsPriceWithSmile : obj)
        ([<ExcelArgument(Name="series",Description = "VannaVolgaDoubleBarrierEngine")>] 
         series : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "IPricingEngine")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Date")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _atmVol = Helper.toHandle<DeltaVolQuote> atmVol "atmVol" 
                let _vol25Put = Helper.toHandle<DeltaVolQuote> vol25Put "vol25Put" 
                let _vol25Call = Helper.toHandle<DeltaVolQuote> vol25Call "vol25Call" 
                let _spotFX = Helper.toHandle<Quote> spotFX "spotFX" 
                let _domesticTS = Helper.toHandle<YieldTermStructure> domesticTS "domesticTS" 
                let _foreignTS = Helper.toHandle<YieldTermStructure> foreignTS "foreignTS" 
                let _getEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine.GetOriginalEngine> getEngine "getEngine" 
                let _adaptVanDelta = Helper.toDefault<bool> adaptVanDelta "adaptVanDelta" false
                let _bsPriceWithSmile = Helper.toDefault<double> bsPriceWithSmile "bsPriceWithSmile" 0.0
                let _series = Helper.toDefault<int> series "series" 5
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder (current : ICell) = withMnemonic mnemonic (Fun.VannaVolgaDoubleBarrierEngine 
                                                            _atmVol.cell 
                                                            _vol25Put.cell 
                                                            _vol25Call.cell 
                                                            _spotFX.cell 
                                                            _domesticTS.cell 
                                                            _foreignTS.cell 
                                                            _getEngine.cell 
                                                            _adaptVanDelta.cell 
                                                            _bsPriceWithSmile.cell 
                                                            _series.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VannaVolgaDoubleBarrierEngine>) l

                let source () = Helper.sourceFold "Fun.VannaVolgaDoubleBarrierEngine" 
                                               [| _atmVol.source
                                               ;  _vol25Put.source
                                               ;  _vol25Call.source
                                               ;  _spotFX.source
                                               ;  _domesticTS.source
                                               ;  _foreignTS.source
                                               ;  _getEngine.source
                                               ;  _adaptVanDelta.source
                                               ;  _bsPriceWithSmile.source
                                               ;  _series.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _atmVol.cell
                                ;  _vol25Put.cell
                                ;  _vol25Call.cell
                                ;  _spotFX.cell
                                ;  _domesticTS.cell
                                ;  _foreignTS.cell
                                ;  _getEngine.cell
                                ;  _adaptVanDelta.cell
                                ;  _bsPriceWithSmile.cell
                                ;  _series.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VannaVolgaDoubleBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_registerWith", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaDoubleBarrierEngineModel.Cast _VannaVolgaDoubleBarrierEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".RegisterWith") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_reset", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaDoubleBarrierEngineModel.Cast _VannaVolgaDoubleBarrierEngine.cell).Reset
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".Reset") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_unregisterWith", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaDoubleBarrierEngineModel.Cast _VannaVolgaDoubleBarrierEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".UnregisterWith") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_update", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaDoubleBarrierEngineModel.Cast _VannaVolgaDoubleBarrierEngine.cell).Update
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".Update") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_Range", Description="Create a range of VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VannaVolgaDoubleBarrierEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VannaVolgaDoubleBarrierEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<VannaVolgaDoubleBarrierEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<VannaVolgaDoubleBarrierEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
