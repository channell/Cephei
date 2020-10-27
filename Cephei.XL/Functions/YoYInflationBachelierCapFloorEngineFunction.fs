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
  Unit Displaced Black-formula inflation cap/floor engine (standalone, i.e. no coupon pricer)
  </summary> *)
[<AutoSerializable(true)>]
module YoYInflationBachelierCapFloorEngineFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationBachelierCapFloorEngine", Description="Create a YoYInflationBachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationBachelierCapFloorEngine_create
        ([<ExcelArgument(Name="Mnemonic",Description = "YoYInflationBachelierCapFloorEngine")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="index",Description = "YoYInflationIndex")>] 
         index : obj)
        ([<ExcelArgument(Name="vol",Description = "YoYOptionletVolatilitySurface")>] 
         vol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _index = Helper.toCell<YoYInflationIndex> index "index" 
                let _vol = Helper.toHandle<YoYOptionletVolatilitySurface> vol "vol" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.YoYInflationBachelierCapFloorEngine 
                                                            _index.cell 
                                                            _vol.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationBachelierCapFloorEngine>) l

                let source () = Helper.sourceFold "Fun.YoYInflationBachelierCapFloorEngine" 
                                               [| _index.source
                                               ;  _vol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _index.cell
                                ;  _vol.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationBachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"

    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationBachelierCapFloorEngine_index", Description="Create a YoYInflationBachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationBachelierCapFloorEngine_index
        ([<ExcelArgument(Name="Mnemonic",Description = "YoYInflationIndex")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationBachelierCapFloorEngine",Description = "YoYInflationBachelierCapFloorEngine")>] 
         yoyinflationbacheliercapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationBachelierCapFloorEngine = Helper.toCell<YoYInflationBachelierCapFloorEngine> yoyinflationbacheliercapfloorengine "YoYInflationBachelierCapFloorEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationBachelierCapFloorEngineModel.Cast _YoYInflationBachelierCapFloorEngine.cell).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source () = Helper.sourceFold (_YoYInflationBachelierCapFloorEngine.source + ".Index") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationBachelierCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationBachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_YoYInflationBachelierCapFloorEngine_setVolatility", Description="Create a YoYInflationBachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationBachelierCapFloorEngine_setVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "YoYOptionletVolatilitySurface")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationBachelierCapFloorEngine",Description = "YoYInflationBachelierCapFloorEngine")>] 
         yoyinflationbacheliercapfloorengine : obj)
        ([<ExcelArgument(Name="vol",Description = "YoYOptionletVolatilitySurface")>] 
         vol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationBachelierCapFloorEngine = Helper.toCell<YoYInflationBachelierCapFloorEngine> yoyinflationbacheliercapfloorengine "YoYInflationBachelierCapFloorEngine"  
                let _vol = Helper.toHandle<YoYOptionletVolatilitySurface> vol "vol" 
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationBachelierCapFloorEngineModel.Cast _YoYInflationBachelierCapFloorEngine.cell).SetVolatility
                                                            _vol.cell 
                                                       ) :> ICell
                let format (o : YoYInflationBachelierCapFloorEngine) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_YoYInflationBachelierCapFloorEngine.source + ".SetVolatility") 

                                               [| _vol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _YoYInflationBachelierCapFloorEngine.cell
                                ;  _vol.cell
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
    [<ExcelFunction(Name="_YoYInflationBachelierCapFloorEngine_volatility", Description="Create a YoYInflationBachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationBachelierCapFloorEngine_volatility
        ([<ExcelArgument(Name="Mnemonic",Description = "YoYOptionletVolatilitySurface")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="YoYInflationBachelierCapFloorEngine",Description = "YoYInflationBachelierCapFloorEngine")>] 
         yoyinflationbacheliercapfloorengine : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _YoYInflationBachelierCapFloorEngine = Helper.toCell<YoYInflationBachelierCapFloorEngine> yoyinflationbacheliercapfloorengine "YoYInflationBachelierCapFloorEngine"  
                let builder (current : ICell) = withMnemonic mnemonic ((YoYInflationBachelierCapFloorEngineModel.Cast _YoYInflationBachelierCapFloorEngine.cell).Volatility
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YoYOptionletVolatilitySurface>>) l

                let source () = Helper.sourceFold (_YoYInflationBachelierCapFloorEngine.source + ".Volatility") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _YoYInflationBachelierCapFloorEngine.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<YoYInflationBachelierCapFloorEngine> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_YoYInflationBachelierCapFloorEngine_Range", Description="Create a range of YoYInflationBachelierCapFloorEngine",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let YoYInflationBachelierCapFloorEngine_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<YoYInflationBachelierCapFloorEngine> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<YoYInflationBachelierCapFloorEngine>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<YoYInflationBachelierCapFloorEngine>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<YoYInflationBachelierCapFloorEngine>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
