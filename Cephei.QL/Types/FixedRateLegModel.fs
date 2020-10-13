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
  helper class building a sequence of fixed rate coupons
constructor
  </summary> *)
[<AutoSerializable(true)>]
type FixedRateLegModel
    ( schedule                                     : ICell<Schedule>
    ) as this =

    inherit Model<FixedRateLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
(*
    Functions
*)
    let _FixedRateLeg                              = cell (fun () -> new FixedRateLeg (schedule.Value))
    let _value                                     = triv (fun () -> _FixedRateLeg.Value.value())
    let _withCouponRates                           (couponRate : ICell<double>) (paymentDayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRate.Value, paymentDayCounter.Value, comp.Value, freq.Value))
    let _withCouponRates1                          (couponRate : ICell<double>) (paymentDayCounter : ICell<DayCounter>) (comp : ICell<Compounding>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRate.Value, paymentDayCounter.Value, comp.Value))
    let _withCouponRates2                          (couponRates : ICell<Generic.List<double>>) (paymentDayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRates.Value, paymentDayCounter.Value))
    let _withCouponRates3                          (couponRates : ICell<Generic.List<double>>) (paymentDayCounter : ICell<DayCounter>) (comp : ICell<Compounding>) (freq : ICell<Frequency>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRates.Value, paymentDayCounter.Value, comp.Value, freq.Value))
    let _withCouponRates4                          (couponRates : ICell<Generic.List<InterestRate>>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRates.Value))
    let _withCouponRates5                          (couponRate : ICell<InterestRate>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRate.Value))
    let _withCouponRates6                          (couponRate : ICell<double>) (paymentDayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRate.Value, paymentDayCounter.Value))
    let _withCouponRates7                          (couponRates : ICell<Generic.List<double>>) (paymentDayCounter : ICell<DayCounter>) (comp : ICell<Compounding>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withCouponRates(couponRates.Value, paymentDayCounter.Value, comp.Value))
    let _withExCouponPeriod                        (period : ICell<Period>) (cal : ICell<Calendar>) (convention : ICell<BusinessDayConvention>) (endOfMonth : ICell<bool>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withExCouponPeriod(period.Value, cal.Value, convention.Value, endOfMonth.Value))
    let _withFirstPeriodDayCounter                 (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withFirstPeriodDayCounter(dayCounter.Value))
    let _withLastPeriodDayCounter                  (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withLastPeriodDayCounter(dayCounter.Value))
    let _withPaymentCalendar                       (cal : ICell<Calendar>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withPaymentCalendar(cal.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withNotionals(notionals.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _FixedRateLeg.Value.withPaymentAdjustment(convention.Value))
    do this.Bind(_FixedRateLeg)
(* 
    casting 
*)
    internal new () = new FixedRateLegModel(null)
    member internal this.Inject v = _FixedRateLeg.Value <- v
    static member Cast (p : ICell<FixedRateLeg>) = 
        if p :? FixedRateLegModel then 
            p :?> FixedRateLegModel
        else
            let o = new FixedRateLegModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.Value                              = _value
    member this.WithCouponRates                    couponRate paymentDayCounter comp freq   
                                                   = _withCouponRates couponRate paymentDayCounter comp freq 
    member this.WithCouponRates1                   couponRate paymentDayCounter comp   
                                                   = _withCouponRates1 couponRate paymentDayCounter comp 
    member this.WithCouponRates2                   couponRates paymentDayCounter   
                                                   = _withCouponRates2 couponRates paymentDayCounter 
    member this.WithCouponRates3                   couponRates paymentDayCounter comp freq   
                                                   = _withCouponRates3 couponRates paymentDayCounter comp freq 
    member this.WithCouponRates4                   couponRates   
                                                   = _withCouponRates4 couponRates 
    member this.WithCouponRates5                   couponRate   
                                                   = _withCouponRates5 couponRate 
    member this.WithCouponRates6                   couponRate paymentDayCounter   
                                                   = _withCouponRates6 couponRate paymentDayCounter 
    member this.WithCouponRates7                   couponRates paymentDayCounter comp   
                                                   = _withCouponRates7 couponRates paymentDayCounter comp 
    member this.WithExCouponPeriod                 period cal convention endOfMonth   
                                                   = _withExCouponPeriod period cal convention endOfMonth 
    member this.WithFirstPeriodDayCounter          dayCounter   
                                                   = _withFirstPeriodDayCounter dayCounter 
    member this.WithLastPeriodDayCounter           dayCounter   
                                                   = _withLastPeriodDayCounter dayCounter 
    member this.WithPaymentCalendar                cal   
                                                   = _withPaymentCalendar cal 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
