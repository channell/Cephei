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
  The differential operator  D_{+}D_{-} discretizes the second derivative with the second-order formula  findiff  the correctness of the returned values is tested by checking them against numerical calculations.

  </summary> *)
[<AutoSerializable(true)>]
type DPlusDMinusModel
    ( gridPoints                                   : ICell<int>
    , h                                            : ICell<double>
    ) as this =

    inherit Model<DPlusDMinus> ()
(*
    Parameters
*)
    let _gridPoints                                = gridPoints
    let _h                                         = h
(*
    Functions
*)
    let _DPlusDMinus                               = cell (fun () -> new DPlusDMinus (gridPoints.Value, h.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _DPlusDMinus.Value.Clone())
    let _diagonal                                  = triv (fun () -> _DPlusDMinus.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _DPlusDMinus.Value.isTimeDependent())
    let _lowerDiagonal                             = triv (fun () -> _DPlusDMinus.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _DPlusDMinus.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.setLastRow(valA.Value, valB.Value)
                                                                     _DPlusDMinus.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _DPlusDMinus.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _DPlusDMinus.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.setTime(t.Value)
                                                                     _DPlusDMinus.Value)
    let _size                                      = triv (fun () -> _DPlusDMinus.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _DPlusDMinus.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = triv (fun () -> _DPlusDMinus.Value.upperDiagonal())
    do this.Bind(_DPlusDMinus)
(* 
    casting 
*)
    internal new () = DPlusDMinusModel(null,null)
    member internal this.Inject v = _DPlusDMinus.Value <- v
    static member Cast (p : ICell<DPlusDMinus>) = 
        if p :? DPlusDMinusModel then 
            p :?> DPlusDMinusModel
        else
            let o = new DPlusDMinusModel ()
            o.Inject p.Value
            o
                            

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
