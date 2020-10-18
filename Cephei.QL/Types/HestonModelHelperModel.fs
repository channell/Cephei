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
  calibration helper for Heston model

  </summary> *)
[<AutoSerializable(true)>]
type HestonModelHelperModel
    ( maturity                                     : ICell<Period>
    , calendar                                     : ICell<Calendar>
    , s0                                           : ICell<Handle<Quote>>
    , strikePrice                                  : ICell<double>
    , volatility                                   : ICell<Handle<Quote>>
    , riskFreeRate                                 : ICell<Handle<YieldTermStructure>>
    , dividendYield                                : ICell<Handle<YieldTermStructure>>
    , errorType                                    : ICell<CalibrationHelper.CalibrationErrorType>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<HestonModelHelper> ()
(*
    Parameters
*)
    let _maturity                                  = maturity
    let _calendar                                  = calendar
    let _s0                                        = s0
    let _strikePrice                               = strikePrice
    let _volatility                                = volatility
    let _riskFreeRate                              = riskFreeRate
    let _dividendYield                             = dividendYield
    let _errorType                                 = errorType
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _HestonModelHelper                         = cell (fun () -> withEngine pricingEngine (new HestonModelHelper (maturity.Value, calendar.Value, s0.Value, strikePrice.Value, volatility.Value, riskFreeRate.Value, dividendYield.Value, errorType.Value)))
    let _addTimesTo                                (t : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).addTimesTo(t.Value)
                                                                     _HestonModelHelper.Value)
    let _blackPrice                                (volatility : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).blackPrice(volatility.Value))
    let _maturity                                  = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).maturity())
    let _modelValue                                = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).modelValue())
    let _optionType                                = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).optionType())
    let _strike                                    = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).strike())
    let _calibrationError                          = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).calibrationError())
    let _impliedVolatility                         (targetValue : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).impliedVolatility(targetValue.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _marketValue                               = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).marketValue())
    let _setPricingEngine                          (engine : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).setPricingEngine(engine.Value)
                                                                     _HestonModelHelper.Value)
    let _volatility                                = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).volatility())
    let _volatilityType                            = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).volatilityType())
    do this.Bind(_HestonModelHelper)
(* 
    casting 
*)
    internal new () = new HestonModelHelperModel(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _HestonModelHelper <- v
    static member Cast (p : ICell<HestonModelHelper>) = 
        if p :? HestonModelHelperModel then 
            p :?> HestonModelHelperModel
        else
            let o = new HestonModelHelperModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.maturity                           = _maturity 
    member this.calendar                           = _calendar 
    member this.s0                                 = _s0 
    member this.strikePrice                        = _strikePrice 
    member this.volatility                         = _volatility 
    member this.riskFreeRate                       = _riskFreeRate 
    member this.dividendYield                      = _dividendYield 
    member this.errorType                          = _errorType 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AddTimesTo                         t   
                                                   = _addTimesTo t 
    member this.BlackPrice                         volatility   
                                                   = _blackPrice volatility 
    member this.Maturity                           = _maturity
    member this.ModelValue                         = _modelValue
    member this.OptionType                         = _optionType
    member this.Strike                             = _strike
    member this.CalibrationError                   = _calibrationError
    member this.ImpliedVolatility                  targetValue accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue accuracy maxEvaluations minVol maxVol 
    member this.MarketValue                        = _marketValue
    member this.SetPricingEngine                   engine   
                                                   = _setPricingEngine engine 
    member this.Volatility                         = _volatility
    member this.VolatilityType                     = _volatilityType
(* <summary>
  calibration helper for Heston model

  </summary> *)
[<AutoSerializable(true)>]
type HestonModelHelperModel1
    ( maturity                                     : ICell<Period>
    , calendar                                     : ICell<Calendar>
    , s0                                           : ICell<double>
    , strikePrice                                  : ICell<double>
    , volatility                                   : ICell<Handle<Quote>>
    , riskFreeRate                                 : ICell<Handle<YieldTermStructure>>
    , dividendYield                                : ICell<Handle<YieldTermStructure>>
    , errorType                                    : ICell<CalibrationHelper.CalibrationErrorType>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<HestonModelHelper> ()
(*
    Parameters
*)
    let _maturity                                  = maturity
    let _calendar                                  = calendar
    let _s0                                        = s0
    let _strikePrice                               = strikePrice
    let _volatility                                = volatility
    let _riskFreeRate                              = riskFreeRate
    let _dividendYield                             = dividendYield
    let _errorType                                 = errorType
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _HestonModelHelper                         = cell (fun () -> withEngine pricingEngine (new HestonModelHelper (maturity.Value, calendar.Value, s0.Value, strikePrice.Value, volatility.Value, riskFreeRate.Value, dividendYield.Value, errorType.Value)))
    let _addTimesTo                                (t : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).addTimesTo(t.Value)
                                                                     _HestonModelHelper.Value)
    let _blackPrice                                (volatility : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).blackPrice(volatility.Value))
    let _maturity                                  = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).maturity())
    let _modelValue                                = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).modelValue())
    let _optionType                                = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).optionType())
    let _strike                                    = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).strike())
    let _calibrationError                          = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).calibrationError())
    let _impliedVolatility                         (targetValue : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).impliedVolatility(targetValue.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _marketValue                               = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).marketValue())
    let _setPricingEngine                          (engine : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).setPricingEngine(engine.Value)
                                                                     _HestonModelHelper.Value)
    let _volatility                                = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).volatility())
    let _volatilityType                            = triv (fun () -> (withEvaluationDate _evaluationDate _HestonModelHelper).volatilityType())
    do this.Bind(_HestonModelHelper)
(* 
    casting 
*)
    internal new () = new HestonModelHelperModel1(null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _HestonModelHelper <- v
    static member Cast (p : ICell<HestonModelHelper>) = 
        if p :? HestonModelHelperModel1 then 
            p :?> HestonModelHelperModel1
        else
            let o = new HestonModelHelperModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.maturity                           = _maturity 
    member this.calendar                           = _calendar 
    member this.s0                                 = _s0 
    member this.strikePrice                        = _strikePrice 
    member this.volatility                         = _volatility 
    member this.riskFreeRate                       = _riskFreeRate 
    member this.dividendYield                      = _dividendYield 
    member this.errorType                          = _errorType 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AddTimesTo                         t   
                                                   = _addTimesTo t 
    member this.BlackPrice                         volatility   
                                                   = _blackPrice volatility 
    member this.Maturity                           = _maturity
    member this.ModelValue                         = _modelValue
    member this.OptionType                         = _optionType
    member this.Strike                             = _strike
    member this.CalibrationError                   = _calibrationError
    member this.ImpliedVolatility                  targetValue accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue accuracy maxEvaluations minVol maxVol 
    member this.MarketValue                        = _marketValue
    member this.SetPricingEngine                   engine   
                                                   = _setPricingEngine engine 
    member this.Volatility                         = _volatility
    member this.VolatilityType                     = _volatilityType
