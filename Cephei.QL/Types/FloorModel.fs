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
type FloorModel
    ( floatingLeg                                  : ICell<Generic.List<CashFlow>>
    , exerciseRates                                : ICell<Generic.List<double>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<Floor> ()
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
    let _Floor                                     = cell (fun () -> withEngine pricingEngine (new Floor (floatingLeg.Value, exerciseRates.Value)))
    let _atmRate                                   (discountCurve : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).atmRate(discountCurve.Value))
    let _capRates                                  = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).capRates())
    let _floatingLeg                               = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).floatingLeg())
    let _floorRates                                = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).floorRates())
    let _getType                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).getType())
    let _impliedVolatility                         (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>) (Type : ICell<VolatilityType>) (displacement : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value, Type.Value, displacement.Value))
    let _impliedVolatility1                        (targetValue : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (guess : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).impliedVolatility(targetValue.Value, discountCurve.Value, guess.Value, accuracy.Value, maxEvaluations.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).isExpired())
    let _lastFloatingRateCoupon                    = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).lastFloatingRateCoupon())
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).maturityDate())
    let _optionlet                                 (i : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).optionlet(i.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).startDate())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _Floor).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _Floor).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).setPricingEngine(e.Value)
                                                                     _Floor.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _Floor).valuationDate())
    do this.Bind(_Floor)
(* 
    casting 
*)
    internal new () = FloorModel(null,null,null,null)
    member internal this.Inject v = _Floor.Value <- v
    static member Cast (p : ICell<Floor>) = 
        if p :? FloorModel then 
            p :?> FloorModel
        else
            let o = new FloorModel ()
            o.Inject p.Value
            o
                            

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
