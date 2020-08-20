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
type IrrFinderModel
    ( leg                                          : ICell<Leg>
    , npv                                          : ICell<double>
    , dayCounter                                   : ICell<DayCounter>
    , comp                                         : ICell<Compounding>
    , freq                                         : ICell<Frequency>
    , includeSettlementDateFlows                   : ICell<bool>
    , settlementDate                               : ICell<Date>
    , npvDate                                      : ICell<Date>
    ) as this =

    inherit Model<IrrFinder> ()
(*
    Parameters
*)
    let _leg                                       = leg
    let _npv                                       = npv
    let _dayCounter                                = dayCounter
    let _comp                                      = comp
    let _freq                                      = freq
    let _includeSettlementDateFlows                = includeSettlementDateFlows
    let _settlementDate                            = settlementDate
    let _npvDate                                   = npvDate
(*
    Functions
*)
    let _IrrFinder                                 = cell (fun () -> new IrrFinder (leg.Value, npv.Value, dayCounter.Value, comp.Value, freq.Value, includeSettlementDateFlows.Value, settlementDate.Value, npvDate.Value))
    let _derivative                                (y : ICell<double>)   
                                                   = cell (fun () -> _IrrFinder.Value.derivative(y.Value))
    let _value                                     (y : ICell<double>)   
                                                   = cell (fun () -> _IrrFinder.Value.value(y.Value))
    do this.Bind(_IrrFinder)

(* 
    Externally visible/bindable properties
*)
    member this.leg                                = _leg 
    member this.npv                                = _npv 
    member this.dayCounter                         = _dayCounter 
    member this.comp                               = _comp 
    member this.freq                               = _freq 
    member this.includeSettlementDateFlows         = _includeSettlementDateFlows 
    member this.settlementDate                     = _settlementDate 
    member this.npvDate                            = _npvDate 
    member this.Derivative                         y   
                                                   = _derivative y 
    member this.Value                              y   
                                                   = _value y 
