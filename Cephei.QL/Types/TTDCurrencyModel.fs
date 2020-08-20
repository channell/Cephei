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
  Trinidad & Tobago dollar   The ISO three-letter code is TTD; the numeric code is 780. It is divided in 100 cents.  currencies

  </summary> *)
[<AutoSerializable(true)>]
type TTDCurrencyModel
    () as this =
    inherit Model<TTDCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _TTDCurrency                               = cell (fun () -> new TTDCurrency ())
    let _code                                      = cell (fun () -> _TTDCurrency.Value.code)
    let _empty                                     = cell (fun () -> _TTDCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _TTDCurrency.Value.Equals(o.Value))
    let _format                                    = cell (fun () -> _TTDCurrency.Value.format)
    let _fractionsPerUnit                          = cell (fun () -> _TTDCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = cell (fun () -> _TTDCurrency.Value.fractionSymbol)
    let _name                                      = cell (fun () -> _TTDCurrency.Value.name)
    let _numericCode                               = cell (fun () -> _TTDCurrency.Value.numericCode)
    let _rounding                                  = cell (fun () -> _TTDCurrency.Value.rounding)
    let _symbol                                    = cell (fun () -> _TTDCurrency.Value.symbol)
    let _ToString                                  = cell (fun () -> _TTDCurrency.Value.ToString())
    let _triangulationCurrency                     = cell (fun () -> _TTDCurrency.Value.triangulationCurrency)
    do this.Bind(_TTDCurrency)

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
