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
  Class for forward type payoffs

  </summary> *)
[<AutoSerializable(true)>]
type ForwardTypePayoffModel
    ( Type                                         : ICell<Position.Type>
    , strike                                       : ICell<double>
    ) as this =

    inherit Model<ForwardTypePayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
(*
    Functions
*)
    let _ForwardTypePayoff                         = cell (fun () -> new ForwardTypePayoff (Type.Value, strike.Value))
    let _description                               = cell (fun () -> _ForwardTypePayoff.Value.description())
    let _forwardType                               = cell (fun () -> _ForwardTypePayoff.Value.forwardType())
    let _name                                      = cell (fun () -> _ForwardTypePayoff.Value.name())
    let _strike                                    = cell (fun () -> _ForwardTypePayoff.Value.strike())
    let _value                                     (price : ICell<double>)   
                                                   = cell (fun () -> _ForwardTypePayoff.Value.value(price.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _ForwardTypePayoff.Value.accept(v.Value)
                                                                     _ForwardTypePayoff.Value)
    do this.Bind(_ForwardTypePayoff)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.Description                        = _description
    member this.ForwardType                        = _forwardType
    member this.Name                               = _name
    member this.Strike                             = _strike
    member this.Value                              price   
                                                   = _value price 
    member this.Accept                             v   
                                                   = _accept v 
