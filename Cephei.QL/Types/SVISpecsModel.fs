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
type SVISpecsModel
    () as this =
    inherit Model<SVISpecs> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _SVISpecs                                  = cell (fun () -> new SVISpecs ())
    let _defaultValues                             (param : ICell<List<Nullable<double>>>) (paramIsFixed : ICell<Generic.List<bool>>) (forward : ICell<double>) (expiryTime : ICell<double>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SVISpecs.Value.defaultValues(param.Value, paramIsFixed.Value, forward.Value, expiryTime.Value, addParams.Value)
                                                                     _SVISpecs.Value)
    let _dilationFactor                            = triv (fun () -> _SVISpecs.Value.dilationFactor())
    let _dimension                                 = triv (fun () -> _SVISpecs.Value.dimension())
    let _direct                                    (x : ICell<Vector>) (paramIsFixed : ICell<Generic.List<bool>>) (param : ICell<List<Nullable<double>>>) (forward : ICell<double>)   
                                                   = triv (fun () -> _SVISpecs.Value.direct(x.Value, paramIsFixed.Value, param.Value, forward.Value))
    let _eps1                                      = triv (fun () -> _SVISpecs.Value.eps1())
    let _eps2                                      = triv (fun () -> _SVISpecs.Value.eps2())
    let _guess                                     (values : ICell<Vector>) (paramIsFixed : ICell<Generic.List<bool>>) (forward : ICell<double>) (expiryTime : ICell<double>) (r : ICell<Generic.List<double>>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SVISpecs.Value.guess(values.Value, paramIsFixed.Value, forward.Value, expiryTime.Value, r.Value, addParams.Value)
                                                                     _SVISpecs.Value)
    let _instance                                  (t : ICell<double>) (forward : ICell<double>) (param : ICell<List<Nullable<double>>>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SVISpecs.Value.instance(t.Value, forward.Value, param.Value, addParams.Value))
    let _inverse                                   (y : ICell<Vector>) (b : ICell<Generic.List<bool>>) (c : ICell<List<Nullable<double>>>) (d : ICell<double>)   
                                                   = triv (fun () -> _SVISpecs.Value.inverse(y.Value, b.Value, c.Value, d.Value))
    let _modelInstance_                            = triv (fun () -> _SVISpecs.Value.modelInstance_)
    let _weight                                    (strike : ICell<double>) (forward : ICell<double>) (stdDev : ICell<double>) (addParams : ICell<List<Nullable<double>>>)   
                                                   = triv (fun () -> _SVISpecs.Value.weight(strike.Value, forward.Value, stdDev.Value, addParams.Value))
    do this.Bind(_SVISpecs)

(* 
    Externally visible/bindable properties
*)
    member this.DefaultValues                      param paramIsFixed forward expiryTime addParams   
                                                   = _defaultValues param paramIsFixed forward expiryTime addParams 
    member this.DilationFactor                     = _dilationFactor
    member this.Dimension                          = _dimension
    member this.Direct                             x paramIsFixed param forward   
                                                   = _direct x paramIsFixed param forward 
    member this.Eps1                               = _eps1
    member this.Eps2                               = _eps2
    member this.Guess                              values paramIsFixed forward expiryTime r addParams   
                                                   = _guess values paramIsFixed forward expiryTime r addParams 
    member this.Instance                           t forward param addParams   
                                                   = _instance t forward param addParams 
    member this.Inverse                            y b c d   
                                                   = _inverse y b c d 
    member this.ModelInstance_                     = _modelInstance_
    member this.Weight                             strike forward stdDev addParams   
                                                   = _weight strike forward stdDev addParams 
