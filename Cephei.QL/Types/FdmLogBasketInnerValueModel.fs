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
type FdmLogBasketInnerValueModel
    ( payoff                                       : ICell<BasketPayoff>
    , mesher                                       : ICell<FdmMesher>
    ) as this =

    inherit Model<FdmLogBasketInnerValue> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _mesher                                    = mesher
(*
    Functions
*)
    let _FdmLogBasketInnerValue                    = cell (fun () -> new FdmLogBasketInnerValue (payoff.Value, mesher.Value))
    let _avgInnerValue                             (iter : ICell<FdmLinearOpIterator>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmLogBasketInnerValue.Value.avgInnerValue(iter.Value, t.Value))
    let _innerValue                                (iter : ICell<FdmLinearOpIterator>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmLogBasketInnerValue.Value.innerValue(iter.Value, t.Value))
    do this.Bind(_FdmLogBasketInnerValue)

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.mesher                             = _mesher 
    member this.AvgInnerValue                      iter t   
                                                   = _avgInnerValue iter t 
    member this.InnerValue                         iter t   
                                                   = _innerValue iter t 
