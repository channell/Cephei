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
type SecondOrderMixedDerivativeOpModel
    ( d0                                           : ICell<int>
    , d1                                           : ICell<int>
    , mesher                                       : ICell<FdmMesher>
    ) as this =

    inherit Model<SecondOrderMixedDerivativeOp> ()
(*
    Parameters
*)
    let _d0                                        = d0
    let _d1                                        = d1
    let _mesher                                    = mesher
(*
    Functions
*)
    let _SecondOrderMixedDerivativeOp              = cell (fun () -> new SecondOrderMixedDerivativeOp (d0.Value, d1.Value, mesher.Value))
    let _add                                       (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.add(A.Value, B.Value))
    let _apply                                     (r : ICell<Vector>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.apply(r.Value))
    let _applyTo                                   (v : ICell<Vector>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.applyTo(v.Value))
    let _Clone                                     = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.Clone())
    let _identity                                  (size : ICell<int>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.identity(size.Value))
    let _isTimeDependent                           = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.isTimeDependent())
    let _mult                                      (r : ICell<Vector>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.mult(r.Value))
    let _multiply                                  (a : ICell<double>) (D : ICell<IOperator>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.multiply(a.Value, D.Value))
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.setTime(t.Value)
                                                                     _SecondOrderMixedDerivativeOp.Value)
    let _size                                      = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.size())
    let _solveFor                                  (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.solveFor(rhs.Value))
    let _subtract                                  (A : ICell<IOperator>) (B : ICell<IOperator>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.subtract(A.Value, B.Value))
    let _swap                                      (m : ICell<NinePointLinearOp>)   
                                                   = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.swap(m.Value)
                                                                     _SecondOrderMixedDerivativeOp.Value)
    let _toMatrix                                  = triv (fun () -> _SecondOrderMixedDerivativeOp.Value.toMatrix())
    do this.Bind(_SecondOrderMixedDerivativeOp)
(* 
    casting 
*)
    internal new () = SecondOrderMixedDerivativeOpModel(null,null,null)
    member internal this.Inject v = _SecondOrderMixedDerivativeOp.Value <- v
    static member Cast (p : ICell<SecondOrderMixedDerivativeOp>) = 
        if p :? SecondOrderMixedDerivativeOpModel then 
            p :?> SecondOrderMixedDerivativeOpModel
        else
            let o = new SecondOrderMixedDerivativeOpModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.d0                                 = _d0 
    member this.d1                                 = _d1 
    member this.mesher                             = _mesher 
    member this.Add                                A B   
                                                   = _add A B 
    member this.Apply                              r   
                                                   = _apply r 
    member this.ApplyTo                            v   
                                                   = _applyTo v 
    member this.Clone                              = _Clone
    member this.Identity                           size   
                                                   = _identity size 
    member this.IsTimeDependent                    = _isTimeDependent
    member this.Mult                               r   
                                                   = _mult r 
    member this.Multiply                           a D   
                                                   = _multiply a D 
    member this.SetTime                            t   
                                                   = _setTime t 
    member this.Size                               = _size
    member this.SolveFor                           rhs   
                                                   = _solveFor rhs 
    member this.Subtract                           A B   
                                                   = _subtract A B 
    member this.Swap                               m   
                                                   = _swap m 
    member this.ToMatrix                           = _toMatrix
