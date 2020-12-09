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
  Ibor rate coupon with digital digital call/put option
need by CashFlowVectors
  </summary> *)
[<AutoSerializable(true)>]
type DigitalIborCouponModel
    ( evaluationDate                               : ICell<Date>
    ) as this =
    inherit Model<DigitalIborCoupon> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
(*
    Functions
*)
    let mutable
        _DigitalIborCoupon                         = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new DigitalIborCoupon ())))
    let _factory                                   (underlying : ICell<IborCoupon>) (callStrike : ICell<Nullable<double>>) (callPosition : ICell<Position.Type>) (isCallATMIncluded : ICell<bool>) (callDigitalPayoff : ICell<Nullable<double>>) (putStrike : ICell<Nullable<double>>) (putPosition : ICell<Position.Type>) (isPutATMIncluded : ICell<bool>) (putDigitalPayoff : ICell<Nullable<double>>) (replication : ICell<DigitalReplication>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.factory(underlying.Value, callStrike.Value, callPosition.Value, isCallATMIncluded.Value, callDigitalPayoff.Value, putStrike.Value, putPosition.Value, isPutATMIncluded.Value, putDigitalPayoff.Value, replication.Value))
    let _callDigitalPayoff                         = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.callDigitalPayoff())
    let _callOptionRate                            = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.callOptionRate())
    let _callStrike                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.callStrike())
    let _convexityAdjustment                       = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.convexityAdjustment())
    let _hasCall                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasCall())
    let _hasCollar                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasCollar())
    let _hasPut                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasPut())
    let _isLongCall                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.isLongCall())
    let _isLongPut                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.isLongPut())
    let _putDigitalPayoff                          = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.putDigitalPayoff())
    let _putOptionRate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.putOptionRate())
    let _putStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.putStrike())
    let _rate                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.setPricer(pricer.Value)
                                                                     _DigitalIborCoupon.Value)
    let _underlying                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.underlying())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.adjustedFixing)
    let _amount                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.amount())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.dayCounter())
    let _fixingDate                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.fixingDate())
    let _fixingDays                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.fixingDays)
    let _gearing                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.gearing())
    let _index                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.index())
    let _indexFixing                               = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.indexFixing())
    let _isInArrears                               = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.pricer())
    let _spread                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.spread())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.update()
                                                                     _DigitalIborCoupon.Value)
    let _accrualDays                               = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.date())
    let _exCouponDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.exCouponDate())
    let _nominal                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accept(v.Value)
                                                                     _DigitalIborCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.registerWith(handler.Value)
                                                                     _DigitalIborCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.unregisterWith(handler.Value)
                                                                     _DigitalIborCoupon.Value)
    do this.Bind(_DigitalIborCoupon)
(* 
    casting 
*)
    
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DigitalIborCouponModel(null)
    member internal this.Inject v = _DigitalIborCoupon <- v
    static member Cast (p : ICell<DigitalIborCoupon>) = 
        if p :? DigitalIborCouponModel then 
            p :?> DigitalIborCouponModel
        else
            let o = new DigitalIborCouponModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Factory                            underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication   
                                                   = _factory underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication 
    member this.CallDigitalPayoff                  = _callDigitalPayoff
    member this.CallOptionRate                     = _callOptionRate
    member this.CallStrike                         = _callStrike
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.HasCall                            = _hasCall
    member this.HasCollar                          = _hasCollar
    member this.HasPut                             = _hasPut
    member this.IsLongCall                         = _isLongCall
    member this.IsLongPut                          = _isLongPut
    member this.PutDigitalPayoff                   = _putDigitalPayoff
    member this.PutOptionRate                      = _putOptionRate
    member this.PutStrike                          = _putStrike
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.Underlying                         = _underlying
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Spread                             = _spread
    member this.Update                             = _update
    member this.AccrualDays                        = _accrualDays
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualPeriod                      = _accrualPeriod
    member this.AccrualStartDate                   = _accrualStartDate
    member this.AccruedDays                        d   
                                                   = _accruedDays d 
    member this.AccruedPeriod                      d   
                                                   = _accruedPeriod d 
    member this.Date                               = _date
    member this.ExCouponDate                       = _exCouponDate
    member this.Nominal                            = _nominal
    member this.ReferencePeriodEnd                 = _referencePeriodEnd
    member this.ReferencePeriodStart               = _referencePeriodStart
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  Ibor rate coupon with digital digital call/put option

  </summary> *)
