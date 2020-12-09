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
  This cash flow pays a predetermined amount at a given date.

  </summary> *)
[<AutoSerializable(true)>]
type SimpleCashFlowModel
    ( amount                                       : ICell<double>
    , date                                         : ICell<Date>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<SimpleCashFlow> ()
(*
    Parameters
*)
    let mutable
        _evaluationDate                            = evaluationDate
    let _amount                                    = amount
    let _date                                      = date
(*
    Functions
*)
    let mutable
        _SimpleCashFlow                            = cell (fun () -> (createEvaluationDate _evaluationDate (fun () ->new SimpleCashFlow (amount.Value, date.Value))))
    let _amount                                    = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.amount())
    let _date                                      = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.date())
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.Equals(cf.Value))
    let _exCouponDate                              = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.accept(v.Value)
                                                                     _SimpleCashFlow.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.registerWith(handler.Value)
                                                                     _SimpleCashFlow.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> (curryEvaluationDate _evaluationDate _SimpleCashFlow).Value.unregisterWith(handler.Value)
                                                                     _SimpleCashFlow.Value)
    do this.Bind(_SimpleCashFlow)
(* 
    casting 
*)
    interface IDateDependant with
        member this.EvaluationDate with get () = _evaluationDate and set d = _evaluationDate <- d

    internal new () = new SimpleCashFlowModel(null,null,null)
    member internal this.Inject v = _SimpleCashFlow <- v
    static member Cast (p : ICell<SimpleCashFlow>) = 
        if p :? SimpleCashFlowModel then 
            p :?> SimpleCashFlowModel
        else
            let o = new SimpleCashFlowModel ()
            o.Inject p
            if p :? IDateDependant then (o :> IDateDependant).EvaluationDate <- (p :?> IDateDependant).EvaluationDate
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.amount                             = _amount 
    member this.date                               = _date 
    member this.Amount                             = _amount
    member this.Date                               = _date
    member this.CompareTo                          cf   
                                                   = _CompareTo cf 
    member this.Equals                             cf   
                                                   = _Equals cf 
    member this.ExCouponDate                       = _exCouponDate
    member this.HasOccurred                        refDate includeRefDate   
                                                   = _hasOccurred refDate includeRefDate 
    member this.TradingExCoupon                    refDate   
                                                   = _tradingExCoupon refDate 
    member this.Accept                             v   
                                                   = _accept v 
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
