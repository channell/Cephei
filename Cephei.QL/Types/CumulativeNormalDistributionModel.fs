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
  Given x it provides an approximation to the integral of the gaussian normal distribution: formula here ...  For this implementation see M. Abramowitz and I. Stegun, Handbook of Mathematical Functions, Dover Publications, New York (1972)

  </summary> *)
[<AutoSerializable(true)>]
type CumulativeNormalDistributionModel
    () as this =
    inherit Model<CumulativeNormalDistribution> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _CumulativeNormalDistribution              = cell (fun () -> new CumulativeNormalDistribution ())
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _CumulativeNormalDistribution.Value.derivative(x.Value))
    let _value                                     (z : ICell<double>)   
                                                   = triv (fun () -> _CumulativeNormalDistribution.Value.value(z.Value))
    do this.Bind(_CumulativeNormalDistribution)
(* 
    casting 
*)
    
    member internal this.Inject v = _CumulativeNormalDistribution <- v
    static member Cast (p : ICell<CumulativeNormalDistribution>) = 
        if p :? CumulativeNormalDistributionModel then 
            p :?> CumulativeNormalDistributionModel
        else
            let o = new CumulativeNormalDistributionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Derivative                         x   
                                                   = _derivative x 
    member this.Value                              z   
                                                   = _value z 
(* <summary>
  Given x it provides an approximation to the integral of the gaussian normal distribution: formula here ...  For this implementation see M. Abramowitz and I. Stegun, Handbook of Mathematical Functions, Dover Publications, New York (1972)

  </summary> *)
[<AutoSerializable(true)>]
type CumulativeNormalDistributionModel1
    ( average                                      : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<CumulativeNormalDistribution> ()
(*
    Parameters
*)
    let _average                                   = average
    let _sigma                                     = sigma
(*
    Functions
*)
    let mutable
        _CumulativeNormalDistribution              = cell (fun () -> new CumulativeNormalDistribution (average.Value, sigma.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _CumulativeNormalDistribution.Value.derivative(x.Value))
    let _value                                     (z : ICell<double>)   
                                                   = triv (fun () -> _CumulativeNormalDistribution.Value.value(z.Value))
    do this.Bind(_CumulativeNormalDistribution)
(* 
    casting 
*)
    internal new () = new CumulativeNormalDistributionModel1(null,null)
    member internal this.Inject v = _CumulativeNormalDistribution <- v
    static member Cast (p : ICell<CumulativeNormalDistribution>) = 
        if p :? CumulativeNormalDistributionModel1 then 
            p :?> CumulativeNormalDistributionModel1
        else
            let o = new CumulativeNormalDistributionModel1 ()
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
    member this.Value                              z   
                                                   = _value z 
