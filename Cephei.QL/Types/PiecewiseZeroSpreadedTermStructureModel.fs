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
type PiecewiseZeroSpreadedTermStructureModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    , spreads                                      : ICell<Generic.List<Handle<Quote>>>
    , dates                                        : ICell<Generic.List<Date>>
    , compounding                                  : ICell<Compounding>
    , frequency                                    : ICell<Frequency>
    , dc                                           : ICell<DayCounter>
    ) as this =

    inherit Model<PiecewiseZeroSpreadedTermStructure> ()
(*
    Parameters
*)
    let _h                                         = h
    let _spreads                                   = spreads
    let _dates                                     = dates
    let _compounding                               = compounding
    let _frequency                                 = frequency
    let _dc                                        = dc
(*
    Functions
*)
    let mutable
        _PiecewiseZeroSpreadedTermStructure        = cell (fun () -> new PiecewiseZeroSpreadedTermStructure (h.Value, spreads.Value, dates.Value, compounding.Value, frequency.Value, dc.Value))
    let _calendar                                  = triv (fun () -> _PiecewiseZeroSpreadedTermStructure.Value.calendar())
    let _dayCounter                                = triv (fun () -> _PiecewiseZeroSpreadedTermStructure.Value.dayCounter())
    let _maxDate                                   = triv (fun () -> _PiecewiseZeroSpreadedTermStructure.Value.maxDate())
    let _referenceDate                             = triv (fun () -> _PiecewiseZeroSpreadedTermStructure.Value.referenceDate())
    let _settlementDays                            = triv (fun () -> _PiecewiseZeroSpreadedTermStructure.Value.settlementDays())
    do this.Bind(_PiecewiseZeroSpreadedTermStructure)
(* 
    casting 
*)
    internal new () = new PiecewiseZeroSpreadedTermStructureModel(null,null,null,null,null,null)
    member internal this.Inject v = _PiecewiseZeroSpreadedTermStructure <- v
    static member Cast (p : ICell<PiecewiseZeroSpreadedTermStructure>) = 
        if p :? PiecewiseZeroSpreadedTermStructureModel then 
            p :?> PiecewiseZeroSpreadedTermStructureModel
        else
            let o = new PiecewiseZeroSpreadedTermStructureModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.spreads                            = _spreads 
    member this.dates                              = _dates 
    member this.compounding                        = _compounding 
    member this.frequency                          = _frequency 
    member this.dc                                 = _dc 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
