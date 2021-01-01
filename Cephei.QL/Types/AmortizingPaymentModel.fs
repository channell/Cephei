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
  This class specializes SimpleCashFlow so that visitors can perform more detailed cash-flow analysis.

  </summary> *)
[<AutoSerializable(true)>]
type AmortizingPaymentModel
    ( amount                                       : ICell<double>
    , date                                         : ICell<Date>
    ) as this =

    inherit Model<AmortizingPayment> ()
(*
    Parameters
*)
    let _amount                                    = amount
    let _date                                      = date
(*
    Functions
*)
    let mutable
        _AmortizingPayment                         = make (fun () -> new AmortizingPayment (amount.Value, date.Value))
    let _amount                                    = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.amount())
    let _date                                      = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.date())
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.Equals(cf.Value))
    let _exCouponDate                              = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.accept(v.Value)
                                                                                        _AmortizingPayment.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.registerWith(handler.Value)
                                                                                        _AmortizingPayment.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv _AmortizingPayment (fun () -> _AmortizingPayment.Value.unregisterWith(handler.Value)
                                                                                        _AmortizingPayment.Value)
    do this.Bind(_AmortizingPayment)
(* 
    casting 
*)
    internal new () = new AmortizingPaymentModel(null,null)
    member internal this.Inject v = _AmortizingPayment <- v
    static member Cast (p : ICell<AmortizingPayment>) = 
        if p :? AmortizingPaymentModel then 
            p :?> AmortizingPaymentModel
        else
            let o = new AmortizingPaymentModel ()
            o.Inject p
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
