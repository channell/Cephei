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
type ProportionalNotionalRiskModel
    ( paymentOffset                                : ICell<EventPaymentOffset>
    , attachement                                  : ICell<double>
    , exhaustion                                   : ICell<double>
    ) as this =

    inherit Model<ProportionalNotionalRisk> ()
(*
    Parameters
*)
    let _paymentOffset                             = paymentOffset
    let _attachement                               = attachement
    let _exhaustion                                = exhaustion
(*
    Functions
*)
    let _ProportionalNotionalRisk                  = cell (fun () -> new ProportionalNotionalRisk (paymentOffset.Value, attachement.Value, exhaustion.Value))
    let _updatePath                                (events : ICell<Generic.List<KeyValuePair<Date,double>>>) (path : ICell<NotionalPath>)   
                                                   = cell (fun () -> _ProportionalNotionalRisk.Value.updatePath(events.Value, path.Value)
                                                                     _ProportionalNotionalRisk.Value)
    do this.Bind(_ProportionalNotionalRisk)

(* 
    Externally visible/bindable properties
*)
    member this.paymentOffset                      = _paymentOffset 
    member this.attachement                        = _attachement 
    member this.exhaustion                         = _exhaustion 
    member this.UpdatePath                         events path   
                                                   = _updatePath events path 
