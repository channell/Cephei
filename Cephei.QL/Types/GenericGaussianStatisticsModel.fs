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
  This class wraps a somewhat generic statistic tool and adds a number of gaussian risk measures (e.g.: value-at-risk, expected shortfall, etc.) based on the mean and variance provided by the underlying statistic tool.

  </summary> *)
[<AutoSerializable(true)>]
type GenericGaussianStatisticsModel<'Stat when 'Stat :> IGeneralStatistics and 'Stat : (new : unit -> 'Stat)>
    ( s                                            : ICell<'Stat>
    ) as this =

    inherit Model<GenericGaussianStatistics<'Stat>> ()
(*
    Parameters
*)
    let _s                                         = s
(*
    Functions
*)
    let _GenericGaussianStatistics                 = cell (fun () -> new GenericGaussianStatistics<'Stat> (s.Value))
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.add(value.Value, weight.Value)
                                                                     _GenericGaussianStatistics.Value)
    let _addSequence                               (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.addSequence(data.Value, weight.Value)
                                                                     _GenericGaussianStatistics.Value)
    let _errorEstimate                             = triv (fun () -> _GenericGaussianStatistics.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.expectationValue(f.Value, inRange.Value))
    let _gaussianAverageShortfall                  (target : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianAverageShortfall(target.Value))
    let _gaussianDownsideDeviation                 = triv (fun () -> _GenericGaussianStatistics.Value.gaussianDownsideDeviation())
    let _gaussianDownsideVariance                  = triv (fun () -> _GenericGaussianStatistics.Value.gaussianDownsideVariance())
    let _gaussianExpectedShortfall                 (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianExpectedShortfall(percentile.Value))
    let _gaussianPercentile                        (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianPercentile(percentile.Value))
    let _gaussianPotentialUpside                   (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianPotentialUpside(percentile.Value))
    let _gaussianRegret                            (target : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianRegret(target.Value))
    let _gaussianShortfall                         (target : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianShortfall(target.Value))
    let _gaussianTopPercentile                     (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianTopPercentile(percentile.Value))
    let _gaussianValueAtRisk                       (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianValueAtRisk(percentile.Value))
    let _kurtosis                                  = triv (fun () -> _GenericGaussianStatistics.Value.kurtosis())
    let _max                                       = triv (fun () -> _GenericGaussianStatistics.Value.max())
    let _mean                                      = triv (fun () -> _GenericGaussianStatistics.Value.mean())
    let _min                                       = triv (fun () -> _GenericGaussianStatistics.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.percentile(percent.Value))
    let _reset                                     = triv (fun () -> _GenericGaussianStatistics.Value.reset()
                                                                     _GenericGaussianStatistics.Value)
    let _samples                                   = triv (fun () -> _GenericGaussianStatistics.Value.samples())
    let _skewness                                  = triv (fun () -> _GenericGaussianStatistics.Value.skewness())
    let _standardDeviation                         = triv (fun () -> _GenericGaussianStatistics.Value.standardDeviation())
    let _variance                                  = triv (fun () -> _GenericGaussianStatistics.Value.variance())
    let _weightSum                                 = triv (fun () -> _GenericGaussianStatistics.Value.weightSum())
    do this.Bind(_GenericGaussianStatistics)

(* 
    Externally visible/bindable properties
*)
    member this.s                                  = _s 
    member this.Add                                value weight   
                                                   = _add value weight 
    member this.AddSequence                        data weight   
                                                   = _addSequence data weight 
    member this.ErrorEstimate                      = _errorEstimate
    member this.ExpectationValue                   f inRange   
                                                   = _expectationValue f inRange 
    member this.GaussianAverageShortfall           target   
                                                   = _gaussianAverageShortfall target 
    member this.GaussianDownsideDeviation          = _gaussianDownsideDeviation
    member this.GaussianDownsideVariance           = _gaussianDownsideVariance
    member this.GaussianExpectedShortfall          percentile   
                                                   = _gaussianExpectedShortfall percentile 
    member this.GaussianPercentile                 percentile   
                                                   = _gaussianPercentile percentile 
    member this.GaussianPotentialUpside            percentile   
                                                   = _gaussianPotentialUpside percentile 
    member this.GaussianRegret                     target   
                                                   = _gaussianRegret target 
    member this.GaussianShortfall                  target   
                                                   = _gaussianShortfall target 
    member this.GaussianTopPercentile              percentile   
                                                   = _gaussianTopPercentile percentile 
    member this.GaussianValueAtRisk                percentile   
                                                   = _gaussianValueAtRisk percentile 
    member this.Kurtosis                           = _kurtosis
    member this.Max                                = _max
    member this.Mean                               = _mean
    member this.Min                                = _min
    member this.Percentile                         percent   
                                                   = _percentile percent 
    member this.Reset                              = _reset
    member this.Samples                            = _samples
    member this.Skewness                           = _skewness
    member this.StandardDeviation                  = _standardDeviation
    member this.Variance                           = _variance
    member this.WeightSum                          = _weightSum
