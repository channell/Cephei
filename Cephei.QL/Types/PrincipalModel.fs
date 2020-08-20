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
  %principal payment over a fixed period   This class implements part of the CashFlow interface but it is still abstract and provides derived classes with methods for accrual period calculations.
Constructors
  </summary> *)
[<AutoSerializable(true)>]
type PrincipalModel
    () as this =
    inherit Model<Principal> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Principal                                 = cell (fun () -> new Principal ())
    let _accrualEndDate                            = cell (fun () -> _Principal.Value.accrualEndDate())
    let _accrualStartDate                          = cell (fun () -> _Principal.Value.accrualStartDate())
    let _amount                                    = cell (fun () -> _Principal.Value.amount())
    let _date                                      = cell (fun () -> _Principal.Value.date())
    let _dayCounter                                = cell (fun () -> _Principal.Value.dayCounter())
    let _nominal                                   = cell (fun () -> _Principal.Value.nominal())
    let _refPeriodEnd                              = cell (fun () -> _Principal.Value.refPeriodEnd)
    let _refPeriodStart                            = cell (fun () -> _Principal.Value.refPeriodStart)
    let _setAmount                                 (amount : ICell<double>)   
                                                   = cell (fun () -> _Principal.Value.setAmount(amount.Value)
                                                                     _Principal.Value)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _Principal.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = cell (fun () -> _Principal.Value.Equals(cf.Value))
    let _exCouponDate                              = cell (fun () -> _Principal.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = cell (fun () -> _Principal.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = cell (fun () -> _Principal.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _Principal.Value.accept(v.Value)
                                                                     _Principal.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _Principal.Value.registerWith(handler.Value)
                                                                     _Principal.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _Principal.Value.unregisterWith(handler.Value)
                                                                     _Principal.Value)
    do this.Bind(_Principal)

(* 
    Externally visible/bindable properties
*)
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualStartDate                   = _accrualStartDate
    member this.Amount                             = _amount
    member this.Date                               = _date
    member this.DayCounter                         = _dayCounter
    member this.Nominal                            = _nominal
    member this.RefPeriodEnd                       = _refPeriodEnd
    member this.RefPeriodStart                     = _refPeriodStart
    member this.SetAmount                          amount   
                                                   = _setAmount amount 
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
  %principal payment over a fixed period   This class implements part of the CashFlow interface but it is still abstract and provides derived classes with methods for accrual period calculations.
default constructor
  </summary> *)
[<AutoSerializable(true)>]
type PrincipalModel1
    ( amount                                       : ICell<double>
    , nominal                                      : ICell<double>
    , paymentDate                                  : ICell<Date>
    , accrualStartDate                             : ICell<Date>
    , accrualEndDate                               : ICell<Date>
    , dayCounter                                   : ICell<DayCounter>
    , refPeriodStart                               : ICell<Date>
    , refPeriodEnd                                 : ICell<Date>
    ) as this =

    inherit Model<Principal> ()
(*
    Parameters
*)
    let _amount                                    = amount
    let _nominal                                   = nominal
    let _paymentDate                               = paymentDate
    let _accrualStartDate                          = accrualStartDate
    let _accrualEndDate                            = accrualEndDate
    let _dayCounter                                = dayCounter
    let _refPeriodStart                            = refPeriodStart
    let _refPeriodEnd                              = refPeriodEnd
(*
    Functions
*)
    let _Principal                                 = cell (fun () -> new Principal (amount.Value, nominal.Value, paymentDate.Value, accrualStartDate.Value, accrualEndDate.Value, dayCounter.Value, refPeriodStart.Value, refPeriodEnd.Value))
    let _accrualEndDate                            = cell (fun () -> _Principal.Value.accrualEndDate())
    let _accrualStartDate                          = cell (fun () -> _Principal.Value.accrualStartDate())
    let _amount                                    = cell (fun () -> _Principal.Value.amount())
    let _date                                      = cell (fun () -> _Principal.Value.date())
    let _dayCounter                                = cell (fun () -> _Principal.Value.dayCounter())
    let _nominal                                   = cell (fun () -> _Principal.Value.nominal())
    let _refPeriodEnd                              = cell (fun () -> _Principal.Value.refPeriodEnd)
    let _refPeriodStart                            = cell (fun () -> _Principal.Value.refPeriodStart)
    let _setAmount                                 (amount : ICell<double>)   
                                                   = cell (fun () -> _Principal.Value.setAmount(amount.Value)
                                                                     _Principal.Value)
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = cell (fun () -> _Principal.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = cell (fun () -> _Principal.Value.Equals(cf.Value))
    let _exCouponDate                              = cell (fun () -> _Principal.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = cell (fun () -> _Principal.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = cell (fun () -> _Principal.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _Principal.Value.accept(v.Value)
                                                                     _Principal.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = cell (fun () -> _Principal.Value.registerWith(handler.Value)
                                                                     _Principal.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = cell (fun () -> _Principal.Value.unregisterWith(handler.Value)
                                                                     _Principal.Value)
    do this.Bind(_Principal)

(* 
    Externally visible/bindable properties
*)
    member this.amount                             = _amount 
    member this.nominal                            = _nominal 
    member this.paymentDate                        = _paymentDate 
    member this.accrualStartDate                   = _accrualStartDate 
    member this.accrualEndDate                     = _accrualEndDate 
    member this.dayCounter                         = _dayCounter 
    member this.refPeriodStart                     = _refPeriodStart 
    member this.refPeriodEnd                       = _refPeriodEnd 
    member this.AccrualEndDate                     = _accrualEndDate
    member this.AccrualStartDate                   = _accrualStartDate
    member this.Amount                             = _amount
    member this.Date                               = _date
    member this.DayCounter                         = _dayCounter
    member this.Nominal                            = _nominal
    member this.RefPeriodEnd                       = _refPeriodEnd
    member this.RefPeriodStart                     = _refPeriodStart
    member this.SetAmount                          amount   
                                                   = _setAmount amount 
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
