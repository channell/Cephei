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
  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  The differential operator must be linear for this evolver to work.  findiff
constructors
  </summary> *)
[<AutoSerializable(true)>]
type CrankNicolsonModel<'Operator when 'Operator :> IOperator>
    () as this =
    inherit Model<CrankNicolson<'Operator>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _CrankNicolson                             = cell (fun () -> new CrankNicolson<'Operator> ())
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalFields : ICell<Object[]>)   
                                                   = triv (fun () -> _CrankNicolson.Value.factory(L.Value, bcs.Value, additionalFields.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolson.Value.setStep(dt.Value)
                                                                     _CrankNicolson.Value)
    let _step                                      (o : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolson.Value.step(o.Value, t.Value, theta.Value)
                                                                     _CrankNicolson.Value)
    do this.Bind(_CrankNicolson)

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            L bcs additionalFields   
                                                   = _factory L bcs additionalFields 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
(* <summary>
  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  The differential operator must be linear for this evolver to work.  findiff
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type CrankNicolsonModel1<'Operator when 'Operator :> IOperator>
    ( L                                            : ICell<'Operator>
    , bcs                                          : ICell<Generic.List<BoundaryCondition<IOperator>>>
    ) as this =

    inherit Model<CrankNicolson<'Operator>> ()
(*
    Parameters
*)
    let _L                                         = L
    let _bcs                                       = bcs
(*
    Functions
*)
    let _CrankNicolson                             = cell (fun () -> new CrankNicolson<'Operator> (L.Value, bcs.Value))
    let _factory                                   (L : ICell<Object>) (bcs : ICell<Object>) (additionalFields : ICell<Object[]>)   
                                                   = triv (fun () -> _CrankNicolson.Value.factory(L.Value, bcs.Value, additionalFields.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolson.Value.setStep(dt.Value)
                                                                     _CrankNicolson.Value)
    let _step                                      (o : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _CrankNicolson.Value.step(o.Value, t.Value, theta.Value)
                                                                     _CrankNicolson.Value)
    do this.Bind(_CrankNicolson)

(* 
    Externally visible/bindable properties
*)
    member this.L                                  = _L 
    member this.bcs                                = _bcs 
    member this.Factory                            L bcs additionalFields   
                                                   = _factory L bcs additionalFields 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
