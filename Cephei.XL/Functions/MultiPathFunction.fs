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
  MultiPath contains the list of paths for each asset, i.e., multipath[j] is the path followed by the j-th asset.  mcarlo
  </summary> *)
[<AutoSerializable(true)>]
module MultiPathFunction =

    (*
        inspectors
    *)
    [<ExcelFunction(Name="_MultiPath_assetNumber", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_assetNumber
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "Reference to MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath" true 
                let builder () = withMnemonic mnemonic ((_MultiPath.cell :?> MultiPathModel).AssetNumber
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiPath.source + ".AssetNumber") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
        ICloneable interface
    *)
    [<ExcelFunction(Name="_MultiPath_Clone", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "Reference to MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath" true 
                let builder () = withMnemonic mnemonic ((_MultiPath.cell :?> MultiPathModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MultiPath.source + ".Clone") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
    [<ExcelFunction(Name="_MultiPath_length", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_length
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "Reference to MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath" true 
                let builder () = withMnemonic mnemonic ((_MultiPath.cell :?> MultiPathModel).Length
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiPath.source + ".Length") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
    [<ExcelFunction(Name="_MultiPath2", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="multiPath",Description = "Reference to multiPath")>] 
         multiPath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _multiPath = Helper.toCell<Generic.List<Path>> multiPath "multiPath" true
                let builder () = withMnemonic mnemonic (Fun.MultiPath2 
                                                            _multiPath.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiPath>) l

                let source = Helper.sourceFold "Fun.MultiPath2" 
                                               [| _multiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _multiPath.cell
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
    [<ExcelFunction(Name="_MultiPath", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="nAsset",Description = "Reference to nAsset")>] 
         nAsset : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "Reference to timeGrid")>] 
         timeGrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _nAsset = Helper.toCell<int> nAsset "nAsset" true
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" true
                let builder () = withMnemonic mnemonic (Fun.MultiPath
                                                            _nAsset.cell 
                                                            _timeGrid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiPath>) l

                let source = Helper.sourceFold "Fun.MultiPath" 
                                               [| _nAsset.source
                                               ;  _timeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _nAsset.cell
                                ;  _timeGrid.cell
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
    [<ExcelFunction(Name="_MultiPath1", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.MultiPath1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiPath>) l

                let source = Helper.sourceFold "Fun.MultiPath1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
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
    [<ExcelFunction(Name="_MultiPath_pathSize", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_pathSize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "Reference to MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath" true 
                let builder () = withMnemonic mnemonic ((_MultiPath.cell :?> MultiPathModel).PathSize
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MultiPath.source + ".PathSize") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
        read/write access to components
    *)
    [<ExcelFunction(Name="_MultiPath_this", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "Reference to MultiPath")>] 
         multipath : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath" true 
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_MultiPath.cell :?> MultiPathModel).This
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Path) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MultiPath.source + ".This") 
                                               [| _MultiPath.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_MultiPath_Range", Description="Create a range of MultiPath",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MultiPath_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MultiPath")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MultiPath> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MultiPath>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MultiPath>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MultiPath>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
