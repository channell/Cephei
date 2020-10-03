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


  </summary> *)
[<AutoSerializable(true)>]
type HestonHullWhitePathPricerModel
    ( exerciseTime                                 : ICell<double>
    , payoff                                       : ICell<Payoff>
    , Process                                      : ICell<HybridHestonHullWhiteProcess>
    ) as this =

    inherit Model<HestonHullWhitePathPricer> ()
(*
    Parameters
*)
    let _exerciseTime                              = exerciseTime
    let _payoff                                    = payoff
    let _Process                                   = Process
(*
    Functions
*)
    let _HestonHullWhitePathPricer                 = cell (fun () -> new HestonHullWhitePathPricer (exerciseTime.Value, payoff.Value, Process.Value))
    let _value                                     (path : ICell<IPath>)   
                                                   = triv (fun () -> _HestonHullWhitePathPricer.Value.value(path.Value))
    do this.Bind(_HestonHullWhitePathPricer)
(* 
    casting 
*)
    internal new () = HestonHullWhitePathPricerModel(null,null,null)
    member internal this.Inject v = _HestonHullWhitePathPricer.Value <- v
    static member Cast (p : ICell<HestonHullWhitePathPricer>) = 
        if p :? HestonHullWhitePathPricerModel then 
            p :?> HestonHullWhitePathPricerModel
        else
            let o = new HestonHullWhitePathPricerModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.exerciseTime                       = _exerciseTime 
    member this.payoff                             = _payoff 
    member this.Process                            = _Process 
    member this.Value                              path   
                                                   = _value path 
