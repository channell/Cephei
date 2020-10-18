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
  This class implements the concept of Matrix as used in linear algebra. As such, it is <b>not</b> meant to be used as a container.
! creates the matrix and fills it with <tt>value</tt>
  </summary> *)
[<AutoSerializable(true)>]
type MatrixModel
    ( rows                                         : ICell<int>
    , columns                                      : ICell<int>
    , value                                        : ICell<double>
    ) as this =

    inherit Model<Matrix> ()
(*
    Parameters
*)
    let _rows                                      = rows
    let _columns                                   = columns
    let _value                                     = value
(*
    Functions
*)
    let mutable
        _Matrix                                    = cell (fun () -> new Matrix (rows.Value, columns.Value, value.Value))
    let _column                                    (c : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.column(c.Value))
    let _columns                                   = triv (fun () -> _Matrix.Value.columns())
    let _diagonal                                  = triv (fun () -> _Matrix.Value.diagonal())
    let _empty                                     = triv (fun () -> _Matrix.Value.empty())
    let _fill                                      (value : ICell<double>)   
                                                   = triv (fun () -> _Matrix.Value.fill(value.Value)
                                                                     _Matrix.Value)
    let _GetRange                                  (start : ICell<int>) (length : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.GetRange(start.Value, length.Value))
    let _row                                       (r : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.row(r.Value))
    let _rows                                      = triv (fun () -> _Matrix.Value.rows())
    let _swap                                      (i1 : ICell<int>) (j1 : ICell<int>) (i2 : ICell<int>) (j2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swap(i1.Value, j1.Value, i2.Value, j2.Value)
                                                                     _Matrix.Value)
    let _swapRow                                   (r1 : ICell<int>) (r2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swapRow(r1.Value, r2.Value)
                                                                     _Matrix.Value)
    let _this                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value])
    let _this1                                     (i : ICell<int>) (j : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value, j.Value])
    let _ToString                                  = triv (fun () -> _Matrix.Value.ToString())
    do this.Bind(_Matrix)
(* 
    casting 
*)
    internal new () = new MatrixModel(null,null,null)
    member internal this.Inject v = _Matrix <- v
    static member Cast (p : ICell<Matrix>) = 
        if p :? MatrixModel then 
            p :?> MatrixModel
        else
            let o = new MatrixModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rows                               = _rows 
    member this.columns                            = _columns 
    member this.value                              = _value 
    member this.Column                             c   
                                                   = _column c 
    member this.Columns                            = _columns
    member this.Diagonal                           = _diagonal
    member this.Empty                              = _empty
    member this.Fill                               value   
                                                   = _fill value 
    member this.GetRange                           start length   
                                                   = _GetRange start length 
    member this.Row                                r   
                                                   = _row r 
    member this.Rows                               = _rows
    member this.Swap                               i1 j1 i2 j2   
                                                   = _swap i1 j1 i2 j2 
    member this.SwapRow                            r1 r2   
                                                   = _swapRow r1 r2 
    member this.This                               i   
                                                   = _this i 
    member this.This1                              i j   
                                                   = _this1 i j 
    member this.ToString                           = _ToString
(* <summary>
  This class implements the concept of Matrix as used in linear algebra. As such, it is <b>not</b> meant to be used as a container.
! creates a matrix with the given dimensions
  </summary> *)
[<AutoSerializable(true)>]
type MatrixModel1
    ( rows                                         : ICell<int>
    , columns                                      : ICell<int>
    ) as this =

    inherit Model<Matrix> ()
(*
    Parameters
*)
    let _rows                                      = rows
    let _columns                                   = columns
(*
    Functions
*)
    let mutable
        _Matrix                                    = cell (fun () -> new Matrix (rows.Value, columns.Value))
    let _column                                    (c : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.column(c.Value))
    let _columns                                   = triv (fun () -> _Matrix.Value.columns())
    let _diagonal                                  = triv (fun () -> _Matrix.Value.diagonal())
    let _empty                                     = triv (fun () -> _Matrix.Value.empty())
    let _fill                                      (value : ICell<double>)   
                                                   = triv (fun () -> _Matrix.Value.fill(value.Value)
                                                                     _Matrix.Value)
    let _GetRange                                  (start : ICell<int>) (length : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.GetRange(start.Value, length.Value))
    let _row                                       (r : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.row(r.Value))
    let _rows                                      = triv (fun () -> _Matrix.Value.rows())
    let _swap                                      (i1 : ICell<int>) (j1 : ICell<int>) (i2 : ICell<int>) (j2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swap(i1.Value, j1.Value, i2.Value, j2.Value)
                                                                     _Matrix.Value)
    let _swapRow                                   (r1 : ICell<int>) (r2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swapRow(r1.Value, r2.Value)
                                                                     _Matrix.Value)
    let _this                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value])
    let _this1                                     (i : ICell<int>) (j : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value, j.Value])
    let _ToString                                  = triv (fun () -> _Matrix.Value.ToString())
    do this.Bind(_Matrix)
(* 
    casting 
*)
    internal new () = new MatrixModel1(null,null)
    member internal this.Inject v = _Matrix <- v
    static member Cast (p : ICell<Matrix>) = 
        if p :? MatrixModel1 then 
            p :?> MatrixModel1
        else
            let o = new MatrixModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.rows                               = _rows 
    member this.columns                            = _columns 
    member this.Column                             c   
                                                   = _column c 
    member this.Columns                            = _columns
    member this.Diagonal                           = _diagonal
    member this.Empty                              = _empty
    member this.Fill                               value   
                                                   = _fill value 
    member this.GetRange                           start length   
                                                   = _GetRange start length 
    member this.Row                                r   
                                                   = _row r 
    member this.Rows                               = _rows
    member this.Swap                               i1 j1 i2 j2   
                                                   = _swap i1 j1 i2 j2 
    member this.SwapRow                            r1 r2   
                                                   = _swapRow r1 r2 
    member this.This                               i   
                                                   = _this i 
    member this.This1                              i j   
                                                   = _this1 i j 
    member this.ToString                           = _ToString
