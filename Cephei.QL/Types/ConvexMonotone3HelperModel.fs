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
type ConvexMonotone3HelperModel
    ( xPrev                                        : ICell<double>
    , xNext                                        : ICell<double>
    , gPrev                                        : ICell<double>
    , gNext                                        : ICell<double>
    , fAverage                                     : ICell<double>
    , eta3                                         : ICell<double>
    , prevPrimitive                                : ICell<double>
    ) as this =

    inherit Model<ConvexMonotone3Helper> ()
(*
    Parameters
*)
    let _xPrev                                     = xPrev
    let _xNext                                     = xNext
    let _gPrev                                     = gPrev
    let _gNext                                     = gNext
    let _fAverage                                  = fAverage
    let _eta3                                      = eta3
    let _prevPrimitive                             = prevPrimitive
(*
    Functions
*)
    let _ConvexMonotone3Helper                     = cell (fun () -> new ConvexMonotone3Helper (xPrev.Value, xNext.Value, gPrev.Value, gNext.Value, fAverage.Value, eta3.Value, prevPrimitive.Value))
    let _fNext                                     = triv (fun () -> _ConvexMonotone3Helper.Value.fNext())
    let _primitive                                 (x : ICell<double>)   
                                                   = triv (fun () -> _ConvexMonotone3Helper.Value.primitive(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = triv (fun () -> _ConvexMonotone3Helper.Value.value(x.Value))
    do this.Bind(_ConvexMonotone3Helper)
(* 
    casting 
*)
    internal new () = new ConvexMonotone3HelperModel(null,null,null,null,null,null,null)
    member internal this.Inject v = _ConvexMonotone3Helper.Value <- v
    static member Cast (p : ICell<ConvexMonotone3Helper>) = 
        if p :? ConvexMonotone3HelperModel then 
            p :?> ConvexMonotone3HelperModel
        else
            let o = new ConvexMonotone3HelperModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.xPrev                              = _xPrev 
    member this.xNext                              = _xNext 
    member this.gPrev                              = _gPrev 
    member this.gNext                              = _gNext 
    member this.fAverage                           = _fAverage 
    member this.eta3                               = _eta3 
    member this.prevPrimitive                      = _prevPrimitive 
    member this.FNext                              = _fNext
    member this.Primitive                          x   
                                                   = _primitive x 
    member this.Value                              x   
                                                   = _value x 
