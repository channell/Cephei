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
Interface class to map the functionality of SobolBrownianGenerator to the "conventional" sequence generator interface

  </summary> *)
[<AutoSerializable(true)>]
type SobolBrownianBridgeRsgModel
    ( factors                                      : ICell<int>
    , steps                                        : ICell<int>
    , ordering                                     : ICell<SobolBrownianGenerator.Ordering>
    , seed                                         : ICell<uint64>
    , directionIntegers                            : ICell<SobolRsg.DirectionIntegers>
    ) as this =

    inherit Model<SobolBrownianBridgeRsg> ()
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
    let _SobolBrownianBridgeRsg                    = cell (fun () -> new SobolBrownianBridgeRsg (factors.Value, steps.Value, ordering.Value, seed.Value, directionIntegers.Value))
    let _dimension                                 = cell (fun () -> _SobolBrownianBridgeRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = cell (fun () -> _SobolBrownianBridgeRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = cell (fun () -> _SobolBrownianBridgeRsg.Value.lastSequence())
    let _nextSequence                              = cell (fun () -> _SobolBrownianBridgeRsg.Value.nextSequence())
    do this.Bind(_SobolBrownianBridgeRsg)

(* 
    Externally visible/bindable properties
*)
    member this.factors                            = _factors 
    member this.steps                              = _steps 
    member this.ordering                           = _ordering 
    member this.seed                               = _seed 
    member this.directionIntegers                  = _directionIntegers 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextSequence                       = _nextSequence
