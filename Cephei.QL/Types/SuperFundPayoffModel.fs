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
  This payoff is equivalent to being (1/lowerstrike) a) long (short) an AssetOrNothing Call (Put) at the lower strike and b) short (long) an AssetOrNothing Call (Put) at the higher strike

  </summary> *)
[<AutoSerializable(true)>]
type SuperFundPayoffModel
    ( strike                                       : ICell<double>
    , secondStrike                                 : ICell<double>
    ) as this =

    inherit Model<SuperFundPayoff> ()
(*
    Parameters
*)
    let _strike                                    = strike
    let _secondStrike                              = secondStrike
(*
    Functions
*)
    let _SuperFundPayoff                           = cell (fun () -> new SuperFundPayoff (strike.Value, secondStrike.Value))
    let _name                                      = cell (fun () -> _SuperFundPayoff.Value.name())
    let _secondStrike                              = cell (fun () -> _SuperFundPayoff.Value.secondStrike())
    let _value                                     (price : ICell<double>)   
                                                   = cell (fun () -> _SuperFundPayoff.Value.value(price.Value))
    let _description                               = cell (fun () -> _SuperFundPayoff.Value.description())
    let _strike                                    = cell (fun () -> _SuperFundPayoff.Value.strike())
    let _optionType                                = cell (fun () -> _SuperFundPayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _SuperFundPayoff.Value.accept(v.Value)
                                                                     _SuperFundPayoff.Value)
    do this.Bind(_SuperFundPayoff)

(* 
    Externally visible/bindable properties
*)
    member this.strike                             = _strike 
    member this.secondStrike                       = _secondStrike 
    member this.Name                               = _name
    member this.SecondStrike                       = _secondStrike
    member this.Value                              price   
                                                   = _value price 
    member this.Description                        = _description
    member this.Strike                             = _strike
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
