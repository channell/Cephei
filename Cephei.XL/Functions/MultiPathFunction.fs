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
    [<ExcelFunction(Name="_MultiPath_assetNumber", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_assetNumber
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiPath")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath"  
                let builder (current : ICell) = withMnemonic mnemonic ((MultiPathModel.Cast _MultiPath.cell).AssetNumber
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiPath.source + ".AssetNumber") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
        ICloneable interface
    *)
    [<ExcelFunction(Name="_MultiPath_Clone", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiPath")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath"  
                let builder (current : ICell) = withMnemonic mnemonic ((MultiPathModel.Cast _MultiPath.cell).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiPath.source + ".Clone") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
    [<ExcelFunction(Name="_MultiPath_length", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_length
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiPath")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath"  
                let builder (current : ICell) = withMnemonic mnemonic ((MultiPathModel.Cast _MultiPath.cell).Length
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiPath.source + ".Length") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
    [<ExcelFunction(Name="_MultiPath2", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiPath")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="multiPath",Description = "Path")>] 
         multiPath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _multiPath = Helper.toCell<Generic.List<Path>> multiPath "multiPath" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MultiPath2 
                                                            _multiPath.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiPath>) l

                let source () = Helper.sourceFold "Fun.MultiPath2" 
                                               [| _multiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _multiPath.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiPath> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiPath", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_create
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiPath")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="nAsset",Description = "int")>] 
         nAsset : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "TimeGrid")>] 
         timeGrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _nAsset = Helper.toCell<int> nAsset "nAsset" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.MultiPath
                                                            _nAsset.cell 
                                                            _timeGrid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiPath>) l

                let source () = Helper.sourceFold "Fun.MultiPath" 
                                               [| _nAsset.source
                                               ;  _timeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _nAsset.cell
                                ;  _timeGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiPath> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiPath1", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "MultiPath")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.MultiPath1 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MultiPath>) l

                let source () = Helper.sourceFold "Fun.MultiPath1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MultiPath> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MultiPath_pathSize", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_pathSize
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "MultiPath")>] 
         multipath : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath"  
                let builder (current : ICell) = withMnemonic mnemonic ((MultiPathModel.Cast _MultiPath.cell).PathSize
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_MultiPath.source + ".PathSize") 
                                               [| _MultiPath.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
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
        read/write access to components
    *)
    [<ExcelFunction(Name="_MultiPath_this", Description="Create a MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MultiPath",Description = "MultiPath")>] 
         multipath : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MultiPath = Helper.toCell<MultiPath> multipath "MultiPath"  
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((MultiPathModel.Cast _MultiPath.cell).This
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : Path) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_MultiPath.source + ".This") 
                                               [| _MultiPath.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MultiPath.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_MultiPath_Range", Description="Create a range of MultiPath",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let MultiPath_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MultiPath> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MultiPath>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<MultiPath>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<MultiPath>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
