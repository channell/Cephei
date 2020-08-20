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
NOTE: There is room for performance improvement especially in the array manipulation
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type Trbdf2Model<'Operator when 'Operator :> IOperator>
    ( L                                            : ICell<'Operator>
    , bcs                                          : ICell<Generic.List<BoundaryCondition<IOperator>>>
    ) as this =

    inherit Model<Trbdf2<'Operator>> ()
(*
    Parameters
*)
    let _L                                         = L
    let _bcs                                       = bcs
(*
    Functions
*)
    let _Trbdf2                                    = cell (fun () -> new Trbdf2<'Operator> (L.Value, bcs.Value))
    let _setStep                                   (dt : ICell<double>)   
                                                   = cell (fun () -> _Trbdf2.Value.setStep(dt.Value)
                                                                     _Trbdf2.Value)
    let _step                                      (a : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = cell (fun () -> _Trbdf2.Value.step(a.Value, t.Value, theta.Value)
                                                                     _Trbdf2.Value)
    do this.Bind(_Trbdf2)

(* 
    Externally visible/bindable properties
*)
    member this.L                                  = _L 
    member this.bcs                                = _bcs 
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
(* <summary>
NOTE: There is room for performance improvement especially in the array manipulation
constructors
  </summary> *)
[<AutoSerializable(true)>]
type Trbdf2Model1<'Operator when 'Operator :> IOperator>
    () as this =
    inherit Model<Trbdf2<'Operator>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Trbdf2                                    = cell (fun () -> new Trbdf2<'Operator> ())
    let _setStep                                   (dt : ICell<double>)   
                                                   = cell (fun () -> _Trbdf2.Value.setStep(dt.Value)
                                                                     _Trbdf2.Value)
    let _step                                      (a : ICell<Object ref>) (t : ICell<double>) (theta : ICell<double>)   
                                                   = cell (fun () -> _Trbdf2.Value.step(a.Value, t.Value, theta.Value)
                                                                     _Trbdf2.Value)
    do this.Bind(_Trbdf2)

(* 
    Externally visible/bindable properties
*)
    member this.SetStep                            dt   
                                                   = _setStep dt 
    member this.Step                               a t theta   
                                                   = _step a t theta 
