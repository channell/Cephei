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
  Halton algorithm for low-discrepancy sequence.  For more details see chapter 8, paragraph 2 of "Monte Carlo Methods in Finance", by Peter Jäckel  - the correctness of the returned values is tested by reproducing known good values. - the correctness of the returned values is tested by checking their discrepancy against known good values.

  </summary> *)
[<AutoSerializable(true)>]
type HaltonRsgModel
    ( dimensionality                               : ICell<int>
    , seed                                         : ICell<uint64>
    , randomStart                                  : ICell<bool>
    , randomShift                                  : ICell<bool>
    ) as this =

    inherit Model<HaltonRsg> ()
(*
    Parameters
*)
    let _dimensionality                            = dimensionality
    let _seed                                      = seed
    let _randomStart                               = randomStart
    let _randomShift                               = randomShift
(*
    Functions
*)
    let _HaltonRsg                                 = cell (fun () -> new HaltonRsg (dimensionality.Value, seed.Value, randomStart.Value, randomShift.Value))
    let _dimension                                 = cell (fun () -> _HaltonRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = cell (fun () -> _HaltonRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = cell (fun () -> _HaltonRsg.Value.lastSequence())
    let _nextSequence                              = cell (fun () -> _HaltonRsg.Value.nextSequence())
    do this.Bind(_HaltonRsg)

(* 
    Externally visible/bindable properties
*)
    member this.dimensionality                     = _dimensionality 
    member this.seed                               = _seed 
    member this.randomStart                        = _randomStart 
    member this.randomShift                        = _randomShift 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextSequence                       = _nextSequence
