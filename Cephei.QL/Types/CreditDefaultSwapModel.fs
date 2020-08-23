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
type CreditDefaultSwapModel
    ( side                                         : ICell<Protection.Side>
    , notional                                     : ICell<double>
    , spread                                       : ICell<double>
    , schedule                                     : ICell<Schedule>
    , convention                                   : ICell<BusinessDayConvention>
    , dayCounter                                   : ICell<DayCounter>
    , settlesAccrual                               : ICell<bool>
    , paysAtDefaultTime                            : ICell<bool>
    , protectionStart                              : ICell<Date>
    , claim                                        : ICell<Claim>
    , lastPeriodDayCounter                         : ICell<DayCounter>
    , rebatesAccrual                               : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CreditDefaultSwap> ()
(*
    Parameters
*)
    let _side                                      = side
    let _notional                                  = notional
    let _spread                                    = spread
    let _schedule                                  = schedule
    let _convention                                = convention
    let _dayCounter                                = dayCounter
    let _settlesAccrual                            = settlesAccrual
    let _paysAtDefaultTime                         = paysAtDefaultTime
    let _protectionStart                           = protectionStart
    let _claim                                     = claim
    let _lastPeriodDayCounter                      = lastPeriodDayCounter
    let _rebatesAccrual                            = rebatesAccrual
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CreditDefaultSwap                         = triv (fun () -> withEngine _pricingEngine.Value (new CreditDefaultSwap (side.Value, notional.Value, spread.Value, schedule.Value, convention.Value, dayCounter.Value, settlesAccrual.Value, paysAtDefaultTime.Value, protectionStart.Value, claim.Value, lastPeriodDayCounter.Value, rebatesAccrual.Value)))
    let _accrualRebateNPV                          = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).accrualRebateNPV())
    let _conventionalSpread                        (conventionalRecovery : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (model : ICell<PricingModel>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).conventionalSpread(conventionalRecovery.Value, discountCurve.Value, dayCounter.Value, model.Value))
    let _couponLegBPS                              = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).couponLegBPS())
    let _couponLegNPV                              = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).couponLegNPV())
    let _coupons                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).coupons())
    let _defaultLegNPV                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).defaultLegNPV())
    let _fairSpread                                = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).fairSpread())
    let _fairUpfront                               = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).fairUpfront())
    let _impliedHazardRate                         (targetNPV : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (recoveryRate : ICell<double>) (accuracy : ICell<double>) (model : ICell<PricingModel>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).impliedHazardRate(targetNPV.Value, discountCurve.Value, dayCounter.Value, recoveryRate.Value, accuracy.Value, model.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).isExpired())
    let _notional                                  = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).notional())
    let _paysAtDefaultTime                         = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).paysAtDefaultTime())
    let _protectionEndDate                         = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).protectionEndDate())
    let _protectionStartDate                       = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).protectionStartDate())
    let _rebatesAccrual                            = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).rebatesAccrual())
    let _runningSpread                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).runningSpread())
    let _settlesAccrual                            = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).settlesAccrual())
    let _side                                      = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).side())
    let _upfront                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).upfront())
    let _upfrontBPS                                = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).upfrontBPS())
    let _upfrontNPV                                = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).upfrontNPV())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).setPricingEngine(e.Value)
                                                                     _CreditDefaultSwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).valuationDate())
    do this.Bind(_CreditDefaultSwap)

