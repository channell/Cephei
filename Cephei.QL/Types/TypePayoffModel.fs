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
  Intermediate class for put/call payoffs

  </summary> *)
[<AutoSerializable(true)>]
type TypePayoffModel
    ( Type                                         : ICell<Option.Type>
    ) as this =

    inherit Model<TypePayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
(*
    Functions
*)
    let _TypePayoff                                = cell (fun () -> new TypePayoff (Type.Value))
    let _description                               = triv (fun () -> _TypePayoff.Value.description())
    let _optionType                                = triv (fun () -> _TypePayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _TypePayoff.Value.accept(v.Value)
                                                                     _TypePayoff.Value)
    let _name                                      = triv (fun () -> _TypePayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _TypePayoff.Value.value(price.Value))
    do this.Bind(_TypePayoff)
(* 
    casting 
*)
    internal new () = TypePayoffModel(null)
    member internal this.Inject v = _TypePayoff.Value <- v
    static member Cast (p : ICell<TypePayoff>) = 
        if p :? TypePayoffModel then 
            p :?> TypePayoffModel
        else
            let o = new TypePayoffModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.Description                        = _description
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 
