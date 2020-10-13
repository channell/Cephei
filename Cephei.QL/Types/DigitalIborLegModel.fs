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
type DigitalIborLegModel
    ( schedule                                     : ICell<Schedule>
    , index                                        : ICell<IborIndex>
    ) as this =

    inherit Model<DigitalIborLeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _index                                     = index
(*
    Functions
*)
    let _DigitalIborLeg                            = cell (fun () -> new DigitalIborLeg (schedule.Value, index.Value))
    let _inArrears                                 = triv (fun () -> _DigitalIborLeg.Value.inArrears())
    let _inArrears1                                (flag : ICell<bool>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.inArrears(flag.Value))
    let _value                                     = triv (fun () -> _DigitalIborLeg.Value.value())
    let _withCallATM                               (flag : ICell<bool>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withCallATM(flag.Value))
    let _withCallATM1                              = triv (fun () -> _DigitalIborLeg.Value.withCallATM())
    let _withCallPayoffs                           (payoffs : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withCallPayoffs(payoffs.Value))
    let _withCallPayoffs1                          (payoff : ICell<double>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withCallPayoffs(payoff.Value))
    let _withCallStrikes                           (strikes : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withCallStrikes(strikes.Value))
    let _withCallStrikes1                          (strike : ICell<double>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withCallStrikes(strike.Value))
    let _withFixingDays                            (fixingDays : ICell<Generic.List<int>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withFixingDays(fixingDays.Value))
    let _withFixingDays1                           (fixingDays : ICell<int>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withFixingDays(fixingDays.Value))
    let _withGearings                              (gearings : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withGearings(gearings.Value))
    let _withGearings1                             (gearing : ICell<double>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withGearings(gearing.Value))
    let _withLongCallOption                        (Type : ICell<Position.Type>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withLongCallOption(Type.Value))
    let _withLongPutOption                         (Type : ICell<Position.Type>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withLongPutOption(Type.Value))
    let _withNotionals                             (notionals : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withNotionals(notionals.Value))
    let _withNotionals1                            (notional : ICell<double>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withNotionals(notional.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withPaymentAdjustment(convention.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withPutATM                                (flag : ICell<bool>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withPutATM(flag.Value))
    let _withPutATM1                               = triv (fun () -> _DigitalIborLeg.Value.withPutATM())
    let _withPutPayoffs                            (payoffs : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withPutPayoffs(payoffs.Value))
    let _withPutPayoffs1                           (payoff : ICell<double>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withPutPayoffs(payoff.Value))
    let _withPutStrikes                            (strike : ICell<double>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withPutStrikes(strike.Value))
    let _withPutStrikes1                           (strikes : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withPutStrikes(strikes.Value))
    let _withReplication                           = triv (fun () -> _DigitalIborLeg.Value.withReplication())
    let _withReplication1                          (replication : ICell<DigitalReplication>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withReplication(replication.Value))
    let _withSpreads                               (spreads : ICell<Generic.List<double>>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withSpreads(spreads.Value))
    let _withSpreads1                              (spread : ICell<double>)   
                                                   = triv (fun () -> _DigitalIborLeg.Value.withSpreads(spread.Value))
    do this.Bind(_DigitalIborLeg)
(* 
    casting 
*)
    internal new () = new DigitalIborLegModel(null,null)
    member internal this.Inject v = _DigitalIborLeg.Value <- v
    static member Cast (p : ICell<DigitalIborLeg>) = 
        if p :? DigitalIborLegModel then 
            p :?> DigitalIborLegModel
        else
            let o = new DigitalIborLegModel ()
            o.Inject p.Value
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
    member this.WithCallATM                        flag   
                                                   = _withCallATM flag 
    member this.WithCallATM1                       = _withCallATM1
    member this.WithCallPayoffs                    payoffs   
                                                   = _withCallPayoffs payoffs 
    member this.WithCallPayoffs1                   payoff   
                                                   = _withCallPayoffs1 payoff 
    member this.WithCallStrikes                    strikes   
                                                   = _withCallStrikes strikes 
    member this.WithCallStrikes1                   strike   
                                                   = _withCallStrikes1 strike 
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
    member this.WithNotionals                      notionals   
                                                   = _withNotionals notionals 
    member this.WithNotionals1                     notional   
                                                   = _withNotionals1 notional 
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
    member this.WithPutStrikes                     strike   
                                                   = _withPutStrikes strike 
    member this.WithPutStrikes1                    strikes   
                                                   = _withPutStrikes1 strikes 
    member this.WithReplication                    = _withReplication
    member this.WithReplication1                   replication   
                                                   = _withReplication1 replication 
    member this.WithSpreads                        spreads   
                                                   = _withSpreads spreads 
    member this.WithSpreads1                       spread   
                                                   = _withSpreads1 spread 
