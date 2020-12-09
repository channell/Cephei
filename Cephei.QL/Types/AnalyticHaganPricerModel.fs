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
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AnalyticHaganPricer> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _swaptionVol                               = swaptionVol
    let _modelOfYieldCurve                         = modelOfYieldCurve
    let _meanReversion                             = meanReversion
(*
    Functions
*)
    let mutable
        _AnalyticHaganPricer                       = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new AnalyticHaganPricer (swaptionVol.Value, modelOfYieldCurve.Value, meanReversion.Value))))
    let _swapletPrice                              = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.swapletPrice())
    let _capletPrice                               (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.capletPrice(effectiveCap.Value))
    let _capletRate                                (effectiveCap : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.capletRate(effectiveCap.Value))
    let _floorletPrice                             (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.floorletPrice(effectiveFloor.Value))
    let _floorletRate                              (effectiveFloor : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.floorletRate(effectiveFloor.Value))
    let _initialize                                (coupon : ICell<FloatingRateCoupon>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.initialize(coupon.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _meanReversion                             = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.meanReversion())
    let _setMeanReversion                          (meanReversion : ICell<Handle<Quote>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.setMeanReversion(meanReversion.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _swapletRate                               = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.swapletRate())
    let _setSwaptionVolatility                     (v : ICell<Handle<SwaptionVolatilityStructure>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.setSwaptionVolatility(v.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _swaptionVolatility                        = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.swaptionVolatility())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.registerWith(handler.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.unregisterWith(handler.Value)
                                                                     _AnalyticHaganPricer.Value)
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _AnalyticHaganPricer).Value.update()
                                                                     _AnalyticHaganPricer.Value)
    do this.Bind(_AnalyticHaganPricer)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new AnalyticHaganPricerModel(null,null,null,null)
    member internal this.Inject v = _AnalyticHaganPricer <- v
    static member Cast (p : ICell<AnalyticHaganPricer>) = 
        if p :? AnalyticHaganPricerModel then 
            p :?> AnalyticHaganPricerModel
        else
            let o = new AnalyticHaganPricerModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

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
