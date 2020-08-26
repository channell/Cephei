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
type CapModel
    ( floatingLeg                                  : ICell<Generic.List<CashFlow>>
    , exerciseRates                                : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Cap> ()
(*
    Parameters
*)
    let _floatingLeg                               = floatingLeg
    let _exerciseRates                             = exerciseRates
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _Cap                                       = cell (fun () -> withEngine pricingEngine (new Cap (floatingLeg.Value, exerciseRates.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).capRates())
    let _floatingLeg                               = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).floatingLeg())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).floorRates())
    let _getType                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).getType())
    let _impliedVolatility                         (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>) (Type : ICell<VolatilityType>) (displacement : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value, Type.Value, displacement.Value))
    let _impliedVolatility1                        (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).isExpired())
    let _lastFloatingRateCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).lastFloatingRateCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).startDate())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _Cap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _Cap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).setPricingEngine(e.Value)
                                                                     _Cap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Cap).valuationDate())
    do this.Bind(_Cap)

(* 
    Externally visible/bindable properties
*)
    member this.floatingLeg                        = _floatingLeg 
    member this.exerciseRates                      = _exerciseRates 
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
