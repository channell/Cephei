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
  Gauss-Gegenbauer polynomial

  </summary> *)
[<AutoSerializable(true)>]
type GaussGegenbauerPolynomialModel
    ( lambda                                       : ICell<double>
    ) as this =

    inherit Model<GaussGegenbauerPolynomial> ()
(*
    Parameters
*)
    let _lambda                                    = lambda
(*
    Functions
*)
    let _GaussGegenbauerPolynomial                 = cell (fun () -> new GaussGegenbauerPolynomial (lambda.Value))
    let _alpha                                     (i : ICell<int>)   
                                                   = triv (fun () -> _GaussGegenbauerPolynomial.Value.alpha(i.Value))
    let _beta                                      (i : ICell<int>)   
                                                   = triv (fun () -> _GaussGegenbauerPolynomial.Value.beta(i.Value))
    let _mu_0                                      = triv (fun () -> _GaussGegenbauerPolynomial.Value.mu_0())
    let _w                                         (x : ICell<double>)   
                                                   = triv (fun () -> _GaussGegenbauerPolynomial.Value.w(x.Value))
    let _value                                     (n : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _GaussGegenbauerPolynomial.Value.value(n.Value, x.Value))
    let _weightedValue                             (n : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _GaussGegenbauerPolynomial.Value.weightedValue(n.Value, x.Value))
    do this.Bind(_GaussGegenbauerPolynomial)
(* 
    casting 
*)
    internal new () = GaussGegenbauerPolynomialModel(null)
    member internal this.Inject v = _GaussGegenbauerPolynomial.Value <- v
    static member Cast (p : ICell<GaussGegenbauerPolynomial>) = 
        if p :? GaussGegenbauerPolynomialModel then 
            p :?> GaussGegenbauerPolynomialModel
        else
            let o = new GaussGegenbauerPolynomialModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.lambda                             = _lambda 
    member this.Alpha                              i   
                                                   = _alpha i 
    member this.Beta                               i   
                                                   = _beta i 
    member this.Mu_0                               = _mu_0
    member this.W                                  x   
                                                   = _w x 
    member this.Value                              n x   
                                                   = _value n x 
    member this.WeightedValue                      n x   
                                                   = _weightedValue n x 
