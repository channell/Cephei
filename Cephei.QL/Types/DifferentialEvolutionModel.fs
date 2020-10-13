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
type DifferentialEvolutionModel
    ( configuration                                : ICell<DifferentialEvolution.Configuration>
    ) as this =

    inherit Model<DifferentialEvolution> ()
(*
    Parameters
*)
    let _configuration                             = configuration
(*
    Functions
*)
    let _DifferentialEvolution                     = cell (fun () -> new DifferentialEvolution (configuration.Value))
    let _configuration                             = triv (fun () -> _DifferentialEvolution.Value.configuration())
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = triv (fun () -> _DifferentialEvolution.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_DifferentialEvolution)
(* 
    casting 
*)
    internal new () = new DifferentialEvolutionModel(null)
    member internal this.Inject v = _DifferentialEvolution.Value <- v
    static member Cast (p : ICell<DifferentialEvolution>) = 
        if p :? DifferentialEvolutionModel then 
            p :?> DifferentialEvolutionModel
        else
            let o = new DifferentialEvolutionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.configuration                      = _configuration 
    member this.Configuration                      = _configuration
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
