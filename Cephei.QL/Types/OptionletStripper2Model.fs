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
  Helper class to extend an OptionletStripper1 object stripping additional optionlet (i.e. caplet/floorlet) volatilities (a.k.a. forward-forward volatilities) from the (cap/floor) At-The-Money term volatilities of a CapFloorTermVolCurve.

  </summary> *)
[<AutoSerializable(true)>]
type OptionletStripper2Model
    ( optionletStripper1                           : ICell<OptionletStripper1>
    , atmCapFloorTermVolCurve                      : ICell<Handle<CapFloorTermVolCurve>>
    ) as this =

    inherit Model<OptionletStripper2> ()
(*
    Parameters
*)
    let _optionletStripper1                        = optionletStripper1
    let _atmCapFloorTermVolCurve                   = atmCapFloorTermVolCurve
(*
    Functions
*)
    let _OptionletStripper2                        = cell (fun () -> new OptionletStripper2 (optionletStripper1.Value, atmCapFloorTermVolCurve.Value))
    let _atmCapFloorPrices                         = triv (fun () -> _OptionletStripper2.Value.atmCapFloorPrices())
    let _atmCapFloorStrikes                        = triv (fun () -> _OptionletStripper2.Value.atmCapFloorStrikes())
    let _spreadsVol                                = triv (fun () -> _OptionletStripper2.Value.spreadsVol())
    let _atmOptionletRates                         = triv (fun () -> _OptionletStripper2.Value.atmOptionletRates())
    let _businessDayConvention                     = triv (fun () -> _OptionletStripper2.Value.businessDayConvention())
    let _calendar                                  = triv (fun () -> _OptionletStripper2.Value.calendar())
    let _dayCounter                                = triv (fun () -> _OptionletStripper2.Value.dayCounter())
    let _displacement                              = triv (fun () -> _OptionletStripper2.Value.displacement())
    let _iborIndex                                 = triv (fun () -> _OptionletStripper2.Value.iborIndex())
    let _optionletAccrualPeriods                   = triv (fun () -> _OptionletStripper2.Value.optionletAccrualPeriods())
    let _optionletFixingDates                      = triv (fun () -> _OptionletStripper2.Value.optionletFixingDates())
    let _optionletFixingTenors                     = triv (fun () -> _OptionletStripper2.Value.optionletFixingTenors())
    let _optionletFixingTimes                      = triv (fun () -> _OptionletStripper2.Value.optionletFixingTimes())
    let _optionletMaturities                       = triv (fun () -> _OptionletStripper2.Value.optionletMaturities())
    let _optionletPaymentDates                     = triv (fun () -> _OptionletStripper2.Value.optionletPaymentDates())
    let _optionletStrikes                          (i : ICell<int>)   
                                                   = triv (fun () -> _OptionletStripper2.Value.optionletStrikes(i.Value))
    let _optionletVolatilities                     (i : ICell<int>)   
                                                   = triv (fun () -> _OptionletStripper2.Value.optionletVolatilities(i.Value))
    let _settlementDays                            = triv (fun () -> _OptionletStripper2.Value.settlementDays())
    let _termVolSurface                            = triv (fun () -> _OptionletStripper2.Value.termVolSurface())
    let _volatilityType                            = triv (fun () -> _OptionletStripper2.Value.volatilityType())
    do this.Bind(_OptionletStripper2)
(* 
    casting 
*)
    internal new () = new OptionletStripper2Model(null,null)
    member internal this.Inject v = _OptionletStripper2.Value <- v
    static member Cast (p : ICell<OptionletStripper2>) = 
        if p :? OptionletStripper2Model then 
            p :?> OptionletStripper2Model
        else
            let o = new OptionletStripper2Model ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.optionletStripper1                 = _optionletStripper1 
    member this.atmCapFloorTermVolCurve            = _atmCapFloorTermVolCurve 
    member this.AtmCapFloorPrices                  = _atmCapFloorPrices
    member this.AtmCapFloorStrikes                 = _atmCapFloorStrikes
    member this.SpreadsVol                         = _spreadsVol
    member this.AtmOptionletRates                  = _atmOptionletRates
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.Displacement                       = _displacement
    member this.IborIndex                          = _iborIndex
    member this.OptionletAccrualPeriods            = _optionletAccrualPeriods
    member this.OptionletFixingDates               = _optionletFixingDates
    member this.OptionletFixingTenors              = _optionletFixingTenors
    member this.OptionletFixingTimes               = _optionletFixingTimes
    member this.OptionletMaturities                = _optionletMaturities
    member this.OptionletPaymentDates              = _optionletPaymentDates
    member this.OptionletStrikes                   i   
                                                   = _optionletStrikes i 
    member this.OptionletVolatilities              i   
                                                   = _optionletVolatilities i 
    member this.SettlementDays                     = _settlementDays
    member this.TermVolSurface                     = _termVolSurface
    member this.VolatilityType                     = _volatilityType
