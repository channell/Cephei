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
  RSG is a sample generator which returns a random sequence.  the generated paths are checked against cached results

  </summary> *)
[<AutoSerializable(true)>]
type MultiPathGeneratorModel<'GSG when 'GSG :> IRNG>
    ( Process                                      : ICell<StochasticProcess>
    , times                                        : ICell<TimeGrid>
    , generator                                    : ICell<'GSG>
    , brownianBridge                               : ICell<bool>
    ) as this =

    inherit Model<MultiPathGenerator<'GSG>> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _times                                     = times
    let _generator                                 = generator
    let _brownianBridge                            = brownianBridge
(*
    Functions
*)
    let mutable
        _MultiPathGenerator                        = cell (fun () -> new MultiPathGenerator<'GSG> (Process.Value, times.Value, generator.Value, brownianBridge.Value))
    let _antithetic                                = triv (fun () -> _MultiPathGenerator.Value.antithetic())
    let _next                                      = triv (fun () -> _MultiPathGenerator.Value.next())
    do this.Bind(_MultiPathGenerator)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.times                              = _times 
    member this.generator                          = _generator 
    member this.brownianBridge                     = _brownianBridge 
    member this.Antithetic                         = _antithetic
    member this.Next                               = _next
