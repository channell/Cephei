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
  f(t) = [ a + b*t ] e^{-c*t} + d following Rebonato's notation.

  </summary> *)
[<AutoSerializable(true)>]
type AbcdMathFunctionModel
    ( abcd                                         : ICell<Generic.List<double>>
    ) as this =

    inherit Model<AbcdMathFunction> ()
(*
    Parameters
*)
    let _abcd                                      = abcd
(*
    Functions
*)
    let _AbcdMathFunction                          = cell (fun () -> new AbcdMathFunction (abcd.Value))
    let _a                                         = triv (fun () -> _AbcdMathFunction.Value.a())
    let _b                                         = triv (fun () -> _AbcdMathFunction.Value.b())
    let _c                                         = triv (fun () -> _AbcdMathFunction.Value.c())
    let _coefficients                              = triv (fun () -> _AbcdMathFunction.Value.coefficients())
    let _d                                         = triv (fun () -> _AbcdMathFunction.Value.d())
    let _definiteDerivativeCoefficients            (t : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.definiteDerivativeCoefficients(t.Value, t2.Value))
    let _definiteIntegral                          (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.definiteIntegral(t1.Value, t2.Value))
    let _definiteIntegralCoefficients              (t : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.definiteIntegralCoefficients(t.Value, t2.Value))
    let _derivative                                (t : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.derivative(t.Value))
    let _derivativeCoefficients                    = triv (fun () -> _AbcdMathFunction.Value.derivativeCoefficients())
    let _longTermValue                             = triv (fun () -> _AbcdMathFunction.Value.longTermValue())
    let _maximumLocation                           = triv (fun () -> _AbcdMathFunction.Value.maximumLocation())
    let _maximumValue                              = triv (fun () -> _AbcdMathFunction.Value.maximumValue())
    let _primitive                                 (t : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.primitive(t.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.value(t.Value))
    do this.Bind(_AbcdMathFunction)

(* 
    Externally visible/bindable properties
*)
    member this.abcd                               = _abcd 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.C                                  = _c
    member this.Coefficients                       = _coefficients
    member this.D                                  = _d
    member this.DefiniteDerivativeCoefficients     t t2   
                                                   = _definiteDerivativeCoefficients t t2 
    member this.DefiniteIntegral                   t1 t2   
                                                   = _definiteIntegral t1 t2 
    member this.DefiniteIntegralCoefficients       t t2   
                                                   = _definiteIntegralCoefficients t t2 
    member this.Derivative                         t   
                                                   = _derivative t 
    member this.DerivativeCoefficients             = _derivativeCoefficients
    member this.LongTermValue                      = _longTermValue
    member this.MaximumLocation                    = _maximumLocation
    member this.MaximumValue                       = _maximumValue
    member this.Primitive                          t   
                                                   = _primitive t 
    member this.Value                              t   
                                                   = _value t 
(* <summary>
  f(t) = [ a + b*t ] e^{-c*t} + d following Rebonato's notation.

  </summary> *)
[<AutoSerializable(true)>]
type AbcdMathFunctionModel1
    ( a                                            : ICell<double>
    , b                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    ) as this =

    inherit Model<AbcdMathFunction> ()
(*
    Parameters
*)
    let _a                                         = a
    let _b                                         = b
    let _c                                         = c
    let _d                                         = d
(*
    Functions
*)
    let _AbcdMathFunction                          = cell (fun () -> new AbcdMathFunction (a.Value, b.Value, c.Value, d.Value))
    let _a                                         = triv (fun () -> _AbcdMathFunction.Value.a())
    let _b                                         = triv (fun () -> _AbcdMathFunction.Value.b())
    let _c                                         = triv (fun () -> _AbcdMathFunction.Value.c())
    let _coefficients                              = triv (fun () -> _AbcdMathFunction.Value.coefficients())
    let _d                                         = triv (fun () -> _AbcdMathFunction.Value.d())
    let _definiteDerivativeCoefficients            (t : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.definiteDerivativeCoefficients(t.Value, t2.Value))
    let _definiteIntegral                          (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.definiteIntegral(t1.Value, t2.Value))
    let _definiteIntegralCoefficients              (t : ICell<double>) (t2 : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.definiteIntegralCoefficients(t.Value, t2.Value))
    let _derivative                                (t : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.derivative(t.Value))
    let _derivativeCoefficients                    = triv (fun () -> _AbcdMathFunction.Value.derivativeCoefficients())
    let _longTermValue                             = triv (fun () -> _AbcdMathFunction.Value.longTermValue())
    let _maximumLocation                           = triv (fun () -> _AbcdMathFunction.Value.maximumLocation())
    let _maximumValue                              = triv (fun () -> _AbcdMathFunction.Value.maximumValue())
    let _primitive                                 (t : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.primitive(t.Value))
    let _value                                     (t : ICell<double>)   
                                                   = triv (fun () -> _AbcdMathFunction.Value.value(t.Value))
    do this.Bind(_AbcdMathFunction)

(* 
    Externally visible/bindable properties
*)
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.c                                  = _c 
    member this.d                                  = _d 
    member this.A                                  = _a
    member this.B                                  = _b
    member this.C                                  = _c
    member this.Coefficients                       = _coefficients
    member this.D                                  = _d
    member this.DefiniteDerivativeCoefficients     t t2   
                                                   = _definiteDerivativeCoefficients t t2 
    member this.DefiniteIntegral                   t1 t2   
                                                   = _definiteIntegral t1 t2 
    member this.DefiniteIntegralCoefficients       t t2   
                                                   = _definiteIntegralCoefficients t t2 
    member this.Derivative                         t   
                                                   = _derivative t 
    member this.DerivativeCoefficients             = _derivativeCoefficients
    member this.LongTermValue                      = _longTermValue
    member this.MaximumLocation                    = _maximumLocation
    member this.MaximumValue                       = _maximumValue
    member this.Primitive                          t   
                                                   = _primitive t 
    member this.Value                              t   
                                                   = _value t 
