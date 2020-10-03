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
  %Payoff with strike expressed as percentage

  </summary> *)
[<AutoSerializable(true)>]
type PercentageStrikePayoffModel
    ( Type                                         : ICell<Option.Type>
    , moneyness                                    : ICell<double>
    ) as this =

    inherit Model<PercentageStrikePayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _moneyness                                 = moneyness
(*
    Functions
*)
    let _PercentageStrikePayoff                    = cell (fun () -> new PercentageStrikePayoff (Type.Value, moneyness.Value))
    let _name                                      = triv (fun () -> _PercentageStrikePayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _PercentageStrikePayoff.Value.value(price.Value))
    let _description                               = triv (fun () -> _PercentageStrikePayoff.Value.description())
    let _strike                                    = triv (fun () -> _PercentageStrikePayoff.Value.strike())
    let _optionType                                = triv (fun () -> _PercentageStrikePayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _PercentageStrikePayoff.Value.accept(v.Value)
                                                                     _PercentageStrikePayoff.Value)
    do this.Bind(_PercentageStrikePayoff)
(* 
    casting 
*)
    internal new () = PercentageStrikePayoffModel(null,null)
    member internal this.Inject v = _PercentageStrikePayoff.Value <- v
    static member Cast (p : ICell<PercentageStrikePayoff>) = 
        if p :? PercentageStrikePayoffModel then 
            p :?> PercentageStrikePayoffModel
        else
            let o = new PercentageStrikePayoffModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.moneyness                          = _moneyness 
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 
    member this.Description                        = _description
    member this.Strike                             = _strike
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
