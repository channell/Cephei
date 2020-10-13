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
  Black-formula inflation cap/floor engine (standalone, i.e. no coupon pricer)

  </summary> *)
[<AutoSerializable(true)>]
type YoYInflationBlackCapFloorEngineModel
    ( index                                        : ICell<YoYInflationIndex>
    , volatility                                   : ICell<Handle<YoYOptionletVolatilitySurface>>
    ) as this =

    inherit Model<YoYInflationBlackCapFloorEngine> ()
(*
    Parameters
*)
    let _index                                     = index
    let _volatility                                = volatility
(*
    Functions
*)
    let _YoYInflationBlackCapFloorEngine           = cell (fun () -> new YoYInflationBlackCapFloorEngine (index.Value, volatility.Value))
    let _index                                     = triv (fun () -> _YoYInflationBlackCapFloorEngine.Value.index())
    let _setVolatility                             (vol : ICell<Handle<YoYOptionletVolatilitySurface>>)   
                                                   = triv (fun () -> _YoYInflationBlackCapFloorEngine.Value.setVolatility(vol.Value)
                                                                     _YoYInflationBlackCapFloorEngine.Value)
    let _volatility                                = triv (fun () -> _YoYInflationBlackCapFloorEngine.Value.volatility())
    do this.Bind(_YoYInflationBlackCapFloorEngine)
(* 
    casting 
*)
    internal new () = new YoYInflationBlackCapFloorEngineModel(null,null)
    member internal this.Inject v = _YoYInflationBlackCapFloorEngine.Value <- v
    static member Cast (p : ICell<YoYInflationBlackCapFloorEngine>) = 
        if p :? YoYInflationBlackCapFloorEngineModel then 
            p :?> YoYInflationBlackCapFloorEngineModel
        else
            let o = new YoYInflationBlackCapFloorEngineModel ()
            o.Inject p.Value
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.index                              = _index 
    member this.volatility                         = _volatility 
    member this.Index                              = _index
    member this.SetVolatility                      vol   
                                                   = _setVolatility vol 
    member this.Volatility                         = _volatility
