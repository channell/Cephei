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
module TrinomialTreeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TrinomialTree_descendant", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "TimeGrid")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrinomialTree",Description = "TrinomialTree")>] 
         trinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "int")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrinomialTree = Helper.toCell<TrinomialTree> trinomialtree "TrinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrinomialTreeModel.Cast _TrinomialTree.cell).Descendant
                                                            _i.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrinomialTree.source + ".Descendant") 

                                               [| _i.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrinomialTree.cell
                                ;  _i.cell
                                ;  _index.cell
                                ;  _branch.cell
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
    [<ExcelFunction(Name="_TrinomialTree_dx", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_dx
        ([<ExcelArgument(Name="Mnemonic",Description = "TimeGrid")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrinomialTree",Description = "TrinomialTree")>] 
         trinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrinomialTree = Helper.toCell<TrinomialTree> trinomialtree "TrinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrinomialTreeModel.Cast _TrinomialTree.cell).Dx
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrinomialTree.source + ".Dx") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrinomialTree.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_TrinomialTree_probability", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "TimeGrid")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrinomialTree",Description = "TrinomialTree")>] 
         trinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "int")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrinomialTree = Helper.toCell<TrinomialTree> trinomialtree "TrinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrinomialTreeModel.Cast _TrinomialTree.cell).Probability
                                                            _i.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrinomialTree.source + ".Probability") 

                                               [| _i.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrinomialTree.cell
                                ;  _i.cell
                                ;  _index.cell
                                ;  _branch.cell
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
    [<ExcelFunction(Name="_TrinomialTree_size", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_size
        ([<ExcelArgument(Name="Mnemonic",Description = "TimeGrid")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrinomialTree",Description = "TrinomialTree")>] 
         trinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrinomialTree = Helper.toCell<TrinomialTree> trinomialtree "TrinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrinomialTreeModel.Cast _TrinomialTree.cell).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrinomialTree.source + ".Size") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrinomialTree.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_TrinomialTree_timeGrid", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_timeGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "TimeGrid")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrinomialTree",Description = "TrinomialTree")>] 
         trinomialtree : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrinomialTree = Helper.toCell<TrinomialTree> trinomialtree "TrinomialTree"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrinomialTreeModel.Cast _TrinomialTree.cell).TimeGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source () = Helper.sourceFold (_TrinomialTree.source + ".TimeGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TrinomialTree.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrinomialTree> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TrinomialTree", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TrinomialTree")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "TimeGrid")>] 
         timeGrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TrinomialTree 
                                                            _Process.cell 
                                                            _timeGrid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TrinomialTree>) l

                let source () = Helper.sourceFold "Fun.TrinomialTree" 
                                               [| _Process.source
                                               ;  _timeGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrinomialTree> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TrinomialTree1", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "TrinomialTree")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="timeGrid",Description = "TimeGrid")>] 
         timeGrid : obj)
        ([<ExcelArgument(Name="isPositive",Description = "bool")>] 
         isPositive : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let _isPositive = Helper.toCell<bool> isPositive "isPositive" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TrinomialTree1 
                                                            _Process.cell 
                                                            _timeGrid.cell 
                                                            _isPositive.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TrinomialTree>) l

                let source () = Helper.sourceFold "Fun.TrinomialTree1" 
                                               [| _Process.source
                                               ;  _timeGrid.source
                                               ;  _isPositive.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _timeGrid.cell
                                ;  _isPositive.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TrinomialTree> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TrinomialTree_underlying", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrinomialTree",Description = "TrinomialTree")>] 
         trinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrinomialTree = Helper.toCell<TrinomialTree> trinomialtree "TrinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((TrinomialTreeModel.Cast _TrinomialTree.cell).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrinomialTree.source + ".Underlying") 

                                               [| _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TrinomialTree.cell
                                ;  _i.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_TrinomialTree_columns", Description="Create a TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TrinomialTree",Description = "TrinomialTree")>] 
         trinomialtree : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TrinomialTree = Helper.toCell<TrinomialTree> trinomialtree "TrinomialTree"  
                let builder (current : ICell) = withMnemonic mnemonic ((TrinomialTreeModel.Cast _TrinomialTree.cell).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TrinomialTree.source + ".Columns") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TrinomialTree.cell
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
    [<ExcelFunction(Name="_TrinomialTree_Range", Description="Create a range of TrinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TrinomialTree_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TrinomialTree> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TrinomialTree>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TrinomialTree>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TrinomialTree>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
