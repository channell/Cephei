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
type ConfigurationModel
    () as this =
    inherit Model<Configuration> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Configuration                             = cell (fun () -> new Configuration ())
    let _applyBounds                               = cell (fun () -> _Configuration.Value.applyBounds)
    let _crossoverIsAdaptive                       = cell (fun () -> _Configuration.Value.crossoverIsAdaptive)
    let _crossoverProbability                      = cell (fun () -> _Configuration.Value.crossoverProbability)
    let _crossoverType                             = cell (fun () -> _Configuration.Value.crossoverType)
    let _populationMembers                         = cell (fun () -> _Configuration.Value.populationMembers)
    let _seed                                      = cell (fun () -> _Configuration.Value.seed)
    let _stepsizeWeight                            = cell (fun () -> _Configuration.Value.stepsizeWeight)
    let _strategy                                  = cell (fun () -> _Configuration.Value.strategy)
    let _withAdaptiveCrossover                     (b : ICell<bool>)   
                                                   = cell (fun () -> _Configuration.Value.withAdaptiveCrossover(b.Value))
    let _withBounds                                (b : ICell<bool>)   
                                                   = cell (fun () -> _Configuration.Value.withBounds(b.Value))
    let _withCrossoverProbability                  (p : ICell<double>)   
                                                   = cell (fun () -> _Configuration.Value.withCrossoverProbability(p.Value))
    let _withCrossoverType                         (t : ICell<CrossoverType>)   
                                                   = cell (fun () -> _Configuration.Value.withCrossoverType(t.Value))
    let _withPopulationMembers                     (n : ICell<int>)   
                                                   = cell (fun () -> _Configuration.Value.withPopulationMembers(n.Value))
    let _withSeed                                  (s : ICell<uint64>)   
                                                   = cell (fun () -> _Configuration.Value.withSeed(s.Value))
    let _withStepsizeWeight                        (w : ICell<double>)   
                                                   = cell (fun () -> _Configuration.Value.withStepsizeWeight(w.Value))
    let _withStrategy                              (s : ICell<Strategy>)   
                                                   = cell (fun () -> _Configuration.Value.withStrategy(s.Value))
    do this.Bind(_Configuration)
(* 
    casting 
*)
    
    member internal this.Inject v = _Configuration.Value <- v
    static member Cast (p : ICell<Configuration>) = 
        if p :? ConfigurationModel then 
            p :?> ConfigurationModel
        else
            let o = new ConfigurationModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<Configuration>) = 
        if p :? ConfigurationModel then 
            p :?> ConfigurationModel
        else
            let o = new ConfigurationModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.ApplyBounds                        = _applyBounds
    member this.CrossoverIsAdaptive                = _crossoverIsAdaptive
    member this.CrossoverProbability               = _crossoverProbability
    member this.CrossoverType                      = _crossoverType
    member this.PopulationMembers                  = _populationMembers
    member this.Seed                               = _seed
    member this.StepsizeWeight                     = _stepsizeWeight
    member this.Strategy                           = _strategy
    member this.WithAdaptiveCrossover              b   
                                                   = _withAdaptiveCrossover b 
    member this.WithBounds                         b   
                                                   = _withBounds b 
    member this.WithCrossoverProbability           p   
                                                   = _withCrossoverProbability p 
    member this.WithCrossoverType                  t   
                                                   = _withCrossoverType t 
    member this.WithPopulationMembers              n   
                                                   = _withPopulationMembers n 
    member this.WithSeed                           s   
                                                   = _withSeed s 
    member this.WithStepsizeWeight                 w   
                                                   = _withStepsizeWeight w 
    member this.WithStrategy                       s   
                                                   = _withStrategy s 
