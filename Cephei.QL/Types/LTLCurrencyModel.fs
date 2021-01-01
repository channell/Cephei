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
type LTLCurrencyModel
    () as this =
    inherit Model<LTLCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _LTLCurrency                               = make (fun () -> new LTLCurrency ())
    let _code                                      = triv _LTLCurrency (fun () -> _LTLCurrency.Value.code)
    let _empty                                     = triv _LTLCurrency (fun () -> _LTLCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _LTLCurrency (fun () -> _LTLCurrency.Value.Equals(o.Value))
    let _format                                    = triv _LTLCurrency (fun () -> _LTLCurrency.Value.format)
    let _fractionsPerUnit                          = triv _LTLCurrency (fun () -> _LTLCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv _LTLCurrency (fun () -> _LTLCurrency.Value.fractionSymbol)
    let _name                                      = triv _LTLCurrency (fun () -> _LTLCurrency.Value.name)
    let _numericCode                               = triv _LTLCurrency (fun () -> _LTLCurrency.Value.numericCode)
    let _rounding                                  = triv _LTLCurrency (fun () -> _LTLCurrency.Value.rounding)
    let _symbol                                    = triv _LTLCurrency (fun () -> _LTLCurrency.Value.symbol)
    let _ToString                                  = triv _LTLCurrency (fun () -> _LTLCurrency.Value.ToString())
    let _triangulationCurrency                     = triv _LTLCurrency (fun () -> _LTLCurrency.Value.triangulationCurrency)
    do this.Bind(_LTLCurrency)
(* 
    casting 
*)
    
    member internal this.Inject v = _LTLCurrency <- v
    static member Cast (p : ICell<LTLCurrency>) = 
        if p :? LTLCurrencyModel then 
            p :?> LTLCurrencyModel
        else
            let o = new LTLCurrencyModel ()
            o.Inject p
            o.Bind p
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
