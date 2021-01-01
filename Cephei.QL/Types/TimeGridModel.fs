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
type TimeGridModel
    ( End                                          : ICell<double>
    , steps                                        : ICell<int>
    ) as this =

    inherit Model<TimeGrid> ()
(*
    Parameters
*)
    let _End                                       = End
    let _steps                                     = steps
(*
    Functions
*)
    let mutable
        _TimeGrid                                  = make (fun () -> new TimeGrid (End.Value, steps.Value))
    let _closestIndex                              (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestIndex(t.Value))
    let _closestTime                               (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestTime(t.Value))
    let _dt                                        (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.dt(i.Value))
    let _empty                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.empty())
    let _First                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.First())
    let _index                                     (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.index(t.Value))
    let _Last                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.Last())
    let _mandatoryTimes                            = triv _TimeGrid (fun () -> _TimeGrid.Value.mandatoryTimes())
    let _size                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.size())
    let _this                                      (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.[i.Value])
    let _Times                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.Times())
    do this.Bind(_TimeGrid)
(* 
    casting 
*)
    internal new () = new TimeGridModel(null,null)
    member internal this.Inject v = _TimeGrid <- v
    static member Cast (p : ICell<TimeGrid>) = 
        if p :? TimeGridModel then 
            p :?> TimeGridModel
        else
            let o = new TimeGridModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.End                                = _End 
    member this.steps                              = _steps 
    member this.ClosestIndex                       t   
                                                   = _closestIndex t 
    member this.ClosestTime                        t   
                                                   = _closestTime t 
    member this.Dt                                 i   
                                                   = _dt i 
    member this.Empty                              = _empty
    member this.First                              = _First
    member this.Index                              t   
                                                   = _index t 
    member this.Last                               = _Last
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Size                               = _size
    member this.This                               i   
                                                   = _this i 
    member this.Times                              = _Times
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type TimeGridModel1
    ( times                                        : ICell<Generic.List<double>>
    ) as this =

    inherit Model<TimeGrid> ()
(*
    Parameters
*)
    let _times                                     = times
(*
    Functions
*)
    let mutable
        _TimeGrid                                  = make (fun () -> new TimeGrid (times.Value))
    let _closestIndex                              (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestIndex(t.Value))
    let _closestTime                               (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestTime(t.Value))
    let _dt                                        (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.dt(i.Value))
    let _empty                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.empty())
    let _First                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.First())
    let _index                                     (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.index(t.Value))
    let _Last                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.Last())
    let _mandatoryTimes                            = triv _TimeGrid (fun () -> _TimeGrid.Value.mandatoryTimes())
    let _size                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.size())
    let _this                                      (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.[i.Value])
    let _Times                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.Times())
    do this.Bind(_TimeGrid)
(* 
    casting 
*)
    internal new () = new TimeGridModel1(null)
    member internal this.Inject v = _TimeGrid <- v
    static member Cast (p : ICell<TimeGrid>) = 
        if p :? TimeGridModel1 then 
            p :?> TimeGridModel1
        else
            let o = new TimeGridModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.times                              = _times 
    member this.ClosestIndex                       t   
                                                   = _closestIndex t 
    member this.ClosestTime                        t   
                                                   = _closestTime t 
    member this.Dt                                 i   
                                                   = _dt i 
    member this.Empty                              = _empty
    member this.First                              = _First
    member this.Index                              t   
                                                   = _index t 
    member this.Last                               = _Last
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Size                               = _size
    member this.This                               i   
                                                   = _this i 
    member this.Times                              = _Times
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type TimeGridModel2
    ( times                                        : ICell<Generic.List<double>>
    , steps                                        : ICell<int>
    ) as this =

    inherit Model<TimeGrid> ()
(*
    Parameters
*)
    let _times                                     = times
    let _steps                                     = steps
(*
    Functions
*)
    let mutable
        _TimeGrid                                  = make (fun () -> new TimeGrid (times.Value, steps.Value))
    let _closestIndex                              (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestIndex(t.Value))
    let _closestTime                               (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestTime(t.Value))
    let _dt                                        (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.dt(i.Value))
    let _empty                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.empty())
    let _First                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.First())
    let _index                                     (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.index(t.Value))
    let _Last                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.Last())
    let _mandatoryTimes                            = triv _TimeGrid (fun () -> _TimeGrid.Value.mandatoryTimes())
    let _size                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.size())
    let _this                                      (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.[i.Value])
    let _Times                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.Times())
    do this.Bind(_TimeGrid)
(* 
    casting 
*)
    internal new () = new TimeGridModel2(null,null)
    member internal this.Inject v = _TimeGrid <- v
    static member Cast (p : ICell<TimeGrid>) = 
        if p :? TimeGridModel2 then 
            p :?> TimeGridModel2
        else
            let o = new TimeGridModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.times                              = _times 
    member this.steps                              = _steps 
    member this.ClosestIndex                       t   
                                                   = _closestIndex t 
    member this.ClosestTime                        t   
                                                   = _closestTime t 
    member this.Dt                                 i   
                                                   = _dt i 
    member this.Empty                              = _empty
    member this.First                              = _First
    member this.Index                              t   
                                                   = _index t 
    member this.Last                               = _Last
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Size                               = _size
    member this.This                               i   
                                                   = _this i 
    member this.Times                              = _Times
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type TimeGridModel3
    ( times                                        : ICell<Generic.List<double>>
    , offset                                       : ICell<int>
    , steps                                        : ICell<int>
    ) as this =

    inherit Model<TimeGrid> ()
(*
    Parameters
*)
    let _times                                     = times
    let _offset                                    = offset
    let _steps                                     = steps
(*
    Functions
*)
    let mutable
        _TimeGrid                                  = make (fun () -> new TimeGrid (times.Value, offset.Value, steps.Value))
    let _closestIndex                              (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestIndex(t.Value))
    let _closestTime                               (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.closestTime(t.Value))
    let _dt                                        (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.dt(i.Value))
    let _empty                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.empty())
    let _First                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.First())
    let _index                                     (t : ICell<double>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.index(t.Value))
    let _Last                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.Last())
    let _mandatoryTimes                            = triv _TimeGrid (fun () -> _TimeGrid.Value.mandatoryTimes())
    let _size                                      = triv _TimeGrid (fun () -> _TimeGrid.Value.size())
    let _this                                      (i : ICell<int>)   
                                                   = triv _TimeGrid (fun () -> _TimeGrid.Value.[i.Value])
    let _Times                                     = triv _TimeGrid (fun () -> _TimeGrid.Value.Times())
    do this.Bind(_TimeGrid)
(* 
    casting 
*)
    internal new () = new TimeGridModel3(null,null,null)
    member internal this.Inject v = _TimeGrid <- v
    static member Cast (p : ICell<TimeGrid>) = 
        if p :? TimeGridModel3 then 
            p :?> TimeGridModel3
        else
            let o = new TimeGridModel3 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.times                              = _times 
    member this.offset                             = _offset 
    member this.steps                              = _steps 
    member this.ClosestIndex                       t   
                                                   = _closestIndex t 
    member this.ClosestTime                        t   
                                                   = _closestTime t 
    member this.Dt                                 i   
                                                   = _dt i 
    member this.Empty                              = _empty
    member this.First                              = _First
    member this.Index                              t   
                                                   = _index t 
    member this.Last                               = _Last
    member this.MandatoryTimes                     = _mandatoryTimes
    member this.Size                               = _size
    member this.This                               i   
                                                   = _this i 
    member this.Times                              = _Times
