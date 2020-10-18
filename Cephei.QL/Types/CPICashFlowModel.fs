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
  It is NOT a coupon, i.e. no accruals.

  </summary> *)
[<AutoSerializable(true)>]
type CPICashFlowModel
    ( notional                                     : ICell<double>
    , index                                        : ICell<ZeroInflationIndex>
    , baseDate                                     : ICell<Date>
    , baseFixing                                   : ICell<double>
    , fixingDate                                   : ICell<Date>
    , paymentDate                                  : ICell<Date>
    , growthOnly                                   : ICell<bool>
    , interpolation                                : ICell<InterpolationType>
    , frequency                                    : ICell<Frequency>
    ) as this =

    inherit Model<CPICashFlow> ()
(*
    Parameters
*)
    let _notional                                  = notional
    let _index                                     = index
    let _baseDate                                  = baseDate
    let _baseFixing                                = baseFixing
    let _fixingDate                                = fixingDate
    let _paymentDate                               = paymentDate
    let _growthOnly                                = growthOnly
    let _interpolation                             = interpolation
    let _frequency                                 = frequency
(*
    Functions
*)
    let mutable
        _CPICashFlow                               = cell (fun () -> new CPICashFlow (notional.Value, index.Value, baseDate.Value, baseFixing.Value, fixingDate.Value, paymentDate.Value, growthOnly.Value, interpolation.Value, frequency.Value))
    let _amount                                    = triv (fun () -> _CPICashFlow.Value.amount())
    let _baseDate                                  = triv (fun () -> _CPICashFlow.Value.baseDate())
    let _baseFixing                                = triv (fun () -> _CPICashFlow.Value.baseFixing())
    let _frequency                                 = triv (fun () -> _CPICashFlow.Value.frequency())
    let _interpolation                             = triv (fun () -> _CPICashFlow.Value.interpolation())
    let _date                                      = triv (fun () -> _CPICashFlow.Value.date())
    let _fixingDate                                = triv (fun () -> _CPICashFlow.Value.fixingDate())
    let _growthOnly                                = triv (fun () -> _CPICashFlow.Value.growthOnly())
    let _index                                     = triv (fun () -> _CPICashFlow.Value.index())
    let _notional                                  = triv (fun () -> _CPICashFlow.Value.notional())
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _CPICashFlow.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _CPICashFlow.Value.Equals(cf.Value))
    let _exCouponDate                              = triv (fun () -> _CPICashFlow.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _CPICashFlow.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _CPICashFlow.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _CPICashFlow.Value.accept(v.Value)
                                                                     _CPICashFlow.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CPICashFlow.Value.registerWith(handler.Value)
                                                                     _CPICashFlow.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _CPICashFlow.Value.unregisterWith(handler.Value)
                                                                     _CPICashFlow.Value)
    do this.Bind(_CPICashFlow)
(* 
    casting 
*)
    internal new () = new CPICashFlowModel(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _CPICashFlow <- v
    static member Cast (p : ICell<CPICashFlow>) = 
        if p :? CPICashFlowModel then 
            p :?> CPICashFlowModel
        else
            let o = new CPICashFlowModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.notional                           = _notional 
    member this.index                              = _index 
    member this.baseDate                           = _baseDate 
    member this.baseFixing                         = _baseFixing 
    member this.fixingDate                         = _fixingDate 
    member this.paymentDate                        = _paymentDate 
    member this.growthOnly                         = _growthOnly 
    member this.interpolation                      = _interpolation 
    member this.frequency                          = _frequency 
    member this.Amount                             = _amount
    member this.BaseDate                           = _baseDate
    member this.BaseFixing                         = _baseFixing
    member this.Frequency                          = _frequency
    member this.Interpolation                      = _interpolation
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
