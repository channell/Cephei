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
  Gaussian kernel function

  </summary> *)
[<AutoSerializable(true)>]
type GaussianKernelModel
    ( average                                      : ICell<double>
    , sigma                                        : ICell<double>
    ) as this =

    inherit Model<GaussianKernel> ()
(*
    Parameters
*)
    let _average                                   = average
    let _sigma                                     = sigma
(*
    Functions
*)
    let mutable
        _GaussianKernel                            = make (fun () -> new GaussianKernel (average.Value, sigma.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv _GaussianKernel (fun () -> _GaussianKernel.Value.derivative(x.Value))
    let _primitive                                 (x : ICell<double>)   
                                                   = triv _GaussianKernel (fun () -> _GaussianKernel.Value.primitive(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv _GaussianKernel (fun () -> _GaussianKernel.Value.value(x.Value))
    do this.Bind(_GaussianKernel)
(* 
    casting 
*)
    internal new () = new GaussianKernelModel(null,null)
    member internal this.Inject v = _GaussianKernel <- v
    static member Cast (p : ICell<GaussianKernel>) = 
        if p :? GaussianKernelModel then 
            p :?> GaussianKernelModel
        else
            let o = new GaussianKernelModel ()
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
    member this.Primitive                          x   
                                                   = _primitive x 
    member this.Value                              x   
                                                   = _value x 