(* 
    Externally visible/bindable properties
*)
    member this.side                               = _side 
    member this.notional                           = _notional 
    member this.spread                             = _spread 
    member this.schedule                           = _schedule 
    member this.convention                         = _convention 
    member this.dayCounter                         = _dayCounter 
    member this.settlesAccrual                     = _settlesAccrual 
    member this.paysAtDefaultTime                  = _paysAtDefaultTime 
    member this.protectionStart                    = _protectionStart 
    member this.claim                              = _claim 
    member this.lastPeriodDayCounter               = _lastPeriodDayCounter 
    member this.rebatesAccrual                     = _rebatesAccrual 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AccrualRebateNPV                   = _accrualRebateNPV
    member this.ConventionalSpread                 conventionalRecovery discountCurve dayCounter model   
                                                   = _conventionalSpread conventionalRecovery discountCurve dayCounter model 
    member this.CouponLegBPS                       = _couponLegBPS
    member this.CouponLegNPV                       = _couponLegNPV
    member this.Coupons                            = _coupons
    member this.DefaultLegNPV                      = _defaultLegNPV
    member this.FairSpread                         = _fairSpread
    member this.FairUpfront                        = _fairUpfront
    member this.ImpliedHazardRate                  targetNPV discountCurve dayCounter recoveryRate accuracy model   
                                                   = _impliedHazardRate targetNPV discountCurve dayCounter recoveryRate accuracy model 
    member this.IsExpired                          = _isExpired
    member this.Notional                           = _notional
    member this.PaysAtDefaultTime                  = _paysAtDefaultTime
    member this.ProtectionEndDate                  = _protectionEndDate
    member this.ProtectionStartDate                = _protectionStartDate
    member this.RebatesAccrual                     = _rebatesAccrual
    member this.RunningSpread                      = _runningSpread
    member this.SettlesAccrual                     = _settlesAccrual
    member this.Side                               = _side
    member this.Upfront                            = _upfront
    member this.UpfrontBPS                         = _upfrontBPS
    member this.UpfrontNPV                         = _upfrontNPV
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
type CreditDefaultSwapModel1
    ( side                                         : ICell<Protection.Side>
    , notional                                     : ICell<double>
    , upfront                                      : ICell<double>
    , runningSpread                                : ICell<double>
    , schedule                                     : ICell<Schedule>
    , convention                                   : ICell<BusinessDayConvention>
    , dayCounter                                   : ICell<DayCounter>
    , settlesAccrual                               : ICell<bool>
    , paysAtDefaultTime                            : ICell<bool>
    , protectionStart                              : ICell<Date>
    , upfrontDate                                  : ICell<Date>
    , claim                                        : ICell<Claim>
    , lastPeriodDayCounter                         : ICell<DayCounter>
    , rebatesAccrual                               : ICell<bool>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<CreditDefaultSwap> ()
(*
    Parameters
*)
    let _side                                      = side
    let _notional                                  = notional
    let _upfront                                   = upfront
    let _runningSpread                             = runningSpread
    let _schedule                                  = schedule
    let _convention                                = convention
    let _dayCounter                                = dayCounter
    let _settlesAccrual                            = settlesAccrual
    let _paysAtDefaultTime                         = paysAtDefaultTime
    let _protectionStart                           = protectionStart
    let _upfrontDate                               = upfrontDate
    let _claim                                     = claim
    let _lastPeriodDayCounter                      = lastPeriodDayCounter
    let _rebatesAccrual                            = rebatesAccrual
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _CreditDefaultSwap                         = triv (fun () -> withEngine _pricingEngine.Value (new CreditDefaultSwap (side.Value, notional.Value, upfront.Value, runningSpread.Value, schedule.Value, convention.Value, dayCounter.Value, settlesAccrual.Value, paysAtDefaultTime.Value, protectionStart.Value, upfrontDate.Value, claim.Value, lastPeriodDayCounter.Value, rebatesAccrual.Value)))
    let _accrualRebateNPV                          = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).accrualRebateNPV())
    let _conventionalSpread                        (conventionalRecovery : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (model : ICell<PricingModel>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).conventionalSpread(conventionalRecovery.Value, discountCurve.Value, dayCounter.Value, model.Value))
    let _couponLegBPS                              = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).couponLegBPS())
    let _couponLegNPV                              = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).couponLegNPV())
    let _coupons                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).coupons())
    let _defaultLegNPV                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).defaultLegNPV())
    let _fairSpread                                = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).fairSpread())
    let _fairUpfront                               = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).fairUpfront())
    let _impliedHazardRate                         (targetNPV : ICell<double>) (discountCurve : ICell<Handle<YieldTermStructure>>) (dayCounter : ICell<DayCounter>) (recoveryRate : ICell<double>) (accuracy : ICell<double>) (model : ICell<PricingModel>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).impliedHazardRate(targetNPV.Value, discountCurve.Value, dayCounter.Value, recoveryRate.Value, accuracy.Value, model.Value))
    let _isExpired                                 = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).isExpired())
    let _notional                                  = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).notional())
    let _paysAtDefaultTime                         = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).paysAtDefaultTime())
    let _protectionEndDate                         = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).protectionEndDate())
    let _protectionStartDate                       = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).protectionStartDate())
    let _rebatesAccrual                            = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).rebatesAccrual())
    let _runningSpread                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).runningSpread())
    let _settlesAccrual                            = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).settlesAccrual())
    let _side                                      = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).side())
    let _upfront                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).upfront())
    let _upfrontBPS                                = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).upfrontBPS())
    let _upfrontNPV                                = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).upfrontNPV())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).CASH())
    let _errorEstimate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).setPricingEngine(e.Value)
                                                                     _CreditDefaultSwap.Value)
    let _valuationDate                             = triv (fun () -> (withEvaluationDate _evaluationDate _CreditDefaultSwap).valuationDate())
    do this.Bind(_CreditDefaultSwap)

(* 
    Externally visible/bindable properties
*)
    member this.side                               = _side 
    member this.notional                           = _notional 
    member this.upfront                            = _upfront 
    member this.runningSpread                      = _runningSpread 
    member this.schedule                           = _schedule 
    member this.convention                         = _convention 
    member this.dayCounter                         = _dayCounter 
    member this.settlesAccrual                     = _settlesAccrual 
    member this.paysAtDefaultTime                  = _paysAtDefaultTime 
    member this.protectionStart                    = _protectionStart 
    member this.upfrontDate                        = _upfrontDate 
    member this.claim                              = _claim 
    member this.lastPeriodDayCounter               = _lastPeriodDayCounter 
    member this.rebatesAccrual                     = _rebatesAccrual 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AccrualRebateNPV                   = _accrualRebateNPV
    member this.ConventionalSpread                 conventionalRecovery discountCurve dayCounter model   
                                                   = _conventionalSpread conventionalRecovery discountCurve dayCounter model 
    member this.CouponLegBPS                       = _couponLegBPS
    member this.CouponLegNPV                       = _couponLegNPV
    member this.Coupons                            = _coupons
    member this.DefaultLegNPV                      = _defaultLegNPV
    member this.FairSpread                         = _fairSpread
    member this.FairUpfront                        = _fairUpfront
    member this.ImpliedHazardRate                  targetNPV discountCurve dayCounter recoveryRate accuracy model   
                                                   = _impliedHazardRate targetNPV discountCurve dayCounter recoveryRate accuracy model 
    member this.IsExpired                          = _isExpired
    member this.Notional                           = _notional
    member this.PaysAtDefaultTime                  = _paysAtDefaultTime
    member this.ProtectionEndDate                  = _protectionEndDate
    member this.ProtectionStartDate                = _protectionStartDate
    member this.RebatesAccrual                     = _rebatesAccrual
    member this.RunningSpread                      = _runningSpread
    member this.SettlesAccrual                     = _settlesAccrual
    member this.Side                               = _side
    member this.Upfront                            = _upfront
    member this.UpfrontBPS                         = _upfrontBPS
    member this.UpfrontNPV                         = _upfrontNPV
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
