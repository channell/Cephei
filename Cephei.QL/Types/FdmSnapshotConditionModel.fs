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
type FdmSnapshotConditionModel
    ( t                                            : ICell<double>
    ) as this =

    inherit Model<FdmSnapshotCondition> ()
(*
    Parameters
*)
    let _t                                         = t
(*
    Functions
*)
    let mutable
        _FdmSnapshotCondition                      = make (fun () -> new FdmSnapshotCondition (t.Value))
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv _FdmSnapshotCondition (fun () -> _FdmSnapshotCondition.Value.applyTo(o.Value, t.Value)
                                                                                           _FdmSnapshotCondition.Value)
    let _getTime                                   = triv _FdmSnapshotCondition (fun () -> _FdmSnapshotCondition.Value.getTime())
    let _getValues                                 = triv _FdmSnapshotCondition (fun () -> _FdmSnapshotCondition.Value.getValues())
    do this.Bind(_FdmSnapshotCondition)
(* 
    casting 
*)
    internal new () = new FdmSnapshotConditionModel(null)
    member internal this.Inject v = _FdmSnapshotCondition <- v
    static member Cast (p : ICell<FdmSnapshotCondition>) = 
        if p :? FdmSnapshotConditionModel then 
            p :?> FdmSnapshotConditionModel
        else
            let o = new FdmSnapshotConditionModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.t                                  = _t 
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
    member this.GetTime                            = _getTime
    member this.GetValues                          = _getValues
