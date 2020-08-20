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
  f(t) = t^i}

  </summary> *)
[<AutoSerializable(true)>]
type PolynomialFunctionModel
    ( coeff                                        : ICell<Generic.List<double>>
    ) as this =

    inherit Model<PolynomialFunction> ()
(*
    Parameters
*)
    let _coeff                                     = coeff
(*
    Functions
*)
    let _PolynomialFunction                        = cell (fun () -> new PolynomialFunction (coeff.Value))
    let _coefficients                              = cell (fun () -> _PolynomialFunction.Value.coefficients())
    let _definiteDerivativeCoefficients            (t : ICell<double>) (t2 : ICell<double>)   
                                                   = cell (fun () -> _PolynomialFunction.Value.definiteDerivativeCoefficients(t.Value, t2.Value))
    let _definiteIntegral                          (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = cell (fun () -> _PolynomialFunction.Value.definiteIntegral(t1.Value, t2.Value))
    let _definiteIntegralCoefficients              (t : ICell<double>) (t2 : ICell<double>)   
                                                   = cell (fun () -> _PolynomialFunction.Value.definiteIntegralCoefficients(t.Value, t2.Value))
    let _derivative                                (t : ICell<double>)   
                                                   = cell (fun () -> _PolynomialFunction.Value.derivative(t.Value))
    let _derivativeCoefficients                    = cell (fun () -> _PolynomialFunction.Value.derivativeCoefficients())
    let _order                                     = cell (fun () -> _PolynomialFunction.Value.order())
    let _primitive                                 (t : ICell<double>)   
                                                   = cell (fun () -> _PolynomialFunction.Value.primitive(t.Value))
    let _primitiveCoefficients                     = cell (fun () -> _PolynomialFunction.Value.primitiveCoefficients())
    let _value                                     (t : ICell<double>)   
                                                   = cell (fun () -> _PolynomialFunction.Value.value(t.Value))
    do this.Bind(_PolynomialFunction)

(* 
    Externally visible/bindable properties
*)
    member this.coeff                              = _coeff 
    member this.Coefficients                       = _coefficients
    member this.DefiniteDerivativeCoefficients     t t2   
                                                   = _definiteDerivativeCoefficients t t2 
    member this.DefiniteIntegral                   t1 t2   
                                                   = _definiteIntegral t1 t2 
    member this.DefiniteIntegralCoefficients       t t2   
                                                   = _definiteIntegralCoefficients t t2 
    member this.Derivative                         t   
                                                   = _derivative t 
    member this.DerivativeCoefficients             = _derivativeCoefficients
    member this.Order                              = _order
    member this.Primitive                          t   
                                                   = _primitive t 
    member this.PrimitiveCoefficients              = _primitiveCoefficients
    member this.Value                              t   
                                                   = _value t 
