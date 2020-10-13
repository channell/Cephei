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
  linear regression y_i = a_0 + a_1*x_0 +..+a_n*x_{n-1} + eps
! multi dimensional linear regression
  </summary> *)
[<AutoSerializable(true)>]
type LinearRegressionModel
    ( x                                            : ICell<Generic.List<Generic.List<double>>>
    , y                                            : ICell<Generic.List<double>>
    ) as this =

    inherit Model<LinearRegression> ()
(*
    Parameters
*)
    let _x                                         = x
    let _y                                         = y
(*
    Functions
*)
    let _LinearRegression                          = cell (fun () -> new LinearRegression (x.Value, y.Value))
    let _coefficients                              = triv (fun () -> _LinearRegression.Value.coefficients())
    let _residuals                                 = triv (fun () -> _LinearRegression.Value.residuals())
    let _standardErrors                            = triv (fun () -> _LinearRegression.Value.standardErrors())
    do this.Bind(_LinearRegression)
(* 
    casting 
*)
    internal new () = new LinearRegressionModel(null,null)
    member internal this.Inject v = _LinearRegression.Value <- v
    static member Cast (p : ICell<LinearRegression>) = 
        if p :? LinearRegressionModel then 
            p :?> LinearRegressionModel
        else
            let o = new LinearRegressionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x                                  = _x 
    member this.y                                  = _y 
    member this.Coefficients                       = _coefficients
    member this.Residuals                          = _residuals
    member this.StandardErrors                     = _standardErrors
(* <summary>
  linear regression y_i = a_0 + a_1*x_0 +..+a_n*x_{n-1} + eps
! one dimensional linear regression
  </summary> *)
[<AutoSerializable(true)>]
type LinearRegressionModel1
    ( x                                            : ICell<Generic.List<double>>
    , y                                            : ICell<Generic.List<double>>
    ) as this =

    inherit Model<LinearRegression> ()
(*
    Parameters
*)
    let _x                                         = x
    let _y                                         = y
(*
    Functions
*)
    let _LinearRegression                          = cell (fun () -> new LinearRegression (x.Value, y.Value))
    let _coefficients                              = triv (fun () -> _LinearRegression.Value.coefficients())
    let _residuals                                 = triv (fun () -> _LinearRegression.Value.residuals())
    let _standardErrors                            = triv (fun () -> _LinearRegression.Value.standardErrors())
    do this.Bind(_LinearRegression)
(* 
    casting 
*)
    internal new () = new LinearRegressionModel1(null,null)
    member internal this.Inject v = _LinearRegression.Value <- v
    static member Cast (p : ICell<LinearRegression>) = 
        if p :? LinearRegressionModel1 then 
            p :?> LinearRegressionModel1
        else
            let o = new LinearRegressionModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.x                                  = _x 
    member this.y                                  = _y 
    member this.Coefficients                       = _coefficients
    member this.Residuals                          = _residuals
    member this.StandardErrors                     = _standardErrors
