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
  The ISO three-letter code is MYR; the numeric code is 458. It is divided in 100 sen.  currencies

  </summary> *)
[<AutoSerializable(true)>]
type MYRCurrencyModel
    () as this =
    inherit Model<MYRCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _MYRCurrency                               = cell (fun () -> new MYRCurrency ())
    let _code                                      = cell (fun () -> _MYRCurrency.Value.code)
    let _empty                                     = cell (fun () -> _MYRCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _MYRCurrency.Value.Equals(o.Value))
    let _format                                    = cell (fun () -> _MYRCurrency.Value.format)
    let _fractionsPerUnit                          = cell (fun () -> _MYRCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = cell (fun () -> _MYRCurrency.Value.fractionSymbol)
    let _name                                      = cell (fun () -> _MYRCurrency.Value.name)
    let _numericCode                               = cell (fun () -> _MYRCurrency.Value.numericCode)
    let _rounding                                  = cell (fun () -> _MYRCurrency.Value.rounding)
    let _symbol                                    = cell (fun () -> _MYRCurrency.Value.symbol)
    let _ToString                                  = cell (fun () -> _MYRCurrency.Value.ToString())
    let _triangulationCurrency                     = cell (fun () -> _MYRCurrency.Value.triangulationCurrency)
    do this.Bind(_MYRCurrency)

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
