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
  Incremental Brownian generator using a Sobol generator, inverse-cumulative Gaussian method, and Brownian bridging.

  </summary> *)
[<AutoSerializable(true)>]
type SobolBrownianGeneratorModel
    ( factors                                      : ICell<int>
    , steps                                        : ICell<int>
    , ordering                                     : ICell<SobolBrownianGenerator.Ordering>
    , seed                                         : ICell<uint64>
    , directionIntegers                            : ICell<SobolRsg.DirectionIntegers>
    ) as this =

    inherit Model<SobolBrownianGenerator> ()
(*
    Parameters
*)
    let _factors                                   = factors
    let _steps                                     = steps
    let _ordering                                  = ordering
    let _seed                                      = seed
    let _directionIntegers                         = directionIntegers
(*
    Functions
*)
    let _SobolBrownianGenerator                    = cell (fun () -> new SobolBrownianGenerator (factors.Value, steps.Value, ordering.Value, seed.Value, directionIntegers.Value))
    let _nextPath                                  = triv (fun () -> _SobolBrownianGenerator.Value.nextPath())
    let _nextStep                                  (output : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _SobolBrownianGenerator.Value.nextStep(output.Value))
    let _numberOfFactors                           = triv (fun () -> _SobolBrownianGenerator.Value.numberOfFactors())
    let _numberOfSteps                             = triv (fun () -> _SobolBrownianGenerator.Value.numberOfSteps())
    let _orderedIndices                            = triv (fun () -> _SobolBrownianGenerator.Value.orderedIndices())
    let _transform                                 (variates : ICell<Generic.List<Generic.List<double>>>)   
                                                   = triv (fun () -> _SobolBrownianGenerator.Value.transform(variates.Value))
    do this.Bind(_SobolBrownianGenerator)
(* 
    casting 
*)
    internal new () = SobolBrownianGeneratorModel(null,null,null,null,null)
    member internal this.Inject v = _SobolBrownianGenerator.Value <- v
    static member Cast (p : ICell<SobolBrownianGenerator>) = 
        if p :? SobolBrownianGeneratorModel then 
            p :?> SobolBrownianGeneratorModel
        else
            let o = new SobolBrownianGeneratorModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.factors                            = _factors 
    member this.steps                              = _steps 
    member this.ordering                           = _ordering 
    member this.seed                               = _seed 
    member this.directionIntegers                  = _directionIntegers 
    member this.NextPath                           = _nextPath
    member this.NextStep                           output   
                                                   = _nextStep output 
    member this.NumberOfFactors                    = _numberOfFactors
    member this.NumberOfSteps                      = _numberOfSteps
    member this.OrderedIndices                     = _orderedIndices
    member this.Transform                          variates   
                                                   = _transform variates 
