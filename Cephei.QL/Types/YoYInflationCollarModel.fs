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
type YoYInflationCollarModel
    ( yoyLeg                                       : ICell<Generic.List<CashFlow>>
    , capRates                                     : ICell<Generic.List<double>>
    , floorRates                                   : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YoYInflationCollar> ()
(*
    Parameters
*)
    let _yoyLeg                                    = yoyLeg
    let _capRates                                  = capRates
    let _floorRates                                = floorRates
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _YoYInflationCollar                        = cell (fun () -> withEngine pricingEngine (new YoYInflationCollar (yoyLeg.Value, capRates.Value, floorRates.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).capRates())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).floorRates())
    let _impliedVolatility                         (price : ICell<double>) (yoyCurve : ICell<Handle<YoYInflationTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).impliedVolatility(price.Value, yoyCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).isExpired())
    let _lastYoYInflationCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).lastYoYInflationCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).startDate())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).TYPE())
    let _yoyLeg                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).yoyLeg())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).setPricingEngine(e.Value)
                                                                     _YoYInflationCollar.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCollar).valuationDate())
    do this.Bind(_YoYInflationCollar)
(* 
    casting 
*)
    internal new () = YoYInflationCollarModel(null,null,null,null,null)
    member internal this.Inject v = _YoYInflationCollar.Value <- v
    static member Cast (p : ICell<YoYInflationCollar>) = 
        if p :? YoYInflationCollarModel then 
            p :?> YoYInflationCollarModel
        else
            let o = new YoYInflationCollarModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.yoyLeg                             = _yoyLeg 
    member this.capRates                           = _capRates 
    member this.floorRates                         = _floorRates 
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
