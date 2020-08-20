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
  This term structure will remain linked to the original structure, i.e., any changes in the latter will be reflected in this structure as well.  yieldtermstructures  - the correctness of the returned values is tested by checking them against numerical calculations. - observability against changes in the underlying term structure and in the added spread is checked.

  </summary> *)
[<AutoSerializable(true)>]
type ForwardSpreadedTermStructureModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    , spread                                       : ICell<Handle<Quote>>
    ) as this =

    inherit Model<ForwardSpreadedTermStructure> ()
(*
    Parameters
*)
    let _h                                         = h
    let _spread                                    = spread
(*
    Functions
*)
    let _ForwardSpreadedTermStructure              = cell (fun () -> new ForwardSpreadedTermStructure (h.Value, spread.Value))
    let _calendar                                  = cell (fun () -> _ForwardSpreadedTermStructure.Value.calendar())
    let _dayCounter                                = cell (fun () -> _ForwardSpreadedTermStructure.Value.dayCounter())
    let _maxDate                                   = cell (fun () -> _ForwardSpreadedTermStructure.Value.maxDate())
    let _maxTime                                   = cell (fun () -> _ForwardSpreadedTermStructure.Value.maxTime())
    let _referenceDate                             = cell (fun () -> _ForwardSpreadedTermStructure.Value.referenceDate())
    let _settlementDays                            = cell (fun () -> _ForwardSpreadedTermStructure.Value.settlementDays())
    do this.Bind(_ForwardSpreadedTermStructure)

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.spread                             = _spread 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
