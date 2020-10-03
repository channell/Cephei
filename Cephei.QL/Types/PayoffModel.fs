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
  Abstract base class for option payoffs
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type PayoffModel
    () as this =
    inherit Model<Payoff> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Payoff                                    = cell (fun () -> new Payoff ())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _Payoff.Value.accept(v.Value)
                                                                     _Payoff.Value)
    let _description                               = triv (fun () -> _Payoff.Value.description())
    let _name                                      = triv (fun () -> _Payoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _Payoff.Value.value(price.Value))
    do this.Bind(_Payoff)
(* 
    casting 
*)
    
    member internal this.Inject v = _Payoff.Value <- v
    static member Cast (p : ICell<Payoff>) = 
        if p :? PayoffModel then 
            p :?> PayoffModel
        else
            let o = new PayoffModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Accept                             v   
                                                   = _accept v 
    member this.Description                        = _description
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 
