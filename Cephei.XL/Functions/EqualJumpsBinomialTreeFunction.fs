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
(*!!
(* <summary>
  lattices
  </summary> *)
[<AutoSerializable(true)>]
module EqualJumpsBinomialTreeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_EqualJumpsBinomialTree", Description="Create a EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "StochasticProcess1D")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "double")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "int")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.EqualJumpsBinomialTree 
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EqualJumpsBinomialTree>) l

                let source () = Helper.sourceFold "Fun.EqualJumpsBinomialTree" 
                                               [| _Process.source
                                               ;  _End.source
                                               ;  _steps.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Process.cell
                                ;  _End.cell
                                ;  _steps.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EqualJumpsBinomialTree> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        parameterless constructor is requried for generics
    *)
    [<ExcelFunction(Name="_EqualJumpsBinomialTree1", Description="Create a EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.EqualJumpsBinomialTree1 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EqualJumpsBinomialTree>) l

                let source () = Helper.sourceFold "Fun.EqualJumpsBinomialTree1" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EqualJumpsBinomialTree> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EqualJumpsBinomialTree_probability", Description="Create a EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualJumpsBinomialTree",Description = "EqualJumpsBinomialTree")>] 
         equaljumpsbinomialtree : obj)
        ([<ExcelArgument(Name="x",Description = "int")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "int")>] 
         y : obj)
        ([<ExcelArgument(Name="branch",Description = "int")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualJumpsBinomialTree = Helper.toCell<EqualJumpsBinomialTree> equaljumpsbinomialtree "EqualJumpsBinomialTree"  
                let _x = Helper.toCell<int> x "x" 
                let _y = Helper.toCell<int> y "y" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((EqualJumpsBinomialTreeModel.Cast _EqualJumpsBinomialTree.cell).Probability
                                                            _x.cell 
                                                            _y.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EqualJumpsBinomialTree.source + ".Probability") 

                                               [| _x.source
                                               ;  _y.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualJumpsBinomialTree.cell
                                ;  _x.cell
                                ;  _y.cell
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
    [<ExcelFunction(Name="_EqualJumpsBinomialTree_underlying", Description="Create a EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualJumpsBinomialTree",Description = "EqualJumpsBinomialTree")>] 
         equaljumpsbinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualJumpsBinomialTree = Helper.toCell<EqualJumpsBinomialTree> equaljumpsbinomialtree "EqualJumpsBinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = withMnemonic mnemonic ((EqualJumpsBinomialTreeModel.Cast _EqualJumpsBinomialTree.cell).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EqualJumpsBinomialTree.source + ".Underlying") 

                                               [| _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualJumpsBinomialTree.cell
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
    [<ExcelFunction(Name="_EqualJumpsBinomialTree_descendant", Description="Create a EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualJumpsBinomialTree",Description = "EqualJumpsBinomialTree")>] 
         equaljumpsbinomialtree : obj)
        ([<ExcelArgument(Name="x",Description = "int")>] 
         x : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "int")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualJumpsBinomialTree = Helper.toCell<EqualJumpsBinomialTree> equaljumpsbinomialtree "EqualJumpsBinomialTree"  
                let _x = Helper.toCell<int> x "x" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((EqualJumpsBinomialTreeModel.Cast _EqualJumpsBinomialTree.cell).Descendant
                                                            _x.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EqualJumpsBinomialTree.source + ".Descendant") 

                                               [| _x.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualJumpsBinomialTree.cell
                                ;  _x.cell
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
    [<ExcelFunction(Name="_EqualJumpsBinomialTree_size", Description="Create a EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualJumpsBinomialTree",Description = "EqualJumpsBinomialTree")>] 
         equaljumpsbinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualJumpsBinomialTree = Helper.toCell<EqualJumpsBinomialTree> equaljumpsbinomialtree "EqualJumpsBinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((EqualJumpsBinomialTreeModel.Cast _EqualJumpsBinomialTree.cell).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EqualJumpsBinomialTree.source + ".Size") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualJumpsBinomialTree.cell
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
    [<ExcelFunction(Name="_EqualJumpsBinomialTree_columns", Description="Create a EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualJumpsBinomialTree",Description = "EqualJumpsBinomialTree")>] 
         equaljumpsbinomialtree : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualJumpsBinomialTree = Helper.toCell<EqualJumpsBinomialTree> equaljumpsbinomialtree "EqualJumpsBinomialTree"  
                let builder (current : ICell) = withMnemonic mnemonic ((EqualJumpsBinomialTreeModel.Cast _EqualJumpsBinomialTree.cell).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_EqualJumpsBinomialTree.source + ".Columns") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _EqualJumpsBinomialTree.cell
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
    [<ExcelFunction(Name="_EqualJumpsBinomialTree_Range", Description="Create a range of EqualJumpsBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualJumpsBinomialTree_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EqualJumpsBinomialTree> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<EqualJumpsBinomialTree> (c)) :> ICell
                let format (i : Cephei.Cell.List<EqualJumpsBinomialTree>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<EqualJumpsBinomialTree>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
