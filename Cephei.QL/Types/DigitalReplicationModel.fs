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
type DigitalReplicationModel
    ( t                                            : ICell<Replication.Type>
    , gap                                          : ICell<double>
    ) as this =

    inherit Model<DigitalReplication> ()
(*
    Parameters
*)
    let _t                                         = t
    let _gap                                       = gap
(*
    Functions
*)
    let mutable
        _DigitalReplication                        = cell (fun () -> new DigitalReplication (t.Value, gap.Value))
    let _gap                                       = triv (fun () -> _DigitalReplication.Value.gap())
    let _replicationType                           = triv (fun () -> _DigitalReplication.Value.replicationType())
    do this.Bind(_DigitalReplication)
(* 
    casting 
*)
    internal new () = new DigitalReplicationModel(null,null)
    member internal this.Inject v = _DigitalReplication <- v
    static member Cast (p : ICell<DigitalReplication>) = 
        if p :? DigitalReplicationModel then 
            p :?> DigitalReplicationModel
        else
            let o = new DigitalReplicationModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.t                                  = _t 
    member this.gap                                = _gap 
    member this.Gap                                = _gap
    member this.ReplicationType                    = _replicationType
