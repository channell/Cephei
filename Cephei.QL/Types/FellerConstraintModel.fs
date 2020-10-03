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
type FellerConstraintModel
    () as this =
    inherit Model<FellerConstraint> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FellerConstraint                          = cell (fun () -> new FellerConstraint ())
    let _empty                                     = cell (fun () -> _FellerConstraint.Value.empty())
    let _lowerBound                                (parameters : ICell<Vector>)   
                                                   = cell (fun () -> _FellerConstraint.Value.lowerBound(parameters.Value))
    let _test                                      (p : ICell<Vector>)   
                                                   = cell (fun () -> _FellerConstraint.Value.test(p.Value))
    let _update                                    (p : ICell<Vector>) (direction : ICell<Vector>) (beta : ICell<double>)   
                                                   = cell (fun () -> _FellerConstraint.Value.update(p.Value, direction.Value, beta.Value))
    let _upperBound                                (parameters : ICell<Vector>)   
                                                   = cell (fun () -> _FellerConstraint.Value.upperBound(parameters.Value))
    do this.Bind(_FellerConstraint)
(* 
    casting 
*)
    
    member internal this.Inject v = _FellerConstraint.Value <- v
    static member Cast (p : ICell<FellerConstraint>) = 
        if p :? FellerConstraintModel then 
            p :?> FellerConstraintModel
        else
            let o = new FellerConstraintModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<FellerConstraint>) = 
        if p :? FellerConstraintModel then 
            p :?> FellerConstraintModel
        else
            let o = new FellerConstraintModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Empty                              = _empty
    member this.LowerBound                         parameters   
                                                   = _lowerBound parameters 
    member this.Test                               p   
                                                   = _test p 
    member this.Update                             p direction beta   
                                                   = _update p direction beta 
    member this.UpperBound                         parameters   
                                                   = _upperBound parameters 
