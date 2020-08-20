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
type FractionalDividendModel
    ( rate                                         : ICell<double>
    , nominal                                      : ICell<double>
    , date                                         : ICell<Date>
    ) as this =

    inherit Model<FractionalDividend> ()
(*
    Parameters
*)
    let _rate                                      = rate
    let _nominal                                   = nominal
    let _date                                      = date
(*
    Functions
*)
    let _FractionalDividend                        = cell (fun () -> new FractionalDividend (rate.Value, nominal.Value, date.Value))
    let _amount                                    = cell (fun () -> _FractionalDividend.Value.amount())
    let _amount1                                   (underlying : ICell<double>)   
                                                   = cell (fun () -> _FractionalDividend.Value.amount(underlying.Value))
    let _nominal                                   = cell (fun () -> _FractionalDividend.Value.nominal())
    let _rate                                      = cell (fun () -> _FractionalDividend.Value.rate())
    let _date                                      = cell (fun () -> _FractionalDividend.Value.date())
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _FractionalDividend.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = cell (fun () -> _FractionalDividend.Value.Equals(cf.Value))
    let _exCouponDate                              = cell (fun () -> _FractionalDividend.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = cell (fun () -> _FractionalDividend.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = cell (fun () -> _FractionalDividend.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _FractionalDividend.Value.accept(v.Value)
                                                                     _FractionalDividend.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _FractionalDividend.Value.registerWith(handler.Value)
                                                                     _FractionalDividend.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _FractionalDividend.Value.unregisterWith(handler.Value)
                                                                     _FractionalDividend.Value)
    do this.Bind(_FractionalDividend)

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.nominal                            = _nominal 
    member this.date                               = _date 
    member this.Amount                             = _amount
    member this.Amount1                            underlying   
                                                   = _amount1 underlying 
    member this.Nominal                            = _nominal
    member this.Rate                               = _rate
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
(* <summary>
  This cash flow pays a predetermined amount at a given date.

  </summary> *)
[<AutoSerializable(true)>]
type FractionalDividendModel1
    ( rate                                         : ICell<double>
    , date                                         : ICell<Date>
    ) as this =

    inherit Model<FractionalDividend> ()
(*
    Parameters
*)
    let _rate                                      = rate
    let _date                                      = date
(*
    Functions
*)
    let _FractionalDividend                        = cell (fun () -> new FractionalDividend (rate.Value, date.Value))
    let _amount                                    = cell (fun () -> _FractionalDividend.Value.amount())
    let _amount1                                   (underlying : ICell<double>)   
                                                   = cell (fun () -> _FractionalDividend.Value.amount(underlying.Value))
    let _nominal                                   = cell (fun () -> _FractionalDividend.Value.nominal())
    let _rate                                      = cell (fun () -> _FractionalDividend.Value.rate())
    let _date                                      = cell (fun () -> _FractionalDividend.Value.date())
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _FractionalDividend.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = cell (fun () -> _FractionalDividend.Value.Equals(cf.Value))
    let _exCouponDate                              = cell (fun () -> _FractionalDividend.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = cell (fun () -> _FractionalDividend.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = cell (fun () -> _FractionalDividend.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _FractionalDividend.Value.accept(v.Value)
                                                                     _FractionalDividend.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _FractionalDividend.Value.registerWith(handler.Value)
                                                                     _FractionalDividend.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _FractionalDividend.Value.unregisterWith(handler.Value)
                                                                     _FractionalDividend.Value)
    do this.Bind(_FractionalDividend)

(* 
    Externally visible/bindable properties
*)
    member this.rate                               = _rate 
    member this.date                               = _date 
    member this.Amount                             = _amount
    member this.Amount1                            underlying   
                                                   = _amount1 underlying 
    member this.Nominal                            = _nominal
    member this.Rate                               = _rate
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
