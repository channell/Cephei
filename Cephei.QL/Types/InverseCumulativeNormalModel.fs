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
  Given x between zero and one as the integral value of a gaussian normal distribution this class provides the value y such that formula here ...  It use Acklam's approximation: by Peter J. Acklam, University of Oslo, Statistics Division. URL: http://home.online.no/~pjacklam/notes/invnorm/index.html  This class can also be used to generate a gaussian normal distribution from a uniform distribution. This is especially useful when a gaussian normal distribution is generated from a low discrepancy uniform distribution: in this case the traditional Box-Muller approach and its variants would not preserve the sequence's low-discrepancy.

  </summary> *)
[<AutoSerializable(true)>]
type InverseCumulativeNormalModel
    () as this =
    inherit Model<InverseCumulativeNormal> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _InverseCumulativeNormal                   = cell (fun () -> new InverseCumulativeNormal ())
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _InverseCumulativeNormal.Value.value(x.Value))
    do this.Bind(_InverseCumulativeNormal)
(* 
    casting 
*)
    
    member internal this.Inject v = _InverseCumulativeNormal.Value <- v
    static member Cast (p : ICell<InverseCumulativeNormal>) = 
        if p :? InverseCumulativeNormalModel then 
            p :?> InverseCumulativeNormalModel
        else
            let o = new InverseCumulativeNormalModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Value                              x   
                                                   = _value x 
(* <summary>
  Given x between zero and one as the integral value of a gaussian normal distribution this class provides the value y such that formula here ...  It use Acklam's approximation: by Peter J. Acklam, University of Oslo, Statistics Division. URL: http://home.online.no/~pjacklam/notes/invnorm/index.html  This class can also be used to generate a gaussian normal distribution from a uniform distribution. This is especially useful when a gaussian normal distribution is generated from a low discrepancy uniform distribution: in this case the traditional Box-Muller approach and its variants would not preserve the sequence's low-discrepancy.

  </summary> *)
[<AutoSerializable(true)>]
type InverseCumulativeNormalModel1
    ( average                                      : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<InverseCumulativeNormal> ()
(*
    Parameters
*)
    let _average                                   = average
    let _sigma                                     = sigma
(*
    Functions
*)
    let _InverseCumulativeNormal                   = cell (fun () -> new InverseCumulativeNormal (average.Value, sigma.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _InverseCumulativeNormal.Value.value(x.Value))
    do this.Bind(_InverseCumulativeNormal)
(* 
    casting 
*)
    internal new () = new InverseCumulativeNormalModel1(null,null)
    member internal this.Inject v = _InverseCumulativeNormal.Value <- v
    static member Cast (p : ICell<InverseCumulativeNormal>) = 
        if p :? InverseCumulativeNormalModel1 then 
            p :?> InverseCumulativeNormalModel1
        else
            let o = new InverseCumulativeNormalModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.average                            = _average 
    member this.sigma                              = _sigma 
    member this.Value                              x   
                                                   = _value x 
