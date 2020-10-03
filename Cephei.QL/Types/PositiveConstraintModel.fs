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
  %Constraint imposing positivity to all arguments

  </summary> *)
[<AutoSerializable(true)>]
type PositiveConstraintModel
    () as this =
    inherit Model<PositiveConstraint> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _PositiveConstraint                        = cell (fun () -> new PositiveConstraint ())
    let _empty                                     = triv (fun () -> _PositiveConstraint.Value.empty())
    let _lowerBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _PositiveConstraint.Value.lowerBound(parameters.Value))
    let _test                                      (p : ICell<Vector>)   
                                                   = triv (fun () -> _PositiveConstraint.Value.test(p.Value))
    let _update                                    (p : ICell<Vector>) (direction : ICell<Vector>) (beta : ICell<double>)   
                                                   = triv (fun () -> _PositiveConstraint.Value.update(ref p.Value, direction.Value, beta.Value))
    let _upperBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _PositiveConstraint.Value.upperBound(parameters.Value))
    do this.Bind(_PositiveConstraint)
(* 
    casting 
*)
    
    member internal this.Inject v = _PositiveConstraint.Value <- v
    static member Cast (p : ICell<PositiveConstraint>) = 
        if p :? PositiveConstraintModel then 
            p :?> PositiveConstraintModel
        else
            let o = new PositiveConstraintModel ()
            o.Inject p.Value
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
