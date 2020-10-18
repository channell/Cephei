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
type OvernightIndexedCouponPricerModel
    () as this =
    inherit Model<OvernightIndexedCouponPricer> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _OvernightIndexedCouponPricer              = cell (fun () -> new OvernightIndexedCouponPricer ())
    let _capletPrice                               (d : ICell<double>)   
                                                   = triv (fun () -> _OvernightIndexedCouponPricer.Value.capletPrice(d.Value))
    let _capletRate                                (d : ICell<double>)   
                                                   = triv (fun () -> _OvernightIndexedCouponPricer.Value.capletRate(d.Value))
    let _floorletPrice                             (d : ICell<double>)   
                                                   = triv (fun () -> _OvernightIndexedCouponPricer.Value.floorletPrice(d.Value))
    let _floorletRate                              (d : ICell<double>)   
                                                   = triv (fun () -> _OvernightIndexedCouponPricer.Value.floorletRate(d.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = triv (fun () -> _OvernightIndexedCouponPricer.Value.initialize(coupon.Value)
                                                                     _OvernightIndexedCouponPricer.Value)
    let _swapletPrice                              = triv (fun () -> _OvernightIndexedCouponPricer.Value.swapletPrice())
    let _swapletRate                               = triv (fun () -> _OvernightIndexedCouponPricer.Value.swapletRate())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _OvernightIndexedCouponPricer.Value.registerWith(handler.Value)
                                                                     _OvernightIndexedCouponPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _OvernightIndexedCouponPricer.Value.unregisterWith(handler.Value)
                                                                     _OvernightIndexedCouponPricer.Value)
    let _update                                    = triv (fun () -> _OvernightIndexedCouponPricer.Value.update()
                                                                     _OvernightIndexedCouponPricer.Value)
    do this.Bind(_OvernightIndexedCouponPricer)
(* 
    casting 
*)
    
    member internal this.Inject v = _OvernightIndexedCouponPricer <- v
    static member Cast (p : ICell<OvernightIndexedCouponPricer>) = 
        if p :? OvernightIndexedCouponPricerModel then 
            p :?> OvernightIndexedCouponPricerModel
        else
            let o = new OvernightIndexedCouponPricerModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.CapletPrice                        d   
                                                   = _capletPrice d 
    member this.CapletRate                         d   
                                                   = _capletRate d 
    member this.FloorletPrice                      d   
                                                   = _floorletPrice d 
    member this.FloorletRate                       d   
                                                   = _floorletRate d 
    member this.Initialize                         coupon   
                                                   = _initialize coupon 
    member this.SwapletPrice                       = _swapletPrice
    member this.SwapletRate                        = _swapletRate
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
