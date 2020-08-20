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
type RangeAccrualPricerModel
    () as this =
    inherit Model<RangeAccrualPricer> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _RangeAccrualPricer                        = cell (fun () -> new RangeAccrualPricer ())
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualPricer.Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualPricer.Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualPricer.Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = cell (fun () -> _RangeAccrualPricer.Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = cell (fun () -> _RangeAccrualPricer.Value.initialize(coupon.Value)
                                                                     _RangeAccrualPricer.Value)
    let _swapletPrice                              = cell (fun () -> _RangeAccrualPricer.Value.swapletPrice())
    let _swapletRate                               = cell (fun () -> _RangeAccrualPricer.Value.swapletRate())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RangeAccrualPricer.Value.registerWith(handler.Value)
                                                                     _RangeAccrualPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _RangeAccrualPricer.Value.unregisterWith(handler.Value)
                                                                     _RangeAccrualPricer.Value)
    let _update                                    = cell (fun () -> _RangeAccrualPricer.Value.update()
                                                                     _RangeAccrualPricer.Value)
    do this.Bind(_RangeAccrualPricer)

(* 
    Externally visible/bindable properties
*)
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
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
