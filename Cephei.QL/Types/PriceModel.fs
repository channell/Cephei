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
  amount to be paid upon callability

  </summary> *)
[<AutoSerializable(true)>]
type PriceModel
    ( amount                                       : ICell<double>
    , Type                                         : ICell<Type>
    ) as this =

    inherit Model<Price> ()
(*
    Parameters
*)
    let _amount                                    = amount
    let _Type                                      = Type
(*
    Functions
*)
    let mutable
        _Price                                     = cell (fun () -> new Price (amount.Value, Type.Value))
    let _amount                                    = cell (fun () -> _Price.Value.amount())
    let _type                                      = cell (fun () -> _Price.Value.TYPE())
    do this.Bind(_Price)
(* 
    casting 
*)
    internal new () = PriceModel(null,null)
    member internal this.Inject v = _Price <- v
    static member Cast (p : ICell<Price>) = 
        if p :? PriceModel then 
            p :?> PriceModel
        else
            let o = new PriceModel ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    internal new () = PriceModel(null,null)
    static member Cast (p : ICell<Price>) = 
        if p :? PriceModel then 
            p :?> PriceModel
        else
            let o = new PriceModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.amount                             = _amount 
    member this.Type                               = _Type 
    member this.Amount                             = _amount
    member this.Type                               = _type
(* <summary>
  amount to be paid upon callability

  </summary> *)
[<AutoSerializable(true)>]
type PriceModel1
    () as this =
    inherit Model<Price> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Price                                     = cell (fun () -> new Price ())
    let _amount                                    = cell (fun () -> _Price.Value.amount())
    let _type                                      = cell (fun () -> _Price.Value.TYPE())
    do this.Bind(_Price)
(* 
    casting 
*)
    
    member internal this.Inject v = _Price <- v
    static member Cast (p : ICell<Price>) = 
        if p :? PriceModel1 then 
            p :?> PriceModel1
        else
            let o = new PriceModel1 ()
            o.Inject p
            o.Bind p
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<Price>) = 
        if p :? PriceModel1 then 
            p :?> PriceModel1
        else
            let o = new PriceModel1 ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.Amount                             = _amount
    member this.Type                               = _type
