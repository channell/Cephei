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
  helper class building a sequence of digital ibor-rate coupons

  </summary> *)
[<AutoSerializable(true)>]
type DigitalCmsLegModel
    ( schedule                                     : ICell<Schedule>
    , index                                        : ICell<SwapIndex>
    ) as this =

    inherit Model<DigitalCmsLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _index                                     = index
(*
    Functions
*)
    let mutable
        _DigitalCmsLeg                             = cell (fun () -> new DigitalCmsLeg (schedule.Value, index.Value))
    let _inArrears                                 = triv (fun () -> _DigitalCmsLeg.Value.inArrears())
    let _inArrears1                                (flag : ICell<bool>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.inArrears(flag.Value))
    let _value                                     = triv (fun () -> _DigitalCmsLeg.Value.value())
    let _withCallATM                               = triv (fun () -> _DigitalCmsLeg.Value.withCallATM())
    let _withCallATM1                              (flag : ICell<bool>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withCallATM(flag.Value))
    let _withCallPayoffs                           (payoff : ICell<double>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withCallPayoffs(payoff.Value))
    let _withCallPayoffs1                          (payoffs : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withCallPayoffs(payoffs.Value))
    let _withCallStrikes                           (strike : ICell<double>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withCallStrikes(strike.Value))
    let _withCallStrikes1                          (strikes : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withCallStrikes(strikes.Value))
    let _withFixingDays                            (fixingDays : ICell<int>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withFixingDays(fixingDays.Value))
    let _withFixingDays1                           (fixingDays : ICell<Generic.List<int>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withFixingDays(fixingDays.Value))
    let _withGearings                              (gearings : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withGearings(gearings.Value))
    let _withGearings1                             (gearing : ICell<double>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withGearings(gearing.Value))
    let _withLongCallOption                        (Type : ICell<Position.Type>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withLongCallOption(Type.Value))
    let _withLongPutOption                         (Type : ICell<Position.Type>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withLongPutOption(Type.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withNotionals(notionals.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withPaymentAdjustment(convention.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withPutATM                                (flag : ICell<bool>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withPutATM(flag.Value))
    let _withPutATM1                               = triv (fun () -> _DigitalCmsLeg.Value.withPutATM())
    let _withPutPayoffs                            (payoffs : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withPutPayoffs(payoffs.Value))
    let _withPutPayoffs1                           (payoff : ICell<double>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withPutPayoffs(payoff.Value))
    let _withPutStrikes                            (strikes : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withPutStrikes(strikes.Value))
    let _withPutStrikes1                           (strike : ICell<double>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withPutStrikes(strike.Value))
    let _withReplication                           (replication : ICell<DigitalReplication>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withReplication(replication.Value))
    let _withReplication1                          = triv (fun () -> _DigitalCmsLeg.Value.withReplication())
    let _withSpreads                               (spread : ICell<double>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withSpreads(spread.Value))
    let _withSpreads1                              (spreads : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalCmsLeg.Value.withSpreads(spreads.Value))
    do this.Bind(_DigitalCmsLeg)
(* 
    casting 
*)
    internal new () = new DigitalCmsLegModel(null,null)
    member internal this.Inject v = _DigitalCmsLeg <- v
    static member Cast (p : ICell<DigitalCmsLeg>) = 
        if p :? DigitalCmsLegModel then 
            p :?> DigitalCmsLegModel
        else
            let o = new DigitalCmsLegModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.InArrears                          = _inArrears
    member this.InArrears1                         flag   
                                                   = _inArrears1 flag 
    member this.Value                              = _value
    member this.WithCallATM                        = _withCallATM
    member this.WithCallATM1                       flag   
                                                   = _withCallATM1 flag 
    member this.WithCallPayoffs                    payoff   
                                                   = _withCallPayoffs payoff 
    member this.WithCallPayoffs1                   payoffs   
                                                   = _withCallPayoffs1 payoffs 
    member this.WithCallStrikes                    strike   
                                                   = _withCallStrikes strike 
    member this.WithCallStrikes1                   strikes   
                                                   = _withCallStrikes1 strikes 
    member this.WithFixingDays                     fixingDays   
                                                   = _withFixingDays fixingDays 
    member this.WithFixingDays1                    fixingDays   
                                                   = _withFixingDays1 fixingDays 
    member this.WithGearings                       gearings   
                                                   = _withGearings gearings 
    member this.WithGearings1                      gearing   
                                                   = _withGearings1 gearing 
    member this.WithLongCallOption                 Type   
                                                   = _withLongCallOption Type 
    member this.WithLongPutOption                  Type   
                                                   = _withLongPutOption Type 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithPutATM                         flag   
                                                   = _withPutATM flag 
    member this.WithPutATM1                        = _withPutATM1
    member this.WithPutPayoffs                     payoffs   
                                                   = _withPutPayoffs payoffs 
    member this.WithPutPayoffs1                    payoff   
                                                   = _withPutPayoffs1 payoff 
    member this.WithPutStrikes                     strikes   
                                                   = _withPutStrikes strikes 
    member this.WithPutStrikes1                    strike   
                                                   = _withPutStrikes1 strike 
    member this.WithReplication                    replication   
                                                   = _withReplication replication 
    member this.WithReplication1                   = _withReplication1
    member this.WithSpreads                        spread   
                                                   = _withSpreads spread 
    member this.WithSpreads1                       spreads   
                                                   = _withSpreads1 spreads 
