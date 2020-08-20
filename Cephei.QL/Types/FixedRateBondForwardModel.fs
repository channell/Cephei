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
  1. valueDate refers to the settlement date of the bond forward contract.  maturityDate is the delivery (or repurchase) date for the underlying bond (not the bond's maturity date).  2. Relevant formulas used in the calculations  refers to a price):  a. P_{CleanFwd}(t) = P_{DirtyFwd}(t) - AI(t=deliveryDate) where AI refers to the accrued interest on the underlying bond.  b. P_{DirtyFwd}(t) = - SpotIncome(t)} {discountCurve->discount(t=deliveryDate)}  c. SpotIncome(t) = CF_i incomeDiscountCurve->discount(t_i) where CF_i represents the ith bond cash flow (coupon payment) associated with the underlying bond falling between the settlementDate and the deliveryDate. (Note the two different discount curves used in b. and c.) 
<b>Example: </b> Repo.cpp valuation of a repo on a fixed-rate bond  Add preconditions and tests  Create switch- if coupon goes to seller is toggled on, don't consider income in the P_{DirtyFwd}(t) calculation.  Verify this works when the underlying is paper (in which case ignore all AI.)  This class still needs to be rigorously tested  instruments
! If strike is given in the constructor, can calculate the NPV of the contract via NPV().  If strike/forward price is desired, it can be obtained via forwardPrice(). In this case, the strike variable in the constructor is irrelevant and will be ignored.
  </summary> *)
[<AutoSerializable(true)>]
type FixedRateBondForwardModel
    ( valueDate                                    : ICell<Date>
    , maturityDate                                 : ICell<Date>
    , Type                                         : ICell<Position.Type>
    , strike                                       : ICell<double>
    , settlementDays                               : ICell<int>
    , dayCounter                                   : ICell<DayCounter>
    , calendar                                     : ICell<Calendar>
    , businessDayConvention                        : ICell<BusinessDayConvention>
    , fixedCouponBond                              : ICell<FixedRateBond>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , incomeDiscountCurve                          : ICell<Handle<YieldTermStructure>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<FixedRateBondForward> ()
(*
    Parameters
*)
    let _valueDate                                 = valueDate
    let _maturityDate                              = maturityDate
    let _Type                                      = Type
    let _strike                                    = strike
    let _settlementDays                            = settlementDays
    let _dayCounter                                = dayCounter
    let _calendar                                  = calendar
    let _businessDayConvention                     = businessDayConvention
    let _fixedCouponBond                           = fixedCouponBond
    let _discountCurve                             = discountCurve
    let _incomeDiscountCurve                       = incomeDiscountCurve
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _FixedRateBondForward                      = cell (fun () -> withEngine _pricingEngine.Value (new FixedRateBondForward (valueDate.Value, maturityDate.Value, Type.Value, strike.Value, settlementDays.Value, dayCounter.Value, calendar.Value, businessDayConvention.Value, fixedCouponBond.Value, discountCurve.Value, incomeDiscountCurve.Value)))
    let _cleanForwardPrice                         = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).cleanForwardPrice())
    let _forwardPrice                              = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).forwardPrice())
    let _spotIncome                                (incomeDiscountCurve : ICell<Handle<YieldTermStructure>>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).spotIncome(incomeDiscountCurve.Value))
    let _spotValue                                 = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).spotValue())
    let _forwardValue                              = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).forwardValue())
    let _impliedYield                              (underlyingSpotValue : ICell<double>) (forwardValue : ICell<double>) (settlementDate : ICell<Date>) (compoundingConvention : ICell<Compounding>) (dayCounter : ICell<DayCounter>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).impliedYield(underlyingSpotValue.Value, forwardValue.Value, settlementDate.Value, compoundingConvention.Value, dayCounter.Value))
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).isExpired())
    let _settlementDate                            = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).settlementDate())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).setPricingEngine(e.Value)
                                                                     _FixedRateBondForward.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _FixedRateBondForward).valuationDate())
    do this.Bind(_FixedRateBondForward)

(* 
    Externally visible/bindable properties
*)
    member this.valueDate                          = _valueDate 
    member this.maturityDate                       = _maturityDate 
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.settlementDays                     = _settlementDays 
    member this.dayCounter                         = _dayCounter 
    member this.calendar                           = _calendar 
    member this.businessDayConvention              = _businessDayConvention 
    member this.fixedCouponBond                    = _fixedCouponBond 
    member this.discountCurve                      = _discountCurve 
    member this.incomeDiscountCurve                = _incomeDiscountCurve 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.CleanForwardPrice                  = _cleanForwardPrice
    member this.ForwardPrice                       = _forwardPrice
    member this.SpotIncome                         incomeDiscountCurve   
                                                   = _spotIncome incomeDiscountCurve 
    member this.SpotValue                          = _spotValue
    member this.ForwardValue                       = _forwardValue
    member this.ImpliedYield                       underlyingSpotValue forwardValue settlementDate compoundingConvention dayCounter   
                                                   = _impliedYield underlyingSpotValue forwardValue settlementDate compoundingConvention dayCounter 
    member this.IsExpired                          = _isExpired
    member this.SettlementDate                     = _settlementDate
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate
