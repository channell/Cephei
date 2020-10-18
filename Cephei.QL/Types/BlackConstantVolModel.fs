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
  This class implements the BlackVolatilityTermStructure interface for a constant Black volatility (no time/strike dependence).

  </summary> *)
[<AutoSerializable(true)>]
type BlackConstantVolModel
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , volatility                                   : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<BlackConstantVol> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _BlackConstantVol                          = cell (fun () -> new BlackConstantVol (settlementDays.Value, cal.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _BlackConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _BlackConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _BlackConstantVol.Value.minStrike())
    do this.Bind(_BlackConstantVol)
(* 
    casting 
*)
    internal new () = new BlackConstantVolModel(null,null,null,null)
    member internal this.Inject v = _BlackConstantVol <- v
    static member Cast (p : ICell<BlackConstantVol>) = 
        if p :? BlackConstantVolModel then 
            p :?> BlackConstantVolModel
        else
            let o = new BlackConstantVolModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
(* <summary>
  This class implements the BlackVolatilityTermStructure interface for a constant Black volatility (no time/strike dependence).

  </summary> *)
[<AutoSerializable(true)>]
type BlackConstantVolModel1
    ( settlementDays                               : ICell<int>
    , cal                                          : ICell<Calendar>
    , volatility                                   : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<BlackConstantVol> ()
(*
    Parameters
*)
    let _settlementDays                            = settlementDays
    let _cal                                       = cal
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _BlackConstantVol                          = cell (fun () -> new BlackConstantVol (settlementDays.Value, cal.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _BlackConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _BlackConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _BlackConstantVol.Value.minStrike())
    do this.Bind(_BlackConstantVol)
(* 
    casting 
*)
    internal new () = new BlackConstantVolModel1(null,null,null,null)
    member internal this.Inject v = _BlackConstantVol <- v
    static member Cast (p : ICell<BlackConstantVol>) = 
        if p :? BlackConstantVolModel1 then 
            p :?> BlackConstantVolModel1
        else
            let o = new BlackConstantVolModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.settlementDays                     = _settlementDays 
    member this.cal                                = _cal 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
(* <summary>
  This class implements the BlackVolatilityTermStructure interface for a constant Black volatility (no time/strike dependence).

  </summary> *)
[<AutoSerializable(true)>]
type BlackConstantVolModel2
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , volatility                                   : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<BlackConstantVol> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _BlackConstantVol                          = cell (fun () -> new BlackConstantVol (referenceDate.Value, cal.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _BlackConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _BlackConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _BlackConstantVol.Value.minStrike())
    do this.Bind(_BlackConstantVol)
(* 
    casting 
*)
    internal new () = new BlackConstantVolModel2(null,null,null,null)
    member internal this.Inject v = _BlackConstantVol <- v
    static member Cast (p : ICell<BlackConstantVol>) = 
        if p :? BlackConstantVolModel2 then 
            p :?> BlackConstantVolModel2
        else
            let o = new BlackConstantVolModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
(* <summary>
  This class implements the BlackVolatilityTermStructure interface for a constant Black volatility (no time/strike dependence).

  </summary> *)
[<AutoSerializable(true)>]
type BlackConstantVolModel3
    ( referenceDate                                : ICell<Date>
    , cal                                          : ICell<Calendar>
    , volatility                                   : ICell<double>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<BlackConstantVol> ()
(*
    Parameters
*)
    let _referenceDate                             = referenceDate
    let _cal                                       = cal
    let _volatility                                = volatility
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _BlackConstantVol                          = cell (fun () -> new BlackConstantVol (referenceDate.Value, cal.Value, volatility.Value, dc.Value))
    let _maxDate                                   = triv (fun () -> _BlackConstantVol.Value.maxDate())
    let _maxStrike                                 = triv (fun () -> _BlackConstantVol.Value.maxStrike())
    let _minStrike                                 = triv (fun () -> _BlackConstantVol.Value.minStrike())
    do this.Bind(_BlackConstantVol)
(* 
    casting 
*)
    internal new () = new BlackConstantVolModel3(null,null,null,null)
    member internal this.Inject v = _BlackConstantVol <- v
    static member Cast (p : ICell<BlackConstantVol>) = 
        if p :? BlackConstantVolModel3 then 
            p :?> BlackConstantVolModel3
        else
            let o = new BlackConstantVolModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.referenceDate                      = _referenceDate 
    member this.cal                                = _cal 
    member this.volatility                         = _volatility 
    member this.dc                                 = _dc 
    member this.MaxDate                            = _maxDate
    member this.MaxStrike                          = _maxStrike
    member this.MinStrike                          = _minStrike
