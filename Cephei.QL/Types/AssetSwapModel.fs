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
  for mechanics of par asset swap and market asset swap, refer to "Introduction to Asset Swap", Lehman Brothers European Fixed Income Research - January 2000, D. O'Kane  instruments  bondCleanPrice must be the (forward) price at the floatSchedule start date  fair prices are not calculated correctly when using indexed coupons.

  </summary> *)
[<AutoSerializable(true)>]
type AssetSwapModel
    ( parAssetSwap                                 : ICell<bool>
    , bond                                         : ICell<Bond>
    , bondCleanPrice                               : ICell<double>
    , nonParRepayment                              : ICell<double>
    , gearing                                      : ICell<double>
    , iborIndex                                    : ICell<IborIndex>
    , spread                                       : ICell<double>
    , floatingDayCount                             : ICell<DayCounter>
    , dealMaturity                                 : ICell<Date>
    , payBondCoupon                                : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AssetSwap> ()
(*
    Parameters
*)
    let _parAssetSwap                              = parAssetSwap
    let _bond                                      = bond
    let _bondCleanPrice                            = bondCleanPrice
    let _nonParRepayment                           = nonParRepayment
    let _gearing                                   = gearing
    let _iborIndex                                 = iborIndex
    let _spread                                    = spread
    let _floatingDayCount                          = floatingDayCount
    let _dealMaturity                              = dealMaturity
    let _payBondCoupon                             = payBondCoupon
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _AssetSwap                                 = cell (fun () -> withEngine _pricingEngine.Value (new AssetSwap (parAssetSwap.Value, bond.Value, bondCleanPrice.Value, nonParRepayment.Value, gearing.Value, iborIndex.Value, spread.Value, floatingDayCount.Value, dealMaturity.Value, payBondCoupon.Value)))
    let _bond                                      = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).bond())
    let _bondLeg                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).bondLeg())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).cleanPrice())
    let _fairCleanPrice                            = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).fairCleanPrice())
    let _fairNonParRepayment                       = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).fairNonParRepayment())
    let _fairSpread                                = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).fairSpread())
    let _floatingLeg                               = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).floatingLeg())
    let _floatingLegBPS                            = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).floatingLegBPS())
    let _floatingLegNPV                            = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).floatingLegNPV())
    let _nonParRepayment                           = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).nonParRepayment())
    let _parSwap                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).parSwap())
    let _payBondCoupon                             = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).payBondCoupon())
    let _spread                                    = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).spread())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).setPricingEngine(e.Value)
                                                                     _AssetSwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).valuationDate())
    do this.Bind(_AssetSwap)

(* 
    Externally visible/bindable properties
*)
    member this.parAssetSwap                       = _parAssetSwap 
    member this.bond                               = _bond 
    member this.bondCleanPrice                     = _bondCleanPrice 
    member this.nonParRepayment                    = _nonParRepayment 
    member this.gearing                            = _gearing 
    member this.iborIndex                          = _iborIndex 
    member this.spread                             = _spread 
    member this.floatingDayCount                   = _floatingDayCount 
    member this.dealMaturity                       = _dealMaturity 
    member this.payBondCoupon                      = _payBondCoupon 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Bond                               = _bond
    member this.BondLeg                            = _bondLeg
    member this.CleanPrice                         = _cleanPrice
    member this.FairCleanPrice                     = _fairCleanPrice
    member this.FairNonParRepayment                = _fairNonParRepayment
    member this.FairSpread                         = _fairSpread
    member this.FloatingLeg                        = _floatingLeg
    member this.FloatingLegBPS                     = _floatingLegBPS
    member this.FloatingLegNPV                     = _floatingLegNPV
    member this.NonParRepayment                    = _nonParRepayment
    member this.ParSwap                            = _parSwap
    member this.PayBondCoupon                      = _payBondCoupon
    member this.Spread                             = _spread
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
  for mechanics of par asset swap and market asset swap, refer to "Introduction to Asset Swap", Lehman Brothers European Fixed Income Research - January 2000, D. O'Kane  instruments  bondCleanPrice must be the (forward) price at the floatSchedule start date  fair prices are not calculated correctly when using indexed coupons.

  </summary> *)
[<AutoSerializable(true)>]
type AssetSwapModel1
    ( payBondCoupon                                : ICell<bool>
    , bond                                         : ICell<Bond>
    , bondCleanPrice                               : ICell<double>
    , iborIndex                                    : ICell<IborIndex>
    , spread                                       : ICell<double>
    , floatSchedule                                : ICell<Schedule>
    , floatingDayCount                             : ICell<DayCounter>
    , parAssetSwap                                 : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<AssetSwap> ()
(*
    Parameters
*)
    let _payBondCoupon                             = payBondCoupon
    let _bond                                      = bond
    let _bondCleanPrice                            = bondCleanPrice
    let _iborIndex                                 = iborIndex
    let _spread                                    = spread
    let _floatSchedule                             = floatSchedule
    let _floatingDayCount                          = floatingDayCount
    let _parAssetSwap                              = parAssetSwap
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _AssetSwap                                 = cell (fun () -> withEngine _pricingEngine.Value (new AssetSwap (payBondCoupon.Value, bond.Value, bondCleanPrice.Value, iborIndex.Value, spread.Value, floatSchedule.Value, floatingDayCount.Value, parAssetSwap.Value)))
    let _bond                                      = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).bond())
    let _bondLeg                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).bondLeg())
    let _cleanPrice                                = cell (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).cleanPrice())
    let _fairCleanPrice                            = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).fairCleanPrice())
    let _fairNonParRepayment                       = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).fairNonParRepayment())
    let _fairSpread                                = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).fairSpread())
    let _floatingLeg                               = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).floatingLeg())
    let _floatingLegBPS                            = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).floatingLegBPS())
    let _floatingLegNPV                            = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).floatingLegNPV())
    let _nonParRepayment                           = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).nonParRepayment())
    let _parSwap                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).parSwap())
    let _payBondCoupon                             = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).payBondCoupon())
    let _spread                                    = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).spread())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).endDiscounts(j.Value))
    let _engine                                    = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).engine)
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).legNPV(j.Value))
    let _maturityDate                              = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).maturityDate())
    let _npvDateDiscount                           = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).payer(j.Value))
    let _startDate                                 = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).startDate())
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).startDiscounts(j.Value))
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).setPricingEngine(e.Value)
                                                                     _AssetSwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _AssetSwap).valuationDate())
    do this.Bind(_AssetSwap)

(* 
    Externally visible/bindable properties
*)
    member this.payBondCoupon                      = _payBondCoupon 
    member this.bond                               = _bond 
    member this.bondCleanPrice                     = _bondCleanPrice 
    member this.iborIndex                          = _iborIndex 
    member this.spread                             = _spread 
    member this.floatSchedule                      = _floatSchedule 
    member this.floatingDayCount                   = _floatingDayCount 
    member this.parAssetSwap                       = _parAssetSwap 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Bond                               = _bond
    member this.BondLeg                            = _bondLeg
    member this.CleanPrice                         = _cleanPrice
    member this.FairCleanPrice                     = _fairCleanPrice
    member this.FairNonParRepayment                = _fairNonParRepayment
    member this.FairSpread                         = _fairSpread
    member this.FloatingLeg                        = _floatingLeg
    member this.FloatingLegBPS                     = _floatingLegBPS
    member this.FloatingLegNPV                     = _floatingLegNPV
    member this.NonParRepayment                    = _nonParRepayment
    member this.ParSwap                            = _parSwap
    member this.PayBondCoupon                      = _payBondCoupon
    member this.Spread                             = _spread
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
