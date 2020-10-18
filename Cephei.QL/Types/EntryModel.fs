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
type EntryModel
    ( r                                            : ICell<ExchangeRate>
    , s                                            : ICell<Date>
    , e                                            : ICell<Date>
    ) as this =

    inherit Model<Entry> ()
(*
    Parameters
*)
    let _r                                         = r
    let _s                                         = s
    let _e                                         = e
(*
    Functions
*)
    let mutable
        _Entry                                     = cell (fun () -> new Entry (r.Value, s.Value, e.Value))
    let _endDate                                   = cell (fun () -> _Entry.Value.endDate)
    let _rate                                      = cell (fun () -> _Entry.Value.rate)
    let _startDate                                 = cell (fun () -> _Entry.Value.startDate)
    do this.Bind(_Entry)
(* 
    casting 
*)
    internal new () = EntryModel(null,null,null)
    member internal this.Inject v = _Entry <- v
    static member Cast (p : ICell<Entry>) = 
        if p :? EntryModel then 
            p :?> EntryModel
        else
            let o = new EntryModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = EntryModel(null,null,null)
    static member Cast (p : ICell<Entry>) = 
        if p :? EntryModel then 
            p :?> EntryModel
        else
            let o = new EntryModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.r                                  = _r 
    member this.s                                  = _s 
    member this.e                                  = _e 
    member this.EndDate                            = _endDate
    member this.Rate                               = _rate
    member this.StartDate                          = _startDate
