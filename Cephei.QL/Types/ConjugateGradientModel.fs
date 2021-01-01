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
  Fletcher-Reeves-Polak-Ribiere algorithm adapted from Numerical Recipes in C, 2nd edition.  User has to provide line-search method and optimization end criteria.  This optimization method requires the knowledge of the gradient of the cost function.  optimizers

  </summary> *)
[<AutoSerializable(true)>]
type ConjugateGradientModel
    ( lineSearch                                   : ICell<LineSearch>
    ) as this =

    inherit Model<ConjugateGradient> ()
(*
    Parameters
*)
    let _lineSearch                                = lineSearch
(*
    Functions
*)
    let mutable
        _ConjugateGradient                         = make (fun () -> new ConjugateGradient (lineSearch.Value))
    let _minimize                                  (P : ICell<Problem>) (endCriteria : ICell<EndCriteria>)   
                                                   = triv _ConjugateGradient (fun () -> _ConjugateGradient.Value.minimize(P.Value, endCriteria.Value))
    do this.Bind(_ConjugateGradient)
(* 
    casting 
*)
    internal new () = new ConjugateGradientModel(null)
    member internal this.Inject v = _ConjugateGradient <- v
    static member Cast (p : ICell<ConjugateGradient>) = 
        if p :? ConjugateGradientModel then 
            p :?> ConjugateGradientModel
        else
            let o = new ConjugateGradientModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.lineSearch                         = _lineSearch 
    member this.Minimize                           P endCriteria   
                                                   = _minimize P endCriteria 
