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
  vanillaengines  the correctness of the returned value is tested by checking it against analytic results.
constructor
  </summary> *)
[<AutoSerializable(true)>]
type MCEuropeanEngineModel<'RNG, 'S when 'RNG :> IRSG and 'RNG : (new : unit -> 'RNG) and 'S :> IGeneralStatistics and 'S : (new : unit -> 'S)>
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<Nullable<int>>
    , timeStepsPerYear                             : ICell<Nullable<int>>
    , brownianBridge                               : ICell<bool>
    , antitheticVariate                            : ICell<bool>
    , requiredSamples                              : ICell<Nullable<int>>
    , requiredTolerance                            : ICell<Nullable<double>>
    , maxSamples                                   : ICell<Nullable<int>>
    , seed                                         : ICell<uint64>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<MCEuropeanEngine<'RNG,'S>> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _Process                                   = Process
    let _timeSteps                                 = timeSteps
    let _timeStepsPerYear                          = timeStepsPerYear
    let _brownianBridge                            = brownianBridge
    let _antitheticVariate                         = antitheticVariate
    let _requiredSamples                           = requiredSamples
    let _requiredTolerance                         = requiredTolerance
    let _maxSamples                                = maxSamples
    let _seed                                      = seed
(*
    Functions
*)
    let mutable
        _MCEuropeanEngine                          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new MCEuropeanEngine<'RNG,'S> (Process.Value, timeSteps.Value, timeStepsPerYear.Value, brownianBridge.Value, antitheticVariate.Value, requiredSamples.Value, requiredTolerance.Value, maxSamples.Value, seed.Value))))
    do this.Bind(_MCEuropeanEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.timeSteps                          = _timeSteps 
    member this.timeStepsPerYear                   = _timeStepsPerYear 
    member this.brownianBridge                     = _brownianBridge 
    member this.antitheticVariate                  = _antitheticVariate 
    member this.requiredSamples                    = _requiredSamples 
    member this.requiredTolerance                  = _requiredTolerance 
    member this.maxSamples                         = _maxSamples 
    member this.seed                               = _seed 
