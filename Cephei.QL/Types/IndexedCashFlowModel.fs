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
  This cash flow is not a coupon, i.e., there's no accrual.  The amount is either i(T)/i(0) or i(T)/i(0) - 1, depending on the growthOnly parameter.  We expect this to be used inside an instrument that does all the date adjustment etc., so this takes just dates and does not change them. growthOnly = false means i(T)/i(0), which is a bond-type setting. growthOnly = true means i(T)/i(0) - 1, which is a swap-type setting.

  </summary> *)
[<AutoSerializable(true)>]
type IndexedCashFlowModel
    ( notional                                     : ICell<double>
    , index                                        : ICell<Index>
    , baseDate                                     : ICell<Date>
    , fixingDate                                   : ICell<Date>
    , paymentDate                                  : ICell<Date>
    , growthOnly                                   : ICell<bool>
    ) as this =

    inherit Model<IndexedCashFlow> ()
(*
    Parameters
*)
    let _notional                                  = notional
    let _index                                     = index
    let _baseDate                                  = baseDate
    let _fixingDate                                = fixingDate
    let _paymentDate                               = paymentDate
    let _growthOnly                                = growthOnly
(*
    Functions
*)
    let _IndexedCashFlow                           = cell (fun () -> new IndexedCashFlow (notional.Value, index.Value, baseDate.Value, fixingDate.Value, paymentDate.Value, growthOnly.Value))
    let _amount                                    = cell (fun () -> _IndexedCashFlow.Value.amount())
    let _baseDate                                  = cell (fun () -> _IndexedCashFlow.Value.baseDate())
    let _date                                      = cell (fun () -> _IndexedCashFlow.Value.date())
    let _fixingDate                                = cell (fun () -> _IndexedCashFlow.Value.fixingDate())
    let _growthOnly                                = cell (fun () -> _IndexedCashFlow.Value.growthOnly())
    let _index                                     = cell (fun () -> _IndexedCashFlow.Value.index())
    let _notional                                  = cell (fun () -> _IndexedCashFlow.Value.notional())
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _IndexedCashFlow.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = cell (fun () -> _IndexedCashFlow.Value.Equals(cf.Value))
    let _exCouponDate                              = cell (fun () -> _IndexedCashFlow.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = cell (fun () -> _IndexedCashFlow.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = cell (fun () -> _IndexedCashFlow.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _IndexedCashFlow.Value.accept(v.Value)
                                                                     _IndexedCashFlow.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _IndexedCashFlow.Value.registerWith(handler.Value)
                                                                     _IndexedCashFlow.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _IndexedCashFlow.Value.unregisterWith(handler.Value)
                                                                     _IndexedCashFlow.Value)
    do this.Bind(_IndexedCashFlow)

(* 
    Externally visible/bindable properties
*)
    member this.notional                           = _notional 
    member this.index                              = _index 
    member this.baseDate                           = _baseDate 
    member this.fixingDate                         = _fixingDate 
    member this.paymentDate                        = _paymentDate 
    member this.growthOnly                         = _growthOnly 
    member this.Amount                             = _amount
    member this.BaseDate                           = _baseDate
    member this.Date                               = _date
    member this.FixingDate                         = _fixingDate
    member this.GrowthOnly                         = _growthOnly
    member this.Index                              = _index
    member this.Notional                           = _notional
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
