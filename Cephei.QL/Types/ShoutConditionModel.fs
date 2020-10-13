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
  A shout option is an option where the holder has the right to lock in a minimum value for the payoff at one (shout) time during the option's life. The minimum value is the option's intrinsic value at the shout time.

  </summary> *)
[<AutoSerializable(true)>]
type ShoutConditionModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , resTime                                      : ICell<double>
    , rate                                         : ICell<double>
    ) as this =

    inherit Model<ShoutCondition> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _resTime                                   = resTime
    let _rate                                      = rate
(*
    Functions
*)
    let _ShoutCondition                            = cell (fun () -> new ShoutCondition (Type.Value, strike.Value, resTime.Value, rate.Value))
    let _applyTo                                   (a : ICell<Vector>) (t : ICell<double>)   
                                                   = triv (fun () -> _ShoutCondition.Value.applyTo(a.Value, t.Value)
                                                                     _ShoutCondition.Value)
    do this.Bind(_ShoutCondition)
(* 
    casting 
*)
    internal new () = new ShoutConditionModel(null,null,null,null)
    member internal this.Inject v = _ShoutCondition.Value <- v
    static member Cast (p : ICell<ShoutCondition>) = 
        if p :? ShoutConditionModel then 
            p :?> ShoutConditionModel
        else
            let o = new ShoutConditionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.resTime                            = _resTime 
    member this.rate                               = _rate 
    member this.ApplyTo                            a t   
                                                   = _applyTo a t 
(* <summary>
  A shout option is an option where the holder has the right to lock in a minimum value for the payoff at one (shout) time during the option's life. The minimum value is the option's intrinsic value at the shout time.

  </summary> *)
[<AutoSerializable(true)>]
type ShoutConditionModel1
    ( intrinsicValues                              : ICell<Vector>
    , resTime                                      : ICell<double>
    , rate                                         : ICell<double>
    ) as this =

    inherit Model<ShoutCondition> ()
(*
    Parameters
*)
    let _intrinsicValues                           = intrinsicValues
    let _resTime                                   = resTime
    let _rate                                      = rate
(*
    Functions
*)
    let _ShoutCondition                            = cell (fun () -> new ShoutCondition (intrinsicValues.Value, resTime.Value, rate.Value))
    let _applyTo                                   (a : ICell<Vector>) (t : ICell<double>)   
                                                   = triv (fun () -> _ShoutCondition.Value.applyTo(a.Value, t.Value)
                                                                     _ShoutCondition.Value)
    do this.Bind(_ShoutCondition)
(* 
    casting 
*)
    internal new () = new ShoutConditionModel1(null,null,null)
    member internal this.Inject v = _ShoutCondition.Value <- v
    static member Cast (p : ICell<ShoutCondition>) = 
        if p :? ShoutConditionModel1 then 
            p :?> ShoutConditionModel1
        else
            let o = new ShoutConditionModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.intrinsicValues                    = _intrinsicValues 
    member this.resTime                            = _resTime 
    member this.rate                               = _rate 
    member this.ApplyTo                            a t   
                                                   = _applyTo a t 
