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
  Callable fixed rate bond Black engine. The embedded (European) option follows the Black "European bond option" treatment in Hull, Fourth Edition, Chapter 20.  set additionalResults (e.g. vega, fairStrike, etc.)  This class has yet to be tested  callablebondengines
! volatility is the quoted fwd yield volatility, not price vol
  </summary> *)
[<AutoSerializable(true)>]
type BlackCallableFixedRateBondEngineModel
    ( fwdYieldVol                                  : ICell<Handle<Quote>>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BlackCallableFixedRateBondEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _fwdYieldVol                               = fwdYieldVol
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let mutable
        _BlackCallableFixedRateBondEngine          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BlackCallableFixedRateBondEngine (fwdYieldVol.Value, discountCurve.Value))))
    do this.Bind(_BlackCallableFixedRateBondEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BlackCallableFixedRateBondEngineModel(null,null,null)
    member internal this.Inject v = _BlackCallableFixedRateBondEngine <- v
    static member Cast (p : ICell<BlackCallableFixedRateBondEngine>) = 
        if p :? BlackCallableFixedRateBondEngineModel then 
            p :?> BlackCallableFixedRateBondEngineModel
        else
            let o = new BlackCallableFixedRateBondEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.fwdYieldVol                        = _fwdYieldVol 
    member this.discountCurve                      = _discountCurve 
(* <summary>
  Callable fixed rate bond Black engine. The embedded (European) option follows the Black "European bond option" treatment in Hull, Fourth Edition, Chapter 20.  set additionalResults (e.g. vega, fairStrike, etc.)  This class has yet to be tested  callablebondengines
! volatility is the quoted fwd yield volatility, not price vol
  </summary> *)
[<AutoSerializable(true)>]
type BlackCallableFixedRateBondEngineModel1
    ( yieldVolStructure                            : ICell<Handle<CallableBondVolatilityStructure>>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BlackCallableFixedRateBondEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _yieldVolStructure                         = yieldVolStructure
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let mutable
        _BlackCallableFixedRateBondEngine          = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BlackCallableFixedRateBondEngine (yieldVolStructure.Value, discountCurve.Value))))
    do this.Bind(_BlackCallableFixedRateBondEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BlackCallableFixedRateBondEngineModel1(null,null,null)
    member internal this.Inject v = _BlackCallableFixedRateBondEngine <- v
    static member Cast (p : ICell<BlackCallableFixedRateBondEngine>) = 
        if p :? BlackCallableFixedRateBondEngineModel1 then 
            p :?> BlackCallableFixedRateBondEngineModel1
        else
            let o = new BlackCallableFixedRateBondEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.yieldVolStructure                  = _yieldVolStructure 
    member this.discountCurve                      = _discountCurve 
