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
  Uses the Brownian-bridge correction for the barrier found in
<i> Going to Extremes: Correcting Simulation Bias in Exotic Option Valuation - D.R. Beaglehole, P.H. Dybvig and G. Zhou Financial Analysts Journal; Jan/Feb 1997; 53, 1. pg. 62-68
</i> and
<i> Simulating path-dependent options: A new approach - M. El Babsiri and G. Noel Journal of Derivatives; Winter 1998; 6, 2; pg. 65-83
</i>  barrierengines  the correctness of the returned value is tested by reproducing results available in literature.

  </summary> *)
[<AutoSerializable(true)>]
type MCBarrierEngineModel<'RNG, 'S when 'RNG :> IRSG and 'RNG : (new : unit -> 'RNG) and 'S :> IGeneralStatistics and 'S : (new : unit -> 'S)>
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , timeSteps                                    : ICell<Nullable<int>>
    , timeStepsPerYear                             : ICell<Nullable<int>>
    , brownianBridge                               : ICell<bool>
    , antitheticVariate                            : ICell<bool>
    , requiredSamples                              : ICell<Nullable<int>>
    , requiredTolerance                            : ICell<Nullable<double>>
    , maxSamples                                   : ICell<Nullable<int>>
    , isBiased                                     : ICell<bool>
    , seed                                         : ICell<uint64>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<MCBarrierEngine<'RNG,'S>> ()
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
    let _isBiased                                  = isBiased
    let _seed                                      = seed
(*
    Functions
*)
    let mutable
        _MCBarrierEngine                           = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new MCBarrierEngine<'RNG,'S> (Process.Value, timeSteps.Value, timeStepsPerYear.Value, brownianBridge.Value, antitheticVariate.Value, requiredSamples.Value, requiredTolerance.Value, maxSamples.Value, isBiased.Value, seed.Value))))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.registerWith(handler.Value)
                                                                     _MCBarrierEngine.Value)
    let _reset                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.reset()
                                                                     _MCBarrierEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.unregisterWith(handler.Value)
                                                                     _MCBarrierEngine.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.update()
                                                                     _MCBarrierEngine.Value)
    let _errorEstimate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.errorEstimate())
    let _sampleAccumulator                         = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.sampleAccumulator())
    let _value                                     (tolerance : ICell<double>) (maxSamples : ICell<int>) (minSamples : ICell<int>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.value(tolerance.Value, maxSamples.Value, minSamples.Value))
    let _valueWithSamples                          (samples : ICell<int>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _MCBarrierEngine).Value.valueWithSamples(samples.Value))
    do this.Bind(_MCBarrierEngine)

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
    member this.isBiased                           = _isBiased 
    member this.seed                               = _seed 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.Reset                              = _reset
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
    member this.ErrorEstimate                      = _errorEstimate
    member this.SampleAccumulator                  = _sampleAccumulator
    member this.Value                              tolerance maxSamples minSamples   
                                                   = _value tolerance maxSamples minSamples 
    member this.ValueWithSamples                   samples   
                                                   = _valueWithSamples samples 
