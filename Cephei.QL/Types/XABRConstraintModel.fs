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
type XABRConstraintModel
    ( impl                                         : ICell<IConstraint>
    ) as this =

    inherit Model<XABRConstraint> ()
(*
    Parameters
*)
    let _impl                                      = impl
(*
    Functions
*)
    let _XABRConstraint                            = cell (fun () -> new XABRConstraint (impl.Value))
    let _config                                    (costFunction : ICell<ProjectedCostFunction>) (coeff : ICell<XABRCoeffHolder<'Model>>) (forward : ICell<double>)   
                                                   = triv (fun () -> _XABRConstraint.Value.config(costFunction.Value, coeff.Value, forward.Value)
                                                                     _XABRConstraint.Value)
    let _empty                                     = triv (fun () -> _XABRConstraint.Value.empty())
    let _lowerBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _XABRConstraint.Value.lowerBound(parameters.Value))
    let _test                                      (p : ICell<Vector>)   
                                                   = triv (fun () -> _XABRConstraint.Value.test(p.Value))
    let _update                                    (p : ICell<Vector>) (direction : ICell<Vector>) (beta : ICell<double>)   
                                                   = triv (fun () -> _XABRConstraint.Value.update(ref p.Value, direction.Value, beta.Value))
    let _upperBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _XABRConstraint.Value.upperBound(parameters.Value))
    do this.Bind(_XABRConstraint)
(* 
    casting 
*)
    internal new () = new XABRConstraintModel(null)
    member internal this.Inject v = _XABRConstraint.Value <- v
    static member Cast (p : ICell<XABRConstraint>) = 
        if p :? XABRConstraintModel then 
            p :?> XABRConstraintModel
        else
            let o = new XABRConstraintModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.impl                               = _impl 
    member this.Config                             costFunction coeff forward   
                                                   = _config costFunction coeff forward 
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


  </summary> *)
[<AutoSerializable(true)>]
type XABRConstraintModel1
    () as this =
    inherit Model<XABRConstraint> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _XABRConstraint                            = cell (fun () -> new XABRConstraint ())
    let _config                                    (costFunction : ICell<ProjectedCostFunction>) (coeff : ICell<XABRCoeffHolder<'Model>>) (forward : ICell<double>)   
                                                   = triv (fun () -> _XABRConstraint.Value.config(costFunction.Value, coeff.Value, forward.Value)
                                                                     _XABRConstraint.Value)
    let _empty                                     = triv (fun () -> _XABRConstraint.Value.empty())
    let _lowerBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _XABRConstraint.Value.lowerBound(parameters.Value))
    let _test                                      (p : ICell<Vector>)   
                                                   = triv (fun () -> _XABRConstraint.Value.test(p.Value))
    let _update                                    (p : ICell<Vector>) (direction : ICell<Vector>) (beta : ICell<double>)   
                                                   = triv (fun () -> _XABRConstraint.Value.update(ref p.Value, direction.Value, beta.Value))
    let _upperBound                                (parameters : ICell<Vector>)   
                                                   = triv (fun () -> _XABRConstraint.Value.upperBound(parameters.Value))
    do this.Bind(_XABRConstraint)
(* 
    casting 
*)
    
    member internal this.Inject v = _XABRConstraint.Value <- v
    static member Cast (p : ICell<XABRConstraint>) = 
        if p :? XABRConstraintModel1 then 
            p :?> XABRConstraintModel1
        else
            let o = new XABRConstraintModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Config                             costFunction coeff forward   
                                                   = _config costFunction coeff forward 
    member this.Empty                              = _empty
    member this.LowerBound                         parameters   
                                                   = _lowerBound parameters 
    member this.Test                               p   
                                                   = _test p 
    member this.Update                             p direction beta   
                                                   = _update p direction beta 
    member this.UpperBound                         parameters   
                                                   = _upperBound parameters 
