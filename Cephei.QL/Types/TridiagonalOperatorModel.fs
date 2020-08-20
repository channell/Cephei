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
  to use real time-dependant algebra, you must overload the corresponding operators in the inheriting time-dependent class.  findiff

  </summary> *)
[<AutoSerializable(true)>]
type TridiagonalOperatorModel
    () as this =
    inherit Model<TridiagonalOperator> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _TridiagonalOperator                       = cell (fun () -> new TridiagonalOperator ())
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.applyTo(v.Value))
    let _Clone                                     = cell (fun () -> _TridiagonalOperator.Value.Clone())
    let _diagonal                                  = cell (fun () -> _TridiagonalOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.identity(size.Value))
    let _isTimeDependent                           = cell (fun () -> _TridiagonalOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = cell (fun () -> _TridiagonalOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _TridiagonalOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setTime(t.Value)
                                                                     _TridiagonalOperator.Value)
    let _size                                      = cell (fun () -> _TridiagonalOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = cell (fun () -> _TridiagonalOperator.Value.upperDiagonal())
    do this.Bind(_TridiagonalOperator)

(* 
    Externally visible/bindable properties
*)
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
  to use real time-dependant algebra, you must overload the corresponding operators in the inheriting time-dependent class.  findiff

  </summary> *)
[<AutoSerializable(true)>]
type TridiagonalOperatorModel1
    ( low                                          : ICell<Vector>
    , mid                                          : ICell<Vector>
    , high                                         : ICell<Vector>
    ) as this =

    inherit Model<TridiagonalOperator> ()
(*
    Parameters
*)
    let _low                                       = low
    let _mid                                       = mid
    let _high                                      = high
(*
    Functions
*)
    let _TridiagonalOperator                       = cell (fun () -> new TridiagonalOperator (low.Value, mid.Value, high.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.applyTo(v.Value))
    let _Clone                                     = cell (fun () -> _TridiagonalOperator.Value.Clone())
    let _diagonal                                  = cell (fun () -> _TridiagonalOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.identity(size.Value))
    let _isTimeDependent                           = cell (fun () -> _TridiagonalOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = cell (fun () -> _TridiagonalOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _TridiagonalOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setTime(t.Value)
                                                                     _TridiagonalOperator.Value)
    let _size                                      = cell (fun () -> _TridiagonalOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = cell (fun () -> _TridiagonalOperator.Value.upperDiagonal())
    do this.Bind(_TridiagonalOperator)

(* 
    Externally visible/bindable properties
*)
    member this.low                                = _low 
    member this.mid                                = _mid 
    member this.high                               = _high 
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
  to use real time-dependant algebra, you must overload the corresponding operators in the inheriting time-dependent class.  findiff

  </summary> *)
[<AutoSerializable(true)>]
type TridiagonalOperatorModel2
    ( size                                         : ICell<int>
    ) as this =

    inherit Model<TridiagonalOperator> ()
(*
    Parameters
*)
    let _size                                      = size
(*
    Functions
*)
    let _TridiagonalOperator                       = cell (fun () -> new TridiagonalOperator (size.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.add(A.Value, B.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.applyTo(v.Value))
    let _Clone                                     = cell (fun () -> _TridiagonalOperator.Value.Clone())
    let _diagonal                                  = cell (fun () -> _TridiagonalOperator.Value.diagonal())
    let _identity                                  (size : ICell<int>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.identity(size.Value))
    let _isTimeDependent                           = cell (fun () -> _TridiagonalOperator.Value.isTimeDependent())
    let _lowerDiagonal                             = cell (fun () -> _TridiagonalOperator.Value.lowerDiagonal())
    let _multiply                                  (a : ICell<double>) (o : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.multiply(a.Value, o.Value))
    let _setFirstRow                               (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setFirstRow(valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setLastRow                                (valA : ICell<double>) (valB : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setLastRow(valA.Value, valB.Value)
                                                                     _TridiagonalOperator.Value)
    let _setMidRow                                 (i : ICell<int>) (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setMidRow(i.Value, valA.Value, valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setMidRows                                (valA : ICell<double>) (valB : ICell<double>) (valC : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setMidRows(valA.Value, valB.Value, valC.Value)
                                                                     _TridiagonalOperator.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.setTime(t.Value)
                                                                     _TridiagonalOperator.Value)
    let _size                                      = cell (fun () -> _TridiagonalOperator.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.solveFor(rhs.Value))
    let _SOR                                       (rhs : ICell<Vector>) (tol : ICell<double>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.SOR(rhs.Value, tol.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = cell (fun () -> _TridiagonalOperator.Value.subtract(A.Value, B.Value))
    let _upperDiagonal                             = cell (fun () -> _TridiagonalOperator.Value.upperDiagonal())
    do this.Bind(_TridiagonalOperator)

(* 
    Externally visible/bindable properties
*)
    member this.size                               = _size 
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
