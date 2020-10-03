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
type CalculatorModel
    ( black                                        : ICell<BlackCalculator>
    ) as this =

    inherit Model<Calculator> ()
(*
    Parameters
*)
    let _black                                     = black
(*
    Functions
*)
    let _Calculator                                = cell (fun () -> new Calculator (black.Value))
    let _visit                                     (o : ICell<Object>)   
                                                   = cell (fun () -> _Calculator.Value.visit(o.Value)
                                                                     _Calculator.Value)
    let _visit1                                    (p : ICell<Payoff>)   
                                                   = cell (fun () -> _Calculator.Value.visit(p.Value)
                                                                     _Calculator.Value)
    let _visit2                                    (p : ICell<PlainVanillaPayoff>)   
                                                   = cell (fun () -> _Calculator.Value.visit(p.Value)
                                                                     _Calculator.Value)
    let _visit3                                    (payoff : ICell<CashOrNothingPayoff>)   
                                                   = cell (fun () -> _Calculator.Value.visit(payoff.Value)
                                                                     _Calculator.Value)
    let _visit4                                    (payoff : ICell<AssetOrNothingPayoff>)   
                                                   = cell (fun () -> _Calculator.Value.visit(payoff.Value)
                                                                     _Calculator.Value)
    let _visit5                                    (payoff : ICell<GapPayoff>)   
                                                   = cell (fun () -> _Calculator.Value.visit(payoff.Value)
                                                                     _Calculator.Value)
    do this.Bind(_Calculator)
(* 
    casting 
*)
    internal new () = CalculatorModel(null)
    member internal this.Inject v = _Calculator.Value <- v
    static member Cast (p : ICell<Calculator>) = 
        if p :? CalculatorModel then 
            p :?> CalculatorModel
        else
            let o = new CalculatorModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    internal new () = CalculatorModel(null)
    static member Cast (p : ICell<Calculator>) = 
        if p :? CalculatorModel then 
            p :?> CalculatorModel
        else
            let o = new CalculatorModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.black                              = _black 
    member this.Visit                              o   
                                                   = _visit o 
    member this.Visit1                             p   
                                                   = _visit1 p 
    member this.Visit2                             p   
                                                   = _visit2 p 
    member this.Visit3                             payoff   
                                                   = _visit3 payoff 
    member this.Visit4                             payoff   
                                                   = _visit4 payoff 
    member this.Visit5                             payoff   
                                                   = _visit5 payoff 
