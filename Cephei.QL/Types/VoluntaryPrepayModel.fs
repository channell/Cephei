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
type VoluntaryPrepayModel
    ( amount                                       : ICell<double>
    , date                                         : ICell<Date>
    ) as this =

    inherit Model<VoluntaryPrepay> ()
(*
    Parameters
*)
    let _amount                                    = amount
    let _date                                      = date
(*
    Functions
*)
    let _VoluntaryPrepay                           = cell (fun () -> new VoluntaryPrepay (amount.Value, date.Value))
    let _amount                                    = triv (fun () -> _VoluntaryPrepay.Value.amount())
    let _date                                      = triv (fun () -> _VoluntaryPrepay.Value.date())
    let _CompareTo                                 (cf : ICell<CashFlow>)   
                                                   = triv (fun () -> _VoluntaryPrepay.Value.CompareTo(cf.Value))
    let _Equals                                    (cf : ICell<Object>)   
                                                   = triv (fun () -> _VoluntaryPrepay.Value.Equals(cf.Value))
    let _exCouponDate                              = triv (fun () -> _VoluntaryPrepay.Value.exCouponDate())
    let _hasOccurred                               (refDate : ICell<Date>) (includeRefDate : ICell<Nullable<bool>>)   
                                                   = triv (fun () -> _VoluntaryPrepay.Value.hasOccurred(refDate.Value, includeRefDate.Value))
    let _tradingExCoupon                           (refDate : ICell<Date>)   
                                                   = triv (fun () -> _VoluntaryPrepay.Value.tradingExCoupon(refDate.Value))
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _VoluntaryPrepay.Value.accept(v.Value)
                                                                     _VoluntaryPrepay.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _VoluntaryPrepay.Value.registerWith(handler.Value)
                                                                     _VoluntaryPrepay.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _VoluntaryPrepay.Value.unregisterWith(handler.Value)
                                                                     _VoluntaryPrepay.Value)
    do this.Bind(_VoluntaryPrepay)
(* 
    casting 
*)
    internal new () = new VoluntaryPrepayModel(null,null)
    member internal this.Inject v = _VoluntaryPrepay.Value <- v
    static member Cast (p : ICell<VoluntaryPrepay>) = 
        if p :? VoluntaryPrepayModel then 
            p :?> VoluntaryPrepayModel
        else
            let o = new VoluntaryPrepayModel ()
            o.Inject p.Value
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
