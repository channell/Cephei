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
type FdmBlackScholesOpModel
    ( mesher                                       : ICell<FdmMesher>
    , bsProcess                                    : ICell<GeneralizedBlackScholesProcess>
    , strike                                       : ICell<double>
    , localVol                                     : ICell<bool>
    , illegalLocalVolOverwrite                     : ICell<Nullable<double>>
    , direction                                    : ICell<int>
    , quantoHelper                                 : ICell<FdmQuantoHelper>
    ) as this =

    inherit Model<FdmBlackScholesOp> ()
(*
    Parameters
*)
    let _mesher                                    = mesher
    let _bsProcess                                 = bsProcess
    let _strike                                    = strike
    let _localVol                                  = localVol
    let _illegalLocalVolOverwrite                  = illegalLocalVolOverwrite
    let _direction                                 = direction
    let _quantoHelper                              = quantoHelper
(*
    Functions
*)
    let _FdmBlackScholesOp                         = cell (fun () -> new FdmBlackScholesOp (mesher.Value, bsProcess.Value, strike.Value, localVol.Value, illegalLocalVolOverwrite.Value, direction.Value, quantoHelper.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.add(A.Value, B.Value))
    let _apply                                     (r : ICell<Vector>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.apply(r.Value))
    let _apply_direction                           (direction : ICell<int>) (r : ICell<Vector>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.apply_direction(direction.Value, r.Value))
    let _apply_mixed                               (r : ICell<Vector>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.apply_mixed(r.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _FdmBlackScholesOp.Value.Clone())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _FdmBlackScholesOp.Value.isTimeDependent())
    let _multiply                                  (a : ICell<double>) (D : ICell<IOperator>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.multiply(a.Value, D.Value))
    let _preconditioner                            (r : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.preconditioner(r.Value, dt.Value))
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.setTime(t.Value)
                                                                     _FdmBlackScholesOp.Value)
    let _setTime1                                  (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.setTime(t1.Value, t2.Value)
                                                                     _FdmBlackScholesOp.Value)
    let _size                                      = triv (fun () -> _FdmBlackScholesOp.Value.size())
    let _solve_splitting                           (direction : ICell<int>) (r : ICell<Vector>) (dt : ICell<double>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.solve_splitting(direction.Value, r.Value, dt.Value))
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.solveFor(rhs.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _FdmBlackScholesOp.Value.subtract(A.Value, B.Value))
    let _toMatrixDecomp                            = triv (fun () -> _FdmBlackScholesOp.Value.toMatrixDecomp())
    let _toMatrix                                  = triv (fun () -> _FdmBlackScholesOp.Value.toMatrix())
    do this.Bind(_FdmBlackScholesOp)
(* 
    casting 
*)
    internal new () = new FdmBlackScholesOpModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _FdmBlackScholesOp.Value <- v
    static member Cast (p : ICell<FdmBlackScholesOp>) = 
        if p :? FdmBlackScholesOpModel then 
            p :?> FdmBlackScholesOpModel
        else
            let o = new FdmBlackScholesOpModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.mesher                             = _mesher 
    member this.bsProcess                          = _bsProcess 
    member this.strike                             = _strike 
    member this.localVol                           = _localVol 
    member this.illegalLocalVolOverwrite           = _illegalLocalVolOverwrite 
    member this.direction                          = _direction 
    member this.quantoHelper                       = _quantoHelper 
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
    member this.Preconditioner                     r dt   
                                                   = _preconditioner r dt 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.SetTime1                           t1 t2   
                                                   = _setTime1 t1 t2 
    member this.Size                               = _size
    member this.Solve_splitting                    direction r dt   
                                                   = _solve_splitting direction r dt 
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.ToMatrixDecomp                     = _toMatrixDecomp
    member this.ToMatrix                           = _toMatrix
