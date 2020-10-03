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
type DoublingConvergenceStepsModel
    () as this =
    inherit Model<DoublingConvergenceSteps> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _DoublingConvergenceSteps                  = cell (fun () -> new DoublingConvergenceSteps ())
    let _initialSamples                            = triv (fun () -> _DoublingConvergenceSteps.Value.initialSamples())
    let _nextSamples                               (current : ICell<int>)   
                                                   = triv (fun () -> _DoublingConvergenceSteps.Value.nextSamples(current.Value))
    do this.Bind(_DoublingConvergenceSteps)
(* 
    casting 
*)
    
    member internal this.Inject v = _DoublingConvergenceSteps.Value <- v
    static member Cast (p : ICell<DoublingConvergenceSteps>) = 
        if p :? DoublingConvergenceStepsModel then 
            p :?> DoublingConvergenceStepsModel
        else
            let o = new DoublingConvergenceStepsModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.InitialSamples                     = _initialSamples
    member this.NextSamples                        current   
                                                   = _nextSamples current 
