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
  Helper class to strip optionlet (i.e. caplet/floorlet) volatilities (a.k.a. forward-forward volatilities) from the (cap/floor) term volatilities of a CapFloorTermVolSurface.

  </summary> *)
[<AutoSerializable(true)>]
type OptionletStripper1Model
    ( termVolSurface                               : ICell<CapFloorTermVolSurface>
    , index                                        : ICell<IborIndex>
    , switchStrike                                 : ICell<Nullable<double>>
    , accuracy                                     : ICell<double>
    , maxIter                                      : ICell<int>
    , discount                                     : ICell<Handle<YieldTermStructure>>
    , Type                                         : ICell<VolatilityType>
    , displacement                                 : ICell<double>
    , dontThrow                                    : ICell<bool>
    ) as this =

    inherit Model<OptionletStripper1> ()
(*
    Parameters
*)
    let _termVolSurface                            = termVolSurface
    let _index                                     = index
    let _switchStrike                              = switchStrike
    let _accuracy                                  = accuracy
    let _maxIter                                   = maxIter
    let _discount                                  = discount
    let _Type                                      = Type
    let _displacement                              = displacement
    let _dontThrow                                 = dontThrow
(*
    Functions
*)
    let mutable
        _OptionletStripper1                        = cell (fun () -> new OptionletStripper1 (termVolSurface.Value, index.Value, switchStrike.Value, accuracy.Value, maxIter.Value, discount.Value, Type.Value, displacement.Value, dontThrow.Value))
    let _capFloorPrices                            = triv (fun () -> _OptionletStripper1.Value.capFloorPrices())
    let _capFloorVolatilities                      = triv (fun () -> _OptionletStripper1.Value.capFloorVolatilities())
    let _optionletPrices                           = triv (fun () -> _OptionletStripper1.Value.optionletPrices())
    let _switchStrike                              = triv (fun () -> _OptionletStripper1.Value.switchStrike())
    let _atmOptionletRates                         = triv (fun () -> _OptionletStripper1.Value.atmOptionletRates())
    let _businessDayConvention                     = triv (fun () -> _OptionletStripper1.Value.businessDayConvention())
    let _calendar                                  = triv (fun () -> _OptionletStripper1.Value.calendar())
    let _dayCounter                                = triv (fun () -> _OptionletStripper1.Value.dayCounter())
    let _displacement                              = triv (fun () -> _OptionletStripper1.Value.displacement())
    let _iborIndex                                 = triv (fun () -> _OptionletStripper1.Value.iborIndex())
    let _optionletAccrualPeriods                   = triv (fun () -> _OptionletStripper1.Value.optionletAccrualPeriods())
    let _optionletFixingDates                      = triv (fun () -> _OptionletStripper1.Value.optionletFixingDates())
    let _optionletFixingTenors                     = triv (fun () -> _OptionletStripper1.Value.optionletFixingTenors())
    let _optionletFixingTimes                      = triv (fun () -> _OptionletStripper1.Value.optionletFixingTimes())
    let _optionletMaturities                       = triv (fun () -> _OptionletStripper1.Value.optionletMaturities())
    let _optionletPaymentDates                     = triv (fun () -> _OptionletStripper1.Value.optionletPaymentDates())
    let _optionletStrikes                          (i : ICell<int>)   
                                                   = triv (fun () -> _OptionletStripper1.Value.optionletStrikes(i.Value))
    let _optionletVolatilities                     (i : ICell<int>)   
                                                   = triv (fun () -> _OptionletStripper1.Value.optionletVolatilities(i.Value))
    let _settlementDays                            = triv (fun () -> _OptionletStripper1.Value.settlementDays())
    let _termVolSurface                            = triv (fun () -> _OptionletStripper1.Value.termVolSurface())
    let _volatilityType                            = triv (fun () -> _OptionletStripper1.Value.volatilityType())
    do this.Bind(_OptionletStripper1)
(* 
    casting 
*)
    internal new () = new OptionletStripper1Model(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _OptionletStripper1 <- v
    static member Cast (p : ICell<OptionletStripper1>) = 
        if p :? OptionletStripper1Model then 
            p :?> OptionletStripper1Model
        else
            let o = new OptionletStripper1Model ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.termVolSurface                     = _termVolSurface 
    member this.index                              = _index 
    member this.switchStrike                       = _switchStrike 
    member this.accuracy                           = _accuracy 
    member this.maxIter                            = _maxIter 
    member this.discount                           = _discount 
    member this.Type                               = _Type 
    member this.displacement                       = _displacement 
    member this.dontThrow                          = _dontThrow 
    member this.CapFloorPrices                     = _capFloorPrices
    member this.CapFloorVolatilities               = _capFloorVolatilities
    member this.OptionletPrices                    = _optionletPrices
    member this.SwitchStrike                       = _switchStrike
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