[<AutoSerializable(true)>]
type DigitalIborCouponModel1
    ( underlying                                   : ICell<IborCoupon>
    , callStrike                                   : ICell<Nullable<double>>
    , callPosition                                 : ICell<Position.Type>
    , isCallATMIncluded                            : ICell<bool>
    , callDigitalPayoff                            : ICell<Nullable<double>>
    , putStrike                                    : ICell<Nullable<double>>
    , putPosition                                  : ICell<Position.Type>
    , isPutATMIncluded                             : ICell<bool>
    , putDigitalPayoff                             : ICell<Nullable<double>>
    , replication                                  : ICell<DigitalReplication>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<DigitalIborCoupon> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _underlying                                = underlying
    let _callStrike                                = callStrike
    let _callPosition                              = callPosition
    let _isCallATMIncluded                         = isCallATMIncluded
    let _callDigitalPayoff                         = callDigitalPayoff
    let _putStrike                                 = putStrike
    let _putPosition                               = putPosition
    let _isPutATMIncluded                          = isPutATMIncluded
    let _putDigitalPayoff                          = putDigitalPayoff
    let _replication                               = replication
(*
    Functions
*)
    let mutable
        _DigitalIborCoupon                         = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new DigitalIborCoupon (underlying.Value, callStrike.Value, callPosition.Value, isCallATMIncluded.Value, callDigitalPayoff.Value, putStrike.Value, putPosition.Value, isPutATMIncluded.Value, putDigitalPayoff.Value, replication.Value))))
    let _factory                                   (underlying : ICell<IborCoupon>) (callStrike : ICell<Nullable<double>>) (callPosition : ICell<Position.Type>) (isCallATMIncluded : ICell<bool>) (callDigitalPayoff : ICell<Nullable<double>>) (putStrike : ICell<Nullable<double>>) (putPosition : ICell<Position.Type>) (isPutATMIncluded : ICell<bool>) (putDigitalPayoff : ICell<Nullable<double>>) (replication : ICell<DigitalReplication>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.factory(underlying.Value, callStrike.Value, callPosition.Value, isCallATMIncluded.Value, callDigitalPayoff.Value, putStrike.Value, putPosition.Value, isPutATMIncluded.Value, putDigitalPayoff.Value, replication.Value))
    let _callDigitalPayoff                         = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.callDigitalPayoff())
    let _callOptionRate                            = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.callOptionRate())
    let _callStrike                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.callStrike())
    let _convexityAdjustment                       = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.convexityAdjustment())
    let _hasCall                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasCall())
    let _hasCollar                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasCollar())
    let _hasPut                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasPut())
    let _isLongCall                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.isLongCall())
    let _isLongPut                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.isLongPut())
    let _putDigitalPayoff                          = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.putDigitalPayoff())
    let _putOptionRate                             = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.putOptionRate())
    let _putStrike                                 = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.putStrike())
    let _rate                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.rate())
    let _setPricer                                 (pricer : ICell<FloatingRateCouponPricer>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.setPricer(pricer.Value)
                                                                     _DigitalIborCoupon.Value)
    let _underlying                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.underlying())
    let _accruedAmount                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accruedAmount(d.Value))
    let _adjustedFixing                            = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.adjustedFixing)
    let _amount                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.amount())
    let _dayCounter                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.dayCounter())
    let _fixingDate                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.fixingDate())
    let _fixingDays                                = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.fixingDays)
    let _gearing                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.gearing())
    let _index                                     = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.index())
    let _indexFixing                               = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.indexFixing())
    let _isInArrears                               = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.isInArrears())
    let _price                                     (yts : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.price(yts.Value))
    let _pricer                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.pricer())
    let _spread                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.spread())
    let _update                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.update()
                                                                     _DigitalIborCoupon.Value)
    let _accrualDays                               = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualDays())
    let _accrualEndDate                            = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualEndDate())
    let _accrualPeriod                             = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualPeriod())
    let _accrualStartDate                          = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accrualStartDate())
    let _accruedDays                               (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accruedDays(d.Value))
    let _accruedPeriod                             (d : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accruedPeriod(d.Value))
    let _date                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.date())
    let _exCouponDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.exCouponDate())
    let _nominal                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.nominal())
    let _referencePeriodEnd                        = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.referencePeriodEnd)
    let _referencePeriodStart                      = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.referencePeriodStart)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.Equals(cf.Value))
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.accept(v.Value)
                                                                     _DigitalIborCoupon.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.registerWith(handler.Value)
                                                                     _DigitalIborCoupon.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _DigitalIborCoupon).Value.unregisterWith(handler.Value)
                                                                     _DigitalIborCoupon.Value)
    do this.Bind(_DigitalIborCoupon)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new DigitalIborCouponModel1(null,null,null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _DigitalIborCoupon <- v
    static member Cast (p : ICell<DigitalIborCoupon>) = 
        if p :? DigitalIborCouponModel1 then 
            p :?> DigitalIborCouponModel1
        else
            let o = new DigitalIborCouponModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.underlying                         = _underlying 
    member this.callStrike                         = _callStrike 
    member this.callPosition                       = _callPosition 
    member this.isCallATMIncluded                  = _isCallATMIncluded 
    member this.callDigitalPayoff                  = _callDigitalPayoff 
    member this.putStrike                          = _putStrike 
    member this.putPosition                        = _putPosition 
    member this.isPutATMIncluded                   = _isPutATMIncluded 
    member this.putDigitalPayoff                   = _putDigitalPayoff 
    member this.replication                        = _replication 
    member this.Factory                            underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication   
                                                   = _factory underlying callStrike callPosition isCallATMIncluded callDigitalPayoff putStrike putPosition isPutATMIncluded putDigitalPayoff replication 
    member this.CallDigitalPayoff                  = _callDigitalPayoff
    member this.CallOptionRate                     = _callOptionRate
    member this.CallStrike                         = _callStrike
    member this.ConvexityAdjustment                = _convexityAdjustment
    member this.HasCall                            = _hasCall
    member this.HasCollar                          = _hasCollar
    member this.HasPut                             = _hasPut
    member this.IsLongCall                         = _isLongCall
    member this.IsLongPut                          = _isLongPut
    member this.PutDigitalPayoff                   = _putDigitalPayoff
    member this.PutOptionRate                      = _putOptionRate
    member this.PutStrike                          = _putStrike
    member this.Rate                               = _rate
    member this.SetPricer                          pricer   
                                                   = _setPricer pricer 
    member this.Underlying                         = _underlying
    member this.AccruedAmount                      d   
                                                   = _accruedAmount d 
    member this.AdjustedFixing                     = _adjustedFixing
    member this.Amount                             = _amount
    member this.DayCounter                         = _dayCounter
    member this.FixingDate                         = _fixingDate
    member this.FixingDays                         = _fixingDays
    member this.Gearing                            = _gearing
    member this.Index                              = _index
    member this.IndexFixing                        = _indexFixing
    member this.IsInArrears                        = _isInArrears
    member this.Price                              yts   
                                                   = _price yts 
    member this.Pricer                             = _pricer
    member this.Spread                             = _spread
    member this.Update                             = _update
    member this.AccrualDays                        = _accrualDays
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualPeriod                      = _accrualPeriod
    member this.AccrualStartDate                   = _accrualStartDate
    member this.AccruedDays                        d   
                                                   = _accruedDays d 
    member this.AccruedPeriod                      d   
                                                   = _accruedPeriod d 
    member this.Date                               = _date
    member this.ExCouponDate                       = _exCouponDate
    member this.Nominal                            = _nominal
    member this.ReferencePeriodEnd                 = _referencePeriodEnd
    member this.ReferencePeriodStart               = _referencePeriodStart
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
