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
type RendistatoCalculatorModel
    ( basket                                       : ICell<RendistatoBasket>
    , euriborIndex                                 : ICell<Euribor>
    , discountCurve                                : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<RendistatoCalculator> ()
(*
    Parameters
*)
    let _basket                                    = basket
    let _euriborIndex                              = euriborIndex
    let _discountCurve                             = discountCurve
(*
    Functions
*)
    let _RendistatoCalculator                      = cell (fun () -> new RendistatoCalculator (basket.Value, euriborIndex.Value, discountCurve.Value))
    let _duration                                  = triv (fun () -> _RendistatoCalculator.Value.duration())
    let _durations                                 = triv (fun () -> _RendistatoCalculator.Value.durations())
    let _equivalentSwap                            = triv (fun () -> _RendistatoCalculator.Value.equivalentSwap())
    let _equivalentSwapDuration                    = triv (fun () -> _RendistatoCalculator.Value.equivalentSwapDuration())
    let _equivalentSwapLength                      = triv (fun () -> _RendistatoCalculator.Value.equivalentSwapLength())
    let _equivalentSwapRate                        = triv (fun () -> _RendistatoCalculator.Value.equivalentSwapRate())
    let _equivalentSwapSpread                      = triv (fun () -> _RendistatoCalculator.Value.equivalentSwapSpread())
    let _equivalentSwapYield                       = triv (fun () -> _RendistatoCalculator.Value.equivalentSwapYield())
    let _swapDurations                             = triv (fun () -> _RendistatoCalculator.Value.swapDurations())
    let _swapLengths                               = triv (fun () -> _RendistatoCalculator.Value.swapLengths())
    let _swapRates                                 = triv (fun () -> _RendistatoCalculator.Value.swapRates())
    let _swapYields                                = triv (fun () -> _RendistatoCalculator.Value.swapYields())
    let _yield                                     = cell (fun () -> _RendistatoCalculator.Value.YIELD())
    let _yields                                    = cell (fun () -> _RendistatoCalculator.Value.yields())
    do this.Bind(_RendistatoCalculator)

(* 
    Externally visible/bindable properties
*)
    member this.basket                             = _basket 
    member this.euriborIndex                       = _euriborIndex 
    member this.discountCurve                      = _discountCurve 
    member this.Duration                           = _duration
    member this.Durations                          = _durations
    member this.EquivalentSwap                     = _equivalentSwap
    member this.EquivalentSwapDuration             = _equivalentSwapDuration
    member this.EquivalentSwapLength               = _equivalentSwapLength
    member this.EquivalentSwapRate                 = _equivalentSwapRate
    member this.EquivalentSwapSpread               = _equivalentSwapSpread
    member this.EquivalentSwapYield                = _equivalentSwapYield
    member this.SwapDurations                      = _swapDurations
    member this.SwapLengths                        = _swapLengths
    member this.SwapRates                          = _swapRates
    member this.SwapYields                         = _swapYields
    member this.Yield                              = _yield
    member this.Yields                             = _yields
