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
type SwaptionHelperModel
    ( maturity                                     : ICell<Period>
    , length                                       : ICell<Period>
    , volatility                                   : ICell<Handle<Quote>>
    , index                                        : ICell<IborIndex>
    , fixedLegTenor                                : ICell<Period>
    , fixedLegDayCounter                           : ICell<DayCounter>
    , floatingLegDayCounter                        : ICell<DayCounter>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    , errorType                                    : ICell<CalibrationHelper.CalibrationErrorType>
    , strike                                       : ICell<Nullable<double>>
    , nominal                                      : ICell<double>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SwaptionHelper> ()
(*
    Parameters
*)
    let _maturity                                  = maturity
    let _length                                    = length
    let _volatility                                = volatility
    let _index                                     = index
    let _fixedLegTenor                             = fixedLegTenor
    let _fixedLegDayCounter                        = fixedLegDayCounter
    let _floatingLegDayCounter                     = floatingLegDayCounter
    let _termStructure                             = termStructure
    let _errorType                                 = errorType
    let _strike                                    = strike
    let _nominal                                   = nominal
    let _Type                                      = Type
    let _shift                                     = shift
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _SwaptionHelper                            = cell (fun () -> withEngine pricingEngine (new SwaptionHelper (maturity.Value, length.Value, volatility.Value, index.Value, fixedLegTenor.Value, fixedLegDayCounter.Value, floatingLegDayCounter.Value, termStructure.Value, errorType.Value, strike.Value, nominal.Value, Type.Value, shift.Value)))
    let _addTimesTo                                (times : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).addTimesTo(times.Value)
                                                                     _SwaptionHelper.Value)
    let _blackPrice                                (sigma : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).blackPrice(sigma.Value))
    let _modelValue                                = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).modelValue())
    let _swaption                                  = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).swaption())
    let _underlyingSwap                            = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).underlyingSwap())
    let _calibrationError                          = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).calibrationError())
    let _impliedVolatility                         (targetValue : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).impliedVolatility(targetValue.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _marketValue                               = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).marketValue())
    let _setPricingEngine                          (engine : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).setPricingEngine(engine.Value)
                                                                     _SwaptionHelper.Value)
    let _volatility                                = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).volatility())
    let _volatilityType                            = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).volatilityType())
    do this.Bind(_SwaptionHelper)
