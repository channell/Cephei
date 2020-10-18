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
  Binary cash-or-nothing payoff

  </summary> *)
[<AutoSerializable(true)>]
type CashOrNothingPayoffModel
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    , cashPayoff                                   : ICell<double>
    ) as this =

    inherit Model<CashOrNothingPayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
    let _cashPayoff                                = cashPayoff
(*
    Functions
*)
    let mutable
        _CashOrNothingPayoff                       = cell (fun () -> new CashOrNothingPayoff (Type.Value, strike.Value, cashPayoff.Value))
    let _cashPayoff                                = triv (fun () -> _CashOrNothingPayoff.Value.cashPayoff())
    let _description                               = triv (fun () -> _CashOrNothingPayoff.Value.description())
    let _name                                      = triv (fun () -> _CashOrNothingPayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = triv (fun () -> _CashOrNothingPayoff.Value.value(price.Value))
    let _strike                                    = triv (fun () -> _CashOrNothingPayoff.Value.strike())
    let _optionType                                = triv (fun () -> _CashOrNothingPayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = triv (fun () -> _CashOrNothingPayoff.Value.accept(v.Value)
                                                                     _CashOrNothingPayoff.Value)
    do this.Bind(_CashOrNothingPayoff)
(* 
    casting 
*)
    internal new () = new CashOrNothingPayoffModel(null,null,null)
    member internal this.Inject v = _CashOrNothingPayoff <- v
    static member Cast (p : ICell<CashOrNothingPayoff>) = 
        if p :? CashOrNothingPayoffModel then 
            p :?> CashOrNothingPayoffModel
        else
            let o = new CashOrNothingPayoffModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.cashPayoff                         = _cashPayoff 
    member this.CashPayoff                         = _cashPayoff
    member this.Description                        = _description
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 
    member this.Strike                             = _strike
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
