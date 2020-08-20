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
type SVIWrapperModel
    ( t                                            : ICell<double>
    , forward                                      : ICell<double>
    , param                                        : ICell<List<Nullable<double>>>
    , addParams                                    : ICell<List<Nullable<double>>>
    ) as this =

    inherit Model<SVIWrapper> ()
(*
    Parameters
*)
    let _t                                         = t
    let _forward                                   = forward
    let _param                                     = param
    let _addParams                                 = addParams
(*
    Functions
*)
    let _SVIWrapper                                = cell (fun () -> new SVIWrapper (t.Value, forward.Value, param.Value, addParams.Value))
    let _volatility                                (x : ICell<double>)   
                                                   = cell (fun () -> _SVIWrapper.Value.volatility(x.Value))
    do this.Bind(_SVIWrapper)

(* 
    Externally visible/bindable properties
*)
    member this.t                                  = _t 
    member this.forward                            = _forward 
    member this.param                              = _param 
    member this.addParams                          = _addParams 
    member this.Volatility                         x   
                                                   = _volatility x 
