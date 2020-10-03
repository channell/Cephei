﻿(*
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
type LVLCurrencyModel
    () as this =
    inherit Model<LVLCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _LVLCurrency                               = cell (fun () -> new LVLCurrency ())
    let _code                                      = triv (fun () -> _LVLCurrency.Value.code)
    let _empty                                     = triv (fun () -> _LVLCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _LVLCurrency.Value.Equals(o.Value))
    let _format                                    = triv (fun () -> _LVLCurrency.Value.format)
    let _fractionsPerUnit                          = triv (fun () -> _LVLCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv (fun () -> _LVLCurrency.Value.fractionSymbol)
    let _name                                      = triv (fun () -> _LVLCurrency.Value.name)
    let _numericCode                               = triv (fun () -> _LVLCurrency.Value.numericCode)
    let _rounding                                  = triv (fun () -> _LVLCurrency.Value.rounding)
    let _symbol                                    = triv (fun () -> _LVLCurrency.Value.symbol)
    let _ToString                                  = triv (fun () -> _LVLCurrency.Value.ToString())
    let _triangulationCurrency                     = triv (fun () -> _LVLCurrency.Value.triangulationCurrency)
    do this.Bind(_LVLCurrency)
(* 
    casting 
*)
    
    member internal this.Inject v = _LVLCurrency.Value <- v
    static member Cast (p : ICell<LVLCurrency>) = 
        if p :? LVLCurrencyModel then 
            p :?> LVLCurrencyModel
        else
            let o = new LVLCurrencyModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Code                               = _code
    member this.Empty                              = _empty
    member this.Equals                             o   
                                                   = _Equals o 
    member this.Format                             = _format
    member this.FractionsPerUnit                   = _fractionsPerUnit
    member this.FractionSymbol                     = _fractionSymbol
    member this.Name                               = _name
    member this.NumericCode                        = _numericCode
    member this.Rounding                           = _rounding
    member this.Symbol                             = _symbol
    member this.ToString                           = _ToString
    member this.TriangulationCurrency              = _triangulationCurrency
