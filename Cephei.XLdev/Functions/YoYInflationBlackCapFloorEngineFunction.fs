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
  Black-formula inflation cap/floor engine (standalone, i.e. no coupon pricer)
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationBlackCapFloorEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationBlackCapFloorEngine", Description="Create a YoYInflationBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationBlackCapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="volatility",Description = "Reference to volatility")>] 
         volatility : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _index = Helper.toCell<YoYInflationIndex> index "index" true
                let _volatility = Helper.toHandle<Handle<YoYOptionletVolatilitySurface>> volatility "volatility" 
                let builder () = withMnemonic mnemonic (Fun.YoYInflationBlackCapFloorEngine 
                                                            _index.cell 
                                                            _volatility.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationBlackCapFloorEngine>) l

                let source = Helper.sourceFold "Fun.YoYInflationBlackCapFloorEngine" 
                                               [| _index.source
                                               ;  _volatility.source
                                               |]
                let hash = Helper.hashFold 
                                [| _index.cell
                                ;  _volatility.cell
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
    [<ExcelFunction(Name="_YoYInflationBlackCapFloorEngine_calculate", Description="Create a YoYInflationBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationBlackCapFloorEngine_calculate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationBlackCapFloorEngine",Description = "Reference to YoYInflationBlackCapFloorEngine")>] 
         yoyinflationblackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationBlackCapFloorEngine = Helper.toCell<YoYInflationBlackCapFloorEngine> yoyinflationblackcapfloorengine "YoYInflationBlackCapFloorEngine" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationBlackCapFloorEngine.cell :?> YoYInflationBlackCapFloorEngineModel).Calculate
                                                       ) :> ICell
                let format (o : YoYInflationBlackCapFloorEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationBlackCapFloorEngine.source + ".Calculate") 
                                               [| _YoYInflationBlackCapFloorEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationBlackCapFloorEngine.cell
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
    [<ExcelFunction(Name="_YoYInflationBlackCapFloorEngine_index", Description="Create a YoYInflationBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationBlackCapFloorEngine_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationBlackCapFloorEngine",Description = "Reference to YoYInflationBlackCapFloorEngine")>] 
         yoyinflationblackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationBlackCapFloorEngine = Helper.toCell<YoYInflationBlackCapFloorEngine> yoyinflationblackcapfloorengine "YoYInflationBlackCapFloorEngine" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationBlackCapFloorEngine.cell :?> YoYInflationBlackCapFloorEngineModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_YoYInflationBlackCapFloorEngine.source + ".Index") 
                                               [| _YoYInflationBlackCapFloorEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationBlackCapFloorEngine.cell
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
    [<ExcelFunction(Name="_YoYInflationBlackCapFloorEngine_setVolatility", Description="Create a YoYInflationBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationBlackCapFloorEngine_setVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationBlackCapFloorEngine",Description = "Reference to YoYInflationBlackCapFloorEngine")>] 
         yoyinflationblackcapfloorengine : obj)
        ([<ExcelArgument(Name="vol",Description = "Reference to vol")>] 
         vol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationBlackCapFloorEngine = Helper.toCell<YoYInflationBlackCapFloorEngine> yoyinflationblackcapfloorengine "YoYInflationBlackCapFloorEngine" true 
                let _vol = Helper.toHandle<Handle<YoYOptionletVolatilitySurface>> vol "vol" 
                let builder () = withMnemonic mnemonic ((_YoYInflationBlackCapFloorEngine.cell :?> YoYInflationBlackCapFloorEngineModel).SetVolatility
                                                            _vol.cell 
                                                       ) :> ICell
                let format (o : YoYInflationBlackCapFloorEngine) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_YoYInflationBlackCapFloorEngine.source + ".SetVolatility") 
                                               [| _YoYInflationBlackCapFloorEngine.source
                                               ;  _vol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationBlackCapFloorEngine.cell
                                ;  _vol.cell
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
    [<ExcelFunction(Name="_YoYInflationBlackCapFloorEngine_volatility", Description="Create a YoYInflationBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationBlackCapFloorEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationBlackCapFloorEngine",Description = "Reference to YoYInflationBlackCapFloorEngine")>] 
         yoyinflationblackcapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationBlackCapFloorEngine = Helper.toCell<YoYInflationBlackCapFloorEngine> yoyinflationblackcapfloorengine "YoYInflationBlackCapFloorEngine" true 
                let builder () = withMnemonic mnemonic ((_YoYInflationBlackCapFloorEngine.cell :?> YoYInflationBlackCapFloorEngineModel).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source = Helper.sourceFold (_YoYInflationBlackCapFloorEngine.source + ".Volatility") 
                                               [| _YoYInflationBlackCapFloorEngine.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationBlackCapFloorEngine.cell
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
    [<ExcelFunction(Name="_YoYInflationBlackCapFloorEngine_Range", Description="Create a range of YoYInflationBlackCapFloorEngine",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let YoYInflationBlackCapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the YoYInflationBlackCapFloorEngine")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationBlackCapFloorEngine> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationBlackCapFloorEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationBlackCapFloorEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<YoYInflationBlackCapFloorEngine>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
