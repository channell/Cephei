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
===========================================================================// NumericHaganPricer                    // ===========================================================================//   Prices a cms coupon via static replication as in Hagan's "Conundrums..." article via numerical integration based on prices of vanilla swaptions

  </summary> *)
[<AutoSerializable(true)>]
type NumericHaganPricerModel
    ( swaptionVol                                  : ICell<Handle<SwaptionVolatilityStructure>>
    , modelOfYieldCurve                            : ICell<GFunctionFactory.YieldCurveModel>
    , meanReversion                                : ICell<Handle<Quote>>
    , lowerLimit                                   : ICell<double>
    , upperLimit                                   : ICell<double>
    , precision                                    : ICell<double>
    , hardUpperLimit                               : ICell<double>
    ) as this =

    inherit Model<NumericHaganPricer> ()
(*
    Parameters
*)
    let _swaptionVol                               = swaptionVol
    let _modelOfYieldCurve                         = modelOfYieldCurve
    let _meanReversion                             = meanReversion
    let _lowerLimit                                = lowerLimit
    let _upperLimit                                = upperLimit
    let _precision                                 = precision
    let _hardUpperLimit                            = hardUpperLimit
(*
    Functions
*)
    let _NumericHaganPricer                        = cell (fun () -> new NumericHaganPricer (swaptionVol.Value, modelOfYieldCurve.Value, meanReversion.Value, lowerLimit.Value, upperLimit.Value, precision.Value, hardUpperLimit.Value))
    let _integrate                                 (a : ICell<double>) (b : ICell<double>) (integrand : ICell<NumericHaganPricer.ConundrumIntegrand>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.integrate(a.Value, b.Value, integrand.Value))
    let _refineIntegration                         (integralValue : ICell<double>) (integrand : ICell<NumericHaganPricer.ConundrumIntegrand>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.refineIntegration(integralValue.Value, integrand.Value))
    let _resetUpperLimit                           (stdDeviationsForUpperLimit : ICell<double>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.resetUpperLimit(stdDeviationsForUpperLimit.Value))
    let _stdDeviations                             = triv (fun () -> _NumericHaganPricer.Value.stdDeviations())
    let _swapletPrice                              = triv (fun () -> _NumericHaganPricer.Value.swapletPrice())
    let _upperLimit                                = triv (fun () -> _NumericHaganPricer.Value.upperLimit())
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.initialize(coupon.Value)
                                                                     _NumericHaganPricer.Value)
    let _meanReversion                             = triv (fun () -> _NumericHaganPricer.Value.meanReversion())
    let _setMeanReversion                          (meanReversion : ICell<Handle<Quote>>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.setMeanReversion(meanReversion.Value)
                                                                     _NumericHaganPricer.Value)
    let _swapletRate                               = triv (fun () -> _NumericHaganPricer.Value.swapletRate())
    let _setSwaptionVolatility                     (v : ICell<Handle<SwaptionVolatilityStructure>>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.setSwaptionVolatility(v.Value)
                                                                     _NumericHaganPricer.Value)
    let _swaptionVolatility                        = triv (fun () -> _NumericHaganPricer.Value.swaptionVolatility())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.registerWith(handler.Value)
                                                                     _NumericHaganPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _NumericHaganPricer.Value.unregisterWith(handler.Value)
                                                                     _NumericHaganPricer.Value)
    let _update                                    = triv (fun () -> _NumericHaganPricer.Value.update()
                                                                     _NumericHaganPricer.Value)
    do this.Bind(_NumericHaganPricer)
(* 
    casting 
*)
    internal new () = NumericHaganPricerModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _NumericHaganPricer.Value <- v
    static member Cast (p : ICell<NumericHaganPricer>) = 
        if p :? NumericHaganPricerModel then 
            p :?> NumericHaganPricerModel
        else
            let o = new NumericHaganPricerModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.swaptionVol                        = _swaptionVol 
    member this.modelOfYieldCurve                  = _modelOfYieldCurve 
    member this.meanReversion                      = _meanReversion 
    member this.lowerLimit                         = _lowerLimit 
    member this.upperLimit                         = _upperLimit 
    member this.precision                          = _precision 
    member this.hardUpperLimit                     = _hardUpperLimit 
    member this.Integrate                          a b integrand   
                                                   = _integrate a b integrand 
    member this.RefineIntegration                  integralValue integrand   
                                                   = _refineIntegration integralValue integrand 
    member this.ResetUpperLimit                    stdDeviationsForUpperLimit   
                                                   = _resetUpperLimit stdDeviationsForUpperLimit 
    member this.StdDeviations                      = _stdDeviations
    member this.SwapletPrice                       = _swapletPrice
    member this.UpperLimit                         = _upperLimit
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
