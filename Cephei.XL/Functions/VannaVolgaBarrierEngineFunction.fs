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
module VannaVolgaBarrierEngineFunction =


    (*
        
    *)
    [<ExcelFunction(Name="_VannaVolgaBarrierEngine", Description="Create a VannaVolgaBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaBarrierEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "VannaVolgaBarrierEngine")>] 
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
        ([<ExcelArgument(Name="adaptVanDelta",Description = "VannaVolgaBarrierEngine")>] 
         adaptVanDelta : obj)
        ([<ExcelArgument(Name="bsPriceWithSmile",Description = "VannaVolgaBarrierEngine")>] 
         bsPriceWithSmile : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _atmVol = Helper.toHandle<DeltaVolQuote> atmVol "atmVol" 
                let _vol25Put = Helper.toHandle<DeltaVolQuote> vol25Put "vol25Put" 
                let _vol25Call = Helper.toHandle<DeltaVolQuote> vol25Call "vol25Call" 
                let _spotFX = Helper.toHandle<Quote> spotFX "spotFX" 
                let _domesticTS = Helper.toHandle<YieldTermStructure> domesticTS "domesticTS" 
                let _foreignTS = Helper.toHandle<YieldTermStructure> foreignTS "foreignTS" 
                let _adaptVanDelta = Helper.toDefault<bool> adaptVanDelta "adaptVanDelta" false
                let _bsPriceWithSmile = Helper.toDefault<double> bsPriceWithSmile "bsPriceWithSmile" 0.0
                let builder (current : ICell) = withMnemonic mnemonic (Fun.VannaVolgaBarrierEngine 
                                                            _atmVol.cell 
                                                            _vol25Put.cell 
                                                            _vol25Call.cell 
                                                            _spotFX.cell 
                                                            _domesticTS.cell 
                                                            _foreignTS.cell 
                                                            _adaptVanDelta.cell 
                                                            _bsPriceWithSmile.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<VannaVolgaBarrierEngine>) l

                let source () = Helper.sourceFold "Fun.VannaVolgaBarrierEngine" 
                                               [| _atmVol.source
                                               ;  _vol25Put.source
                                               ;  _vol25Call.source
                                               ;  _spotFX.source
                                               ;  _domesticTS.source
                                               ;  _foreignTS.source
                                               ;  _adaptVanDelta.source
                                               ;  _bsPriceWithSmile.source
                                               |]
                let hash = Helper.hashFold 
                                [| _atmVol.cell
                                ;  _vol25Put.cell
                                ;  _vol25Call.cell
                                ;  _spotFX.cell
                                ;  _domesticTS.cell
                                ;  _foreignTS.cell
                                ;  _adaptVanDelta.cell
                                ;  _bsPriceWithSmile.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<VannaVolgaBarrierEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_VannaVolgaBarrierEngine_registerWith", Description="Create a VannaVolgaBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaBarrierEngine_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaBarrierEngine",Description = "VannaVolgaBarrierEngine")>] 
         vannavolgabarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaBarrierEngine = Helper.toCell<VannaVolgaBarrierEngine> vannavolgabarrierengine "VannaVolgaBarrierEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaBarrierEngineModel.Cast _VannaVolgaBarrierEngine.cell).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaBarrierEngine.source + ".RegisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaBarrierEngine_reset", Description="Create a VannaVolgaBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaBarrierEngine_reset
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaBarrierEngine",Description = "VannaVolgaBarrierEngine")>] 
         vannavolgabarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaBarrierEngine = Helper.toCell<VannaVolgaBarrierEngine> vannavolgabarrierengine "VannaVolgaBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaBarrierEngineModel.Cast _VannaVolgaBarrierEngine.cell).Reset
                                                       ) :> ICell
                let format (o : VannaVolgaBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaBarrierEngine.source + ".Reset") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaBarrierEngine_unregisterWith", Description="Create a VannaVolgaBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaBarrierEngine_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaBarrierEngine",Description = "VannaVolgaBarrierEngine")>] 
         vannavolgabarrierengine : obj)
        ([<ExcelArgument(Name="handler",Description = "Callback")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaBarrierEngine = Helper.toCell<VannaVolgaBarrierEngine> vannavolgabarrierengine "VannaVolgaBarrierEngine"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaBarrierEngineModel.Cast _VannaVolgaBarrierEngine.cell).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : VannaVolgaBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaBarrierEngine.source + ".UnregisterWith") 

                                               [| _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _VannaVolgaBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaBarrierEngine_update", Description="Create a VannaVolgaBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaBarrierEngine_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="VannaVolgaBarrierEngine",Description = "VannaVolgaBarrierEngine")>] 
         vannavolgabarrierengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _VannaVolgaBarrierEngine = Helper.toCell<VannaVolgaBarrierEngine> vannavolgabarrierengine "VannaVolgaBarrierEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((VannaVolgaBarrierEngineModel.Cast _VannaVolgaBarrierEngine.cell).Update
                                                       ) :> ICell
                let format (o : VannaVolgaBarrierEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_VannaVolgaBarrierEngine.source + ".Update") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _VannaVolgaBarrierEngine.cell
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
    [<ExcelFunction(Name="_VannaVolgaBarrierEngine_Range", Description="Create a range of VannaVolgaBarrierEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let VannaVolgaBarrierEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<VannaVolgaBarrierEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<VannaVolgaBarrierEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<VannaVolgaBarrierEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<VannaVolgaBarrierEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
