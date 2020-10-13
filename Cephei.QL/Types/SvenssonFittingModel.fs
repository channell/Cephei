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
  Fits a discount function to the form  See: Svensson, L. (1994). Estimating and interpreting forward interest rates: Sweden 1992-4. Discussion paper, Centre for Economic Policy Research(1051).

  </summary> *)
[<AutoSerializable(true)>]
type SvenssonFittingModel
    ( weights                                      : ICell<Vector>
    , optimizationMethod                           : ICell<OptimizationMethod>
    ) as this =

    inherit Model<SvenssonFitting> ()
(*
    Parameters
*)
    let _weights                                   = weights
    let _optimizationMethod                        = optimizationMethod
(*
    Functions
*)
    let _SvenssonFitting                           = cell (fun () -> new SvenssonFitting (weights.Value, optimizationMethod.Value))
    let _clone                                     = triv (fun () -> _SvenssonFitting.Value.clone())
    let _size                                      = triv (fun () -> _SvenssonFitting.Value.size())
    let _constrainAtZero                           = triv (fun () -> _SvenssonFitting.Value.constrainAtZero())
    let _discount                                  (x : ICell<Vector>) (t : ICell<double>)   
                                                   = triv (fun () -> _SvenssonFitting.Value.discount(x.Value, t.Value))
    let _minimumCostValue                          = triv (fun () -> _SvenssonFitting.Value.minimumCostValue())
    let _numberOfIterations                        = triv (fun () -> _SvenssonFitting.Value.numberOfIterations())
    let _optimizationMethod                        = triv (fun () -> _SvenssonFitting.Value.optimizationMethod())
    let _solution                                  = triv (fun () -> _SvenssonFitting.Value.solution())
    let _weights                                   = triv (fun () -> _SvenssonFitting.Value.weights())
    do this.Bind(_SvenssonFitting)
(* 
    casting 
*)
    internal new () = new SvenssonFittingModel(null,null)
    member internal this.Inject v = _SvenssonFitting.Value <- v
    static member Cast (p : ICell<SvenssonFitting>) = 
        if p :? SvenssonFittingModel then 
            p :?> SvenssonFittingModel
        else
            let o = new SvenssonFittingModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.weights                            = _weights 
    member this.optimizationMethod                 = _optimizationMethod 
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
