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
  Quoted as a fixed rate K  At start: P_n(0,T) N [(1+K)^{T}-1] = P_n(0,T) N -1 where T is the maturity time, P_n(0,t) is the nominal discount factor at time t N is the notional, and I(t) is the inflation index value at time t  This inherits from swap and has two very simple legs: a fixed leg, from the quote (K); and an indexed leg.  At maturity the two single cashflows are swapped.  These are the notional versus the inflation-indexed notional Because the coupons are zero there are no accruals (and no coupons).  Inflation is generally available on every day, including holidays and weekends.  Hence there is a variable to state whether the observe/fix dates for inflation are adjusted or not.  The default is not to adjust.  A zero inflation swap is a simple enough instrument that the standard discounting pricing engine that works for a vanilla swap also works.  we do not need Schedules on the legs because they use one or two dates only per leg.
Generally inflation indices are available with a lag of 1month and then observed with a lag of 2-3 months depending whether they use an interpolated fixing or not.  Here, we make the swap use the interpolation of the index to avoid incompatibilities.
  </summary> *)
[<AutoSerializable(true)>]
type ZeroCouponInflationSwapModel
    ( Type                                         : ICell<ZeroCouponInflationSwap.Type>
    , nominal                                      : ICell<double>
    , startDate                                    : ICell<Date>
    , maturity                                     : ICell<Date>
    , fixCalendar                                  : ICell<Calendar>
    , fixConvention                                : ICell<BusinessDayConvention>
    , dayCounter                                   : ICell<DayCounter>
    , fixedRate                                    : ICell<double>
    , infIndex                                     : ICell<ZeroInflationIndex>
    , observationLag                               : ICell<Period>
    , adjustInfObsDates                            : ICell<bool>
    , infCalendar                                  : ICell<Calendar>
    , infConvention                                : ICell<Nullable<BusinessDayConvention>>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ZeroCouponInflationSwap> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _nominal                                   = nominal
    let _startDate                                 = startDate
    let _maturity                                  = maturity
    let _fixCalendar                               = fixCalendar
    let _fixConvention                             = fixConvention
    let _dayCounter                                = dayCounter
    let _fixedRate                                 = fixedRate
    let _infIndex                                  = infIndex
    let _observationLag                            = observationLag
    let _adjustInfObsDates                         = adjustInfObsDates
    let _infCalendar                               = infCalendar
    let _infConvention                             = infConvention
    let mutable
        _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let mutable
        _ZeroCouponInflationSwap                   = make (fun () -> withEngine pricingEngine evaluationDate (new ZeroCouponInflationSwap (Type.Value, nominal.Value, startDate.Value, maturity.Value, fixCalendar.Value, fixConvention.Value, dayCounter.Value, fixedRate.Value, infIndex.Value, observationLag.Value, adjustInfObsDates.Value, infCalendar.Value, infConvention.Value)))
    let _adjustObservationDates                    = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).adjustObservationDates())
    let _dayCounter                                = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).dayCounter())
    let _fairRate                                  = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).fairRate())
    let _fixedCalendar                             = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).fixedCalendar())
    let _fixedConvention                           = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).fixedConvention())
    let _fixedLeg                                  = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).fixedLeg())
    let _fixedLegNPV                               = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).fixedLegNPV())
    let _fixedRate                                 = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).fixedRate())
    let _inflationCalendar                         = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).inflationCalendar())
    let _inflationConvention                       = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).inflationConvention())
    let _inflationIndex                            = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).inflationIndex())
    let _inflationLeg                              = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).inflationLeg())
    let _inflationLegNPV                           = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).inflationLegNPV())
    let _maturityDate                              = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).maturityDate())
    let _nominal                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).nominal())
    let _observationLag                            = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).observationLag())
    let _startDate                                 = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).startDate())
    let _type                                      = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).TYPE())
    let _endDiscounts                              (j : ICell<int>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).endDiscounts(j.Value))
    let _engine                                    = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).engine)
    let _isExpired                                 = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).isExpired())
    let _leg                                       (j : ICell<int>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).leg(j.Value))
    let _legBPS                                    (j : ICell<int>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).legBPS(j.Value))
    let _legNPV                                    (j : ICell<int>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).legNPV(j.Value))
    let _npvDateDiscount                           = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).npvDateDiscount())
    let _payer                                     (j : ICell<int>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).payer(j.Value))
    let _startDiscounts                            (j : ICell<int>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).startDiscounts(j.Value))
    let _CASH                                      = cell _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).CASH())
    let _errorEstimate                             = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).errorEstimate())
    let _NPV                                       = cell _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).setPricingEngine(e.Value)
                                                                                              _ZeroCouponInflationSwap.Value)
    let _valuationDate                             = triv _ZeroCouponInflationSwap (fun () -> (withEvaluationDate _evaluationDate _ZeroCouponInflationSwap).valuationDate())
    do this.Bind(_ZeroCouponInflationSwap)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new ZeroCouponInflationSwapModel(null,null,null,null,null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _ZeroCouponInflationSwap <- v
    static member Cast (p : ICell<ZeroCouponInflationSwap>) = 
        if p :? ZeroCouponInflationSwapModel then 
            p :?> ZeroCouponInflationSwapModel
        else
            let o = new ZeroCouponInflationSwapModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.nominal                            = _nominal 
    member this.startDate                          = _startDate 
    member this.maturity                           = _maturity 
    member this.fixCalendar                        = _fixCalendar 
    member this.fixConvention                      = _fixConvention 
    member this.dayCounter                         = _dayCounter 
    member this.fixedRate                          = _fixedRate 
    member this.infIndex                           = _infIndex 
    member this.observationLag                     = _observationLag 
    member this.adjustInfObsDates                  = _adjustInfObsDates 
    member this.infCalendar                        = _infCalendar 
    member this.infConvention                      = _infConvention 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.AdjustObservationDates             = _adjustObservationDates
    member this.DayCounter                         = _dayCounter
    member this.FairRate                           = _fairRate
    member this.FixedCalendar                      = _fixedCalendar
    member this.FixedConvention                    = _fixedConvention
    member this.FixedLeg                           = _fixedLeg
    member this.FixedLegNPV                        = _fixedLegNPV
    member this.FixedRate                          = _fixedRate
    member this.InflationCalendar                  = _inflationCalendar
    member this.InflationConvention                = _inflationConvention
    member this.InflationIndex                     = _inflationIndex
    member this.InflationLeg                       = _inflationLeg
    member this.InflationLegNPV                    = _inflationLegNPV
    member this.MaturityDate                       = _maturityDate
    member this.Nominal                            = _nominal
    member this.ObservationLag                     = _observationLag
    member this.StartDate                          = _startDate
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
    member this.NpvDateDiscount                    = _npvDateDiscount
    member this.Payer                              j   
                                                   = _payer j 
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
