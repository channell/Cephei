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
  Basis swap. Simple Libor swap vs Libor swap
constructor
  </summary> *)
[<AutoSerializable(true)>]
type BasisSwapModel
    ( Type                                         : ICell<BasisSwap.Type>
    , nominal                                      : ICell<double>
    , float1Schedule                               : ICell<Schedule>
    , iborIndex1                                   : ICell<IborIndex>
    , spread1                                      : ICell<double>
    , float1DayCount                               : ICell<DayCounter>
    , float2Schedule                               : ICell<Schedule>
    , iborIndex2                                   : ICell<IborIndex>
    , spread2                                      : ICell<double>
    , float2DayCount                               : ICell<DayCounter>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BasisSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _float1Schedule                            = float1Schedule
    let _iborIndex1                                = iborIndex1
    let _spread1                                   = spread1
    let _float1DayCount                            = float1DayCount
    let _float2Schedule                            = float2Schedule
    let _iborIndex2                                = iborIndex2
    let _spread2                                   = spread2
    let _float2DayCount                            = float2DayCount
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _BasisSwap                                 = cell (fun () -> withEngine _pricingEngine.Value (new BasisSwap (Type.Value, nominal.Value, float1Schedule.Value, iborIndex1.Value, spread1.Value, float1DayCount.Value, float2Schedule.Value, iborIndex2.Value, spread2.Value, float2DayCount.Value)))
    let _fairLongSpread                            = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).fairLongSpread())
    let _fairShortSpread                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).fairShortSpread())
    let _floating1Leg                              = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1Leg())
    let _floating1LegBPS                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1LegBPS())
    let _floating1LegNPV                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1LegNPV())
    let _floating1Schedule                         = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1Schedule())
    let _floating2Leg                              = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2Leg())
    let _floating2LegBPS                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2LegBPS())
    let _floating2LegNPV                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2LegNPV())
    let _floating2Schedule                         = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2Schedule())
    let _iborIndex1                                = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).iborIndex1())
    let _iborIndex2                                = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).iborIndex2())
    let _nominal                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).nominal)
    let _spread1                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).spread1)
    let _spread2                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).spread2)
    let _swapType                                  = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).swapType)
    let _endDiscounts                              (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).endDiscounts(j.Value))
    let _engine                                    = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).engine)
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).legNPV(j.Value))
    let _maturityDate                              = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).maturityDate())
    let _npvDateDiscount                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).payer(j.Value))
    let _startDate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).setPricingEngine(e.Value)
                                                                     _BasisSwap.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).valuationDate())
    do this.Bind(_BasisSwap)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.float1Schedule                     = _float1Schedule 
    member this.iborIndex1                         = _iborIndex1 
    member this.spread1                            = _spread1 
    member this.float1DayCount                     = _float1DayCount 
    member this.float2Schedule                     = _float2Schedule 
    member this.iborIndex2                         = _iborIndex2 
    member this.spread2                            = _spread2 
    member this.float2DayCount                     = _float2DayCount 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FairLongSpread                     = _fairLongSpread
    member this.FairShortSpread                    = _fairShortSpread
    member this.Floating1Leg                       = _floating1Leg
    member this.Floating1LegBPS                    = _floating1LegBPS
    member this.Floating1LegNPV                    = _floating1LegNPV
    member this.Floating1Schedule                  = _floating1Schedule
    member this.Floating2Leg                       = _floating2Leg
    member this.Floating2LegBPS                    = _floating2LegBPS
    member this.Floating2LegNPV                    = _floating2LegNPV
    member this.Floating2Schedule                  = _floating2Schedule
    member this.IborIndex1                         = _iborIndex1
    member this.IborIndex2                         = _iborIndex2
    member this.Nominal                            = _nominal
    member this.Spread1                            = _spread1
    member this.Spread2                            = _spread2
    member this.SwapType                           = _swapType
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
  Basis swap. Simple Libor swap vs Libor swap

  </summary> *)
