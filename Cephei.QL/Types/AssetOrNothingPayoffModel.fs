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
  Binary asset-or-nothing payoff

  </summary> *)
[<AutoSerializable(true)>]
type AssetOrNothingPayoffModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    ) as this =

    inherit Model<AssetOrNothingPayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
(*
    Functions
*)
    let _AssetOrNothingPayoff                      = cell (fun () -> new AssetOrNothingPayoff (Type.Value, strike.Value))
    let _name                                      = cell (fun () -> _AssetOrNothingPayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = cell (fun () -> _AssetOrNothingPayoff.Value.value(price.Value))
    let _description                               = cell (fun () -> _AssetOrNothingPayoff.Value.description())
    let _strike                                    = cell (fun () -> _AssetOrNothingPayoff.Value.strike())
    let _optionType                                = cell (fun () -> _AssetOrNothingPayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _AssetOrNothingPayoff.Value.accept(v.Value)
                                                                     _AssetOrNothingPayoff.Value)
    do this.Bind(_AssetOrNothingPayoff)

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
