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
  Prices a cms coupon using a linear terminal swap rate model The slope parameter is linked to a gaussian short rate model. Reference: Andersen, Piterbarg, Interest Rate Modeling, 16.3.2  The cut off point for integration can be set - by explicitly specifying the lower and upper bound - by defining the lower and upper bound to be the strike where a vanilla swaption has 1% or less vega of the atm swaption - by defining the lower and upper bound to be the strike where undeflated ( ) payer resp. receiver prices are below a given threshold - by specificying a number of standard deviations to cover using a Black Scholes process with an atm volatility as a benchmark In every case the lower and upper bound are applied though. In case the smile section is shifted lognormal, the specified lower and upper bound are applied to strike + shift so that e.g. a zero lower bound always refers to the lower bound of the rates in the shifted lognormal model. Note that for normal volatility input the lower rate bound should probably be adjusted to an appropriate negative value, there is no automatic adjustment in this case.

  </summary> *)
[<AutoSerializable(true)>]
type LinearTsrPricerModel
    ( swaptionVol                                  : ICell<Handle<SwaptionVolatilityStructure>>
    , meanReversion                                : ICell<Handle<Quote>>
    , couponDiscountCurve                          : ICell<Handle<YieldTermStructure>>
    , settings                                     : ICell<LinearTsrPricer.Settings>
    , integrator                                   : ICell<Integrator>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<LinearTsrPricer> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _swaptionVol                               = swaptionVol
    let _meanReversion                             = meanReversion
    let _couponDiscountCurve                       = couponDiscountCurve
    let _settings                                  = settings
    let _integrator                                = integrator
(*
    Functions
*)
    let mutable
        _LinearTsrPricer                           = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new LinearTsrPricer (swaptionVol.Value, meanReversion.Value, couponDiscountCurve.Value, settings.Value, integrator.Value))))
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.initialize(coupon.Value)
                                                                                      _LinearTsrPricer.Value)
    let _meanReversion                             = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.meanReversion())
    let _setMeanReversion                          (meanReversion : ICell<Handle<Quote>>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.setMeanReversion(meanReversion.Value)
                                                                                      _LinearTsrPricer.Value)
    let _swapletPrice                              = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.swapletPrice())
    let _swapletRate                               = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.swapletRate())
    let _setSwaptionVolatility                     (v : ICell<Handle<SwaptionVolatilityStructure>>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.setSwaptionVolatility(v.Value)
                                                                                      _LinearTsrPricer.Value)
    let _swaptionVolatility                        = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.swaptionVolatility())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.registerWith(handler.Value)
                                                                                      _LinearTsrPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.unregisterWith(handler.Value)
                                                                                      _LinearTsrPricer.Value)
    let _update                                    = triv _LinearTsrPricer (fun () -> (curryEvaluationDate _evaluationDate _LinearTsrPricer).Value.update()
                                                                                      _LinearTsrPricer.Value)
    do this.Bind(_LinearTsrPricer)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new LinearTsrPricerModel(null,null,null,null,null,null)
    member internal this.Inject v = _LinearTsrPricer <- v
    static member Cast (p : ICell<LinearTsrPricer>) = 
        if p :? LinearTsrPricerModel then 
            p :?> LinearTsrPricerModel
        else
            let o = new LinearTsrPricerModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.swaptionVol                        = _swaptionVol 
    member this.meanReversion                      = _meanReversion 
    member this.couponDiscountCurve                = _couponDiscountCurve 
    member this.settings                           = _settings 
    member this.integrator                         = _integrator 
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
    member this.SwapletPrice                       = _swapletPrice
    member this.SwapletRate                        = _swapletRate
    member this.SetSwaptionVolatility              v   
                                                   = _setSwaptionVolatility v 
    member this.SwaptionVolatility                 = _swaptionVolatility
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
