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

Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type SABRSpecsModel
    () as this =
    inherit Model<SABRSpecs> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _SABRSpecs                                 = cell (fun () -> new SABRSpecs ())
    let _defaultValues                             (param : ICell<List<Nullable<double>>>) (b : ICell<Generic.List<bool>>) (forward : ICell<double>) (expiryTime : ICell<double>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SABRSpecs.Value.defaultValues(param.Value, b.Value, forward.Value, expiryTime.Value, addParams.Value)
                                                                     _SABRSpecs.Value)
    let _dilationFactor                            = triv (fun () -> _SABRSpecs.Value.dilationFactor())
    let _dimension                                 = triv (fun () -> _SABRSpecs.Value.dimension())
    let _direct                                    (x : ICell<Vector>) (b : ICell<Generic.List<bool>>) (c : ICell<List<Nullable<double>>>) (d : ICell<double>)   
                                                   = triv (fun () -> _SABRSpecs.Value.direct(x.Value, b.Value, c.Value, d.Value))
    let _eps1                                      = triv (fun () -> _SABRSpecs.Value.eps1())
    let _eps2                                      = triv (fun () -> _SABRSpecs.Value.eps2())
    let _guess                                     (values : ICell<Vector>) (paramIsFixed : ICell<Generic.List<bool>>) (forward : ICell<double>) (expiryTime : ICell<double>) (r : ICell<Generic.List<double>>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SABRSpecs.Value.guess(values.Value, paramIsFixed.Value, forward.Value, expiryTime.Value, r.Value, addParams.Value)
                                                                     _SABRSpecs.Value)
    let _instance                                  (t : ICell<double>) (forward : ICell<double>) (param : ICell<List<Nullable<double>>>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SABRSpecs.Value.instance(t.Value, forward.Value, param.Value, addParams.Value))
    let _inverse                                   (y : ICell<Vector>) (b : ICell<Generic.List<bool>>) (c : ICell<List<Nullable<double>>>) (d : ICell<double>)   
                                                   = triv (fun () -> _SABRSpecs.Value.inverse(y.Value, b.Value, c.Value, d.Value))
    let _weight                                    (strike : ICell<double>) (forward : ICell<double>) (stdDev : ICell<double>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SABRSpecs.Value.weight(strike.Value, forward.Value, stdDev.Value, addParams.Value))
    do this.Bind(_SABRSpecs)
(* 
    casting 
*)
    
    member internal this.Inject v = _SABRSpecs <- v
    static member Cast (p : ICell<SABRSpecs>) = 
        if p :? SABRSpecsModel then 
            p :?> SABRSpecsModel
        else
            let o = new SABRSpecsModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.DefaultValues                      param b forward expiryTime addParams   
                                                   = _defaultValues param b forward expiryTime addParams 
    member this.DilationFactor                     = _dilationFactor
    member this.Dimension                          = _dimension
    member this.Direct                             x b c d   
                                                   = _direct x b c d 
    member this.Eps1                               = _eps1
    member this.Eps2                               = _eps2
    member this.Guess                              values paramIsFixed forward expiryTime r addParams   
                                                   = _guess values paramIsFixed forward expiryTime r addParams 
    member this.Instance                           t forward param addParams   
                                                   = _instance t forward param addParams 
    member this.Inverse                            y b c d   
                                                   = _inverse y b c d 
    member this.Weight                             strike forward stdDev addParams   
                                                   = _weight strike forward stdDev addParams 
