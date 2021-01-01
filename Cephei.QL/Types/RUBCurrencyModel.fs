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
  The ISO three-letter code is RUB; the numeric code is 643. It is divided in 100 kopeyki.  currencies

  </summary> *)
[<AutoSerializable(true)>]
type RUBCurrencyModel
    () as this =
    inherit Model<RUBCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _RUBCurrency                               = make (fun () -> new RUBCurrency ())
    let _code                                      = triv _RUBCurrency (fun () -> _RUBCurrency.Value.code)
    let _empty                                     = triv _RUBCurrency (fun () -> _RUBCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _RUBCurrency (fun () -> _RUBCurrency.Value.Equals(o.Value))
    let _format                                    = triv _RUBCurrency (fun () -> _RUBCurrency.Value.format)
    let _fractionsPerUnit                          = triv _RUBCurrency (fun () -> _RUBCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv _RUBCurrency (fun () -> _RUBCurrency.Value.fractionSymbol)
    let _name                                      = triv _RUBCurrency (fun () -> _RUBCurrency.Value.name)
    let _numericCode                               = triv _RUBCurrency (fun () -> _RUBCurrency.Value.numericCode)
    let _rounding                                  = triv _RUBCurrency (fun () -> _RUBCurrency.Value.rounding)
    let _symbol                                    = triv _RUBCurrency (fun () -> _RUBCurrency.Value.symbol)
    let _ToString                                  = triv _RUBCurrency (fun () -> _RUBCurrency.Value.ToString())
    let _triangulationCurrency                     = triv _RUBCurrency (fun () -> _RUBCurrency.Value.triangulationCurrency)
    do this.Bind(_RUBCurrency)
(* 
    casting 
*)
    
    member internal this.Inject v = _RUBCurrency <- v
    static member Cast (p : ICell<RUBCurrency>) = 
        if p :? RUBCurrencyModel then 
            p :?> RUBCurrencyModel
        else
            let o = new RUBCurrencyModel ()
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
