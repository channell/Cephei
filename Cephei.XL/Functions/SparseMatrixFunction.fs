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
general sparse matrix taken from http://www.blackbeltcoder.com/Articles/algorithms/creating-a-sparse-matrix-in-net and completed for QLNet
  </summary> *)
[<AutoSerializable(true)>]
module SparseMatrixFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SparseMatrix_Clear", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_Clear
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).Clear
                                                       ) :> ICell
                let format (o : SparseMatrix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".Clear") 
                                               [| _SparseMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
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
    [<ExcelFunction(Name="_SparseMatrix_columns", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".Columns") 
                                               [| _SparseMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
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
    [<ExcelFunction(Name="_SparseMatrix_GetAt", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_GetAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="row",Description = "Reference to row")>] 
         row : obj)
        ([<ExcelArgument(Name="col",Description = "Reference to col")>] 
         col : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _row = Helper.toCell<int> row "row" 
                let _col = Helper.toCell<int> col "col" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).GetAt
                                                            _row.cell 
                                                            _col.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".GetAt") 
                                               [| _SparseMatrix.source
                                               ;  _row.source
                                               ;  _col.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _row.cell
                                ;  _col.cell
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
    [<ExcelFunction(Name="_SparseMatrix_GetColumnData", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_GetColumnData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="col",Description = "Reference to col")>] 
         col : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _col = Helper.toCell<int> col "col" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).GetColumnData
                                                            _col.cell 
                                                       ) :> ICell
                let format (o : Generic.IEnumerable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".GetColumnData") 
                                               [| _SparseMatrix.source
                                               ;  _col.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _col.cell
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
    [<ExcelFunction(Name="_SparseMatrix_GetColumnDataCount", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_GetColumnDataCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="col",Description = "Reference to col")>] 
         col : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _col = Helper.toCell<int> col "col" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).GetColumnDataCount
                                                            _col.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".GetColumnDataCount") 
                                               [| _SparseMatrix.source
                                               ;  _col.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _col.cell
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
    [<ExcelFunction(Name="_SparseMatrix_GetRowData", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_GetRowData
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="row",Description = "Reference to row")>] 
         row : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _row = Helper.toCell<int> row "row" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).GetRowData
                                                            _row.cell 
                                                       ) :> ICell
                let format (o : Generic.IEnumerable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".GetRowData") 
                                               [| _SparseMatrix.source
                                               ;  _row.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _row.cell
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
    [<ExcelFunction(Name="_SparseMatrix_GetRowDataCount", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_GetRowDataCount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="row",Description = "Reference to row")>] 
         row : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _row = Helper.toCell<int> row "row" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).GetRowDataCount
                                                            _row.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".GetRowDataCount") 
                                               [| _SparseMatrix.source
                                               ;  _row.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _row.cell
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
    [<ExcelFunction(Name="_SparseMatrix_RemoveAt", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_RemoveAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="row",Description = "Reference to row")>] 
         row : obj)
        ([<ExcelArgument(Name="col",Description = "Reference to col")>] 
         col : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _row = Helper.toCell<int> row "row" 
                let _col = Helper.toCell<int> col "col" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).RemoveAt
                                                            _row.cell 
                                                            _col.cell 
                                                       ) :> ICell
                let format (o : SparseMatrix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".RemoveAt") 
                                               [| _SparseMatrix.source
                                               ;  _row.source
                                               ;  _col.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _row.cell
                                ;  _col.cell
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
    [<ExcelFunction(Name="_SparseMatrix_rows", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_rows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).Rows
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".Rows") 
                                               [| _SparseMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
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
    [<ExcelFunction(Name="_SparseMatrix_SetAt", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_SetAt
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="row",Description = "Reference to row")>] 
         row : obj)
        ([<ExcelArgument(Name="col",Description = "Reference to col")>] 
         col : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _row = Helper.toCell<int> row "row" 
                let _col = Helper.toCell<int> col "col" 
                let _value = Helper.toCell<double> value "value" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).SetAt
                                                            _row.cell 
                                                            _col.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : SparseMatrix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".SetAt") 
                                               [| _SparseMatrix.source
                                               ;  _row.source
                                               ;  _col.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _row.cell
                                ;  _col.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_SparseMatrix1", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rows",Description = "Reference to rows")>] 
         rows : obj)
        ([<ExcelArgument(Name="columns",Description = "Reference to columns")>] 
         columns : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rows = Helper.toCell<int> rows "rows" 
                let _columns = Helper.toCell<int> columns "columns" 
                let builder () = withMnemonic mnemonic (Fun.SparseMatrix1 
                                                            _rows.cell 
                                                            _columns.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source = Helper.sourceFold "Fun.SparseMatrix1" 
                                               [| _rows.source
                                               ;  _columns.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rows.cell
                                ;  _columns.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SparseMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SparseMatrix2", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.SparseMatrix2 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source = Helper.sourceFold "Fun.SparseMatrix2" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SparseMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SparseMatrix", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="lhs",Description = "Reference to lhs")>] 
         lhs : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _lhs = Helper.toCell<SparseMatrix> lhs "lhs" 
                let builder () = withMnemonic mnemonic (Fun.SparseMatrix
                                                            _lhs.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SparseMatrix>) l

                let source = Helper.sourceFold "Fun.SparseMatrix" 
                                               [| _lhs.source
                                               |]
                let hash = Helper.hashFold 
                                [| _lhs.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SparseMatrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SparseMatrix_this", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        ([<ExcelArgument(Name="row",Description = "Reference to row")>] 
         row : obj)
        ([<ExcelArgument(Name="col",Description = "Reference to col")>] 
         col : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let _row = Helper.toCell<int> row "row" 
                let _col = Helper.toCell<int> col "col" 
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).This
                                                            _row.cell 
                                                            _col.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".This") 
                                               [| _SparseMatrix.source
                                               ;  _row.source
                                               ;  _col.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
                                ;  _row.cell
                                ;  _col.cell
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
    [<ExcelFunction(Name="_SparseMatrix_values", Description="Create a SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_values
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SparseMatrix",Description = "Reference to SparseMatrix")>] 
         sparsematrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SparseMatrix = Helper.toCell<SparseMatrix> sparsematrix "SparseMatrix"  
                let builder () = withMnemonic mnemonic ((_SparseMatrix.cell :?> SparseMatrixModel).Values
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SparseMatrix.source + ".Values") 
                                               [| _SparseMatrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SparseMatrix.cell
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
    [<ExcelFunction(Name="_SparseMatrix_Range", Description="Create a range of SparseMatrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SparseMatrix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SparseMatrix")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SparseMatrix> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SparseMatrix>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SparseMatrix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SparseMatrix>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
