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
type SimulatedAnnealingModel<'RNG when 'RNG : not struct and 'RNG :> IRNGTraits and 'RNG : (new : unit -> 'RNG)>
    ( lambda                                       : ICell<double>
    , T0                                           : ICell<double>
    , K                                            : ICell<int>
    , alpha                                        : ICell<double>
    , rng                                          : ICell<'RNG>
    ) as this =

    inherit Model<SimulatedAnnealing<'RNG>> ()
(*
    Parameters
*)
    let _lambda                                    = lambda
    let _T0                                        = T0
    let _K                                         = K
    let _alpha                                     = alpha
    let _rng                                       = rng
(*
    Functions
*)
    let mutable
        _SimulatedAnnealing                        = make (fun () -> new SimulatedAnnealing<'RNG> (lambda.Value, T0.Value, K.Value, alpha.Value, rng.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = triv _SimulatedAnnealing (fun () -> _SimulatedAnnealing.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_SimulatedAnnealing)

(* 
    Externally visible/bindable properties
*)
    member this.lambda                             = _lambda 
    member this.T0                                 = _T0 
    member this.K                                  = _K 
    member this.alpha                              = _alpha 
    member this.rng                                = _rng 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type SimulatedAnnealingModel1<'RNG when 'RNG : not struct and 'RNG :> IRNGTraits and 'RNG : (new : unit -> 'RNG)>
    ( lambda                                       : ICell<double>
    , T0                                           : ICell<double>
    , epsilon                                      : ICell<double>
    , m                                            : ICell<int>
    , rng                                          : ICell<'RNG>
    ) as this =

    inherit Model<SimulatedAnnealing<'RNG>> ()
(*
    Parameters
*)
    let _lambda                                    = lambda
    let _T0                                        = T0
    let _epsilon                                   = epsilon
    let _m                                         = m
    let _rng                                       = rng
(*
    Functions
*)
    let mutable
        _SimulatedAnnealing                        = make (fun () -> new SimulatedAnnealing<'RNG> (lambda.Value, T0.Value, epsilon.Value, m.Value, rng.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = triv _SimulatedAnnealing (fun () -> _SimulatedAnnealing.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_SimulatedAnnealing)

(* 
    Externally visible/bindable properties
*)
    member this.lambda                             = _lambda 
    member this.T0                                 = _T0 
    member this.epsilon                            = _epsilon 
    member this.m                                  = _m 
    member this.rng                                = _rng 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
