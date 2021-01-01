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
  Generates random paths with drift(S,t) and variance(S,t) using a gaussian sequence generator  mcarlo  the generated paths are checked against cached results

  </summary> *)
[<AutoSerializable(true)>]
type PathGeneratorModel<'GSG when 'GSG :> IRNG>
    ( Process                                      : ICell<StochasticProcess>
    , timeGrid                                     : ICell<TimeGrid>
    , generator                                    : ICell<'GSG>
    , brownianBridge                               : ICell<bool>
    ) as this =

    inherit Model<PathGenerator<'GSG>> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _timeGrid                                  = timeGrid
    let _generator                                 = generator
    let _brownianBridge                            = brownianBridge
(*
    Functions
*)
    let mutable
        _PathGenerator                             = make (fun () -> new PathGenerator<'GSG> (Process.Value, timeGrid.Value, generator.Value, brownianBridge.Value))
    let _antithetic                                = triv _PathGenerator (fun () -> _PathGenerator.Value.antithetic())
    let _next                                      = triv _PathGenerator (fun () -> _PathGenerator.Value.next())
    do this.Bind(_PathGenerator)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeGrid                           = _timeGrid 
    member this.generator                          = _generator 
    member this.brownianBridge                     = _brownianBridge 
    member this.Antithetic                         = _antithetic
    member this.Next                               = _next
(* <summary>
  Generates random paths with drift(S,t) and variance(S,t) using a gaussian sequence generator  mcarlo  the generated paths are checked against cached results
constructors
  </summary> *)
[<AutoSerializable(true)>]
type PathGeneratorModel1<'GSG when 'GSG :> IRNG>
    ( Process                                      : ICell<StochasticProcess>
    , length                                       : ICell<double>
    , timeSteps                                    : ICell<int>
    , generator                                    : ICell<'GSG>
    , brownianBridge                               : ICell<bool>
    ) as this =

    inherit Model<PathGenerator<'GSG>> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _length                                    = length
    let _timeSteps                                 = timeSteps
    let _generator                                 = generator
    let _brownianBridge                            = brownianBridge
(*
    Functions
*)
    let mutable
        _PathGenerator                             = make (fun () -> new PathGenerator<'GSG> (Process.Value, length.Value, timeSteps.Value, generator.Value, brownianBridge.Value))
    let _antithetic                                = triv _PathGenerator (fun () -> _PathGenerator.Value.antithetic())
    let _next                                      = triv _PathGenerator (fun () -> _PathGenerator.Value.next())
    do this.Bind(_PathGenerator)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.length                             = _length 
    member this.timeSteps                          = _timeSteps 
    member this.generator                          = _generator 
    member this.brownianBridge                     = _brownianBridge 
    member this.Antithetic                         = _antithetic
    member this.Next                               = _next