(* 
    casting 
*)
    internal new () = new SwaptionHelperModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwaptionHelper <- v
    static member Cast (p : ICell<SwaptionHelper>) = 
        if p :? SwaptionHelperModel then 
            p :?> SwaptionHelperModel
        else
            let o = new SwaptionHelperModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.maturity                           = _maturity 
    member this.length                             = _length 
    member this.volatility                         = _volatility 
    member this.index                              = _index 
    member this.fixedLegTenor                      = _fixedLegTenor 
    member this.fixedLegDayCounter                 = _fixedLegDayCounter 
    member this.floatingLegDayCounter              = _floatingLegDayCounter 
    member this.termStructure                      = _termStructure 
    member this.errorType                          = _errorType 
    member this.strike                             = _strike 
    member this.nominal                            = _nominal 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AddTimesTo                         times   
                                                   = _addTimesTo times 
    member this.BlackPrice                         sigma   
                                                   = _blackPrice sigma 
    member this.ModelValue                         = _modelValue
    member this.Swaption                           = _swaption
    member this.UnderlyingSwap                     = _underlyingSwap
    member this.CalibrationError                   = _calibrationError
    member this.ImpliedVolatility                  targetValue accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue accuracy maxEvaluations minVol maxVol 
    member this.MarketValue                        = _marketValue
    member this.SetPricingEngine                   engine   
                                                   = _setPricingEngine engine 
    member this.Volatility                         = _volatility
    member this.VolatilityType                     = _volatilityType
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type SwaptionHelperModel1
    ( exerciseDate                                 : ICell<Date>
    , endDate                                      : ICell<Date>
    , volatility                                   : ICell<Handle<Quote>>
    , index                                        : ICell<IborIndex>
    , fixedLegTenor                                : ICell<Period>
    , fixedLegDayCounter                           : ICell<DayCounter>
    , floatingLegDayCounter                        : ICell<DayCounter>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    , errorType                                    : ICell<CalibrationHelper.CalibrationErrorType>
    , strike                                       : ICell<Nullable<double>>
    , nominal                                      : ICell<double>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SwaptionHelper> ()
(*
    Parameters
*)
    let _exerciseDate                              = exerciseDate
    let _endDate                                   = endDate
    let _volatility                                = volatility
    let _index                                     = index
    let _fixedLegTenor                             = fixedLegTenor
    let _fixedLegDayCounter                        = fixedLegDayCounter
    let _floatingLegDayCounter                     = floatingLegDayCounter
    let _termStructure                             = termStructure
    let _errorType                                 = errorType
    let _strike                                    = strike
    let _nominal                                   = nominal
    let _Type                                      = Type
    let _shift                                     = shift
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _SwaptionHelper                            = cell (fun () -> withEngine pricingEngine (new SwaptionHelper (exerciseDate.Value, endDate.Value, volatility.Value, index.Value, fixedLegTenor.Value, fixedLegDayCounter.Value, floatingLegDayCounter.Value, termStructure.Value, errorType.Value, strike.Value, nominal.Value, Type.Value, shift.Value)))
    let _addTimesTo                                (times : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).addTimesTo(times.Value)
                                                                     _SwaptionHelper.Value)
    let _blackPrice                                (sigma : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).blackPrice(sigma.Value))
    let _modelValue                                = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).modelValue())
    let _swaption                                  = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).swaption())
    let _underlyingSwap                            = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).underlyingSwap())
    let _calibrationError                          = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).calibrationError())
    let _impliedVolatility                         (targetValue : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).impliedVolatility(targetValue.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _marketValue                               = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).marketValue())
    let _setPricingEngine                          (engine : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).setPricingEngine(engine.Value)
                                                                     _SwaptionHelper.Value)
    let _volatility                                = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).volatility())
    let _volatilityType                            = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).volatilityType())
    do this.Bind(_SwaptionHelper)
