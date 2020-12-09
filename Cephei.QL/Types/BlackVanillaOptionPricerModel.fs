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
===========================================================================// BlackVanillaOptionPricer                         // ===========================================================================

  </summary> *)
[<AutoSerializable(true)>]
type BlackVanillaOptionPricerModel
    ( forwardValue                                 : ICell<double>
    , expiryDate                                   : ICell<Date>
    , swapTenor                                    : ICell<Period>
    , volatilityStructure                          : ICell<SwaptionVolatilityStructure>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BlackVanillaOptionPricer> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _forwardValue                              = forwardValue
    let _expiryDate                                = expiryDate
    let _swapTenor                                 = swapTenor
    let _volatilityStructure                       = volatilityStructure
(*
    Functions
*)
    let mutable
        _BlackVanillaOptionPricer                  = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BlackVanillaOptionPricer (forwardValue.Value, expiryDate.Value, swapTenor.Value, volatilityStructure.Value))))
    let _value                                     (strike : ICell<double>) (optionType : ICell<Option.Type>) (deflator : ICell<double>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _BlackVanillaOptionPricer).Value.value(strike.Value, optionType.Value, deflator.Value))
    do this.Bind(_BlackVanillaOptionPricer)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BlackVanillaOptionPricerModel(null,null,null,null,null)
    member internal this.Inject v = _BlackVanillaOptionPricer <- v
    static member Cast (p : ICell<BlackVanillaOptionPricer>) = 
        if p :? BlackVanillaOptionPricerModel then 
            p :?> BlackVanillaOptionPricerModel
        else
            let o = new BlackVanillaOptionPricerModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.forwardValue                       = _forwardValue 
    member this.expiryDate                         = _expiryDate 
    member this.swapTenor                          = _swapTenor 
    member this.volatilityStructure                = _volatilityStructure 
    member this.Value                              strike optionType deflator   
                                                   = _value strike optionType deflator 
