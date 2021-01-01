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
type BachelierSwaptionEngineModel
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<double>
    , dc                                           : ICell<DayCounter>
    , model                                        : ICell<BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BachelierSwaptionEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
    let _model                                     = model
(*
    Functions
*)
    let mutable
        _BachelierSwaptionEngine                   = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BachelierSwaptionEngine (discountCurve.Value, vol.Value, dc.Value, model.Value))))
    let _termStructure                             = triv _BachelierSwaptionEngine (fun () -> (curryEvaluationDate _evaluationDate _BachelierSwaptionEngine).Value.termStructure())
    let _volatility                                = triv _BachelierSwaptionEngine (fun () -> (curryEvaluationDate _evaluationDate _BachelierSwaptionEngine).Value.volatility())
    do this.Bind(_BachelierSwaptionEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BachelierSwaptionEngineModel(null,null,null,null,null)
    member internal this.Inject v = _BachelierSwaptionEngine <- v
    static member Cast (p : ICell<BachelierSwaptionEngine>) = 
        if p :? BachelierSwaptionEngineModel then 
            p :?> BachelierSwaptionEngineModel
        else
            let o = new BachelierSwaptionEngineModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.model                              = _model 
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BachelierSwaptionEngineModel1
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<SwaptionVolatilityStructure>>
    , model                                        : ICell<BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BachelierSwaptionEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _model                                     = model
(*
    Functions
*)
    let mutable
        _BachelierSwaptionEngine                   = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BachelierSwaptionEngine (discountCurve.Value, vol.Value, model.Value))))
    let _termStructure                             = triv _BachelierSwaptionEngine (fun () -> (curryEvaluationDate _evaluationDate _BachelierSwaptionEngine).Value.termStructure())
    let _volatility                                = triv _BachelierSwaptionEngine (fun () -> (curryEvaluationDate _evaluationDate _BachelierSwaptionEngine).Value.volatility())
    do this.Bind(_BachelierSwaptionEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BachelierSwaptionEngineModel1(null,null,null,null)
    member internal this.Inject v = _BachelierSwaptionEngine <- v
    static member Cast (p : ICell<BachelierSwaptionEngine>) = 
        if p :? BachelierSwaptionEngineModel1 then 
            p :?> BachelierSwaptionEngineModel1
        else
            let o = new BachelierSwaptionEngineModel1 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.model                              = _model 
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type BachelierSwaptionEngineModel2
    ( discountCurve                                : ICell<Handle<YieldTermStructure>>
    , vol                                          : ICell<Handle<Quote>>
    , dc                                           : ICell<DayCounter>
    , model                                        : ICell<BlackStyleSwaptionEngine<BachelierSpec>.CashAnnuityModel>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<BachelierSwaptionEngine> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _discountCurve                             = discountCurve
    let _vol                                       = vol
    let _dc                                        = dc
    let _model                                     = model
(*
    Functions
*)
    let mutable
        _BachelierSwaptionEngine                   = make (fun () -> (createEvaluationDate _evaluationDate (fun () ->new BachelierSwaptionEngine (discountCurve.Value, vol.Value, dc.Value, model.Value))))
    let _termStructure                             = triv _BachelierSwaptionEngine (fun () -> (curryEvaluationDate _evaluationDate _BachelierSwaptionEngine).Value.termStructure())
    let _volatility                                = triv _BachelierSwaptionEngine (fun () -> (curryEvaluationDate _evaluationDate _BachelierSwaptionEngine).Value.volatility())
    do this.Bind(_BachelierSwaptionEngine)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new BachelierSwaptionEngineModel2(null,null,null,null,null)
    member internal this.Inject v = _BachelierSwaptionEngine <- v
    static member Cast (p : ICell<BachelierSwaptionEngine>) = 
        if p :? BachelierSwaptionEngineModel2 then 
            p :?> BachelierSwaptionEngineModel2
        else
            let o = new BachelierSwaptionEngineModel2 ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.discountCurve                      = _discountCurve 
    member this.vol                                = _vol 
    member this.dc                                 = _dc 
    member this.model                              = _model 
    member this.TermStructure                      = _termStructure
    member this.Volatility                         = _volatility
