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
  Gauss-Laguerre polynomial

  </summary> *)
[<AutoSerializable(true)>]
type GaussLaguerrePolynomialModel
    () as this =
    inherit Model<GaussLaguerrePolynomial> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _GaussLaguerrePolynomial                   = make (fun () -> new GaussLaguerrePolynomial ())
    let _alpha                                     (i : ICell<int>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.alpha(i.Value))
    let _beta                                      (i : ICell<int>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.beta(i.Value))
    let _mu_0                                      = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.mu_0())
    let _w                                         (x : ICell<double>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.w(x.Value))
    let _value                                     (n : ICell<int>) (x : ICell<double>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.value(n.Value, x.Value))
    let _weightedValue                             (n : ICell<int>) (x : ICell<double>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.weightedValue(n.Value, x.Value))
    do this.Bind(_GaussLaguerrePolynomial)
(* 
    casting 
*)
    
    member internal this.Inject v = _GaussLaguerrePolynomial <- v
    static member Cast (p : ICell<GaussLaguerrePolynomial>) = 
        if p :? GaussLaguerrePolynomialModel then 
            p :?> GaussLaguerrePolynomialModel
        else
            let o = new GaussLaguerrePolynomialModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
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
(* <summary>
  Gauss-Laguerre polynomial

  </summary> *)
[<AutoSerializable(true)>]
type GaussLaguerrePolynomialModel1
    ( s                                            : ICell<double>
    ) as this =

    inherit Model<GaussLaguerrePolynomial> ()
(*
    Parameters
*)
    let _s                                         = s
(*
    Functions
*)
    let mutable
        _GaussLaguerrePolynomial                   = make (fun () -> new GaussLaguerrePolynomial (s.Value))
    let _alpha                                     (i : ICell<int>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.alpha(i.Value))
    let _beta                                      (i : ICell<int>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.beta(i.Value))
    let _mu_0                                      = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.mu_0())
    let _w                                         (x : ICell<double>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.w(x.Value))
    let _value                                     (n : ICell<int>) (x : ICell<double>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.value(n.Value, x.Value))
    let _weightedValue                             (n : ICell<int>) (x : ICell<double>)   
                                                   = triv _GaussLaguerrePolynomial (fun () -> _GaussLaguerrePolynomial.Value.weightedValue(n.Value, x.Value))
    do this.Bind(_GaussLaguerrePolynomial)
(* 
    casting 
*)
    internal new () = new GaussLaguerrePolynomialModel1(null)
    member internal this.Inject v = _GaussLaguerrePolynomial <- v
    static member Cast (p : ICell<GaussLaguerrePolynomial>) = 
        if p :? GaussLaguerrePolynomialModel1 then 
            p :?> GaussLaguerrePolynomialModel1
        else
            let o = new GaussLaguerrePolynomialModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.s                                  = _s 
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
