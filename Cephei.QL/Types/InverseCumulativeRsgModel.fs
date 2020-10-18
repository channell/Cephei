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
  It uses a sequence of uniform deviate in (0, 1) as the source of cumulative distribution values. Then an inverse cumulative distribution is used to calculate the distribution deviate.  The uniform deviate sequence is supplied by USG. The inverse cumulative distribution is supplied by IC.

  </summary> *)
[<AutoSerializable(true)>]
type InverseCumulativeRsgModel<'USG, 'IC when 'USG :> IRNG and 'IC :> IValue>
    ( uniformSequenceGenerator                     : ICell<'USG>
    , inverseCumulative                            : ICell<'IC>
    ) as this =

    inherit Model<InverseCumulativeRsg<'USG,'IC>> ()
(*
    Parameters
*)
    let _uniformSequenceGenerator                  = uniformSequenceGenerator
    let _inverseCumulative                         = inverseCumulative
(*
    Functions
*)
    let mutable
        _InverseCumulativeRsg                      = cell (fun () -> new InverseCumulativeRsg<'USG,'IC> (uniformSequenceGenerator.Value, inverseCumulative.Value))
    let _dimension                                 = triv (fun () -> _InverseCumulativeRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv (fun () -> _InverseCumulativeRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv (fun () -> _InverseCumulativeRsg.Value.lastSequence())
    let _nextSequence                              = triv (fun () -> _InverseCumulativeRsg.Value.nextSequence())
    do this.Bind(_InverseCumulativeRsg)

(* 
    Externally visible/bindable properties
*)
    member this.uniformSequenceGenerator           = _uniformSequenceGenerator 
    member this.inverseCumulative                  = _inverseCumulative 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextSequence                       = _nextSequence
(* <summary>
  It uses a sequence of uniform deviate in (0, 1) as the source of cumulative distribution values. Then an inverse cumulative distribution is used to calculate the distribution deviate.  The uniform deviate sequence is supplied by USG. The inverse cumulative distribution is supplied by IC.

  </summary> *)
[<AutoSerializable(true)>]
type InverseCumulativeRsgModel1<'USG, 'IC when 'USG :> IRNG and 'IC :> IValue>
    ( uniformSequenceGenerator                     : ICell<'USG>
    ) as this =

    inherit Model<InverseCumulativeRsg<'USG,'IC>> ()
(*
    Parameters
*)
    let _uniformSequenceGenerator                  = uniformSequenceGenerator
(*
    Functions
*)
    let mutable
        _InverseCumulativeRsg                      = cell (fun () -> new InverseCumulativeRsg<'USG,'IC> (uniformSequenceGenerator.Value))
    let _dimension                                 = triv (fun () -> _InverseCumulativeRsg.Value.dimension())
    let _factory                                   (dimensionality : ICell<int>) (seed : ICell<uint64>)   
                                                   = triv (fun () -> _InverseCumulativeRsg.Value.factory(dimensionality.Value, seed.Value))
    let _lastSequence                              = triv (fun () -> _InverseCumulativeRsg.Value.lastSequence())
    let _nextSequence                              = triv (fun () -> _InverseCumulativeRsg.Value.nextSequence())
    do this.Bind(_InverseCumulativeRsg)

(* 
    Externally visible/bindable properties
*)
    member this.uniformSequenceGenerator           = _uniformSequenceGenerator 
    member this.Dimension                          = _dimension
    member this.Factory                            dimensionality seed   
                                                   = _factory dimensionality seed 
    member this.LastSequence                       = _lastSequence
    member this.NextSequence                       = _nextSequence
