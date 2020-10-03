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
type FloatFloatSwapModel
    ( Type                                         : ICell<VanillaSwap.Type>
    , nominal1                                     : ICell<Generic.List<double>>
    , nominal2                                     : ICell<Generic.List<double>>
    , schedule1                                    : ICell<Schedule>
    , index1                                       : ICell<InterestRateIndex>
    , dayCount1                                    : ICell<DayCounter>
    , schedule2                                    : ICell<Schedule>
    , index2                                       : ICell<InterestRateIndex>
    , dayCount2                                    : ICell<DayCounter>
    , intermediateCapitalExchange                  : ICell<bool>
    , finalCapitalExchange                         : ICell<bool>
    , gearing1                                     : ICell<Generic.List<double>>
    , spread1                                      : ICell<Generic.List<double>>
    , cappedRate1                                  : ICell<List<Nullable<double>>>
    , flooredRate1                                 : ICell<List<Nullable<double>>>
    , gearing2                                     : ICell<Generic.List<double>>
    , spread2                                      : ICell<Generic.List<double>>
    , cappedRate2                                  : ICell<List<Nullable<double>>>
    , flooredRate2                                 : ICell<List<Nullable<double>>>
    , paymentConvention1                           : ICell<Nullable<BusinessDayConvention>>
    , paymentConvention2                           : ICell<Nullable<BusinessDayConvention>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FloatFloatSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal1                                  = nominal1
    let _nominal2                                  = nominal2
    let _schedule1                                 = schedule1
    let _index1                                    = index1
    let _dayCount1                                 = dayCount1
    let _schedule2                                 = schedule2
    let _index2                                    = index2
    let _dayCount2                                 = dayCount2
    let _intermediateCapitalExchange               = intermediateCapitalExchange
    let _finalCapitalExchange                      = finalCapitalExchange
    let _gearing1                                  = gearing1
    let _spread1                                   = spread1
    let _cappedRate1                               = cappedRate1
    let _flooredRate1                              = flooredRate1
    let _gearing2                                  = gearing2
    let _spread2                                   = spread2
    let _cappedRate2                               = cappedRate2
    let _flooredRate2                              = flooredRate2
    let _paymentConvention1                        = paymentConvention1
    let _paymentConvention2                        = paymentConvention2
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FloatFloatSwap                            = cell (fun () -> withEngine pricingEngine (new FloatFloatSwap (Type.Value, nominal1.Value, nominal2.Value, schedule1.Value, index1.Value, dayCount1.Value, schedule2.Value, index2.Value, dayCount2.Value, intermediateCapitalExchange.Value, finalCapitalExchange.Value, gearing1.Value, spread1.Value, cappedRate1.Value, flooredRate1.Value, gearing2.Value, spread2.Value, cappedRate2.Value, flooredRate2.Value, paymentConvention1.Value, paymentConvention2.Value)))
    let _cappedRate1                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).cappedRate1())
    let _cappedRate2                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).cappedRate2())
    let _dayCount1                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).dayCount1())
    let _dayCount2                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).dayCount2())
    let _flooredRate1                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).flooredRate1())
    let _flooredRate2                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).flooredRate2())
    let _gearing1                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).gearing1())
    let _gearing2                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).gearing2())
    let _index1                                    = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).index1())
    let _index2                                    = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).index2())
    let _leg1                                      = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).leg1())
    let _leg2                                      = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).leg2())
    let _nominal1                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).nominal1())
    let _nominal2                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).nominal2())
    let _paymentConvention1                        = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).paymentConvention1())
    let _paymentConvention2                        = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).paymentConvention2())
    let _schedule1                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).schedule1())
    let _schedule2                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).schedule2())
    let _spread1                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).spread1())
    let _spread2                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).spread2())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).TYPE())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).setPricingEngine(e.Value)
                                                                     _FloatFloatSwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).valuationDate())
    do this.Bind(_FloatFloatSwap)
