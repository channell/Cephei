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
type DigitalNotionalRiskModel
    ( paymentOffset                                : ICell<EventPaymentOffset>
    , threshold                                    : ICell<double>
    ) as this =

    inherit Model<DigitalNotionalRisk> ()
(*
    Parameters
*)
    let _paymentOffset                             = paymentOffset
    let _threshold                                 = threshold
(*
    Functions
*)
    let mutable
        _DigitalNotionalRisk                       = make (fun () -> new DigitalNotionalRisk (paymentOffset.Value, threshold.Value))
    let _updatePath                                (events : ICell<Generic.List<KeyValuePair<Date,double>>>) (path : ICell<NotionalPath>)   
                                                   = triv _DigitalNotionalRisk (fun () -> _DigitalNotionalRisk.Value.updatePath(events.Value, path.Value)
                                                                                          _DigitalNotionalRisk.Value)
    do this.Bind(_DigitalNotionalRisk)
(* 
    casting 
*)
    internal new () = new DigitalNotionalRiskModel(null,null)
    member internal this.Inject v = _DigitalNotionalRisk <- v
    static member Cast (p : ICell<DigitalNotionalRisk>) = 
        if p :? DigitalNotionalRiskModel then 
            p :?> DigitalNotionalRiskModel
        else
            let o = new DigitalNotionalRiskModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.paymentOffset                      = _paymentOffset 
    member this.threshold                          = _threshold 
    member this.UpdatePath                         events path   
                                                   = _updatePath events path 
