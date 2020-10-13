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
  %Currency specification
default constructor Instances built via this constructor have undefined behavior. Such instances can only act as placeholders and must be reassigned to a valid currency before being used.
  </summary> *)
[<AutoSerializable(true)>]
type CurrencyModel
    () as this =
    inherit Model<Currency> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Currency                                  = cell (fun () -> new Currency ())
    let _code                                      = triv (fun () -> _Currency.Value.code)
    let _empty                                     = triv (fun () -> _Currency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Currency.Value.Equals(o.Value))
    let _format                                    = triv (fun () -> _Currency.Value.format)
    let _fractionsPerUnit                          = triv (fun () -> _Currency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv (fun () -> _Currency.Value.fractionSymbol)
    let _name                                      = triv (fun () -> _Currency.Value.name)
    let _numericCode                               = triv (fun () -> _Currency.Value.numericCode)
    let _rounding                                  = triv (fun () -> _Currency.Value.rounding)
    let _symbol                                    = triv (fun () -> _Currency.Value.symbol)
    let _ToString                                  = triv (fun () -> _Currency.Value.ToString())
    let _triangulationCurrency                     = triv (fun () -> _Currency.Value.triangulationCurrency)
    do this.Bind(_Currency)
(* 
    casting 
*)
    
    member internal this.Inject v = _Currency.Value <- v
    static member Cast (p : ICell<Currency>) = 
        if p :? CurrencyModel then 
            p :?> CurrencyModel
        else
            let o = new CurrencyModel ()
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
(* <summary>
  %Currency specification

  </summary> *)
[<AutoSerializable(true)>]
type CurrencyModel1
    ( name                                         : ICell<string>
    , code                                         : ICell<string>
    , numericCode                                  : ICell<int>
    , symbol                                       : ICell<string>
    , fractionSymbol                               : ICell<string>
    , fractionsPerUnit                             : ICell<int>
    , rounding                                     : ICell<Rounding>
    , formatString                                 : ICell<string>
    ) as this =

    inherit Model<Currency> ()
(*
    Parameters
*)
    let _name                                      = name
    let _code                                      = code
    let _numericCode                               = numericCode
    let _symbol                                    = symbol
    let _fractionSymbol                            = fractionSymbol
    let _fractionsPerUnit                          = fractionsPerUnit
    let _rounding                                  = rounding
    let _formatString                              = formatString
(*
    Functions
*)
    let _Currency                                  = cell (fun () -> new Currency (name.Value, code.Value, numericCode.Value, symbol.Value, fractionSymbol.Value, fractionsPerUnit.Value, rounding.Value, formatString.Value))
    let _code                                      = triv (fun () -> _Currency.Value.code)
    let _empty                                     = triv (fun () -> _Currency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Currency.Value.Equals(o.Value))
    let _format                                    = triv (fun () -> _Currency.Value.format)
    let _fractionsPerUnit                          = triv (fun () -> _Currency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv (fun () -> _Currency.Value.fractionSymbol)
    let _name                                      = triv (fun () -> _Currency.Value.name)
    let _numericCode                               = triv (fun () -> _Currency.Value.numericCode)
    let _rounding                                  = triv (fun () -> _Currency.Value.rounding)
    let _symbol                                    = triv (fun () -> _Currency.Value.symbol)
    let _ToString                                  = triv (fun () -> _Currency.Value.ToString())
    let _triangulationCurrency                     = triv (fun () -> _Currency.Value.triangulationCurrency)
    do this.Bind(_Currency)
(* 
    casting 
*)
    internal new () = new CurrencyModel1(null,null,null,null,null,null,null,null)
    member internal this.Inject v = _Currency.Value <- v
    static member Cast (p : ICell<Currency>) = 
        if p :? CurrencyModel1 then 
            p :?> CurrencyModel1
        else
            let o = new CurrencyModel1 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.name                               = _name 
    member this.code                               = _code 
    member this.numericCode                        = _numericCode 
    member this.symbol                             = _symbol 
    member this.fractionSymbol                     = _fractionSymbol 
    member this.fractionsPerUnit                   = _fractionsPerUnit 
    member this.rounding                           = _rounding 
    member this.formatString                       = _formatString 
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
(* <summary>
  %Currency specification

  </summary> *)
[<AutoSerializable(true)>]
type CurrencyModel2
    ( name                                         : ICell<string>
    , code                                         : ICell<string>
    , numericCode                                  : ICell<int>
    , symbol                                       : ICell<string>
    , fractionSymbol                               : ICell<string>
    , fractionsPerUnit                             : ICell<int>
    , rounding                                     : ICell<Rounding>
    , formatString                                 : ICell<string>
    , triangulationCurrency                        : ICell<Currency>
    ) as this =

    inherit Model<Currency> ()
(*
    Parameters
*)
    let _name                                      = name
    let _code                                      = code
    let _numericCode                               = numericCode
    let _symbol                                    = symbol
    let _fractionSymbol                            = fractionSymbol
    let _fractionsPerUnit                          = fractionsPerUnit
    let _rounding                                  = rounding
    let _formatString                              = formatString
    let _triangulationCurrency                     = triangulationCurrency
(*
    Functions
*)
    let _Currency                                  = cell (fun () -> new Currency (name.Value, code.Value, numericCode.Value, symbol.Value, fractionSymbol.Value, fractionsPerUnit.Value, rounding.Value, formatString.Value, triangulationCurrency.Value))
    let _code                                      = triv (fun () -> _Currency.Value.code)
    let _empty                                     = triv (fun () -> _Currency.Value.empty())
    let _Equals                                    (o : ICell<Object>)   
                                                   = triv (fun () -> _Currency.Value.Equals(o.Value))
    let _format                                    = triv (fun () -> _Currency.Value.format)
    let _fractionsPerUnit                          = triv (fun () -> _Currency.Value.fractionsPerUnit)
    let _fractionSymbol                            = triv (fun () -> _Currency.Value.fractionSymbol)
    let _name                                      = triv (fun () -> _Currency.Value.name)
    let _numericCode                               = triv (fun () -> _Currency.Value.numericCode)
    let _rounding                                  = triv (fun () -> _Currency.Value.rounding)
    let _symbol                                    = triv (fun () -> _Currency.Value.symbol)
    let _ToString                                  = triv (fun () -> _Currency.Value.ToString())
    let _triangulationCurrency                     = triv (fun () -> _Currency.Value.triangulationCurrency)
    do this.Bind(_Currency)
(* 
    casting 
*)
    internal new () = new CurrencyModel2(null,null,null,null,null,null,null,null,null)
    member internal this.Inject v = _Currency.Value <- v
    static member Cast (p : ICell<Currency>) = 
        if p :? CurrencyModel2 then 
            p :?> CurrencyModel2
        else
            let o = new CurrencyModel2 ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.name                               = _name 
    member this.code                               = _code 
    member this.numericCode                        = _numericCode 
    member this.symbol                             = _symbol 
    member this.fractionSymbol                     = _fractionSymbol 
    member this.fractionsPerUnit                   = _fractionsPerUnit 
    member this.rounding                           = _rounding 
    member this.formatString                       = _formatString 
    member this.triangulationCurrency              = _triangulationCurrency 
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
