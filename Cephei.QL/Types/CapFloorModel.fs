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
type CapFloorModel
    ( Type                                         : ICell<CapFloorType>
    , floatingLeg                                  : ICell<Generic.List<CashFlow>>
    , capRates                                     : ICell<Generic.List<double>>
    , floorRates                                   : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CapFloor> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _floatingLeg                               = floatingLeg
    let _capRates                                  = capRates
    let _floorRates                                = floorRates
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CapFloor                                  = cell (fun () -> withEngine pricingEngine (new CapFloor (Type.Value, floatingLeg.Value, capRates.Value, floorRates.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).capRates())
    let _floatingLeg                               = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).floatingLeg())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).floorRates())
    let _getType                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).getType())
    let _impliedVolatility                         (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>) (Type : ICell<VolatilityType>) (displacement : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value, Type.Value, displacement.Value))
    let _impliedVolatility1                        (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).isExpired())
    let _lastFloatingRateCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).lastFloatingRateCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).startDate())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CapFloor).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CapFloor).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).setPricingEngine(e.Value)
                                                                     _CapFloor.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).valuationDate())
    do this.Bind(_CapFloor)
(* 
    casting 
*)
    internal new () = new CapFloorModel(null,null,null,null,null,null)
    member internal this.Inject v = _CapFloor.Value <- v
    static member Cast (p : ICell<CapFloor>) = 
        if p :? CapFloorModel then 
            p :?> CapFloorModel
        else
            let o = new CapFloorModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.floatingLeg                        = _floatingLeg 
    member this.capRates                           = _capRates 
    member this.floorRates                         = _floorRates 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AtmRate                            discountCurve   
                                                   = _atmRate discountCurve 
    member this.CapRates                           = _capRates
    member this.FloatingLeg                        = _floatingLeg
    member this.FloorRates                         = _floorRates
    member this.GetType                            = _getType
    member this.ImpliedVolatility                  targetValue discountCurve guess accuracy maxEvaluations minVol maxVol Type displacement   
                                                   = _impliedVolatility targetValue discountCurve guess accuracy maxEvaluations minVol maxVol Type displacement 
    member this.ImpliedVolatility1                 targetValue discountCurve guess accuracy maxEvaluations   
                                                   = _impliedVolatility1 targetValue discountCurve guess accuracy maxEvaluations 
    member this.IsExpired                          = _isExpired
    member this.LastFloatingRateCoupon             = _lastFloatingRateCoupon
    member this.MaturityDate                       = _maturityDate
    member this.Optionlet                          i   
                                                   = _optionlet i 
    member this.StartDate                          = _startDate
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type CapFloorModel1
    ( Type                                         : ICell<CapFloorType>
    , floatingLeg                                  : ICell<Generic.List<CashFlow>>
    , strikes                                      : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CapFloor> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _floatingLeg                               = floatingLeg
    let _strikes                                   = strikes
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CapFloor                                  = cell (fun () -> withEngine pricingEngine (new CapFloor (Type.Value, floatingLeg.Value, strikes.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).capRates())
    let _floatingLeg                               = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).floatingLeg())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).floorRates())
    let _getType                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).getType())
    let _impliedVolatility                         (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>) (Type : ICell<VolatilityType>) (displacement : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value, Type.Value, displacement.Value))
    let _impliedVolatility1                        (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).isExpired())
    let _lastFloatingRateCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).lastFloatingRateCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).startDate())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CapFloor).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CapFloor).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).setPricingEngine(e.Value)
                                                                     _CapFloor.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CapFloor).valuationDate())
    do this.Bind(_CapFloor)
(* 
    casting 
*)
    internal new () = new CapFloorModel1(null,null,null,null,null)
    member internal this.Inject v = _CapFloor.Value <- v
    static member Cast (p : ICell<CapFloor>) = 
        if p :? CapFloorModel1 then 
            p :?> CapFloorModel1
        else
            let o = new CapFloorModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.floatingLeg                        = _floatingLeg 
    member this.strikes                            = _strikes 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AtmRate                            discountCurve   
                                                   = _atmRate discountCurve 
    member this.CapRates                           = _capRates
    member this.FloatingLeg                        = _floatingLeg
    member this.FloorRates                         = _floorRates
    member this.GetType                            = _getType
    member this.ImpliedVolatility                  targetValue discountCurve guess accuracy maxEvaluations minVol maxVol Type displacement   
                                                   = _impliedVolatility targetValue discountCurve guess accuracy maxEvaluations minVol maxVol Type displacement 
    member this.ImpliedVolatility1                 targetValue discountCurve guess accuracy maxEvaluations   
                                                   = _impliedVolatility1 targetValue discountCurve guess accuracy maxEvaluations 
    member this.IsExpired                          = _isExpired
    member this.LastFloatingRateCoupon             = _lastFloatingRateCoupon
    member this.MaturityDate                       = _maturityDate
    member this.Optionlet                          i   
                                                   = _optionlet i 
    member this.StartDate                          = _startDate
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
