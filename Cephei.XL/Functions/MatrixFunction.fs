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
    [<ExcelFunction(Name="_Matrix_column", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_column
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _c = Helper.toCell<int> c "c" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Column
                                                            _c.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Matrix.source + ".Column") 
                                               [| _Matrix.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _c.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_columns", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_columns
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Columns
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Matrix.source + ".Columns") 
                                               [| _Matrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_diagonal", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_diagonal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Diagonal
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Matrix.source + ".Diagonal") 
                                               [| _Matrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_empty", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Matrix.source + ".Empty") 
                                               [| _Matrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_fill", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_fill
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _value = Helper.toCell<double> value "value" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Fill
                                                            _value.cell 
                                                       ) :> ICell
                let format (o : Matrix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Matrix.source + ".Fill") 
                                               [| _Matrix.source
                                               ;  _value.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_GetRange", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_GetRange
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="start",Description = "Reference to start")>] 
         start : obj)
        ([<ExcelArgument(Name="length",Description = "Reference to length")>] 
         length : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _start = Helper.toCell<int> start "start" true
                let _length = Helper.toCell<int> length "length" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).GetRange
                                                            _start.cell 
                                                            _length.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Matrix.source + ".GetRange") 
                                               [| _Matrix.source
                                               ;  _start.source
                                               ;  _length.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _start.cell
                                ;  _length.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix2", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _from = Helper.toCell<Matrix> from "from" true
                let builder () = withMnemonic mnemonic (Fun.Matrix2
                                                            _from.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold "Fun.Matrix2" 
                                               [| _from.source
                                               |]
                let hash = Helper.hashFold 
                                [| _from.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_Matrix", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rows",Description = "Reference to rows")>] 
         rows : obj)
        ([<ExcelArgument(Name="columns",Description = "Reference to columns")>] 
         columns : obj)
        ([<ExcelArgument(Name="value",Description = "Reference to value")>] 
         value : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rows = Helper.toCell<int> rows "rows" true
                let _columns = Helper.toCell<int> columns "columns" true
                let _value = Helper.toCell<double> value "value" true
                let builder () = withMnemonic mnemonic (Fun.Matrix
                                                            _rows.cell 
                                                            _columns.cell 
                                                            _value.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold "Fun.Matrix" 
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
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_Matrix1", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="rows",Description = "Reference to rows")>] 
         rows : obj)
        ([<ExcelArgument(Name="columns",Description = "Reference to columns")>] 
         columns : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _rows = Helper.toCell<int> rows "rows" true
                let _columns = Helper.toCell<int> columns "columns" true
                let builder () = withMnemonic mnemonic (Fun.Matrix1
                                                            _rows.cell 
                                                            _columns.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold "Fun.Matrix1" 
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
                    ; subscriber = Helper.subscriberModel format
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
    [<ExcelFunction(Name="_Matrix3", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Matrix3 ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold "Fun.Matrix3" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_row", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_row
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="r",Description = "Reference to r")>] 
         r : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _r = Helper.toCell<int> r "r" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Row
                                                            _r.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_Matrix.source + ".Row") 
                                               [| _Matrix.source
                                               ;  _r.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _r.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Matrix_rows", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_rows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Rows
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Matrix.source + ".Rows") 
                                               [| _Matrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_swap", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_swap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="i1",Description = "Reference to i1")>] 
         i1 : obj)
        ([<ExcelArgument(Name="j1",Description = "Reference to j1")>] 
         j1 : obj)
        ([<ExcelArgument(Name="i2",Description = "Reference to i2")>] 
         i2 : obj)
        ([<ExcelArgument(Name="j2",Description = "Reference to j2")>] 
         j2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _i1 = Helper.toCell<int> i1 "i1" true
                let _j1 = Helper.toCell<int> j1 "j1" true
                let _i2 = Helper.toCell<int> i2 "i2" true
                let _j2 = Helper.toCell<int> j2 "j2" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).Swap
                                                            _i1.cell 
                                                            _j1.cell 
                                                            _i2.cell 
                                                            _j2.cell 
                                                       ) :> ICell
                let format (o : Matrix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Matrix.source + ".Swap") 
                                               [| _Matrix.source
                                               ;  _i1.source
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
    [<ExcelFunction(Name="_Matrix_swapRow", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_swapRow
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="r1",Description = "Reference to r1")>] 
         r1 : obj)
        ([<ExcelArgument(Name="r2",Description = "Reference to r2")>] 
         r2 : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _r1 = Helper.toCell<int> r1 "r1" true
                let _r2 = Helper.toCell<int> r2 "r2" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).SwapRow
                                                            _r1.cell 
                                                            _r2.cell 
                                                       ) :> ICell
                let format (o : Matrix) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Matrix.source + ".SwapRow") 
                                               [| _Matrix.source
                                               ;  _r1.source
                                               ;  _r2.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _r1.cell
                                ;  _r2.cell
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
    [<ExcelFunction(Name="_Matrix_this", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_this
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _i = Helper.toCell<int> i "i" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).This
                                                            _i.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Matrix.source + ".This") 
                                               [| _Matrix.source
                                               ;  _i.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_this1", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_this1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        ([<ExcelArgument(Name="i",Description = "Reference to i")>] 
         i : obj)
        ([<ExcelArgument(Name="j",Description = "Reference to j")>] 
         j : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let _i = Helper.toCell<int> i "i" true
                let _j = Helper.toCell<int> j "j" true
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).This1
                                                            _i.cell 
                                                            _j.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Matrix.source + ".This1") 
                                               [| _Matrix.source
                                               ;  _i.source
                                               ;  _j.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
                                ;  _i.cell
                                ;  _j.cell
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
    [<ExcelFunction(Name="_Matrix_ToString", Description="Create a Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Matrix",Description = "Reference to Matrix")>] 
         matrix : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Matrix = Helper.toCell<Matrix> matrix "Matrix" true 
                let builder () = withMnemonic mnemonic ((_Matrix.cell :?> MatrixModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Matrix.source + ".ToString") 
                                               [| _Matrix.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Matrix.cell
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
    [<ExcelFunction(Name="_Matrix_Range", Description="Create a range of Matrix",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Matrix_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Matrix")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Matrix> i "value" true) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Matrix>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Matrix>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Matrix>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
