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
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>
general sparse matrix taken from http://www.blackbeltcoder.com/Articles/algorithms/creating-a-sparse-matrix-in-net and completed for QLNet

  </summary> *)
[<AutoSerializable(true)>]
type SparseMatrixModel
    ( lhs                                          : ICell<SparseMatrix>
    ) as this =

    inherit Model<SparseMatrix> ()
(*
    Parameters
*)
    let _lhs                                       = lhs
(*
    Functions
*)
    let mutable
        _SparseMatrix                              = make (fun () -> new SparseMatrix (lhs.Value))
    let _Clear                                     = triv _SparseMatrix (fun () -> _SparseMatrix.Value.Clear()
                                                                                   _SparseMatrix.Value)
    let _columns                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.columns())
    let _GetAt                                     (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetAt(row.Value, col.Value))
    let _GetColumnData                             (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetColumnData(col.Value))
    let _GetColumnDataCount                        (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetColumnDataCount(col.Value))
    let _GetRowData                                (row : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetRowData(row.Value))
    let _GetRowDataCount                           (row : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetRowDataCount(row.Value))
    let _RemoveAt                                  (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.RemoveAt(row.Value, col.Value)
                                                                                   _SparseMatrix.Value)
    let _rows                                      = triv _SparseMatrix (fun () -> _SparseMatrix.Value.rows())
    let _SetAt                                     (row : ICell<int>) (col : ICell<int>) (value : ICell<double>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.SetAt(row.Value, col.Value, value.Value)
                                                                                   _SparseMatrix.Value)
    let _this                                      (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.[row.Value, col.Value])
    let _values                                    = triv _SparseMatrix (fun () -> _SparseMatrix.Value.values())
    do this.Bind(_SparseMatrix)
(* 
    casting 
*)
    internal new () = new SparseMatrixModel(null)
    member internal this.Inject v = _SparseMatrix <- v
    static member Cast (p : ICell<SparseMatrix>) = 
        if p :? SparseMatrixModel then 
            p :?> SparseMatrixModel
        else
            let o = new SparseMatrixModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.lhs                                = _lhs 
    member this.Clear                              = _Clear
    member this.Columns                            = _columns
    member this.GetAt                              row col   
                                                   = _GetAt row col 
    member this.GetColumnData                      col   
                                                   = _GetColumnData col 
    member this.GetColumnDataCount                 col   
                                                   = _GetColumnDataCount col 
    member this.GetRowData                         row   
                                                   = _GetRowData row 
    member this.GetRowDataCount                    row   
                                                   = _GetRowDataCount row 
    member this.RemoveAt                           row col   
                                                   = _RemoveAt row col 
    member this.Rows                               = _rows
    member this.SetAt                              row col value   
                                                   = _SetAt row col value 
    member this.This                               row col   
                                                   = _this row col 
    member this.Values                             = _values
(* <summary>
general sparse matrix taken from http://www.blackbeltcoder.com/Articles/algorithms/creating-a-sparse-matrix-in-net and completed for QLNet

  </summary> *)
[<AutoSerializable(true)>]
type SparseMatrixModel1
    ( rows                                         : ICell<int>
    , columns                                      : ICell<int>
    ) as this =

    inherit Model<SparseMatrix> ()
(*
    Parameters
*)
    let _rows                                      = rows
    let _columns                                   = columns
(*
    Functions
*)
    let mutable
        _SparseMatrix                              = make (fun () -> new SparseMatrix (rows.Value, columns.Value))
    let _Clear                                     = triv _SparseMatrix (fun () -> _SparseMatrix.Value.Clear()
                                                                                   _SparseMatrix.Value)
    let _columns                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.columns())
    let _GetAt                                     (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetAt(row.Value, col.Value))
    let _GetColumnData                             (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetColumnData(col.Value))
    let _GetColumnDataCount                        (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetColumnDataCount(col.Value))
    let _GetRowData                                (row : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetRowData(row.Value))
    let _GetRowDataCount                           (row : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetRowDataCount(row.Value))
    let _RemoveAt                                  (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.RemoveAt(row.Value, col.Value)
                                                                                   _SparseMatrix.Value)
    let _rows                                      = triv _SparseMatrix (fun () -> _SparseMatrix.Value.rows())
    let _SetAt                                     (row : ICell<int>) (col : ICell<int>) (value : ICell<double>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.SetAt(row.Value, col.Value, value.Value)
                                                                                   _SparseMatrix.Value)
    let _this                                      (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.[row.Value, col.Value])
    let _values                                    = triv _SparseMatrix (fun () -> _SparseMatrix.Value.values())
    do this.Bind(_SparseMatrix)
