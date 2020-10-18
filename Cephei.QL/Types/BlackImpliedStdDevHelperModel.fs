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
type BlackImpliedStdDevHelperModel
    ( optionType                                   : ICell<Option.Type>
    , strike                                       : ICell<double>
    , forward                                      : ICell<double>
    , undiscountedBlackPrice                       : ICell<double>
    , displacement                                 : ICell<double>
    ) as this =

    inherit Model<BlackImpliedStdDevHelper> ()
(*
    Parameters
*)
    let _optionType                                = optionType
    let _strike                                    = strike
    let _forward                                   = forward
    let _undiscountedBlackPrice                    = undiscountedBlackPrice
    let _displacement                              = displacement
(*
    Functions
*)
    let mutable
        _BlackImpliedStdDevHelper                  = cell (fun () -> new BlackImpliedStdDevHelper (optionType.Value, strike.Value, forward.Value, undiscountedBlackPrice.Value, displacement.Value))
    let _derivative                                (stdDev : ICell<double>)   
                                                   = cell (fun () -> _BlackImpliedStdDevHelper.Value.derivative(stdDev.Value))
    let _value                                     (stdDev : ICell<double>)   
                                                   = cell (fun () -> _BlackImpliedStdDevHelper.Value.value(stdDev.Value))
    do this.Bind(_BlackImpliedStdDevHelper)
(* 
    casting 
*)
    internal new () = BlackImpliedStdDevHelperModel(null,null,null,null,null)
    member internal this.Inject v = _BlackImpliedStdDevHelper <- v
    static member Cast (p : ICell<BlackImpliedStdDevHelper>) = 
        if p :? BlackImpliedStdDevHelperModel then 
            p :?> BlackImpliedStdDevHelperModel
        else
            let o = new BlackImpliedStdDevHelperModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = BlackImpliedStdDevHelperModel(null,null,null,null,null)
    static member Cast (p : ICell<BlackImpliedStdDevHelper>) = 
        if p :? BlackImpliedStdDevHelperModel then 
            p :?> BlackImpliedStdDevHelperModel
        else
            let o = new BlackImpliedStdDevHelperModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.optionType                         = _optionType 
    member this.strike                             = _strike 
    member this.forward                            = _forward 
    member this.undiscountedBlackPrice             = _undiscountedBlackPrice 
    member this.displacement                       = _displacement 
    member this.Derivative                         stdDev   
                                                   = _derivative stdDev 
    member this.Value                              stdDev   
                                                   = _value stdDev 
