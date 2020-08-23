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
type IntegrandModel
    ( payoff                                       : ICell<Payoff>
    , s0                                           : ICell<double>
    , drift                                        : ICell<double>
    , variance                                     : ICell<double>
    ) as this =

    inherit Model<Integrand> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _s0                                        = s0
    let _drift                                     = drift
    let _variance                                  = variance
(*
    Functions
*)
    let _Integrand                                 = cell (fun () -> new Integrand (payoff.Value, s0.Value, drift.Value, variance.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _Integrand.Value.value(x.Value))
    do this.Bind(_Integrand)

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.s0                                 = _s0 
    member this.drift                              = _drift 
    member this.variance                           = _variance 
    member this.Value                              x   
                                                   = _value x 
