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
  Given x, it returns its probability in a Gaussian normal distribution. It provides the first derivative too.  the correctness of the returned value is tested by checking it against numerical calculations. Cross-checks are also performed against the CumulativeNormalDistribution and InverseCumulativeNormal classes.

  </summary> *)
[<AutoSerializable(true)>]
type NormalDistributionModel
    () as this =
    inherit Model<NormalDistribution> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _NormalDistribution                        = cell (fun () -> new NormalDistribution ())
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _NormalDistribution.Value.derivative(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _NormalDistribution.Value.value(x.Value))
    do this.Bind(_NormalDistribution)
(* 
    casting 
*)
    
    member internal this.Inject v = _NormalDistribution <- v
    static member Cast (p : ICell<NormalDistribution>) = 
        if p :? NormalDistributionModel then 
            p :?> NormalDistributionModel
        else
            let o = new NormalDistributionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Derivative                         x   
                                                   = _derivative x 
    member this.Value                              x   
                                                   = _value x 
(* <summary>
  Given x, it returns its probability in a Gaussian normal distribution. It provides the first derivative too.  the correctness of the returned value is tested by checking it against numerical calculations. Cross-checks are also performed against the CumulativeNormalDistribution and InverseCumulativeNormal classes.

  </summary> *)
[<AutoSerializable(true)>]
type NormalDistributionModel1
    ( average                                      : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<NormalDistribution> ()
(*
    Parameters
*)
    let _average                                   = average
    let _sigma                                     = sigma
(*
    Functions
*)
    let mutable
        _NormalDistribution                        = cell (fun () -> new NormalDistribution (average.Value, sigma.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _NormalDistribution.Value.derivative(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _NormalDistribution.Value.value(x.Value))
    do this.Bind(_NormalDistribution)
(* 
    casting 
*)
    internal new () = new NormalDistributionModel1(null,null)
    member internal this.Inject v = _NormalDistribution <- v
    static member Cast (p : ICell<NormalDistribution>) = 
        if p :? NormalDistributionModel1 then 
            p :?> NormalDistributionModel1
        else
            let o = new NormalDistributionModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.average                            = _average 
    member this.sigma                              = _sigma 
    member this.Derivative                         x   
                                                   = _derivative x 
    member this.Value                              x   
                                                   = _value x 
