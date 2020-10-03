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
type MonthlyYieldFinderModel
    ( faceAmount                                   : ICell<double>
    , cashflows                                    : ICell<Generic.List<CashFlow>>
    , settlement                                   : ICell<Date>
    ) as this =

    inherit Model<MonthlyYieldFinder> ()
(*
    Parameters
*)
    let _faceAmount                                = faceAmount
    let _cashflows                                 = cashflows
    let _settlement                                = settlement
(*
    Functions
*)
    let _MonthlyYieldFinder                        = cell (fun () -> new MonthlyYieldFinder (faceAmount.Value, cashflows.Value, settlement.Value))
    let _value                                     (Yield : ICell<double>)   
                                                   = triv (fun () -> _MonthlyYieldFinder.Value.value(Yield.Value))
    let _derivative                                (x : ICell<double>)   
                                                   = triv (fun () -> _MonthlyYieldFinder.Value.derivative(x.Value))
    do this.Bind(_MonthlyYieldFinder)
(* 
    casting 
*)
    internal new () = MonthlyYieldFinderModel(null,null,null)
    member internal this.Inject v = _MonthlyYieldFinder.Value <- v
    static member Cast (p : ICell<MonthlyYieldFinder>) = 
        if p :? MonthlyYieldFinderModel then 
            p :?> MonthlyYieldFinderModel
        else
            let o = new MonthlyYieldFinderModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.faceAmount                         = _faceAmount 
    member this.cashflows                          = _cashflows 
    member this.settlement                         = _settlement 
    member this.Value                              Yield   
                                                   = _value Yield 
    member this.Derivative                         x   
                                                   = _derivative x 
