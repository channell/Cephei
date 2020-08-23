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
type ImpliedVolHelperModel
    ( cap                                          : ICell<CapFloor>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , targetValue                                  : ICell<double>
    , displacement                                 : ICell<double>
    , Type                                         : ICell<VolatilityType>
    ) as this =

    inherit Model<ImpliedVolHelper> ()
(*
    Parameters
*)
    let _cap                                       = cap
    let _discountCurve                             = discountCurve
    let _targetValue                               = targetValue
    let _displacement                              = displacement
    let _Type                                      = Type
(*
    Functions
*)
    let _ImpliedVolHelper                          = cell (fun () -> new ImpliedVolHelper (cap.Value, discountCurve.Value, targetValue.Value, displacement.Value, Type.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _ImpliedVolHelper.Value.derivative(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _ImpliedVolHelper.Value.value(x.Value))
    do this.Bind(_ImpliedVolHelper)

(* 
    Externally visible/bindable properties
*)
    member this.cap                                = _cap 
    member this.discountCurve                      = _discountCurve 
    member this.targetValue                        = _targetValue 
    member this.displacement                       = _displacement 
    member this.Type                               = _Type 
    member this.Derivative                         x   
                                                   = _derivative x 
    member this.Value                              x   
                                                   = _value x 
