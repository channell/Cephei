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
  Helper class for precomputed distributions
required for generics
  </summary> *)
[<AutoSerializable(true)>]
type StatsHolderModel
    ( mean                                         : ICell<double>
    , standardDeviation                            : ICell<double>
    ) as this =

    inherit Model<StatsHolder> ()
(*
    Parameters
*)
    let _mean                                      = mean
    let _standardDeviation                         = standardDeviation
(*
    Functions
*)
    let mutable
        _StatsHolder                               = make (fun () -> new StatsHolder (mean.Value, standardDeviation.Value))
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.add(value.Value, weight.Value)
                                                                                  _StatsHolder.Value)
    let _addSequence                               (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.addSequence(data.Value, weight.Value)
                                                                                  _StatsHolder.Value)
    let _errorEstimate                             = triv _StatsHolder (fun () -> _StatsHolder.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.expectationValue(f.Value, inRange.Value))
    let _kurtosis                                  = triv _StatsHolder (fun () -> _StatsHolder.Value.kurtosis())
    let _max                                       = triv _StatsHolder (fun () -> _StatsHolder.Value.max())
    let _mean                                      = triv _StatsHolder (fun () -> _StatsHolder.Value.mean())
    let _min                                       = triv _StatsHolder (fun () -> _StatsHolder.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.percentile(percent.Value))
    let _reset                                     = triv _StatsHolder (fun () -> _StatsHolder.Value.reset()
                                                                                  _StatsHolder.Value)
    let _samples                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.samples())
    let _skewness                                  = triv _StatsHolder (fun () -> _StatsHolder.Value.skewness())
    let _standardDeviation                         = triv _StatsHolder (fun () -> _StatsHolder.Value.standardDeviation())
    let _variance                                  = triv _StatsHolder (fun () -> _StatsHolder.Value.variance())
    let _weightSum                                 = triv _StatsHolder (fun () -> _StatsHolder.Value.weightSum())
    do this.Bind(_StatsHolder)
(* 
    casting 
*)
    internal new () = new StatsHolderModel(null,null)
    member internal this.Inject v = _StatsHolder <- v
    static member Cast (p : ICell<StatsHolder>) = 
        if p :? StatsHolderModel then 
            p :?> StatsHolderModel
        else
            let o = new StatsHolderModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.mean                               = _mean 
    member this.standardDeviation                  = _standardDeviation 
    member this.Add                                value weight   
                                                   = _add value weight 
    member this.AddSequence                        data weight   
                                                   = _addSequence data weight 
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
(* <summary>
  Helper class for precomputed distributions

  </summary> *)
[<AutoSerializable(true)>]
type StatsHolderModel1
    () as this =
    inherit Model<StatsHolder> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _StatsHolder                               = make (fun () -> new StatsHolder ())
    let _add                                       (value : ICell<double>) (weight : ICell<double>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.add(value.Value, weight.Value)
                                                                                  _StatsHolder.Value)
    let _addSequence                               (data : ICell<Generic.List<double>>) (weight : ICell<Generic.List<double>>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.addSequence(data.Value, weight.Value)
                                                                                  _StatsHolder.Value)
    let _errorEstimate                             = triv _StatsHolder (fun () -> _StatsHolder.Value.errorEstimate())
    let _expectationValue                          (f : ICell<Func<KeyValuePair<double,double>,double>>) (inRange : ICell<Func<KeyValuePair<double,double>,bool>>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.expectationValue(f.Value, inRange.Value))
    let _kurtosis                                  = triv _StatsHolder (fun () -> _StatsHolder.Value.kurtosis())
    let _max                                       = triv _StatsHolder (fun () -> _StatsHolder.Value.max())
    let _mean                                      = triv _StatsHolder (fun () -> _StatsHolder.Value.mean())
    let _min                                       = triv _StatsHolder (fun () -> _StatsHolder.Value.min())
    let _percentile                                (percent : ICell<double>)   
                                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.percentile(percent.Value))
    let _reset                                     = triv _StatsHolder (fun () -> _StatsHolder.Value.reset()
                                                                                  _StatsHolder.Value)
    let _samples                                   = triv _StatsHolder (fun () -> _StatsHolder.Value.samples())
    let _skewness                                  = triv _StatsHolder (fun () -> _StatsHolder.Value.skewness())
    let _standardDeviation                         = triv _StatsHolder (fun () -> _StatsHolder.Value.standardDeviation())
    let _variance                                  = triv _StatsHolder (fun () -> _StatsHolder.Value.variance())
    let _weightSum                                 = triv _StatsHolder (fun () -> _StatsHolder.Value.weightSum())
    do this.Bind(_StatsHolder)
(* 
    casting 
*)
    
    member internal this.Inject v = _StatsHolder <- v
    static member Cast (p : ICell<StatsHolder>) = 
        if p :? StatsHolderModel1 then 
            p :?> StatsHolderModel1
        else
            let o = new StatsHolderModel1 ()
            o.Inject p
            o.Bind p
            o
                            

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
