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
  This class wraps a somewhat generic statistic tool and adds a number of risk measures (e.g.: value-at-risk, expected shortfall, etc.) based on the data distribution as reported by the underlying statistic tool.  add historical annualized volatility
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type GenericRiskStatisticsModel<'Stat when 'Stat :> IGeneralStatistics and 'Stat : (new : unit -> 'Stat)>
    () as this =
    inherit Model<GenericRiskStatistics<'Stat>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _GenericRiskStatistics                     = cell (fun () -> new GenericRiskStatistics<'Stat> ())
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.add(value.Value, weight.Value)
                                                                     _GenericRiskStatistics.Value)
    let _addSequence                               (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.addSequence(data.Value, weight.Value)
                                                                     _GenericRiskStatistics.Value)
    let _averageShortfall                          (target : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.averageShortfall(target.Value))
    let _downsideDeviation                         = cell (fun () -> _GenericRiskStatistics.Value.downsideDeviation())
    let _downsideVariance                          = cell (fun () -> _GenericRiskStatistics.Value.downsideVariance())
    let _errorEstimate                             = cell (fun () -> _GenericRiskStatistics.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.expectationValue(f.Value, inRange.Value))
    let _expectedShortfall                         (centile : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.expectedShortfall(centile.Value))
    let _kurtosis                                  = cell (fun () -> _GenericRiskStatistics.Value.kurtosis())
    let _max                                       = cell (fun () -> _GenericRiskStatistics.Value.max())
    let _mean                                      = cell (fun () -> _GenericRiskStatistics.Value.mean())
    let _min                                       = cell (fun () -> _GenericRiskStatistics.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.percentile(percent.Value))
    let _potentialUpside                           (centile : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.potentialUpside(centile.Value))
    let _regret                                    (target : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.regret(target.Value))
    let _reset                                     = cell (fun () -> _GenericRiskStatistics.Value.reset()
                                                                     _GenericRiskStatistics.Value)
    let _samples                                   = cell (fun () -> _GenericRiskStatistics.Value.samples())
    let _semiDeviation                             = cell (fun () -> _GenericRiskStatistics.Value.semiDeviation())
    let _semiVariance                              = cell (fun () -> _GenericRiskStatistics.Value.semiVariance())
    let _shortfall                                 (target : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.shortfall(target.Value))
    let _skewness                                  = cell (fun () -> _GenericRiskStatistics.Value.skewness())
    let _standardDeviation                         = cell (fun () -> _GenericRiskStatistics.Value.standardDeviation())
    let _valueAtRisk                               (centile : ICell<double>)   
                                                   = cell (fun () -> _GenericRiskStatistics.Value.valueAtRisk(centile.Value))
    let _variance                                  = cell (fun () -> _GenericRiskStatistics.Value.variance())
    let _weightSum                                 = cell (fun () -> _GenericRiskStatistics.Value.weightSum())
    do this.Bind(_GenericRiskStatistics)

(* 
    Externally visible/bindable properties
*)
    member this.Add                                value weight   
                                                   = _add value weight 
    member this.AddSequence                        data weight   
                                                   = _addSequence data weight 
    member this.AverageShortfall                   target   
                                                   = _averageShortfall target 
    member this.DownsideDeviation                  = _downsideDeviation
    member this.DownsideVariance                   = _downsideVariance
    member this.ErrorEstimate                      = _errorEstimate
    member this.ExpectationValue                   f inRange   
                                                   = _expectationValue f inRange 
    member this.ExpectedShortfall                  centile   
                                                   = _expectedShortfall centile 
    member this.Kurtosis                           = _kurtosis
    member this.Max                                = _max
    member this.Mean                               = _mean
    member this.Min                                = _min
    member this.Percentile                         percent   
                                                   = _percentile percent 
    member this.PotentialUpside                    centile   
                                                   = _potentialUpside centile 
    member this.Regret                             target   
                                                   = _regret target 
    member this.Reset                              = _reset
    member this.Samples                            = _samples
    member this.SemiDeviation                      = _semiDeviation
    member this.SemiVariance                       = _semiVariance
    member this.Shortfall                          target   
                                                   = _shortfall target 
    member this.Skewness                           = _skewness
    member this.StandardDeviation                  = _standardDeviation
    member this.ValueAtRisk                        centile   
                                                   = _valueAtRisk centile 
    member this.Variance                           = _variance
    member this.WeightSum                          = _weightSum
