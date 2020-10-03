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
  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  copy constructor/assignment (these will be provided by the compiler if none is defined) Operator(const Operator&); Operator& operator=(const Operator&);  inspectors Size size();  modifiers void setTime(Time t);  operator interface array_type solveFor(const array_type&); static Operator identity(Size size);  operator algebra Operator operator*(Real, const Operator&); Operator operator+(const Operator&, const Operator&);  findiff
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type ImplicitEulerModel<'Operator when 'Operator :> IOperator>
    ( L                                            : ICell<'Operator>
    , bcs                                          : ICell<Generic.List<BoundaryCondition<IOperator>>>
    ) as this =

    inherit Model<ImplicitEuler<'Operator>> ()
(*
    Parameters
*)
    let _L                                         = L
    let _bcs                                       = bcs
(*
    Functions
*)
    let _ImplicitEuler                             = cell (fun () -> new ImplicitEuler<'Operator> (L.Value, bcs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _ImplicitEuler.Value.setStep(dt.Value)
                                                                     _ImplicitEuler.Value)
    let _step                                      (o : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _ImplicitEuler.Value.step(ref o.Value, t.Value, theta.Value)
                                                                     _ImplicitEuler.Value)
    do this.Bind(_ImplicitEuler)

(* 
    Externally visible/bindable properties
*)
    member this.L                                  = _L 
    member this.bcs                                = _bcs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
(* <summary>
  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  copy constructor/assignment (these will be provided by the compiler if none is defined) Operator(const Operator&); Operator& operator=(const Operator&);  inspectors Size size();  modifiers void setTime(Time t);  operator interface array_type solveFor(const array_type&); static Operator identity(Size size);  operator algebra Operator operator*(Real, const Operator&); Operator operator+(const Operator&, const Operator&);  findiff
constructors
  </summary> *)
[<AutoSerializable(true)>]
type ImplicitEulerModel1<'Operator when 'Operator :> IOperator>
    () as this =
    inherit Model<ImplicitEuler<'Operator>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _ImplicitEuler                             = cell (fun () -> new ImplicitEuler<'Operator> ())
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv (fun () -> _ImplicitEuler.Value.setStep(dt.Value)
                                                                     _ImplicitEuler.Value)
    let _step                                      (o : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv (fun () -> _ImplicitEuler.Value.step(ref o.Value, t.Value, theta.Value)
                                                                     _ImplicitEuler.Value)
    do this.Bind(_ImplicitEuler)

(* 
    Externally visible/bindable properties
*)
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
