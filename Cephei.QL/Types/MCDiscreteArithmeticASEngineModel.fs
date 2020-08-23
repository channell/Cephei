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

constructor
  </summary> *)
[<AutoSerializable(true)>]
type MCDiscreteArithmeticASEngineModel<'RNG, 'S when 'RNG :> IRSG and 'RNG : (new : unit -> 'RNG) and 'S :> Statistics and 'S : (new : unit -> 'S)>
    ( Process                                      : ICell<GeneralizedBlackScholesProcess>
    , brownianBridge                               : ICell<bool>
    , antitheticVariate                            : ICell<bool>
    , requiredSamples                              : ICell<int>
    , requiredTolerance                            : ICell<double>
    , maxSamples                                   : ICell<int>
    , seed                                         : ICell<uint64>
    ) as this =

    inherit Model<MCDiscreteArithmeticASEngine<'RNG,'S>> ()
(*
    Parameters
*)
    let _Process                                   = Process
    let _brownianBridge                            = brownianBridge
    let _antitheticVariate                         = antitheticVariate
    let _requiredSamples                           = requiredSamples
    let _requiredTolerance                         = requiredTolerance
    let _maxSamples                                = maxSamples
    let _seed                                      = seed
(*
    Functions
*)
    let _MCDiscreteArithmeticASEngine              = cell (fun () -> new MCDiscreteArithmeticASEngine<'RNG,'S> (Process.Value, brownianBridge.Value, antitheticVariate.Value, requiredSamples.Value, requiredTolerance.Value, maxSamples.Value, seed.Value))
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.registerWith(handler.Value)
                                                                     _MCDiscreteArithmeticASEngine.Value)
    let _reset                                     = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.reset()
                                                                     _MCDiscreteArithmeticASEngine.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.unregisterWith(handler.Value)
                                                                     _MCDiscreteArithmeticASEngine.Value)
    let _update                                    = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.update()
                                                                     _MCDiscreteArithmeticASEngine.Value)
    let _errorEstimate                             = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.errorEstimate())
    let _sampleAccumulator                         = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.sampleAccumulator())
    let _value                                     (tolerance : ICell<double>) (maxSamples : ICell<int>) (minSamples : ICell<int>)   
                                                   = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.value(tolerance.Value, maxSamples.Value, minSamples.Value))
    let _valueWithSamples                          (samples : ICell<int>)   
                                                   = triv (fun () -> _MCDiscreteArithmeticASEngine.Value.valueWithSamples(samples.Value))
    do this.Bind(_MCDiscreteArithmeticASEngine)

(* 
    Externally visible/bindable properties
*)
    member this.Process                            = _Process 
    member this.brownianBridge                     = _brownianBridge 
    member this.antitheticVariate                  = _antitheticVariate 
    member this.requiredSamples                    = _requiredSamples 
    member this.requiredTolerance                  = _requiredTolerance 
    member this.maxSamples                         = _maxSamples 
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
