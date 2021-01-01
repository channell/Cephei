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
type AverageBMALegModel
    ( schedule                                     : ICell<Schedule>
    , index                                        : ICell<BMAIndex>
    ) as this =

    inherit Model<AverageBMALeg> ()
(*
    Parameters
*)
    let _schedule                                  = schedule
    let _index                                     = index
(*
    Functions
*)
    let mutable
        _AverageBMALeg                             = make (fun () -> new AverageBMALeg (schedule.Value, index.Value))
    let _value                                     = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.value())
    let _withGearings                              (gearings : ICell<Generic.List<double>>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withGearings(gearings.Value))
    let _withGearings1                             (gearing : ICell<double>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withGearings(gearing.Value))
    let _withPaymentDayCounter                     (dayCounter : ICell<DayCounter>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withPaymentDayCounter(dayCounter.Value))
    let _withSpreads                               (spread : ICell<double>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withSpreads(spread.Value))
    let _withSpreads1                              (spreads : ICell<Generic.List<double>>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withSpreads(spreads.Value))
    let _withNotionals                             (notional : ICell<double>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withNotionals(notional.Value))
    let _withNotionals1                            (notionals : ICell<Generic.List<double>>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withNotionals(notionals.Value))
    let _withPaymentAdjustment                     (convention : ICell<BusinessDayConvention>)   
                                                   = triv _AverageBMALeg (fun () -> _AverageBMALeg.Value.withPaymentAdjustment(convention.Value))
    do this.Bind(_AverageBMALeg)
(* 
    casting 
*)
    internal new () = new AverageBMALegModel(null,null)
    member internal this.Inject v = _AverageBMALeg <- v
    static member Cast (p : ICell<AverageBMALeg>) = 
        if p :? AverageBMALegModel then 
            p :?> AverageBMALegModel
        else
            let o = new AverageBMALegModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.schedule                           = _schedule 
    member this.index                              = _index 
    member this.Value                              = _value
    member this.WithGearings                       gearings   
                                                   = _withGearings gearings 
    member this.WithGearings1                      gearing   
                                                   = _withGearings1 gearing 
    member this.WithPaymentDayCounter              dayCounter   
                                                   = _withPaymentDayCounter dayCounter 
    member this.WithSpreads                        spread   
                                                   = _withSpreads spread 
    member this.WithSpreads1                       spreads   
                                                   = _withSpreads1 spreads 
    member this.WithNotionals                      notional   
                                                   = _withNotionals notional 
    member this.WithNotionals1                     notionals   
                                                   = _withNotionals1 notionals 
    member this.WithPaymentAdjustment              convention   
                                                   = _withPaymentAdjustment convention 
