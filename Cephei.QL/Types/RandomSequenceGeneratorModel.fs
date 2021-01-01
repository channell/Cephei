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
  Random sequence generator based on a pseudo-random number generator RNG. Do not use with low-discrepancy sequence generator.

  </summary> *)
[<AutoSerializable(true)>]
type RandomSequenceGeneratorModel<'RNG when 'RNG :> IRNGTraits and 'RNG : (new : unit -> 'RNG)>
    ( dimensionality                               : ICell<int>
    , seed                                         : ICell<uint64>
    ) as this =

    inherit Model<RandomSequenceGenerator<'RNG>> ()
(*
    Parameters
*)
    let _dimensionality                            = dimensionality
    let _seed                                      = seed
(*
    Functions
*)
    let mutable
        _RandomSequenceGenerator                   = make (fun () -> new RandomSequenceGenerator<'RNG> (dimensionality.Value, seed.Value))
    let _dimension                                 = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.lastSequence())
    let _nextInt32Sequence                         = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.nextInt32Sequence())
    let _nextSequence                              = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.nextSequence())
    do this.Bind(_RandomSequenceGenerator)

(* 
    Externally visible/bindable properties
*)
    member this.dimensionality                     = _dimensionality 
    member this.seed                               = _seed 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextInt32Sequence                  = _nextInt32Sequence
    member this.NextSequence                       = _nextSequence
(* <summary>
  Random sequence generator based on a pseudo-random number generator RNG. Do not use with low-discrepancy sequence generator.

  </summary> *)
[<AutoSerializable(true)>]
type RandomSequenceGeneratorModel1<'RNG when 'RNG :> IRNGTraits and 'RNG : (new : unit -> 'RNG)>
    ( dimensionality                               : ICell<int>
    , rng                                          : ICell<'RNG>
    ) as this =

    inherit Model<RandomSequenceGenerator<'RNG>> ()
(*
    Parameters
*)
    let _dimensionality                            = dimensionality
    let _rng                                       = rng
(*
    Functions
*)
    let mutable
        _RandomSequenceGenerator                   = make (fun () -> new RandomSequenceGenerator<'RNG> (dimensionality.Value, rng.Value))
    let _dimension                                 = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.lastSequence())
    let _nextInt32Sequence                         = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.nextInt32Sequence())
    let _nextSequence                              = triv _RandomSequenceGenerator (fun () -> _RandomSequenceGenerator.Value.nextSequence())
    do this.Bind(_RandomSequenceGenerator)

(* 
    Externally visible/bindable properties
*)
    member this.dimensionality                     = _dimensionality 
    member this.rng                                = _rng 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextInt32Sequence                  = _nextInt32Sequence
    member this.NextSequence                       = _nextSequence