(* 
    casting 
*)
    internal new () = new SparseMatrixModel1(null,null)
    member internal this.Inject v = _SparseMatrix <- v
    static member Cast (p : ICell<SparseMatrix>) = 
        if p :? SparseMatrixModel1 then 
            p :?> SparseMatrixModel1
        else
            let o = new SparseMatrixModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rows                               = _rows 
    member this.columns                            = _columns 
    member this.Clear                              = _Clear
    member this.Columns                            = _columns
    member this.GetAt                              row col   
                                                   = _GetAt row col 
    member this.GetColumnData                      col   
                                                   = _GetColumnData col 
    member this.GetColumnDataCount                 col   
                                                   = _GetColumnDataCount col 
    member this.GetRowData                         row   
                                                   = _GetRowData row 
    member this.GetRowDataCount                    row   
                                                   = _GetRowDataCount row 
    member this.RemoveAt                           row col   
                                                   = _RemoveAt row col 
    member this.Rows                               = _rows
    member this.SetAt                              row col value   
                                                   = _SetAt row col value 
    member this.This                               row col   
                                                   = _this row col 
    member this.Values                             = _values
(* <summary>
general sparse matrix taken from http://www.blackbeltcoder.com/Articles/algorithms/creating-a-sparse-matrix-in-net and completed for QLNet

  </summary> *)
[<AutoSerializable(true)>]
type SparseMatrixModel2
    () as this =
    inherit Model<SparseMatrix> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _SparseMatrix                              = make (fun () -> new SparseMatrix ())
    let _Clear                                     = triv _SparseMatrix (fun () -> _SparseMatrix.Value.Clear()
                                                                                   _SparseMatrix.Value)
    let _columns                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.columns())
    let _GetAt                                     (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetAt(row.Value, col.Value))
    let _GetColumnData                             (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetColumnData(col.Value))
    let _GetColumnDataCount                        (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetColumnDataCount(col.Value))
    let _GetRowData                                (row : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetRowData(row.Value))
    let _GetRowDataCount                           (row : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.GetRowDataCount(row.Value))
    let _RemoveAt                                  (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.RemoveAt(row.Value, col.Value)
                                                                                   _SparseMatrix.Value)
    let _rows                                      = triv _SparseMatrix (fun () -> _SparseMatrix.Value.rows())
    let _SetAt                                     (row : ICell<int>) (col : ICell<int>) (value : ICell<double>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.SetAt(row.Value, col.Value, value.Value)
                                                                                   _SparseMatrix.Value)
    let _this                                      (row : ICell<int>) (col : ICell<int>)   
                                                   = triv _SparseMatrix (fun () -> _SparseMatrix.Value.[row.Value, col.Value])
    let _values                                    = triv _SparseMatrix (fun () -> _SparseMatrix.Value.values())
    do this.Bind(_SparseMatrix)
(* 
    casting 
*)
    
    member internal this.Inject v = _SparseMatrix <- v
    static member Cast (p : ICell<SparseMatrix>) = 
        if p :? SparseMatrixModel2 then 
            p :?> SparseMatrixModel2
        else
            let o = new SparseMatrixModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Clear                              = _Clear
    member this.Columns                            = _columns
    member this.GetAt                              row col   
                                                   = _GetAt row col 
    member this.GetColumnData                      col   
                                                   = _GetColumnData col 
    member this.GetColumnDataCount                 col   
                                                   = _GetColumnDataCount col 
    member this.GetRowData                         row   
                                                   = _GetRowData row 
    member this.GetRowDataCount                    row   
                                                   = _GetRowDataCount row 
    member this.RemoveAt                           row col   
                                                   = _RemoveAt row col 
    member this.Rows                               = _rows
    member this.SetAt                              row col value   
                                                   = _SetAt row col value 
    member this.This                               row col   
                                                   = _this row col 
    member this.Values                             = _values
