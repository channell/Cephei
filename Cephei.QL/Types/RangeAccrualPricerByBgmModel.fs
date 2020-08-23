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
type RangeAccrualPricerByBgmModel
    ( correlation                                  : ICell<double>
    , smilesOnExpiry                               : ICell<SmileSection>
    , smilesOnPayment                              : ICell<SmileSection>
    , withSmile                                    : ICell<bool>
    , byCallSpread                                 : ICell<bool>
    ) as this =

    inherit Model<RangeAccrualPricerByBgm> ()
(*
    Parameters
*)
    let _correlation                               = correlation
    let _smilesOnExpiry                            = smilesOnExpiry
    let _smilesOnPayment                           = smilesOnPayment
    let _withSmile                                 = withSmile
    let _byCallSpread                              = byCallSpread
(*
    Functions
*)
    let _RangeAccrualPricerByBgm                   = cell (fun () -> new RangeAccrualPricerByBgm (correlation.Value, smilesOnExpiry.Value, smilesOnPayment.Value, withSmile.Value, byCallSpread.Value))
    let _swapletPrice                              = triv (fun () -> _RangeAccrualPricerByBgm.Value.swapletPrice())
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> _RangeAccrualPricerByBgm.Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> _RangeAccrualPricerByBgm.Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> _RangeAccrualPricerByBgm.Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> _RangeAccrualPricerByBgm.Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = triv (fun () -> _RangeAccrualPricerByBgm.Value.initialize(coupon.Value)
                                                                     _RangeAccrualPricerByBgm.Value)
    let _swapletRate                               = triv (fun () -> _RangeAccrualPricerByBgm.Value.swapletRate())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RangeAccrualPricerByBgm.Value.registerWith(handler.Value)
                                                                     _RangeAccrualPricerByBgm.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _RangeAccrualPricerByBgm.Value.unregisterWith(handler.Value)
                                                                     _RangeAccrualPricerByBgm.Value)
    let _update                                    = triv (fun () -> _RangeAccrualPricerByBgm.Value.update()
                                                                     _RangeAccrualPricerByBgm.Value)
    do this.Bind(_RangeAccrualPricerByBgm)

(* 
    Externally visible/bindable properties
*)
    member this.correlation                        = _correlation 
    member this.smilesOnExpiry                     = _smilesOnExpiry 
    member this.smilesOnPayment                    = _smilesOnPayment 
    member this.withSmile                          = _withSmile 
    member this.byCallSpread                       = _byCallSpread 
    member this.SwapletPrice                       = _swapletPrice
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
    member this.SwapletRate                        = _swapletRate
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
