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
  This package encapuslates an array of grid points.  It is used primarily in PDE calculations.
  </summary> *)
[<AutoSerializable(true)>]
module TransformedGridFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_TransformedGrid_dx", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_dx
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).Dx
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TransformedGrid.source + ".Dx") 
                                               [| _TransformedGrid.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
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
    [<ExcelFunction(Name="_TransformedGrid_dxArray", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_dxArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).DxArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TransformedGrid.source + ".DxArray") 
                                               [| _TransformedGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TransformedGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TransformedGrid_dxm", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_dxm
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).Dxm
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TransformedGrid.source + ".Dxm") 
                                               [| _TransformedGrid.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
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
    [<ExcelFunction(Name="_TransformedGrid_dxmArray", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_dxmArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).DxmArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TransformedGrid.source + ".DxmArray") 
                                               [| _TransformedGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TransformedGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TransformedGrid_dxp", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_dxp
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).Dxp
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TransformedGrid.source + ".Dxp") 
                                               [| _TransformedGrid.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
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
    [<ExcelFunction(Name="_TransformedGrid_dxpArray", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_dxpArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).DxpArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TransformedGrid.source + ".DxpArray") 
                                               [| _TransformedGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TransformedGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TransformedGrid_grid", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_grid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).Grid
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TransformedGrid.source + ".Grid") 
                                               [| _TransformedGrid.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
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
    [<ExcelFunction(Name="_TransformedGrid_gridArray", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_gridArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).GridArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TransformedGrid.source + ".GridArray") 
                                               [| _TransformedGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TransformedGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TransformedGrid_size", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_size
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).Size
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TransformedGrid.source + ".Size") 
                                               [| _TransformedGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
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
    [<ExcelFunction(Name="_TransformedGrid_transformedGrid", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_transformedGrid
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).TransformedGrid
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_TransformedGrid.source + ".TransformedGrid") 
                                               [| _TransformedGrid.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
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
    [<ExcelFunction(Name="_TransformedGrid1", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        ([<ExcelArgument(Name="func",Description = "Reference to func")>] 
         func : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let _func = Helper.toCell<Func<double,double>> func "func" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TransformedGrid1 
                                                            _grid.cell 
                                                            _func.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TransformedGrid>) l

                let source () = Helper.sourceFold "Fun.TransformedGrid1" 
                                               [| _grid.source
                                               ;  _func.source
                                               |]
                let hash = Helper.hashFold 
                                [| _grid.cell
                                ;  _func.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TransformedGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TransformedGrid", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="grid",Description = "Reference to grid")>] 
         grid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _grid = Helper.toCell<Vector> grid "grid" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.TransformedGrid
                                                            _grid.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<TransformedGrid>) l

                let source () = Helper.sourceFold "Fun.TransformedGrid" 
                                               [| _grid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _grid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TransformedGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_TransformedGrid_transformedGridArray", Description="Create a TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_transformedGridArray
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="TransformedGrid",Description = "Reference to TransformedGrid")>] 
         transformedgrid : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _TransformedGrid = Helper.toCell<TransformedGrid> transformedgrid "TransformedGrid"  
                let builder (current : ICell) = withMnemonic mnemonic ((TransformedGridModel.Cast _TransformedGrid.cell).TransformedGridArray
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_TransformedGrid.source + ".TransformedGridArray") 
                                               [| _TransformedGrid.source
                                               |]
                let hash = Helper.hashFold 
                                [| _TransformedGrid.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<TransformedGrid> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_TransformedGrid_Range", Description="Create a range of TransformedGrid",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let TransformedGrid_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the TransformedGrid")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<TransformedGrid> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<TransformedGrid>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = Util.value l :> ICell
                let format (i : Generic.List<ICell<TransformedGrid>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "cell Generic.List<TransformedGrid>(" + (Helper.sourceFoldArray (s) + ")"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
