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
type AverageBasketPayoffModel
    ( p                                            : ICell<Payoff>
    , a                                            : ICell<Vector>
    ) as this =

    inherit Model<AverageBasketPayoff> ()
(*
    Parameters
*)
    let _p                                         = p
    let _a                                         = a
(*
    Functions
*)
    let _AverageBasketPayoff                       = cell (fun () -> new AverageBasketPayoff (p.Value, a.Value))
    let _accumulate                                (a : ICell<Vector>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.accumulate(a.Value))
    let _basePayoff                                = triv (fun () -> _AverageBasketPayoff.Value.basePayoff())
    let _description                               = triv (fun () -> _AverageBasketPayoff.Value.description())
    let _name                                      = triv (fun () -> _AverageBasketPayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.value(price.Value))
    let _value1                                    (a : ICell<Vector>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.value(a.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.accept(v.Value)
                                                                     _AverageBasketPayoff.Value)
    do this.Bind(_AverageBasketPayoff)

(* 
    Externally visible/bindable properties
*)
    member this.p                                  = _p 
    member this.a                                  = _a 
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
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type AverageBasketPayoffModel1
    ( p                                            : ICell<Payoff>
    , n                                            : ICell<int>
    ) as this =

    inherit Model<AverageBasketPayoff> ()
(*
    Parameters
*)
    let _p                                         = p
    let _n                                         = n
(*
    Functions
*)
    let _AverageBasketPayoff                       = cell (fun () -> new AverageBasketPayoff (p.Value, n.Value))
    let _accumulate                                (a : ICell<Vector>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.accumulate(a.Value))
    let _basePayoff                                = triv (fun () -> _AverageBasketPayoff.Value.basePayoff())
    let _description                               = triv (fun () -> _AverageBasketPayoff.Value.description())
    let _name                                      = triv (fun () -> _AverageBasketPayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.value(price.Value))
    let _value1                                    (a : ICell<Vector>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.value(a.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _AverageBasketPayoff.Value.accept(v.Value)
                                                                     _AverageBasketPayoff.Value)
    do this.Bind(_AverageBasketPayoff)

(* 
    Externally visible/bindable properties
*)
    member this.p                                  = _p 
    member this.n                                  = _n 
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
