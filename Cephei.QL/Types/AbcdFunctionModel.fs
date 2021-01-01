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
  f(T-t) = [ a + b(T-t) ] e^{-c(T-t)} + d following Rebonato's notation.

  </summary> *)
[<AutoSerializable(true)>]
type AbcdFunctionModel
    ( a                                            : ICell<double>
    , b                                            : ICell<double>
    , c                                            : ICell<double>
    , d                                            : ICell<double>
    ) as this =

    inherit Model<AbcdFunction> ()
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
    let mutable
        _AbcdFunction                              = make (fun () -> new AbcdFunction (a.Value, b.Value, c.Value, d.Value))
    let _covariance                                (t : ICell<double>) (T2 : ICell<double>) (S : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.covariance(t.Value, T2.Value, S.Value))
    let _covariance1                               (t1 : ICell<double>) (t2 : ICell<double>) (T : ICell<double>) (S : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.covariance(t1.Value, t2.Value, T.Value, S.Value))
    let _instantaneousCovariance                   (u : ICell<double>) (T : ICell<double>) (S : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.instantaneousCovariance(u.Value, T.Value, S.Value))
    let _instantaneousVariance                     (u : ICell<double>) (T : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.instantaneousVariance(u.Value, T.Value))
    let _instantaneousVolatility                   (u : ICell<double>) (T : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.instantaneousVolatility(u.Value, T.Value))
    let _longTermVolatility                        = triv _AbcdFunction (fun () -> _AbcdFunction.Value.longTermVolatility())
    let _maximumVolatility                         = triv _AbcdFunction (fun () -> _AbcdFunction.Value.maximumVolatility())
    let _primitive                                 (t : ICell<double>) (T2 : ICell<double>) (S : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.primitive(t.Value, T2.Value, S.Value))
    let _shortTermVolatility                       = triv _AbcdFunction (fun () -> _AbcdFunction.Value.shortTermVolatility())
    let _variance                                  (tMin : ICell<double>) (tMax : ICell<double>) (T : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.variance(tMin.Value, tMax.Value, T.Value))
    let _volatility                                (tMin : ICell<double>) (tMax : ICell<double>) (T : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.volatility(tMin.Value, tMax.Value, T.Value))
    let _a                                         = triv _AbcdFunction (fun () -> _AbcdFunction.Value.a())
    let _b                                         = triv _AbcdFunction (fun () -> _AbcdFunction.Value.b())
    let _c                                         = triv _AbcdFunction (fun () -> _AbcdFunction.Value.c())
    let _coefficients                              = triv _AbcdFunction (fun () -> _AbcdFunction.Value.coefficients())
    let _d                                         = triv _AbcdFunction (fun () -> _AbcdFunction.Value.d())
    let _definiteDerivativeCoefficients            (t : ICell<double>) (t2 : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.definiteDerivativeCoefficients(t.Value, t2.Value))
    let _definiteIntegral                          (t1 : ICell<double>) (t2 : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.definiteIntegral(t1.Value, t2.Value))
    let _definiteIntegralCoefficients              (t : ICell<double>) (t2 : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.definiteIntegralCoefficients(t.Value, t2.Value))
    let _derivative                                (t : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.derivative(t.Value))
    let _derivativeCoefficients                    = triv _AbcdFunction (fun () -> _AbcdFunction.Value.derivativeCoefficients())
    let _longTermValue                             = triv _AbcdFunction (fun () -> _AbcdFunction.Value.longTermValue())
    let _maximumLocation                           = triv _AbcdFunction (fun () -> _AbcdFunction.Value.maximumLocation())
    let _maximumValue                              = triv _AbcdFunction (fun () -> _AbcdFunction.Value.maximumValue())
    let _value                                     (t : ICell<double>)   
                                                   = triv _AbcdFunction (fun () -> _AbcdFunction.Value.value(t.Value))
    do this.Bind(_AbcdFunction)
(* 
    casting 
*)
    internal new () = new AbcdFunctionModel(null,null,null,null)
    member internal this.Inject v = _AbcdFunction <- v
    static member Cast (p : ICell<AbcdFunction>) = 
        if p :? AbcdFunctionModel then 
            p :?> AbcdFunctionModel
        else
            let o = new AbcdFunctionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.a                                  = _a 
    member this.b                                  = _b 
    member this.c                                  = _c 
    member this.d                                  = _d 
    member this.Covariance                         t T2 S   
                                                   = _covariance t T2 S 
    member this.Covariance1                        t1 t2 T S   
                                                   = _covariance1 t1 t2 T S 
    member this.InstantaneousCovariance            u T S   
                                                   = _instantaneousCovariance u T S 
    member this.InstantaneousVariance              u T   
                                                   = _instantaneousVariance u T 
    member this.InstantaneousVolatility            u T   
                                                   = _instantaneousVolatility u T 
    member this.LongTermVolatility                 = _longTermVolatility
    member this.MaximumVolatility                  = _maximumVolatility
    member this.Primitive                          t T2 S   
                                                   = _primitive t T2 S 
    member this.ShortTermVolatility                = _shortTermVolatility
    member this.Variance                           tMin tMax T   
                                                   = _variance tMin tMax T 
    member this.Volatility                         tMin tMax T   
                                                   = _volatility tMin tMax T 
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
    member this.Value                              t   
                                                   = _value t 
