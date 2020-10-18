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
type BiasedBarrierPathPricerModel
    ( barrierType                                  : ICell<Barrier.Type>
    , barrier                                      : ICell<Nullable<double>>
    , rebate                                       : ICell<Nullable<double>>
    , Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , discounts                                    : ICell<Generic.List<double>>
    ) as this =

    inherit Model<BiasedBarrierPathPricer> ()
(*
    Parameters
*)
    let _barrierType                               = barrierType
    let _barrier                                   = barrier
    let _rebate                                    = rebate
    let _Type                                      = Type
    let _strike                                    = strike
    let _discounts                                 = discounts
(*
    Functions
*)
    let mutable
        _BiasedBarrierPathPricer                   = cell (fun () -> new BiasedBarrierPathPricer (barrierType.Value, barrier.Value, rebate.Value, Type.Value, strike.Value, discounts.Value))
    let _value                                     (path : ICell<IPath>)   
                                                   = triv (fun () -> _BiasedBarrierPathPricer.Value.value(path.Value))
    do this.Bind(_BiasedBarrierPathPricer)
(* 
    casting 
*)
    internal new () = new BiasedBarrierPathPricerModel(null,null,null,null,null,null)
    member internal this.Inject v = _BiasedBarrierPathPricer <- v
    static member Cast (p : ICell<BiasedBarrierPathPricer>) = 
        if p :? BiasedBarrierPathPricerModel then 
            p :?> BiasedBarrierPathPricerModel
        else
            let o = new BiasedBarrierPathPricerModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.barrierType                        = _barrierType 
    member this.barrier                            = _barrier 
    member this.rebate                             = _rebate 
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.discounts                          = _discounts 
    member this.Value                              path   
                                                   = _value path 
