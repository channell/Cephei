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
  Callable zero coupon bond, where the embedded (European) option price is assumed to obey the Black formula. Follows "European bond option" treatment in Hull, Fourth Edition, Chapter 20.  This class has yet to be tested.  callablebondengines
! volatility is the quoted fwd yield volatility, not price vol
  </summary> *)
[<AutoSerializable(true)>]
type BlackCallableZeroCouponBondEngineModel
    ( yieldVolStructure                            : ICell<Handle<CallableBondVolatilityStructure>>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BlackCallableZeroCouponBondEngine> ()
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
        _BlackCallableZeroCouponBondEngine         = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BlackCallableZeroCouponBondEngine (yieldVolStructure.Value, discountCurve.Value))))
    do this.Bind(_BlackCallableZeroCouponBondEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BlackCallableZeroCouponBondEngineModel(null,null,null)
    member internal this.Inject v = _BlackCallableZeroCouponBondEngine <- v
    static member Cast (p : ICell<BlackCallableZeroCouponBondEngine>) = 
        if p :? BlackCallableZeroCouponBondEngineModel then 
            p :?> BlackCallableZeroCouponBondEngineModel
        else
            let o = new BlackCallableZeroCouponBondEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.yieldVolStructure                  = _yieldVolStructure 
    member this.discountCurve                      = _discountCurve 
(* <summary>
  Callable zero coupon bond, where the embedded (European) option price is assumed to obey the Black formula. Follows "European bond option" treatment in Hull, Fourth Edition, Chapter 20.  This class has yet to be tested.  callablebondengines
! volatility is the quoted fwd yield volatility, not price vol
  </summary> *)
[<AutoSerializable(true)>]
type BlackCallableZeroCouponBondEngineModel1
    ( fwdYieldVol                                  : ICell<Handle<Quote>>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BlackCallableZeroCouponBondEngine> ()
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
        _BlackCallableZeroCouponBondEngine         = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BlackCallableZeroCouponBondEngine (fwdYieldVol.Value, discountCurve.Value))))
    do this.Bind(_BlackCallableZeroCouponBondEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BlackCallableZeroCouponBondEngineModel1(null,null,null)
    member internal this.Inject v = _BlackCallableZeroCouponBondEngine <- v
    static member Cast (p : ICell<BlackCallableZeroCouponBondEngine>) = 
        if p :? BlackCallableZeroCouponBondEngineModel1 then 
            p :?> BlackCallableZeroCouponBondEngineModel1
        else
            let o = new BlackCallableZeroCouponBondEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.fwdYieldVol                        = _fwdYieldVol 
    member this.discountCurve                      = _discountCurve 
