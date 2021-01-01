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
  This payoff is equivalent to being a) long a PlainVanillaPayoff at the first strike (same Call/Put type) and b) short a CashOrNothingPayoff at the first strike (same Call/Put type) with cash payoff equal to the difference between the second and the first strike. this payoff can be negative depending on the strikes

  </summary> *)
[<AutoSerializable(true)>]
type GapPayoffModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , secondStrike                                 : ICell<double>
    ) as this =

    inherit Model<GapPayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _secondStrike                              = secondStrike
(*
    Functions
*)
    let mutable
        _GapPayoff                                 = make (fun () -> new GapPayoff (Type.Value, strike.Value, secondStrike.Value))
    let _description                               = triv _GapPayoff (fun () -> _GapPayoff.Value.description())
    let _name                                      = triv _GapPayoff (fun () -> _GapPayoff.Value.name())
    let _secondStrike                              = triv _GapPayoff (fun () -> _GapPayoff.Value.secondStrike())
    let _value                                     (price : ICell<double>)   
                                                   = triv _GapPayoff (fun () -> _GapPayoff.Value.value(price.Value))
    let _strike                                    = triv _GapPayoff (fun () -> _GapPayoff.Value.strike())
    let _optionType                                = triv _GapPayoff (fun () -> _GapPayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _GapPayoff (fun () -> _GapPayoff.Value.accept(v.Value)
                                                                                _GapPayoff.Value)
    do this.Bind(_GapPayoff)
(* 
    casting 
*)
    internal new () = new GapPayoffModel(null,null,null)
    member internal this.Inject v = _GapPayoff <- v
    static member Cast (p : ICell<GapPayoff>) = 
        if p :? GapPayoffModel then 
            p :?> GapPayoffModel
        else
            let o = new GapPayoffModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.secondStrike                       = _secondStrike 
    member this.Description                        = _description
    member this.Name                               = _name
    member this.SecondStrike                       = _secondStrike
    member this.Value                              price   
                                                   = _value price 
    member this.Strike                             = _strike
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
