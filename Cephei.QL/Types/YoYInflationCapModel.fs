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
type YoYInflationCapModel
    ( yoyLeg                                       : ICell<Generic.List<CashFlow>>
    , exerciseRates                                : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YoYInflationCap> ()
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
    let _YoYInflationCap                           = cell (fun () -> withEngine pricingEngine (new YoYInflationCap (yoyLeg.Value, exerciseRates.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).capRates())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).floorRates())
    let _impliedVolatility                         (price : ICell<double>) (yoyCurve : ICell<Handle<YoYInflationTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).impliedVolatility(price.Value, yoyCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).isExpired())
    let _lastYoYInflationCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).lastYoYInflationCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).startDate())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).TYPE())
    let _yoyLeg                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).yoyLeg())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).setPricingEngine(e.Value)
                                                                     _YoYInflationCap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCap).valuationDate())
    do this.Bind(_YoYInflationCap)
(* 
    casting 
*)
    internal new () = new YoYInflationCapModel(null,null,null,null)
    member internal this.Inject v = _YoYInflationCap.Value <- v
    static member Cast (p : ICell<YoYInflationCap>) = 
        if p :? YoYInflationCapModel then 
            p :?> YoYInflationCapModel
        else
            let o = new YoYInflationCapModel ()
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
