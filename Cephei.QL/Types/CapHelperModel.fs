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
type CapHelperModel
    ( length                                       : ICell<Period>
    , volatility                                   : ICell<Handle<Quote>>
    , index                                        : ICell<IborIndex>
    , fixedLegFrequency                            : ICell<Frequency>
    , fixedLegDayCounter                           : ICell<DayCounter>
    , includeFirstSwaplet                          : ICell<bool>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    , errorType                                    : ICell<CalibrationHelper.CalibrationErrorType>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CapHelper> ()
(*
    Parameters
*)
    let _length                                    = length
    let _volatility                                = volatility
    let _index                                     = index
    let _fixedLegFrequency                         = fixedLegFrequency
    let _fixedLegDayCounter                        = fixedLegDayCounter
    let _includeFirstSwaplet                       = includeFirstSwaplet
    let _termStructure                             = termStructure
    let _errorType                                 = errorType
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _CapHelper                                 = make (fun () -> withEngine pricingEngine evaluationDate (new CapHelper (length.Value, volatility.Value, index.Value, fixedLegFrequency.Value, fixedLegDayCounter.Value, includeFirstSwaplet.Value, termStructure.Value, errorType.Value)))
    let _addTimesTo                                (times : ICell<Generic.List<double>>)   
                                                   = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).addTimesTo(times.Value)
                                                                                _CapHelper.Value)
    let _blackPrice                                (sigma : ICell<double>)   
                                                   = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).blackPrice(sigma.Value))
    let _modelValue                                = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).modelValue())
    let _calibrationError                          = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).calibrationError())
    let _impliedVolatility                         (targetValue : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).impliedVolatility(targetValue.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _marketValue                               = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).marketValue())
    let _setPricingEngine                          (engine : ICell<IPricingEngine>)   
                                                   = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).setPricingEngine(engine.Value)
                                                                                _CapHelper.Value)
    let _volatility                                = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).volatility())
    let _volatilityType                            = triv _CapHelper (fun () -> (withEvaluationDate _evaluationDate _CapHelper).volatilityType())
    do this.Bind(_CapHelper)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new CapHelperModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CapHelper <- v
    static member Cast (p : ICell<CapHelper>) = 
        if p :? CapHelperModel then 
            p :?> CapHelperModel
        else
            let o = new CapHelperModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.length                             = _length 
    member this.volatility                         = _volatility 
    member this.index                              = _index 
    member this.fixedLegFrequency                  = _fixedLegFrequency 
    member this.fixedLegDayCounter                 = _fixedLegDayCounter 
    member this.includeFirstSwaplet                = _includeFirstSwaplet 
    member this.termStructure                      = _termStructure 
    member this.errorType                          = _errorType 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AddTimesTo                         times   
                                                   = _addTimesTo times 
    member this.BlackPrice                         sigma   
                                                   = _blackPrice sigma 
    member this.ModelValue                         = _modelValue
    member this.CalibrationError                   = _calibrationError
    member this.ImpliedVolatility                  targetValue accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue accuracy maxEvaluations minVol maxVol 
    member this.MarketValue                        = _marketValue
    member this.SetPricingEngine                   engine   
                                                   = _setPricingEngine engine 
    member this.Volatility                         = _volatility
    member this.VolatilityType                     = _volatilityType
