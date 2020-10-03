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
  instruments

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationFloorModel
    ( yoyLeg                                       : ICell<Generic.List<CashFlow>>
    , exerciseRates                                : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YoYInflationFloor> ()
(*
    Parameters
*)
    let _yoyLeg                                    = yoyLeg
    let _exerciseRates                             = exerciseRates
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _YoYInflationFloor                         = cell (fun () -> withEngine pricingEngine (new YoYInflationFloor (yoyLeg.Value, exerciseRates.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).capRates())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).floorRates())
    let _impliedVolatility                         (price : ICell<double>) (yoyCurve : ICell<Handle<YoYInflationTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).impliedVolatility(price.Value, yoyCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).isExpired())
    let _lastYoYInflationCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).lastYoYInflationCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).startDate())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).TYPE())
    let _yoyLeg                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).yoyLeg())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).setPricingEngine(e.Value)
                                                                     _YoYInflationFloor.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationFloor).valuationDate())
    do this.Bind(_YoYInflationFloor)
(* 
    casting 
*)
    internal new () = YoYInflationFloorModel(null,null,null,null)
    member internal this.Inject v = _YoYInflationFloor.Value <- v
    static member Cast (p : ICell<YoYInflationFloor>) = 
        if p :? YoYInflationFloorModel then 
            p :?> YoYInflationFloorModel
        else
            let o = new YoYInflationFloorModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.yoyLeg                             = _yoyLeg 
    member this.exerciseRates                      = _exerciseRates 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AtmRate                            discountCurve   
                                                   = _atmRate discountCurve 
    member this.CapRates                           = _capRates
    member this.FloorRates                         = _floorRates
    member this.ImpliedVolatility                  price yoyCurve guess accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility price yoyCurve guess accuracy maxEvaluations minVol maxVol 
    member this.IsExpired                          = _isExpired
    member this.LastYoYInflationCoupon             = _lastYoYInflationCoupon
    member this.MaturityDate                       = _maturityDate
    member this.Optionlet                          i   
                                                   = _optionlet i 
    member this.StartDate                          = _startDate
    member this.Type                               = _type
    member this.YoyLeg                             = _yoyLeg
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
