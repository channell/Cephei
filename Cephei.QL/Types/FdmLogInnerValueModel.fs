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
type FdmLogInnerValueModel
    ( payoff                                       : ICell<Payoff>
    , mesher                                       : ICell<FdmMesher>
    , direction                                    : ICell<int>
    ) as this =

    inherit Model<FdmLogInnerValue> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _mesher                                    = mesher
    let _direction                                 = direction
(*
    Functions
*)
    let _FdmLogInnerValue                          = cell (fun () -> new FdmLogInnerValue (payoff.Value, mesher.Value, direction.Value))
    let _avgInnerValue                             (iter : ICell<FdmLinearOpIterator>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmLogInnerValue.Value.avgInnerValue(iter.Value, t.Value))
    let _innerValue                                (iter : ICell<FdmLinearOpIterator>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmLogInnerValue.Value.innerValue(iter.Value, t.Value))
    do this.Bind(_FdmLogInnerValue)
(* 
    casting 
*)
    internal new () = FdmLogInnerValueModel(null,null,null)
    member internal this.Inject v = _FdmLogInnerValue.Value <- v
    static member Cast (p : ICell<FdmLogInnerValue>) = 
        if p :? FdmLogInnerValueModel then 
            p :?> FdmLogInnerValueModel
        else
            let o = new FdmLogInnerValueModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.mesher                             = _mesher 
    member this.direction                          = _direction 
    member this.AvgInnerValue                      iter t   
                                                   = _avgInnerValue iter t 
    member this.InnerValue                         iter t   
                                                   = _innerValue iter t 
