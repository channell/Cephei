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
type AmericanPathPricerModel
    ( payoff                                       : ICell<Payoff>
    , polynomOrder                                 : ICell<int>
    , polynomType                                  : ICell<LsmBasisSystem.PolynomType>
    ) as this =

    inherit Model<AmericanPathPricer> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _polynomOrder                              = polynomOrder
    let _polynomType                               = polynomType
(*
    Functions
*)
    let _AmericanPathPricer                        = cell (fun () -> new AmericanPathPricer (payoff.Value, polynomOrder.Value, polynomType.Value))
    let _basisSystem                               = cell (fun () -> _AmericanPathPricer.Value.basisSystem())
    let _state                                     (path : ICell<IPath>) (t : ICell<int>)   
                                                   = cell (fun () -> _AmericanPathPricer.Value.state(path.Value, t.Value))
    let _value                                     (path : ICell<IPath>) (t : ICell<int>)   
                                                   = cell (fun () -> _AmericanPathPricer.Value.value(path.Value, t.Value))
    do this.Bind(_AmericanPathPricer)

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.polynomOrder                       = _polynomOrder 
    member this.polynomType                        = _polynomType 
    member this.BasisSystem                        = _basisSystem
    member this.State                              path t   
                                                   = _state path t 
    member this.Value                              path t   
                                                   = _value path t 
