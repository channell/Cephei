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
  Australian dollar   The ISO three-letter code is AUD; the numeric code is 36. It is divided into 100 cents.  currencies

  </summary> *)
[<AutoSerializable(true)>]
type AUDCurrencyModel
    () as this =
    inherit Model<AUDCurrency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _AUDCurrency                               = make (fun () -> new AUDCurrency ())
    let _code                                      = triv _AUDCurrency (fun () -> _AUDCurrency.Value.code)
    let _empty                                     = triv _AUDCurrency (fun () -> _AUDCurrency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv _AUDCurrency (fun () -> _AUDCurrency.Value.Equals(o.Value))
    let _format                                    = triv _AUDCurrency (fun () -> _AUDCurrency.Value.format)
    let _fractionsPerUnit                          = triv _AUDCurrency (fun () -> _AUDCurrency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv _AUDCurrency (fun () -> _AUDCurrency.Value.fractionSymbol)
    let _name                                      = triv _AUDCurrency (fun () -> _AUDCurrency.Value.name)
    let _numericCode                               = triv _AUDCurrency (fun () -> _AUDCurrency.Value.numericCode)
    let _rounding                                  = triv _AUDCurrency (fun () -> _AUDCurrency.Value.rounding)
    let _symbol                                    = triv _AUDCurrency (fun () -> _AUDCurrency.Value.symbol)
    let _ToString                                  = triv _AUDCurrency (fun () -> _AUDCurrency.Value.ToString())
    let _triangulationCurrency                     = triv _AUDCurrency (fun () -> _AUDCurrency.Value.triangulationCurrency)
    do this.Bind(_AUDCurrency)
(* 
    casting 
*)
    
    member internal this.Inject v = _AUDCurrency <- v
    static member Cast (p : ICell<AUDCurrency>) = 
        if p :? AUDCurrencyModel then 
            p :?> AUDCurrencyModel
        else
            let o = new AUDCurrencyModel ()
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
