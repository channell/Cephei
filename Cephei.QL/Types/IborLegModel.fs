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
  helper class building a sequence of capped/floored ibor-rate coupons
constructor
  </summary> *)
[<AutoSerializable(true)>]
type IborLegModel
    ( schedule                                     : ICell<Schedule>
    , index                                        : ICell<IborIndex>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<IborLeg> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _schedule                                  = schedule
    let _index                                     = index
(*
    Functions
*)
    let mutable
        _IborLeg                                   = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new IborLeg (schedule.Value, index.Value))))
    let _value                                     = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.value())
    let _inArrears                                 = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.inArrears())
    let _inArrears1                                (flag : ICell<bool>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.inArrears(flag.Value))
    let _withCaps                                  (caps : ICell<Generic.List<Nullable<double>>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withCaps(caps.Value))
    let _withCaps1                                 (cap : ICell<Nullable<double>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withCaps(cap.Value))
    let _withFixingDays                            (fixingDays : ICell<int>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withFixingDays(fixingDays.Value))
    let _withFixingDays1                           (fixingDays : ICell<Generic.List<int>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withFixingDays(fixingDays.Value))
    let _withFloors                                (floor : ICell<Nullable<double>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withFloors(floor.Value))
    let _withFloors1                               (floors : ICell<Generic.List<Nullable<double>>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withFloors(floors.Value))
    let _withGearings                              (gearing : ICell<double>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withGearings(gearing.Value))
    let _withGearings1                             (gearings : ICell<Generic.List<double>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withGearings(gearings.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withPaymentDayCounter(dayCounter.Value))
    let _withSpreads                               (spread : ICell<double>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withSpreads(spread.Value))
    let _withSpreads1                              (spreads : ICell<Generic.List<double>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withSpreads(spreads.Value))
    let _withZeroPayments                          = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withZeroPayments())
    let _withZeroPayments1                         (flag : ICell<bool>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withZeroPayments(flag.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withNotionals(notionals.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv _IborLeg (fun () -> (curryEvaluationDate _evaluationDate _IborLeg).Value.withPaymentAdjustment(convention.Value))
    do this.Bind(_IborLeg)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new IborLegModel(null,null,null)
    member internal this.Inject v = _IborLeg <- v
    static member Cast (p : ICell<IborLeg>) = 
        if p :? IborLegModel then 
            p :?> IborLegModel
        else
            let o = new IborLegModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.Value                              = _value
    member this.InArrears                          = _inArrears
    member this.InArrears1                         flag   
                                                   = _inArrears1 flag 
    member this.WithCaps                           caps   
                                                   = _withCaps caps 
    member this.WithCaps1                          cap   
                                                   = _withCaps1 cap 
    member this.WithFixingDays                     fixingDays   
                                                   = _withFixingDays fixingDays 
    member this.WithFixingDays1                    fixingDays   
                                                   = _withFixingDays1 fixingDays 
    member this.WithFloors                         floor   
                                                   = _withFloors floor 
    member this.WithFloors1                        floors   
                                                   = _withFloors1 floors 
    member this.WithGearings                       gearing   
                                                   = _withGearings gearing 
    member this.WithGearings1                      gearings   
                                                   = _withGearings1 gearings 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSpreads                        spread   
                                                   = _withSpreads spread 
    member this.WithSpreads1                       spreads   
                                                   = _withSpreads1 spreads 
    member this.WithZeroPayments                   = _withZeroPayments
    member this.WithZeroPayments1                  flag   
                                                   = _withZeroPayments1 flag 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
