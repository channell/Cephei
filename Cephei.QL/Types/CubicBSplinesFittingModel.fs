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
  Fits a discount function to a set of cubic B-splines N_{i,3}(t) i.e., d(t) =  c_i * N_{i,3}(t)  See: McCulloch, J. 1971, "Measuring the Term Structure of Interest Rates." Journal of Business, 44: 19-31  McCulloch, J. 1975, "The tax adjusted yield curve." Journal of Finance, XXX811-30  "The results are extremely sensitive to the number and location of the knot points, and there is no optimal way of selecting them." James, J. and N. Webber, "Interest Rate Modelling" John Wiley, 2000, pp. 440.

  </summary> *)
[<AutoSerializable(true)>]
type CubicBSplinesFittingModel
    ( knots                                        : ICell<Generic.List<double>>
    , constrainAtZero                              : ICell<bool>
    , weights                                      : ICell<Vector>
    , optimizationMethod                           : ICell<OptimizationMethod>
    ) as this =

    inherit Model<CubicBSplinesFitting> ()
(*
    Parameters
*)
    let _knots                                     = knots
    let _constrainAtZero                           = constrainAtZero
    let _weights                                   = weights
    let _optimizationMethod                        = optimizationMethod
(*
    Functions
*)
    let _CubicBSplinesFitting                      = cell (fun () -> new CubicBSplinesFitting (knots.Value, constrainAtZero.Value, weights.Value, optimizationMethod.Value))
    let _basisFunction                             (i : ICell<int>) (t : ICell<double>)   
                                                   = triv (fun () -> _CubicBSplinesFitting.Value.basisFunction(i.Value, t.Value))
    let _clone                                     = triv (fun () -> _CubicBSplinesFitting.Value.clone())
    let _size                                      = triv (fun () -> _CubicBSplinesFitting.Value.size())
    let _constrainAtZero                           = triv (fun () -> _CubicBSplinesFitting.Value.constrainAtZero())
    let _discount                                  (x : ICell<Vector>) (t : ICell<double>)   
                                                   = triv (fun () -> _CubicBSplinesFitting.Value.discount(x.Value, t.Value))
    let _minimumCostValue                          = triv (fun () -> _CubicBSplinesFitting.Value.minimumCostValue())
    let _numberOfIterations                        = triv (fun () -> _CubicBSplinesFitting.Value.numberOfIterations())
    let _optimizationMethod                        = triv (fun () -> _CubicBSplinesFitting.Value.optimizationMethod())
    let _solution                                  = triv (fun () -> _CubicBSplinesFitting.Value.solution())
    let _weights                                   = triv (fun () -> _CubicBSplinesFitting.Value.weights())
    do this.Bind(_CubicBSplinesFitting)
(* 
    casting 
*)
    internal new () = CubicBSplinesFittingModel(null,null,null,null)
    member internal this.Inject v = _CubicBSplinesFitting.Value <- v
    static member Cast (p : ICell<CubicBSplinesFitting>) = 
        if p :? CubicBSplinesFittingModel then 
            p :?> CubicBSplinesFittingModel
        else
            let o = new CubicBSplinesFittingModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.knots                              = _knots 
    member this.constrainAtZero                    = _constrainAtZero 
    member this.weights                            = _weights 
    member this.optimizationMethod                 = _optimizationMethod 
    member this.BasisFunction                      i t   
                                                   = _basisFunction i t 
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