(* <summary>
  This class implements the concept of Matrix as used in linear algebra. As such, it is <b>not</b> meant to be used as a container.

  </summary> *)
[<AutoSerializable(true)>]
type MatrixModel2
    ( from                                         : ICell<Matrix>
    ) as this =

    inherit Model<Matrix> ()
(*
    Parameters
*)
    let _from                                      = from
(*
    Functions
*)
    let mutable
        _Matrix                                    = cell (fun () -> new Matrix (from.Value))
    let _column                                    (c : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.column(c.Value))
    let _columns                                   = triv (fun () -> _Matrix.Value.columns())
    let _diagonal                                  = triv (fun () -> _Matrix.Value.diagonal())
    let _empty                                     = triv (fun () -> _Matrix.Value.empty())
    let _fill                                      (value : ICell<double>)   
                                                   = triv (fun () -> _Matrix.Value.fill(value.Value)
                                                                     _Matrix.Value)
    let _GetRange                                  (start : ICell<int>) (length : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.GetRange(start.Value, length.Value))
    let _row                                       (r : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.row(r.Value))
    let _rows                                      = triv (fun () -> _Matrix.Value.rows())
    let _swap                                      (i1 : ICell<int>) (j1 : ICell<int>) (i2 : ICell<int>) (j2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swap(i1.Value, j1.Value, i2.Value, j2.Value)
                                                                     _Matrix.Value)
    let _swapRow                                   (r1 : ICell<int>) (r2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swapRow(r1.Value, r2.Value)
                                                                     _Matrix.Value)
    let _this                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value])
    let _this1                                     (i : ICell<int>) (j : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value, j.Value])
    let _ToString                                  = triv (fun () -> _Matrix.Value.ToString())
    do this.Bind(_Matrix)
(* 
    casting 
*)
    internal new () = new MatrixModel2(null)
    member internal this.Inject v = _Matrix <- v
    static member Cast (p : ICell<Matrix>) = 
        if p :? MatrixModel2 then 
            p :?> MatrixModel2
        else
            let o = new MatrixModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.from                               = _from 
    member this.Column                             c   
                                                   = _column c 
    member this.Columns                            = _columns
    member this.Diagonal                           = _diagonal
    member this.Empty                              = _empty
    member this.Fill                               value   
                                                   = _fill value 
    member this.GetRange                           start length   
                                                   = _GetRange start length 
    member this.Row                                r   
                                                   = _row r 
    member this.Rows                               = _rows
    member this.Swap                               i1 j1 i2 j2   
                                                   = _swap i1 j1 i2 j2 
    member this.SwapRow                            r1 r2   
                                                   = _swapRow r1 r2 
    member this.This                               i   
                                                   = _this i 
    member this.This1                              i j   
                                                   = _this1 i j 
    member this.ToString                           = _ToString
(* <summary>
  This class implements the concept of Matrix as used in linear algebra. As such, it is <b>not</b> meant to be used as a container.
! creates an empty matrix
  </summary> *)
[<AutoSerializable(true)>]
type MatrixModel3
    () as this =
    inherit Model<Matrix> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Matrix                                    = cell (fun () -> new Matrix ())
    let _column                                    (c : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.column(c.Value))
    let _columns                                   = triv (fun () -> _Matrix.Value.columns())
    let _diagonal                                  = triv (fun () -> _Matrix.Value.diagonal())
    let _empty                                     = triv (fun () -> _Matrix.Value.empty())
    let _fill                                      (value : ICell<double>)   
                                                   = triv (fun () -> _Matrix.Value.fill(value.Value)
                                                                     _Matrix.Value)
    let _GetRange                                  (start : ICell<int>) (length : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.GetRange(start.Value, length.Value))
    let _row                                       (r : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.row(r.Value))
    let _rows                                      = triv (fun () -> _Matrix.Value.rows())
    let _swap                                      (i1 : ICell<int>) (j1 : ICell<int>) (i2 : ICell<int>) (j2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swap(i1.Value, j1.Value, i2.Value, j2.Value)
                                                                     _Matrix.Value)
    let _swapRow                                   (r1 : ICell<int>) (r2 : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.swapRow(r1.Value, r2.Value)
                                                                     _Matrix.Value)
    let _this                                      (i : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value])
    let _this1                                     (i : ICell<int>) (j : ICell<int>)   
                                                   = triv (fun () -> _Matrix.Value.[i.Value, j.Value])
    let _ToString                                  = triv (fun () -> _Matrix.Value.ToString())
    do this.Bind(_Matrix)
(* 
    casting 
*)
    
    member internal this.Inject v = _Matrix <- v
    static member Cast (p : ICell<Matrix>) = 
        if p :? MatrixModel3 then 
            p :?> MatrixModel3
        else
            let o = new MatrixModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Column                             c   
                                                   = _column c 
    member this.Columns                            = _columns
    member this.Diagonal                           = _diagonal
    member this.Empty                              = _empty
    member this.Fill                               value   
                                                   = _fill value 
    member this.GetRange                           start length   
                                                   = _GetRange start length 
    member this.Row                                r   
                                                   = _row r 
    member this.Rows                               = _rows
    member this.Swap                               i1 j1 i2 j2   
                                                   = _swap i1 j1 i2 j2 
    member this.SwapRow                            r1 r2   
                                                   = _swapRow r1 r2 
    member this.This                               i   
                                                   = _this i 
    member this.This1                              i j   
                                                   = _this1 i j 
    member this.ToString                           = _ToString