(* 
    casting 
*)
    internal new () = new SwaptionHelperModel1(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwaptionHelper <- v
    static member Cast (p : ICell<SwaptionHelper>) = 
        if p :? SwaptionHelperModel1 then 
            p :?> SwaptionHelperModel1
        else
            let o = new SwaptionHelperModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.exerciseDate                       = _exerciseDate 
    member this.endDate                            = _endDate 
    member this.volatility                         = _volatility 
    member this.index                              = _index 
    member this.fixedLegTenor                      = _fixedLegTenor 
    member this.fixedLegDayCounter                 = _fixedLegDayCounter 
    member this.floatingLegDayCounter              = _floatingLegDayCounter 
    member this.termStructure                      = _termStructure 
    member this.errorType                          = _errorType 
    member this.strike                             = _strike 
    member this.nominal                            = _nominal 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AddTimesTo                         times   
                                                   = _addTimesTo times 
    member this.BlackPrice                         sigma   
                                                   = _blackPrice sigma 
    member this.ModelValue                         = _modelValue
    member this.Swaption                           = _swaption
    member this.UnderlyingSwap                     = _underlyingSwap
    member this.CalibrationError                   = _calibrationError
    member this.ImpliedVolatility                  targetValue accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue accuracy maxEvaluations minVol maxVol 
    member this.MarketValue                        = _marketValue
    member this.SetPricingEngine                   engine   
                                                   = _setPricingEngine engine 
    member this.Volatility                         = _volatility
    member this.VolatilityType                     = _volatilityType
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type SwaptionHelperModel2
    ( exerciseDate                                 : ICell<Date>
    , length                                       : ICell<Period>
    , volatility                                   : ICell<Handle<Quote>>
    , index                                        : ICell<IborIndex>
    , fixedLegTenor                                : ICell<Period>
    , fixedLegDayCounter                           : ICell<DayCounter>
    , floatingLegDayCounter                        : ICell<DayCounter>
    , termStructure                                : ICell<Handle<YieldTermStructure>>
    , errorType                                    : ICell<CalibrationHelper.CalibrationErrorType>
    , strike                                       : ICell<Nullable<double>>
    , nominal                                      : ICell<double>
    , Type                                         : ICell<VolatilityType>
    , shift                                        : ICell<double>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SwaptionHelper> ()
(*
    Parameters
*)
    let _exerciseDate                              = exerciseDate
    let _length                                    = length
    let _volatility                                = volatility
    let _index                                     = index
    let _fixedLegTenor                             = fixedLegTenor
    let _fixedLegDayCounter                        = fixedLegDayCounter
    let _floatingLegDayCounter                     = floatingLegDayCounter
    let _termStructure                             = termStructure
    let _errorType                                 = errorType
    let _strike                                    = strike
    let _nominal                                   = nominal
    let _Type                                      = Type
    let _shift                                     = shift
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _SwaptionHelper                            = cell (fun () -> withEngine pricingEngine (new SwaptionHelper (exerciseDate.Value, length.Value, volatility.Value, index.Value, fixedLegTenor.Value, fixedLegDayCounter.Value, floatingLegDayCounter.Value, termStructure.Value, errorType.Value, strike.Value, nominal.Value, Type.Value, shift.Value)))
    let _addTimesTo                                (times : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).addTimesTo(times.Value)
                                                                     _SwaptionHelper.Value)
    let _blackPrice                                (sigma : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).blackPrice(sigma.Value))
    let _modelValue                                = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).modelValue())
    let _swaption                                  = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).swaption())
    let _underlyingSwap                            = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).underlyingSwap())
    let _calibrationError                          = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).calibrationError())
    let _impliedVolatility                         (targetValue : ICell<double>) (accuracy : ICell<double>) (maxEvaluations : ICell<int>) (minVol : ICell<double>) (maxVol : ICell<double>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).impliedVolatility(targetValue.Value, accuracy.Value, maxEvaluations.Value, minVol.Value, maxVol.Value))
    let _marketValue                               = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).marketValue())
    let _setPricingEngine                          (engine : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).setPricingEngine(engine.Value)
                                                                     _SwaptionHelper.Value)
    let _volatility                                = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).volatility())
    let _volatilityType                            = triv (fun () -> (withEvaluationDate _evaluationDate _SwaptionHelper).volatilityType())
    do this.Bind(_SwaptionHelper)
(* 
    casting 
*)
    internal new () = new SwaptionHelperModel2(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _SwaptionHelper <- v
    static member Cast (p : ICell<SwaptionHelper>) = 
        if p :? SwaptionHelperModel2 then 
            p :?> SwaptionHelperModel2
        else
            let o = new SwaptionHelperModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.exerciseDate                       = _exerciseDate 
    member this.length                             = _length 
    member this.volatility                         = _volatility 
    member this.index                              = _index 
    member this.fixedLegTenor                      = _fixedLegTenor 
    member this.fixedLegDayCounter                 = _fixedLegDayCounter 
    member this.floatingLegDayCounter              = _floatingLegDayCounter 
    member this.termStructure                      = _termStructure 
    member this.errorType                          = _errorType 
    member this.strike                             = _strike 
    member this.nominal                            = _nominal 
    member this.Type                               = _Type 
    member this.shift                              = _shift 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AddTimesTo                         times   
                                                   = _addTimesTo times 
    member this.BlackPrice                         sigma   
                                                   = _blackPrice sigma 
    member this.ModelValue                         = _modelValue
    member this.Swaption                           = _swaption
    member this.UnderlyingSwap                     = _underlyingSwap
    member this.CalibrationError                   = _calibrationError
    member this.ImpliedVolatility                  targetValue accuracy maxEvaluations minVol maxVol   
                                                   = _impliedVolatility targetValue accuracy maxEvaluations minVol maxVol 
    member this.MarketValue                        = _marketValue
    member this.SetPricingEngine                   engine   
                                                   = _setPricingEngine engine 
    member this.Volatility                         = _volatility
    member this.VolatilityType                     = _volatilityType
