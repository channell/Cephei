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
  Analytic formula for American exercise payoff at-expiry options   calculate greeks

  </summary> *)
[<AutoSerializable(true)>]
type AmericanPayoffAtExpiryModel
    ( spot                                         : ICell<double>
    , discount                                     : ICell<double>
    , dividendDiscount                             : ICell<double>
    , variance                                     : ICell<double>
    , payoff                                       : ICell<StrikedTypePayoff>
    , knock_in                                     : ICell<bool>
    ) as this =

    inherit Model<AmericanPayoffAtExpiry> ()
(*
    Parameters
*)
    let _spot                                      = spot
    let _discount                                  = discount
    let _dividendDiscount                          = dividendDiscount
    let _variance                                  = variance
    let _payoff                                    = payoff
    let _knock_in                                  = knock_in
(*
    Functions
*)
    let _AmericanPayoffAtExpiry                    = cell (fun () -> new AmericanPayoffAtExpiry (spot.Value, discount.Value, dividendDiscount.Value, variance.Value, payoff.Value, knock_in.Value))
    let _value                                     = cell (fun () -> _AmericanPayoffAtExpiry.Value.value())
    do this.Bind(_AmericanPayoffAtExpiry)

(* 
    Externally visible/bindable properties
*)
    member this.spot                               = _spot 
    member this.discount                           = _discount 
    member this.dividendDiscount                   = _dividendDiscount 
    member this.variance                           = _variance 
    member this.payoff                             = _payoff 
    member this.knock_in                           = _knock_in 
    member this.Value                              = _value
