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
type NotionalPathModel
    () as this =
    inherit Model<NotionalPath> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _NotionalPath                              = cell (fun () -> new NotionalPath ())
    let _addReduction                              (date : ICell<Date>) (newRate : ICell<double>)   
                                                   = cell (fun () -> _NotionalPath.Value.addReduction(date.Value, newRate.Value)
                                                                     _NotionalPath.Value)
    let _loss                                      = cell (fun () -> _NotionalPath.Value.loss())
    let _notionalRate                              (date : ICell<Date>)   
                                                   = cell (fun () -> _NotionalPath.Value.notionalRate(date.Value))
    let _reset                                     = cell (fun () -> _NotionalPath.Value.reset()
                                                                     _NotionalPath.Value)
    do this.Bind(_NotionalPath)

(* 
    Externally visible/bindable properties
*)
    member this.AddReduction                       date newRate   
                                                   = _addReduction date newRate 
    member this.Loss                               = _loss
    member this.NotionalRate                       date   
                                                   = _notionalRate date 
    member this.Reset                              = _reset
