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
  Mersenne Twister random number generator of period 2**19937-1  For more details see http://www.math.keio.ac.jp/matumoto/emt.html  the correctness of the returned values is tested by checking them against known good results.

  </summary> *)
[<AutoSerializable(true)>]
type MersenneTwisterUniformRngModel
    ( seed                                         : ICell<uint64>
    ) as this =

    inherit Model<MersenneTwisterUniformRng> ()
(*
    Parameters
*)
    let _seed                                      = seed
(*
    Functions
*)
    let _MersenneTwisterUniformRng                 = cell (fun () -> new MersenneTwisterUniformRng (seed.Value))
    let _factory                                   (seed : ICell<uint64>)   
                                                   = cell (fun () -> _MersenneTwisterUniformRng.Value.factory(seed.Value))
    let _next                                      = cell (fun () -> _MersenneTwisterUniformRng.Value.next())
    let _nextInt32                                 = cell (fun () -> _MersenneTwisterUniformRng.Value.nextInt32())
    let _nextReal                                  = cell (fun () -> _MersenneTwisterUniformRng.Value.nextReal())
    do this.Bind(_MersenneTwisterUniformRng)

(* 
    Externally visible/bindable properties
*)
    member this.seed                               = _seed 
    member this.Factory                            seed   
                                                   = _factory seed 
    member this.Next                               = _next
    member this.NextInt32                          = _nextInt32
    member this.NextReal                           = _nextReal
(* <summary>
  Mersenne Twister random number generator of period 2**19937-1  For more details see http://www.math.keio.ac.jp/matumoto/emt.html  the correctness of the returned values is tested by checking them against known good results.
! if the given seed is 0, a random seed will be chosen based on clock()
  </summary> *)
[<AutoSerializable(true)>]
type MersenneTwisterUniformRngModel1
    () as this =
    inherit Model<MersenneTwisterUniformRng> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _MersenneTwisterUniformRng                 = cell (fun () -> new MersenneTwisterUniformRng ())
    let _factory                                   (seed : ICell<uint64>)   
                                                   = cell (fun () -> _MersenneTwisterUniformRng.Value.factory(seed.Value))
    let _next                                      = cell (fun () -> _MersenneTwisterUniformRng.Value.next())
    let _nextInt32                                 = cell (fun () -> _MersenneTwisterUniformRng.Value.nextInt32())
    let _nextReal                                  = cell (fun () -> _MersenneTwisterUniformRng.Value.nextReal())
    do this.Bind(_MersenneTwisterUniformRng)

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            seed   
                                                   = _factory seed 
    member this.Next                               = _next
    member this.NextInt32                          = _nextInt32
    member this.NextReal                           = _nextReal
(* <summary>
  Mersenne Twister random number generator of period 2**19937-1  For more details see http://www.math.keio.ac.jp/matumoto/emt.html  the correctness of the returned values is tested by checking them against known good results.

  </summary> *)
[<AutoSerializable(true)>]
type MersenneTwisterUniformRngModel2
    ( seeds                                        : ICell<Generic.List<uint64>>
    ) as this =

    inherit Model<MersenneTwisterUniformRng> ()
(*
    Parameters
*)
    let _seeds                                     = seeds
(*
    Functions
*)
    let _MersenneTwisterUniformRng                 = cell (fun () -> new MersenneTwisterUniformRng (seeds.Value))
    let _factory                                   (seed : ICell<uint64>)   
                                                   = cell (fun () -> _MersenneTwisterUniformRng.Value.factory(seed.Value))
    let _next                                      = cell (fun () -> _MersenneTwisterUniformRng.Value.next())
    let _nextInt32                                 = cell (fun () -> _MersenneTwisterUniformRng.Value.nextInt32())
    let _nextReal                                  = cell (fun () -> _MersenneTwisterUniformRng.Value.nextReal())
    do this.Bind(_MersenneTwisterUniformRng)

(* 
    Externally visible/bindable properties
*)
    member this.seeds                              = _seeds 
    member this.Factory                            seed   
                                                   = _factory seed 
    member this.Next                               = _next
    member this.NextInt32                          = _nextInt32
    member this.NextReal                           = _nextReal
