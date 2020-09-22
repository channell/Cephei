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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_calculate", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "Reference to VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine" true 
                let builder () = withMnemonic mnemonic ((_VannaVolgaDoubleBarrierEngine.cell :?> VannaVolgaDoubleBarrierEngineModel).Calculate
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".Calculate") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_GetOriginalEngine", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_GetOriginalEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "Reference to VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="series",Description = "Reference to series")>] 
         series : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine" true 
                let _Process = Helper.toCell<GeneralizedBlackScholesProcess> Process "Process" true
                let _series = Helper.toCell<int> series "series" true
                let builder () = withMnemonic mnemonic ((_VannaVolgaDoubleBarrierEngine.cell :?> VannaVolgaDoubleBarrierEngineModel).GetOriginalEngine
                                                            _Process.cell 
                                                            _series.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IPricingEngine>) l

                let source = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".GetOriginalEngine") 
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="atmVol",Description = "Reference to atmVol")>] 
         atmVol : obj)
        ([<ExcelArgument(Name="vol25Put",Description = "Reference to vol25Put")>] 
         vol25Put : obj)
        ([<ExcelArgument(Name="vol25Call",Description = "Reference to vol25Call")>] 
         vol25Call : obj)
        ([<ExcelArgument(Name="spotFX",Description = "Reference to spotFX")>] 
         spotFX : obj)
        ([<ExcelArgument(Name="domesticTS",Description = "Reference to domesticTS")>] 
         domesticTS : obj)
        ([<ExcelArgument(Name="foreignTS",Description = "Reference to foreignTS")>] 
         foreignTS : obj)
        ([<ExcelArgument(Name="getEngine",Description = "Reference to getEngine")>] 
         getEngine : obj)
        ([<ExcelArgument(Name="adaptVanDelta",Description = "Reference to adaptVanDelta")>] 
         adaptVanDelta : obj)
        ([<ExcelArgument(Name="bsPriceWithSmile",Description = "Reference to bsPriceWithSmile")>] 
         bsPriceWithSmile : obj)
        ([<ExcelArgument(Name="series",Description = "Reference to series")>] 
         series : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _atmVol = Helper.toHandle<Handle<DeltaVolQuote>> atmVol "atmVol" 
                let _vol25Put = Helper.toHandle<Handle<DeltaVolQuote>> vol25Put "vol25Put" 
                let _vol25Call = Helper.toHandle<Handle<DeltaVolQuote>> vol25Call "vol25Call" 
                let _spotFX = Helper.toHandle<Handle<Quote>> spotFX "spotFX" 
                let _domesticTS = Helper.toHandle<Handle<YieldTermStructure>> domesticTS "domesticTS" 
                let _foreignTS = Helper.toHandle<Handle<YieldTermStructure>> foreignTS "foreignTS" 
                let _getEngine = Helper.toCell<GetOriginalEngine> getEngine "getEngine" true
                let _adaptVanDelta = Helper.toCell<bool> adaptVanDelta "adaptVanDelta" true
                let _bsPriceWithSmile = Helper.toCell<double> bsPriceWithSmile "bsPriceWithSmile" true
                let _series = Helper.toCell<int> series "series" true
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine" true 
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate" true 
                let builder () = withMnemonic mnemonic (Fun.VannaVolgaDoubleBarrierEngine 
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

                let source = Helper.sourceFold "Fun.VannaVolgaDoubleBarrierEngine" 
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_registerWith", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "Reference to VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_VannaVolgaDoubleBarrierEngine.cell :?> VannaVolgaDoubleBarrierEngineModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".RegisterWith") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_reset", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "Reference to VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine" true 
                let builder () = withMnemonic mnemonic ((_VannaVolgaDoubleBarrierEngine.cell :?> VannaVolgaDoubleBarrierEngineModel).Reset
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".Reset") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_unregisterWith", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "Reference to VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine" true 
                let _handler = Helper.toCell<Callback> handler "handler" true
                let builder () = withMnemonic mnemonic ((_VannaVolgaDoubleBarrierEngine.cell :?> VannaVolgaDoubleBarrierEngineModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".UnregisterWith") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_update", Description="Create a VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaDoubleBarrierEngine",Description = "Reference to VannaVolgaDoubleBarrierEngine")>] 
         vannavolgadoublebarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaDoubleBarrierEngine = Helper.toCell<VannaVolgaDoubleBarrierEngine> vannavolgadoublebarrierengine "VannaVolgaDoubleBarrierEngine" true 
                let builder () = withMnemonic mnemonic ((_VannaVolgaDoubleBarrierEngine.cell :?> VannaVolgaDoubleBarrierEngineModel).Update
                                                       ) :> ICell
                let format (o : VannaVolgaDoubleBarrierEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_VannaVolgaDoubleBarrierEngine.source + ".Update") 
                                               [| _VannaVolgaDoubleBarrierEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaDoubleBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaDoubleBarrierEngine_Range", Description="Create a range of VannaVolgaDoubleBarrierEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let VannaVolgaDoubleBarrierEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the VannaVolgaDoubleBarrierEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VannaVolgaDoubleBarrierEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VannaVolgaDoubleBarrierEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<VannaVolgaDoubleBarrierEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<VannaVolgaDoubleBarrierEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
