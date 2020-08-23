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
  helper class building a Bullet Principal leg
constructor
  </summary> *)
[<AutoSerializable(true)>]
type PricipalLegModel
    ( schedule                                     : ICell<Schedule>
    , paymentDayCounter                            : ICell<DayCounter>
    ) as this =

    inherit Model<PricipalLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _paymentDayCounter                         = paymentDayCounter
(*
    Functions
*)
    let _PricipalLeg                               = cell (fun () -> new PricipalLeg (schedule.Value, paymentDayCounter.Value))
    let _value                                     = triv (fun () -> _PricipalLeg.Value.value())
    let _withNotionals                             (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _PricipalLeg.Value.withNotionals(notionals.Value))
    let _withNotionals1                            (notional : ICell<double>)   
                                                   = triv (fun () -> _PricipalLeg.Value.withNotionals(notional.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _PricipalLeg.Value.withPaymentAdjustment(convention.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _PricipalLeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withSign                                  (sign : ICell<int>)   
                                                   = triv (fun () -> _PricipalLeg.Value.withSign(sign.Value))
    do this.Bind(_PricipalLeg)

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.paymentDayCounter                  = _paymentDayCounter 
    member this.Value                              = _value
    member this.WithNotionals                      notionals   
                                                   = _withNotionals notionals 
    member this.WithNotionals1                     notional   
                                                   = _withNotionals1 notional 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSign                           sign   
                                                   = _withSign sign 
