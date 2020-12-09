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
    let mutable
        _evaluationDate                            = evaluationDate
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
===========================================================================// ConundrumIntegrand                           // ===========================================================================

  </summary> *)
[<AutoSerializable(true)>]
type ConundrumIntegrandModel
    ( o                                            : ICell<VanillaOptionPricer>
    , curve                                        : ICell<YieldTermStructure>
    , gFunction                                    : ICell<GFunction>
    , fixingDate                                   : ICell<Date>
    , paymentDate                                  : ICell<Date>
    , annuity                                      : ICell<double>
    , forwardValue                                 : ICell<double>
    , strike                                       : ICell<double>
    , optionType                                   : ICell<Option.Type>
    ( evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<ConundrumIntegrand> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _o                                         = o
    let _curve                                     = curve
    let _gFunction                                 = gFunction
    let _fixingDate                                = fixingDate
    let _paymentDate                               = paymentDate
    let _annuity                                   = annuity
    let _forwardValue                              = forwardValue
    let _strike                                    = strike
    let _optionType                                = optionType
(*
    Functions
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let mutable
        _ConundrumIntegrand                        = cell (fun () -> (withEvaluationDate _evaluationDate new ConundrumIntegrand (o.Value, curve.Value, gFunction.Value, fixingDate.Value, paymentDate.Value, annuity.Value, forwardValue.Value, strike.Value, optionType.Value)))
    let _firstDerivativeOfF                        (x : ICell<double>)   
                                                   = cell (fun () -> _ConundrumIntegrand.Value.firstDerivativeOfF(x.Value))
    let _secondDerivativeOfF                       (x : ICell<double>)   
                                                   = cell (fun () -> _ConundrumIntegrand.Value.secondDerivativeOfF(x.Value))
    let _value                                     (x : ICell<double>)   
                                                   = cell (fun () -> _ConundrumIntegrand.Value.value(x.Value))
    do this.Bind(_ConundrumIntegrand)
(* 
    casting 
*)
    let mutable
        _evaluationDate                            = evaluationDate
   interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
    internal new () = ConundrumIntegrandModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _ConundrumIntegrand <- v
    static member Cast (p : ICell<ConundrumIntegrand>) = 
        if p :? ConundrumIntegrandModel then 
            p :?> ConundrumIntegrandModel
        else
            let o = new ConundrumIntegrandModel ()
            o.Inject p\m            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            
(* 
    casting 
*)
    let mutable
        _evaluationDate                            = evaluationDate
   interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d
    internal new () = ConundrumIntegrandModel(null,null,null,null,null,null,null,null,null)
    static member Cast (p : ICell<ConundrumIntegrand>) = 
        if p :? ConundrumIntegrandModel then 
            p :?> ConundrumIntegrandModel
        else
            let o = new ConundrumIntegrandModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    let mutable
        _evaluationDate                            = evaluationDate
    member this.o                                  = _o 
    member this.curve                              = _curve 
    member this.gFunction                          = _gFunction 
    member this.fixingDate                         = _fixingDate 
    member this.paymentDate                        = _paymentDate 
    member this.annuity                            = _annuity 
    member this.forwardValue                       = _forwardValue 
    member this.strike                             = _strike 
    member this.optionType                         = _optionType 
    member this.FirstDerivativeOfF                 x   
                                                   = _firstDerivativeOfF x 
    member this.SecondDerivativeOfF                x   
                                                   = _secondDerivativeOfF x 
    member this.Value                              x   
                                                   = _value x 
