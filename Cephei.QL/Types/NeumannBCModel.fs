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
NeumanBC works on TridiagonalOperator. IOperator here is for type compatobility with options

  </summary> *)
[<AutoSerializable(true)>]
type NeumannBCModel
    ( value                                        : ICell<double>
    , side                                         : ICell<BoundaryCondition<IOperator>.Side>
    ) as this =

    inherit Model<NeumannBC> ()
(*
    Parameters
*)
    let _value                                     = value
    let _side                                      = side
(*
    Functions
*)
    let mutable
        _NeumannBC                                 = cell (fun () -> new NeumannBC (value.Value, side.Value))
    let _applyAfterApplying                        (u : ICell<Vector>)   
                                                   = triv (fun () -> _NeumannBC.Value.applyAfterApplying(u.Value)
                                                                     _NeumannBC.Value)
    let _applyAfterSolving                         (v : ICell<Vector>)   
                                                   = triv (fun () -> _NeumannBC.Value.applyAfterSolving(v.Value)
                                                                     _NeumannBC.Value)
    let _applyBeforeApplying                       (o : ICell<IOperator>)   
                                                   = triv (fun () -> _NeumannBC.Value.applyBeforeApplying(o.Value)
                                                                     _NeumannBC.Value)
    let _applyBeforeSolving                        (o : ICell<IOperator>) (rhs : ICell<Vector>)   
                                                   = triv (fun () -> _NeumannBC.Value.applyBeforeSolving(o.Value, rhs.Value)
                                                                     _NeumannBC.Value)
    let _setTime                                   (t : ICell<double>)   
                                                   = triv (fun () -> _NeumannBC.Value.setTime(t.Value)
                                                                     _NeumannBC.Value)
    do this.Bind(_NeumannBC)
(* 
    casting 
*)
    internal new () = new NeumannBCModel(null,null)
    member internal this.Inject v = _NeumannBC <- v
    static member Cast (p : ICell<NeumannBC>) = 
        if p :? NeumannBCModel then 
            p :?> NeumannBCModel
        else
            let o = new NeumannBCModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.value                              = _value 
    member this.side                               = _side 
    member this.ApplyAfterApplying                 u   
                                                   = _applyAfterApplying u 
    member this.ApplyAfterSolving                  v   
                                                   = _applyAfterSolving v 
    member this.ApplyBeforeApplying                o   
                                                   = _applyBeforeApplying o 
    member this.ApplyBeforeSolving                 o rhs   
                                                   = _applyBeforeSolving o rhs 
    member this.SetTime                            t   
                                                   = _setTime t 
