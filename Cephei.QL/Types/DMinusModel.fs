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
  The differential operator D_{-} discretizes the first derivative with the first-order formula u_{i}} x} = D_{-} u_{i}  findiff

  </summary> *)
[<AutoSerializable(true)>]
type DMinusModel
    ( gridPoints                                   : ICell<int>
    , h                                            : ICell<double>
    ) as this =

    inherit Model<DMinus> ()
(*
    Parameters
*)
    let _gridPoints                                = gridPoints
    let _h                                         = h
(*
    Functions
*)
    let _DMinus                                    = cell (fun () -> new DMinus (gridPoints.Value, h.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _DMinus.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _DMinus.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _DMinus.Value.Clone())
    let _diagonal                                  = triv (fun () -> _DMinus.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _DMinus.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _DMinus.Value.isTimeDependent())
    let _lowerDiagonal                             = triv (fun () -> _DMinus.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = triv (fun () -> _DMinus.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _DMinus.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _DMinus.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = triv (fun () -> _DMinus.Value.setLastRow(valA.Value, valB.Value)
                                                                     _DMinus.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _DMinus.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _DMinus.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _DMinus.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _DMinus.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _DMinus.Value.setTime(t.Value)
                                                                     _DMinus.Value)
    let _size                                      = triv (fun () -> _DMinus.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _DMinus.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = triv (fun () -> _DMinus.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _DMinus.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = triv (fun () -> _DMinus.Value.upperDiagonal())
    do this.Bind(_DMinus)
(* 
    casting 
*)
    internal new () = DMinusModel(null,null)
    member internal this.Inject v = _DMinus.Value <- v
    static member Cast (p : ICell<DMinus>) = 
        if p :? DMinusModel then 
            p :?> DMinusModel
        else
            let o = new DMinusModel ()
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
