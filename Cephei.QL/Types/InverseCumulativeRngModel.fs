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
  It uses a uniform deviate in (0, 1) as the source of cumulative distribution values. Then an inverse cumulative distribution is used to calculate the distribution deviate.  The uniform deviate is supplied by RNG. The inverse cumulative distribution is supplied by IC.

  </summary> *)
[<AutoSerializable(true)>]
type InverseCumulativeRngModel<'RNG, 'IC when 'RNG :> IRNGTraits and 'IC :> IValue and 'IC : (new : unit -> 'IC)>
    ( uniformGenerator                             : ICell<'RNG>
    ) as this =

    inherit Model<InverseCumulativeRng<'RNG,'IC>> ()
(*
    Parameters
*)
    let _uniformGenerator                          = uniformGenerator
(*
    Functions
*)
    let _InverseCumulativeRng                      = cell (fun () -> new InverseCumulativeRng<'RNG,'IC> (uniformGenerator.Value))
    let _next                                      = triv (fun () -> _InverseCumulativeRng.Value.next())
    do this.Bind(_InverseCumulativeRng)

(* 
    Externally visible/bindable properties
*)
    member this.uniformGenerator                   = _uniformGenerator 
    member this.Next                               = _next
