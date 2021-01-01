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
type CompositeZeroYieldStructureModel
    ( h1                                           : ICell<Handle<YieldTermStructure>>
    , h2                                           : ICell<Handle<YieldTermStructure>>
    , f                                            : ICell<Func<double,double,double>>
    , comp                                         : ICell<Compounding>
    , freq                                         : ICell<Frequency>
    ) as this =

    inherit Model<CompositeZeroYieldStructure> ()
(*
    Parameters
*)
    let _h1                                        = h1
    let _h2                                        = h2
    let _f                                         = f
    let _comp                                      = comp
    let _freq                                      = freq
(*
    Functions
*)
    let mutable
        _CompositeZeroYieldStructure               = make (fun () -> new CompositeZeroYieldStructure (h1.Value, h2.Value, f.Value, comp.Value, freq.Value))
    let _calendar                                  = triv _CompositeZeroYieldStructure (fun () -> _CompositeZeroYieldStructure.Value.calendar())
    let _dayCounter                                = triv _CompositeZeroYieldStructure (fun () -> _CompositeZeroYieldStructure.Value.dayCounter())
    let _maxDate                                   = triv _CompositeZeroYieldStructure (fun () -> _CompositeZeroYieldStructure.Value.maxDate())
    let _maxTime                                   = triv _CompositeZeroYieldStructure (fun () -> _CompositeZeroYieldStructure.Value.maxTime())
    let _referenceDate                             = triv _CompositeZeroYieldStructure (fun () -> _CompositeZeroYieldStructure.Value.referenceDate())
    let _settlementDays                            = triv _CompositeZeroYieldStructure (fun () -> _CompositeZeroYieldStructure.Value.settlementDays())
    let _update                                    = triv _CompositeZeroYieldStructure (fun () -> _CompositeZeroYieldStructure.Value.update()
                                                                                                  _CompositeZeroYieldStructure.Value)
    do this.Bind(_CompositeZeroYieldStructure)
(* 
    casting 
*)
    internal new () = new CompositeZeroYieldStructureModel(null,null,null,null,null)
    member internal this.Inject v = _CompositeZeroYieldStructure <- v
    static member Cast (p : ICell<CompositeZeroYieldStructure>) = 
        if p :? CompositeZeroYieldStructureModel then 
            p :?> CompositeZeroYieldStructureModel
        else
            let o = new CompositeZeroYieldStructureModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.h1                                 = _h1 
    member this.h2                                 = _h2 
    member this.f                                  = _f 
    member this.comp                               = _comp 
    member this.freq                               = _freq 
    member this.Calendar                           = _calendar
    member this.DayCounter                         = _dayCounter
    member this.MaxDate                            = _maxDate
    member this.MaxTime                            = _maxTime
    member this.ReferenceDate                      = _referenceDate
    member this.SettlementDays                     = _settlementDays
    member this.Update                             = _update
