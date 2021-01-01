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
  See sect. findiff for details on the method.  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  copy constructor/assignment (these will be provided by the compiler if none is defined) Operator(const Operator&); Operator& operator=(const Operator&);  inspectors Size size();  modifiers void setTime(Time t);  operator interface array_type applyTo(const array_type&); static Operator identity(Size size);  operator algebra Operator operator*(Real, const Operator&); Operator operator-(const Operator&, const Operator&);  add Richardson extrapolation  findiff
constructors
  </summary> *)
[<AutoSerializable(true)>]
type ExplicitEulerModel<'Operator when 'Operator :> IOperator>
    () as this =
    inherit Model<ExplicitEuler<'Operator>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _ExplicitEuler                             = make (fun () -> new ExplicitEuler<'Operator> ())
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv _ExplicitEuler (fun () -> _ExplicitEuler.Value.setStep(dt.Value)
                                                                                    _ExplicitEuler.Value)
    let _step                                      (o : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv _ExplicitEuler (fun () -> _ExplicitEuler.Value.step(ref o.Value, t.Value, theta.Value)
                                                                                    _ExplicitEuler.Value)
    do this.Bind(_ExplicitEuler)

(* 
    Externally visible/bindable properties
*)
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
(* <summary>
  See sect. findiff for details on the method.  In this implementation, the passed operator must be derived from either TimeConstantOperator or TimeDependentOperator. Also, it must implement at least the following interface:  copy constructor/assignment (these will be provided by the compiler if none is defined) Operator(const Operator&); Operator& operator=(const Operator&);  inspectors Size size();  modifiers void setTime(Time t);  operator interface array_type applyTo(const array_type&); static Operator identity(Size size);  operator algebra Operator operator*(Real, const Operator&); Operator operator-(const Operator&, const Operator&);  add Richardson extrapolation  findiff
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type ExplicitEulerModel1<'Operator when 'Operator :> IOperator>
    ( L                                            : ICell<'Operator>
    , bcs                                          : ICell<Generic.List<BoundaryCondition<IOperator>>>
    ) as this =

    inherit Model<ExplicitEuler<'Operator>> ()
(*
    Parameters
*)
    let _L                                         = L
    let _bcs                                       = bcs
(*
    Functions
*)
    let mutable
        _ExplicitEuler                             = make (fun () -> new ExplicitEuler<'Operator> (L.Value, bcs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = triv _ExplicitEuler (fun () -> _ExplicitEuler.Value.setStep(dt.Value)
                                                                                    _ExplicitEuler.Value)
    let _step                                      (o : ICell<Object>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = triv _ExplicitEuler (fun () -> _ExplicitEuler.Value.step(ref o.Value, t.Value, theta.Value)
                                                                                    _ExplicitEuler.Value)
    do this.Bind(_ExplicitEuler)

(* 
    Externally visible/bindable properties
*)
    member this.L                                  = _L 
    member this.bcs                                = _bcs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               o t theta   
                                                   = _step o t theta 
