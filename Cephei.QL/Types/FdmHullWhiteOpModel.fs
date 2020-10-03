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
type FdmHullWhiteOpModel
    ( mesher                                       : ICell<FdmMesher>
    , model                                        : ICell<HullWhite>
    , direction                                    : ICell<int>
    ) as this =

    inherit Model<FdmHullWhiteOp> ()
(*
    Parameters
*)
    let _mesher                                    = mesher
    let _model                                     = model
    let _direction                                 = direction
(*
    Functions
*)
    let _FdmHullWhiteOp                            = cell (fun () -> new FdmHullWhiteOp (mesher.Value, model.Value, direction.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.add(A.Value, B.Value))
    let _apply                                     (r : ICell<Vector>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.apply(r.Value))
    let _apply_direction                           (direction : ICell<int>) (r : ICell<Vector>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.apply_direction(direction.Value, r.Value))
    let _apply_mixed                               (r : ICell<Vector>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.apply_mixed(r.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _FdmHullWhiteOp.Value.Clone())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _FdmHullWhiteOp.Value.isTimeDependent())
    let _multiply                                  (a : ICell<double>) (D : ICell<IOperator>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.multiply(a.Value, D.Value))
    let _preconditioner                            (r : ICell<Vector>) (s : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.preconditioner(r.Value, s.Value))
    let _setTime                                   (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.setTime(t1.Value, t2.Value)
                                                                     _FdmHullWhiteOp.Value)
    let _setTime1                                  (t : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.setTime(t.Value)
                                                                     _FdmHullWhiteOp.Value)
    let _size                                      = triv (fun () -> _FdmHullWhiteOp.Value.size())
    let _solve_splitting                           (direction : ICell<int>) (r : ICell<Vector>) (s : ICell<double>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.solve_splitting(direction.Value, r.Value, s.Value))
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.solveFor(rhs.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _FdmHullWhiteOp.Value.subtract(A.Value, B.Value))
    let _toMatrixDecomp                            = triv (fun () -> _FdmHullWhiteOp.Value.toMatrixDecomp())
    let _toMatrix                                  = triv (fun () -> _FdmHullWhiteOp.Value.toMatrix())
    do this.Bind(_FdmHullWhiteOp)
(* 
    casting 
*)
    internal new () = FdmHullWhiteOpModel(null,null,null)
    member internal this.Inject v = _FdmHullWhiteOp.Value <- v
    static member Cast (p : ICell<FdmHullWhiteOp>) = 
        if p :? FdmHullWhiteOpModel then 
            p :?> FdmHullWhiteOpModel
        else
            let o = new FdmHullWhiteOpModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.mesher                             = _mesher 
    member this.model                              = _model 
    member this.direction                          = _direction 
    member this.Add                                A B   
                                                   = _add A B 
    member this.Apply                              r   
                                                   = _apply r 
    member this.Apply_direction                    direction r   
                                                   = _apply_direction direction r 
    member this.Apply_mixed                        r   
                                                   = _apply_mixed r 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Clone                              = _Clone
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.Multiply                           a D   
                                                   = _multiply a D 
    member this.Preconditioner                     r s   
                                                   = _preconditioner r s 
    member this.SetTime                            t1 t2   
                                                   = _setTime t1 t2 
    member this.SetTime1                           t   
                                                   = _setTime1 t 
    member this.Size                               = _size
    member this.Solve_splitting                    direction r s   
                                                   = _solve_splitting direction r s 
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.ToMatrixDecomp                     = _toMatrixDecomp
    member this.ToMatrix                           = _toMatrix
