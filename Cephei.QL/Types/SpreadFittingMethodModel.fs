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
Fits a spread curve on top of a discount function according to given parametric method

  </summary> *)
[<AutoSerializable(true)>]
type SpreadFittingMethodModel
    ( Method                                       : ICell<FittedBondDiscountCurve.FittingMethod>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<SpreadFittingMethod> ()
(*
    Parameters
*)
    let _Method                                    = Method
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let _SpreadFittingMethod                       = cell (fun () -> new SpreadFittingMethod (Method.Value, discountCurve.Value))
    let _clone                                     = triv (fun () -> _SpreadFittingMethod.Value.clone())
    let _size                                      = triv (fun () -> _SpreadFittingMethod.Value.size())
    let _constrainAtZero                           = triv (fun () -> _SpreadFittingMethod.Value.constrainAtZero())
    let _discount                                  (x : ICell<Vector>) (t : ICell<double>)   
                                                   = triv (fun () -> _SpreadFittingMethod.Value.discount(x.Value, t.Value))
    let _minimumCostValue                          = triv (fun () -> _SpreadFittingMethod.Value.minimumCostValue())
    let _numberOfIterations                        = triv (fun () -> _SpreadFittingMethod.Value.numberOfIterations())
    let _optimizationMethod                        = triv (fun () -> _SpreadFittingMethod.Value.optimizationMethod())
    let _solution                                  = triv (fun () -> _SpreadFittingMethod.Value.solution())
    let _weights                                   = triv (fun () -> _SpreadFittingMethod.Value.weights())
    do this.Bind(_SpreadFittingMethod)
(* 
    casting 
*)
    internal new () = SpreadFittingMethodModel(null,null)
    member internal this.Inject v = _SpreadFittingMethod.Value <- v
    static member Cast (p : ICell<SpreadFittingMethod>) = 
        if p :? SpreadFittingMethodModel then 
            p :?> SpreadFittingMethodModel
        else
            let o = new SpreadFittingMethodModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Method                             = _Method 
    member this.discountCurve                      = _discountCurve 
    member this.Clone                              = _clone
    member this.Size                               = _size
    member this.ConstrainAtZero                    = _constrainAtZero
    member this.Discount                           x t   
                                                   = _discount x t 
    member this.MinimumCostValue                   = _minimumCostValue
    member this.NumberOfIterations                 = _numberOfIterations
    member this.OptimizationMethod                 = _optimizationMethod
    member this.Solution                           = _solution
    member this.Weights                            = _weights
