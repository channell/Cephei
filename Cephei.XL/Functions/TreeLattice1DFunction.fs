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
  One-dimensional tree-based lattice.
  </summary> *)
[<AutoSerializable(true)>]
module TreeLattice1DFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice1D_grid", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).Grid
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".Grid") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice1D", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="timeGrid",Description = "TimeGrid")>] 
         timeGrid : obj)
        ([<ExcelArgument(Name="n",Description = "int")>] 
         n : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _timeGrid = Helper.toCell<TimeGrid> timeGrid "timeGrid" 
                let _n = Helper.toCell<int> n "n" 
                let builder (current : ICell) = (Fun.TreeLattice1D 
                                                            _timeGrid.cell 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeLattice1D>) l

                let source () = Helper.sourceFold "Fun.TreeLattice1D" 
                                               [| _timeGrid.source
                                               ;  _n.source
                                               |]
                let hash = Helper.hashFold 
                                [| _timeGrid.cell
                                ;  _n.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice1D_underlying", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_underlying
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="index",Description = "int")>] 
         index : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _i = Helper.toCell<int> i "i" 
                let _index = Helper.toCell<int> index "index" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).Underlying
                                                            _i.cell 
                                                            _index.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".Underlying") 

                                               [| _i.source
                                               ;  _index.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
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
        Lattice interface
    *)
    [<ExcelFunction(Name="_TreeLattice1D_initialize", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).Initialize
                                                            _asset.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : TreeLattice1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".Initialize") 

                                               [| _asset.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
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
    [<ExcelFunction(Name="_TreeLattice1D_partialRollback", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).PartialRollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TreeLattice1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".PartialRollback") 

                                               [| _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
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
    [<ExcelFunction(Name="_TreeLattice1D_presentValue", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).PresentValue
                                                            _asset.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".PresentValue") 

                                               [| _asset.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
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
    [<ExcelFunction(Name="_TreeLattice1D_rollback", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).Rollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TreeLattice1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".Rollback") 

                                               [| _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
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
    [<ExcelFunction(Name="_TreeLattice1D_statePrices", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_statePrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).StatePrices
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".StatePrices") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice1D_stepback", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_stepback
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="values",Description = "Vector")>] 
         values : obj)
        ([<ExcelArgument(Name="newValues",Description = "Vector")>] 
         newValues : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let _i = Helper.toCell<int> i "i" 
                let _values = Helper.toCell<Vector> values "values" 
                let _newValues = Helper.toCell<Vector> newValues "newValues" 
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).Stepback
                                                            _i.cell 
                                                            _values.cell 
                                                            _newValues.cell 
                                                       ) :> ICell
                let format (o : TreeLattice1D) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".Stepback") 

                                               [| _i.source
                                               ;  _values.source
                                               ;  _newValues.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
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
    [<ExcelFunction(Name="_TreeLattice1D_timeGrid", Description="Create a TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_timeGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice1D",Description = "TreeLattice1D")>] 
         treelattice1d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice1D = Helper.toModelReference<TreeLattice1D> treelattice1d "TreeLattice1D"  
                let builder (current : ICell) = ((TreeLattice1DModel.Cast _TreeLattice1D.cell).TimeGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source () = Helper.sourceFold (_TreeLattice1D.source + ".TimeGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TreeLattice1D.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice1D> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TreeLattice1D_Range", Description="Create a range of TreeLattice1D",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice1D_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TreeLattice1D> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<TreeLattice1D> (c)) :> ICell
                let format (i : Cephei.Cell.List<TreeLattice1D>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<TreeLattice1D>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
