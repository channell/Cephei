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
  This class implements the concept of Matrix as used in linear algebra. As such, it is <b>not</b> meant to be used as a container.
  </summary> *)
[<AutoSerializable(true)>]
module MatrixFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_column", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_column
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="c",Description = "int")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _c = Helper.toCell<int> c "c" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Column
                                                            _c.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Matrix.source + ".Column") 

                                               [| _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _c.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_columns", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".Columns") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_diagonal", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Matrix.source + ".Diagonal") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_empty", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".Empty") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_fill", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_fill
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Fill
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : Matrix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".Fill") 

                                               [| _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _value.cell
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
    [<ExcelFunction(Name="_Matrix_GetRange", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_GetRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="start",Description = "int")>] 
         start : obj)
        ([<ExcelArgument(Name="length",Description = "int")>] 
         length : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _start = Helper.toCell<int> start "start" 
                let _length = Helper.toCell<int> length "length" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).GetRange
                                                            _start.cell 
                                                            _length.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Matrix.source + ".GetRange") 

                                               [| _start.source
                                               ;  _length.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _start.cell
                                ;  _length.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix2", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="from",Description = "Matrix")>] 
         from : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _from = Helper.toCell<Matrix> from "from" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Matrix2
                                                            _from.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold "Fun.Matrix2" 
                                               [| _from.source
                                               |]
                let hash = Helper.hashFold 
                                [| _from.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! creates the matrix and fills it with <tt>value</tt>
    *)
    [<ExcelFunction(Name="_Matrix", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rows",Description = "int")>] 
         rows : obj)
        ([<ExcelArgument(Name="columns",Description = "int")>] 
         columns : obj)
        ([<ExcelArgument(Name="value",Description = "double")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rows = Helper.toCell<int> rows "rows" 
                let _columns = Helper.toCell<int> columns "columns" 
                let _value = Helper.toCell<double> value "value" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Matrix
                                                            _rows.cell 
                                                            _columns.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold "Fun.Matrix" 
                                               [| _rows.source
                                               ;  _columns.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rows.cell
                                ;  _columns.cell
                                ;  _value.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! creates a matrix with the given dimensions
    *)
    [<ExcelFunction(Name="_Matrix1", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rows",Description = "int")>] 
         rows : obj)
        ([<ExcelArgument(Name="columns",Description = "int")>] 
         columns : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rows = Helper.toCell<int> rows "rows" 
                let _columns = Helper.toCell<int> columns "columns" 
                let builder (current : ICell) = withMnemonic mnemonic (Fun.Matrix1
                                                            _rows.cell 
                                                            _columns.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold "Fun.Matrix1" 
                                               [| _rows.source
                                               ;  _columns.source
                                               |]
                let hash = Helper.hashFold 
                                [| _rows.cell
                                ;  _columns.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! creates an empty matrix
    *)
    [<ExcelFunction(Name="_Matrix3", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder (current : ICell) = withMnemonic mnemonic (Fun.Matrix3 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source () = Helper.sourceFold "Fun.Matrix3" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_row", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_row
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="r",Description = "int")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _r = Helper.toCell<int> r "r" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Row
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source () = Helper.sourceFold (_Matrix.source + ".Row") 

                                               [| _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Matrix> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_rows", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_rows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Rows
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".Rows") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_swap", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="i1",Description = "int")>] 
         i1 : obj)
        ([<ExcelArgument(Name="j1",Description = "int")>] 
         j1 : obj)
        ([<ExcelArgument(Name="i2",Description = "int")>] 
         i2 : obj)
        ([<ExcelArgument(Name="j2",Description = "int")>] 
         j2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _i1 = Helper.toCell<int> i1 "i1" 
                let _j1 = Helper.toCell<int> j1 "j1" 
                let _i2 = Helper.toCell<int> i2 "i2" 
                let _j2 = Helper.toCell<int> j2 "j2" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).Swap
                                                            _i1.cell 
                                                            _j1.cell 
                                                            _i2.cell 
                                                            _j2.cell 
                                                       ) :> ICell
                let format (o : Matrix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".Swap") 

                                               [| _i1.source
                                               ;  _j1.source
                                               ;  _i2.source
                                               ;  _j2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _i1.cell
                                ;  _j1.cell
                                ;  _i2.cell
                                ;  _j2.cell
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
    [<ExcelFunction(Name="_Matrix_swapRow", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_swapRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="r1",Description = "int")>] 
         r1 : obj)
        ([<ExcelArgument(Name="r2",Description = "int")>] 
         r2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _r1 = Helper.toCell<int> r1 "r1" 
                let _r2 = Helper.toCell<int> r2 "r2" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).SwapRow
                                                            _r1.cell 
                                                            _r2.cell 
                                                       ) :> ICell
                let format (o : Matrix) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".SwapRow") 

                                               [| _r1.source
                                               ;  _r2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _r1.cell
                                ;  _r2.cell
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
    [<ExcelFunction(Name="_Matrix_this", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _i = Helper.toCell<int> i "i" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).This
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".This") 

                                               [| _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_this1", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_this1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="i",Description = "int")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "int")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let _i = Helper.toCell<int> i "i" 
                let _j = Helper.toCell<int> j "j" 
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).This1
                                                            _i.cell 
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".This1") 

                                               [| _i.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _i.cell
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
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_ToString", Description="Create a Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix"  
                let builder (current : ICell) = withMnemonic mnemonic ((MatrixModel.Cast _Matrix.cell).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source () = Helper.sourceFold (_Matrix.source + ".ToString") 

                                               [||]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_Range", Description="Create a range of Matrix",Category="Cephei", IsThreadSafe = false, IsExceptionSafe=true)>]
    let Matrix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifier for Cell")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Matrix> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)

                let s = a |> Array.map (fun i -> i.source)
                let builder (current : ICell) = (new Cephei.Cell.List<Matrix> (c)) :> ICell
                let format (i : Cephei.Cell.List<Matrix>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = Model.formatMnemonic mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source =  (fun () -> "(new Cephei.Cell.List<Matrix>(" + (Helper.sourceFoldArray (s) + "))"))
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
