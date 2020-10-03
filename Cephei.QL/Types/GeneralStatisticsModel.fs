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
  This class accumulates a set of data and returns their statistics (e.g: mean, variance, skewness, kurtosis, error estimation, percentile, etc.) based on the empirical distribution (no gaussian assumption)  It doesn't suffer the numerical instability problem of IncrementalStatistics. The downside is that it stores all samples, thus increasing the memory requirements.

  </summary> *)
[<AutoSerializable(true)>]
type GeneralStatisticsModel
    () as this =
    inherit Model<GeneralStatistics> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _GeneralStatistics                         = cell (fun () -> new GeneralStatistics ())
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = triv (fun () -> _GeneralStatistics.Value.add(value.Value, weight.Value)
                                                                     _GeneralStatistics.Value)
    let _add1                                      (value : ICell<double>)   
                                                   = triv (fun () -> _GeneralStatistics.Value.add(value.Value)
                                                                     _GeneralStatistics.Value)
    let _addSequence                               (list : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _GeneralStatistics.Value.addSequence(list.Value)
                                                                     _GeneralStatistics.Value)
    let _addSequence1                              (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _GeneralStatistics.Value.addSequence(data.Value, weight.Value)
                                                                     _GeneralStatistics.Value)
    let _data                                      = triv (fun () -> _GeneralStatistics.Value.data())
    let _errorEstimate                             = triv (fun () -> _GeneralStatistics.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = triv (fun () -> _GeneralStatistics.Value.expectationValue(f.Value, inRange.Value))
    let _kurtosis                                  = triv (fun () -> _GeneralStatistics.Value.kurtosis())
    let _max                                       = triv (fun () -> _GeneralStatistics.Value.max())
    let _mean                                      = triv (fun () -> _GeneralStatistics.Value.mean())
    let _min                                       = triv (fun () -> _GeneralStatistics.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = triv (fun () -> _GeneralStatistics.Value.percentile(percent.Value))
    let _reset                                     = triv (fun () -> _GeneralStatistics.Value.reset()
                                                                     _GeneralStatistics.Value)
    let _samples                                   = triv (fun () -> _GeneralStatistics.Value.samples())
    let _skewness                                  = triv (fun () -> _GeneralStatistics.Value.skewness())
    let _sort                                      = triv (fun () -> _GeneralStatistics.Value.sort()
                                                                     _GeneralStatistics.Value)
    let _standardDeviation                         = triv (fun () -> _GeneralStatistics.Value.standardDeviation())
    let _topPercentile                             (percent : ICell<double>)   
                                                   = triv (fun () -> _GeneralStatistics.Value.topPercentile(percent.Value))
    let _variance                                  = triv (fun () -> _GeneralStatistics.Value.variance())
    let _weightSum                                 = triv (fun () -> _GeneralStatistics.Value.weightSum())
    do this.Bind(_GeneralStatistics)
(* 
    casting 
*)
    
    member internal this.Inject v = _GeneralStatistics.Value <- v
    static member Cast (p : ICell<GeneralStatistics>) = 
        if p :? GeneralStatisticsModel then 
            p :?> GeneralStatisticsModel
        else
            let o = new GeneralStatisticsModel ()
            o.Inject p.Value
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
    member this.Data                               = _data
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
    member this.Sort                               = _sort
    member this.StandardDeviation                  = _standardDeviation
    member this.TopPercentile                      percent   
                                                   = _topPercentile percent 
    member this.Variance                           = _variance
    member this.WeightSum                          = _weightSum