[<AutoSerializable(true)>]
type BasisSwapModel1
    ( Type                                         : ICell<BasisSwap.Type>
    , nominal                                      : ICell<double>
    , float1Schedule                               : ICell<Schedule>
    , iborIndex1                                   : ICell<IborIndex>
    , spread1                                      : ICell<double>
    , float1DayCount                               : ICell<DayCounter>
    , float2Schedule                               : ICell<Schedule>
    , iborIndex2                                   : ICell<IborIndex>
    , spread2                                      : ICell<double>
    , float2DayCount                               : ICell<DayCounter>
    , paymentConvention                            : ICell<Nullable<BusinessDayConvention>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BasisSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _float1Schedule                            = float1Schedule
    let _iborIndex1                                = iborIndex1
    let _spread1                                   = spread1
    let _float1DayCount                            = float1DayCount
    let _float2Schedule                            = float2Schedule
    let _iborIndex2                                = iborIndex2
    let _spread2                                   = spread2
    let _float2DayCount                            = float2DayCount
    let _paymentConvention                         = paymentConvention
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _BasisSwap                                 = cell (fun () -> withEngine _pricingEngine.Value (new BasisSwap (Type.Value, nominal.Value, float1Schedule.Value, iborIndex1.Value, spread1.Value, float1DayCount.Value, float2Schedule.Value, iborIndex2.Value, spread2.Value, float2DayCount.Value, paymentConvention.Value)))
    let _fairLongSpread                            = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).fairLongSpread())
    let _fairShortSpread                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).fairShortSpread())
    let _floating1Leg                              = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1Leg())
    let _floating1LegBPS                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1LegBPS())
    let _floating1LegNPV                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1LegNPV())
    let _floating1Schedule                         = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating1Schedule())
    let _floating2Leg                              = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2Leg())
    let _floating2LegBPS                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2LegBPS())
    let _floating2LegNPV                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2LegNPV())
    let _floating2Schedule                         = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).floating2Schedule())
    let _iborIndex1                                = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).iborIndex1())
    let _iborIndex2                                = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).iborIndex2())
    let _nominal                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).nominal)
    let _spread1                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).spread1)
    let _spread2                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).spread2)
    let _swapType                                  = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).swapType)
    let _endDiscounts                              (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).endDiscounts(j.Value))
    let _engine                                    = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).engine)
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).legNPV(j.Value))
    let _maturityDate                              = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).maturityDate())
    let _npvDateDiscount                           = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).payer(j.Value))
    let _startDate                                 = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).setPricingEngine(e.Value)
                                                                     _BasisSwap.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _BasisSwap).valuationDate())
    do this.Bind(_BasisSwap)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.float1Schedule                     = _float1Schedule 
    member this.iborIndex1                         = _iborIndex1 
    member this.spread1                            = _spread1 
    member this.float1DayCount                     = _float1DayCount 
    member this.float2Schedule                     = _float2Schedule 
    member this.iborIndex2                         = _iborIndex2 
    member this.spread2                            = _spread2 
    member this.float2DayCount                     = _float2DayCount 
    member this.paymentConvention                  = _paymentConvention 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.FairLongSpread                     = _fairLongSpread
    member this.FairShortSpread                    = _fairShortSpread
    member this.Floating1Leg                       = _floating1Leg
    member this.Floating1LegBPS                    = _floating1LegBPS
    member this.Floating1LegNPV                    = _floating1LegNPV
    member this.Floating1Schedule                  = _floating1Schedule
    member this.Floating2Leg                       = _floating2Leg
    member this.Floating2LegBPS                    = _floating2LegBPS
    member this.Floating2LegNPV                    = _floating2LegNPV
    member this.Floating2Schedule                  = _floating2Schedule
    member this.IborIndex1                         = _iborIndex1
    member this.IborIndex2                         = _iborIndex2
    member this.Nominal                            = _nominal
    member this.Spread1                            = _spread1
    member this.Spread2                            = _spread2
    member this.SwapType                           = _swapType
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
