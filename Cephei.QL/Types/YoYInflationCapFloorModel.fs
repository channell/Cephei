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
  instruments  Note that the standard YoY inflation cap/floor defined here is different from nominal, because in nominal world standard cap/floors do not have the first optionlet.  This is because they set in advance so there is no point.  However, yoy inflation generally sets (effectively) in arrears, (actually in arrears vs lag of a few months) thus the first optionlet is relevant.  Hence we can do a parity test without a special definition of the YoY cap/floor instrument.  - the relationship between the values of caps, floors and the resulting collars is checked. - the put-call parity between the values of caps, floors and swaps is checked. - the correctness of the returned value is tested by checking it against a known good value.

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationCapFloorModel
    ( Type                                         : ICell<CapFloorType>
    , yoyLeg                                       : ICell<Generic.List<CashFlow>>
    , strikes                                      : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YoYInflationCapFloor> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _yoyLeg                                    = yoyLeg
    let _strikes                                   = strikes
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _YoYInflationCapFloor                      = cell (fun () -> withEngine evaluationDate pricingEngine (new YoYInflationCapFloor (Type.Value, yoyLeg.Value, strikes.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).capRates())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).floorRates())
    let _impliedVolatility                         (price : ICell<double>) (yoyCurve : ICell<Handle<YoYInflationTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).impliedVolatility(price.Value, yoyCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).isExpired())
    let _lastYoYInflationCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).lastYoYInflationCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).startDate())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).TYPE())
    let _yoyLeg                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).yoyLeg())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).setPricingEngine(e.Value)
                                                                     _YoYInflationCapFloor.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).valuationDate())
    do this.Bind(_YoYInflationCapFloor)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.yoyLeg                             = _yoyLeg 
    member this.strikes                            = _strikes 
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
    member this.Type1                              = _type
    member this.YoyLeg                             = _yoyLeg
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
(* <summary>
  instruments  Note that the standard YoY inflation cap/floor defined here is different from nominal, because in nominal world standard cap/floors do not have the first optionlet.  This is because they set in advance so there is no point.  However, yoy inflation generally sets (effectively) in arrears, (actually in arrears vs lag of a few months) thus the first optionlet is relevant.  Hence we can do a parity test without a special definition of the YoY cap/floor instrument.  - the relationship between the values of caps, floors and the resulting collars is checked. - the put-call parity between the values of caps, floors and swaps is checked. - the correctness of the returned value is tested by checking it against a known good value.

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationCapFloorModel1
    ( Type                                         : ICell<CapFloorType>
    , yoyLeg                                       : ICell<Generic.List<CashFlow>>
    , capRates                                     : ICell<Generic.List<double>>
    , floorRates                                   : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<YoYInflationCapFloor> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _yoyLeg                                    = yoyLeg
    let _capRates                                  = capRates
    let _floorRates                                = floorRates
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _YoYInflationCapFloor                      = cell (fun () -> withEngine evaluationDate pricingEngine (new YoYInflationCapFloor (Type.Value, yoyLeg.Value, capRates.Value, floorRates.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).capRates())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).floorRates())
    let _impliedVolatility                         (price : ICell<double>) (yoyCurve : ICell<Handle<YoYInflationTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).impliedVolatility(price.Value, yoyCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).isExpired())
    let _lastYoYInflationCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).lastYoYInflationCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).startDate())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).TYPE())
    let _yoyLeg                                    = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).yoyLeg())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).setPricingEngine(e.Value)
                                                                     _YoYInflationCapFloor.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _YoYInflationCapFloor).valuationDate())
    do this.Bind(_YoYInflationCapFloor)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
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
    member this.Type1                              = _type
    member this.YoyLeg                             = _yoyLeg
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
