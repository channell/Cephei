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
  Given x between zero and one as the integral value of a gaussian normal distribution this class provides the value y such that formula here ...  It uses Beasly and Springer approximation, with an improved approximation for the tails. See Boris Moro, "The Full Monte", 1995, Risk Magazine.  This class can also be used to generate a gaussian normal distribution from a uniform distribution. This is especially useful when a gaussian normal distribution is generated from a low discrepancy uniform distribution: in this case the traditional Box-Muller approach and its variants would not preserve the sequence's low-discrepancy.  Peter J. Acklam's approximation is better and is available as QuantLib::InverseCumulativeNormal

  </summary> *)
[<AutoSerializable(true)>]
type MoroInverseCumulativeNormalModel
    ( average                                      : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<MoroInverseCumulativeNormal> ()
(*
    Parameters
*)
    let _average                                   = average
    let _sigma                                     = sigma
(*
    Functions
*)
    let mutable
        _MoroInverseCumulativeNormal               = make (fun () -> new MoroInverseCumulativeNormal (average.Value, sigma.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _MoroInverseCumulativeNormal (fun () -> _MoroInverseCumulativeNormal.Value.value(x.Value))
    do this.Bind(_MoroInverseCumulativeNormal)
(* 
    casting 
*)
    internal new () = new MoroInverseCumulativeNormalModel(null,null)
    member internal this.Inject v = _MoroInverseCumulativeNormal <- v
    static member Cast (p : ICell<MoroInverseCumulativeNormal>) = 
        if p :? MoroInverseCumulativeNormalModel then 
            p :?> MoroInverseCumulativeNormalModel
        else
            let o = new MoroInverseCumulativeNormalModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.average                            = _average 
    member this.sigma                              = _sigma 
    member this.Value                              x   
                                                   = _value x 
