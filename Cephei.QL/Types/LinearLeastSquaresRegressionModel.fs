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
  References: "Numerical Recipes in C", 2nd edition, Press, Teukolsky, Vetterling, Flannery,  the correctness of the returned values is tested by checking their properties.

  </summary> *)
[<AutoSerializable(true)>]
type LinearLeastSquaresRegressionModel
    ( x                                            : ICell<Generic.List<double>>
    , y                                            : ICell<Generic.List<double>>
    , v                                            : ICell<Generic.List<Func<double,double>>>
    ) as this =

    inherit Model<LinearLeastSquaresRegression> ()
(*
    Parameters
*)
    let _x                                         = x
    let _y                                         = y
    let _v                                         = v
(*
    Functions
*)
    let _LinearLeastSquaresRegression              = cell (fun () -> new LinearLeastSquaresRegression (x.Value, y.Value, v.Value))
    do this.Bind(_LinearLeastSquaresRegression)
(* 
    casting 
*)
    internal new () = LinearLeastSquaresRegressionModel(null,null,null)
    member internal this.Inject v = _LinearLeastSquaresRegression.Value <- v
    static member Cast (p : ICell<LinearLeastSquaresRegression>) = 
        if p :? LinearLeastSquaresRegressionModel then 
            p :?> LinearLeastSquaresRegressionModel
        else
            let o = new LinearLeastSquaresRegressionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x                                  = _x 
    member this.y                                  = _y 
    member this.v                                  = _v 
