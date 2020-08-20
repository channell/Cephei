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
===========================================================================// AnalyticHaganPricer                           // ===========================================================================

  </summary> *)
[<AutoSerializable(true)>]
type AnalyticHaganPricerModel
    ( swaptionVol                                  : ICell<Handle<SwaptionVolatilityStructure>>
    , modelOfYieldCurve                            : ICell<GFunctionFactory.YieldCurveModel>
    , meanReversion                                : ICell<Handle<Quote>>
    ) as this =

    inherit Model<AnalyticHaganPricer> ()
(*
    Parameters
*)
    let _swaptionVol                               = swaptionVol
    let _modelOfYieldCurve                         = modelOfYieldCurve
    let _meanReversion                             = meanReversion
(*
    Functions
*)
    let _AnalyticHaganPricer                       = cell (fun () -> new AnalyticHaganPricer (swaptionVol.Value, modelOfYieldCurve.Value, meanReversion.Value))
    let _swapletPrice                              = cell (fun () -> _AnalyticHaganPricer.Value.swapletPrice())
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.initialize(coupon.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _meanReversion                             = cell (fun () -> _AnalyticHaganPricer.Value.meanReversion())
    let _setMeanReversion                          (meanReversion : ICell<Handle<Quote>>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.setMeanReversion(meanReversion.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _swapletRate                               = cell (fun () -> _AnalyticHaganPricer.Value.swapletRate())
    let _setSwaptionVolatility                     (v : ICell<Handle<SwaptionVolatilityStructure>>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.setSwaptionVolatility(v.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _swaptionVolatility                        = cell (fun () -> _AnalyticHaganPricer.Value.swaptionVolatility())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.registerWith(handler.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _AnalyticHaganPricer.Value.unregisterWith(handler.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _update                                    = cell (fun () -> _AnalyticHaganPricer.Value.update()
                                                                     _AnalyticHaganPricer.Value)
    do this.Bind(_AnalyticHaganPricer)

(* 
    Externally visible/bindable properties
*)
    member this.swaptionVol                        = _swaptionVol 
    member this.modelOfYieldCurve                  = _modelOfYieldCurve 
    member this.meanReversion                      = _meanReversion 
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
    member this.MeanReversion                      = _meanReversion
    member this.SetMeanReversion                   meanReversion   
                                                   = _setMeanReversion meanReversion 
    member this.SwapletRate                        = _swapletRate
    member this.SetSwaptionVolatility              v   
                                                   = _setSwaptionVolatility v 
    member this.SwaptionVolatility                 = _swaptionVolatility
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
