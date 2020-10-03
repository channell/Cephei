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


  </summary> *)
[<AutoSerializable(true)>]
type PdeOperatorModel<'PdeClass when 'PdeClass :> PdeSecondOrderParabolic and 'PdeClass : (new : unit -> 'PdeClass)>
    ( grid                                         : ICell<Vector>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    ) as this =

    inherit Model<PdeOperator<'PdeClass>> ()
(*
    Parameters
*)
    let _grid                                      = grid
    let _Process                                   = Process
(*
    Functions
*)
    let _PdeOperator                               = cell (fun () -> new PdeOperator<'PdeClass> (grid.Value, Process.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _PdeOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _PdeOperator.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _PdeOperator.Value.Clone())
    let _diagonal                                  = triv (fun () -> _PdeOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _PdeOperator.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _PdeOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = triv (fun () -> _PdeOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = triv (fun () -> _PdeOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _PdeOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _PdeOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _PdeOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _PdeOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setTime(t.Value)
                                                                     _PdeOperator.Value)
    let _size                                      = triv (fun () -> _PdeOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _PdeOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _PdeOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = triv (fun () -> _PdeOperator.Value.upperDiagonal())
    do this.Bind(_PdeOperator)

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
    member this.Process                            = _Process 
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type PdeOperatorModel1<'PdeClass when 'PdeClass :> PdeSecondOrderParabolic and 'PdeClass : (new : unit -> 'PdeClass)>
    ( grid                                         : ICell<Vector>
    , Process                                      : ICell<GeneralizedBlackScholesProcess>
    , residualTime                                 : ICell<double>
    ) as this =

    inherit Model<PdeOperator<'PdeClass>> ()
(*
    Parameters
*)
    let _grid                                      = grid
    let _Process                                   = Process
    let _residualTime                              = residualTime
(*
    Functions
*)
    let _PdeOperator                               = cell (fun () -> new PdeOperator<'PdeClass> (grid.Value, Process.Value, residualTime.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _PdeOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _PdeOperator.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _PdeOperator.Value.Clone())
    let _diagonal                                  = triv (fun () -> _PdeOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _PdeOperator.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _PdeOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = triv (fun () -> _PdeOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = triv (fun () -> _PdeOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _PdeOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _PdeOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _PdeOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _PdeOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.setTime(t.Value)
                                                                     _PdeOperator.Value)
    let _size                                      = triv (fun () -> _PdeOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _PdeOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = triv (fun () -> _PdeOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _PdeOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = triv (fun () -> _PdeOperator.Value.upperDiagonal())
    do this.Bind(_PdeOperator)

(* 
    Externally visible/bindable properties
*)
    member this.grid                               = _grid 
    member this.Process                            = _Process 
    member this.residualTime                       = _residualTime 
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