(* 
    casting 
*)
    internal new () = FloatFloatSwapModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FloatFloatSwap.Value <- v
    static member Cast (p : ICell<FloatFloatSwap>) = 
        if p :? FloatFloatSwapModel then 
            p :?> FloatFloatSwapModel
        else
            let o = new FloatFloatSwapModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal1                           = _nominal1 
    member this.nominal2                           = _nominal2 
    member this.schedule1                          = _schedule1 
    member this.index1                             = _index1 
    member this.dayCount1                          = _dayCount1 
    member this.schedule2                          = _schedule2 
    member this.index2                             = _index2 
    member this.dayCount2                          = _dayCount2 
    member this.intermediateCapitalExchange        = _intermediateCapitalExchange 
    member this.finalCapitalExchange               = _finalCapitalExchange 
    member this.gearing1                           = _gearing1 
    member this.spread1                            = _spread1 
    member this.cappedRate1                        = _cappedRate1 
    member this.flooredRate1                       = _flooredRate1 
    member this.gearing2                           = _gearing2 
    member this.spread2                            = _spread2 
    member this.cappedRate2                        = _cappedRate2 
    member this.flooredRate2                       = _flooredRate2 
    member this.paymentConvention1                 = _paymentConvention1 
    member this.paymentConvention2                 = _paymentConvention2 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.CappedRate1                        = _cappedRate1
    member this.CappedRate2                        = _cappedRate2
    member this.DayCount1                          = _dayCount1
    member this.DayCount2                          = _dayCount2
    member this.FlooredRate1                       = _flooredRate1
    member this.FlooredRate2                       = _flooredRate2
    member this.Gearing1                           = _gearing1
    member this.Gearing2                           = _gearing2
    member this.Index1                             = _index1
    member this.Index2                             = _index2
    member this.Leg1                               = _leg1
    member this.Leg2                               = _leg2
    member this.Nominal1                           = _nominal1
    member this.Nominal2                           = _nominal2
    member this.PaymentConvention1                 = _paymentConvention1
    member this.PaymentConvention2                 = _paymentConvention2
    member this.Schedule1                          = _schedule1
    member this.Schedule2                          = _schedule2
    member this.Spread1                            = _spread1
    member this.Spread2                            = _spread2
    member this.Type1                              = _type
    member this.EndDiscounts                       j   
                                                   = _endDiscounts j 
    member this.Engine                             = _engine
    member this.IsExpired                          = _isExpired
    member this.Leg                                j   
                                                   = _leg j 
    member this.LegBPS                             j   
                                                   = _legBPS j 
    member this.LegNPV                             j   
                                                   = _legNPV j 
    member this.MaturityDate                       = _maturityDate
    member this.NpvDateDiscount                    = _npvDateDiscount
    member this.Payer                              j   
                                                   = _payer j 
    member this.StartDate                          = _startDate
    member this.StartDiscounts                     j   
                                                   = _startDiscounts j 
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
type FloatFloatSwapModel1
    ( Type                                         : ICell<VanillaSwap.Type>
    , nominal1                                     : ICell<double>
    , nominal2                                     : ICell<double>
    , schedule1                                    : ICell<Schedule>
    , index1                                       : ICell<InterestRateIndex>
    , dayCount1                                    : ICell<DayCounter>
    , schedule2                                    : ICell<Schedule>
    , index2                                       : ICell<InterestRateIndex>
    , dayCount2                                    : ICell<DayCounter>
    , intermediateCapitalExchange                  : ICell<bool>
    , finalCapitalExchange                         : ICell<bool>
    , gearing1                                     : ICell<double>
    , spread1                                      : ICell<double>
    , cappedRate1                                  : ICell<Nullable<double>>
    , flooredRate1                                 : ICell<Nullable<double>>
    , gearing2                                     : ICell<double>
    , spread2                                      : ICell<double>
    , cappedRate2                                  : ICell<Nullable<double>>
    , flooredRate2                                 : ICell<Nullable<double>>
    , paymentConvention1                           : ICell<Nullable<BusinessDayConvention>>
    , paymentConvention2                           : ICell<Nullable<BusinessDayConvention>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FloatFloatSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal1                                  = nominal1
    let _nominal2                                  = nominal2
    let _schedule1                                 = schedule1
    let _index1                                    = index1
    let _dayCount1                                 = dayCount1
    let _schedule2                                 = schedule2
    let _index2                                    = index2
    let _dayCount2                                 = dayCount2
    let _intermediateCapitalExchange               = intermediateCapitalExchange
    let _finalCapitalExchange                      = finalCapitalExchange
    let _gearing1                                  = gearing1
    let _spread1                                   = spread1
    let _cappedRate1                               = cappedRate1
    let _flooredRate1                              = flooredRate1
    let _gearing2                                  = gearing2
    let _spread2                                   = spread2
    let _cappedRate2                               = cappedRate2
    let _flooredRate2                              = flooredRate2
    let _paymentConvention1                        = paymentConvention1
    let _paymentConvention2                        = paymentConvention2
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FloatFloatSwap                            = cell (fun () -> withEngine pricingEngine (new FloatFloatSwap (Type.Value, nominal1.Value, nominal2.Value, schedule1.Value, index1.Value, dayCount1.Value, schedule2.Value, index2.Value, dayCount2.Value, intermediateCapitalExchange.Value, finalCapitalExchange.Value, gearing1.Value, spread1.Value, cappedRate1.Value, flooredRate1.Value, gearing2.Value, spread2.Value, cappedRate2.Value, flooredRate2.Value, paymentConvention1.Value, paymentConvention2.Value)))
    let _cappedRate1                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).cappedRate1())
    let _cappedRate2                               = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).cappedRate2())
    let _dayCount1                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).dayCount1())
    let _dayCount2                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).dayCount2())
    let _flooredRate1                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).flooredRate1())
    let _flooredRate2                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).flooredRate2())
    let _gearing1                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).gearing1())
    let _gearing2                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).gearing2())
    let _index1                                    = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).index1())
    let _index2                                    = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).index2())
    let _leg1                                      = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).leg1())
    let _leg2                                      = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).leg2())
    let _nominal1                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).nominal1())
    let _nominal2                                  = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).nominal2())
    let _paymentConvention1                        = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).paymentConvention1())
    let _paymentConvention2                        = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).paymentConvention2())
    let _schedule1                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).schedule1())
    let _schedule2                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).schedule2())
    let _spread1                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).spread1())
    let _spread2                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).spread2())
    let _type                                      = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).TYPE())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).setPricingEngine(e.Value)
                                                                     _FloatFloatSwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _FloatFloatSwap).valuationDate())
    do this.Bind(_FloatFloatSwap)
