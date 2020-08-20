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
type QuadraticMinHelperModel
    ( xPrev                                        : ICell<double>
    , xNext                                        : ICell<double>
    , fPrev                                        : ICell<double>
    , fNext                                        : ICell<double>
    , fAverage                                     : ICell<double>
    , prevPrimitive                                : ICell<double>
    ) as this =

    inherit Model<QuadraticMinHelper> ()
(*
    Parameters
*)
    let _xPrev                                     = xPrev
    let _xNext                                     = xNext
    let _fPrev                                     = fPrev
    let _fNext                                     = fNext
    let _fAverage                                  = fAverage
    let _prevPrimitive                             = prevPrimitive
(*
    Functions
*)
    let _QuadraticMinHelper                        = cell (fun () -> new QuadraticMinHelper (xPrev.Value, xNext.Value, fPrev.Value, fNext.Value, fAverage.Value, prevPrimitive.Value))
    let _fNext                                     = cell (fun () -> _QuadraticMinHelper.Value.fNext())
    let _primitive                                 (x : ICell<double>)   
                                                   = cell (fun () -> _QuadraticMinHelper.Value.primitive(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _QuadraticMinHelper.Value.value(x.Value))
    do this.Bind(_QuadraticMinHelper)

(* 
    Externally visible/bindable properties
*)
    member this.xPrev                              = _xPrev 
    member this.xNext                              = _xNext 
    member this.fPrev                              = _fPrev 
    member this.fNext                              = _fNext 
    member this.fAverage                           = _fAverage 
    member this.prevPrimitive                      = _prevPrimitive 
    member this.FNext                              = _fNext
    member this.Primitive                          x   
                                                   = _primitive x 
    member this.Value                              x   
                                                   = _value x 
