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
  The differential operator D_{+} discretizes the first derivative with the first-order formula u_{i}} x} = D_{+} u_{i}  findiff

  </summary> *)
[<AutoSerializable(true)>]
type DPlusModel
    ( gridPoints                                   : ICell<int>
    , h                                            : ICell<double>
    ) as this =

    inherit Model<DPlus> ()
(*
    Parameters
*)
    let _gridPoints                                = gridPoints
    let _h                                         = h
(*
    Functions
*)
    let _DPlus                                     = cell (fun () -> new DPlus (gridPoints.Value, h.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _DPlus.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = cell (fun () -> _DPlus.Value.applyTo(v.Value))
    let _Clone                                     = cell (fun () -> _DPlus.Value.Clone())
    let _diagonal                                  = cell (fun () -> _DPlus.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = cell (fun () -> _DPlus.Value.identity(size.Value))
    let _isTimeDependent                           = cell (fun () -> _DPlus.Value.isTimeDependent())
    let _lowerDiagonal                             = cell (fun () -> _DPlus.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = cell (fun () -> _DPlus.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _DPlus.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _DPlus.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = cell (fun () -> _DPlus.Value.setLastRow(valA.Value, valB.Value)
                                                                     _DPlus.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _DPlus.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _DPlus.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _DPlus.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _DPlus.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _DPlus.Value.setTime(t.Value)
                                                                     _DPlus.Value)
    let _size                                      = cell (fun () -> _DPlus.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = cell (fun () -> _DPlus.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = cell (fun () -> _DPlus.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _DPlus.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = cell (fun () -> _DPlus.Value.upperDiagonal())
    do this.Bind(_DPlus)

(* 
    Externally visible/bindable properties
*)
    member this.gridPoints                         = _gridPoints 
    member this.h                                  = _h 
    member this.Add                                A B   
                                                   = _add A B 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Clone                              = _Clone
    member this.Diagonal                           = _diagonal
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.LowerDiagonal                      = _lowerDiagonal
    member this.Multiply                           a o   
                                                   = _multiply a o 
    member this.SetFirstRow                        valB valC   
                                                   = _setFirstRow valB valC 
    member this.SetLastRow                         valA valB   
                                                   = _setLastRow valA valB 
    member this.SetMidRow                          i valA valB valC   
                                                   = _setMidRow i valA valB valC 
    member this.SetMidRows                         valA valB valC   
                                                   = _setMidRows valA valB valC 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.Size                               = _size
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.SOR                                rhs tol   
                                                   = _SOR rhs tol 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.UpperDiagonal                      = _upperDiagonal
