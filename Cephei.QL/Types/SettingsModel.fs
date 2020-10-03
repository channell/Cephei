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
type SettingsModel
    () as this =
    inherit Model<Settings> ()
(*
    Parameters
*)
(*
    Functions
*)
    let _Settings                                  = cell (fun () -> new Settings ())
    let _lowerRateBound_                           = cell (fun () -> _Settings.Value.lowerRateBound_)
    let _priceThreshold_                           = cell (fun () -> _Settings.Value.priceThreshold_)
    let _stdDevs_                                  = cell (fun () -> _Settings.Value.stdDevs_)
    let _strategy_                                 = cell (fun () -> _Settings.Value.strategy_)
    let _upperRateBound_                           = cell (fun () -> _Settings.Value.upperRateBound_)
    let _vegaRatio_                                = cell (fun () -> _Settings.Value.vegaRatio_)
    let _withBSStdDevs                             (stdDevs : ICell<double>) (lowerRateBound : ICell<double>) (upperRateBound : ICell<double>)   
                                                   = cell (fun () -> _Settings.Value.withBSStdDevs(stdDevs.Value, lowerRateBound.Value, upperRateBound.Value))
    let _withPriceThreshold                        (priceThreshold : ICell<double>) (lowerRateBound : ICell<double>) (upperRateBound : ICell<double>)   
                                                   = cell (fun () -> _Settings.Value.withPriceThreshold(priceThreshold.Value, lowerRateBound.Value, upperRateBound.Value))
    let _withRateBound                             (lowerRateBound : ICell<double>) (upperRateBound : ICell<double>)   
                                                   = cell (fun () -> _Settings.Value.withRateBound(lowerRateBound.Value, upperRateBound.Value))
    let _withVegaRatio                             (vegaRatio : ICell<double>) (lowerRateBound : ICell<double>) (upperRateBound : ICell<double>)   
                                                   = cell (fun () -> _Settings.Value.withVegaRatio(vegaRatio.Value, lowerRateBound.Value, upperRateBound.Value))
    do this.Bind(_Settings)
(* 
    casting 
*)
    
    member internal this.Inject v = _Settings.Value <- v
    static member Cast (p : ICell<Settings>) = 
        if p :? SettingsModel then 
            p :?> SettingsModel
        else
            let o = new SettingsModel ()
            o.Inject p.Value
            o
                            
(* 
    casting 
*)
    
    static member Cast (p : ICell<Settings>) = 
        if p :? SettingsModel then 
            p :?> SettingsModel
        else
            let o = new SettingsModel ()
            o.Value <- p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.LowerRateBound_                    = _lowerRateBound_
    member this.PriceThreshold_                    = _priceThreshold_
    member this.StdDevs_                           = _stdDevs_
    member this.Strategy_                          = _strategy_
    member this.UpperRateBound_                    = _upperRateBound_
    member this.VegaRatio_                         = _vegaRatio_
    member this.WithBSStdDevs                      stdDevs lowerRateBound upperRateBound   
                                                   = _withBSStdDevs stdDevs lowerRateBound upperRateBound 
    member this.WithPriceThreshold                 priceThreshold lowerRateBound upperRateBound   
                                                   = _withPriceThreshold priceThreshold lowerRateBound upperRateBound 
    member this.WithRateBound                      lowerRateBound upperRateBound   
                                                   = _withRateBound lowerRateBound upperRateBound 
    member this.WithVegaRatio                      vegaRatio lowerRateBound upperRateBound   
                                                   = _withVegaRatio vegaRatio lowerRateBound upperRateBound 
