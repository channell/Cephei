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
  Black-formula pricer for capped/floored Ibor coupons References for timing adjustments Black76             Hull, Options, Futures and other derivatives, 4th ed., page 550 BivariateLognormal  http://ssrn.com/abstract=2170721 The bivariate lognormal adjustment implementation is still considered experimental

  </summary> *)
[<AutoSerializable(true)>]
type BlackIborCouponPricerModel
    ( v                                            : ICell<Handle<OptionletVolatilityStructure>>
    , timingAdjustment                             : ICell<BlackIborCouponPricer.TimingAdjustment>
    , correlation                                  : ICell<Handle<Quote>>
    ) as this =

    inherit Model<BlackIborCouponPricer> ()
(*
    Parameters
*)
    let _v                                         = v
    let _timingAdjustment                          = timingAdjustment
    let _correlation                               = correlation
(*
    Functions
*)
    let mutable
        _BlackIborCouponPricer                     = cell (fun () -> new BlackIborCouponPricer (v.Value, timingAdjustment.Value, correlation.Value))
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.initialize(coupon.Value)
                                                                     _BlackIborCouponPricer.Value)
    let _swapletPrice                              = triv (fun () -> _BlackIborCouponPricer.Value.swapletPrice())
    let _swapletRate                               = triv (fun () -> _BlackIborCouponPricer.Value.swapletRate())
    let _capletVolatility                          = triv (fun () -> _BlackIborCouponPricer.Value.capletVolatility())
    let _setCapletVolatility                       (v : ICell<Handle<OptionletVolatilityStructure>>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.setCapletVolatility(v.Value)
                                                                     _BlackIborCouponPricer.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.registerWith(handler.Value)
                                                                     _BlackIborCouponPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BlackIborCouponPricer.Value.unregisterWith(handler.Value)
                                                                     _BlackIborCouponPricer.Value)
    let _update                                    = triv (fun () -> _BlackIborCouponPricer.Value.update()
                                                                     _BlackIborCouponPricer.Value)
    do this.Bind(_BlackIborCouponPricer)
(* 
    casting 
*)
    internal new () = new BlackIborCouponPricerModel(null,null,null)
    member internal this.Inject v = _BlackIborCouponPricer <- v
    static member Cast (p : ICell<BlackIborCouponPricer>) = 
        if p :? BlackIborCouponPricerModel then 
            p :?> BlackIborCouponPricerModel
        else
            let o = new BlackIborCouponPricerModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.v                                  = _v 
    member this.timingAdjustment                   = _timingAdjustment 
    member this.correlation                        = _correlation 
    member this.CapletPrice                        effectiveCap   
                                                   = _capletPrice effectiveCap 
    member this.CapletRate                         effectiveCap   
                                                   = _capletRate effectiveCap 
    member this.FloorletPrice                      effectiveFloor   
                                                   = _floorletPrice effectiveFloor 
    member this.FloorletRate                       effectiveFloor   
                                                   = _floorletRate effectiveFloor 
    member this.Initialize                         coupon   
                                                   = _initialize coupon 
    member this.SwapletPrice                       = _swapletPrice
    member this.SwapletRate                        = _swapletRate
    member this.CapletVolatility                   = _capletVolatility
    member this.SetCapletVolatility                v   
                                                   = _setCapletVolatility v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
