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
type FdmAmericanStepConditionModel
    ( mesher                                       : ICell<FdmMesher>
    , calculator                                   : ICell<FdmInnerValueCalculator>
    ) as this =

    inherit Model<FdmAmericanStepCondition> ()
(*
    Parameters
*)
    let _mesher                                    = mesher
    let _calculator                                = calculator
(*
    Functions
*)
    let _FdmAmericanStepCondition                  = cell (fun () -> new FdmAmericanStepCondition (mesher.Value, calculator.Value))
    let _applyTo                                   (o : ICell<Object>) (t : ICell<double>)   
                                                   = triv (fun () -> _FdmAmericanStepCondition.Value.applyTo(o.Value, t.Value)
                                                                     _FdmAmericanStepCondition.Value)
    do this.Bind(_FdmAmericanStepCondition)
(* 
    casting 
*)
    internal new () = FdmAmericanStepConditionModel(null,null)
    member internal this.Inject v = _FdmAmericanStepCondition.Value <- v
    static member Cast (p : ICell<FdmAmericanStepCondition>) = 
        if p :? FdmAmericanStepConditionModel then 
            p :?> FdmAmericanStepConditionModel
        else
            let o = new FdmAmericanStepConditionModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.mesher                             = _mesher 
    member this.calculator                         = _calculator 
    member this.ApplyTo                            o t   
                                                   = _applyTo o t 
