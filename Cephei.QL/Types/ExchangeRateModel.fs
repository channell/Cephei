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
type ExchangeRateModel
    ( source                                       : ICell<Currency>
    , target                                       : ICell<Currency>
    , rate                                         : ICell<double>
    ) as this =

    inherit Model<ExchangeRate> ()
(*
    Parameters
*)
    let _source                                    = source
    let _target                                    = target
    let _rate                                      = rate
(*
    Functions
*)
    let mutable
        _ExchangeRate                              = cell (fun () -> new ExchangeRate (source.Value, target.Value, rate.Value))
    let _exchange                                  (amount : ICell<Money>)   
                                                   = triv (fun () -> _ExchangeRate.Value.exchange(amount.Value))
    let _HasValue                                  = triv (fun () -> _ExchangeRate.Value.HasValue)
    let _rate                                      = triv (fun () -> _ExchangeRate.Value.rate)
    let _source                                    = triv (fun () -> _ExchangeRate.Value.source)
    let _target                                    = triv (fun () -> _ExchangeRate.Value.target)
    let _type                                      = triv (fun () -> _ExchangeRate.Value.TYPE)
    do this.Bind(_ExchangeRate)
(* 
    casting 
*)
    internal new () = new ExchangeRateModel(null,null,null)
    member internal this.Inject v = _ExchangeRate <- v
    static member Cast (p : ICell<ExchangeRate>) = 
        if p :? ExchangeRateModel then 
            p :?> ExchangeRateModel
        else
            let o = new ExchangeRateModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.source                             = _source 
    member this.target                             = _target 
    member this.rate                               = _rate 
    member this.Exchange                           amount   
                                                   = _exchange amount 
    member this.HasValue                           = _HasValue
    member this.Rate                               = _rate
    member this.Source                             = _source
    member this.Target                             = _target
    member this.Type                               = _type
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type ExchangeRateModel1
    () as this =
    inherit Model<ExchangeRate> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _ExchangeRate                              = cell (fun () -> new ExchangeRate ())
    let _exchange                                  (amount : ICell<Money>)   
                                                   = triv (fun () -> _ExchangeRate.Value.exchange(amount.Value))
    let _HasValue                                  = triv (fun () -> _ExchangeRate.Value.HasValue)
    let _rate                                      = triv (fun () -> _ExchangeRate.Value.rate)
    let _source                                    = triv (fun () -> _ExchangeRate.Value.source)
    let _target                                    = triv (fun () -> _ExchangeRate.Value.target)
    let _type                                      = triv (fun () -> _ExchangeRate.Value.TYPE)
    do this.Bind(_ExchangeRate)
(* 
    casting 
*)
    
    member internal this.Inject v = _ExchangeRate <- v
    static member Cast (p : ICell<ExchangeRate>) = 
        if p :? ExchangeRateModel1 then 
            p :?> ExchangeRateModel1
        else
            let o = new ExchangeRateModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Exchange                           amount   
                                                   = _exchange amount 
    member this.HasValue                           = _HasValue
    member this.Rate                               = _rate
    member this.Source                             = _source
    member this.Target                             = _target
    member this.Type                               = _type
