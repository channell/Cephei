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
(*!! generic
(* <summary>
  This lattice is based on two trinomial trees and primarily used for the G2 short-rate model.  lattices
  </summary> *)
[<AutoSerializable(true)>]
module TreeLattice2DFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice2D_descendant", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_descendant
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).Descendant
                                                            _i.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".Descendant") 
                                               [| _TreeLattice2D.source
                                               ;  _i.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
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
    [<ExcelFunction(Name="_TreeLattice2D_grid", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).Grid
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".Grid") 
                                               [| _TreeLattice2D.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice2D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice2D_probability", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_probability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="branch",Description = "Reference to branch")>] 
         branch : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let _branch = Helper.toCell<int> branch "branch" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).Probability
                                                            _i.cell 
                                                            _index.cell 
                                                            _branch.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".Probability") 
                                               [| _TreeLattice2D.source
                                               ;  _i.source
                                               ;  _index.source
                                               ;  _branch.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
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
    [<ExcelFunction(Name="_TreeLattice2D_size", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).Size
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".Size") 
                                               [| _TreeLattice2D.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
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
        this is a workaround for CuriouslyRecurringTemplate of TreeLattice recheck it
    *)
    [<ExcelFunction(Name="_TreeLattice2D", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tree1",Description = "Reference to tree1")>] 
         tree1 : obj)
        ([<ExcelArgument(Name="tree2",Description = "Reference to tree2")>] 
         tree2 : obj)
        ([<ExcelArgument(Name="correlation",Description = "Reference to correlation")>] 
         correlation : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tree1 = Helper.toCell<TrinomialTree> tree1 "tree1" 
                let _tree2 = Helper.toCell<TrinomialTree> tree2 "tree2" 
                let _correlation = Helper.toCell<double> correlation "correlation" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TreeLattice2D 
                                                            _tree1.cell 
                                                            _tree2.cell 
                                                            _correlation.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeLattice2D>) l

                let source () = Helper.sourceFold "Fun.TreeLattice2D" 
                                               [| _tree1.source
                                               ;  _tree2.source
                                               ;  _correlation.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tree1.cell
                                ;  _tree2.cell
                                ;  _correlation.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice2D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Lattice interface
    *)
    [<ExcelFunction(Name="_TreeLattice2D_initialize", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).Initialize
                                                            _asset.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : TreeLattice2D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".Initialize") 
                                               [| _TreeLattice2D.source
                                               ;  _asset.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                ;  _asset.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_TreeLattice2D_partialRollback", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).PartialRollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TreeLattice2D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".PartialRollback") 
                                               [| _TreeLattice2D.source
                                               ;  _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                ;  _asset.cell
                                ;  _To.cell
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
        ! Computes the present value of an asset using Arrow-Debrew prices
    *)
    [<ExcelFunction(Name="_TreeLattice2D_presentValue", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).PresentValue
                                                            _asset.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".PresentValue") 
                                               [| _TreeLattice2D.source
                                               ;  _asset.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                ;  _asset.cell
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
    [<ExcelFunction(Name="_TreeLattice2D_rollback", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="asset",Description = "Reference to asset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).Rollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TreeLattice2D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".Rollback") 
                                               [| _TreeLattice2D.source
                                               ;  _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                ;  _asset.cell
                                ;  _To.cell
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
    [<ExcelFunction(Name="_TreeLattice2D_statePrices", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_statePrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).StatePrices
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".StatePrices") 
                                               [| _TreeLattice2D.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice2D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice2D_stepback", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_stepback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="values",Description = "Reference to values")>] 
         values : obj)
        ([<ExcelArgument(Name="newValues",Description = "Reference to newValues")>] 
         newValues : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let _i = Helper.toCell<int> i "i" 
                let _values = Helper.toCell<Vector> values "values" 
                let _newValues = Helper.toCell<Vector> newValues "newValues" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).Stepback
                                                            _i.cell 
                                                            _values.cell 
                                                            _newValues.cell 
                                                       ) :> ICell
                let format (o : TreeLattice2D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".Stepback") 
                                               [| _TreeLattice2D.source
                                               ;  _i.source
                                               ;  _values.source
                                               ;  _newValues.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                ;  _i.cell
                                ;  _values.cell
                                ;  _newValues.cell
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
    [<ExcelFunction(Name="_TreeLattice2D_timeGrid", Description="Create a TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_timeGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice2D",Description = "Reference to TreeLattice2D")>] 
         treelattice2d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice2D = Helper.toCell<TreeLattice2D> treelattice2d "TreeLattice2D"  
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLattice2DModel.Cast _TreeLattice2D.cell).TimeGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source () = Helper.sourceFold (_TreeLattice2D.source + ".TimeGrid") 
                                               [| _TreeLattice2D.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice2D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice2D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TreeLattice2D_Range", Description="Create a range of TreeLattice2D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice2D_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TreeLattice2D")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TreeLattice2D> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TreeLattice2D>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TreeLattice2D>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TreeLattice2D>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
