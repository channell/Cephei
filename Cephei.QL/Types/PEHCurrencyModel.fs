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
  Peruvian sol   The ISO three-letter code was PEH. A numeric code is not available as per ISO 3166-1, we assign 999 as a user-defined code. It was divided in 100 centavos.  Obsoleted by the inti since February 1985.  currencies

  </summary> *)
[<AutoSerializable(true)>]
type PEHCurrencyModel
    () as this =
    inherit Model<PEHCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _PEHCurrency                               = cell (fun () -> new PEHCurrency ())
    let _code                                      = cell (fun () -> _PEHCurrency.Value.code)
    let _empty                                     = cell (fun () -> _PEHCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = cell (fun () -> _PEHCurrency.Value.Equals(o.Value))
    let _format                                    = cell (fun () -> _PEHCurrency.Value.format)
    let _fractionsPerUnit                          = cell (fun () -> _PEHCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = cell (fun () -> _PEHCurrency.Value.fractionSymbol)
    let _name                                      = cell (fun () -> _PEHCurrency.Value.name)
    let _numericCode                               = cell (fun () -> _PEHCurrency.Value.numericCode)
    let _rounding                                  = cell (fun () -> _PEHCurrency.Value.rounding)
    let _symbol                                    = cell (fun () -> _PEHCurrency.Value.symbol)
    let _ToString                                  = cell (fun () -> _PEHCurrency.Value.ToString())
    let _triangulationCurrency                     = cell (fun () -> _PEHCurrency.Value.triangulationCurrency)
    do this.Bind(_PEHCurrency)

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
