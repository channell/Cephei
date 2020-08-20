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
type ZSpreadFinderModel
    ( leg                                          : ICell<Leg>
    , discountCurve                                : ICell<YieldTermStructure>
    , npv                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , comp                                         : ICell<Compounding>
    , freq                                         : ICell<Frequency>
    , includeSettlementDateFlows                   : ICell<bool>
    , settlementDate                               : ICell<Date>
    , npvDate                                      : ICell<Date>
    ) as this =

    inherit Model<ZSpreadFinder> ()
(*
    Parameters
*)
    let _leg                                       = leg
    let _discountCurve                             = discountCurve
    let _npv                                       = npv
    let _dc                                        = dc
    let _comp                                      = comp
    let _freq                                      = freq
    let _includeSettlementDateFlows                = includeSettlementDateFlows
    let _settlementDate                            = settlementDate
    let _npvDate                                   = npvDate
(*
    Functions
*)
    let _ZSpreadFinder                             = cell (fun () -> new ZSpreadFinder (leg.Value, discountCurve.Value, npv.Value, dc.Value, comp.Value, freq.Value, includeSettlementDateFlows.Value, settlementDate.Value, npvDate.Value))
    let _value                                     (zSpread : ICell<double>)   
                                                   = cell (fun () -> _ZSpreadFinder.Value.value(zSpread.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = cell (fun () -> _ZSpreadFinder.Value.derivative(x.Value))
    do this.Bind(_ZSpreadFinder)

(* 
    Externally visible/bindable properties
*)
    member this.leg                                = _leg 
    member this.discountCurve                      = _discountCurve 
    member this.npv                                = _npv 
    member this.dc                                 = _dc 
    member this.comp                               = _comp 
    member this.freq                               = _freq 
    member this.includeSettlementDateFlows         = _includeSettlementDateFlows 
    member this.settlementDate                     = _settlementDate 
    member this.npvDate                            = _npvDate 
    member this.Value                              zSpread   
                                                   = _value zSpread 
    member this.Derivative                         x   
                                                   = _derivative x 
