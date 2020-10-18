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
  Plain-vanilla payoff

  </summary> *)
[<AutoSerializable(true)>]
type PlainVanillaPayoffModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    ) as this =

    inherit Model<PlainVanillaPayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
(*
    Functions
*)
    let mutable
        _PlainVanillaPayoff                        = cell (fun () -> new PlainVanillaPayoff (Type.Value, strike.Value))
    let _name                                      = triv (fun () -> _PlainVanillaPayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _PlainVanillaPayoff.Value.value(price.Value))
    let _description                               = triv (fun () -> _PlainVanillaPayoff.Value.description())
    let _strike                                    = triv (fun () -> _PlainVanillaPayoff.Value.strike())
    let _optionType                                = triv (fun () -> _PlainVanillaPayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _PlainVanillaPayoff.Value.accept(v.Value)
                                                                     _PlainVanillaPayoff.Value)
    do this.Bind(_PlainVanillaPayoff)
(* 
    casting 
*)
    internal new () = new PlainVanillaPayoffModel(null,null)
    member internal this.Inject v = _PlainVanillaPayoff <- v
    static member Cast (p : ICell<PlainVanillaPayoff>) = 
        if p :? PlainVanillaPayoffModel then 
            p :?> PlainVanillaPayoffModel
        else
            let o = new PlainVanillaPayoffModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 
    member this.Description                        = _description
    member this.Strike                             = _strike
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
