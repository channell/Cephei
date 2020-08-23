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
  It provides 1-dimensional statistics as discrepancy plus N-dimensional (sequence) statistics (e.g. mean, variance, skewness, kurtosis, etc.) with one component for each dimension of the sample space.  For most of the statistics this class relies on the StatisticsType underlying class to provide 1-D methods that will be iterated for all the components of the N-D data. These lifted methods are the union of all the methods that might be requested to the 1-D underlying StatisticsType class, with the usual compile-time checks provided by the template approach.  the correctness of the returned values is tested by checking them against numerical calculations.

  </summary> *)
[<AutoSerializable(true)>]
type GenericSequenceStatisticsModel<'S when 'S :> IGeneralStatistics and 'S : (new : unit -> 'S)>
    ( dimension                                    : ICell<int>
    ) as this =

    inherit Model<GenericSequenceStatistics<'S>> ()
(*
    Parameters
*)
    let _dimension                                 = dimension
(*
    Functions
*)
    let _GenericSequenceStatistics                 = cell (fun () -> new GenericSequenceStatistics<'S> (dimension.Value))
    let _add                                       (Begin : ICell<Generic.List<double>>) (weight : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.add(Begin.Value, weight.Value)
                                                                     _GenericSequenceStatistics.Value)
    let _add1                                      (Begin : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.add(Begin.Value)
                                                                     _GenericSequenceStatistics.Value)
    let _averageShortfall                          (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.averageShortfall(x.Value))
    let _correlation                               = triv (fun () -> _GenericSequenceStatistics.Value.correlation())
    let _covariance                                = triv (fun () -> _GenericSequenceStatistics.Value.covariance())
    let _downsideDeviation                         = triv (fun () -> _GenericSequenceStatistics.Value.downsideDeviation())
    let _downsideVariance                          = triv (fun () -> _GenericSequenceStatistics.Value.downsideVariance())
    let _errorEstimate                             = triv (fun () -> _GenericSequenceStatistics.Value.errorEstimate())
    let _expectedShortfall                         (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.expectedShortfall(x.Value))
    let _gaussianAverageShortfall                  (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.gaussianAverageShortfall(x.Value))
    let _gaussianExpectedShortfall                 (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.gaussianExpectedShortfall(x.Value))
    let _gaussianPercentile                        (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.gaussianPercentile(x.Value))
    let _gaussianPotentialUpside                   (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.gaussianPotentialUpside(x.Value))
    let _gaussianShortfall                         (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.gaussianShortfall(x.Value))
    let _gaussianValueAtRisk                       (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.gaussianValueAtRisk(x.Value))
    let _kurtosis                                  = triv (fun () -> _GenericSequenceStatistics.Value.kurtosis())
    let _max                                       = triv (fun () -> _GenericSequenceStatistics.Value.max())
    let _mean                                      = triv (fun () -> _GenericSequenceStatistics.Value.mean())
    let _min                                       = triv (fun () -> _GenericSequenceStatistics.Value.min())
    let _percentile                                (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.percentile(x.Value))
    let _potentialUpside                           (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.potentialUpside(x.Value))
    let _regret                                    (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.regret(x.Value))
    let _reset                                     (dimension : ICell<int>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.reset(dimension.Value)
                                                                     _GenericSequenceStatistics.Value)
    let _samples                                   = triv (fun () -> _GenericSequenceStatistics.Value.samples())
    let _semiDeviation                             = triv (fun () -> _GenericSequenceStatistics.Value.semiDeviation())
    let _semiVariance                              = triv (fun () -> _GenericSequenceStatistics.Value.semiVariance())
    let _shortfall                                 (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.shortfall(x.Value))
    let _size                                      = triv (fun () -> _GenericSequenceStatistics.Value.size())
    let _skewness                                  = triv (fun () -> _GenericSequenceStatistics.Value.skewness())
    let _standardDeviation                         = triv (fun () -> _GenericSequenceStatistics.Value.standardDeviation())
    let _valueAtRisk                               (x : ICell<double>)   
                                                   = triv (fun () -> _GenericSequenceStatistics.Value.valueAtRisk(x.Value))
    let _variance                                  = triv (fun () -> _GenericSequenceStatistics.Value.variance())
    let _weightSum                                 = triv (fun () -> _GenericSequenceStatistics.Value.weightSum())
    do this.Bind(_GenericSequenceStatistics)

(* 
    Externally visible/bindable properties
*)
    member this.dimension                          = _dimension 
    member this.Add                                Begin weight   
                                                   = _add Begin weight 
    member this.Add1                               Begin   
                                                   = _add1 Begin 
    member this.AverageShortfall                   x   
                                                   = _averageShortfall x 
    member this.Correlation                        = _correlation
    member this.Covariance                         = _covariance
    member this.DownsideDeviation                  = _downsideDeviation
    member this.DownsideVariance                   = _downsideVariance
    member this.ErrorEstimate                      = _errorEstimate
    member this.ExpectedShortfall                  x   
                                                   = _expectedShortfall x 
    member this.GaussianAverageShortfall           x   
                                                   = _gaussianAverageShortfall x 
    member this.GaussianExpectedShortfall          x   
                                                   = _gaussianExpectedShortfall x 
    member this.GaussianPercentile                 x   
                                                   = _gaussianPercentile x 
    member this.GaussianPotentialUpside            x   
                                                   = _gaussianPotentialUpside x 
    member this.GaussianShortfall                  x   
                                                   = _gaussianShortfall x 
    member this.GaussianValueAtRisk                x   
                                                   = _gaussianValueAtRisk x 
    member this.Kurtosis                           = _kurtosis
    member this.Max                                = _max
    member this.Mean                               = _mean
    member this.Min                                = _min
    member this.Percentile                         x   
                                                   = _percentile x 
    member this.PotentialUpside                    x   
                                                   = _potentialUpside x 
    member this.Regret                             x   
                                                   = _regret x 
    member this.Reset                              dimension   
                                                   = _reset dimension 
    member this.Samples                            = _samples
    member this.SemiDeviation                      = _semiDeviation
    member this.SemiVariance                       = _semiVariance
    member this.Shortfall                          x   
                                                   = _shortfall x 
    member this.Size                               = _size
    member this.Skewness                           = _skewness
    member this.StandardDeviation                  = _standardDeviation
    member this.ValueAtRisk                        x   
                                                   = _valueAtRisk x 
    member this.Variance                           = _variance
    member this.WeightSum                          = _weightSum
