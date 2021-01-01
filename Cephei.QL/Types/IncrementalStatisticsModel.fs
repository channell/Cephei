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
  It can accumulate a set of data and return statistics (e.g: mean, variance, skewness, kurtosis, error estimation, etc.)  high moments are numerically unstable for high average/standardDeviation ratios.

  </summary> *)
[<AutoSerializable(true)>]
type IncrementalStatisticsModel
    () as this =
    inherit Model<IncrementalStatistics> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _IncrementalStatistics                     = make (fun () -> new IncrementalStatistics ())
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.add(value.Value, weight.Value)
                                                                                            _IncrementalStatistics.Value)
    let _add1                                      (value : ICell<double>)   
                                                   = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.add(value.Value)
                                                                                            _IncrementalStatistics.Value)
    let _addSequence                               (list : ICell<Generic.List<double>>)   
                                                   = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.addSequence(list.Value)
                                                                                            _IncrementalStatistics.Value)
    let _addSequence1                              (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.addSequence(data.Value, weight.Value)
                                                                                            _IncrementalStatistics.Value)
    let _downsideDeviation                         = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.downsideDeviation())
    let _downsideVariance                          = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.downsideVariance())
    let _errorEstimate                             = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.expectationValue(f.Value, inRange.Value))
    let _kurtosis                                  = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.kurtosis())
    let _max                                       = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.max())
    let _mean                                      = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.mean())
    let _min                                       = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.percentile(percent.Value))
    let _reset                                     = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.reset()
                                                                                            _IncrementalStatistics.Value)
    let _samples                                   = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.samples())
    let _skewness                                  = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.skewness())
    let _standardDeviation                         = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.standardDeviation())
    let _variance                                  = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.variance())
    let _weightSum                                 = triv _IncrementalStatistics (fun () -> _IncrementalStatistics.Value.weightSum())
    do this.Bind(_IncrementalStatistics)
(* 
    casting 
*)
    
    member internal this.Inject v = _IncrementalStatistics <- v
    static member Cast (p : ICell<IncrementalStatistics>) = 
        if p :? IncrementalStatisticsModel then 
            p :?> IncrementalStatisticsModel
        else
            let o = new IncrementalStatisticsModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Add                                value weight   
                                                   = _add value weight 
    member this.Add1                               value   
                                                   = _add1 value 
    member this.AddSequence                        list   
                                                   = _addSequence list 
    member this.AddSequence1                       data weight   
                                                   = _addSequence1 data weight 
    member this.DownsideDeviation                  = _downsideDeviation
    member this.DownsideVariance                   = _downsideVariance
    member this.ErrorEstimate                      = _errorEstimate
    member this.ExpectationValue                   f inRange   
                                                   = _expectationValue f inRange 
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
