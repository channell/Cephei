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
type EverywhereConstantHelperModel
    ( value                                        : ICell<double>
    , prevPrimitive                                : ICell<double>
    , xPrev                                        : ICell<double>
    ) as this =

    inherit Model<EverywhereConstantHelper> ()
(*
    Parameters
*)
    let _value                                     = value
    let _prevPrimitive                             = prevPrimitive
    let _xPrev                                     = xPrev
(*
    Functions
*)
    let _EverywhereConstantHelper                  = cell (fun () -> new EverywhereConstantHelper (value.Value, prevPrimitive.Value, xPrev.Value))
    let _fNext                                     = cell (fun () -> _EverywhereConstantHelper.Value.fNext())
    let _primitive                                 (x : ICell<double>)   
                                                   = cell (fun () -> _EverywhereConstantHelper.Value.primitive(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _EverywhereConstantHelper.Value.value(x.Value))
    do this.Bind(_EverywhereConstantHelper)

(* 
    Externally visible/bindable properties
*)
    member this.value                              = _value 
    member this.prevPrimitive                      = _prevPrimitive 
    member this.xPrev                              = _xPrev 
    member this.FNext                              = _fNext
    member this.Primitive                          x   
                                                   = _primitive x 
    member this.Value                              x   
                                                   = _value x 
