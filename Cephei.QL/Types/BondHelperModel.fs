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
  This class assumes that the reference date does not change between calls of setTermStructure().
! \warning Setting a pricing engine to the passed bond from external code will cause the bootstrap to fail or to give wrong results. It is advised to discard the bond after creating the helper, so that the helper has sole ownership of it.
  </summary> *)
[<AutoSerializable(true)>]
type BondHelperModel
    ( price                                        : ICell<Handle<Quote>>
    , bond                                         : ICell<Bond>
    , useCleanPrice                                : ICell<bool>
    ) as this =

    inherit Model<BondHelper> ()
(*
    Parameters
*)
    let _price                                     = price
    let _bond                                      = bond
    let _useCleanPrice                             = useCleanPrice
(*
    Functions
*)
    let _BondHelper                                = cell (fun () -> new BondHelper (price.Value, bond.Value, useCleanPrice.Value))
    let _bond                                      = triv (fun () -> _BondHelper.Value.bond())
    let _impliedQuote                              = triv (fun () -> _BondHelper.Value.impliedQuote())
    let _setTermStructure                          (t : ICell<YieldTermStructure>)   
                                                   = triv (fun () -> _BondHelper.Value.setTermStructure(t.Value)
                                                                     _BondHelper.Value)
    let _useCleanPrice                             = triv (fun () -> _BondHelper.Value.useCleanPrice())
    let _earliestDate                              = triv (fun () -> _BondHelper.Value.earliestDate())
    let _latestDate                                = triv (fun () -> _BondHelper.Value.latestDate())
    let _latestRelevantDate                        = triv (fun () -> _BondHelper.Value.latestRelevantDate())
    let _maturityDate                              = triv (fun () -> _BondHelper.Value.maturityDate())
    let _pillarDate                                = triv (fun () -> _BondHelper.Value.pillarDate())
    let _quote                                     = triv (fun () -> _BondHelper.Value.quote())
    let _quoteError                                = triv (fun () -> _BondHelper.Value.quoteError())
    let _quoteIsValid                              = triv (fun () -> _BondHelper.Value.quoteIsValid())
    let _quoteValue                                = triv (fun () -> _BondHelper.Value.quoteValue())
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BondHelper.Value.registerWith(handler.Value)
                                                                     _BondHelper.Value)
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _BondHelper.Value.unregisterWith(handler.Value)
                                                                     _BondHelper.Value)
    let _update                                    = triv (fun () -> _BondHelper.Value.update()
                                                                     _BondHelper.Value)
    do this.Bind(_BondHelper)

(* 
    Externally visible/bindable properties
*)
    member this.price                              = _price 
    member this.bond                               = _bond 
    member this.useCleanPrice                      = _useCleanPrice 
    member this.Bond                               = _bond
    member this.ImpliedQuote                       = _impliedQuote
    member this.SetTermStructure                   t   
                                                   = _setTermStructure t 
    member this.UseCleanPrice                      = _useCleanPrice
    member this.EarliestDate                       = _earliestDate
    member this.LatestDate                         = _latestDate
    member this.LatestRelevantDate                 = _latestRelevantDate
    member this.MaturityDate                       = _maturityDate
    member this.PillarDate                         = _pillarDate
    member this.Quote                              = _quote
    member this.QuoteError                         = _quoteError
    member this.QuoteIsValid                       = _quoteIsValid
    member this.QuoteValue                         = _quoteValue
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
    member this.Update                             = _update
