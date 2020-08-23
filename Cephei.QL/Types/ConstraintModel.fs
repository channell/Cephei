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
  Base constraint class

  </summary> *)
[<AutoSerializable(true)>]
type ConstraintModel
    ( impl                                         : ICell<IConstraint>
    ) as this =

    inherit Model<Constraint> ()
(*
    Parameters
*)
    let _impl                                      = impl
(*
    Functions
*)
    let _Constraint                                = cell (fun () -> new Constraint (impl.Value))
    let _empty                                     = triv (fun () -> _Constraint.Value.empty())
    let _lowerBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _Constraint.Value.lowerBound(parameters.Value))
    let _test                                      (p : ICell<Vector>)   
                                                   = triv (fun () -> _Constraint.Value.test(p.Value))
    let _update                                    (p : ICell<Vector ref>) (direction : ICell<Vector>) (beta : ICell<double>)   
                                                   = triv (fun () -> _Constraint.Value.update(p.Value, direction.Value, beta.Value))
    let _upperBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _Constraint.Value.upperBound(parameters.Value))
    do this.Bind(_Constraint)

(* 
    Externally visible/bindable properties
*)
    member this.impl                               = _impl 
    member this.Empty                              = _empty
    member this.LowerBound                         parameters   
                                                   = _lowerBound parameters 
    member this.Test                               p   
                                                   = _test p 
    member this.Update                             p direction beta   
                                                   = _update p direction beta 
    member this.UpperBound                         parameters   
                                                   = _upperBound parameters 
(* <summary>
  Base constraint class

  </summary> *)
[<AutoSerializable(true)>]
type ConstraintModel1
    () as this =
    inherit Model<Constraint> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Constraint                                = cell (fun () -> new Constraint ())
    let _empty                                     = triv (fun () -> _Constraint.Value.empty())
    let _lowerBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _Constraint.Value.lowerBound(parameters.Value))
    let _test                                      (p : ICell<Vector>)   
                                                   = triv (fun () -> _Constraint.Value.test(p.Value))
    let _update                                    (p : ICell<Vector ref>) (direction : ICell<Vector>) (beta : ICell<double>)   
                                                   = triv (fun () -> _Constraint.Value.update(p.Value, direction.Value, beta.Value))
    let _upperBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _Constraint.Value.upperBound(parameters.Value))
    do this.Bind(_Constraint)

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
