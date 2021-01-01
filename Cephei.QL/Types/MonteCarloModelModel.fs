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
  The template arguments of this class correspond to available policies for the particular model to be instantiated---i.e., whether it is single- or multi-asset, or whether it should use pseudo-random or low-discrepancy numbers for path generation. Such decisions are grouped in trait classes so as to be orthogonal---see mctraits for examples.  The constructor accepts two safe references, i.e. two smart pointers, one to a path generator and the other to a path pricer.  In case of control variate technique the user should provide the additional control option, namely the option path pricer and the option value.  mcarlo

  </summary> *)
[<AutoSerializable(true)>]
type MonteCarloModelModel<'MC, 'RNG, 'S when 'S :> IGeneralStatistics>
    ( pathGenerator                                : ICell<IPathGenerator<IRNG>>
    , pathPricer                                   : ICell<PathPricer<IPath>>
    , sampleAccumulator                            : ICell<'S>
    , antitheticVariate                            : ICell<bool>
    , cvPathPricer                                 : ICell<PathPricer<IPath>>
    , cvOptionValue                                : ICell<double>
    , cvPathGenerator                              : ICell<IPathGenerator<IRNG>>
    ) as this =

    inherit Model<MonteCarloModel<'MC,'RNG,'S>> ()
(*
    Parameters
*)
    let _pathGenerator                             = pathGenerator
    let _pathPricer                                = pathPricer
    let _sampleAccumulator                         = sampleAccumulator
    let _antitheticVariate                         = antitheticVariate
    let _cvPathPricer                              = cvPathPricer
    let _cvOptionValue                             = cvOptionValue
    let _cvPathGenerator                           = cvPathGenerator
(*
    Functions
*)
    let mutable
        _MonteCarloModel                           = make (fun () -> new MonteCarloModel<'MC,'RNG,'S> (pathGenerator.Value, pathPricer.Value, sampleAccumulator.Value, antitheticVariate.Value, cvPathPricer.Value, cvOptionValue.Value, cvPathGenerator.Value))
    let _addSamples                                (samples : ICell<int>)   
                                                   = triv _MonteCarloModel (fun () -> _MonteCarloModel.Value.addSamples(samples.Value)
                                                                                      _MonteCarloModel.Value)
    let _sampleAccumulator                         = triv _MonteCarloModel (fun () -> _MonteCarloModel.Value.sampleAccumulator())
    do this.Bind(_MonteCarloModel)

(* 
    Externally visible/bindable properties
*)
    member this.pathGenerator                      = _pathGenerator 
    member this.pathPricer                         = _pathPricer 
    member this.sampleAccumulator                  = _sampleAccumulator 
    member this.antitheticVariate                  = _antitheticVariate 
    member this.cvPathPricer                       = _cvPathPricer 
    member this.cvOptionValue                      = _cvOptionValue 
    member this.cvPathGenerator                    = _cvPathGenerator 
    member this.AddSamples                         samples   
                                                   = _addSamples samples 
    member this.SampleAccumulator                  = _sampleAccumulator
