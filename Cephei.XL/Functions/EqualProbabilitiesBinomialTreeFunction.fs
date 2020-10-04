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
module EqualProbabilitiesBinomialTreeFunction =

    (*
        parameterless constructor is requried for generics
    *)
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree", Description="Create a EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.EqualProbabilitiesBinomialTree 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EqualProbabilitiesBinomialTree>) l

                let source = Helper.sourceFold "Fun.EqualProbabilitiesBinomialTree" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EqualProbabilitiesBinomialTree> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree1", Description="Create a EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Process",Description = "Reference to Process")>] 
         Process : obj)
        ([<ExcelArgument(Name="End",Description = "Reference to End")>] 
         End : obj)
        ([<ExcelArgument(Name="steps",Description = "Reference to steps")>] 
         steps : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Process = Helper.toCell<StochasticProcess1D> Process "Process" 
                let _End = Helper.toCell<double> End "End" 
                let _steps = Helper.toCell<int> steps "steps" 
                let builder () = withMnemonic mnemonic (Fun.EqualProbabilitiesBinomialTree1 
                                                            _Process.cell 
                                                            _End.cell 
                                                            _steps.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<EqualProbabilitiesBinomialTree>) l

                let source = Helper.sourceFold "Fun.EqualProbabilitiesBinomialTree1" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<EqualProbabilitiesBinomialTree> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree_probability", Description="Create a EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualProbabilitiesBinomialTree",Description = "Reference to EqualProbabilitiesBinomialTree")>] 
         equalprobabilitiesbinomialtree : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="y",Description = "Reference to y")>] 
         y : obj)
        ([<ExcelArgument(Name="z",Description = "Reference to z")>] 
         z : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualProbabilitiesBinomialTree = Helper.toCell<EqualProbabilitiesBinomialTree> equalprobabilitiesbinomialtree "EqualProbabilitiesBinomialTree"  
                let _x = Helper.toCell<int> x "x" 
                let _y = Helper.toCell<int> y "y" 
                let _z = Helper.toCell<int> z "z" 
                let builder () = withMnemonic mnemonic ((EqualProbabilitiesBinomialTreeModel.Cast _EqualProbabilitiesBinomialTree.cell).Probability
                                                            _x.cell 
                                                            _y.cell 
                                                            _z.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EqualProbabilitiesBinomialTree.source + ".Probability") 
                                               [| _EqualProbabilitiesBinomialTree.source
                                               ;  _x.source
                                               ;  _y.source
                                               ;  _z.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualProbabilitiesBinomialTree.cell
                                ;  _x.cell
                                ;  _y.cell
                                ;  _z.cell
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
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree_underlying", Description="Create a EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualProbabilitiesBinomialTree",Description = "Reference to EqualProbabilitiesBinomialTree")>] 
         equalprobabilitiesbinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualProbabilitiesBinomialTree = Helper.toCell<EqualProbabilitiesBinomialTree> equalprobabilitiesbinomialtree "EqualProbabilitiesBinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let builder () = withMnemonic mnemonic ((EqualProbabilitiesBinomialTreeModel.Cast _EqualProbabilitiesBinomialTree.cell).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_EqualProbabilitiesBinomialTree.source + ".Underlying") 
                                               [| _EqualProbabilitiesBinomialTree.source
                                               ;  _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualProbabilitiesBinomialTree.cell
                                ;  _i.cell
                                ;  _index.cell
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
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree_descendant", Description="Create a EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualProbabilitiesBinomialTree",Description = "Reference to EqualProbabilitiesBinomialTree")>] 
         equalprobabilitiesbinomialtree : obj)
        ([<ExcelArgument(Name="x",Description = "Reference to x")>] 
         x : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualProbabilitiesBinomialTree = Helper.toCell<EqualProbabilitiesBinomialTree> equalprobabilitiesbinomialtree "EqualProbabilitiesBinomialTree"  
                let _x = Helper.toCell<int> x "x" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder () = withMnemonic mnemonic ((EqualProbabilitiesBinomialTreeModel.Cast _EqualProbabilitiesBinomialTree.cell).Descendant
                                                            _x.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EqualProbabilitiesBinomialTree.source + ".Descendant") 
                                               [| _EqualProbabilitiesBinomialTree.source
                                               ;  _x.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualProbabilitiesBinomialTree.cell
                                ;  _x.cell
                                ;  _index.cell
                                ;  _branch.cell
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
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree_size", Description="Create a EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualProbabilitiesBinomialTree",Description = "Reference to EqualProbabilitiesBinomialTree")>] 
         equalprobabilitiesbinomialtree : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualProbabilitiesBinomialTree = Helper.toCell<EqualProbabilitiesBinomialTree> equalprobabilitiesbinomialtree "EqualProbabilitiesBinomialTree"  
                let _i = Helper.toCell<int> i "i" 
                let builder () = withMnemonic mnemonic ((EqualProbabilitiesBinomialTreeModel.Cast _EqualProbabilitiesBinomialTree.cell).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EqualProbabilitiesBinomialTree.source + ".Size") 
                                               [| _EqualProbabilitiesBinomialTree.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualProbabilitiesBinomialTree.cell
                                ;  _i.cell
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
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree_columns", Description="Create a EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="EqualProbabilitiesBinomialTree",Description = "Reference to EqualProbabilitiesBinomialTree")>] 
         equalprobabilitiesbinomialtree : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _EqualProbabilitiesBinomialTree = Helper.toCell<EqualProbabilitiesBinomialTree> equalprobabilitiesbinomialtree "EqualProbabilitiesBinomialTree"  
                let builder () = withMnemonic mnemonic ((EqualProbabilitiesBinomialTreeModel.Cast _EqualProbabilitiesBinomialTree.cell).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_EqualProbabilitiesBinomialTree.source + ".Columns") 
                                               [| _EqualProbabilitiesBinomialTree.source
                                               |]
                let hash = Helper.hashFold 
                                [| _EqualProbabilitiesBinomialTree.cell
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
    [<ExcelFunction(Name="_EqualProbabilitiesBinomialTree_Range", Description="Create a range of EqualProbabilitiesBinomialTree",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let EqualProbabilitiesBinomialTree_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the EqualProbabilitiesBinomialTree")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<EqualProbabilitiesBinomialTree> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<EqualProbabilitiesBinomialTree>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<EqualProbabilitiesBinomialTree>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<EqualProbabilitiesBinomialTree>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
