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
  unify the intrinsicValues/Payoff thing

  </summary> *)
[<AutoSerializable(true)>]
type AmericanConditionModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    ) as this =

    inherit Model<AmericanCondition> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
(*
    Functions
*)
    let mutable
        _AmericanCondition                         = make (fun () -> new AmericanCondition (Type.Value, strike.Value))
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv _AmericanCondition (fun () -> _AmericanCondition.Value.applyTo(o.Value, t.Value)
                                                                                        _AmericanCondition.Value)
    do this.Bind(_AmericanCondition)
(* 
    casting 
*)
    internal new () = new AmericanConditionModel(null,null)
    member internal this.Inject v = _AmericanCondition <- v
    static member Cast (p : ICell<AmericanCondition>) = 
        if p :? AmericanConditionModel then 
            p :?> AmericanConditionModel
        else
            let o = new AmericanConditionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
(* <summary>
  unify the intrinsicValues/Payoff thing

  </summary> *)
[<AutoSerializable(true)>]
type AmericanConditionModel1
    ( intrinsicValues                              : ICell<Vector>
    ) as this =

    inherit Model<AmericanCondition> ()
(*
    Parameters
*)
    let _intrinsicValues                           = intrinsicValues
(*
    Functions
*)
    let mutable
        _AmericanCondition                         = make (fun () -> new AmericanCondition (intrinsicValues.Value))
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv _AmericanCondition (fun () -> _AmericanCondition.Value.applyTo(o.Value, t.Value)
                                                                                        _AmericanCondition.Value)
    do this.Bind(_AmericanCondition)
(* 
    casting 
*)
    internal new () = new AmericanConditionModel1(null)
    member internal this.Inject v = _AmericanCondition <- v
    static member Cast (p : ICell<AmericanCondition>) = 
        if p :? AmericanConditionModel1 then 
            p :?> AmericanConditionModel1
        else
            let o = new AmericanConditionModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.intrinsicValues                    = _intrinsicValues 
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