(* 
    casting 
*)
    internal new () = FloatFloatSwapModel1(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _FloatFloatSwap.Value <- v
    static member Cast (p : ICell<FloatFloatSwap>) = 
        if p :? FloatFloatSwapModel1 then 
            p :?> FloatFloatSwapModel1
        else
            let o = new FloatFloatSwapModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal1                           = _nominal1 
    member this.nominal2                           = _nominal2 
    member this.schedule1                          = _schedule1 
    member this.index1                             = _index1 
    member this.dayCount1                          = _dayCount1 
    member this.schedule2                          = _schedule2 
    member this.index2                             = _index2 
    member this.dayCount2                          = _dayCount2 
    member this.intermediateCapitalExchange        = _intermediateCapitalExchange 
    member this.finalCapitalExchange               = _finalCapitalExchange 
    member this.gearing1                           = _gearing1 
    member this.spread1                            = _spread1 
    member this.cappedRate1                        = _cappedRate1 
    member this.flooredRate1                       = _flooredRate1 
    member this.gearing2                           = _gearing2 
    member this.spread2                            = _spread2 
    member this.cappedRate2                        = _cappedRate2 
    member this.flooredRate2                       = _flooredRate2 
    member this.paymentConvention1                 = _paymentConvention1 
    member this.paymentConvention2                 = _paymentConvention2 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.CappedRate1                        = _cappedRate1
    member this.CappedRate2                        = _cappedRate2
    member this.DayCount1                          = _dayCount1
    member this.DayCount2                          = _dayCount2
    member this.FlooredRate1                       = _flooredRate1
    member this.FlooredRate2                       = _flooredRate2
    member this.Gearing1                           = _gearing1
    member this.Gearing2                           = _gearing2
    member this.Index1                             = _index1
    member this.Index2                             = _index2
    member this.Leg1                               = _leg1
    member this.Leg2                               = _leg2
    member this.Nominal1                           = _nominal1
    member this.Nominal2                           = _nominal2
    member this.PaymentConvention1                 = _paymentConvention1
    member this.PaymentConvention2                 = _paymentConvention2
    member this.Schedule1                          = _schedule1
    member this.Schedule2                          = _schedule2
    member this.Spread1                            = _spread1
    member this.Spread2                            = _spread2
    member this.Type1                              = _type
    member this.EndDiscounts                       j   
                                                   = _endDiscounts j 
    member this.Engine                             = _engine
    member this.IsExpired                          = _isExpired
    member this.Leg                                j   
                                                   = _leg j 
    member this.LegBPS                             j   
                                                   = _legBPS j 
    member this.LegNPV                             j   
                                                   = _legNPV j 
    member this.MaturityDate                       = _maturityDate
    member this.NpvDateDiscount                    = _npvDateDiscount
    member this.Payer                              j   
                                                   = _payer j 
    member this.StartDate                          = _startDate
    member this.StartDiscounts                     j   
                                                   = _startDiscounts j 
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
