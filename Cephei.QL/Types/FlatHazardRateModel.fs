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
  defaultprobabilitytermstructures

  </summary> *)
[<AutoSerializable(true)>]
type FlatHazardRateModel
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , hazardRate                                   : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<FlatHazardRate> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _hazardRate                                = hazardRate
    let _dc                                        = dc
(*
    Functions
*)
    let _FlatHazardRate                            = cell (fun () -> new FlatHazardRate (settlementDays.Value, calendar.Value, hazardRate.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _FlatHazardRate.Value.maxDate())
    do this.Bind(_FlatHazardRate)
(* 
    casting 
*)
    internal new () = FlatHazardRateModel(null,null,null,null)
    member internal this.Inject v = _FlatHazardRate.Value <- v
    static member Cast (p : ICell<FlatHazardRate>) = 
        if p :? FlatHazardRateModel then 
            p :?> FlatHazardRateModel
        else
            let o = new FlatHazardRateModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.hazardRate                         = _hazardRate 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
(* <summary>
  defaultprobabilitytermstructures

  </summary> *)
[<AutoSerializable(true)>]
type FlatHazardRateModel1
    ( referenceDate                                : ICell<Date>
    , hazardRate                                   : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<FlatHazardRate> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _hazardRate                                = hazardRate
    let _dc                                        = dc
(*
    Functions
*)
    let _FlatHazardRate                            = cell (fun () -> new FlatHazardRate (referenceDate.Value, hazardRate.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _FlatHazardRate.Value.maxDate())
    do this.Bind(_FlatHazardRate)
(* 
    casting 
*)
    internal new () = FlatHazardRateModel1(null,null,null)
    member internal this.Inject v = _FlatHazardRate.Value <- v
    static member Cast (p : ICell<FlatHazardRate>) = 
        if p :? FlatHazardRateModel1 then 
            p :?> FlatHazardRateModel1
        else
            let o = new FlatHazardRateModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.hazardRate                         = _hazardRate 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
(* <summary>
  defaultprobabilitytermstructures

  </summary> *)
[<AutoSerializable(true)>]
type FlatHazardRateModel2
    ( referenceDate                                : ICell<Date>
    , hazardRate                                   : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<FlatHazardRate> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _hazardRate                                = hazardRate
    let _dc                                        = dc
(*
    Functions
*)
    let _FlatHazardRate                            = cell (fun () -> new FlatHazardRate (referenceDate.Value, hazardRate.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _FlatHazardRate.Value.maxDate())
    do this.Bind(_FlatHazardRate)
(* 
    casting 
*)
    internal new () = FlatHazardRateModel2(null,null,null)
    member internal this.Inject v = _FlatHazardRate.Value <- v
    static member Cast (p : ICell<FlatHazardRate>) = 
        if p :? FlatHazardRateModel2 then 
            p :?> FlatHazardRateModel2
        else
            let o = new FlatHazardRateModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.hazardRate                         = _hazardRate 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
(* <summary>
  defaultprobabilitytermstructures

  </summary> *)
[<AutoSerializable(true)>]
type FlatHazardRateModel3
    ( settlementDays                               : ICell<int>
    , calendar                                     : ICell<Calendar>
    , hazardRate                                   : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<FlatHazardRate> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _calendar                                  = calendar
    let _hazardRate                                = hazardRate
    let _dc                                        = dc
(*
    Functions
*)
    let _FlatHazardRate                            = cell (fun () -> new FlatHazardRate (settlementDays.Value, calendar.Value, hazardRate.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _FlatHazardRate.Value.maxDate())
    do this.Bind(_FlatHazardRate)
(* 
    casting 
*)
    internal new () = FlatHazardRateModel3(null,null,null,null)
    member internal this.Inject v = _FlatHazardRate.Value <- v
    static member Cast (p : ICell<FlatHazardRate>) = 
        if p :? FlatHazardRateModel3 then 
            p :?> FlatHazardRateModel3
        else
            let o = new FlatHazardRateModel3 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.calendar                           = _calendar 
    member this.hazardRate                         = _hazardRate 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
