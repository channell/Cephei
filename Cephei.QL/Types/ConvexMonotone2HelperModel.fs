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
type ConvexMonotone2HelperModel
    ( xPrev                                        : ICell<double>
    , xNext                                        : ICell<double>
    , gPrev                                        : ICell<double>
    , gNext                                        : ICell<double>
    , fAverage                                     : ICell<double>
    , eta2                                         : ICell<double>
    , prevPrimitive                                : ICell<double>
    ) as this =

    inherit Model<ConvexMonotone2Helper> ()
(*
    Parameters
*)
    let _xPrev                                     = xPrev
    let _xNext                                     = xNext
    let _gPrev                                     = gPrev
    let _gNext                                     = gNext
    let _fAverage                                  = fAverage
    let _eta2                                      = eta2
    let _prevPrimitive                             = prevPrimitive
(*
    Functions
*)
    let mutable
        _ConvexMonotone2Helper                     = cell (fun () -> new ConvexMonotone2Helper (xPrev.Value, xNext.Value, gPrev.Value, gNext.Value, fAverage.Value, eta2.Value, prevPrimitive.Value))
    let _fNext                                     = triv (fun () -> _ConvexMonotone2Helper.Value.fNext())
    let _primitive                                 (x : ICell<double>)   
                                                   = triv (fun () -> _ConvexMonotone2Helper.Value.primitive(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _ConvexMonotone2Helper.Value.value(x.Value))
    do this.Bind(_ConvexMonotone2Helper)
(* 
    casting 
*)
    internal new () = new ConvexMonotone2HelperModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _ConvexMonotone2Helper <- v
    static member Cast (p : ICell<ConvexMonotone2Helper>) = 
        if p :? ConvexMonotone2HelperModel then 
            p :?> ConvexMonotone2HelperModel
        else
            let o = new ConvexMonotone2HelperModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xPrev                              = _xPrev 
    member this.xNext                              = _xNext 
    member this.gPrev                              = _gPrev 
    member this.gNext                              = _gNext 
    member this.fAverage                           = _fAverage 
    member this.eta2                               = _eta2 
    member this.prevPrimitive                      = _prevPrimitive 
    member this.FNext                              = _fNext
    member this.Primitive                          x   
                                                   = _primitive x 
    member this.Value                              x   
                                                   = _value x 