(* <summary>
  This class wraps a somewhat generic statistic tool and adds a number of gaussian risk measures (e.g.: value-at-risk, expected shortfall, etc.) based on the mean and variance provided by the underlying statistic tool.

  </summary> *)
[<AutoSerializable(true)>]
type GenericGaussianStatisticsModel1<'Stat when 'Stat :> IGeneralStatistics and 'Stat : (new : unit -> 'Stat)>
    () as this =
    inherit Model<GenericGaussianStatistics<'Stat>> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _GenericGaussianStatistics                 = cell (fun () -> new GenericGaussianStatistics<'Stat> ())
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.add(value.Value, weight.Value)
                                                                     _GenericGaussianStatistics.Value)
    let _addSequence                               (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.addSequence(data.Value, weight.Value)
                                                                     _GenericGaussianStatistics.Value)
    let _errorEstimate                             = triv (fun () -> _GenericGaussianStatistics.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.expectationValue(f.Value, inRange.Value))
    let _gaussianAverageShortfall                  (target : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianAverageShortfall(target.Value))
    let _gaussianDownsideDeviation                 = triv (fun () -> _GenericGaussianStatistics.Value.gaussianDownsideDeviation())
    let _gaussianDownsideVariance                  = triv (fun () -> _GenericGaussianStatistics.Value.gaussianDownsideVariance())
    let _gaussianExpectedShortfall                 (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianExpectedShortfall(percentile.Value))
    let _gaussianPercentile                        (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianPercentile(percentile.Value))
    let _gaussianPotentialUpside                   (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianPotentialUpside(percentile.Value))
    let _gaussianRegret                            (target : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianRegret(target.Value))
    let _gaussianShortfall                         (target : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianShortfall(target.Value))
    let _gaussianTopPercentile                     (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianTopPercentile(percentile.Value))
    let _gaussianValueAtRisk                       (percentile : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.gaussianValueAtRisk(percentile.Value))
    let _kurtosis                                  = triv (fun () -> _GenericGaussianStatistics.Value.kurtosis())
    let _max                                       = triv (fun () -> _GenericGaussianStatistics.Value.max())
    let _mean                                      = triv (fun () -> _GenericGaussianStatistics.Value.mean())
    let _min                                       = triv (fun () -> _GenericGaussianStatistics.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = triv (fun () -> _GenericGaussianStatistics.Value.percentile(percent.Value))
    let _reset                                     = triv (fun () -> _GenericGaussianStatistics.Value.reset()
                                                                     _GenericGaussianStatistics.Value)
    let _samples                                   = triv (fun () -> _GenericGaussianStatistics.Value.samples())
    let _skewness                                  = triv (fun () -> _GenericGaussianStatistics.Value.skewness())
    let _standardDeviation                         = triv (fun () -> _GenericGaussianStatistics.Value.standardDeviation())
    let _variance                                  = triv (fun () -> _GenericGaussianStatistics.Value.variance())
    let _weightSum                                 = triv (fun () -> _GenericGaussianStatistics.Value.weightSum())
    do this.Bind(_GenericGaussianStatistics)

(* 
    Externally visible/bindable properties
*)
    member this.Add                                value weight   
                                                   = _add value weight 
    member this.AddSequence                        data weight   
                                                   = _addSequence data weight 
    member this.ErrorEstimate                      = _errorEstimate
    member this.ExpectationValue                   f inRange   
                                                   = _expectationValue f inRange 
    member this.GaussianAverageShortfall           target   
                                                   = _gaussianAverageShortfall target 
    member this.GaussianDownsideDeviation          = _gaussianDownsideDeviation
    member this.GaussianDownsideVariance           = _gaussianDownsideVariance
    member this.GaussianExpectedShortfall          percentile   
                                                   = _gaussianExpectedShortfall percentile 
    member this.GaussianPercentile                 percentile   
                                                   = _gaussianPercentile percentile 
    member this.GaussianPotentialUpside            percentile   
                                                   = _gaussianPotentialUpside percentile 
    member this.GaussianRegret                     target   
                                                   = _gaussianRegret target 
    member this.GaussianShortfall                  target   
                                                   = _gaussianShortfall target 
    member this.GaussianTopPercentile              percentile   
                                                   = _gaussianTopPercentile percentile 
    member this.GaussianValueAtRisk                percentile   
                                                   = _gaussianValueAtRisk percentile 
    member this.Kurtosis                           = _kurtosis
    member this.Max                                = _max
    member this.Mean                               = _mean
    member this.Min                                = _min
    member this.Percentile                         percent   
                                                   = _percentile percent 
    member this.Reset                              = _reset
    member this.Samples                            = _samples
    member this.Skewness                           = _skewness
    member this.StandardDeviation                  = _standardDeviation
    member this.Variance                           = _variance
    member this.WeightSum                          = _weightSum
