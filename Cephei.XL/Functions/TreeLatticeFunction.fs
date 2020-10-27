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

  </summary> *)
[<AutoSerializable(true)>]
module TreeLatticeFunction =

    (*
        Lattice interface
    *)
    [<ExcelFunction(Name="_TreeLattice_initialize", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_initialize
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).Initialize
                                                            _asset.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : TreeLattice) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice.source + ".Initialize") 

                                               [| _asset.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
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
    [<ExcelFunction(Name="_TreeLattice_partialRollback", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_partialRollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).PartialRollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TreeLattice) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice.source + ".PartialRollback") 

                                               [| _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
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
    [<ExcelFunction(Name="_TreeLattice_presentValue", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_presentValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).PresentValue
                                                            _asset.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TreeLattice.source + ".PresentValue") 

                                               [| _asset.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
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
    [<ExcelFunction(Name="_TreeLattice_rollback", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_rollback
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        ([<ExcelArgument(Name="asset",Description = "DiscretizedAsset")>] 
         asset : obj)
        ([<ExcelArgument(Name="To",Description = "double")>] 
         To : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let _asset = Helper.toCell<DiscretizedAsset> asset "asset" 
                let _To = Helper.toCell<double> To "To" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).Rollback
                                                            _asset.cell 
                                                            _To.cell 
                                                       ) :> ICell
                let format (o : TreeLattice) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice.source + ".Rollback") 

                                               [| _asset.source
                                               ;  _To.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
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
    [<ExcelFunction(Name="_TreeLattice_statePrices", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_statePrices
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).StatePrices
                                                            _i.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TreeLattice.source + ".StatePrices") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
                                ;  _i.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice_stepback", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_stepback
        ([<ExcelArgument(Name="Mnemonic",Description = "TreeLattice")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="values",Description = "Vector")>] 
         values : obj)
        ([<ExcelArgument(Name="newValues",Description = "Vector")>] 
         newValues : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let _i = Helper.toCell<int> i "i" 
                let _values = Helper.toCell<Vector> values "values" 
                let _newValues = Helper.toCell<Vector> newValues "newValues" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).Stepback
                                                            _i.cell 
                                                            _values.cell 
                                                            _newValues.cell 
                                                       ) :> ICell
                let format (o : TreeLattice) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_TreeLattice.source + ".Stepback") 

                                               [| _i.source
                                               ;  _values.source
                                               ;  _newValues.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
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
    [<ExcelFunction(Name="_TreeLattice", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_create
        ([<ExcelArgument(Name="Mnemonic",Description = "TreeLattice")>] 
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
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TreeLattice 
                                                            _timeGrid.cell 
                                                            _n.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TreeLattice>) l

                let source () = Helper.sourceFold "Fun.TreeLattice" 
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
                    ; subscriber = Helper.subscriberModel<TreeLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        this is a smell, but we need it. We'll rethink it later.
    *)
    [<ExcelFunction(Name="_TreeLattice_grid", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Vector")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        ([<ExcelArgument(Name="t",Description = "double")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let _t = Helper.toCell<double> t "t" 
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).Grid
                                                            _t.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TreeLattice.source + ".Grid") 

                                               [| _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
                                ;  _t.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TreeLattice_timeGrid", Description="Create a TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_timeGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "TimeGrid")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TreeLattice",Description = "TreeLattice")>] 
         treelattice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TreeLattice = Helper.toCell<TreeLattice> treelattice "TreeLattice"  
                let builder (current : ICell) = withMnemonic mnemonic ((TreeLatticeModel.Cast _TreeLattice.cell).TimeGrid
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TimeGrid>) l

                let source () = Helper.sourceFold (_TreeLattice.source + ".TimeGrid") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _TreeLattice.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TreeLattice> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TreeLattice_Range", Description="Create a range of TreeLattice",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TreeLattice_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Helper.Range.fromModelList")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Helper.Range.fromModelList")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TreeLattice> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TreeLattice>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TreeLattice>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TreeLattice>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
