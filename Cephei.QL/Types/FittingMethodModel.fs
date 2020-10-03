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
  This base class provides the specific methodology/strategy used to construct a FittedBondDiscountCurve.  Derived classes need only define the virtual function discountFunction() based on the particular fitting method to be implemented, as well as size(), the number of variables to be solved for/optimized. The generic fitting methodology implemented here can be termed nonlinear, in contrast to (typically faster, computationally) linear fitting method.  Optional parameters for FittingMethod include an Array of weights, which will be used as weights to each bond. If not given or empty, then the bonds will be weighted by inverse duration  derive the special-case class LinearFittingMethods from FittingMethod. A linear fitting to a set of basis functions b_i(t) is any fitting of the form d(t) = c_i b_i(t) i.e., linear in the unknown coefficients c_i Such a fitting can be reduced to a linear algebra problem Ax = b and for large numbers of bonds, would typically be much faster computationally than the generic non-linear fitting method.  some parameters to the Simplex optimization method may need to be tweaked internally to the class, depending on the fitting method used, in order to get proper/reasonable/faster convergence.
Missing Constructor
  </summary> *)
[<AutoSerializable(true)>]
type FittingMethodModel
    () as this =
    inherit Model<FittingMethod> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _FittingMethod                             = cell (fun () -> new FittingMethod ())
    let _clone                                     = cell (fun () -> _FittingMethod.Value.clone())
    let _constrainAtZero                           = cell (fun () -> _FittingMethod.Value.constrainAtZero())
    let _discount                                  (x : ICell<Vector>) (t : ICell<double>)   
                                                   = cell (fun () -> _FittingMethod.Value.discount(x.Value, t.Value))
    let _minimumCostValue                          = cell (fun () -> _FittingMethod.Value.minimumCostValue())
    let _numberOfIterations                        = cell (fun () -> _FittingMethod.Value.numberOfIterations())
    let _optimizationMethod                        = cell (fun () -> _FittingMethod.Value.optimizationMethod())
    let _size                                      = cell (fun () -> _FittingMethod.Value.size())
    let _solution                                  = cell (fun () -> _FittingMethod.Value.solution())
    let _weights                                   = cell (fun () -> _FittingMethod.Value.weights())
    do this.Bind(_FittingMethod)
(* 
    casting 
*)
    
    member internal this.Inject v = _FittingMethod.Value <- v
    static member Cast (p : ICell<FittingMethod>) = 
        if p :? FittingMethodModel then 
            p :?> FittingMethodModel
        else
            let o = new FittingMethodModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<FittingMethod>) = 
        if p :? FittingMethodModel then 
            p :?> FittingMethodModel
        else
            let o = new FittingMethodModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Clone                              = _clone
    member this.ConstrainAtZero                    = _constrainAtZero
    member this.Discount                           x t   
                                                   = _discount x t 
    member this.MinimumCostValue                   = _minimumCostValue
    member this.NumberOfIterations                 = _numberOfIterations
    member this.OptimizationMethod                 = _optimizationMethod
    member this.Size                               = _size
    member this.Solution                           = _solution
    member this.Weights                            = _weights
