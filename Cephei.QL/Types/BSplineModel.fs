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
  Follows treatment and notation from:  Weisstein, Eric W. "B-Spline." From MathWorld--A Wolfram Web Resource.  <http://mathworld.wolfram.com/B-Spline.html>  (p+1) order B-spline (or p degree polynomial) basis functions N_{i,p}(x), i = 0,1,2 n with n+1 control points, or equivalently, an associated knot vector of size p+n+2 defined at the increasingly sorted points (x_0, x_1 x_{n+p+1}) A linear B-spline has p=1 quadratic B-spline has p=2 a cubic B-spline has p=3 etc.

  </summary> *)
[<AutoSerializable(true)>]
type BSplineModel
    ( p                                            : ICell<int>
    , n                                            : ICell<int>
    , knots                                        : ICell<Generic.List<double>>
    ) as this =

    inherit Model<BSpline> ()
(*
    Parameters
*)
    let _p                                         = p
    let _n                                         = n
    let _knots                                     = knots
(*
    Functions
*)
    let mutable
        _BSpline                                   = cell (fun () -> new BSpline (p.Value, n.Value, knots.Value))
    let _value                                     (i : ICell<int>) (x : ICell<double>)   
                                                   = triv (fun () -> _BSpline.Value.value(i.Value, x.Value))
    do this.Bind(_BSpline)
(* 
    casting 
*)
    internal new () = new BSplineModel(null,null,null)
    member internal this.Inject v = _BSpline <- v
    static member Cast (p : ICell<BSpline>) = 
        if p :? BSplineModel then 
            p :?> BSplineModel
        else
            let o = new BSplineModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.p                                  = _p 
    member this.n                                  = _n 
    member this.knots                              = _knots 
    member this.Value                              i x   
                                                   = _value i x 
