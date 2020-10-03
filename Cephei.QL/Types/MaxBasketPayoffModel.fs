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
type MaxBasketPayoffModel
    ( p                                            : ICell<Payoff>
    ) as this =

    inherit Model<MaxBasketPayoff> ()
(*
    Parameters
*)
    let _p                                         = p
(*
    Functions
*)
    let _MaxBasketPayoff                           = cell (fun () -> new MaxBasketPayoff (p.Value))
    let _accumulate                                (a : ICell<Vector>)   
                                                   = triv (fun () -> _MaxBasketPayoff.Value.accumulate(a.Value))
    let _basePayoff                                = triv (fun () -> _MaxBasketPayoff.Value.basePayoff())
    let _description                               = triv (fun () -> _MaxBasketPayoff.Value.description())
    let _name                                      = triv (fun () -> _MaxBasketPayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _MaxBasketPayoff.Value.value(price.Value))
    let _value1                                    (a : ICell<Vector>)   
                                                   = triv (fun () -> _MaxBasketPayoff.Value.value(a.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _MaxBasketPayoff.Value.accept(v.Value)
                                                                     _MaxBasketPayoff.Value)
    do this.Bind(_MaxBasketPayoff)
(* 
    casting 
*)
    internal new () = MaxBasketPayoffModel(null)
    member internal this.Inject v = _MaxBasketPayoff.Value <- v
    static member Cast (p : ICell<MaxBasketPayoff>) = 
        if p :? MaxBasketPayoffModel then 
            p :?> MaxBasketPayoffModel
        else
            let o = new MaxBasketPayoffModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.p                                  = _p 
    member this.Accumulate                         a   
                                                   = _accumulate a 
    member this.BasePayoff                         = _basePayoff
    member this.Description                        = _description
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 
    member this.Value1                             a   
                                                   = _value1 a 
    member this.Accept                             v   
                                                   = _accept v 
